using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class QuestionOption : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("go_to_question_id")]
        public string GoToQuestionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(150)]
        [JsonProperty("name")]
        public string Name { get; set; }

    }

}