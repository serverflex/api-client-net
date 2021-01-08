using BattleCrate.API.Entities;
using BattleCrate.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class AccountOperations : BaseOperations, IAccountOperations
    {
        #region Public Methods
        /// <summary>
        /// Get the current user.
        /// </summary>
        public virtual Task<UserEntity> GetUserAsync(CancellationToken cancellationToken = default)
        {
            return ((IAccountOperations)this).GetUserAsync<UserEntity>(cancellationToken);
        }

        /// <summary>
        /// Get the current user.
        /// </summary>
        public virtual Task<TUserEntity> GetUserAsync<TUserEntity>(CancellationToken cancellationToken = default)
            where TUserEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TUserEntity>(HttpMethod.Get, "account", cancellationToken);
        }

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        public virtual Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            return ((IAccountOperations)this).GetBalanceAsync<BalanceEntity>(cancellationToken);
        }

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        public virtual Task<TBalanceEntity[]> GetBalanceAsync<TBalanceEntity>(CancellationToken cancellationToken = default)
            where TBalanceEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TBalanceEntity[]>(HttpMethod.Get, "account/balance", cancellationToken);
        }

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        public virtual Task<ReferralOverviewEntity> GetReferralOverviewAsync(CancellationToken cancellationToken = default)
        {
            return ((IAccountOperations)this).GetReferralOverviewAsync<ReferralOverviewEntity>(cancellationToken);
        }

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        public virtual Task<TReferralOverviewEntity> GetReferralOverviewAsync<TReferralOverviewEntity>(CancellationToken cancellationToken = default)
            where TReferralOverviewEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TReferralOverviewEntity>(HttpMethod.Get, "account/referral_overview", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for users.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public AccountOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
