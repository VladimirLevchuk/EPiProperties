using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using EPiProperties.Contracts;
using EPiServer.DataAbstraction.RuntimeModel;

namespace EPiProperties.Infrastructure
{
    public class EPiPropertiesInterceptorSelector : ContentProxyInterceptorSelector
    {
        protected IEPiPropertiesRegistry EpiPropertiesRegistry { get; set; }

        public EPiPropertiesInterceptorSelector(IEPiPropertiesRegistry epiPropertiesRegistry)
        {
            EpiPropertiesRegistry = epiPropertiesRegistry;
        }

        public override IInterceptor[] SelectPropertyInterceptors(PropertyInfo propertyInfo, IInterceptor[] interceptors)
        {
            Debug.WriteLine("[EPiProperties] Select interceptor for {0}.{1}", propertyInfo.DeclaringType.FullName, propertyInfo.Name);

            var interceptor = EpiPropertiesRegistry.IsEPiProperty(propertyInfo)
                ? interceptors.FirstOrDefault(x => x.GetType().Is<EPiPropertiesInterceptor>())
                : interceptors.FirstOrDefault(x => x.GetType().Is<ContentDataInterceptor>());
            
            return interceptor != null ?  new [] { interceptor } : new IInterceptor[] {};
        }
    }
}