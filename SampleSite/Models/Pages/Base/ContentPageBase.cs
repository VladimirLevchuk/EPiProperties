using EPiServer.Core;

namespace SampleSite.Models.Pages.Base
{
    public class ContentPageBase : PageData
    {
        public virtual string Heading { get; set; }

        public virtual string Intro { get; set; }

        public virtual XhtmlString Body { get; set; }
    }
}