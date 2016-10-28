using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class SurveyResultsClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal SurveyResultsClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultsRequest"></param>
        /// <returns></returns>
        public async Task<List<SurveyResult>> GetAllForCampaignAsync(string campaignId, DateTime? since = null, DateTime? until = null)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/survey-results", HttpMethod.Get);

            if (since != null)
            {
                request.AddQueryString("since", since.Value.ToString("s") + "+00:00");
            }
            if (until != null)
            {
                request.AddQueryString("until", until.Value.ToString("s") + "+00:00");
            }

            var response = await VoiqClient.SendAsync<List<SurveyResult>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<List<SurveyResult>> GetForContactAsync(string campaignId, string contactId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/contacts/{contactId}/survey-results", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<List<SurveyResult>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        #endregion

    }
}
