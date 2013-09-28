using EPiProperties.Base;
using EPiProperties.OtherProperties.DataAnnotation;
using EPiServer.Framework;

namespace EPiProperties.OtherProperties.Initialization
{
    [InitializableModule]
    public class OtherPropertiesConfigurationModule : EPiPropertiesInitializationModuleBase
    {
        public override void ConfigureEPiProperties(EPiPropertiesRegistry registry)
        {
            registry.For<FriendlyUrlAttribute>().Use<FriendlyUrlPropertyGetter>();
        }
    }
}
