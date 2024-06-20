using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class SchedulService
    {
        private readonly DatabaseContext _databaseContext = DatabaseContext.GetInstance();

        public void SaveRepair(GroundVehicle groundVehicleWithRepair)
        {
            if (groundVehicleWithRepair is null)
                throw new ArgumentNullException("This Ground Vehicle isn't camper!");

            _databaseContext.GroundVehicles.Update(groundVehicleWithRepair);
            _databaseContext.SaveChanges();
        }
    }
}
