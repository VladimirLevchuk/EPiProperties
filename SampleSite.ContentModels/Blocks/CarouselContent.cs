using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using SampleSite.ContentModels.Pages.Base;

namespace SampleSite.ContentModels.Blocks
{
    [ContentType(DisplayName = "CarouselContent", GUID = "63bf5dbc-5acc-4f36-b648-d735f5e5a6c5")]
    public class CarouselContent : BlockData
    {
        public virtual PageReference CarouselRootLink { get; set; }

        [CmsReference]
        public virtual PageBase CarouselRoot { get; internal set; }
    }
}