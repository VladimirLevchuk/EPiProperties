using System;
using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiServer.Core;
using Castle.Core.Internal;

namespace EPiProperties.StatusProperties
{
    public class PublishedStatusPropertyGetter : IEPiPropertyGetter
    {
        public virtual bool CanIntercept(PageData page, PropertyInfo property)
        {
            return property.PropertyType == typeof(bool);
        }

        public virtual object GetValue(PageData page, PropertyInfo property)
        {
            var annotation = property.GetAttribute<CmsPublishedStatusAttribute>();
            if (annotation == null)
            {
                throw new InvalidOperationException("No CmsReference annotation attribute. ");
            }

            var result = page.CheckPublishedStatus(annotation.Status);

            return result;
        }
    }
}
