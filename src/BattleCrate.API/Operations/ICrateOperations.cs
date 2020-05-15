﻿using BattleCrate.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface ICrateOperations
    {
        #region Public Methods
        /// <summary>
        /// Delete a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to delete.</param>
        Task DeleteCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        Task<CrateEntity> DeployCrateAsync(CrateDeployEntity configuration, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        Task<CrateEntity> EditCrateAsync(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to retrieve.</param>
        Task<CrateEntity> GetCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the crate to get the active player count for.</param>
        Task<CratePlayersEntity> GetPlayersAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in acsending order (oldest Crates at the top).
        /// </summary>
        Task<CrateEntity[]> ListAllCratesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        Task<ResultResponseEntity<CrateEntity>> ListCratesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default);

        /// <summary>
        /// Restart a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete.</param>
        Task RestartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Input a command into the console for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to send the command to.</param>
        /// <param name="command">The command to enter into the Crate's console.</param>
        Task SendCommandAsync(Guid crateUuid, CrateCommandEntity command, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete.</param>
        Task StartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete.</param>
        Task StopCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default);
        #endregion
    }
}
