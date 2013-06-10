using Castle.DynamicProxy;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer.Core;

namespace EPiProperties
{
    public class EPiPropertiesInterceptor : IInterceptor
    {
        private readonly EPiPropertiesRegistry _registry;

        protected virtual EPiPropertiesRegistry Registry
        {
            get { return _registry; }
        }
        
        public EPiPropertiesInterceptor(EPiPropertiesRegistry registry)
        {
            _registry = registry;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            // try to get property info from the current invocation get_ method. 
            var getProperty = invocation.ExtractPropertyInfoByGetMethod();
            if (getProperty != null)
            {
                // if property info found let's lookup getter
                var propertyGetter = Registry.LookupGetter(getProperty);

                var @object = invocation.Proxy as PageData;

                if (@object != null 
                    && propertyGetter != null 
                    && propertyGetter.CanIntercept(@object, getProperty))
                {
                    // and if getter is present and can intercept the current call let's get the return value from one. 
                    invocation.ReturnValue = propertyGetter.GetValue(@object, getProperty);
                }
            }
        }
    }
}
