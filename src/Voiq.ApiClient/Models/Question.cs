using Newtonsoft.Json;

namespace Voiq.ApiClient.Models
{
    public class Question : QuestionBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("has_other")]
        public bool HasOther { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder { get; set; }


    }
}
