using System.Reflection;
using EPiProperties.Contracts;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace EPiProperties.OtherProperties
{
    public class FriendlyUrlPropertyGetter : IEPiPropertyGetter
    {
        protected virtual UrlResolver Resolver
        {
            get 
            {
                // I don't use ctor injection here because getters are cached, 
                // but resolver can be dependent from the current request, 
                // so I want to get it every time it's needed
                var result = ServiceLocator.Current.GetInstance<UrlResolver>();
                return result;
            } 
        }

        public bool CanIntercept(IContentData contentData, PropertyInfo property)
        {
            return contentData is PageData;
        }

        public object GetValue(IContentData contentData, PropertyInfo property)
        {
            var page = (PageData) contentData;

            var result = GetFriendlyUrl(page);

            return result;
        }

        private string GetFriendlyUrl(PageData page)
        {
            var result = Resolver.GetUrl(page.PageLink, page.LanguageBranch);
            return result;
        }
    }
}
