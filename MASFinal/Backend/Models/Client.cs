using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Client : Person
    {
        public DateTime JoiningDate { get; private set; }
        public int Discount { get; private set; }
        public List<Rent> Rents { get; private set; } = new();

        public Client(DateTime joiningDate, int discount, string firstName, string lastName, Address address, string email, string phoneNumber) 
            : base(firstName, lastName, address, email, phoneNumber)
        {
            JoiningDate = joiningDate;
            Discount = discount;
        }

        private Client() : base() { }
        
        public void AddRent(Rent rent) => Rents.Add(rent);

        public void RemoveRent(Rent rent) => Rents.Remove(rent);
    }
}
