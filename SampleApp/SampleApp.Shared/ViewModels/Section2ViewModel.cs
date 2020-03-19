using AutoMapper;
using SampleApp.Services;
using Zafiro.UI.Infrastructure.Uno;

namespace SampleApp.ViewModels
{
    public class Section2ViewModel : SectionViewModel
    {
        public Section2ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}