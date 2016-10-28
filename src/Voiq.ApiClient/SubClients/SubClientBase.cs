namespace Voiq.ApiClient.SubClients
{

    /// <summary>
    /// 
    /// </summary>
    public class SubClientBase
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        internal VoiqClient VoiqClient { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voiqClient"></param>
        internal SubClientBase(VoiqClient voiqClient)
        {
            VoiqClient = voiqClient;
        }

        #endregion

    }
}
