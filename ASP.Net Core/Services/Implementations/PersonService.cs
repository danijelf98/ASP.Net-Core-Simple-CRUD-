using ASP.Net_Core.Models.Base;
using ASP.Net_Core.Models.Binding;
using ASP.Net_Core.Models.Dbo;
using ASP.Net_Core.Models.ViewModel;
using ASP.Net_Core.Services.Interfaces;
using AutoMapper;

namespace ASP.Net_Core.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private static List<Person> people = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Markov",
                Age = 23
            },
            new Person
            {
                Id = 2,
                FirstName = "Darko",
                LastName = "Darko",
                Age = 14
            },
            new Person
            {
                Id = 3,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Age = 47
            }

        };
        private int GenerateId()
        {
            if (!people.Any())
            {
                return 1; // which means, it will start from the beginning if list is empty.
            }
            return people.OrderByDescending(x => x.Id).First().Id;
        }

        /// <summary>
        /// Get all People from the List
        /// </summary>
        /// <returns></returns>
        public List<PersonViewModel> GetAllPeople()
        {
            return people.Select(y => new PersonViewModel
            {
                Id = y.Id,
                FirstName = y.FirstName,
                LastName = y.LastName,
                Age = y.Age
            }).ToList();
        }

        /// <summary>
        /// Get dbo by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonViewModel GetPersonById(int id)
        {
            Person dbo = people.FirstOrDefault(p => p.Id == id);
            return new PersonViewModel { Id = dbo.Id, FirstName = dbo.FirstName, LastName = dbo.LastName, Age = dbo.Age };
        }

        /// <summary>
        /// Add dbo into list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonViewModel AddPerson(PersonBinding model)
        {
            Person dbo = new Person
            {
                Id = GenerateId(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age
            };

            people.Add(dbo);

            return new PersonViewModel { Id = dbo.Id, FirstName = dbo.FirstName, LastName = dbo.LastName, Age = dbo.Age };
        }

        /// <summary>
        /// Edit dbo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonViewModel EditPerson(PersonUpdateBinding model)
        {
            Person dbo = people.FirstOrDefault(x => x.Id == model.Id);

            dbo.FirstName = model.FirstName;
            dbo.LastName = model.LastName;
            dbo.Age = model.Age;

            return new PersonViewModel { Id = dbo.Id, FirstName = dbo.FirstName, LastName = dbo.LastName, Age = dbo.Age };
        }

        /// <summary>
        /// Delete dbo b Id
        /// </summary>
        /// <param name="id"></param>
        public bool DeletePerson(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return false;
            }

            people.Remove(person);
            return true;
        }
    }
}
