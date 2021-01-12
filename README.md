# api-client-net

The .NET API client for the ServerFlex platform.

## Getting Started

The use of the ServerFlex API requires an API key. Head over to the [ServerFlex web app](https://app.battlecrate.io/) to generate one.

Add a reference to ServerFlex.API.

## Usage

### Create the ServerFlex API client

```
// Parameterless constructor.
ApiClient apiClient = new ApiClient();

// Create an API client with a custom base URI.
ApiClient apiClient = new ApiClient(new Uri("custom_base_uri"));
```

### Add authentication

```
apiClient.Authentication = new ApiKeyAuthentication
{
    ApiKey = "your_api_key"
};
```

### Making requests

Requests are separated into operations accessible via the `ApiClient`, for example: `ApiClient.Servers` or `ApiClient.Regions`. View the [sample projects](https://github.com/battlecrate/api-client-net/tree/master/examples) for examples.

### Extending

This client has been designed to maximize extendability. All operation methods are virtual, and have generic method variants so that you can request custom entities without having to create multiple objects. You can override the respective construct methods within `ApiClient` to return your custom operations.

```
public class CustomServerOperations : ServerOperations
{
    public override async Task<TServerEntity> GetServerAsync<TServerEntity>(Guid serverUuid, CancellationToken cancellationToken = default)
        where TServerEntity : class
    {
        var server = await base.GetServerAsync<TServerEntity>(serverUuid, cancellationToken);
        
        if (server is CustomServerEntity customServer)
        {
            // Custom server functionality.
        }
        
        return server;
    }
    
    ...
}

public class CustomApiClient : ApiClient
{
    protected override IServerOperations ConstructServerOperations()
    {
        return new CustomServerOperations(this);
    }
    
    ...
}
```
