using BattleCrate.API.Operations;
using System;

namespace BattleCrate.API
{
    public class ApiClient : BaseApiClient, IApiClient
    {
        #region Fields
        private IAccountOperations _accountOperations;
        private ICrateOperations _crateOperations;
        private ICratePackageOperations _cratePackageOperations;
        private IRegionOperations _regionOperations;
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

        protected virtual IRegionOperations ConstructRegionOpertaions()
            => new RegionOperations(this);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new BattleCrate API client.
        /// </summary>
        public ApiClient()
            : base()
            => Initialize();

        /// <summary>
        /// Creates a new BattleCrate API client with an API key.
        /// </summary>
        /// <param name="apiKey">Your BattleCrate API key.</param>
        public ApiClient(string apiKey)
            : base(apiKey)
            => Initialize();

        /// <summary>
        /// Creates a new BattleCrate API client with a custom base URI.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API.</param>
        public ApiClient(Uri baseApiUri)
            : base(baseApiUri)
            => Initialize();

        /// <summary>
        /// Creates a new BattleCrate API client with a custom base URI and an API key.
        /// </summary>
        /// <param name="baseApiUri">The base URI to use for the API.</param>
        /// <param name="apiKey">Your BattleCrate API key.</param>
        public ApiClient(Uri baseApiUri, string apiKey)
            : base(baseApiUri, apiKey)
            => Initialize();
        #endregion

        #region Private Methods
        private void Initialize()
        {
            _accountOperations = ConstructAccountOpertaions();
            _crateOperations = ConstructCrateOpertaions();
            _cratePackageOperations = ConstructCratePackageOpertaions();
            _regionOperations = ConstructRegionOpertaions();
        }
        #endregion
    }
}
