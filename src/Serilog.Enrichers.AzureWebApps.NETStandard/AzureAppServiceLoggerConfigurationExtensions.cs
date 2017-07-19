using System;
using Serilog.Configuration;
using Serilog.Enrichers.AzureAppService.NETStandard;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for Azure App Service environment.
    /// </summary>
    public static class AzureAppServiceLoggerConfigurationExtensions
    {
        // For available environment variables see: https://github.com/projectkudu/kudu/wiki/Azure-runtime-environment

        /// <summary>
        /// Adds the Azure site name to log events. The site name is the value taken from
        /// enviroment variable WEBSITE_SITE_NAME. In Azure App Service this contains the name of
        /// the Azure Web App.
        /// </summary>
        /// <param name="enrichmentConfiguration">Enrichment configuration to complete.</param>
        /// <returns>Logger configuration with this enricher configured.</returns>
        public static LoggerConfiguration WithAzureWebAppsSiteName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "AzureWebAppsSiteName",
                environmentName: "WEBSITE_SITE_NAME",
                defaultValue: "LOCAL");

            return enrichmentConfiguration.With(enricher);
        }

        /// <summary>
        /// Adds the Azure host name to log events. The host name is the value taken from
        /// environment variable WEBSITE_HOSTNAME. In Azure App Service this contains the URL for
        /// the site and includes the site name along with the slot name.
        /// </summary>
        /// <param name="enrichmentConfiguration">Enrichment configuration to complete.</param>
        /// <returns>Logger configuration with this enricher configured.</returns>
        // For details see: http://blog.amitapple.com/post/2014/11/azure-websites-slots/
        public static LoggerConfiguration WithAzureWebAppsHostName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "AzureWebAppsHostName",
                environmentName: "WEBSITE_HOSTNAME",
                defaultValue: "localhost");

            return enrichmentConfiguration.With(enricher);
        }

        /// <summary>
        /// Adds the Azure instance id to log events. The instance id is the value taken from
        /// environment variable WEBSITE_INSTANCE_ID. In Azure App Service this contains the
        /// identifier for the VM that the site is running on.
        /// </summary>
        /// <param name="enrichmentConfiguration">Enrichment configuration to complete.</param>
        /// <returns>Logger configuration with this enricher configured.</returns>
        public static LoggerConfiguration WithAzureWebAppsInstanceId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "AzureWebAppsInstanceId",
                environmentName: "WEBSITE_INSTANCE_ID",
                defaultValue: "localhost");

            return enrichmentConfiguration.With(enricher);
        }

        /// <summary>
        /// Adds the Azure Web Jobs name to log events. The web job name is taken from environment
        /// variable WEBJOBS_NAME. In Azure App Service this contains the name of the web job.
        /// </summary>
        /// <param name="enrichmentConfiguration">Enrichment configuration to complete.</param>
        /// <returns>Logger configuration with this enricher configured.</returns>
        public static LoggerConfiguration WithWebJobsName(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "AzureWebJobsName",
                environmentName: "WEBJOBS_NAME",
                defaultValue: "NO_WEBJOB");

            return enrichmentConfiguration.With(enricher);
        }

        /// <summary>
        /// Adds the Azure Web Jobs type to log events. The web job type is taken from environment
        /// variable WEBJOBS_TYPE. In Azure App Service this contains the type of the web job
        /// (triggered or continuous).
        /// </summary>
        /// <param name="enrichmentConfiguration">Enrichment configuration to complete.</param>
        /// <returns>Logger configuration with this enricher configured.</returns>
        public static LoggerConfiguration WithWebJobsType(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "AzureWebJobsType",
                environmentName: "WEBJOBS_TYPE",
                defaultValue: "NO_WEBJOB");

            return enrichmentConfiguration.With(enricher);
        }
    }
}
