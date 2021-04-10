using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerOperations
    {
        #region Public Methods
        /// <summary>
        /// Delete a server from your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to delete.</param>
        Task DeleteServerAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new server to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new server.</param>
        Task<ServerEntity> DeployServerAsync(ServerDeployEntity configuration, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new server to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new server.</param>
        Task<TServerEntity> DeployServerAsync<TServerEntity>(ServerDeployEntity configuration, CancellationToken cancellationToken = default)
            where TServerEntity : class;

        /// <summary>
        /// Edit a server within your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to edit.</param>
        /// <param name="changes">The changes to make to the server.</param>
        Task<ServerEntity> EditServerAsync(Guid serverUuid, ServerEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit a server within your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to edit.</param>
        /// <param name="changes">The changes to make to the server.</param>
        Task<TServerEntity> EditServerAsync<TServerEntity>(Guid serverUuid, ServerEditEntity changes, CancellationToken cancellationToken = default)
            where TServerEntity : class;

        /// <summary>
        /// Get a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        Task<ServerEntity> GetServerAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        Task<TServerEntity> GetServerAsync<TServerEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TServerEntity : class;

        /// <summary>
        /// Get the number of players that are currently connected to a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get the active player count for.</param>
        Task<ServerPlayersEntity> GetPlayersAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the number of players that are currently connected to a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get the active player count for.</param>
        Task<TServerPlayersEntity> GetPlayersAsync<TServerPlayersEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TServerPlayersEntity : class;

        /// <summary>
        /// Get all of the servers in your account in ascending order (oldest servers at the top).
        /// </summary>
        Task<ServerEntity[]> ListAllServersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all of the servers in your account in ascending order (oldest servers at the top).
        /// </summary>
        Task<TServerEntity[]> ListAllServersAsync<TServerEntity>(CancellationToken cancellationToken = default)
            where TServerEntity : class;

        /// <summary>
        /// Get a page of server in your account in ascending order (oldest servers at the top).
        /// </summary>
        /// <param name="limit">The maximum number of servers that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<ServerEntity>> ListServersAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of server in your account in ascending order (oldest servers at the top).
        /// </summary>
        /// <param name="limit">The maximum number of servers that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TServerEntity>> ListServersAsync<TServerEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TServerEntity : class;

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        Task<OperationEntity> RestartServerAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> RestartServerAsync(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Input a command into the console of a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to send the command to.</param>
        /// <param name="command">The command to enter into the server's console.</param>
        Task SendCommandAsync(Guid serverUuid, ServerConsoleInputEntity command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        Task<OperationEntity> StartServerAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StartServerAsync(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        Task<OperationEntity> StopServerAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StopServerAsync(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;
        #endregion
    }
}
