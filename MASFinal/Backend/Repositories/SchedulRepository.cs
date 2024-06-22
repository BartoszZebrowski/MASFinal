using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class SchedulRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SchedulRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public void AddRent(GroundVehicle groundVehicleWithRent)
        {
            if (groundVehicleWithRent is null)
                throw new ArgumentNullException("Ground Vehicle can't be null");

            if (groundVehicleWithRent.Rents.IsNullOrEmpty())
                throw new ArgumentNullException("This Ground Vehicle don't have Rent");

            _databaseContext.GroundVehicles.Update(groundVehicleWithRent);
            _databaseContext.SaveChanges();
        }

        public void AddRepair(GroundVehicle groundVehicleWithRepair)
        {
            if (groundVehicleWithRepair is null)
                throw new ArgumentNullException("This Ground Vehicle isn't camper!");

            if (groundVehicleWithRepair.Repairs.IsNullOrEmpty())
                throw new ArgumentNullException("This Ground Vehicle don't have Repairs");

            _databaseContext.GroundVehicles.Update(groundVehicleWithRepair);
            _databaseContext.SaveChanges();
        }

        public Repair GetRepairById(Guid id) => _databaseContext.Repairs
            .Include(r => r.GroundVehicle)
            .Include(m => m.Mechanic)
            .First(x => x.Id == id);

        public IEnumerable<Repair> GetAllRepairs() => _databaseContext.Repairs
            .Include(r => r.GroundVehicle)
            .Include(m => m.Mechanic)
            .AsNoTracking();

        internal void GetAllRents() => _databaseContext.Rents
            .Include(r => r.Vehicle)
            .Include(m => m.Client)
            .AsNoTracking();
    }
}
