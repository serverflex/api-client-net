using BattleCrate.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface ICratePackageOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        Task<CratePackageEntity> GetCratePackageAsync(string cratePackageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        Task<TCratePackageEntity> GetCratePackageAsync<TCratePackageEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// <summary>
        /// Get a Crate Profile.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        Task<CrateProfileEntity> GetCrateProfileAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate Profile.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        Task<TCrateProfileEntity> GetCrateProfileAsync<TCrateProfileEntity>(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class;

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        Task<TCratePackageEntity[]> ListAllCratePackagesAsync<TCratePackageEntity>(CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// <summary>
        /// Get all available Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        Task<CrateProfileEntity[]> ListAllCrateProfilesAsync(string cratePackageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        Task<TCrateProfileEntity[]> ListAllCrateProfilesAsync<TCrateProfileEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class;

        /// <summary>
        /// Get all Crate Profile properties.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        Task<CrateProfilePropertyEntity[]> ListAllCrateProfilePropertiesAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all Crate Profile properties.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        Task<TCrateProfilePropertyEntity[]> ListAllCrateProfilePropertiesAsync<TCrateProfilePropertyEntity>(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            where TCrateProfilePropertyEntity : class;

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<TCratePackageEntity>> ListCratePackagesAsync<TCratePackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// <summary>
        /// Get a page of Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        /// <param name="limit">The maximum number of Crate Profiles that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<CrateProfileEntity>> ListCrateProfilesAsync(string cratePackageName, int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        /// <param name="limit">The maximum number of Crate Profiles that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TCrateProfileEntity>> ListCrateProfilesAsync<TCrateProfileEntity>(string cratePackageName, int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class;
        #endregion
    }
}
