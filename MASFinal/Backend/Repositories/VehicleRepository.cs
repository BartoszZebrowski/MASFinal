using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class VehicleRepository
    {
        private readonly DatabaseContext _databaseContext;

        public VehicleRepository()
        {
            _databaseContext = new DatabaseContext();
        }

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

        public GroundVehicle GetBusById(Guid id)
        {
            var bus = _databaseContext.GroundVehicles
                .Include(c => c.Bus)
                .FirstOrDefault(x => x.Id == id);

            if (bus is null) 
                throw new Exception($"Not found bus with following id: {id}");

            return bus;
        }

        public GroundVehicle GetCamperById(Guid id)
        {
            var camper = _databaseContext.GroundVehicles
                .Include(c => c.Camper)
                .FirstOrDefault(x => x.Id == id);

            if (camper is null) 
                throw new Exception($"Not found camper with following id: {id}");

            return camper;
        }

        public Boat GetBoatById(Guid id)
        {
            var boat = _databaseContext.Boats.FirstOrDefault(x => x.Id == id);

            if (boat is null) 
                throw new Exception($"Not found Boats with following id: {id}");

            return boat;
        }

        public Amphibian GetAmphibianById(Guid id)
        {
            var amphibian = _databaseContext.Amphibians.FirstOrDefault(x => x.Id == id);

            if (amphibian is null) 
                throw new Exception($"Not found amphibian with following id: {id}");

            return amphibian;
        }

        public IEnumerable<GroundVehicle> GetAllBuses() => _databaseContext.GroundVehicles
            .Include(b => b.Bus)
            .Where(b => b.Bus != null)
            .Include(c => c.Rents)
            .Include(c => c.Repairs)
            .AsNoTracking();

        public IEnumerable<GroundVehicle> GetAllCampers() => _databaseContext.GroundVehicles
            .Include(c => c.Camper)
            .Include(c => c.Rents)
            .Include(c => c.Repairs)
            .Where(b => b.Camper != null)
            .AsNoTracking();

        public IEnumerable<Boat> GetAllBoats() => _databaseContext.Boats.AsNoTracking();

        public IEnumerable<Amphibian> GetAllAmphibians() => _databaseContext.Amphibians.AsNoTracking();

        internal List<IVehicle> GetAllVehicles()
        {
            var vehicles = new List<IVehicle>();

            vehicles.AddRange(GetAllBuses());
            vehicles.AddRange(GetAllCampers());
            vehicles.AddRange(GetAllAmphibians());
            vehicles.AddRange(GetAllBoats());

            return vehicles;
        }

        public void DeleteVehicle(IVehicle vehicle)
        {
            if(vehicle.Type == "Bus")
            {
                var groundVehicle = vehicle as GroundVehicle;

                _databaseContext.GroundVehicles.Remove(groundVehicle);
                _databaseContext.Buses.Remove(groundVehicle.Bus);
                DeleteDrive(groundVehicle.Drive);

                _databaseContext.Repairs.RemoveRange(groundVehicle.Repairs);
            }

            if (vehicle.Type == "Camper")
            {
                var groundVehicle = vehicle as GroundVehicle;

                _databaseContext.GroundVehicles.Remove(groundVehicle);
                _databaseContext.Campers.Remove(groundVehicle.Camper);
                DeleteDrive(groundVehicle.Drive);
                _databaseContext.Repairs.RemoveRange(groundVehicle.Repairs);
            }

            if (vehicle.Type == "Amphibian")
            {
                var amphibian = vehicle as Amphibian;

                _databaseContext.Amphibians.Remove(amphibian);
                DeleteDrive(amphibian.Drive);
            }

            if (vehicle.Type == "Boat")
            {
                var boat = vehicle as Boat;

                _databaseContext.Boats.Remove(boat);
                DeleteDrive(boat.Drive);
            }

            _databaseContext.SaveChanges();
        }

        public void ChangeBusToCamper(Bus bus, Camper camper)
        {
            _databaseContext.Buses.Remove(bus);
            _databaseContext.Campers.Add(camper);

            _databaseContext.SaveChanges();
        }

        public List<DriveType> GetAllDrives()
        {
            return _databaseContext.DriveTypes.ToList();
        }

        public void DeleteDrive(DriveType drive)
        {
            if (drive.ElectricEngine != null)
                _databaseContext.ElectricEngines.Remove(drive.ElectricEngine);

            if (drive.CombustionEngine != null)
                _databaseContext.CombustionEngines.Remove(drive.CombustionEngine);

            _databaseContext.DriveTypes.Remove(drive);
        }
    }

}
