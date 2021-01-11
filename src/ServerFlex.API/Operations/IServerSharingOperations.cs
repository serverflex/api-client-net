using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerSharingOperations
    {
        #region Public Methods
        /// <summary>
        /// Share a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<UserSharingEntity> AddServerUserSharingAsync(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Share a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<TUserSharingEntity> AddServerUserSharingAsync<TUserSharingEntity>(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Delete a user from the sharing of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        Task DeleteServerUserSharingAsync(Guid crateUuid, Guid userUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<UserSharingEntity> EditServerUserSharingAsync(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<TUserSharingEntity> EditServerUserSharingAsync<TUserSharingEntity>(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<UserSharingEntity[]> ListAllServerUserSharingAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate.</param>
        Task<TUserSharingEntity[]> ListAllServerUserSharingAsync<TUserSharingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;
        #endregion
    }
}
