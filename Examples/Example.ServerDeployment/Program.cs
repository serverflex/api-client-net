﻿using ServerFlex.API;
using ServerFlex.API.Authentication;
using ServerFlex.API.Entities;
using ServerFlex.API.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.ServerDeployment
{
    /// <summary>
    /// An example program to deploy a new server to your account.
    /// </summary>
    public static class Program
    {
        public static async Task Main()
        {
            // Create ServerFlex API client.
            var apiClient = new ApiClient
            {
                Authentication = new ApiKeyAuthentication
                {
                    ApiKey = Environment.GetEnvironmentVariable("API_KEY")
                }
            };

            // Get the current user so we can say hello :)
            var user = await apiClient.Accounts.GetUserAsync().ConfigureAwait(false);

            Console.WriteLine($"Hello, {user.GivenName}! Let's deploy a server!");

            // Get all available packages.
            var allPackages = await apiClient.Packages.ListAllPackagesAsync().ConfigureAwait(false);

            // We want to deploy a Minecraft server.
            var minecraftPackage = allPackages.FirstOrDefault(a => a.Name.Equals("minecraft"));

            if (minecraftPackage == null)
            {
                Console.WriteLine("Minecraft package was not found :(");
                return;
            }

            // Get the lowest tier plan.
            var serverPlan = minecraftPackage.Plans.OrderBy(p => p.Pricing.CostMonthly).First();

            // Select a region to deploy the server to.
            var region = minecraftPackage.Regions.First();

            var newServerConfig = new ServerDeployEntity
            {
                BillingType = BillingType.Hourly,
                Name = $".NET API Client Sample Server",
                PackageName = minecraftPackage.Name,
                PlanName = serverPlan.Name,
                Properties = new Dictionary<string, object>
                {
                    ["eula"] = true
                },
                RegionName = region.Name,
                Runtimes = new[]
                {
                    // Runtimes are formatted [runtime name]:[runtime version].
                    // This is used to deploy a vanilla Minecraft server on the latest version of Minecraft.
                    "vanilla:latest"
                }
            };

            // Deploy the server.
            var newCrate = await apiClient.Servers.DeployServerAsync(newServerConfig).ConfigureAwait(false);

            Console.WriteLine($"Congratulations! Your new server has been deployed! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
