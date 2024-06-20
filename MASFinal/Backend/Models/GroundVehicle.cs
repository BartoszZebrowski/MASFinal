using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class GroundVehicle : IVehicle
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

        ////////////
        public int Mileage { get; set; }
        public DrivingLicencType Category { get; set; }
        public int NumberOfWheels { get; set; }
        public int RimSize { get; set; }
        public Bus? Bus { get; set; }
        public Guid? BusId { get; set; }
        public Camper? Camper { get; set; }
        public Guid? CamperId { get; set; }
        public List<Repair> Repairs { get; private set; }
        public string Type
        {
            get 
            {
                if (Bus is not null)
                    return "Bus";
                else
                    return "Camper";
            }
            set => throw new NotImplementedException();
        }

        public GroundVehicle(string brand,
            string model,
            decimal dailyRentalPrice, 
            int numberOfSeats,
            DateTime productionDate,
            int power,
            int mileage,
            DrivingLicencType category,
            int numberOfWheels,
            int rimSize)
        {
            Id = Guid.NewGuid();
            Brand = brand;
            Model = model;
            DailyRentalPrice = dailyRentalPrice;
            NumberOfSeats = numberOfSeats;
            BuyDate = DateTime.Now;
            ProductionDate = productionDate;
            Power = power;
            Rents = new();
            Mileage = mileage;
            Category = category;
            NumberOfWheels = numberOfWheels;
            RimSize = rimSize;
        }

        public void ScrapVehicle(decimal price)
        {
            throw new NotImplementedException();
        }

        public void SellVehicle(decimal price)
        {
            throw new NotImplementedException();
        }
        public void SetBus(Bus bus)
        {
            if(Camper is not null)
                throw new Exception("Can't set Bus when Camper is not null");

            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            Bus = bus;
        }

        public void SetCamper(Camper camper)
        {
            if (Bus is not null)
                throw new Exception("Can't set Camper when Bus is not null");

            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            Camper = camper;
        }   

        public void ChangeBusToCamper(string equipment, bool hasGenerator)
        {
            if (Bus is null)
                throw new Exception("This is not a Bus");

            Bus = null; //pousuwac z ekstensji !!!!
            Camper.CreateCamper(this, equipment, hasGenerator);
        }

        public void AddRepair(Repair repair)
        {
            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            Repairs.Add(repair);
        }
    }
}
