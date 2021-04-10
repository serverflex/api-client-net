using ServerFlex.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IRegionOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a region.
        /// </summary>
        /// <param name="regionName">The name of the region.</param>
        Task<RegionEntity> GetRegionAsync(string regionName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a region.
        /// </summary>
        /// <param name="regionName">The name of the region.</param>
        Task<TRegionEntity> GetRegionAsync<TRegionEntity>(string regionName, CancellationToken cancellationToken = default)
            where TRegionEntity : class;

        /// <summary>
        /// Get all available regions.
        /// </summary>
        Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all available regions.
        /// </summary>
        Task<TRegionEntity[]> ListAllRegionsAsync<TRegionEntity>(CancellationToken cancellationToken = default)
            where TRegionEntity : class;

        /// <summary>
        /// Get a page of regions.
        /// </summary>
        /// <param name="limit">The maximum number of regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of regions.
        /// </summary>
        /// <param name="limit">The maximum number of regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TRegionEntity>> ListRegionsAsync<TRegionEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TRegionEntity : class;
        #endregion
    }
}
