using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Security;

namespace EPiProperties.StatusProperties.Services
{
    public class CmsPageService : ICmsPageService
    {
        public virtual bool IsAvailableInMenu(PageData pageData)
        {
            return pageData.VisibleInMenu && IsVisibleOnSite(pageData);
        }

        public virtual bool IsAvailaibleForCurrentUser(PageData pageData)
        {
            return IsPublished(pageData) && IsReadableForCurrentUser(pageData) && IsVisibleOnSite(pageData);
        }

        public virtual bool IsReadableForCurrentUser(IContent content)
        {
            var result = FilterAccess.QueryDistinctAccessEdit(content, AccessLevel.Read);
            return result;
        }

        public virtual bool IsVisibleOnSite(PageData content)
        {
            return content.IsVisibleOnSite();
        }

        public virtual bool HasTemplate(PageData content)
        {
            return content.HasTemplate();
        }

        public virtual bool IsPublished(IContent content)
        {
            var result = FilterPublished.CheckPublishedStatus(content, PagePublishedStatus.Published);
            return result;
        }
    }
}