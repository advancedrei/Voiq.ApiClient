using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Voiq.ApiClient.Models;

namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class QuestionsClient : SubClientBase
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal QuestionsClient(VoiqClient voiqClient) : base(voiqClient)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultsRequest"></param>
        /// <returns></returns>
        public async Task<List<Question>> GetAllForSurveyAsync(string campaignId, string surveyId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/surveys/{surveyId}/questions", HttpMethod.Get);


            var response = await VoiqClient.SendAsync<List<Question>>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public async Task<Question> GetAsync(string campaignId, string surveyId, string questionId)
        {
            var request = await VoiqClient.GetRestRequest($"campaigns/{campaignId}/surveys/{surveyId}/questions/{questionId}", HttpMethod.Get);
            var response = await VoiqClient.SendAsync<Question>(request);
            return await VoiqClient.ProcessResponse(response);
        }

        #endregion

    }

}