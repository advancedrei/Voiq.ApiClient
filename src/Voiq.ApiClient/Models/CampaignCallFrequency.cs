using Newtonsoft.Json;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class CampaignCallFrequency
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time_lapse")]
        public string TimeLapse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_attempts")]
        public int MaxAttempts { get; set; }

    }

}