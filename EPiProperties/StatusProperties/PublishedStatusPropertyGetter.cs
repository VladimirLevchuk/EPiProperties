﻿using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiServer.Core;
using EPiProperties.Util;
using EPiServer.Filters;

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
            var annotation = property.GetAnnotation<CmsPublishedStatusAttribute>();

            var result = FilterPublished.CheckPublishedStatus((IContent) page, annotation.Status);

            return result;
        }
    }
}
