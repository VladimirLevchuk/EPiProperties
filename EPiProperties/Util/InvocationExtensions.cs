using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace EPiProperties.Util
{
    static class InvocationExtensions
    {
        static PropertyInfo GetPropertyInfo(IInvocation invocation, string prefix)
        {
            if (invocation == null)
            {
                throw new ArgumentNullException("invocation");
            }
            if (prefix == null)
            {
                throw new ArgumentNullException("prefix");
            }

            var methodName = invocation.Method.Name;

            if (!methodName.StartsWith(prefix))
            {
                return null;
            }

            var propertyName = methodName.Substring(prefix.Length);
            var result = invocation.TargetType.GetProperty(propertyName);
            return result;
        }

        public static PropertyInfo ExtractPropertyInfoByGetMethod(this IInvocation invocation)
        {
            var result = GetPropertyInfo(invocation, "get_");
            return result;
        }

        public static PropertyInfo ExtractPropertyInfoBySetMethod(this IInvocation invocation)
        {
            var result = GetPropertyInfo(invocation, "set_");
            return result;
        }
    }
}