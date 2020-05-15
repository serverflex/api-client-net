using BattleCrate.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface IRegionOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a Region.
        /// </summary>
        /// <param name="regionName">The name of the Region to retrieve.</param>
        Task<RegionEntity> GetRegion(string regionName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of available Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);
        #endregion
    }
}
