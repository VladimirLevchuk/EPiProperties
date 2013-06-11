using EPiProperties.StatusProperties.Services;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiProperties.StatusProperties.Initialization
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class EPiStatusConfigurationModule : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(x =>
                {
                    x.For<ICmsPageService>().Use<CmsPageService>();
                });
        }
    }
}