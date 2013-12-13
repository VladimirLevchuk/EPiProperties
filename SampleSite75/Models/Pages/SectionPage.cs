using System.Collections.Generic;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.DataAnnotations;
using SampleSite.Models.Pages.Base;

namespace SampleSite.Models.Pages
{
    [ContentType(GUID = "{E9E10D4C-79F4-4490-A93C-CD95C0961E6F}")]
    public class SectionPage : ContentPageBase
    {
        [CmsChildren]
        public virtual IEnumerable<FolderPage> Subsections { get; internal set; }
    }
}