using EPiInterceptors;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EPiProperties.Initialization
{
    [InitializableModule]
    public class EPiPropertiesInterceptorInitializer : InterceptionRegistrationModule
    {
        public override void Initialize(InitializationEngine context)
        {
            base.Initialize(context);
        }

        public override void RegisterInterceptors(ContentDataInterceptonRegistry registry)
        {
            registry.InterceptWith<EPiPropertiesInterceptor>();
        }
    }
}
