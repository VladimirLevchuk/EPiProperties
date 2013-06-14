﻿using System.Collections.Generic;
using EPiProperties.NavigationProperties.DataAnnotation;
using EPiProperties.StatusProperties.DataAnnotation;
using EPiProperties.StatusProperties.Predicates;
using EPiServer.Core;

namespace SampleSite.Models.Pages.Base
{
    public class PageBase : PageData
    {
        [CmsChildren]
        public virtual IEnumerable<PageBase> Children { get; internal set; }

        [CmsParent]
        public virtual PageBase Parent { get; internal set; }

        [CmsPublishedStatus]
        public virtual bool IsPublished { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableForCurrentUser))]
        public virtual bool IsAvailableForCurrentUser { get; internal set; }

        [CmsPagePredicate(Predicate = typeof(AvailableInMenu))]
        public virtual bool IsAvailableInMenu { get; internal set; }

        [CmsAncestors]
        public virtual IEnumerable<PageBase> Ancestors { get; internal set; }

        [CmsDescendants]
        public virtual IEnumerable<PageBase> DescendentPages { get; internal set; }

        [CmsDescendants]
        public virtual IEnumerable<ContentReference> Descendents { get; internal set; }
    }
}