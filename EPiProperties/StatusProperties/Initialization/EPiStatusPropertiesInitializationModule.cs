using EPiProperties.Abstraction;
using EPiProperties.Base;
using EPiProperties.Initialization;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiServer.Framework;

namespace EPiProperties.StatusProperties.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiPropertiesInterceptorInitializer))]
    public class EPiStatusPropertiesInitializationModule : EPiPropertiesInitializationModuleBase
    {
        public override void ConfigureEPiProperties(EPiPropertiesRegistry registry)
        {
            registry.For<CmsPublishedStatusAttribute>().Use<PublishedStatusPropertyGetter>();
            registry.For<CmsPagePredicateAttribute>().Use<PagePredicatePropertyGetter>();
        }
    }
}
