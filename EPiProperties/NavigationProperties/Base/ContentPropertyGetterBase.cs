using EPiServer;

namespace EPiProperties.NavigationProperties.Base
{
    /// <summary>
    /// Property getter which loads contents using IContentLoader
    /// </summary>
    public abstract class ContentPropertyGetterBase
    {
        private readonly IContentLoader _contentLoader;
        protected virtual IContentLoader ContentLoader { get { return _contentLoader; } }

        protected ContentPropertyGetterBase(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }        
    }
}