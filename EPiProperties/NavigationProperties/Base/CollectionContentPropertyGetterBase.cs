using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiProperties.Contracts;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties.Base
{
    /// <summary>
    /// Content property getter which helps to work with collection properties. 
    /// </summary>
    public abstract class CollectionContentPropertyGetterBase : ContentPropertyGetterBase, IEPiPropertyGetter
    {
        protected CollectionContentPropertyGetterBase(IContentLoader contentLoader) : base(contentLoader)
        {}

        protected virtual IList CreateResultCollection(Type itemType)
        {
            // create a new List<ItemType> to represent the results. 
            var resultType = typeof(List<>).MakeGenericType(itemType);
            var result = (IList)Activator.CreateInstance(resultType);

            return result;
        }

        protected virtual IList GetPagesCollection(Func<IEnumerable<IContent>> retrieveMethod, Type itemType)
        {
            var result = CreateResultCollection(itemType);

            foreach (var page in retrieveMethod().Select(page => page.Cast(itemType)).Where(x => x != null))
            {
                result.Add(page);
            }

            return result;
        }

        protected virtual IList GetPagesCollection(Func<IEnumerable<ContentReference>> retrieveMethod, 
            Type itemType)
        {
            Func<IEnumerable<IContent>> loadPages = () => retrieveMethod().Select(x => ContentLoader.Get<IContent>(x));

            var result = GetPagesCollection(loadPages, itemType);
            return result;
        }

        public virtual bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            var content = contentData as IContent;
            // extract collection item type from it (i.e. for property type IEnumerable<ArticlePage> we'll extract ArticlePage type)
            var collectionItemType = property.PropertyType.TryGetCollectionItemType();

            return content != null && collectionItemType != null && CanIntercept(content, property, collectionItemType);
        }

        public virtual object GetValue(IContentData contentData, PropertyInfo property)
        {
            var collectionItemType = property.PropertyType.TryGetCollectionItemType();

            return GetValue((IContent) contentData, property, collectionItemType);
        }

        public virtual bool CanIntercept(IContent content, PropertyInfo property, Type collectionItemType)
        {
            return true;
        }

        public abstract object GetValue(IContent content, PropertyInfo property, Type collectionItemType);
    }
}