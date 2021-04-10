using ServerFlex.API.Operations;
using System;

namespace ServerFlex.API
{
    public class ApiClient : BaseApiClient, IApiClient
    {
        #region Fields
        private readonly IAccountOperations _accountOperations;
        private readonly IPackageOperations _packageOperations;
        private readonly IRegionOperations _regionOperations;
        private readonly IServerOperations _serverOperations;
        private readonly IServerSharingOperations _serverSharingOperations;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the API operations for accounts.
        /// </summary>
        public virtual IAccountOperations Accounts => _accountOperations;

        /// <summary>
        /// Gets the API operations for server packages.
        /// </summary>
        public virtual IPackageOperations Packages => _packageOperations;

        /// <summary>
        /// Gets the API operations for regions.
        /// </summary>
        public virtual IRegionOperations Regions => _regionOperations;

        /// <summary>
        /// Gets the API operations for servers.
        /// </summary>
        public virtual IServerOperations Servers => _serverOperations;

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

        protected virtual IPackageOperations ConstructPackageOpertaions()
        {
            return new PackageOperations(this);
        }

        protected virtual IRegionOperations ConstructRegionOpertaions()
        {
            return new RegionOperations(this);
        }

        protected virtual IServerOperations ConstructServerOpertaions()
        {
            return new ServerOperations(this);
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
            _packageOperations = ConstructPackageOpertaions();
            _serverSharingOperations = ConstructServerSharingOperations();
        }
        #endregion
    }
}
