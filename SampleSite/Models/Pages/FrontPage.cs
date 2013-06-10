using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using SampleSite.Models.Pages.Base;

namespace SampleSite.Models.Pages
{
    [ContentType(GUID = "{63302A4D-7577-4258-A519-38567F1EE3E0}")]
    public class FrontPage : Base.PageBase
    {
        [CmsChildren]
        public virtual IEnumerable<ContentPageBase> Children { get; internal set; }
    }
}