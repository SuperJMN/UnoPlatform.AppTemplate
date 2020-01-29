using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AutoMapper;
using ReactiveUI;
using SampleApp.Infrastructure;
using SampleApp.Services;
using Uno.Disposables;

namespace SampleApp.ViewModels
{
    public class SampleSectionViewModel : ReactiveObject, IDisposable
    {
        private readonly ObservableAsPropertyHelper<bool> isBusy;
        private readonly ObservableAsPropertyHelper<List<ItemViewModel>> items;
        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public SampleSectionViewModel(IMyService service, IMapper mapper, IDialogService dialogService)
        {
            Fetch = ReactiveCommand.CreateFromObservable(() =>
                Observable.FromAsync(service.GetItems)
                    .Select(list => list.Select(mapper.Map<ItemViewModel>).ToList()));

            ShowError = ReactiveCommand.CreateFromTask<Exception>(e => dialogService.Show("Error", $"There has been an error while fetching data from the service."));
            Fetch.ThrownExceptions.InvokeCommand(ShowError);
            
            isBusy = Fetch.IsExecuting.ToProperty(this, vm => vm.IsBusy);
            items = Fetch.ToProperty(this, vm => vm.Items);

            Fetch.Execute().Catch(Observable.Return(Enumerable.Empty<ItemViewModel>())).Subscribe();
        }

        public ReactiveCommand<Exception, Unit> ShowError { get; set; }

        public bool IsBusy => isBusy.Value;

        public ReactiveCommand<Unit, List<ItemViewModel>> Fetch { get; }

        public List<ItemViewModel> Items => items.Value;

        public void Dispose()
        {
            isBusy?.Dispose();
            items?.Dispose();
            disposables?.Dispose();
            ShowError?.Dispose();
            Fetch?.Dispose();
        }
    }
}