using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Models;
using Voiq.ApiClient.Responses;

namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class PhoneCallsClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal PhoneCallsClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<List<Lead>> GetAllAsync(string campaignId, DateTime? since = null, DateTime? until = null)
        {
            var response = await GetAllInternalAsync(campaignId, since, until);
            var results = response.Select(c => { c.Lead.Calls = c.Calls; return c.Lead; });
            return results.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="leads"></param>
        /// <returns></returns>
        public async Task<List<Lead>> GetAllAsync(string campaignId, List<Lead> leads, DateTime? since = null, DateTime? until = null)
        {
            var response = await GetAllInternalAsync(campaignId, since, until);

            var tempResults =
                from lead in leads
                join calls in response on lead.Id equals calls.Lead.Id
                select new { lead, calls.Calls };

            var results = tempResults.Select(c => { c.lead.Calls = c.Calls; return c.lead; });
            return results.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="leadId"></param>
        /// <returns></returns>
        public async Task<List<PhoneCall>> GetForCampaignContactAsync(string campaignId, string leadId)
        {
            var callsRequest = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/leads/{leadId}/calls", HttpMethod.Get);
            var callsResponse = await VoiqClient.SendAsync<List<PhoneCall>>(callsRequest);
            return await VoiqClient.ProcessResponse(callsResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task GetForCampaignContactAsync(string campaignId, Lead contact)
        {
            contact.Calls = await GetForCampaignContactAsync(campaignId, contact.Id);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        private async Task<List<CallsListResponse>> GetAllInternalAsync(string campaignId, DateTime? since = null, DateTime? until = null)
        {
            var callsRequest = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/calls", HttpMethod.Get);

            if (since != null)
            {
                callsRequest.AddQueryString("since", since.Value.ToString("s") + "+00:00");
            }
            if (until != null)
            {
                callsRequest.AddQueryString("until", until.Value.ToString("s") + "+00:00");
            }

            var callsResponse = await VoiqClient.SendAsync<List<CallsListResponse>>(callsRequest);
            var response = await VoiqClient.ProcessResponse(callsResponse);
            return response;
        }

        #endregion

    }

}