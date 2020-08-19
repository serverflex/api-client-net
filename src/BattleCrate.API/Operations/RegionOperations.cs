using BattleCrate.API.Entities;
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
        public Task<RegionEntity> GetRegion(string regionName, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<RegionEntity>(HttpMethod.Get, $"region/{regionName}", cancellationToken);

        /// <summary>
        /// Get all available Regions.
        /// </summary>
        public Task<RegionEntity[]> ListAllRegionsAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestEntireListJsonSerializedAsync<RegionEntity>("region", cancellationToken);

        /// <summary>
        /// Get a page of Regions.
        /// </summary>
        /// <param name="limit">The maximum number of Regions that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public Task<ResultResponseEntity<RegionEntity>> ListRegionsAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<RegionEntity>(limit, page, "region", cancellationToken);
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
