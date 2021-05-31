using ServerFlex.API.Entities;
using System;

namespace ServerFlex.API.Events
{
    public class EventReceivedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the received event.
        /// </summary>
        public EventEntity EventEntity { get; }
        #endregion

        #region Constructors
        public EventReceivedEventArgs(EventEntity eventEntity)
            : base()
        {
            EventEntity = eventEntity;
        }
        #endregion
    }
}
