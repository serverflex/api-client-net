using ServerFlex.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IPackageOperations
    {
        #region Methods
        /// <summary>
        /// Get a package.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        Task<PackageEntity> GetPackageAsync(string packageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a package.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        Task<TPackageEntity> GetPackageAsync<TPackageEntity>(string packageName, CancellationToken cancellationToken = default)
            where TPackageEntity : class;

        /// <summary>
        /// Get all available packages.
        /// </summary>
        Task<PackageEntity[]> ListAllPackagesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available packages.
        /// </summary>
        Task<TPackageEntity[]> ListAllPackagesAsync<TPackageEntity>(CancellationToken cancellationToken = default)
            where TPackageEntity : class;

        /// <summary>
        /// Get a page of packages.
        /// </summary>
        /// <param name="limit">The maximum number of packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<PackageEntity>> ListPackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of packages.
        /// </summary>
        /// <param name="limit">The maximum number of packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<TPackageEntity>> ListPackagesAsync<TPackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TPackageEntity : class;

        /// <summary>
        /// Get all package properties.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<PackagePropertyEntity[]> ListAllPackagePropertiesAsync(string packageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all package properties.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        Task<TPackagePropertyEntity[]> ListAllPackagePropertiesAsync<TPackagePropertyEntity>(string packageName, CancellationToken cancellationToken = default)
            where TPackagePropertyEntity : class;
        #endregion
    }
}
