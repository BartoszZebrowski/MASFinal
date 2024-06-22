using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class Amphibian : GroundVehicle, IWaterVehicle
    {
        public decimal MaximumLaunchAngle { get; set; }
        public DriveSystem DriveSystem { get; set; }


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

        public string Type
        {
            get => "Amphibian";
            set => throw new NotImplementedException();
        }
        public Amphibian(decimal maximumLaunchAngle,
            DriveSystem driveSystem,
            bool requiresHelmsmanLicense,
            decimal displacement,
            string brand,
            string model,
            decimal dailyRentalPrice,
            int numberOfSeats,
            DateTime productionDate,
            int power,
            int mileage,
            DrivingLicencType category,
            int numberOfWheels,
            int rimSize) 
            : base(brand, model, dailyRentalPrice, numberOfSeats, productionDate, power, mileage, category, numberOfWheels, rimSize)
        {
            MaximumLaunchAngle = maximumLaunchAngle;
            DriveSystem = driveSystem;
            RequiresHelmsmanLicense = requiresHelmsmanLicense;
            Displacement = displacement;

        }
    }
}
