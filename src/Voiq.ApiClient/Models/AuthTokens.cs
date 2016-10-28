using Newtonsoft.Json;
using System;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    internal class AuthTokens
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset ExpiresUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresInSeconds { get; set; }

        /// <summary>
        /// Returns whether or not this token is currently valid, with a large enough time-buffer to account for network latency.
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => ExpiresUtc.AddSeconds(-5) <= DateTime.UtcNow;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

    }

}