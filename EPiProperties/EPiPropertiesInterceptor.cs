using System.Linq;
using Castle.DynamicProxy;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer.Core;

namespace EPiProperties
{
    public class EPiPropertiesInterceptor : IInterceptor
    {
        private readonly IEPiPropertiesRegistry _registry;

        protected virtual IEPiPropertiesRegistry Registry
        {
            get { return _registry; }
        }

        public EPiPropertiesInterceptor(IEPiPropertiesRegistry registry)
        {
            _registry = registry;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            // try to get property info from the current invocation get_ method. 
            var getProperty = invocation.ExtractPropertyInfoByGetMethod();
            if (getProperty != null)
            {
                // if property info found 
                var contentData = invocation.Proxy as IContentData;

                if (contentData != null)
                {
                    // let's lookup getter
                    var propertyGetter = Registry.LookupGetters(getProperty).FirstOrDefault(x => x.CanIntercept(contentData, getProperty));
                    
                    if (propertyGetter != null)
                    {
                        // and if getter is present and can intercept the current call let's get the return value from one. 
                        invocation.ReturnValue = propertyGetter.GetValue(contentData, getProperty);
                    }
                }
            }
        }
    }
}
