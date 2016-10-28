using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Voiq.ApiClient.Models
{
    public class SurveyResult : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("call_log_id")]
        public string CallLogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("contact")]
        public Lead Lead { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("results")]
        public List<Answer> Results { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("survey_id")]
        public string SurveyId { get; set; }

    }

}