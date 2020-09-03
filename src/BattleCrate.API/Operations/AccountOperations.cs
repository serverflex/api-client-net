using BattleCrate.API.Entities;
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
        public Task<UserEntity> GetUserAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<UserEntity>(HttpMethod.Get, "account", cancellationToken);

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        public Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<BalanceEntity[]>(HttpMethod.Get, "account/balance", cancellationToken);

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        public Task<ReferralOverviewEntity> GetReferralOverviewAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<ReferralOverviewEntity>(HttpMethod.Get, "account/referral_overview", cancellationToken);
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
