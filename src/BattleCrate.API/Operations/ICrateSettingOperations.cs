using BattleCrate.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface ICrateSettingOperations
    {
        #region Public Methods
        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        Task<CrateSettingEntity[]> ListAllCrateSettingsAsync(Guid crateUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        Task<TCrateSettingEntity[]> ListAllCrateSettingsAsync<TCrateSettingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class;
        #endregion
    }
}
