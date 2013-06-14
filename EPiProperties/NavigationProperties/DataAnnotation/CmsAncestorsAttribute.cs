using System;

namespace EPiProperties.NavigationProperties.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CmsAncestorsAttribute : Attribute
    {}
}