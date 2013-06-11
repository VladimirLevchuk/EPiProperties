using EPiProperties.Util;
using EPiServer.Core;
using NUnit.Framework;
using SampleSite.Models.Pages;
using FluentAssertions;

namespace EPiProperties.Tests
{
    public class ObjectExtensionTests
    {
        [Test]
        public void Cast_CastsPageTypeToPageData()
        {
            var article = new ArticlePage();

            var pageData = article.Cast(typeof(PageData));

            pageData.Should().BeAssignableTo<PageData>();
        }

        [Test]
        public void Cast_CalledWithNonPageType_ReturnsNull()
        {
            var block = new BlockData();

            var pageData = block.Cast(typeof(PageData));

            pageData.Should().BeNull();
        }
    }
}
