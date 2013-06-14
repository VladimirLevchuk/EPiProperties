using System;
using System.Reflection;
using EPiProperties.NavigationProperties.Base;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;
using System.Linq;

namespace EPiProperties.NavigationProperties
{
    public class DescendentsPropertyGetter : CollectionContentPropertyGetterBase
    {
        public DescendentsPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public override object GetValue(IContent content, PropertyInfo property, Type collectionItemType)
        {
            // Let's support both Pages and ContentReference collections
            bool returnReferences = collectionItemType.Is<ContentReference>();

            var descendents = ContentLoader.GetDescendents(content.ContentLink);

            var result = returnReferences
                ? descendents.ToList()
                : GetPagesCollection(() => descendents, collectionItemType);

            return result;
        }
    }
}