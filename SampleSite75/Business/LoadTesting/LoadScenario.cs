using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;

namespace SampleSite.Business.LoadTesting
{
    public abstract class LoadScenario
    {
        protected LoadScenario(IContentRepository contentRepository)
        {
            ContentRepository = contentRepository;
        }

        public virtual int Pages { get; set; }

        protected virtual IContentRepository ContentRepository { get; private set; }

        protected ContentReference TestRootLink { get; private set; }

        public virtual void Startup()
        {
            var root = CreateTestRoot();
            if (string.IsNullOrEmpty(root.PageName))
            {
                root.PageName = "Test Root";
            }

            TestRootLink = ContentRepository.Save(root, SaveAction.Publish);

            for (int i = 1; i <= Pages; ++i)
            {
                var newPage = CreateTestPage(i);
                newPage.PageName = "Test Page " + i.ToString();
                ContentRepository.Save(newPage, SaveAction.Publish);
            }
        }

        protected abstract PageData CreateTestRoot();

        protected abstract PageData CreateTestPage(int step);

        public virtual void Cleanup()
        {
            ContentRepository.DeleteChildren(TestRootLink, true, AccessLevel.NoAccess);
            ContentRepository.Delete(TestRootLink, true);            
        }

        public virtual void BeforeEachLoad()
        {
            // entry point to clear cache etc. 
        }


        public virtual void AfterEachLoad()
        {}

        public abstract void LoadStep();
    }
}