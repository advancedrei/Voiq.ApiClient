using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Campaign : VoiqModelBase
    {

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public List<Lead> Calls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("campaign_call_frequencies")]
        public CampaignCallFrequencies CampaignCallFrequencies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("campaign_days")]
        public List<int> CampaignDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<Lead> Leads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2)]
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_date_at")]
        public DateTime DateEnds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iso_end_date_at")]
        public DateTimeOffset DateEndsUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("start_date_at")]
        public DateTime DateStarts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iso_start_date_at")]
        public DateTimeOffset DateStartsUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(500)]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extra_field_headers")]
        public List<string> ExtraFieldHeaders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(2000)]
        [JsonProperty("faq")]
        public string Faq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(500)]
        [JsonProperty("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(60)]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(120)]
        [JsonProperty("objective")]
        public string Objective { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<SurveyResult> SurveyResults { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<Survey> Surveys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_time_at")]
        public DateTime TimeEnds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("start_time_at")]
        public DateTime TimeStarts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timezone_id")]
        public int TimeZoneId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transfer_phone_number")]
        public string TransferPhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Returns a string suitable for display in the debugger. Ensures such strings are compiled by the runtime and not interpreted by the currently-executing language.
        /// </summary>
        /// <remarks>http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx</remarks>
        private string DebuggerDisplay
        {
            get { return $"{Name}: {Id}"; }
        }

    }

}