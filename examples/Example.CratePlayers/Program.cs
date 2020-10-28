using BattleCrate.API;
using BattleCrate.API.Authentication;
using System;
using System.Threading.Tasks;

namespace Example.CratePlayers
{
    /// <summary>
    /// An example program to get player information about a Crate.
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

            // Get all Crates on your account.
            var crates = await apiClient.Crates.ListAllCratesAsync().ConfigureAwait(false);

            foreach (var crate in crates)
            {
                var players = await apiClient.Crates.GetPlayersAsync(crate.UUID).ConfigureAwait(false);

                Console.WriteLine($"{crate.Name} (created at {crate.CreatedAt:HH:mm, dd-MM-yyyy}) currently has {players.Online} players online.");
            }
        }
    }
}
