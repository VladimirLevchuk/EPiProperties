using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Castle.DynamicProxy;
using EPiProperties.Util;
using EPiServer.Core;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.ServiceLocation;

namespace EPiProperties
{
    public class DebugContentDataInterceptor : ContentDataInterceptor
    {
        private readonly ContentDataInterceptorHandler _contentDataInterceptorHandler;
        
        public DebugContentDataInterceptor() : this(ServiceLocator.Current.GetInstance<ContentDataInterceptorHandler>())
        {
        }

        public DebugContentDataInterceptor(ContentDataInterceptorHandler contentDataInterceptorHandler)
        {
            _contentDataInterceptorHandler = contentDataInterceptorHandler;
        }

        public override void Intercept(IInvocation invocation)
        {
            var getProperty = invocation.ExtractPropertyInfoByGetMethod();
            if (getProperty != null)
            {
                System.Diagnostics.Debug.WriteLine("INTERCEPT: " + getProperty.Name);
            }

            var propertiesInterceptor = ServiceLocator.Current.GetInstance<EPiPropertiesInterceptor>();

            propertiesInterceptor.Intercept(invocation);

            if (invocation.ReturnValue == null)
            {
                base.Intercept(invocation);
            }
        }

        protected override void HandleGetterAccessor(IInvocation invocation, PropertyData propertyData)
        {
            IPropertyDataInterceptor propertyInterceptor = _contentDataInterceptorHandler.GetPropertyInterceptor(propertyData.GetType());
            if (propertyInterceptor != null)
            {
                invocation.ReturnValue = propertyInterceptor.GetValue(propertyData, invocation.Method.ReturnType);
            }
            else if ((propertyData.Value == null) && invocation.Method.ReturnType.IsValueType)
            {
                invocation.ReturnValue = Activator.CreateInstance(invocation.Method.ReturnType);
            }
            else
            {
                invocation.ReturnValue = propertyData.Value;
            }
        }

        protected override void HandleSetterAccessor(IInvocation invocation, PropertyData propertyData)
        {
            IPropertyDataInterceptor propertyInterceptor = _contentDataInterceptorHandler.GetPropertyInterceptor(propertyData.GetType());
            if (propertyInterceptor != null)
            {
                Type parameterType = invocation.Method.GetParameters()[0].ParameterType;
                propertyInterceptor.SetValue(propertyData, parameterType, invocation.Arguments[0]);
            }
            else
            {
                propertyData.Value = invocation.Arguments[0];
            }
        }
    }
}