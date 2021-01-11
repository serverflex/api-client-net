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
        /// Delete a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to delete.</param>
        Task DeleteServerAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        Task<ServerEntity> DeployServerAsync(ServerDeployEntity configuration, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        Task<TCrateEntity> DeployServerAsync<TCrateEntity>(ServerDeployEntity configuration, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        Task<ServerEntity> EditServerAsync(Guid crateUuid, ServerEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        Task<TCrateEntity> EditServerAsync<TCrateEntity>(Guid crateUuid, ServerEditEntity changes, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<ServerEntity> GetServerAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<TCrateEntity> GetServerAsync<TCrateEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the crate to get the active player count for.</param>
        Task<ServerPlayersEntity> GetPlayersAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the crate to get the active player count for.</param>
        Task<TCratePlayersEntity> GetPlayersAsync<TCratePlayersEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCratePlayersEntity : class;

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        Task<ServerEntity[]> ListAllServersAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        Task<TCrateEntity[]> ListAllServersAsync<TCrateEntity>(CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<ServerEntity>> ListServersAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TCrateEntity>> ListServersAsync<TCrateEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        Task<OperationEntity> RestartServerAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> RestartServerAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> RestartServerAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Input a command into the console of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to send the command to.</param>
        /// <param name="command">The command to enter into the Crate's console.</param>
        Task SendCommandAsync(Guid crateUuid, ServerConsoleInputEntity command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        Task<OperationEntity> StartServerAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StartServerAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StartServerAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        Task<OperationEntity> StopServerAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StopServerAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StopServerAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;
        #endregion
    }
}
