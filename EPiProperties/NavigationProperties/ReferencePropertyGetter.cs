using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;
using Castle.Core.Internal;
using EPiServer.Framework.Localization;

namespace EPiProperties.NavigationProperties
{
    public class ReferencePropertyGetter : IEPiPropertyGetter
    {
        private readonly IContentLoader _contentLoader;
        private readonly LocalizationService _localizationService;

        protected virtual IContentLoader ContentLoader { get { return _contentLoader; }}
        protected virtual LocalizationService LocalizationService { get { return _localizationService; } }

        public ReferencePropertyGetter(IContentLoader contentLoader, LocalizationService localizationService)
        {
            _contentLoader = contentLoader;
            _localizationService = localizationService;
        }

        public bool CanIntercept(PageData page, PropertyInfo property)
        {
            return property.PropertyType.Is<PageData>();
        }

        public object GetValue(PageData page, PropertyInfo property)
        {
            // define if property is required
            var requiredAnnotation = property.GetAttribute<RequiredAttribute>();

            // get annotation attribute
            var annotation = property.GetAnnotation<CmsReferenceAttribute>();

            // get reference property name set by attribute or default
            var referencePropertyName = annotation.LinkFieldName ?? property.Name + "Link";

            // lookup reference property
            var referenceProperty = page.GetType().GetProperty(referencePropertyName);

            if (referenceProperty != null)
            // if reference property found
            {
                // get link to a referenced page
                var link = referenceProperty.GetValue(page, new object[0]) as PageReference;

                if (!PageReference.IsNullOrEmpty(link))
                // and if it's not empty
                {
                    // load referenced page and cast it to the target property type. 
                    var result = ContentLoader.Get<PageData>(link).Cast(property.PropertyType);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            if (requiredAnnotation == null)
            // if property is not marked as required
            {
                return null;
            }

            // otherwise get error message
            string errorMessageFormat; 

            if (!string.IsNullOrEmpty(requiredAnnotation.ErrorMessageResourceName))
            {
                errorMessageFormat = LocalizationService.GetString(requiredAnnotation.ErrorMessageResourceName);
            }
            else if (!string.IsNullOrEmpty(requiredAnnotation.ErrorMessage))
            {
                errorMessageFormat = requiredAnnotation.ErrorMessage;
            }
            else
            {
                errorMessageFormat = LocalizationService.GetString("EPiProperties/PropertyRequiredFormat", "Required property '{0}' is not set on the page #{1} of type '{2}'. ");
            }

            var errorMessage = string.Format(errorMessageFormat,
                property.Name,
                page.PageLink.ID,
                page.PageTypeName);

            throw new ApplicationException(errorMessage);
        }
    }
}