using System.Collections.Generic;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.DataAnnotations;
using SampleSite.Models.Pages.Base;

namespace SampleSite.Models.Pages
{
    [ContentType(GUID = "{37E9A1AC-BEF3-4B19-969D-D9C618C5CB20}")]
    public class ListPage : ContentPageBase
    {
        [CmsChildren]
        public virtual IEnumerable<ArticlePage> ChildArticles { get; internal set; }
    }
}