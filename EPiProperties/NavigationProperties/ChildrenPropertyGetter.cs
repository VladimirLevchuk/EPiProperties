using System;
using System.Reflection;
using EPiProperties.NavigationProperties.Base;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ChildrenPropertyGetter : CollectionContentPropertyGetterBase
    {
        public ChildrenPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public override object GetValue(IContent content, PropertyInfo property, Type collectionItemType)
        {
            var result = GetPagesCollection(
                () => ContentLoader.GetChildren<IContent>(content.ContentLink), 
                collectionItemType);

            return result;
        }
    }
}