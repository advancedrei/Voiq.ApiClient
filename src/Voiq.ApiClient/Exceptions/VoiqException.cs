using System;
using Voiq.ApiClient.Responses;

namespace Voiq.ApiClient.Exceptions
{
    public class VoiqException : Exception
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorResponse"></param>
        public VoiqException(ErrorResponse errorResponse) : base()
        {
            ErrorResponse = errorResponse;
        }

        #endregion

    }

}