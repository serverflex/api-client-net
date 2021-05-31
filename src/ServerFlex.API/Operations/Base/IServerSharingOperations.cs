using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations.Base
{
    public interface IServerSharingOperations
    {
        #region Public Methods
        /// <summary>
        /// Share a server with another user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<UserSharingEntity> AddServerUserSharingAsync(Guid serverUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Share a server with another user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="newUser">The new user configuration.</param>
        Task<TUserSharingEntity> AddServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Delete a user from the sharing of a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        Task DeleteServerUserSharingAsync(Guid serverUuid, Guid userUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the server sharing settings for a user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<UserSharingEntity> EditServerUserSharingAsync(Guid serverUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edit the server sharing settings for a user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        /// <param name="userUuid">The UUID of the user.</param>
        /// <param name="changes">The changes to make.</param>
        Task<TUserSharingEntity> EditServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;

        /// <summary>
        /// Get the user sharing for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        Task<UserSharingEntity[]> ListAllServerUserSharingAsync(Guid serverUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the user sharing for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server.</param>
        Task<TUserSharingEntity[]> ListAllServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class;
        #endregion
    }
}
