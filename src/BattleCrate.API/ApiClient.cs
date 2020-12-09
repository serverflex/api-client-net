using BattleCrate.API.Operations;
using System;

namespace BattleCrate.API
{
    public class ApiClient : BaseApiClient, IApiClient
    {
        #region Fields
        private readonly IAccountOperations _accountOperations;
        private readonly ICrateOperations _crateOperations;
        private readonly ICratePackageOperations _cratePackageOperations;
        private readonly ICrateSettingOperations _crateSettingOperations;
        private readonly ICrateSharingOperations _crateSharingOperations;
        private readonly IRegionOperations _regionOperations;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the API operations for accounts.
        /// </summary>
        public virtual IAccountOperations Accounts => _accountOperations;

        /// <summary>
        /// Gets the API operations for Crate Packages.
        /// </summary>
        public virtual ICratePackageOperations CratePackages => _cratePackageOperations;

        /// <summary>
        /// Gets the API operations for Crates.
        /// </summary>
        public virtual ICrateOperations Crates => _crateOperations;

        /// <summary>
        /// Gets the API operations for Crate settings.
        /// </summary>
        public virtual ICrateSettingOperations CrateSettings => _crateSettingOperations;

        /// <summary>
        /// Gets the API operations for Crate sharing.
        /// </summary>
        public virtual ICrateSharingOperations CrateSharing => _crateSharingOperations;

        /// <summary>
        /// Gets the API operations for Regions.
        /// </summary>
        public virtual IRegionOperations Regions => _regionOperations;
        #endregion

        #region Protected Methods
        protected virtual IAccountOperations ConstructAccountOpertaions()
            => new AccountOperations(this);

        protected virtual ICrateOperations ConstructCrateOpertaions()
            => new CrateOperations(this);

        protected virtual ICratePackageOperations ConstructCratePackageOpertaions()
            => new CratePackageOperations(this);

        protected virtual ICrateSettingOperations ConstructCrateSettingOperations()
        {
            return new CrateSettingOperations(this);
        }

        protected virtual ICrateSharingOperations ConstructCrateSharingOperations()
            => new CrateSharingOperations(this);

        protected virtual IRegionOperations ConstructRegionOpertaions()
            => new RegionOperations(this);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new BattleCrate API client with an optional custom base URI.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API, or null for default.</param>
        public ApiClient(Uri baseApiUri = null)
            : base(baseApiUri)
        {
            _accountOperations = ConstructAccountOpertaions();
            _crateOperations = ConstructCrateOpertaions();
            _cratePackageOperations = ConstructCratePackageOpertaions();
            _crateSettingOperations = ConstructCrateSettingOperations();
            _crateSharingOperations = ConstructCrateSharingOperations();
            _regionOperations = ConstructRegionOpertaions();
        }
        #endregion
    }
}
