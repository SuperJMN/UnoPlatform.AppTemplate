using AutoMapper;
using SampleApp.Services;
using Zafiro.Core.UI;

namespace SampleApp.ViewModels
{
    public class Section3ViewModel : SectionViewModel
    {
        public Section3ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}