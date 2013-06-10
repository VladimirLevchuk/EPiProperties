using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ChildrenPropertyGetter : ContentPropertyBase, IEPiPropertyGetter
    {
        public ChildrenPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public virtual object GetValue(PageData page, PropertyInfo property)
        {
            var itemType = property.DeclaringType.TryGetCollectionItemType();
            if (itemType == null)
            {
                throw new InvalidOperationException("Unsupported property type " + (property.DeclaringType != null ? property.DeclaringType.FullName : "<null>"));
            }

            var resultType = typeof(List<>).MakeGenericType(itemType);
            var result = (IList) Activator.CreateInstance(resultType);
            
            var children = ContentLoader.GetChildren<PageData>(page.PageLink);
           
            foreach (var child in children.Select(x => x.Cast(resultType)).Where(child => child != null))
            {
                result.Add(child);
            }

            return result;
        }

        public virtual bool CanIntercept(PageData page, PropertyInfo property)
        {
            var propertyType = property.DeclaringType;

            var itemType = propertyType.TryGetCollectionItemType();

            return itemType != null && itemType.Is<PageData>();
        }
    }
}