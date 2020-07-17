using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using SampleApp.Services;
using TestApp.Shared;
using Uno.Disposables;
using Zafiro.Core.UI;

namespace SampleApp.ViewModels
{
    public abstract class SectionViewModel : ReactiveObject, IDisposable
    {
        private readonly ObservableAsPropertyHelper<bool> isBusy;
        private readonly ObservableAsPropertyHelper<List<ItemViewModel>> items;
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public SectionViewModel(IMyService service, IMapper mapper, IDialogService dialogService)
        {
            Fetch = ReactiveCommand.CreateFromObservable(() =>
                Observable.FromAsync(service.GetItems)
                    .Select(list => list.Select(mapper.Map<ItemViewModel>).ToList()));

            Fetch.ShowExceptions(dialogService).DisposeWith(disposables);
            
            isBusy = Fetch.IsExecuting.ToProperty(this, vm => vm.IsBusy);
            items = Fetch.ToProperty(this, vm => vm.Items);

            Fetch.Execute().Catch(Observable.Empty<List<ItemViewModel>>()).Subscribe();
        }

        public bool IsBusy => isBusy.Value;

        public ReactiveCommand<Unit, List<ItemViewModel>> Fetch { get; }

        public List<ItemViewModel> Items => items.Value;

        public void Dispose()
        {
            isBusy?.Dispose();
            items?.Dispose();
            disposables?.Dispose();
            Fetch?.Dispose();
        }
    }
}