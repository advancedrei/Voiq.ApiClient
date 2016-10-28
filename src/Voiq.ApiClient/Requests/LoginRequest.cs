using Newtonsoft.Json;

namespace Voiq.ApiClient.Requests
{

    /// <summary>
    /// 
    /// </summary>
    internal class LoginRequest : LoginRequestBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId">Client ID for the mobile application.</param>
        /// <param name="clientSecret">Client secret for the mobile application.</param>
        /// <param name="username">Email of the agent that wants to access the application.</param>
        /// <param name="password">Password of the agent that wants to access the application.</param>
        public LoginRequest(string clientId, string clientSecret) : base(clientId, clientSecret, "client_credentials")
        {
        }

        #endregion

    }

}