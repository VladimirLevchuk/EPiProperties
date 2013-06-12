using EPiProperties.Base;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiProperties.StatusProperties.Services;
using EPiServer.Framework;
using EPiServer.ServiceLocation;

namespace EPiProperties.StatusProperties.Initialization
{
    [InitializableModule]
    public class EPiStatusConfigurationModule : EPiPropertiesInitializationModuleBase
    {
        public override void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(x =>
                {
                    x.For<ICmsPageService>().Use<CmsPageService>();
                });
        }

        public override void ConfigureEPiProperties(EPiPropertiesRegistry registry)
        {
            registry.For<CmsPublishedStatusAttribute>().Use<PublishedStatusPropertyGetter>();
            registry.For<CmsPagePredicateAttribute>().Use<PagePredicatePropertyGetter>();
        }
    }
}