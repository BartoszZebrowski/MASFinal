using MASFinal.Backend.Generic;
using MASFinal.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public interface IVehicle : Entity
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
        public string Type { get; set; }

        public void SellVehicle(decimal price);
        public void ScrapVehicle(decimal price);
        public void AddRent(Rent rent) => Rents.Add(rent);
        public void SetDriveType(DriveType drive)
        {
            if(drive == null)
                throw new ArgumentNullException("Drive can't be null");

            if (new VehicleRepository().GetAllDrives().Any(d => d.Id == drive.Id))
                throw new ArgumentNullException("This drive type is setted to vehicle!");

            Drive = drive;
        }
    }
}
