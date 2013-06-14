using EPiServer;
using EPiServer.Core;
using SampleSite.Models.Pages;

namespace SampleSite.Business.LoadTesting
{
    public class LoadWhenPropertiesNotUsed : LoadScenario
    {
        public LoadWhenPropertiesNotUsed(IContentRepository contentRepository) : base(contentRepository)
        {}

        protected ListPage ListPage { get; private set; }

        public override void LoadStep()
        {
            var page = ContentRepository.Get<ListPage>(TestRootLink);
        }

        protected override PageData CreateTestRoot()
        {
            ListPage = ContentRepository.GetDefault<ListPage>(ContentReference.StartPage);
            return ListPage;
        }

        protected override PageData CreateTestPage(int step)
        {
            var result = ContentRepository.GetDefault<ArticlePage>(TestRootLink);
            return result;
        }
    }
}