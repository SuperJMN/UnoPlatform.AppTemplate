using AutoMapper;
using SampleApp.Infrastructure;
using SampleApp.Services;

namespace SampleApp.ViewModels
{
    public class Section1ViewModel: SectionViewModel
    {
        public Section1ViewModel(IMyService service, IMapper mapper, IDialogService dialogService) : base(service, mapper, dialogService)
        {
        }
    }
}