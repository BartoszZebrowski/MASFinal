using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class VehicleService
    {
        private readonly DatabaseContext _databaseContext = DatabaseContext.GetInstance();

        public void AddBus(GroundVehicle bus)
        {
            if (bus.Bus is null)
                throw new ArgumentNullException("This Ground Vehicle isn't bus!");

            _databaseContext.GroundVehicles.Add(bus);
        }

        public void AddCamper(GroundVehicle caper)
        {
            if (caper.Camper is null)
                throw new ArgumentNullException("This Ground Vehicle isn't camper!");

            _databaseContext.GroundVehicles.Add(caper);
            _databaseContext.SaveChanges();

        }

        public void AddBoat(Boat boat)
        {
            if (boat is null)
                throw new ArgumentNullException("This Boat can't be null");

            _databaseContext.Boats.Add(boat);
            _databaseContext.SaveChanges();
        }

        public void AddAmphibian(Amphibian amphibian)
        {
            if (amphibian is null)
                throw new ArgumentNullException("This Amphibian can't be null");

            _databaseContext.Amphibians.Add(amphibian);
            _databaseContext.SaveChanges();
        }
    }
}
