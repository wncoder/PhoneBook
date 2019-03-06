using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class PersonService: IPersonService
    {
        private readonly IRepository<Person> _repository;
        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }


        public List<Person> GetAllPerson()
        {
            return _repository.GetAll().ToList();
        }

        public Person GetPerson(int Id)
        {
            return _repository.GetByID(Id);
        }

        public void CreatePerson(Person person)
        {
            _repository.Create(person);
        }

        public void UpdatePerson(Person person)
        {
            _repository.Update(person);
        }

        public void DeletePerson(int Id)
        {
            _repository.Delete(Id);
        }
    }
}
