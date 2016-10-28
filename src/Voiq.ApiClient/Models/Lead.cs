using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Lead : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<PhoneCall> Calls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(100)]
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ext_1")]
        public string Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_1")]
        public string Extra01 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_2")]
        public string Extra02 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_3")]
        public string Extra03 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_4")]
        public string Extra04 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_5")]
        public string Extra05 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_6")]
        public string Extra06 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_7")]
        public string Extra07 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_8")]
        public string Extra08 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_9")]
        public string Extra09 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_10")]
        public string Extra10 { get; set; }

        /// <summary>
        /// First name of the contact.
        /// </summary>
        [StringLength(100)]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the contact.
        /// </summary>
        [StringLength(100)]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Phone number of the contact in the E.164 format.
        /// </summary>
        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<SurveyResult> SurveyResults { get; set; }

        /// <summary>
        /// Zip code of the contact location.
        /// </summary>
        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Returns a string suitable for display in the debugger. Ensures such strings are compiled by the runtime and not interpreted by the currently-executing language.
        /// </summary>
        /// <remarks>http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx</remarks>
        private string DebuggerDisplay
        {
            get { return $"{FirstName} {LastName}, {CompanyName}"; }
        }

    }

}