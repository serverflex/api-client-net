using ServerFlex.API.Operations;
using System;

namespace ServerFlex.API
{
    public class ApiClient : BaseApiClient, IApiClient
    {
        #region Fields
        private readonly IAccountOperations _accountOperations;
        private readonly IRegionOperations _regionOperations;
        private readonly IServerOperations _serverOperations;
        private readonly IServerPackageOperations _serverPackageOperations;
        private readonly IServerSettingOperations _serverSettingOperations;
        private readonly IServerSharingOperations _serverSharingOperations;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the API operations for accounts.
        /// </summary>
        public virtual IAccountOperations Accounts => _accountOperations;

        /// <summary>
        /// Gets the API operations for Regions.
        /// </summary>
        public virtual IRegionOperations Regions => _regionOperations;

        /// <summary>
        /// Gets the API operations for server Packages.
        /// </summary>
        public virtual IServerPackageOperations ServerPackages => _serverPackageOperations;

        /// <summary>
        /// Gets the API operations for servers.
        /// </summary>
        public virtual IServerOperations Servers => _serverOperations;

        /// <summary>
        /// Gets the API operations for server settings.
        /// </summary>
        public virtual IServerSettingOperations ServerSettings => _serverSettingOperations;

        /// <summary>
        /// Gets the API operations for server sharing.
        /// </summary>
        public virtual IServerSharingOperations ServerSharing => _serverSharingOperations;
        #endregion

        #region Protected Methods
        protected virtual IAccountOperations ConstructAccountOpertaions()
        {
            return new AccountOperations(this);
        }

        protected virtual IRegionOperations ConstructRegionOpertaions()
        {
            return new RegionOperations(this);
        }

        protected virtual IServerOperations ConstructServerOpertaions()
        {
            return new ServerOperations(this);
        }

        protected virtual IServerPackageOperations ConstructServerPackageOpertaions()
        {
            return new ServerPackageOperations(this);
        }

        protected virtual IServerSettingOperations ConstructServerSettingOperations()
        {
            return new ServerSettingOperations(this);
        }

        protected virtual IServerSharingOperations ConstructServerSharingOperations()
        {
            return new ServerSharingOperations(this);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new ServerFlex API client with an optional custom base URI.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API, or null for default.</param>
        public ApiClient(Uri baseApiUri = null)
            : base(baseApiUri)
        {
            _accountOperations = ConstructAccountOpertaions();
            _regionOperations = ConstructRegionOpertaions();
            _serverOperations = ConstructServerOpertaions();
            _serverPackageOperations = ConstructServerPackageOpertaions();
            _serverSettingOperations = ConstructServerSettingOperations();
            _serverSharingOperations = ConstructServerSharingOperations();
        }
        #endregion
    }
}
