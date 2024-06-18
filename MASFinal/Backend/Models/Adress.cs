using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
