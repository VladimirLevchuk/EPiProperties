﻿using EPiInterceptors;
using EPiProperties.Abstraction;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiProperties.Initialization
{
    [ModuleDependency(typeof(ContentDataInterceptionExtendModule))]
    public class EPiPropertiesConfigurationModule : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(x =>
                {
                    x.For<EPiPropertiesRegistry>().Singleton().Use<EPiPropertiesRegistry>();
                    x.For<EPiPropertiesInterceptor>().Singleton().Use<EPiPropertiesInterceptor>();
                    x.For<ContentDataInterceptor>().Use<DebugContentDataInterceptor>();
                });
        }

        public void Initialize(InitializationEngine context)
        {}

        public void Preload(string[] parameters)
        {}

        public void Uninitialize(InitializationEngine context)
        {}
    }
}