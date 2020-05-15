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
        /// <param name="cratePackageName">The name of thhe Crate Package.</param>
        Task<CratePackageEntity> GetCratePackageAsync(string cratePackageName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);
        #endregion
    }
}
