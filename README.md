# api-client-net

The .NET API client for the BattleCrate platform.

## Getting Started

The use of the BattleCrate API requires an API key. Head over to the [BattleCrate web app](https://app.battlecrate.io/) to generate one.

Add a reference to BattleCrate.API.

## Usage

### Create the BattleCrate API client

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

Requests are separated into operations accessible via the `ApiClient`, for example: `ApiClient.Crates` or `ApiClient.Regions`. View the [sample projects](https://github.com/battlecrate/api-client-net/tree/master/examples) for examples.

### Extending

This client has been designed to maximize extendability. All operation methods are virtual, and have generic method variants so that you can request custom entities without having to create multiple objects. You can override the respective construct methods within `ApiClient` to return your custom operations.

```
public class CustomCrateOperations : CrateOperations
{
    public override async Task<TCrateEntity> GetCrateAsync<TCrateEntity>(Guid crateUuid, CancellationToken cancellationToken = default)
        where TCrateEntity : class
    {
        var crate = await base.GetCrateAsync<TCrateEntity>(crateUuid, cancellationToken);
        
        if (crate is CustomCrateEntity customCrate)
        {
            // Custom Crate functionality.
        }
        
        return crate;
    }
    
    ...
}

public class CustomApiClient : ApiClient
{
    protected override ICrateOperations ConstructCrateOperations()
    {
        return new CustomCrateOperations(this);
    }
}
```
