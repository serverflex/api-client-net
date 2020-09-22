using BattleCrate.API.Operations;

namespace BattleCrate.API
{
    public interface IApiClient
    {
        #region Properties
        /// <summary>
        /// Gets the API operations for accounts.
        /// </summary>
        IAccountOperations Accounts { get; }

        /// <summary>
        /// Gets the API operations for Crate Packages.
        /// </summary>
        ICratePackageOperations CratePackages { get; }

        /// <summary>
        /// Gets the API operations for Crates.
        /// </summary>
        ICrateOperations Crates { get; }

        /// <summary>
        /// Gets the API operations for Regions.
        /// </summary>
        IRegionOperations Regions { get; }
        #endregion
    }
}
