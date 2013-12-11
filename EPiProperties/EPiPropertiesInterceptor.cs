using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EPiProperties.Abstraction;
using EPiProperties.Util;
using EPiServer.Construction;
using EPiServer.Core;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;

namespace EPiProperties
{
    public class ContentDataInterceptorHandlerExtender : ContentDataInterceptorHandler
    {
        public ContentDataInterceptorHandlerExtender(ConstructorParameterResolver constructorResolver, Action<IWindsorContainer> containerConfigurator)
            : base(constructorResolver)
        {
            Validator.ThrowIfNull("containerConfigurator", containerConfigurator);

            var fieldContainer = typeof(ContentDataInterceptorHandler).GetField("_container", BindingFlags.Instance | BindingFlags.NonPublic);

            var container = (IWindsorContainer) fieldContainer.GetValue(this);
            
            containerConfigurator(container);
            Container = container;
        }

        protected virtual IWindsorContainer Container { get; private set; }
    }

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
            Debug.WriteLine("[INTERCEPTION] {0}", invocation.Method.Name);

            if (invocation.Method.Name.Contains("Children"))
            {
                Debugger.Break();
            }
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
