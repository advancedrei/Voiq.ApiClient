using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class LeadsClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal LeadsClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<List<Lead>> GetAllAsync(string campaignId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/leads", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<List<Lead>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="leadId"></param>
        /// <param name="getCalls"></param>
        /// <param name="getSurveyResults"></param>
        /// <returns></returns>
        public async Task<Lead> GetAsync(string campaignId, string leadId, bool getCalls = true, bool getSurveyResults = true)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/leads/{leadId}", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<Lead>(request);
            var lead = await VoiqClient.ProcessResponse(response);

            if (getCalls)
            {
                lead.Calls = await VoiqClient.Calls.GetForCampaignContactAsync(campaignId, leadId);
            }

            if (getSurveyResults)
            {
                lead.SurveyResults = await VoiqClient.SurveyResults.GetForContactAsync(campaignId, leadId);
            }
            return lead;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Lead> DeleteAsync(string campaignId, string contactId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/contacts/{contactId}", HttpMethod.Delete);
            var response = await VoiqClient.SendAsync<Lead>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        #endregion

    }

}