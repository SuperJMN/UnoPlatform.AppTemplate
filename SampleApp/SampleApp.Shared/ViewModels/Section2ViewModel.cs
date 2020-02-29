using AutoMapper;
using SampleApp.Infrastructure;
using SampleApp.Services;

namespace SampleApp.ViewModels
{
    public class Section2ViewModel : SectionViewModel
    {
        public Section2ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}