using System;
using FluentAssertions;
using NUnit.Framework;
using Serilog.Enrichers.AzureAppService;
using Serilog.Events;

namespace Serilog.Enrichers.AzureAppService.UnitTest
{
    public class EnvironmentVariableEnricherTest
    {
        [Test]
        public void When_environment_variable_not_set_default_value_is_used()
        {
            LogEvent logEvent = null;

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "SerilogPropertyName",
                environmentName: "MY_ENV_VARIABLE",
                defaultValue: "namename");

            var logger = new LoggerConfiguration()
                .Enrich.With(enricher)
                .WriteTo.Sink(new DelegatingSink(e => logEvent = e))
                .CreateLogger();

            logger.Information("Test log");

            var propertyInEvent = (ScalarValue)logEvent.Properties["SerilogPropertyName"];
            propertyInEvent.Value.Should().Be("namename");
        }

        [Test]
        public void When_environtment_variable_is_set_it_is_also_used()
        {
            LogEvent logEvent = null;
            Environment.SetEnvironmentVariable("MY_ENV_VARIABLE","Hubbadubba");

            var enricher = new EnvironmentVariableEnricher(
                serilogName: "SerilogPropertyName",
                environmentName: "MY_ENV_VARIABLE",
                defaultValue: "namename");

            var logger = new LoggerConfiguration()
                .Enrich.With(enricher)
                .WriteTo.Sink(new DelegatingSink(e => logEvent = e))
                .CreateLogger();

            logger.Information("Test log");

            var propertyInEvent = (ScalarValue)logEvent.Properties["SerilogPropertyName"];
            propertyInEvent.Value.Should().Be("Hubbadubba");
        }
    }
}
