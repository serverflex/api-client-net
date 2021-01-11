using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class ServerSharingOperations : BaseOperations, IServerSharingOperations
    {
        #region Public Methods
        /// <summary>
        /// Shares a server with another user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        public virtual Task<UserSharingEntity> AddServerUserSharingAsync(Guid serverUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
        {
            return ((IServerSharingOperations)this).AddServerUserSharingAsync<UserSharingEntity>(serverUuid, newUser, cancellationToken);
        }

        /// <summary>
        /// Shares a server with another user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        public virtual Task<TUserSharingEntity> AddServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<UserSharingNewEntity, TUserSharingEntity>(HttpMethod.Post, $"server/{serverUuid}/sharing/add", newUser, cancellationToken);
        }

        /// <summary>
        /// Delete a user from the sharing of a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to remove the user from.</param>
        /// <param name="userUuid">The UUID of the user to remove.</param>
        public virtual Task DeleteServerUserSharingAsync(Guid serverUuid, Guid userUuid, CancellationToken cancellationToken = default)
        {
            return ApiRequestor.RequestAsync(HttpMethod.Delete, $"server/{serverUuid}/sharing/{userUuid}", null, cancellationToken);
        }

        /// <summary>
        /// Edit the server sharing settings for a user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        public virtual Task<UserSharingEntity> EditServerUserSharingAsync(Guid serverUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
        {
            return ((IServerSharingOperations)this).EditServerUserSharingAsync<UserSharingEntity>(serverUuid, userUuid, changes, cancellationToken);
        }

        /// <summary>
        /// Edit the server sharing settings for a user.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        public virtual Task<TUserSharingEntity> EditServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<UserSharingEditEntity, TUserSharingEntity>(HttpMethod.Post, $"server/{serverUuid}/sharing/{userUuid}", changes, cancellationToken);
        }

        /// <summary>
        /// Get the user sharing for a server.
        /// </summary>
        /// <param name="crateUuid">The UUID of the server to get sharing for.</param>
        public virtual Task<UserSharingEntity[]> ListAllServerUserSharingAsync(Guid crateUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerSharingOperations)this).ListAllServerUserSharingAsync<UserSharingEntity>(crateUuid, cancellationToken);
        }

        /// <summary>
        /// Get the user sharing for a server.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get sharing for.</param>
        public virtual Task<TUserSharingEntity[]> ListAllServerUserSharingAsync<TUserSharingEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TUserSharingEntity[]>(HttpMethod.Get, $"server/{serverUuid}/sharing", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for server sharing.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public ServerSharingOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
