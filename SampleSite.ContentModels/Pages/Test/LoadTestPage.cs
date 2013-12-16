using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace SampleSite.ContentModels.Pages.Test
{
    [ContentType(GUID = "{838F72EC-C2EE-464A-9F89-C511BFD6D270}")]
    public class LoadTestPage : PageData
    {
        public virtual int Steps { get; set; }

        public virtual int PagesCount { get; set; }

        public override void SetDefaultValues(EPiServer.DataAbstraction.ContentType contentType)
        {
            Steps = 100;
            PagesCount = 100;

            base.SetDefaultValues(contentType);
        }
    }
}