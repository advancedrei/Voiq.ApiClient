using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class PhoneCall : VoiqModelBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("disposition")]
        public CallDisposition Disposition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("duration")]
        public int? DurationInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("audio_url")]
        public string RecordingUrl { get; set; }

        /// <summary>
        /// Returns a string suitable for display in the debugger. Ensures such strings are compiled by the runtime and not interpreted by the currently-executing language.
        /// </summary>
        /// <remarks>http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx</remarks>
        private string DebuggerDisplay
        {
            get { return $"{DateCreated.ToString("d")}: {Disposition.Name}, {DurationInSeconds} sec"; }
        }

    }

}