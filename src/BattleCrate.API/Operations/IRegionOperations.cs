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
        /// <param name="regionName">The name of the Region.</param>
        Task<RegionEntity> GetRegion(string regionName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Region.
        /// </summary>
        /// <param name="regionName">The name of the Region.</param>
        Task<TRegionEntity> GetRegion<TRegionEntity>(string regionName, CancellationToken cancellationToken = default)
            where TRegionEntity : class;

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        Task<TRegionEntity[]> ListAllRegionsAsync<TRegionEntity>(CancellationToken cancellationToken = default)
            where TRegionEntity : class;

        /// <summary>
        /// Get a page of Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TRegionEntity>> ListRegionsAsync<TRegionEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TRegionEntity : class;
        #endregion
    }
}
