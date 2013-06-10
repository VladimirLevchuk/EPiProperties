using System;
using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ParentPropertyGetter : ContentPropertyBase, IEPiPropertyGetter
    {
        public ParentPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public bool CanIntercept(PageData page, PropertyInfo property)
        {
            return property.DeclaringType.Is<PageData>();
        }

        public object GetValue(PageData page, PropertyInfo property)
        {
            var resultType = property.DeclaringType;
            var result = ContentLoader.Get<PageData>(page.ParentLink).Cast(resultType);
            return result;
        }
    }
}