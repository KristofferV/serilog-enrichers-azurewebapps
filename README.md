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

### About the environment variables

A proper description of the Azure App service environment and the available variables is [here][1]. For WebJobs, the
information is [here][2].

[1]: https://github.com/projectkudu/kudu/wiki/Azure-runtime-environment
[2]: https://github.com/projectkudu/kudu/wiki/WebJobs#environment-settings

### Included enrichers

The package includes:

 * `WithAzureWebAppsSiteName()` - adds the name of the Azure WebApp the application runs within - reads the WEBSITE\_SITE\_NAME environment variable.
 * `WithAzureWebAppsHostName()` - adds the URL of the Azure WebApp the application runs within - reads WEBSITE\_HOSTNAME.
 * `WithAzureWebAppsInstanceId()` - adds the identifier of the Azure App Service VM instance the app runs within - reads WEBSITE\_INSTANCE\_ID.
 * `WithAzureWebJobsName()` - adds the name of the Azure WebJob (if the application is a WebJob) - reads WEBJOBS\_NAME.
 * `WithAzureWebJobsType` - adds the type name of the Azure WebJob (continuous or triggered) - reads WEBJOBS\_TYPE.
