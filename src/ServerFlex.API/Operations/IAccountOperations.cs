﻿using ServerFlex.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public interface IAccountOperations
    {
        #region Public Methods
        /// <summary>
        /// Get the current user.
        /// </summary>
        Task<UserEntity> GetUserAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the current user.
        /// </summary>
        Task<TUserEntity> GetUserAsync<TUserEntity>(CancellationToken cancellationToken = default)
            where TUserEntity : class;

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        Task<BalanceEntity[]> GetBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the balance for the current user, in all supported currencies.
        /// </summary>
        Task<TBalanceEntity[]> GetBalanceAsync<TBalanceEntity>(CancellationToken cancellationToken = default)
            where TBalanceEntity : class;

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        Task<ReferralOverviewEntity> GetReferralOverviewAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the referral overview for the current user.
        /// </summary>
        Task<TReferralOverviewEntity> GetReferralOverviewAsync<TReferralOverviewEntity>(CancellationToken cancellationToken = default)
            where TReferralOverviewEntity : class;
        #endregion
    }
}
