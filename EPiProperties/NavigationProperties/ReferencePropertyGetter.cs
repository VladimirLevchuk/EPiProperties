using System;
using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;
using Castle.Core.Internal;

namespace EPiProperties.NavigationProperties
{
    public class ReferencePropertyGetter : IEPiPropertyGetter
    {
        private readonly IContentLoader _contentLoader;

        protected virtual IContentLoader ContentLoader { get { return _contentLoader; }}

        public ReferencePropertyGetter(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public bool CanIntercept(PageData page, PropertyInfo property)
        {
            return property.PropertyType.Is<PageData>();
        }

        public object GetValue(PageData page, PropertyInfo property)
        {
            ////// define if property is required
            ////bool isRequired = property.HasAttribute<RequiredAttribute>();

            // get annotation attribute
            var annotation = property.GetAnnotation<CmsReferenceAttribute>();

            // get reference property name set by attribute or default
            var referencePropertyName = annotation.LinkFieldName ?? property.Name + "Link";

            // lookup reference property
            var referenceProperty = page.GetType().GetProperty(referencePropertyName);

            if (referenceProperty == null)
            {
                // return null if not found, think about throwing an Exception if Required annotation present. 
                return null;
            }

            // get reference
            var link = referenceProperty.GetValue(page, new object[0]) as PageReference;

            if (PageReference.IsNullOrEmpty(link))
            {
                return null;
            }

            // load referenced page and cast it to the target property type. 
            var result = ContentLoader.Get<PageData>(link).Cast(property.PropertyType);
            return result;
        }
    }
}