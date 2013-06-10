using System.Collections.Generic;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace SampleSite.Models.Pages.Base
{
    public class PageBase : PageData
    {
        [CmsChildren]
        [Ignore]
        public virtual IEnumerable<ContentPageBase> Children { get; internal set; }
    }
}