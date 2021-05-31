using System;

namespace ServerFlex.API.Entities
{
    public class ServerStateUpdateEventEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the server UUID.
        /// </summary>
        public Guid ServerUUID { get; set; }

        /// <summary>
        /// Gets or sets the server state. See <see cref="ServerState" />.
        /// </summary>
        public string State { get; set; }
        #endregion
    }
}
