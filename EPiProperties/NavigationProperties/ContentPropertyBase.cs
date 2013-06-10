using EPiServer;

namespace EPiProperties.NavigationProperties
{
    public abstract class ContentPropertyBase
    {
        private readonly IContentLoader _contentLoader;
        protected virtual IContentLoader ContentLoader { get { return _contentLoader; }}
        protected ContentPropertyBase(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
    }
}