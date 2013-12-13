using System;
using System.Reflection;
using Castle.DynamicProxy;
using EPiProperties.Util;

namespace EPiProperties.Contracts
{
    public abstract class ContentProxyInterceptorSelector : IInterceptorSelector
    {
        public virtual IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var propertyInfo = method.ToPropertyInfo();

            return propertyInfo != null ? SelectPropertyInterceptors(propertyInfo, interceptors) : new IInterceptor[] { };
        }

        public abstract IInterceptor[] SelectPropertyInterceptors(PropertyInfo propertyInfo, IInterceptor[] interceptors);
    }
}