using Newtonsoft.Json;
using System.Diagnostics;

namespace Voiq.ApiClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Answer
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("question")]
        public Question Question { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("question_option_id")]
        public string OptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("question_option_name")]
        public string OptionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("answer")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("other_answer")]
        public string OtherAnswer { get; set; }

        /// <summary>
        /// Returns a string suitable for display in the debugger. Ensures such strings are compiled by the runtime and not interpreted by the currently-executing language.
        /// </summary>
        /// <remarks>http://blogs.msdn.com/b/jaredpar/archive/2011/03/18/debuggerdisplay-attribute-best-practices.aspx</remarks>
        private string DebuggerDisplay
        {
            get { return $"{Question.Name.Replace(":", "")}: {Value ?? OtherAnswer}"; }
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"{Question.Name.Replace(":", "")}: {Value ?? OtherAnswer}";
        }

        #endregion

    }

}