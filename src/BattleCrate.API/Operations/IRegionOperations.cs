using BattleCrate.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface IRegionOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a region.
        /// </summary>
        /// <param name="regionName">The name of the region to retrieve.</param>
        Task<RegionEntity> GetRegion(string regionName, CancellationToken cancellationToken);

        /// <summary>
        /// Get all available regions.
        /// </summary>
        Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get a page of available Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit, int page, CancellationToken cancellationToken);
        #endregion
    }
}
