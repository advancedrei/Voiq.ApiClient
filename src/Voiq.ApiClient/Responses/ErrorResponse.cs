using Newtonsoft.Json;
using System.Collections.Generic;

namespace Voiq.ApiClient.Responses
{

    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("errors")]
        public List<ValidationError> Errors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

    }

}