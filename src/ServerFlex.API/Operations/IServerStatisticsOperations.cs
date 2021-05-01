using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerStatisticsOperations
    {
        #region Methods
        /// <summary>
        /// Gets historical CPU usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<ServerHistoricalUsageEntity> GetHistoricalCPUUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets historical CPU usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<TServerHistoricalUsageEntity> GetHistoricalCPUUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class;

        /// <summary>
        /// Gets historical RAM usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<ServerHistoricalUsageEntity> GetHistoricalRAMUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets historical RAM usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<TServerHistoricalUsageEntity> GetHistoricalRAMUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class;

        /// <summary>
        /// Gets historical storage usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<ServerHistoricalUsageEntity> GetHistoricalStorageUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets historical storage usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<TServerHistoricalUsageEntity> GetHistoricalStorageUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class;

        /// <summary>
        /// Gets historical resource usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<ServerHistoricalUsageEntity> GetHistoricalUsageAsync(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets historical resource usage information for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="from">The date and time to get the usage information from.</param>
        Task<TServerHistoricalUsageEntity> GetHistoricalUsageAsync<TServerHistoricalUsageEntity>(Guid serverUuid, DateTime from, CancellationToken cancellationToken = default)
            where TServerHistoricalUsageEntity : class;
        #endregion
    }
}
