using System.Reflection;
using EPiProperties.Contracts;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiProperties.Util;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace EPiProperties.StatusProperties
{
    public class PagePredicatePropertyGetter : IEPiPropertyGetter
    {
        public virtual bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            return property.HasAnnotation<CmsPagePredicateAttribute>() 
                && (contentData is PageData) && property.PropertyType == typeof(bool);
        }

        public virtual object GetValue(IContentData contentData, PropertyInfo property)
        {
            var annotation = property.GetAnnotation<CmsPagePredicateAttribute>();

            var predicate = (IPagePredicate) ServiceLocator.Current.GetService(annotation.Predicate);

            return predicate.Test((PageData) contentData);
        }
    }
}