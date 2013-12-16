using System;
using System.Reflection;
using Castle.DynamicProxy;
using EPiProperties.Contracts;
using EPiProperties.Util;
using EPiServer.DataAbstraction.RuntimeModel;

namespace EPiProperties.Infrastructure
{
    public class EPiPropertiesContentDataInterceptorHook : ContentDataInterceptorHook
    {
        protected IEPiPropertiesRegistry EpiPropertiesRegistry { get; set; }
        private readonly IProxyGenerationHook _episerverInternalHook;

        public EPiPropertiesContentDataInterceptorHook(IEPiPropertiesRegistry epiPropertiesRegistry)
        {
            EpiPropertiesRegistry = epiPropertiesRegistry;
            var episerverInternalHookType = typeof(ContentDataInterceptor).Assembly.GetType("EPiServer.DataAbstraction.RuntimeModel.ContentDataInterceptorHook");
            _episerverInternalHook = (IProxyGenerationHook) Activator.CreateInstance(episerverInternalHookType);
        }

        public override bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return _episerverInternalHook.ShouldInterceptMethod(type, methodInfo) || IsEPiProperty(type, methodInfo);
        }

        private bool IsEPiProperty(Type type, MethodInfo methodInfo)
        {
            var propertyInfo = methodInfo.ToPropertyInfo();
            return propertyInfo != null && methodInfo.IsPropertyGetter() && EpiPropertiesRegistry.IsEPiProperty(propertyInfo);
        }
    }
}