# api-client-net

The .NET API client for the BattleCrate platform.

## Getting Started

You will need a BattleCrate API key to use the API. Head over to the [BattleCrate web app](https://app.battlecrate.io/) to generate one.

Add a reference to BattleCrate.API.

## Usage

### Create the BattleCrate API client

```
// Parameterless constructor.
ApiClient apiClient = new ApiClient();

// Create an API client with your API key.
ApiClient apiClient = new ApiClient("your_api_key");

// Create an API client with a custom base URI and no API key.
ApiClient apiClient = new ApiClient(new Uri("custom_base_uri"));

// Create an API client with a custom base URI and your API key.
ApiClient apiClient = new ApiClient(new Uri("custom_base_uri"), "your_api_key");
```

### Making requests

Requests are separated into operations accessible via the `ApiClient`, for example: `ApiClient.Crates` or `ApiClient.Regions`. View the [sample projects](https://github.com/battlecrate/api-client-net/tree/master/examples) for examples.
