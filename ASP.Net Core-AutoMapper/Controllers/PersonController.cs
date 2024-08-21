using ASP.Net_Core_AutoMapper.Models.Binding;
using ASP.Net_Core_AutoMapper.Models.ViewModel;
using ASP.Net_Core_AutoMapper.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_AutoMapper.Controllers
{
    public class PersonController : Controller
    {

        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        public IActionResult ListOfPeople()
        {
            var people = personService.GetAllPeople();
            return View(people);
        }
        public IActionResult PersonDetails(int id)
        {
            var person = personService.GetPersonById(id);
            return View(person);
        }
        public IActionResult AddPerson()
        {
             return View();
        }

        [HttpPost]
        public IActionResult AddPerson(PersonBinding model)
        {
            personService.AddPerson(model);
            return RedirectToAction("ListOfPeople");
        }
        public IActionResult DeletePerson(int id)
        {
            personService.DeletePerson(id);
            return RedirectToAction("ListOfPeople");
        }
        public IActionResult EditPerson(int id)
        {
            var person = personService.GetPersonById(id);
            var model = mapper.Map<PersonUpdateBinding>(person);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPerson(PersonUpdateBinding model)
        {
            personService.EditPerson(model);
            return RedirectToAction("ListOfPeople");
        }
    }
}
