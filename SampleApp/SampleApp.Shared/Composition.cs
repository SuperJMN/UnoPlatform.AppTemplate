using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using AutoMapper;
using EasyRpc.DynamicClient;
using EasyRpc.DynamicClient.Grace;
using Grace.DependencyInjection;
using SampleApp.Infrastructure;
using SampleApp.Services;
using SampleApp.ViewModels;
using SampleApp.Views;
using Uno.Extensions;

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

            container.ProxyNamespace("http://localhost:61207", namespaces: typeof(Anchor).Namespace);
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