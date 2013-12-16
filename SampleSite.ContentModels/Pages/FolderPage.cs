using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.DataAnnotations;
using SampleSite.ContentModels.Pages.Base;

namespace SampleSite.ContentModels.Pages
{
    [ContentType(GUID = "{440D331D-E6AD-4BFD-93BF-7D0F12DA1DEB}")]
    public class FolderPage : PageBase
    {
        [ScaffoldColumn(false)]
        public virtual string Foo { get; set; }

        [CmsChildren]
        public virtual IEnumerable<ArticlePage> ChildArticles { get; internal set; }
    }
}