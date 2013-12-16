using System.ComponentModel.DataAnnotations;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using SampleSite.ContentModels.Blocks;
using SampleSite.ContentModels.Pages.Base;

namespace SampleSite.ContentModels.Pages
{
    [ContentType(GUID = "{63302A4D-7577-4258-A519-38567F1EE3E0}")]
    public class FrontPage : PageBase
    {
        public virtual PageReference SearchPageLink { get; set; }

        public virtual PageReference MainListReference { get; set; }

        [CmsReference]
        [Required]
        public virtual SearchPage SearchPage { get; internal set; }

        [CmsReference(LinkFieldName = "MainListReference")]
        public virtual ListPage MainList { get; internal set; }

        public virtual CarouselContent FrontCarousel { get; set; }
    }
}