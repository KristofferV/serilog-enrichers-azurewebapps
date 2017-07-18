using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers.AzureAppService.NETStandard
{
    /// <summary>
    /// Generic log event enricher that takes the value of some environment variable and adds it as
    /// a property with a specified name on Serilog events. The environment variable is expected to
    /// remain constant during program execution and will therefore be cached.
    /// </summary>
    public class EnvironmentVariableEnricher : ILogEventEnricher
    {
        private readonly string _serilogPropertyName;
        private readonly string _environmentVariableName;
        private readonly string _defaultValue;
        private LogEventProperty _cachedProperty;

        /// <summary>
        /// Constructs a new enricher based on the given values.
        /// </summary>
        /// <param name="serilogName">The property name to use when adding value to log events.</param>
        /// <param name="environmentName">The name of the environment variable to take value from.</param>
        /// <param name="defaultValue">The default value to use in case the environment variable does not exist.</param>
        public EnvironmentVariableEnricher(string serilogName, string environmentName, string defaultValue)
        {
            _serilogPropertyName = serilogName;
            _environmentVariableName = environmentName;
            _defaultValue = defaultValue;
        }

        /// <summary>
        /// See <see cref="ILogEventEnricher.Enrich(LogEvent, ILogEventPropertyFactory)"/>.
        /// </summary>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var cachedProp = _cachedProperty;
            if (cachedProp == null)
            {
                string valueToUse = Environment.GetEnvironmentVariable(_environmentVariableName) ?? _defaultValue;
                _cachedProperty = cachedProp = propertyFactory.CreateProperty(_serilogPropertyName, valueToUse);
            }

            logEvent.AddPropertyIfAbsent(cachedProp);
        }
    }
}
