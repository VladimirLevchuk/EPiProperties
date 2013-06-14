using System;

namespace EPiProperties.NavigationProperties.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CmsReferenceAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets PageReference field name which defines the reference source. 
        /// $(PropertyName) + Link will be used by default
        /// (i.e. SearchPageLink will be used for property named SearchPage). 
        /// </summary>
        public string LinkFieldName { get; set; }
    }
}