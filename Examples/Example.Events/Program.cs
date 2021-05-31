using ServerFlex.API;
using ServerFlex.API.Authentication;
using ServerFlex.API.Entities;
using ServerFlex.API.Events;
using System;
using System.Threading.Tasks;

namespace Example.Events
{
    /// <summary>
    /// An example program to deploy a new server to your account.
    /// </summary>
    public static class Program
    {
        public static async Task Main()
        {
            // Create ServerFlex API client.
            var apiClient = new ApiClient(new Uri("https://serverflex.ngrok.io/1.0/"), new Uri("wss://serverflex.ngrok.io/1.0/websockets/"))
            {
                Authentication = new ApiKeyAuthentication
                {
                    ApiKey = Environment.GetEnvironmentVariable("API_KEY")
                }
            };

            // List all servers in account.
            var servers = await apiClient.Servers.ListAllServersAsync();

            if (servers.Length == 0)
            {
                Console.WriteLine("Your account does not contain any servers to view events for :(");
                return;
            }

            // Register event handlers.
            apiClient.Connected += ApiClient_Connected;
            apiClient.Disconnected += ApiClient_Disconnected;
            apiClient.EventReceived += ApiClient_EventReceived;

            // Get our WebSocket token.
            var webSocketToken = await apiClient.Events.GetWebSocketTokenAsync();

            Console.WriteLine(webSocketToken.Token);
            Console.WriteLine(webSocketToken.ExpiryTime);
            Console.WriteLine();

            foreach (var server in servers)
            {
                await apiClient.Events.AddSubscriptionAsync(webSocketToken.Token, new SubscriptionNewEntity
                {
                    EventType = "state",
                    ResourceID = server.UUID.ToString(),
                    ResourceType = "server"
                });
            }

            Console.WriteLine($"Listening for events from {servers.Length} servers!");
            Console.WriteLine();

            // Wait for the console to fill up with events :)
            Console.ReadLine();
        }

        private static void ApiClient_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to events!");
            Console.WriteLine();
        }

        private static void ApiClient_Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Disconnected from events!");
            Console.WriteLine();
        }

        private static void ApiClient_EventReceived(object sender, EventReceivedEventArgs e)
        {
            Console.WriteLine("Event received!");
            Console.WriteLine($"Event type: {e.EventEntity.EventType}");
            Console.WriteLine($"Resource ID: {e.EventEntity.ResourceID}");
            Console.WriteLine($"Resource type: {e.EventEntity.ResourceType}");
            Console.WriteLine($"JSON payload: {e.EventEntity.Payload}");
            Console.WriteLine();
        }
    }
}
