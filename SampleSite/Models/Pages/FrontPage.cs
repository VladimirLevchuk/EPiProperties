using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace SampleSite.Models.Pages
{
    [ContentType(GUID = "{63302A4D-7577-4258-A519-38567F1EE3E0}")]
    public class FrontPage : Base.PageBase
    {
        public virtual PageReference SearchPageLink { get; set; }

        public virtual PageReference MainListReference { get; set; }

        [CmsReference]
        public virtual SearchPage SearchPage { get; internal set; }

        [CmsReference(LinkFieldName = "MainListReference")]
        public virtual ListPage MainList { get; internal set; }
    }
}