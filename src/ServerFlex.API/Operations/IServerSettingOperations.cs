using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IServerSettingOperations
    {
        #region Public Methods
        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        Task<ServerSettingEntity[]> ListAllServerSettingsAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        Task<TCrateSettingEntity[]> ListAllServerSettingsAsync<TCrateSettingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class;
        #endregion
    }
}
