using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class ServerPropertyOperations : BaseOperations, IServerPropertyOperations
    {
        #region Public Methods
        /// <summary>
        /// Get all server properties.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get properties for.</param>
        public Task<ServerPropertyEntity[]> ListAllServerPropertiesAsync(Guid serverUuid, CancellationToken cancellationToken = default)
        {
            return ((IServerPropertyOperations)this).ListAllServerPropertiesAsync<ServerPropertyEntity>(serverUuid, cancellationToken);
        }

        /// <summary>
        /// Get all server properties.
        /// </summary>
        /// <param name="serverUuid">The UUID of the server to get properties for.</param>
        public Task<TServerSettingEntity[]> ListAllServerPropertiesAsync<TServerSettingEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
            where TServerSettingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerSettingEntity[]>(HttpMethod.Get, $"server/{serverUuid}/settings", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for server settings.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public ServerPropertyOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
