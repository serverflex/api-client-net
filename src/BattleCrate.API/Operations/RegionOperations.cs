using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class RegionOperations : BaseOperations, IRegionOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a Region.
        /// </summary>
        /// <param name="regionName">The name of the Region.</param>
        public virtual Task<RegionEntity> GetRegion(string regionName, CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).GetRegion<RegionEntity>(regionName, cancellationToken);
        }

        /// <summary>
        /// Get a Region.
        /// </summary>
        /// <param name="regionName">The name of the Region.</param>
        public virtual Task<TRegionEntity> GetRegion<TRegionEntity>(string regionName, CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TRegionEntity>(HttpMethod.Get, $"region/{regionName}", cancellationToken);
        }

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        public virtual Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).ListAllRegionsAsync<RegionEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        public virtual Task<TRegionEntity[]> ListAllRegionsAsync<TRegionEntity>(CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TRegionEntity>("region", cancellationToken);
        }

        /// <summary>
        /// Get a page of Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).ListRegionsAsync<RegionEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<TRegionEntity>> ListRegionsAsync<TRegionEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TRegionEntity>(limit, page, "region", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Regions.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public RegionOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
