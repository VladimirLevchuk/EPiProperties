using EPiProperties.Abstraction;
using EPiProperties.Base;
using EPiProperties.Initialization;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Framework;

namespace EPiProperties.NavigationProperties.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiPropertiesInterceptorInitializer))]
    public class EPiNavigationPropertiesInitializationModule : EPiPropertiesInitializationModuleBase
    {
        public override void ConfigureEPiProperties(EPiPropertiesRegistry registry)
        {
            registry.For<CmsChildrenAttribute>().Use<ChildrenPropertyGetter>();
            registry.For<CmsAncestorsAttribute>().Use<AncestorsPropertyGetter>();
            registry.For<CmsDescendantsAttribute>().Use<DescendentsPropertyGetter>();
            registry.For<CmsParentAttribute>().Use<ParentPropertyGetter>();
            registry.For<CmsReferenceAttribute>().Use<ReferencePropertyGetter>();
        }
    }
}
