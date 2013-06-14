using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPiProperties.NavigationProperties.DataAnnotation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CmsChildrenAttribute : Attribute
    {
    }
}
