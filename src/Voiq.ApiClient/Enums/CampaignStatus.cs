
namespace Voiq.ApiClient.Enums
{

    /// <summary>
    /// 
    /// </summary>
    public enum CampaignStatus : int
    {
        /// <summary>
        /// The campaign is paused or in set up mode
        /// </summary>
        SetUp = 1,

        /// <summary>
        /// The campaign is live and the agents can make calls
        /// </summary>
        Live = 2,

        /// <summary>
        /// The campaign was deleted
        /// </summary>
        Deleted = 3,

        /// <summary>
        /// The campaign was completed and can't change from this status
        /// </summary>
        Completed = 4

    }

}