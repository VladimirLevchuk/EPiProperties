using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EPiProperties.Contracts;
using EPiProperties.Infrastructure;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;

namespace EPiProperties.Initialization
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class EPiPropertiesConfigurationModule : IConfigurableModule
    {
        public virtual void ConfigureContainer(ServiceConfigurationContext context)
        {
            RegistryIoC(context.Container);
        }

        public virtual void RegistryIoC(IContainer container)
        {
            container.Configure(x =>
            {
                // EPiProperties related
                x.For<EPiPropertiesRegistry>().Singleton().Use<EPiPropertiesRegistry>();
                x.For<IEPiPropertiesRegistry>().Use(() => ServiceLocator.Current.GetInstance<EPiPropertiesRegistry>());
                x.For<EPiPropertiesInterceptor>().Use<EPiPropertiesInterceptor>();

                // ContentDataInterceptorHandler to be overriden to allow customize interception logic and configure windsor container
                x.For<ContentDataInterceptorHandler>().Use<ContentDataInterceptorHandlerExtender>().Ctor<Action<IWindsorContainer>>().Is(ConfigureWindsor);

                // ContentScannerExtension filters out EPiProperties from content type syncronization mechanism
                x.For<ContentScannerExtension>().Use<EPiPropertiesCustomContentScannerExtension>();

                // Hook is called once when gen­er­at­ing proxy type, to filter out properties we can intercept 
                x.For<ContentDataInterceptorHook>().Singleton().Use<EPiPropertiesContentDataInterceptorHook>();
                // and selector works for each generated proxy instance
                x.For<ContentProxyInterceptorSelector>().Singleton().Use<EPiPropertiesInterceptorSelector>();
            });            
        }

        public virtual void ConfigureWindsor(IWindsorContainer container)
        {
            container
                .ForwardToServiceLocator<EPiPropertiesInterceptor>()
                .ForwardToServiceLocator<PropertyInterceptionFilter>()
                .ForwardToServiceLocator<IEPiPropertiesRegistry>();
        }

        public void Initialize(InitializationEngine context)
        {}

        public void Uninitialize(InitializationEngine context)
        {}

        public void Preload(string[] parameters)
        {}
    }

    public static class WindsorToServiceLocatorExtensions
    {
        public static IWindsorContainer ForwardToServiceLocator<TContract>(this IWindsorContainer container) where TContract : class
        {
            return container.Register(Component.For<TContract>().UsingFactoryMethod(
                () => ServiceLocator.Current.GetInstance<TContract>()));
        }
    }
}