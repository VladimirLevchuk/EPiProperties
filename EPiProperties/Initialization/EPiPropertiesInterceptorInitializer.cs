using EPiInterceptors;
using EPiServer.Framework;

namespace EPiProperties.Initialization
{
    [InitializableModule]
    public class EPiPropertiesInterceptorInitializer : InterceptionRegistrationModule
    {
        public override void RegisterInterceptors(ContentDataInterceptonRegistry registry)
        {
            registry.InterceptWith<EPiPropertiesInterceptor>();
        }
    }
}
