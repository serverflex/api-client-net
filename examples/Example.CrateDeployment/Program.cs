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
        public static async Task Main()
        {
            // Create BattleCrate API client.
            var apiClient = new ApiClient(Environment.GetEnvironmentVariable("API_KEY"));

            // Get the current user so we can say hello :)
            var user = await apiClient.Accounts.GetUserAsync().ConfigureAwait(false);

            Console.WriteLine($"Hello, {user.GivenName}! Let's deploy a Crate!");

            // Get all available Crate Packages.
            var allCratePackages = await apiClient.CratePackages.ListAllCratePackagesAsync().ConfigureAwait(false);

            // We want to deploy a Minecraft Crate.
            var minecrateCratePackage = allCratePackages.FirstOrDefault(a => a.Name.Equals("minecraft"));

            if (minecrateCratePackage == null)
            {
                Console.WriteLine("Minecraft Crate Package was not found :(");
                return;
            }

            // Get the latest Crate Profile for the Crate Package.
            var crateProfile = minecrateCratePackage.Profiles.OrderByDescending(p => p.Name).First();

            // Get the lowest tier Crate Plan.
            var cratePlan = minecrateCratePackage.Plans.OrderBy(p => p.Pricing.Sum(pr => pr.CostMonthly)).First();

            // Select a Region to deploy the Crate to.
            var region = minecrateCratePackage.Regions.First();

            var newCrateConfiguration = new CrateDeployEntity
            {
                Name = $".NET API Client Sample Crate",
                PlanName = cratePlan.Name,
                ProfileName = crateProfile.Name,
                RegionName = region.Name,
                Properties = new Dictionary<string, object>
                {
                    ["eula"] = true,
                    ["version"] = "1.15.2"
                }
            };

            // Deploy the Crate.
            var newCrate = await apiClient.Crates.DeployCrateAsync(newCrateConfiguration).ConfigureAwait(false);

            Console.WriteLine($"Congratulations! Your new Crate has been deployed! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
