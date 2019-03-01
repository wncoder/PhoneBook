using System;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public partial class Person
    {
        public Person()
        {
            Phones = new HashSet<Phones>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte Gender { get; set; }

        public ICollection<Phones> Phones { get; set; }
    }
}
