using Newtonsoft.Json;

namespace Voiq.ApiClient.Models
{
    public class CampaignCallFrequencies
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("busy")]
        public CampaignCallFrequency Busy { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("call_later")]
        public CampaignCallFrequency CallLater { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("voicemail")]
        public CampaignCallFrequency Voicemail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("no_answer")]
        public CampaignCallFrequency NoAnswer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("puhu")]
        public CampaignCallFrequency PickUpHangUp { get; set; }

    }

}