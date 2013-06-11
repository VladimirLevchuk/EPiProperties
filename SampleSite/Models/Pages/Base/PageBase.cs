using System.Collections.Generic;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiProperties.StatusProperties.Predicates;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace SampleSite.Models.Pages.Base
{
    public class PageBase : PageData
    {
        [CmsChildren]
        [Ignore]
        public virtual IEnumerable<PageBase> Children { get; set; }

        [CmsParent]
        [Ignore]
        public virtual PageBase Parent { get; set; }

        [CmsPublishedStatus]
        public virtual bool IsPublished { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableForCurrentUser))]
        public virtual bool IsAvailableForCurrentUser { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableInMenu))]
        public virtual bool IsAvailableInMenu { get; internal set; }
    }
}