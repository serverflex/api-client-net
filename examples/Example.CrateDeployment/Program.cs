using BattleCrate.API;
using BattleCrate.API.Authentication;
using BattleCrate.API.Entities;
using BattleCrate.API.Schema;
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
            var apiClient = new ApiClient
            {
                Authentication = new ApiKeyAuthentication
                {
                    ApiKey = Environment.GetEnvironmentVariable("API_KEY")
                }
            };

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

            // Get the lowest tier Crate Plan.
            var cratePlan = minecrateCratePackage.Plans.OrderBy(p => p.Pricing.Sum(pr => pr.CostMonthly)).First();

            // Select a Region to deploy the Crate to.
            var region = minecrateCratePackage.Regions.First();

            var newCrateConfiguration = new CrateDeployEntity
            {
                BillingType = BillingType.Hourly,
                Name = $".NET API Client Sample Crate",
                PackageName = minecrateCratePackage.Name,
                PlanName = cratePlan.Name,
                Properties = new Dictionary<string, object>
                {
                    ["eula"] = true
                },
                RegionName = region.Name,
                Runtimes = new[]
                {
                    // Runtimes are formatted [runtime name]:[runtime version].
                    // This is used to deploy a vanilla Minecraft Crate on the latest version of Minecraft.
                    "vanilla:latest"
                }
            };

            // Deploy the Crate.
            var newCrate = await apiClient.Crates.DeployCrateAsync(newCrateConfiguration).ConfigureAwait(false);

            Console.WriteLine($"Congratulations! Your new Crate has been deployed! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
