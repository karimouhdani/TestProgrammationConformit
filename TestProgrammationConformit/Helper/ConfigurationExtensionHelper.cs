using Microsoft.Extensions.Configuration;

namespace TestProgrammationConformit.Helper
{
    /// <summary>
    /// Configuration Extension Helper
    /// </summary>
    public static class ConfigurationExtensionHelper
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetConfig(this IConfiguration configuration, string section, string key)
        {
            string configValue = null;

            if (configuration != null)
                configValue = configuration[$"{ section}:{ key}"];

            return configValue;
        }

        /// <summary>
        /// Gets the configuration as int.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int GetConfigAsInt(this IConfiguration configuration, string section, string key, int defaultValue)
        {
            if (int.TryParse(configuration.GetConfig(section, key), out int intConfig))
                return intConfig;

            return defaultValue;
        }
    }
}
