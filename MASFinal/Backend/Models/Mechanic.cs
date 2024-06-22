using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Mechanic : Person
    {
        public DateTime DateOfEmployment { get; set; }
        public decimal GrossSalary { get; set; }
        public static decimal MaxBonus { get; set; }
        public List<Repair> Repairs { get; private set; } = new();

        public Mechanic(DateTime dateOfEmployment, decimal grossSalary, string firstName, string lastName, Address address, string email, string phoneNumber) 
            : base(firstName, lastName, address, email, phoneNumber)
        {
            DateOfEmployment = dateOfEmployment;
            GrossSalary = grossSalary;
        }

        private Mechanic() : base() { }

        internal void AddRepair(Repair repair)
        {
            Repairs.Add(repair);
        }
    }
}
