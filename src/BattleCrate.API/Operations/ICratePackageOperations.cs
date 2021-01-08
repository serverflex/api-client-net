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
        /// Get all available Crate Packages.
        /// </summary>
        Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        Task<TCratePackageEntity[]> ListAllCratePackagesAsync<TCratePackageEntity>(CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

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

        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<CrateSettingEntity[]> ListAllCratePackageProperties(string packageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<TCrateSettingEntity[]> ListAllCratePackageProperties<TCrateSettingEntity>(string packageName, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class;
        #endregion
    }
}
