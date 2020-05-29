using BattleCrate.API;
using System;
using System.Threading.Tasks;

namespace Example.CratePlayers
{
    /// <summary>
    /// An example program to get player information about a Crate.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async static Task Main(string[] args)
        {
            // Create client.
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

            // Get all Crates on your account.
            var crates = await apiClient.Crates.ListAllCratesAsync().ConfigureAwait(false);

            foreach (var crate in crates)
            {
                var players = await apiClient.Crates.GetPlayersAsync(crate.UUID).ConfigureAwait(false);

                Console.WriteLine($"{crate.Name} (created at {crate.CreatedAt:HH:mm, dd-MM-yyyy}) currently has {players.OnlineCount} players online.");
            }
        }
    }
}
