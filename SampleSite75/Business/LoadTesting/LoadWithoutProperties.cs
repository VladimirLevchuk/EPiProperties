using EPiServer;
using EPiServer.Core;
using SampleSite.ContentModels.Pages.Test;

namespace SampleSite.Business.LoadTesting
{
    public class LoadWithoutProperties : LoadScenario
    {
        public LoadWithoutProperties(IContentRepository contentRepository) : base(contentRepository)
        {}

        protected override PageData CreateTestRoot()
        {
            var result = ContentRepository.GetDefault<PageWithoutEPiProperties>(ContentReference.StartPage);
            return result;
        }

        protected override PageData CreateTestPage(int step)
        {
            var result = ContentRepository.GetDefault<PageWithoutEPiProperties>(TestRootLink);
            return result;
        }

        public override void LoadStep()
        {
            var page = ContentRepository.Get<PageWithoutEPiProperties>(TestRootLink);
        }
    }
}