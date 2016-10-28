using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class Survey : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset DateUpdatedUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<Question> Questions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<SurveyResult> Results { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(1000)]
        [JsonProperty("script")]
        public string Script { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(140)]
        [JsonProperty("script_instructions")]
        public string ScriptInstructions { get; set; }

    }

}