using System;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public partial class Phones
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneType { get; set; }

        public Person Person { get; set; }
    }
}
