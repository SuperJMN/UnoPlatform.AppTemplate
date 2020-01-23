using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Services;

namespace TestApp
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<List<Item>> items;

        public MainViewModel(IMyService service)
        {
            Fetch = ReactiveCommand.CreateFromTask(() => service.GetItems());
            items = Fetch.ToProperty(this, x => x.Items);
            Fetch.Execute().Subscribe();
        }

        public ReactiveCommand<Unit, List<Item>> Fetch { get; set; }

        public List<Item> Items => items.Value;
    }
}