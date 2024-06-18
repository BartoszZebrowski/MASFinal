using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    interface IWaterVehicle : IVehicle
    {
        bool RequiresHelmsmanLicense { get; set; }
        decimal Displacement { get; set; }
    }
}
