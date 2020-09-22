using BattleCrate.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface ICrateOperations
    {
        #region Public Methods
        /// <summary>
        /// Shares a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<UserSharingEntity> AddCrateUserSharingAsync(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Shares a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<TUserSharingEntity> AddCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Delete a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to delete.</param>
        Task DeleteCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a user from the sharing of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to remove the user from.</param>
        /// <param name="userUuid">The UUID of the user to remove.</param>
        Task DeleteCrateUserSharingAsync(Guid crateUuid, Guid userUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        Task<CrateEntity> DeployCrateAsync(CrateDeployEntity configuration, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        Task<TCrateEntity> DeployCrateAsync<TCrateEntity>(CrateDeployEntity configuration, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        Task<CrateEntity> EditCrateAsync(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        Task<TCrateEntity> EditCrateAsync<TCrateEntity>(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        Task<UserSharingEntity> EditCrateUserSharingAsync(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        Task<TUserSharingEntity> EditCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<CrateEntity> GetCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<TCrateEntity> GetCrateAsync<TCrateEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the crate to get the active player count for.</param>
        Task<CratePlayersEntity> GetPlayersAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the crate to get the active player count for.</param>
        Task<TCratePlayersEntity> GetPlayersAsync<TCratePlayersEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCratePlayersEntity : class;

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        Task<CrateEntity[]> ListAllCratesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        Task<TCrateEntity[]> ListAllCratesAsync<TCrateEntity>(CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get sharing for.</param>
        Task<UserSharingEntity[]> ListAllCrateUserSharingAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get sharing for.</param>
        Task<TUserSharingEntity[]> ListAllCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<CrateEntity>> ListCratesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<TCrateEntity>> ListCratesAsync<TCrateEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCrateEntity : class;

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        Task<OperationEntity> RestartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        Task<TOperationEntity> RestartCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> RestartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> RestartCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Input a command into the console of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to send the command to.</param>
        /// <param name="command">The command to enter into the Crate's console.</param>
        Task SendCommandAsync(Guid crateUuid, CrateConsoleInputEntity command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        Task<OperationEntity> StartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        Task<TOperationEntity> StartCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StartCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        Task<OperationEntity> StopCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        Task<TOperationEntity> StopCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class;

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<OperationEntity> StopCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        Task<TOperationEntity> StopCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class;
        #endregion
    }
}
