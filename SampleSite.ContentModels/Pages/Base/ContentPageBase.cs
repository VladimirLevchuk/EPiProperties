﻿using EPiServer.Core;

namespace SampleSite.ContentModels.Pages.Base
{
    public class ContentPageBase : PageBase
    {
        public virtual string Heading { get; set; }

        public virtual string Intro { get; set; }

        public virtual XhtmlString Body { get; set; }
    }
}