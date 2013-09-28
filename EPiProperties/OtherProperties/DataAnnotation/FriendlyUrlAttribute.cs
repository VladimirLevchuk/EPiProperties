using System;

namespace EPiProperties.OtherProperties.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FriendlyUrlAttribute : Attribute
    {
    }
}
