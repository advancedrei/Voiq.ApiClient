using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Voiq.ApiClient.Enums;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CampaignSummary : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("leads_completed")]
        public int LeadsCompleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("leads_total")]
        public int LeadsTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("end_date_at")]
        public DateTime DateEnds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("start_date_at")]
        public DateTime DateStarts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(60)]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("campaign_status_id")]
        public CampaignStatus Status { get; set; }

        /// <summary>
        /// Returns a string suitable for display in the debugger. Ensures such strings are compiled by the runtime and not interpreted by the currently-executing language.
        /// </summary>
        /// <remarks>http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx</remarks>
        private string DebuggerDisplay
        {
            get { return $"{Name}: [{LeadsCompleted}/{LeadsTotal}]"; }
        }

    }

}