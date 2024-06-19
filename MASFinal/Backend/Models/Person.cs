using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    abstract class Person : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string firstName, string lastName, Address address, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        protected Person() { }
    }
}
