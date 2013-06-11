using System;
using System.Reflection;
using Castle.Core.Internal;

namespace EPiProperties.Util
{
    public static class PropertyInfoExtensions
    {
        public static TAttribute GetAnnotation<TAttribute>(this PropertyInfo property) 
            where TAttribute : class
        {
            var result = property.GetAttribute<TAttribute>();

            if (result == null)
            {
                throw new InvalidOperationException(
                    string.Format("Required annotation attribute '{0}' is not found on the property '{1}' of type '{2}'. ",
                        typeof(TAttribute).FullName,
                        property.Name,
                        property.DeclaringType));
            }

            return result;
        }
    }
}