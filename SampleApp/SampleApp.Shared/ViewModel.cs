using System;
using System.Collections.Generic;
using System.Reactive;
using EasyRpc.DynamicClient;
using EasyRpc.DynamicClient.Grace;
using Grace.DependencyInjection;
using ReactiveUI;
using Services;

namespace TestApp
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<List<Item>> items;

        public MainViewModel()
        {
            var container = new DependencyInjectionContainer();
            container.Configure(c =>
            {
                c.Export<InterfaceNamingConvention>().As<INamingConventionService>();
            });

            container.ProxyNamespace("http://localhost:61207", namespaces: typeof(IMyService).Namespace);
            
            var service = container.Locate<IMyService>();
            Fetch = ReactiveCommand.CreateFromTask(() => service.GetItems());
            items = Fetch.ToProperty(this, x => x.Items);
            Fetch.Execute().Subscribe();
        }

        public ReactiveCommand<Unit, List<Item>> Fetch { get; set; }

        public List<Item> Items => items.Value;
    }
}