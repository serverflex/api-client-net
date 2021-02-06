using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerPropertyOperations
    {
        #region Public Methods
        /// <summary>
        /// Get all server settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the server to get settings for.</param>
        Task<ServerPropertyEntity[]> ListAllServerPropertiesAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all server settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the server to get settings for.</param>
        Task<TCrateSettingEntity[]> ListAllServerPropertiesAsync<TCrateSettingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class;
        #endregion
    }
}
