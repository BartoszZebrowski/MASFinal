using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal DailyRentalPrice { get; set; }
        public int NoumberOfSeats { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public int Power { get; set; }

        public List<Rent> Rents { get; private set; }

        public abstract void SellVehicle(decimal price);
        public abstract void ScrapVehicle(decimal price);
        public void AddRent(Rent rent) => Rents.Add(rent);
    }



}
