using Newtonsoft.Json;
using System.Collections.Generic;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.Responses
{

    /// <summary>
    /// 
    /// </summary>
    public class CallsListResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("calls")]
        public List<PhoneCall> Calls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("contact")]
        public Lead Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lead")]
        public Lead Lead { get; set; }

    }

}