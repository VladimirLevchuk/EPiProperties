using EPiProperties.StatusProperties.Services;
using EPiServer.Core;

namespace EPiProperties.StatusProperties.Predicates
{
    /// <summary>
    /// Determines whether the given page is available in menu. 
    /// </summary>
    public class AvailableInMenu : Base.CmsPagePredicateBase
    {
        public AvailableInMenu(ICmsPageService pageService)
            : base(pageService)
        {}

        public override bool Test(PageData page)
        {
            return PageService.IsAvailableInMenu(page);
        }
    }
}