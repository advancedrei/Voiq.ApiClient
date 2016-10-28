using Newtonsoft.Json;
using System;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class VoiqDateWithTimeZone
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timezone_type")]
        public string TimeZoneType { get; set; }

    }

}