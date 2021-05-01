using ServerFlex.API.Operations;

namespace ServerFlex.API
{
    public interface IApiClient
    {
        #region Properties
        /// <summary>
        /// Gets the API operations for accounts.
        /// </summary>
        IAccountOperations Accounts { get; }

        /// <summary>
        /// Gets the API operations for server packages.
        /// </summary>
        IPackageOperations Packages { get; }

        /// <summary>
        /// Gets the API operations for regions.
        /// </summary>
        IRegionOperations Regions { get; }

        /// <summary>
        /// Gets the API operations for servers.
        /// </summary>
        IServerOperations Servers { get; }

        /// <summary>
        /// Gets the API operations for server sharing.
        /// </summary>
        IServerSharingOperations ServerSharing { get; }

        /// <summary>
        /// Gets the API operations for server statistics.
        /// </summary>
        IServerStatisticsOperations ServerStatistics { get; }
        #endregion
    }
}
