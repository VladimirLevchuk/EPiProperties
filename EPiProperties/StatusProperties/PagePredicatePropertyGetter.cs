using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiProperties.Util;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EPiProperties.StatusProperties
{
    public class PagePredicatePropertyGetter : IEPiPropertyGetter
    {
        public virtual bool CanIntercept(PageData page, PropertyInfo property)
        {
            return property.PropertyType == typeof(bool);
        }

        public virtual object GetValue(PageData page, PropertyInfo property)
        {
            var annotation = property.GetAnnotation<CmsPagePredicateAttribute>();

            var predicate = (IPagePredicate) ServiceLocator.Current.GetService(annotation.Predicate);

            return predicate.Test(page);
        }
    }
}