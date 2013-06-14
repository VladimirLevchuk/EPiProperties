using System;

namespace EPiProperties.StatusProperties.DataAnnotation
{
    public class CmsPagePredicateAttribute : Attribute
    {
        public Type Predicate { get; set; }
    }
}