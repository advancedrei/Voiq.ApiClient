using Newtonsoft.Json;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.Requests
{
    public class CreateQuestionRequest : QuestionBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("add_other")]
        public bool AddOther { get; set; }

        /// <summary>
        /// Possible values are: "Text", and "Number".
        /// </summary>
        [JsonProperty("question_validation_type")]
        public string ValidationType { get; set; }

        /// <summary>
        /// Possible values for "Text" are: "email", and "url". Possible values for "Number" are: "phone_number", and "zip_code".
        /// </summary>
        [JsonProperty("question_validation_type_item")]
        public string ValidationTypeItem { get; set; }

    }

}