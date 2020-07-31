using BattleCrate.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BattleCrate.API.Operations
{
    public interface IAccountOperations
    {
        #region Public Methods
        /// <summary>
        /// Gets basic information about your account.
        /// </summary>
        Task<UserEntity> GetUserAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets your account balance in all supported currencies.
        /// </summary>
        Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default);
        #endregion
    }
}
