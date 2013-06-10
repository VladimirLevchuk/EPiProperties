using EPiProperties.Abstraction;
using EPiProperties.App_Start;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiProperties.Base
{
    [ModuleDependency(typeof(EPiPropertiesInitializationModule))]
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