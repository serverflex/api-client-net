using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class ServerOperations : BaseOperations, IServerOperations
    {
        #region Public Methods
        /// <summary>
        /// Delete a server from your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to delete.</param>
        public virtual Task DeleteServerAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ApiRequestor.RequestAsync(HttpMethod.Delete, $"server/{serverUuid}", null, cancellationToken);
        }

        /// <summary>
        /// Deploy a new server to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new server.</param>
        public virtual Task<ServerEntity> DeployServerAsync(ServerDeployEntity configuration, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).DeployServerAsync<ServerEntity>(configuration, cancellationToken);
        }

        /// <summary>
        /// Deploy a new server to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new server.</param>
        public virtual Task<TServerEntity> DeployServerAsync<TServerEntity>(ServerDeployEntity configuration, CancellationToken cancellationToken = default)
            where TServerEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<ServerDeployEntity, TServerEntity>(HttpMethod.Post, "server/new", configuration, cancellationToken);
        }

        /// <summary>
        /// Edit a server within your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to edit.</param>
        /// <param name="changes">The changes to make to the server.</param>
        public virtual Task<ServerEntity> EditServerAsync(Guid serverUuid, ServerEditEntity changes, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).EditServerAsync<ServerEntity>(serverUuid, changes, cancellationToken);
        }

        /// <summary>
        /// Edit a server within your account.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to edit.</param>
        /// <param name="changes">The changes to make to the server.</param>
        public virtual Task<TCrateEntity> EditServerAsync<TCrateEntity>(Guid serverUuid, ServerEditEntity changes, CancellationToken cancellationToken = default)
            where TCrateEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<ServerEditEntity, TCrateEntity>(HttpMethod.Post, $"server/{serverUuid}", changes, cancellationToken);
        }

        /// <summary>
        /// Get a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        public virtual Task<ServerEntity> GetServerAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).GetServerAsync<ServerEntity>(serverUuid, cancellationToken);
        }

        /// <summary>
        /// Get a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        public virtual Task<TServerEntity> GetServerAsync<TServerEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TServerEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerEntity>(HttpMethod.Get, $"server/{serverUuid}", null, cancellationToken);
        }

        /// <summary>
        /// Get the number of players that are currently connected to a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get the active player count for.</param>
        public virtual Task<ServerPlayersEntity> GetPlayersAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).GetPlayersAsync<ServerPlayersEntity>(serverUuid, cancellationToken);
        }

        /// <summary>
        /// Get the number of players that are currently connected to a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get the active player count for.</param>
        public virtual Task<TServerPlayersEntity> GetPlayersAsync<TServerPlayersEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TServerPlayersEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerPlayersEntity>(HttpMethod.Get, $"server/{serverUuid}/players", cancellationToken);
        }

        /// <summary>
        /// Get all of the servers in your account. The returned servers are sorted by date created in acsending order (oldest servers at the top).
        /// </summary>
        public virtual Task<ServerEntity[]> ListAllServersAsync(CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).ListAllServersAsync<ServerEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all of the servers in your account. The returned servers are sorted by date created in acsending order (oldest servers at the top).
        /// </summary>
        public virtual Task<TServerEntity[]> ListAllServersAsync<TServerEntity>(CancellationToken cancellationToken = default)
            where TServerEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TServerEntity>("server", cancellationToken);
        }

        /// <summary>
        /// Get a page of servers in your account. The returned servers are sorted by date created in ascending order (oldest servers at the top).
        /// </summary>
        /// <param name="limit">The maximum number of servers that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<ServerEntity>> ListServersAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).ListServersAsync<ServerEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of servers in your account. The returned servers are sorted by date created in ascending order (oldest servers at the top).
        /// </summary>
        /// <param name="limit">The maximum number of servers that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<TServerEntity>> ListServersAsync<TServerEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TServerEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TServerEntity>(limit, page, "server", cancellationToken);
        }

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        public virtual Task<OperationEntity> RestartServerAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).RestartServerAsync<OperationEntity>(serverUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        public virtual Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return ((IServerOperations)this).RestartServerAsync<TOperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> RestartServerAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).RestartServerAsync<OperationEntity>(crateUuid, timeout, cancellationToken);
        }

        /// <summary>
        /// Restart a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return RequestWithTimeoutAsync<TOperationEntity>(timeout, $"server/{crateUuid}/restart", cancellationToken);
        }

        /// <summary>
        /// Input a command into the console of a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to send the command to.</param>
        /// <param name="command">The command to enter into the server's console.</param>
        public virtual Task SendCommandAsync(Guid serverUuid, ServerConsoleInputEntity command, CancellationToken cancellationToken = default)
        {
            return ApiRequestor.RequestAsync(HttpMethod.Post, $"server/{serverUuid}/console", command, cancellationToken);
        }

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        public virtual Task<OperationEntity> StartServerAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).StartServerAsync<OperationEntity>(serverUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        public virtual Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return ((IServerOperations)this).StartServerAsync<TOperationEntity>(serverUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> StartServerAsync(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).StartServerAsync<OperationEntity>(serverUuid, timeout, cancellationToken);
        }

        /// <summary>
        /// Start a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return RequestWithTimeoutAsync<TOperationEntity>(timeout, $"server/{serverUuid}/start", cancellationToken);
        }

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        public virtual Task<OperationEntity> StopServerAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).StopServerAsync<OperationEntity>(serverUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        public virtual Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return ((IServerOperations)this).StopServerAsync<TOperationEntity>(serverUuid, TimeSpan.FromMinutes(2), cancellationToken);
        }

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> StopServerAsync(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
        {
            return ((IServerOperations)this).StopServerAsync<OperationEntity>(serverUuid, timeout, cancellationToken);
        }

        /// <summary>
        /// Stop a server. This process is asynchronous so the server may not be available immediately.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid serverUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
        {
            return RequestWithTimeoutAsync<TOperationEntity>(timeout, $"server/{serverUuid}/stop", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for servers.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public ServerOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion

        #region Private Methods
        private Task<TResponse> RequestWithTimeoutAsync<TResponse>(TimeSpan timeout, string path, CancellationToken cancellationToken)
        {
            if (timeout.TotalSeconds < 1 || timeout.TotalMinutes > 2)
                throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be between 1 second and 2 minutes.");

            return ApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod.Post, $"{path}?timeout={timeout.TotalSeconds}", null, cancellationToken);
        }
        #endregion
    }
}
