using EPiInterceptors;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiProperties.App_Start
{
    public class EPiPropertiesInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var interceptorsRegistry = ServiceLocator.Current.GetInstance<ContentDataInterceptonRegistry>();
        
            interceptorsRegistry.InterceptWith<EPiPropertiesInterceptor>();
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
