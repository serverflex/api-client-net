using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class CrateSharingOperations : BaseOperations, ICrateSharingOperations
    {
        #region Public Methods
        /// <summary>
        /// Shares a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        public virtual Task<UserSharingEntity> AddCrateUserSharingAsync(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
        {
            return ((ICrateSharingOperations)this).AddCrateUserSharingAsync<UserSharingEntity>(crateUuid, newUser, cancellationToken);
        }

        /// <summary>
        /// Shares a Crate with another user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to add the user to.</param>
        /// <param name="newUser">The new user configuration.</param>
        public virtual Task<TUserSharingEntity> AddCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, UserSharingNewEntity newUser, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<UserSharingNewEntity, TUserSharingEntity>(HttpMethod.Post, $"crate/{crateUuid}/sharing/add", newUser, cancellationToken);
        }

        /// <summary>
        /// Delete a user from the sharing of a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to remove the user from.</param>
        /// <param name="userUuid">The UUID of the user to remove.</param>
        public virtual Task DeleteCrateUserSharingAsync(Guid crateUuid, Guid userUuid, CancellationToken cancellationToken = default)
        {
            return ApiRequestor.RequestAsync(HttpMethod.Delete, $"crate/{crateUuid}/sharing/{userUuid}", null, cancellationToken);
        }

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        public virtual Task<UserSharingEntity> EditCrateUserSharingAsync(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
        {
            return ((ICrateSharingOperations)this).EditCrateUserSharingAsync<UserSharingEntity>(crateUuid, userUuid, changes, cancellationToken);
        }

        /// <summary>
        /// Edit the Crate sharing settings for a user.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to make the changes to.</param>
        /// <param name="userUuid">The UUID of the user to update the settings for.</param>
        /// <param name="changes">The changes to make.</param>
        public virtual Task<TUserSharingEntity> EditCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, Guid userUuid, UserSharingEditEntity changes, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<UserSharingEditEntity, TUserSharingEntity>(HttpMethod.Post, $"crate/{crateUuid}/sharing/{userUuid}", changes, cancellationToken);
        }

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get sharing for.</param>
        public virtual Task<UserSharingEntity[]> ListAllCrateUserSharingAsync(Guid crateUuid, CancellationToken cancellationToken = default)
        {
            return ((ICrateSharingOperations)this).ListAllCrateUserSharingAsync<UserSharingEntity>(crateUuid, cancellationToken);
        }

        /// <summary>
        /// Get the user sharing for a Crate.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get sharing for.</param>
        public virtual Task<TUserSharingEntity[]> ListAllCrateUserSharingAsync<TUserSharingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TUserSharingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TUserSharingEntity[]>(HttpMethod.Get, $"crate/{crateUuid}/sharing", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crate sharing.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CrateSharingOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
