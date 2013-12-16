using System;
using EPiServer;

namespace SampleSite.Business.LoadTesting
{
    public class LoadEPiPropertiesChildren : LoadWhenPropertiesNotUsed
    {
        public LoadEPiPropertiesChildren(IContentRepository contentRepository) : base(contentRepository)
        {}

        public override void LoadStep()
        {
            var children = ListPage.Children;
        }
    }
}