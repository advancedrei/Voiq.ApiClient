using Newtonsoft.Json;

namespace Voiq.ApiClient.Requests
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class LoginRequestBase
    {

        #region Properties

        /// <summary>
        /// Client ID for the mobile application.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret for the mobile application.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Grant type for the authorization. Possible values are "password" or "refresh_token".
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="grantType"></param>
        public LoginRequestBase(string clientId, string clientSecret, string grantType)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            GrantType = grantType;
        }

        #endregion

    }

}