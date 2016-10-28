using Newtonsoft.Json;
using PortableRest;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Enums;
using Voiq.ApiClient.Exceptions;
using Voiq.ApiClient.Models;
using Voiq.ApiClient.Requests;
using Voiq.ApiClient.Responses;
using Voiq.ApiClient.SubClients;

namespace Voiq.ApiClient
{
    public class VoiqClient : RestClient
    {

        #region Private Methods

        private string baseUrlFormat = "https://{0}voiq.com/clients/api";

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        internal AuthTokens AuthTokens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string ClientId { get; }

        /// <summary>
        /// 
        /// </summary>
        private string ClientSecret { get; }

        /// <summary>
        /// 
        /// </summary>
        public PhoneCallsClient Calls { get; }

        /// <summary>
        /// 
        /// </summary>
        public CampaignsClient Campaigns { get; }

        /// <summary>
        /// 
        /// </summary>
        public LeadsClient Leads { get; }

        /// <summary>
        /// 
        /// </summary>
        public QuestionsClient Questions { get; }

        /// <summary>
        /// 
        /// </summary>
        public SurveyResultsClient SurveyResults { get; }

        /// <summary>
        /// 
        /// </summary>
        public SurveysClient Surveys { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public VoiqClient(string clientId, string clientSecret, Environments environment)
        {
            BaseUrl = GetBaseUrl(environment);
            ClientId = clientId;
            ClientSecret = clientSecret;
            Calls = new PhoneCallsClient(this);
            Campaigns = new CampaignsClient(this);
            Leads = new LeadsClient(this);
            Questions = new QuestionsClient(this);
            SurveyResults = new SurveyResultsClient(this);
            Surveys = new SurveysClient(this);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            var loginRequest = new LoginRequest(ClientId, ClientSecret);
            await LoginInternal(loginRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task RefreshTokenAsync()
        {
            var loginRequest = new TokenRefreshRequest(ClientId, ClientSecret, AuthTokens.AccessToken);
            await LoginInternal(loginRequest);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal async Task CheckIfTokenRefreshNeeded()
        {
            if (AuthTokens.IsExpired)
            {
                await RefreshTokenAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        internal string GetBaseUrl(Environments env)
        {
            switch (env)
            {
                case Environments.Dev:
                    return string.Format(baseUrlFormat, "dev.");
                case Environments.QA:
                    return string.Format(baseUrlFormat, "qa.");
                default:
                    return string.Format(baseUrlFormat, "app.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        internal async Task<RestRequest> GetRestRequest(string resource, HttpMethod method)
        {
            var request = new RestRequest(resource, method, ContentTypes.Json);
            await CheckIfTokenRefreshNeeded();
            request.AddHeader("Authorization", $"{AuthTokens.TokenType} {AuthTokens.AccessToken}");
            //TODO: This should not be required, but is due to an implementation issue in Voiq.
            if (method == HttpMethod.Get)
            {
                request.AddHeader("Accept", "application/json");
            }
            return request;
        }

        internal async Task LoginInternal<T>(T loginRequest) where T : class
        {
            var request = new RestRequest("oauth2/authorize", HttpMethod.Post, ContentTypes.Json);
            request.AddParameter(loginRequest);

            var response = await SendAsync<AuthTokens>(request);
            var result = await ProcessResponse(response);
            ProcessTokenResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        internal async Task<T> ProcessResponse<T>(RestResponse<T> response) where T: class
        {
            switch (response.HttpResponseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    return response.Content;

                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.PaymentRequired:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.MethodNotAllowed:
                    var result = await response.HttpResponseMessage.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(result);
                        throw new VoiqException(error);
                    }
                    throw new PortableRestException("An error occurred on the server.");

                case HttpStatusCode.InternalServerError:
                    throw new PortableRestException("An error occurred on the server.");

                default:
                    return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        internal void ProcessTokenResult(AuthTokens tokens)
        {
            tokens.ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(tokens.ExpiresInSeconds - 2);
            AuthTokens = tokens;
        }

        #endregion

    }

}