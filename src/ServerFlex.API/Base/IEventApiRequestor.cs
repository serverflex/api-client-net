using ServerFlex.API.Authentication;
using ServerFlex.API.Events;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Base
{
    public interface IEventApiRequestor
    {
        #region Events
        event EventHandler Connected;
        event EventHandler Disconnected;
        event EventHandler<EventReceivedEventArgs> EventReceived;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the API authentication.
        /// </summary>
        IApiAuthentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets the base URI to use for the event API.
        /// </summary>
        Uri BaseEventApiUri { get; set; }

        /// <summary>
        /// Gets the API client's underlying WebSocket client.
        /// </summary>
        ClientWebSocket WebSocketClient { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Connect to the event API via WebSockets.
        /// </summary>
        /// <param name="token">Your WebSocket token.</param>
        Task ConnectAsync(string token, CancellationToken cancellationToken = default);
        #endregion
    }
}
