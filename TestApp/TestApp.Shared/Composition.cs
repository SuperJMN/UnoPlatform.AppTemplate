using System;
using System.Collections.Generic;
using System.Text;
using EasyRpc.DynamicClient;
using EasyRpc.DynamicClient.Grace;
using Grace.DependencyInjection;
using Services;

namespace TestApp
{
    class Composition
    {
        public Composition()
        {
            var container = new DependencyInjectionContainer();
            container.Configure(c =>
            {
                c.Export<InterfaceNamingConvention>().As<INamingConventionService>();
            });

            container.ProxyNamespace("http://localhost:61207", namespaces: typeof(IMyService).Namespace);

            Root = container.Locate<MainViewModel>();
        }

        public MainViewModel Root { get; set; }
    }
}
