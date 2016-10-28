using Newtonsoft.Json;

namespace Voiq.ApiClient.Requests
{

    /// <summary>
    /// 
    /// </summary>
    internal class TokenRefreshRequest : LoginRequestBase
    {

        #region Properties

        /// <summary>
        /// Refresh token that will help renew the access token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId">Client ID for the mobile application.</param>
        /// <param name="clientSecret">Client secret for the mobile application.</param>
        /// <param name="refreshToken">Refresh token that will help renew the access token.</param>
        public TokenRefreshRequest(string clientId, string clientSecret, string refreshToken) : base(clientId, clientSecret, "refresh_token")
        {
            RefreshToken = refreshToken;
        }

        #endregion

    }

}