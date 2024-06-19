using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    interface IVehicle : Entity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal DailyRentalPrice { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public int Power { get; set; }

        public DriveType Drive { get; set; }
        public List<Rent> Rents { get; set; }

        public void SellVehicle(decimal price);
        public void ScrapVehicle(decimal price);
        public void AddRent(Rent rent) => Rents.Add(rent);
        public void SetDriveType(DriveType drive)
        {
            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            Drive = drive;
        }
    }
}
