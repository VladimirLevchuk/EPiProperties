using EPiProperties.StatusProperties.Services;
using EPiServer.Core;

namespace EPiProperties.StatusProperties.Predicates
{
    /// <summary>
    /// Determines whether the given page is available for the current user. 
    /// </summary>
    public class AvailableForCurrentUser : Base.CmsPagePredicateBase
    {
        public AvailableForCurrentUser(ICmsPageService pageService) : base(pageService)
        {}

        public override bool Test(PageData page)
        {
            return PageService.IsAvailaibleForCurrentUser(page);
        }
    }
}
