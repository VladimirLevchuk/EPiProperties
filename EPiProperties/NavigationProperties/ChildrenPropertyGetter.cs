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
    public class ChildrenPropertyGetter : IEPiPropertyGetter
    {
        private readonly IContentLoader _contentLoader;
        protected virtual IContentLoader ContentLoader { get { return _contentLoader; } }

        public ChildrenPropertyGetter(IContentLoader contentLoader)
        {
            // simple constructor injection
            _contentLoader = contentLoader;
        }

        public virtual bool CanIntercept(PageData page, PropertyInfo property)
        {
            // get property type
            var propertyType = property.PropertyType;

            // extract collection item type from it (i.e. for property type IEnumerable<ArticlePage> we'll extract ArticlePage type)
            var itemType = propertyType.TryGetCollectionItemType();
            
            // we handle this property if it's a collection with item type derived from PageData
            return itemType != null && itemType.Is<PageData>();
        }

        public virtual object GetValue(PageData page, PropertyInfo property)
        {
            // get the collection item type. 
            var itemType = property.PropertyType.TryGetCollectionItemType();
            if (itemType == null)
            {
                throw new InvalidOperationException("Unsupported property type " + property.PropertyType.FullName);
            }

            // create a new List<ItemType> to represent the results. 
            var resultType = typeof(List<>).MakeGenericType(itemType);
            var result = (IList) Activator.CreateInstance(resultType);
            
            // get the current page children as PageData
            var children = ContentLoader.GetChildren<PageData>(page.PageLink);

            // and filter them by our ItemType (same as children.OfType<ItemType>())
            foreach (var child in children.Select(x => x.Cast(itemType)).Where(child => child != null))
            {
                result.Add(child);
            }

            return result;
        }
    }
}