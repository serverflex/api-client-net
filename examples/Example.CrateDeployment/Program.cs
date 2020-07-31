using BattleCrate.API;
using BattleCrate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.CLI
{
    /// <summary>
    /// An example program to deploy a new Crate to your account.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static async Task Main()
        {
            int deployCrates = 25;

            // Create BattleCrate API client.
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

            UserEntity account = await apiClient.Accounts.GetUserAsync().ConfigureAwait(false);

            Console.WriteLine($"Hello {account.GivenName}, we are going to deploy {deployCrates} Crates.");

            // Find package to deploy.
            var allPackages = await apiClient.CratePackages.ListAllCratePackagesAsync().ConfigureAwait(false);

            // Get "minecraft".
            var minecraftPackage = allPackages.SingleOrDefault(x => x.Name == "minecraft");

            if (minecraftPackage == null)
                throw new Exception("Minecraft could not be found!");

            // Get the latest profile for this (ie get the latest version).
            var profile = minecraftPackage.Profiles.OrderByDescending(x => x.Name).First();

            // Get the lowest tier plan.
            var plan = minecraftPackage.Plans.OrderBy(x => x.Pricing.Sum(p => p.CostMonthly)).First();

            // Select a region to deploy to.
            var region = minecraftPackage.Regions.First();

            // Run deployment.
            for(int i = 0; i < deployCrates; i++)
            {
                var newCrate = await apiClient.Crates.DeployCrateAsync(new CrateDeployEntity
                {
                    Name = $"Sample Crate {i}",
                    PlanName = plan.Name,
                    ProfileName = profile.Name,
                    RegionName = region.Name,
                    Properties = new Dictionary<string, object>
                    {
                        { "eula", true },
                        { "version", "1.15.2" }
                    }
                }).ConfigureAwait(false);

                Console.WriteLine($"Your new Crate: \"{newCrate.Name}\" has been created!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
