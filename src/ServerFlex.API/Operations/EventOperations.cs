using ServerFlex.API.Base;
using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class EventOperations : BaseOperations, IEventOperations
    {
        #region Public Methods
        /// <summary>
        /// Adds an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscription">The subscription configuration.</param>
        public virtual Task<SubscriptionEntity> AddSubscriptionAsync(string token, SubscriptionNewEntity subscription, CancellationToken cancellationToken = default)
        {
            return ((IEventOperations)this).AddSubscriptionAsync<SubscriptionEntity>(token, subscription, cancellationToken);
        }

        /// <summary>
        /// Adds an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscription">The subscription configuration.</param>
        public virtual Task<TSubscriptionEntity> AddSubscriptionAsync<TSubscriptionEntity>(string token, SubscriptionNewEntity subscription, CancellationToken cancellationToken = default)
            where TSubscriptionEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TSubscriptionEntity>(HttpMethod.Post, $"websockets/subscribe?token={token}", cancellationToken);
        }

        /// <summary>
        /// Gets an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        public virtual Task<SubscriptionEntity> GetSubscriptionAsync(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default)
        {
            return ((IEventOperations)this).GetSubscriptionAsync<SubscriptionEntity>(token, subscriptionUuid, cancellationToken);
        }

        /// <summary>
        /// Gets an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        public virtual Task<TSubscriptionEntity> GetSubscriptionAsync<TSubscriptionEntity>(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default)
            where TSubscriptionEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TSubscriptionEntity>(HttpMethod.Get, $"websockets/{subscriptionUuid}?token={token}", cancellationToken);
        }

        /// <summary>
        /// Gets your WebSocket token.
        /// </summary>
        public virtual Task<WebSocketTokenEntity> GetWebSocketTokenAsync(CancellationToken cancellationToken = default)
        {
            return ((IEventOperations)this).GetWebSocketTokenAsync<WebSocketTokenEntity>(cancellationToken);
        }

        /// <summary>
        /// Gets your WebSocket token.
        /// </summary>
        public virtual Task<TWebSocketTokenEntity> GetWebSocketTokenAsync<TWebSocketTokenEntity>(CancellationToken cancellationToken = default)
            where TWebSocketTokenEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TWebSocketTokenEntity>(HttpMethod.Get, "websockets/token", cancellationToken);
        }

        /// <summary>
        /// Removes an event subscription.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        /// <param name="subscriptionUuid">The subscription UUID.</param>
        public virtual Task RemoveSubscriptionAsync(string token, Guid subscriptionUuid, CancellationToken cancellationToken = default)
        {
            return ApiRequestor.RequestAsync(HttpMethod.Post, $"websockets/{subscriptionUuid}/unsubscribe?token={token}", null, cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for events.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public EventOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
