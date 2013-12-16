using System.Reflection;
using EPiProperties.Contracts;
using EPiProperties.Util;
using EPiServer;
using EPiServer.Core;

namespace EPiProperties.NavigationProperties
{
    public class ParentPropertyGetter : Base.ContentPropertyGetterBase, IEPiPropertyGetter
    {
        public ParentPropertyGetter(IContentLoader contentLoader) : base(contentLoader)
        {}

        public bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            // we intercept property if it's declared in a page or shared block. 
            return contentData is IContent;
        }

        public object GetValue(IContentData contentData, PropertyInfo property)
        {
            var content = (IContent) contentData;
            // the type from the property declaration
            var resultType = property.PropertyType;
            // load parent page and cast it to the declaration type
            var result = ContentLoader.Get<IContent>(content.ParentLink).Cast(resultType);

            return result;
        }
    }
}