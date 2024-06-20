using MASFinal.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Context
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Address> Adress { get; set; }
        public DbSet<Amphibian> Amphibians { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Camper> Campers { get; set; }
        //public DbSet<Client> Clients { get; set; } //
        public DbSet<CombustionEngine> CombustionEngines{ get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<ElectricEngine> ElectricEngines { get; set; }
        public DbSet<GroundVehicle> GroundVehicles { get; set; }
        //public DbSet<IVehicle> Vehicles { get; set; } //
        //public DbSet<IWaterVehicle> WaterVehicles { get; set; } //
        public DbSet<Mechanic> Mechanics { get; set; }
        //public DbSet<Person> Persons { get; set; } //
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Repair> Repairs { get; set; }



        private static DatabaseContext _instance = null;
        public DatabaseContext() { }

        public static DatabaseContext GetInstance()
        {
            if(_instance is null)
                _instance = new DatabaseContext();

            return _instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\Local;Database=MAS2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rent>().Ignore(r => r.Vehicle);

            modelBuilder.Entity<CombustionEngine>()
                .HasOne(ce => ce.Drive)
                .WithOne(d => d.CombustionEngine)
                .HasForeignKey<DriveType>(dt => dt.CombustionEngineId);

            modelBuilder.Entity<ElectricEngine>()
                .HasOne(ce => ce.Drive)
                .WithOne(d => d.ElectricEngine)
                .HasForeignKey<DriveType>(dt => dt.ElectricEngineId);

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.GroundVehicle)
                .WithOne(gv => gv.Bus)
                .HasForeignKey<GroundVehicle>(dt => dt.BusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Camper>()
                .HasOne(c => c.GroundVehicle)
                .WithOne(gv => gv.Camper)
                .HasForeignKey<GroundVehicle>(dt => dt.CamperId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
