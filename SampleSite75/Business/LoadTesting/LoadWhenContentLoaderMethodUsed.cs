using EPiServer;
using EPiServer.Core;

namespace SampleSite.Business.LoadTesting
{
    public class LoadWhenContentLoaderMethodUsed : LoadWithoutProperties
    {
        public LoadWhenContentLoaderMethodUsed(IContentRepository contentRepository) : base(contentRepository)
        {}

        public override void LoadStep()
        {
            var children = ContentRepository.GetChildren<IContent>(TestRootLink);
        }
    }
}