using EPiInterceptors;
using EPiServer.Framework;

namespace EPiProperties.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiPropertiesConfigurationModule))]
    [ModuleDependency(typeof(ContentDataInterceptionExtendModule))]
    public class EPiPropertiesInterceptorInitializer : InterceptionRegistrationModule
    {
        public override void RegisterInterceptors(ContentDataInterceptonRegistry registry)
        {
            registry.InterceptWith<EPiPropertiesInterceptor>();
        }
    }
}
