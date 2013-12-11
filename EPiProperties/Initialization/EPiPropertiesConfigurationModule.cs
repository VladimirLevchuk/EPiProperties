using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EPiInterceptors;
using EPiProperties.Abstraction;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.ServiceLocation;
using StructureMap;

namespace EPiProperties.Initialization
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class EPiPropertiesConfigurationModule : InterceptionRegistrationInitModuleBase
    {
        public override void ConfigureContainer(ServiceConfigurationContext context)
        {
            base.ConfigureContainer(context);
            RegistryIoC(context.Container);
        }

        public virtual void RegistryIoC(IContainer container)
        {
            container.Configure(x =>
            {
                // x.For<ContentDataInterceptor>().Use<DebugContentDataInterceptor>();
                x.For<ContentDataInterceptorHandler>().Use<ContentDataInterceptorHandlerExtender>().Ctor<Action<IWindsorContainer>>().Is(ConfigureWindsor);
                x.For<EPiPropertiesRegistry>().Singleton().Use<EPiPropertiesRegistry>();
                x.For<IEPiPropertiesRegistry>().Use(() => ServiceLocator.Current.GetInstance<EPiPropertiesRegistry>());
                x.For<EPiPropertiesInterceptor>().Use<EPiPropertiesInterceptor>();
            });            
        }



        public virtual void ConfigureWindsor(IWindsorContainer container)
        {
            container
                .ForwardToServiceLocator<EPiPropertiesInterceptor>()
                .ForwardToServiceLocator<PropertyInterceptionFilter>()
                .ForwardToServiceLocator<IEPiPropertiesRegistry>();
        }

        public override void RegisterContentDataInterceptors(ContentDataInterceptonRegistry registry)
        {
            // registry.InterceptWith<EPiPropertiesInterceptor>();
        }
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