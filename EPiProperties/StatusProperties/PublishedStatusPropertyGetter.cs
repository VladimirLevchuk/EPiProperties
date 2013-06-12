using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiServer.Core;
using EPiProperties.Util;
using EPiServer.Filters;

namespace EPiProperties.StatusProperties
{
    public class PublishedStatusPropertyGetter : IEPiPropertyGetter
    {
        public virtual bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            return property.HasAnnotation<CmsPublishedStatusAttribute>() 
                && contentData is IContent 
                && property.PropertyType == typeof(bool);
        }

        public virtual object GetValue(IContentData contentData, PropertyInfo property)
        {
            var content = (IContent) contentData;
            var annotation = property.GetAnnotation<CmsPublishedStatusAttribute>();

            var result = FilterPublished.CheckPublishedStatus(content, annotation.Status);

            return result;
        }
    }
}
