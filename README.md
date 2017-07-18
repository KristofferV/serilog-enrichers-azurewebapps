# Serilog.Enrichers.AzureAppService


Enrichers that add properties from Azure App Service environment variables.
 
To use the enrichers, first install the NuGet package:

```powershell
Install-Package Serilog.Enrichers.AzureAppService
```

Then, apply the enrichers to your `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
    .Enrich.WithAzureWebAppsSiteName()
    .Enrich.WithAzureWebAppsHostName()
    .Enrich.WithAzureWebAppsInstanceId()
    .Enrich.WithAzureWebJobsName()
    .Enrich.WithAzureWebJobsType()
    // ...other configuration...
    .CreateLogger();
```

### Included enrichers

The package includes:

 * `WithAzureWebAppsSiteName()` - adds the name of the Azure WebApp the application runs within
 * `WithAzureWebAppsHostName()` - adds the URL of the Azure WebApp the application runs within
 * `WithAzureWebAppsInstanceId()` - adds the identifier of the Azure App Service VM instance the app runs within
 * `WithAzureWebJobsName()` - adds the name of the Azure WebJob (if the application is a WebJob)
 * `WithAzureWebJobsType` - adds the type name of the Azure WebJob (continuous or triggered)
