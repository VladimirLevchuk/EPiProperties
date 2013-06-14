using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace SampleSite.Models.Pages.Test
{
    [ContentType(GUID = "{01B82D63-BF0D-4D8F-B3A7-FBC81CAC4EF2}")]
    public class PageWithoutEPiProperties : PageData
    {
        public virtual string Title { get; set; }
    }
}