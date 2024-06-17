using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class GroundVehicle : Vehicle
    {
        public int Mileage { get; set; }
        public DrivingLicencType Category { get; set; }
        public int NumberOfWheels { get; set; }
        public int RimSize { get; set; }
    }
}
