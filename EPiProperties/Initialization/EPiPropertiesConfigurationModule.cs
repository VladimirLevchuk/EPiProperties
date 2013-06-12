using EPiInterceptors;
using EPiProperties.Abstraction;
using EPiServer.Framework;
using EPiServer.ServiceLocation;
using StructureMap;

namespace EPiProperties.Initialization
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class EPiPropertiesConfigurationModule : InterceptionRegistrationInitModuleBase
    {
        public override void ConfigureContainer(ServiceConfigurationContext context)
        {
            base.ConfigureContainer(context);
            RegistryIoC(context.Container);
        }

        public virtual void RegistryIoC(IContainer container)
        {
            container.Configure(x =>
                {
                    x.For<EPiPropertiesRegistry>().Singleton().Use<EPiPropertiesRegistry>();
                    x.For<IEPiPropertiesRegistry>().Use(() => ServiceLocator.Current.GetInstance<EPiPropertiesRegistry>());
                    x.For<EPiPropertiesInterceptor>().Use<EPiPropertiesInterceptor>();
                });            
        }

        public override void RegisterContentDataInterceptors(ContentDataInterceptonRegistry registry)
        {
            registry.InterceptWith<EPiPropertiesInterceptor>();
        }
    }
}