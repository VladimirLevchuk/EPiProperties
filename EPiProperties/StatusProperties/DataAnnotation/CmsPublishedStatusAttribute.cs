using System;
using EPiServer.Core;

namespace EPiProperties.StatusProperties.DataAnnotation
{
    public class CmsPublishedStatusAttribute : Attribute
    {
        private PagePublishedStatus _status = PagePublishedStatus.Published;

        public PagePublishedStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
