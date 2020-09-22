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
            => ((ICratePackageOperations)this).GetCratePackageAsync<CratePackageEntity>(cratePackageName, cancellationToken);

        /// <summary>
        /// Get a Crate Package.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        public virtual Task<TCratePackageEntity> GetCratePackageAsync<TCratePackageEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<TCratePackageEntity>(HttpMethod.Get, $"crate_package/{cratePackageName}", cancellationToken);

        /// <summary>
        /// Get a Crate Profile.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public virtual Task<CrateProfileEntity> GetCrateProfileAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).GetCrateProfileAsync<CrateProfileEntity>(cratePackageName, crateProfileName, cancellationToken);

        /// <summary>
        /// Get a Crate Profile.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public virtual Task<TCrateProfileEntity> GetCrateProfileAsync<TCrateProfileEntity>(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<TCrateProfileEntity>(HttpMethod.Get, $"crate_package/{cratePackageName}/profile/{crateProfileName}", cancellationToken);

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        public virtual Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).ListAllCratePackagesAsync<CratePackageEntity>(cancellationToken);

        /// <summary>
        /// Get all available Crate Packages.
        /// </summary>
        public virtual Task<TCratePackageEntity[]> ListAllCratePackagesAsync<TCratePackageEntity>(CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
            => ApiRequestor.RequestEntireListJsonSerializedAsync<TCratePackageEntity>("crate_package", cancellationToken);

        /// <summary>
        /// Get all available Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        public virtual Task<CrateProfileEntity[]> ListAllCrateProfilesAsync(string cratePackageName, CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).ListAllCrateProfilesAsync<CrateProfileEntity>(cratePackageName, cancellationToken);

        /// <summary>
        /// Get all available Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        public virtual Task<TCrateProfileEntity[]> ListAllCrateProfilesAsync<TCrateProfileEntity>(string cratePackageName, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class
            => ApiRequestor.RequestEntireListJsonSerializedAsync<TCrateProfileEntity>($"crate_package/{cratePackageName}/profile", cancellationToken);

        /// <summary>
        /// Get all Crate Profile properties.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public virtual Task<CrateProfilePropertyEntity[]> ListAllCrateProfilePropertiesAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).ListAllCrateProfilePropertiesAsync<CrateProfilePropertyEntity>(cratePackageName, crateProfileName, cancellationToken);

        /// <summary>
        /// Get all Crate Profile properties.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profile belongs to.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public virtual Task<TCrateProfilePropertyEntity[]> ListAllCrateProfilePropertiesAsync<TCrateProfilePropertyEntity>(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            where TCrateProfilePropertyEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<TCrateProfilePropertyEntity[]>(HttpMethod.Get, $"crate_package/{cratePackageName}/profile/{crateProfileName}/properties", cancellationToken);

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).ListCratePackagesAsync<CratePackageEntity>(limit, page, cancellationToken);

        /// <summary>
        /// Get a page of Crate Packages.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<TCratePackageEntity>> ListCratePackagesAsync<TCratePackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCratePackageEntity : class
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<TCratePackageEntity>(limit, page, "crate_package", cancellationToken);

        /// <summary>
        /// Get a page of Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        /// <param name="limit">The maximum number of Crate Profiles that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<CrateProfileEntity>> ListCrateProfilesAsync(string cratePackageName, int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ((ICratePackageOperations)this).ListCrateProfilesAsync<CrateProfileEntity>(cratePackageName, limit, page, cancellationToken);

        /// <summary>
        /// Get a page of Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package that the Crate Profiles belong to.</param>
        /// <param name="limit">The maximum number of Crate Profiles that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<TCrateProfileEntity>> ListCrateProfilesAsync<TCrateProfileEntity>(string cratePackageName, int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCrateProfileEntity : class
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<TCrateProfileEntity>(limit, page, $"crate_package/{cratePackageName}/profile", cancellationToken);
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
