using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer.Core;

namespace EPiProperties
{
    public class EPiPropertiesInterceptor : IInterceptor
    {
        private readonly IEPiPropertiesRegistry _registry;
        private readonly PropertyInterceptionFilter _filter;

        protected virtual IEPiPropertiesRegistry Registry
        {
            get { return _registry; }
        }

        public EPiPropertiesInterceptor(IEPiPropertiesRegistry registry, PropertyInterceptionFilter filter)
        {
            _registry = registry;
            _filter = filter;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            // try to get property info from the current invocation get_ method. 
            var getProperty = invocation.ExtractPropertyInfoByGetMethod();
            if (getProperty != null && !_filter.NeverIntercept(getProperty))
            {
                // if property info found 
                var contentData = invocation.Proxy as IContentData;

                // let's filter out properties from EPiServer library

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

    public class PropertyInterceptionFilter
    {
        public virtual bool NeverIntercept(PropertyInfo property)
        {
            var result = property.DeclaringType.AssemblyQualifiedName.ToLower().StartsWith("EPiServer".ToLower());
            return result;
        }
    }
}
