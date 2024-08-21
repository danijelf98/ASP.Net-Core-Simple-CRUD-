using ASP.Net_Core.Models.Binding;
using ASP.Net_Core.Models.ViewModel;

namespace ASP.Net_Core.Services.Interfaces
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