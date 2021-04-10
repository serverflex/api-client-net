using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class PackageOperations : BaseOperations, IPackageOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a package.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        public virtual Task<PackageEntity> GetPackageAsync(string packageName, CancellationToken cancellationToken = default)
        {
            return ((IPackageOperations)this).GetPackageAsync<PackageEntity>(packageName, cancellationToken);
        }

        /// <summary>
        /// Get a package.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        public virtual Task<TPackageEntity> GetPackageAsync<TPackageEntity>(string packageName, CancellationToken cancellationToken = default)
            where TPackageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TPackageEntity>(HttpMethod.Get, $"package/{packageName}", cancellationToken);
        }

        /// <summary>
        /// Get all available packages.
        /// </summary>
        public virtual Task<PackageEntity[]> ListAllPackagesAsync(CancellationToken cancellationToken = default)
        {
            return ((IPackageOperations)this).ListAllPackagesAsync<PackageEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all available packages.
        /// </summary>
        public virtual Task<TPackageEntity[]> ListAllPackagesAsync<TPackageEntity>(CancellationToken cancellationToken = default)
            where TPackageEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TPackageEntity>("package", cancellationToken);
        }

        /// <summary>
        /// Get a page of packages.
        /// </summary>
        /// <param name="limit">The maximum number of packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<PackageEntity>> ListPackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((IPackageOperations)this).ListPackagesAsync<PackageEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of packages.
        /// </summary>
        /// <param name="limit">The maximum number of packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<TPackageEntity>> ListPackagesAsync<TPackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TPackageEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TPackageEntity>(limit, page, "package", cancellationToken);
        }

        /// <summary>
        /// Get all package properties.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        public virtual Task<PackagePropertyEntity[]> ListAllPackagePropertiesAsync(string packageName, CancellationToken cancellationToken = default)
        {
            return ((IPackageOperations)this).ListAllPackagePropertiesAsync<PackagePropertyEntity>(packageName, cancellationToken);
        }

        /// <summary>
        /// Get all package properties.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        public virtual Task<TPackagePropertyEntity[]> ListAllPackagePropertiesAsync<TPackagePropertyEntity>(string packageName, CancellationToken cancellationToken = default)
            where TPackagePropertyEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TPackagePropertyEntity[]>(HttpMethod.Get, $"package/{packageName}/properties", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for packages.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public PackageOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
