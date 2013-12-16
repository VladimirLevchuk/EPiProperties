using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool HasAnnotation<TAttribute>(this PropertyInfo property)
            where TAttribute : class
        {
            return property.HasAttribute<TAttribute>();
        }

        public static bool AnnotatedWithAnyOf(this PropertyInfo property, IEnumerable<Type> annotationAttributes)
        {
            var actualAttributes = property.GetCustomAttributes(true).Select(x => x.GetType());

            var result = actualAttributes.Intersect(annotationAttributes).Any();
            return result;
        }

        public static bool IsPropertyInfo(this MethodInfo method)
        {
            return method.IsPropertyGetter() || method.IsPropertySetter();
        }

        public static bool IsPropertyGetter(this MethodInfo method)
        {
            return method.IsSpecialName && method.Name.StartsWith("get_", StringComparison.Ordinal);
        }

        public static bool IsPropertySetter(this MethodInfo method)
        {
            return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.Ordinal);
        }

        public static PropertyInfo ToPropertyInfo(this MethodInfo method)
        {
            if (!method.IsPropertyInfo())
            {
                return null;
            }

            var propertyName = method.Name.Substring("?et_".Length);
            var result = method.DeclaringType.GetProperty(propertyName);
            return result;            
        }
    }
}