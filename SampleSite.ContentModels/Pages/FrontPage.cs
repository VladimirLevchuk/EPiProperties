using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using EPiProperties;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using SampleSite.Models.Blocks;

namespace SampleSite.Models.Pages
{
    [ContentType(GUID = "{63302A4D-7577-4258-A519-38567F1EE3E0}")]
    public class FrontPage : Base.PageBase
    {
        public virtual PageReference SearchPageLink { get; set; }

        public virtual PageReference MainListReference { get; set; }

        [CmsReference]
        [Required]
        public virtual SearchPage SearchPage { get; internal set; }

        [CmsReference(LinkFieldName = "MainListReference")]
        public virtual ListPage MainList { get; internal set; }

        public virtual CarouselContent FrontCarousel { get; set; }
    }
}