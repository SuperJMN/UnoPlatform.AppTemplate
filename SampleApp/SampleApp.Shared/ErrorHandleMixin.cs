using System;
using System.Reactive.Linq;
using ReactiveUI;
using Zafiro.Core.UI;

namespace TestApp.Shared
{
    public static class ErrorHandleMixin
    {
        public static IDisposable ShowExceptions<TInput, TOutput>(this ReactiveCommand<TInput, TOutput> command, IDialogService dialogService)
        {
            return command.ThrownExceptions.SelectMany(exception =>
            {
                return Observable.FromAsync(() => dialogService.Notice("An error has occurred", exception.Message));
            }).Subscribe();
        }
    }
}
