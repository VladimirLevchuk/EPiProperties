using System;
using System.Reflection;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class AncestorsPropertyGetter : Base.CollectionContentPropertyGetterBase
    {
        public AncestorsPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public override object GetValue(IContent content, PropertyInfo property, Type collectionItemType)
        {
            var result = GetPagesCollection(
                () => ContentLoader.GetAncestors(content.ContentLink),
                collectionItemType);

            return result;
        }
    }
}