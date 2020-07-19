using AutoMapper;
using SampleApp.Services;
using Zafiro.Core.UI;

namespace SampleApp.ViewModels
{
    public class Section2ViewModel : SectionViewModel
    {
        public Section2ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}