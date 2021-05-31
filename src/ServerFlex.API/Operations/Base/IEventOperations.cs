using ServerFlex.API.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations.Base
{
    public interface IEventOperations
    {
        #region Methods
        /// <summary>
        /// Adds an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscription">The subscription configuration.</param>
        Task<SubscriptionEntity> AddSubscriptionAsync(string token, SubscriptionNewEntity subscription, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscription">The subscription configuration.</param>
        Task<TSubscriptionEntity> AddSubscriptionAsync<TSubscriptionEntity>(string token, SubscriptionNewEntity subscription, CancellationToken cancellationToken = default)
            where TSubscriptionEntity : class;

        /// <summary>
        /// Gets an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        Task<SubscriptionEntity> GetSubscriptionAsync(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        Task<TSubscriptionEntity> GetSubscriptionAsync<TSubscriptionEntity>(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default)
            where TSubscriptionEntity : class;

        /// <summary>
        /// Gets your WebSocket token.
        /// </summary>
        Task<WebSocketTokenEntity> GetWebSocketTokenAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets your WebSocket token.
        /// </summary>
        Task<TWebSocketTokenEntity> GetWebSocketTokenAsync<TWebSocketTokenEntity>(CancellationToken cancellationToken = default)
            where TWebSocketTokenEntity : class;

        /// <summary>
        /// Removes an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        Task RemoveSubscriptionAsync(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default);
        #endregion
    }
}
