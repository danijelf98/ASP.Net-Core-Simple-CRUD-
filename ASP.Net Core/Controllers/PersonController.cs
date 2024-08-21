using ASP.Net_Core.Models.Binding;
using ASP.Net_Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public IActionResult ListOfPeople()
        {
            var people = personService.GetAllPeople();
            return View(people);
        }
        public IActionResult PersonDetails(int id)
        {
            var people = personService.GetPersonById(id);
            return View(people);
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
            var dbo = personService.GetPersonById(id);
            var model = new PersonUpdateBinding()
            {
                Id = id,
                FirstName = dbo.FirstName,
                LastName = dbo.LastName,
                Age = dbo.Age
            };
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
