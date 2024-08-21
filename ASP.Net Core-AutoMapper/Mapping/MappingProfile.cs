using ASP.Net_Core_AutoMapper.Models.Binding;
using ASP.Net_Core_AutoMapper.Models.Dbo;
using ASP.Net_Core_AutoMapper.Models.ViewModel;
using AutoMapper;

namespace ASP.Net_Core_AutoMapper.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonBinding, Person>();
            CreateMap<PersonUpdateBinding, Person>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, PersonUpdateBinding>();
        }
    }
}
