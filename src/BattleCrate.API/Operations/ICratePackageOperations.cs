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
        Task<CratePackageEntity> GetCratePackageAsync(string cratePackageName, CancellationToken cancellationToken);

        /// <summary>
        /// Get all available Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        Task<CratePackageEntity[]> ListAllCratePackagesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get a page of Crate Packages. Crate Packages will be returned with a maximum of 3 Plans, 3 Profiles and 3 Regions. To get a full list of Plans, Profiles and Regions, use <see cref="GetCratePackageAsync" />.
        /// </summary>
        /// <param name="limit">The maximum number of Crate Pakcages that can be returned.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<CratePackageEntity>> ListCratePackagesAsync(int limit, int page, CancellationToken cancellationToken);
        #endregion
    }
}
