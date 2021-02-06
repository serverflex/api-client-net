using ServerFlex.API.Entities;
using ServerFlex.API.Operations.Base;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFlex.API.Operations
{
    public class ServerPackageOperations : BaseOperations, IServerPackageOperations
    {
        #region Public Methods
        /// <summary>
        /// Get a server Package.
        /// </summary>
        /// <param name="serverPackageName">The name of the server Package.</param>
        public virtual Task<ServerPackageEntity> GetServerPackageAsync(string serverPackageName, CancellationToken cancellationToken = default)
        {
            return ((IServerPackageOperations)this).GetServerPackageAsync<ServerPackageEntity>(serverPackageName, cancellationToken);
        }

        /// <summary>
        /// Get a server Package.
        /// </summary>
        /// <param name="serverPackageName">The name of the server Package.</param>
        public virtual Task<TServerPackageEntity> GetServerPackageAsync<TServerPackageEntity>(string serverPackageName, CancellationToken cancellationToken = default)
            where TServerPackageEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerPackageEntity>(HttpMethod.Get, $"package/{serverPackageName}", cancellationToken);
        }

        /// <summary>
        /// Get all available server Packages.
        /// </summary>
        public virtual Task<ServerPackageEntity[]> ListAllServerPackagesAsync(CancellationToken cancellationToken = default)
        {
            return ((IServerPackageOperations)this).ListAllServerPackagesAsync<ServerPackageEntity>(cancellationToken);
        }

        /// <summary>
        /// Get all available server Packages.
        /// </summary>
        public virtual Task<TServerPackageEntity[]> ListAllServerPackagesAsync<TServerPackageEntity>(CancellationToken cancellationToken = default)
            where TServerPackageEntity : class
        {
            return ApiRequestor.RequestEntireListJsonSerializedAsync<TServerPackageEntity>("package", cancellationToken);
        }

        /// <summary>
        /// Get a page of server Packages.
        /// </summary>
        /// <param name="limit">The maximum number of server Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<ServerPackageEntity>> ListServerPackagesAsync(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
        {
            return ((IServerPackageOperations)this).ListServerPackagesAsync<ServerPackageEntity>(limit, page, cancellationToken);
        }

        /// <summary>
        /// Get a page of server Packages.
        /// </summary>
        /// <param name="limit">The maximum number of server Packages that can be returned. Minimum: 1, maximum: 50.</param>
        /// <param name="page">The cursor for the next batch of results.</param>
        public virtual Task<ResultResponseEntity<TServerPackageEntity>> ListServerPackagesAsync<TServerPackageEntity>(int limit = 25, int page = 1, CancellationToken cancellationToken = default)
            where TServerPackageEntity : class
        {
            return ApiRequestor.RequestResultResponseJsonSerializedAsync<TServerPackageEntity>(limit, page, "package", cancellationToken);
        }
        
        /// <summary>
        /// Get all server properties.
        /// </summary>
        /// <param name="serverPackageName">The server Package name.</param>
        public virtual Task<ServerPropertyEntity[]> ListAllServerPackagePropertiesAsync(string serverPackageName, CancellationToken cancellationToken = default)
        {
            return ((IServerPackageOperations)this).ListAllServerPackagePropertiesAsync<ServerPropertyEntity>(serverPackageName, cancellationToken);
        }

        /// <summary>
        /// Get all server properties.
        /// </summary>
        /// <param name="serverPackageName">The server Package name.</param>
        public virtual Task<TServerSettingEntity[]> ListAllServerPackagePropertiesAsync<TServerSettingEntity>(string serverPackageName, CancellationToken cancellationToken = default)
            where TServerSettingEntity : class
        {
            return ApiRequestor.RequestJsonSerializedAsync<TServerSettingEntity[]>(HttpMethod.Get, $"package/{serverPackageName}/properties", cancellationToken);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new set of API operations for server Packages.
        /// </summary>
        /// <param name="apiRequestor">The API requestor to use for communicating with the API.</param>
        public ServerPackageOperations(IApiRequestor apiRequestor)
            : base(apiRequestor)
        {
        }
        #endregion
    }
}
