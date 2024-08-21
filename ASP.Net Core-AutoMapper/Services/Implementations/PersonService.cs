using ASP.Net_Core_AutoMapper.Models.Binding;
using ASP.Net_Core_AutoMapper.Models.Dbo;
using ASP.Net_Core_AutoMapper.Models.ViewModel;
using ASP.Net_Core_AutoMapper.Services.Interfaces;
using AutoMapper;

namespace ASP.Net_Core_AutoMapper.Services.Implementations
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
        private readonly IMapper mapper;

        public PersonService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        //Generates or finds Id
        private int GenerateId()
        {
            if (!people.Any())
            {
                return 1;
            }
            return people.OrderByDescending(p => p.Id).First().Id+1;
        }

        /// <summary>
        /// Get All People
        /// </summary>
        /// <returns></returns>
        public List<PersonViewModel> GetAllPeople()
        {
            return people.Select(p => mapper.Map<PersonViewModel>(p)).ToList();
        }

        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonViewModel GetPersonById(int id)
        {
            Person dbo = people.FirstOrDefault(p => p.Id == id);
            return mapper.Map<PersonViewModel>(dbo);
        }

        /// <summary>
        /// Add person into List
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonViewModel AddPerson(PersonBinding model)
        {
            var dbo = mapper.Map<Person>(model);
            dbo.Id = GenerateId();
            people.Add(dbo);
            return mapper.Map<PersonViewModel>(dbo);
        }

        /// <summary>
        /// Updates values in object called Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonViewModel EditPerson(PersonUpdateBinding model)
        {
            Person dbo = people.FirstOrDefault(p => p.Id == model.Id);
            mapper.Map(model, dbo);
            return mapper.Map<PersonViewModel>(dbo);
        }

        /// <summary>
        /// Remove person from the list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePerson(int id)
        {
            var dbo = people.FirstOrDefault(p => p.Id == id);
            if (dbo == null)
            {
                return false;
            }
            people.Remove(dbo);
            return true;
        }
    }
}
