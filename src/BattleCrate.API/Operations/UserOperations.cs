using BattleCrate.API.Entities;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public class UserOperations : BaseOperations, IUserOperations
    {
        #region Public Methods
        /// <summary>
        /// Gets basic information about your account.
        /// </summary>
        public Task<UserEntity> GetAccountAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<UserEntity>(HttpMethod.Get, "account", cancellationToken);

        /// <summary>
        /// Gets your account balance in all supported currencies.
        /// </summary>
        public Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default)
            => ApiRequestor.RequestJsonSerializedAsync<BalanceEntity[]>(HttpMethod.Get, "account/balance", cancellationToken);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for users.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public UserOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
