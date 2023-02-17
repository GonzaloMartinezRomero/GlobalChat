using GlobalChatServer.Model;

namespace GlobalChatServer.AppConfiguration
{
    public static class ConfigurationExtension
    {   
        private const string CONFIGURATION_SECTION = "GlobalChatNetwork";

        public static GlobalChatNetworkConfiguration LoadGlobalChatConfiguration(this IConfigurationRoot configBuilder)
        {
            GlobalChatNetworkConfiguration config = configBuilder.GetSection(CONFIGURATION_SECTION)
                                                    .Get<GlobalChatNetworkConfiguration>() 
                                                    ?? throw new ArgumentNullException(nameof(GlobalChatNetworkConfiguration));
            config.CheckConfigurationValues();

            return config;
        }

        public static void CheckConfigurationValues(this GlobalChatNetworkConfiguration config)
        {
            if(String.IsNullOrEmpty(config.HubEndpoint))
                throw new ArgumentException(nameof(config.HubEndpoint));
        }
    }
}
