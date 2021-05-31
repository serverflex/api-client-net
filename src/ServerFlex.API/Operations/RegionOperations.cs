using ServerFlex.API.Base;
using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class RegionOperations : BaseOperations, IRegionOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a region.
        /// </summary>
        /// <param name="regionName">The name of the region.</param>
        public virtual Task<RegionEntity> GetRegionAsync(string regionName, CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).GetRegionAsync<RegionEntity>(regionName, cancellationToken);
        }

        /// <summary>
        /// Get a region.
        /// </summary>
        /// <param name="regionName">The name of the region.</param>
        public virtual Task<TRegionEntity> GetRegionAsync<TRegionEntity>(string regionName, CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TRegionEntity>(HttpMethod.Get, $"region/{regionName}", cancellationToken);
        }

        /// <summary>
        /// Get all available regions.
        /// </summary>
        public virtual Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).ListAllRegionsAsync<RegionEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all available regions.
        /// </summary>
        public virtual Task<TRegionEntity[]> ListAllRegionsAsync<TRegionEntity>(CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TRegionEntity>("region", cancellationToken);
        }

        /// <summary>
        /// Get a page of regions.
        /// </summary>
        /// <param name="limit">The maximum number of regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((IRegionOperations)this).ListRegionsAsync<RegionEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of regions.
        /// </summary>
        /// <param name="limit">The maximum number of regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<TRegionEntity>> ListRegionsAsync<TRegionEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TRegionEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TRegionEntity>(limit, page, "region", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for regions.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public RegionOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
