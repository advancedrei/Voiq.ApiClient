using Newtonsoft.Json;
using System.Collections.Generic;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.Requests
{

    /// <summary>
    /// 
    /// </summary>
    public class ContactsBulkRequest
    {

        /// <summary>
        /// Array with the list of contacts to create, with maximum of 1000 items
        /// </summary>
        [JsonProperty("contacts")]
        public List<Lead> Contacts { get; set; }

        /// <summary>
        /// Array with the name of the headers of the extra fields.
        /// </summary>
        [JsonProperty("extra_field_headers")]
        public List<string> ExtraFieldHeaders { get; set; }

    }

}