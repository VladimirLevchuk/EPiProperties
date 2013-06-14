using System.Reflection;
using EPiProperties.StatusProperties.Services;
using EPiServer.Core;

namespace EPiProperties.StatusProperties.Predicates.Base
{
    public abstract class CmsPagePredicateBase : IPagePredicate
    {
        private readonly ICmsPageService _pageService;
        protected virtual ICmsPageService PageService { get { return _pageService; }}

        protected CmsPagePredicateBase(ICmsPageService pageService)
        {
            _pageService = pageService;
        }

        public abstract bool Test(PageData page);
    }
}