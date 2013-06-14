using EPiServer.Core;

namespace EPiProperties.StatusProperties.Services
{
    public interface ICmsPageService
    {
        bool IsPublished(IContent content);

        bool IsAvailableInMenu(PageData pageData);

        bool IsAvailaibleForCurrentUser(PageData pageData);

        bool IsReadableForCurrentUser(IContent content);

        bool IsVisibleOnSite(PageData content);

        bool HasTemplate(PageData content);
    }
}
