using AutoMapper;
using SampleApp.Services;
using Zafiro.UI.Infrastructure.Uno;

namespace SampleApp.ViewModels
{
    public class Section1ViewModel: SectionViewModel
    {
        public Section1ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}