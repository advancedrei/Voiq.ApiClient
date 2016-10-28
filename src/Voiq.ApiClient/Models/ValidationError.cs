using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voiq.ApiClient
{

    /// <summary>
    /// 
    /// </summary>
    public class ValidationError
    {

        /// <summary>
        /// The details of the error for this particular field.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The field that threw the error.
        /// </summary>
        public string Field { get; set; }

    }

}