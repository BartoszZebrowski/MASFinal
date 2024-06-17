using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class Bus : GroundVehicle
    {
        public decimal TrunkCapacity { get; set; }
        public BodyType TypeOfBody { get; set; }
    }
}
