using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
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
        public virtual Task DeleteCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestAsync(HttpMethod.Delete, $"crate/{crateUuid}", null, cancellationToken);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        public virtual Task<CrateEntity> DeployCrateAsync(CrateDeployEntity configuration, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).DeployCrateAsync<CrateEntity>(configuration, cancellationToken);

        /// <summary>
        /// Deploy a new Crate to your account.
        /// </summary>
        /// <param name="configuration">The configuration for the new Crate.</param>
        public virtual Task<TCrateEntity> DeployCrateAsync<TCrateEntity>(CrateDeployEntity configuration, CancellationToken cancellationToken = default)
            where TCrateEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<CrateDeployEntity, TCrateEntity>(HttpMethod.Post, "crate/new", configuration, cancellationToken);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        public virtual Task<CrateEntity> EditCrateAsync(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).EditCrateAsync<CrateEntity>(crateUuid, changes, cancellationToken);

        /// <summary>
        /// Edit a Crate within your account.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to edit.</param>
        /// <param name="changes">The changes to make to the Crate.</param>
        public virtual Task<TCrateEntity> EditCrateAsync<TCrateEntity>(Guid crateUuid, CrateEditEntity changes, CancellationToken cancellationToken = default)
            where TCrateEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<CrateEditEntity, TCrateEntity>(HttpMethod.Post, $"crate/{crateUuid}", changes, cancellationToken);

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        public virtual Task<CrateEntity> GetCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).GetCrateAsync<CrateEntity>(crateUuid, cancellationToken);

        /// <summary>
        /// Get a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        public virtual Task<TCrateEntity> GetCrateAsync<TCrateEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<TCrateEntity>(HttpMethod.Get, $"crate/{crateUuid}", null, cancellationToken);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get the active player count for.</param>
        public virtual Task<CratePlayersEntity> GetPlayersAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).GetPlayersAsync<CratePlayersEntity>(crateUuid, cancellationToken);

        /// <summary>
        /// Get the number of players that are currently connected to a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get the active player count for.</param>
        public virtual Task<TCratePlayersEntity> GetPlayersAsync<TCratePlayersEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCratePlayersEntity : class
            => ApiRequestor.RequestJsonSerializedAsync<TCratePlayersEntity>(HttpMethod.Get, $"crate/{crateUuid}/players", cancellationToken);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in acsending order (oldest Crates at the top).
        /// </summary>
        public virtual Task<CrateEntity[]> ListAllCratesAsync(CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).ListAllCratesAsync<CrateEntity>(cancellationToken);

        /// <summary>
        /// Get all of the Crates in your account. The returned Crates are sorted by date created in acsending order (oldest Crates at the top).
        /// </summary>
        public virtual Task<TCrateEntity[]> ListAllCratesAsync<TCrateEntity>(CancellationToken cancellationToken = default)
            where TCrateEntity : class
            => ApiRequestor.RequestEntireListJsonSerializedAsync<TCrateEntity>("crate", cancellationToken);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<CrateEntity>> ListCratesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).ListCratesAsync<CrateEntity>(limit, page, cancellationToken);

        /// <summary>
        /// Get a page of Crates in your account. The returned Crates are sorted by date created in ascending order (oldest Crates at the top).
        /// </summary>
        /// <param name="limit">The maximum number of Crates that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results. Minimum: 1.</param>
        public virtual Task<ResultResponseEntity<TCrateEntity>> ListCratesAsync<TCrateEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TCrateEntity : class
            => ApiRequestor.RequestResultResponseJsonSerializedAsync<TCrateEntity>(limit, page, "crate", cancellationToken);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        public virtual Task<OperationEntity> RestartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).RestartCrateAsync<OperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        public virtual Task<TOperationEntity> RestartCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => ((ICrateOperations)this).RestartCrateAsync<TOperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> RestartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).RestartCrateAsync<OperationEntity>(crateUuid, timeout, cancellationToken);

        /// <summary>
        /// Restart a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to restart.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> RestartCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => RequestWithTimeoutAsync<TOperationEntity>(timeout, $"crate/{crateUuid}/restart", cancellationToken);

        /// <summary>
        /// Input a command into the console of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to send the command to.</param>
        /// <param name="command">The command to enter into the Crate's console.</param>
        public virtual Task SendCommandAsync(Guid crateUuid, CrateConsoleInputEntity command, CancellationToken cancellationToken = default)
            => ApiRequestor.RequestAsync(HttpMethod.Post, $"crate/{crateUuid}/console", command, cancellationToken);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        public virtual Task<OperationEntity> StartCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).StartCrateAsync<OperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        public virtual Task<TOperationEntity> StartCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => ((ICrateOperations)this).StartCrateAsync<TOperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> StartCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).StartCrateAsync<OperationEntity>(crateUuid, timeout, cancellationToken);

        /// <summary>
        /// Start a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to start.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> StartCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => RequestWithTimeoutAsync<TOperationEntity>(timeout, $"crate/{crateUuid}/start", cancellationToken);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        public virtual Task<OperationEntity> StopCrateAsync(Guid crateUuid, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).StopCrateAsync<OperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        public virtual Task<TOperationEntity> StopCrateAsync<TOperationEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => ((ICrateOperations)this).StopCrateAsync<TOperationEntity>(crateUuid, TimeSpan.FromMinutes(2), cancellationToken);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<OperationEntity> StopCrateAsync(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            => ((ICrateOperations)this).StopCrateAsync<OperationEntity>(crateUuid, timeout, cancellationToken);

        /// <summary>
        /// Stop a Crate. This process is asynchronous so the Crate may not be available immediately.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to stop.</param>
        /// <param name="timeout">The timeout to wait for the call to complete. Minimum: 1 second, maximum: 2 minutes.</param>
        public virtual Task<TOperationEntity> StopCrateAsync<TOperationEntity>(Guid crateUuid, TimeSpan timeout, CancellationToken cancellationToken = default)
            where TOperationEntity : class
            => RequestWithTimeoutAsync<TOperationEntity>(timeout, $"crate/{crateUuid}/stop", cancellationToken);
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
            if (timeout.TotalSeconds < 1 || timeout.TotalMinutes > 2)
                throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be between 1 second and 2 minutes.");

            return ApiRequestor.RequestJsonSerializedAsync<TResponse>(HttpMethod.Post, $"{path}?timeout={timeout.TotalSeconds}", null, cancellationToken);
        }
        #endregion
    }
}
