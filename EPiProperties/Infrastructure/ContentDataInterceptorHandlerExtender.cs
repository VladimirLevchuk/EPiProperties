using System;
using System.Reflection;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EPiProperties.Contracts;
using EPiServer.Construction;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.ServiceLocation;

namespace EPiProperties.Infrastructure
{
    public class ContentDataInterceptorHandlerExtender : ContentDataInterceptorHandler
    {
        protected ContentProxyInterceptorSelector InterceptorSelector { get; set; }
        private MethodInfo _methodIsInterceptableType;
        protected virtual object SyncRoot
        {
            get;
            private set;
        }

        public ContentDataInterceptorHandlerExtender(ConstructorParameterResolver constructorResolver, 
            ContentProxyInterceptorSelector interceptorSelector,
            Action<IWindsorContainer> containerConfigurator)
            : base(constructorResolver)
        {
            InterceptorSelector = interceptorSelector;
            Validator.ThrowIfNull("containerConfigurator", containerConfigurator);

            var fieldContainer = typeof(ContentDataInterceptorHandler).GetField("_container", BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldSyncObject = typeof(ContentDataInterceptorHandler).GetField("_syncObject", BindingFlags.NonPublic | BindingFlags.Static);

            var container = (IWindsorContainer)fieldContainer.GetValue(this);
            _methodIsInterceptableType = typeof(ContentDataInterceptorHandler).Assembly.GetType("EPiServer.DataAbstraction.RuntimeModel.TypeExtensions").GetMethod("IsInterceptableType");

            SyncRoot = fieldSyncObject.GetValue(null);


            containerConfigurator(container);
            Container = container;
        }

        protected virtual IWindsorContainer Container { get; private set; }

        public virtual bool IsInterceptableType(Type t)
        {
            var result = (bool)_methodIsInterceptableType.Invoke(null, new object[] { t });
            return result;
        }

        public override void RegisterInterceptor(Type modelType, ContentDataInterceptor interceptor)
        {
            Validator.ThrowIfNull("type", (object)modelType);
            Validator.ThrowIfNull("interceptor", (object)interceptor);

            lock (SyncRoot)
            {
                if (IsInterceptableType(modelType))
                {
                    var interceptorType = interceptor.GetType();
                    string interceptorReferenceKey = interceptorType.Name + modelType.AssemblyQualifiedName;

                    if (!Container.Kernel.HasComponent(interceptorReferenceKey))
                    {
                        Container.Register(
                            Component.For<IInterceptor>().ImplementedBy(interceptorType).LifeStyle.Singleton.Named(interceptorReferenceKey));
                    }

                    if (!Container.Kernel.HasComponent(modelType))
                    {
                        Container.Register(
                            Component
                                .For(modelType)
                                .ImplementedBy(modelType)
                                .LifeStyle.Transient
                                .Interceptors(
                                    InterceptorReference.ForKey(interceptorReferenceKey),
                                    InterceptorReference.ForType<EPiPropertiesInterceptor>())
                                .SelectedWith(InterceptorSelector)
                                .Anywhere
                                .Proxy.Hook(ServiceLocator.Current.GetInstance<ContentDataInterceptorHook>()
                                ) /* !!! */                            
                        );
                    }
                }
                else
                {
                    if (!Container.Kernel.HasComponent(modelType))
                    {
                        Container.Register(Component.For(modelType).ImplementedBy(modelType).LifeStyle.Transient);
                    }
                }
                
                RegisterPropertyInterceptor();
            }
        }
    }
}
