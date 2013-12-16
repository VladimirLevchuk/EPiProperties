using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.DataAnnotations;
using SampleSite.ContentModels.Pages.Base;

namespace SampleSite.ContentModels.Pages
{
    [ContentType(GUID = "{D45D87F2-E22E-4402-8F6D-7F72559C71F4}")]
    public class ArticlePage : ContentPageBase
    {
        [CmsParent]
        public virtual ListPage ParentList { get; internal  set; }
    }
}