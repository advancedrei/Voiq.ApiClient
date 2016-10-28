using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class SurveysClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal SurveysClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<List<Survey>> GetAllForCampaignAsync(string campaignId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/surveys", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<List<Survey>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="surveyId"></param>
        /// <param name="getQuestions"></param>
        /// <param name="getSurveyResults"
        /// <returns></returns>
        public async Task<Survey> GetAsync(string campaignId, string surveyId, bool getQuestions = true, bool getSurveyResults = false)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/surveys/{surveyId}", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<Survey>(request);
            var survey =  await VoiqClient.ProcessResponse(response);

            if (getQuestions)
            {
                survey.Questions = await VoiqClient.Questions.GetAllForSurveyAsync(campaignId, surveyId);
            }

            if (getSurveyResults)
            {
                survey.Results = await VoiqClient.SurveyResults.GetAllForCampaignAsync(campaignId);
            }
            return survey;
        }

        #endregion

    }
}
