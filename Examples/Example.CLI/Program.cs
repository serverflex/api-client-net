using BattleCrate.API;
using System;
using System.Threading.Tasks;

namespace Example.CLI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

            var crates = await apiClient.Crates.ListAllCratesAsync().ConfigureAwait(false);

            foreach (var crate in crates)
            {
                var players = await apiClient.Crates.GetPlayersAsync(crate.UUID).ConfigureAwait(false);
                
                Console.WriteLine($"{crate.Name} (created at {crate.CreatedAt:HH:mm, dd-MM-yyyy}) currently has {players.OnlineCount} players online.");
            }
        }
    }
}
