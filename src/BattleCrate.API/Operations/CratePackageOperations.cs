using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class CratePackageOperations : BaseOperations, ICratePackageOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        public virtual Task<CratePackageEntity> GetCratePackageAsync(string cratePackageName, CancellationToken cancellationToken = default)
        {
            return ((ICratePackageOperations)this).GetCratePackageAsync<CratePackageEntity>(cratePackageName, cancellationToken);
        }

        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        public virtual Task<TCratePackageEntity> GetCratePackageAsync<TCratePackageEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TCratePackageEntity>(HttpMethod.Get, $"crate_package/{cratePackageName}", cancellationToken);
        }

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        public virtual Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default)
        {
            return ((ICratePackageOperations)this).ListAllCratePackagesAsync<CratePackageEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        public virtual Task<TCratePackageEntity[]> ListAllCratePackagesAsync<TCratePackageEntity>(CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TCratePackageEntity>("crate_package", cancellationToken);
        }

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((ICratePackageOperations)this).ListCratePackagesAsync<CratePackageEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<TCratePackageEntity>> ListCratePackagesAsync<TCratePackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TCratePackageEntity>(limit, page, "crate_package", cancellationToken);
        }
        
        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        public Task<CrateSettingEntity[]> ListAllCratePackageProperties(string packageName, CancellationToken cancellationToken = default)
        {
            return ((ICratePackageOperations)this).ListAllCratePackageProperties<CrateSettingEntity>(packageName, cancellationToken);
        }

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="packageName">The package name.</param>
        public Task<TCrateSettingEntity[]> ListAllCratePackageProperties<TCrateSettingEntity>(string packageName, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TCrateSettingEntity[]>(HttpMethod.Get, $"crate_package/{packageName}/properties", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crate Packages.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CratePackageOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
