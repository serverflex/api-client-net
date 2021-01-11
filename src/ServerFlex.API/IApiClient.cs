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
        /// Gets the API operations for Regions.
        /// </summary>
        IRegionOperations Regions { get; }

        /// <summary>
        /// Gets the API operations for server Packages.
        /// </summary>
        IServerPackageOperations ServerPackages { get; }

        /// <summary>
        /// Gets the API operations for servers.
        /// </summary>
        IServerOperations Servers { get; }

        /// <summary>
        /// Gets the API operations for server settings.
        /// </summary>
        IServerSettingOperations ServerSettings { get; }

        /// <summary>
        /// Gets the API operations for server sharing.
        /// </summary>
        IServerSharingOperations ServerSharing { get; }
        #endregion
    }
}
