using System.Reflection;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ParentPropertyGetter : IEPiPropertyGetter
    {
        private readonly IContentLoader _contentLoader;
        protected virtual IContentLoader ContentLoader { get { return _contentLoader; } }

        public ParentPropertyGetter(IContentLoader contentLoader)
        {
            // inject content loader here
            _contentLoader = contentLoader;
        }

        public bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            // we intercept property if it's declared with any PageData descendant. 
            return contentData is IContent && property.PropertyType.Is<PageData>();
        }

        public object GetValue(IContentData contentData, PropertyInfo property)
        {
            var content = (IContent) contentData;
            // the type from the property declaration
            var resultType = property.PropertyType;
            // load parent page and cast it to the declaration type
            var result = ContentLoader.Get<PageData>(content.ParentLink).Cast(resultType);
            return result;
        }
    }
}