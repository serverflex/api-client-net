using BattleCrate.API.Entities;
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
        public Task<CratePackageEntity> GetCratePackageAsync(string cratePackageName, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CratePackageEntity>(HttpMethod.Get, $"package/{cratePackageName}", cancellationToken);

        /// <summary>
        /// Get a Crate Profile.
        /// </summary>
        /// <param name="cratePackageName">The name of thhe Crate Package.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public Task<CrateProfileEntity> GetCrateProfileAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CrateProfileEntity>(HttpMethod.Get, $"crate_package/{cratePackageName}/profile/{crateProfileName}", cancellationToken);

        /// <summary>
        /// Get all available Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        public Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestEntireListJsonSerializedAsync<CratePackageEntity>("crate_package", cancellationToken);

        /// <summary>
        /// Get all available Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of thhe Crate Package.</param>
        public Task<CrateProfileEntity[]> ListAllCrateProfilesAsync(string cratePackageName, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestEntireListJsonSerializedAsync<CrateProfileEntity>($"crate_package/{cratePackageName}/profile", cancellationToken);

        /// <summary>
        /// Get a page of Crate Profile properties.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        /// <param name="crateProfileName">The name of the Crate Profile.</param>
        public Task<CrateProfilePropertyEntity[]> ListAllCrateProfilePropertiesAsync(string cratePackageName, string crateProfileName, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CrateProfilePropertyEntity[]>(HttpMethod.Get, $"crate_package/{cratePackageName}/profile/{crateProfileName}/properties", cancellationToken);

        /// <summary>
        /// Get a page of Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<CratePackageEntity>(limit, page, "crate_package", cancellationToken);

        /// <summary>
        /// Get a page of Crate Profiles.
        /// </summary>
        /// <param name="cratePackageName">The name of the Crate Package.</param>
        /// <param name="limit">The maximum number of Crate Profiles that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public Task<ResultResponseEntity<CrateProfileEntity>> ListCrateProfilesAsync(string cratePackageName, int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<CrateProfileEntity>(limit, page, $"crate_package/{cratePackageName}/profile", cancellationToken);
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
