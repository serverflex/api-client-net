using BattleCrate.API;
using BattleCrate.API.Entities;
using System;
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
            // Create BattleCrate API client.
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

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
            var newCrate = await apiClient.Crates.DeployCrateAsync(new CrateDeployEntity
            {
                Name = "Sample Crate",
                PlanName = plan.Name,
                ProfileName = profile.Name,
                RegionName = region.Name

            }).ConfigureAwait(false);

            Console.WriteLine($"Your new Crate: \"{newCrate.Name}\" has been deployed!");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
