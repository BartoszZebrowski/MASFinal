using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class Boat : IWaterVehicle
    {
        private Guid _id;
        public Guid Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private decimal _dailyRentalPrice;
        public decimal DailyRentalPrice
        {
            get { return _dailyRentalPrice; }
            set { _dailyRentalPrice = value; }
        }

        private int _numberOfSeats;
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set { _numberOfSeats = value; }
        }

        private DateTime _buyDate;
        public DateTime BuyDate
        {
            get { return _buyDate; }
            set { _buyDate = value; }
        }

        private DateTime _productionDate;
        public DateTime ProductionDate
        {
            get { return _productionDate; }
            set { _productionDate = value; }
        }

        private int _power;
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        private DriveType _drive;
        public DriveType Drive
        {
            get { return _drive; }
            set { _drive = value; }
        }

        private List<Rent> _rents;
        public List<Rent> Rents
        {
            get { return _rents ??= new List<Rent>(); }
            set { _rents = value; }
        }

        private bool _requiresHelmsmanLicense;
        public bool RequiresHelmsmanLicense
        {
            get => _requiresHelmsmanLicense;
            set => _requiresHelmsmanLicense = value;
        }

        private decimal _displacment;
        public decimal Displacement
        {
            get => _displacment;
            set => _displacment = value;
        }

        public bool HasSail { get; set; }
        public bool CanSleep { get; set; }
        public string Type 
        { 
            get => "Boat";
            set => throw new NotImplementedException();
        }

        public void SellVehicle(decimal price)
        {
            throw new NotImplementedException();
        }

        public void ScrapVehicle(decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
