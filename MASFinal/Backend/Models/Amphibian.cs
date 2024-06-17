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
    }
}
