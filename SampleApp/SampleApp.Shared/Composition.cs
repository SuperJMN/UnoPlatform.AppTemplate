using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using AutoMapper;
using EasyRpc.DynamicClient;
using EasyRpc.DynamicClient.Grace;
using Grace.DependencyInjection;
using SampleApp.Services;
using SampleApp.ViewModels;
using SampleApp.Views;
using Uno.Extensions;
using Zafiro.Uno.Infrastructure;

namespace SampleApp
{
    public class Composition : CompositionBase
    {
        protected override void ConfigureServices(DependencyInjectionContainer container)
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.ConstructServicesUsing(container.Locate);
                x.CreateMap<Item, ItemViewModel>();
            }).CreateMapper();

            container.Configure(c =>
            {
                c.ExportInstance(mapper).As<IMapper>();
                c.Export<InterfaceNamingConvention>().As<INamingConventionService>();
            });

            var uri = GetServiceUri();

            container.ProxyNamespace(uri, namespaces: typeof(Anchor).Namespace);
        }

        private static string GetServiceUri()
        {
            var port = 61207;
#if __ANDROID__
            var domain = "10.0.2.2";
#else
            var domain = "localhost";
#endif
            return $"http://{domain}:{port}";
        }

        protected override void ConfigureViewModelToViewMaps(IDictionary<Type, Type> map)
        {
            var vmToViewMaps = new Dictionary<Type, Type>
            {
                {typeof(Section1ViewModel), typeof(Section1)},
                {typeof(Section2ViewModel), typeof(Section2)},
                {typeof(Section3ViewModel), typeof(Section3)},
            };
            
            map.AddRange(vmToViewMaps);
        }

        protected override void ConfigureSections(List<Section> mappings)
        {
            var sections = new[]
            {
                new Section("Section 1", typeof(Section1ViewModel)){ Icon = new SymbolIcon(Symbol.Home)},
                new Section("Section 2", typeof(Section2ViewModel)){ Icon = new SymbolIcon(Symbol.Page)},
                new Section("Section 3", typeof(Section3ViewModel)){ Icon = new SymbolIcon(Symbol.Page2)},
            };

            mappings.AddRange(sections);
        }
    }
}