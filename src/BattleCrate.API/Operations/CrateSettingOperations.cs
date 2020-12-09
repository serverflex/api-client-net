using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class CrateSettingOperations : BaseOperations, ICrateSettingOperations
    {
        #region Public Methods
        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        public Task<CrateSettingEntity[]> ListAllCrateSettingsAsync(Guid crateUuid, CancellationToken cancellationToken = default)
        {
            return ((ICrateSettingOperations)this).ListAllCrateSettingsAsync<CrateSettingEntity>(crateUuid, cancellationToken);
        }

        /// <summary>
        /// Get all Crate settings.
        /// </summary>
        /// <param name="crateUuid">The UUID of the Crate to get settings for.</param>
        public Task<TCrateSettingEntity[]> ListAllCrateSettingsAsync<TCrateSettingEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
            where TCrateSettingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TCrateSettingEntity[]>(HttpMethod.Get, $"crate/{crateUuid}/settings", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for Crate settings.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public CrateSettingOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
