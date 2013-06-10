using EPiProperties.Abstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiProperties.Base
{
    public abstract class EPiPropertiesInitializationModuleBase : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var registry = ServiceLocator.Current.GetInstance<EPiPropertiesRegistry>();
            ConfigureEPiProperties(registry); 
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public abstract void ConfigureEPiProperties(EPiPropertiesRegistry registry);
    }
}