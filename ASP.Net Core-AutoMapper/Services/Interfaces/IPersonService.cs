using ASP.Net_Core_AutoMapper.Models.Binding;
using ASP.Net_Core_AutoMapper.Models.ViewModel;

namespace ASP.Net_Core_AutoMapper.Services.Interfaces
{
    public interface IPersonService
    {
        PersonViewModel AddPerson(PersonBinding model);
        bool DeletePerson(int id);
        PersonViewModel EditPerson(PersonUpdateBinding model);
        List<PersonViewModel> GetAllPeople();
        PersonViewModel GetPersonById(int id);
    }
}