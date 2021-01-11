using ServerFlex.API;
using ServerFlex.API.Authentication;
using System;
using System.Threading.Tasks;

namespace Example.ServerPlayers
{
    /// <summary>
    /// An example program to get player information about a server.
    /// </summary>
    public static class Program
    {
        public async static Task Main()
        {
            // Create client.
            var apiClient = new ApiClient
            {
                Authentication = new ApiKeyAuthentication
                {
                    ApiKey = Environment.GetEnvironmentVariable("API_KEY")
                }
            };

            // Get all servers on your account.
            var servers = await apiClient.Servers.ListAllServersAsync().ConfigureAwait(false);

            foreach (var server in servers)
            {
                var players = await apiClient.Servers.GetPlayersAsync(server.UUID).ConfigureAwait(false);

                Console.WriteLine($"{server.Name} (created at {server.CreatedAt:HH:mm, dd-MM-yyyy}) currently has {players.Online} players online.");
            }
        }
    }
}
