using BattleCrate.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface IAccountOperations
    {
        #region Public Methods
        /// <summary>
        /// Get the current user.
        /// </summary>
        Task<UserEntity> GetUserAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        Task<ReferralOverviewEntity> GetReferralOverviewAsync(CancellationToken cancellationToken = default);
        #endregion
    }
}
