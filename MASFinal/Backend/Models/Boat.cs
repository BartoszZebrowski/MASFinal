using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class Boat : IWaterVehicle
    {
        public bool HasSail { get; set; }
        public bool CanSleep { get; set; }

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
