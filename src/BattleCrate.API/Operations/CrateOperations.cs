﻿using BattleCrate.API.Entities;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class CrateOperations : BaseOperations, ICrateOperations
    {
        #region Public Methods
        /// <summary>
        /// Delete a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to delete.</param>
        public Task DeleteCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestAsync(HttpMethod.Delete, $"crate/{crateUuid}", null, cancellationToken);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        public Task<CrateEntity> DeployCrateAsync(CrateDeployEntity configuration, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CrateDeployEntity, CrateEntity>(HttpMethod.Post, "crate/new", configuration, cancellationToken);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        public Task<CrateEntity> EditCrateAsync(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CrateEditEntity, CrateEntity>(HttpMethod.Post, $"crate/{crateUuid}", changes, cancellationToken);

        /// <summary>
        /// Get a Crate from your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to retrieve.</param>
        public Task<CrateEntity> GetCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CrateEntity>(HttpMethod.Get, $"crate/{crateUuid}", null, cancellationToken);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get the active player count for.</param>
        public Task<CratePlayersEntity> GetPlayersAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<CratePlayersEntity>(HttpMethod.Get, $"crate/{crateUuid}/players", cancellationToken);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in acsending order (oldest Crates at the top).
        /// </summary>
        public Task<CrateEntity[]> ListAllCratesAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestEntireListJsonSerializedAsync<CrateEntity>("crate", cancellationToken);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public Task<ResultResponseEntity<CrateEntity>> ListCratesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<CrateEntity>(limit, page, "crate", cancellationToken);

        /// <summary>
        /// Restart a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        public Task<OperationEntity> RestartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => RestartCrateAsync(crateUuid, TimeSpan.FromSeconds(30), cancellationToken);

        /// <summary>
        /// Restart a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 30 seconds.</param>
        public Task<OperationEntity> RestartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => RequestWithTimeoutAsync<OperationEntity>(timeout, $"crate/{crateUuid}/restart", cancellationToken);

        /// <summary>
        /// Input a command into the console for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to send the command to.</param>
        /// <param name="command">The command to enter into the Crate's console.</param>
        public Task SendCommandAsync(Guid crateUuid, CrateCommandEntity command, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestAsync(HttpMethod.Post, $"crate/{crateUuid}/console", command, cancellationToken);

        /// <summary>
        /// Start a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        public Task<OperationEntity> StartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => StartCrateAsync(crateUuid, TimeSpan.FromSeconds(30), cancellationToken);

        /// <summary>
        /// Start a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 30 seconds.</param>
        public Task<OperationEntity> StartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => RequestWithTimeoutAsync<OperationEntity>(timeout, $"crate/{crateUuid}/start", cancellationToken);

        /// <summary>
        /// Stop a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        public Task<OperationEntity> StopCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => StopCrateAsync(crateUuid, TimeSpan.FromSeconds(30), cancellationToken);

        /// <summary>
        /// Stop a Crate from your account. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 30 seconds.</param>
        public Task<OperationEntity> StopCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => RequestWithTimeoutAsync<OperationEntity>(timeout, $"crate/{crateUuid}/stop", cancellationToken);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crates.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CrateOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion

        #region Private Methods
        private Task<TResponse> RequestWithTimeoutAsync<TResponse>(TimeSpan timeout, string path, CancellationToken cancellationToken)
        {
            if (timeout.TotalSeconds < 1 || timeout.TotalSeconds > 30)
                throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be between 1 and 30 seconds.");

            return ApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod.Post, $"{path}?timeout={timeout.TotalSeconds}", null, cancellationToken);
        }
        #endregion
    }
}
