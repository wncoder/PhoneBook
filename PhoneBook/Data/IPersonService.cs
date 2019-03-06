using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhoneBook.Models;

namespace PhoneBook.Data
{
    public interface IPersonService
    {
        List<Person> GetAllPerson();
        Person GetPerson(int Id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int Id);
    }
}
