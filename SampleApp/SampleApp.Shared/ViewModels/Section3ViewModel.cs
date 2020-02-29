using AutoMapper;
using SampleApp.Infrastructure;
using SampleApp.Services;

namespace SampleApp.ViewModels
{
    public class Section3ViewModel : SectionViewModel
    {
        public Section3ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}