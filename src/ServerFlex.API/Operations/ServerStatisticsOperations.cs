using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class ServerStatisticsOperations : BaseOperations, IServerStatisticsOperations
    {
        #region Public Methods
        /// <summary>
        /// Gets historical CPU usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<ServerHistoricalUsageEntity> GetHistoricalCPUUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
        {
            return ((IServerStatisticsOperations)this).GetHistoricalCPUUsageAsync<ServerHistoricalUsageEntity>(serverUuid, from, cancellationToken);
        }

        /// <summary>
        /// Gets historical CPU usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<TServerHistoricalUsageEntity> GetHistoricalCPUUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerHistoricalUsageEntity>(HttpMethod.Get, $"server/{serverUuid}/stats?from={from:o}&cpu=true", cancellationToken);
        }

        /// <summary>
        /// Gets historical RAM usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<ServerHistoricalUsageEntity> GetHistoricalRAMUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
        {
            return ((IServerStatisticsOperations)this).GetHistoricalRAMUsageAsync<ServerHistoricalUsageEntity>(serverUuid, from, cancellationToken);
        }

        /// <summary>
        /// Gets historical RAM usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<TServerHistoricalUsageEntity> GetHistoricalRAMUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerHistoricalUsageEntity>(HttpMethod.Get, $"server/{serverUuid}/stats?from={from:o}&ram=true", cancellationToken);
        }

        /// <summary>
        /// Gets historical storage usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<ServerHistoricalUsageEntity> GetHistoricalStorageUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
        {
            return ((IServerStatisticsOperations)this).GetHistoricalStorageUsageAsync<ServerHistoricalUsageEntity>(serverUuid, from, cancellationToken);
        }

        /// <summary>
        /// Gets historical storage usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<TServerHistoricalUsageEntity> GetHistoricalStorageUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerHistoricalUsageEntity>(HttpMethod.Get, $"server/{serverUuid}/stats?from={from:o}&storage=true", cancellationToken);
        }

        /// <summary>
        /// Gets historical resource usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<ServerHistoricalUsageEntity> GetHistoricalUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
        {
            return ((IServerStatisticsOperations)this).GetHistoricalUsageAsync<ServerHistoricalUsageEntity>(serverUuid, from, cancellationToken);
        }

        /// <summary>
        /// Gets historical resource usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        public virtual Task<TServerHistoricalUsageEntity> GetHistoricalUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerHistoricalUsageEntity>(HttpMethod.Get, $"server/{serverUuid}/stats?from={from:o}&cpu=true&ram=true&storage=true", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for server statistics.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public ServerStatisticsOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
