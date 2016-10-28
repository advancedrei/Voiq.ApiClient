using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Voiq.ApiClient.Enums;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class QuestionBase : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("go_to_question_id")]
        public string GoToQuestionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(140)]
        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(500)]
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("options")]
        public List<QuestionOption> Options { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("question_type")]
        public QuestionTypes QuestionType { get; set; }

    }

}