using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    interface IWaterVehicle
    {
        bool RequiresHelmsmanLicense { get; set; }
        decimal Displacement { get; set; }
    }
}
