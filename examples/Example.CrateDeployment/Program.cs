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
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            // Create client.
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

            // Find package to deploy
            CratePackageEntity[] allPackages = await apiClient.CratePackages.ListAllCratePackagesAsync().ConfigureAwait(false);

            // Get "minecraft".
            CratePackageEntity minecraft = allPackages.SingleOrDefault(x => x.Name == "minecraft");

            if (minecraft == null)
                throw new Exception("Minecraft could not be found!");

            // Get the latest profile for this (ie get the latest version)
            CrateProfileEntity profile = minecraft.Profiles.OrderByDescending(x => x.Name).First();

            // Get the lowest plan
            CratePlanEntity plan = minecraft.Plans.OrderBy(x => x.CostPerHour).First();

            // Select a region to deploy to
            RegionEntity region = minecraft.Regions.First();

            // Run deployent.
            CrateEntity newCrate = await apiClient.Crates.DeployCrateAsync(new CrateDeployEntity
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
