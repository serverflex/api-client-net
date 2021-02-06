using ServerFlex.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerPackageOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        Task<ServerPackageEntity> GetServerPackageAsync(string cratePackageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        Task<TCratePackageEntity> GetServerPackageAsync<TCratePackageEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        Task<ServerPackageEntity[]> ListAllServerPackagesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        Task<TCratePackageEntity[]> ListAllServerPackagesAsync<TCratePackageEntity>(CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<ServerPackageEntity>> ListServerPackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<TCratePackageEntity>> ListServerPackagesAsync<TCratePackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class;

        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<ServerPropertyEntity[]> ListAllServerPackagePropertiesAsync(string packageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<TCrateSettingEntity[]> ListAllServerPackagePropertiesAsync<TCrateSettingEntity>(string packageName, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class;
        #endregion
    }
}
