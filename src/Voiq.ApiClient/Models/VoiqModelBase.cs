using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [StringLength(255)]
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

    }

}