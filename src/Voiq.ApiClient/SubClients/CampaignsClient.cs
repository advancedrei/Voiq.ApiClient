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
    public class CampaignsClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        public CampaignsClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CampaignSummary>> GetAllAsync()
        {
            var request = await VoiqClient.GetRestRequest($"campaigns", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<List<CampaignSummary>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="getCalls"></param>
        /// <param name="getLeads"></param>
        /// <param name="getSurveys"></param>
        /// <param name="getSurveyResults"></param>
        /// <param name="since"></param>
        /// <param name="until"></param>
        /// <returns></returns>
        public async Task<Campaign> GetAsync(string campaignId, bool getCalls = false, bool getLeads = true, bool getSurveys = true, bool getSurveyResults = false, DateTime? since = null, DateTime? until = null)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<Campaign>(request);
            var campaign = await VoiqClient.ProcessResponse(response);

            if (getLeads)
            {
                var leads = await VoiqClient.Leads.GetAllAsync(campaignId);

                if (getCalls)
                {
                    // RWM: This version associates the retrieved calls with the existing leads.
                    leads = await VoiqClient.Calls.GetAllAsync(campaignId, leads, since, until);
                }
                campaign.Leads = leads;
            }

            // RWM: This is if they didn't ask for the Leads but they still want the Calls.
            if (getCalls && campaign.Leads == null)
            {
                campaign.Leads = await VoiqClient.Calls.GetAllAsync(campaignId, since, until);
            }

            if (getSurveys)
            {
                campaign.Surveys = await VoiqClient.Surveys.GetAllForCampaignAsync(campaignId);
            }

            if (getSurveyResults)
            {
                campaign.SurveyResults = await VoiqClient.SurveyResults.GetAllForCampaignAsync(campaignId, since, until);
            }

            return campaign;
        }

        #endregion

    }

}