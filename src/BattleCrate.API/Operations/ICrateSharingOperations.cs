using BattleCrate.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface ICrateSharingOperations
    {
        #region Public Methods
        /// <summary>
        /// Share a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<UserSharingEntity> AddCrateUserSharingAsync(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Share a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<TUserSharingEntity> AddCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Delete a user from the sharing of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        Task DeleteCrateUserSharingAsync(Guid crateUuid, Guid userUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<UserSharingEntity> EditCrateUserSharingAsync(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<TUserSharingEntity> EditCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<UserSharingEntity[]> ListAllCrateUserSharingAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<TUserSharingEntity[]> ListAllCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;
        #endregion
    }
}
