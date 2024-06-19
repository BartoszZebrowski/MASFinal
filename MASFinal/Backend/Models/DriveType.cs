using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class DriveType : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public ElectricEngine? ElectricEngine { get; set; }

        public Guid? ElectricEngineId { get; set; }

        public CombustionEngine? CombustionEngine { get; set; }
        public Guid? CombustionEngineId { get; set; }

        private DriveType() { }

        public static void CreateElectricDrive(IVehicle vehicle, decimal averagePowerConsumption, decimal maximumChargingCurrent)
        {
            if(vehicle is null)
                throw new ArgumentNullException("Vehicle can't be null!");

            var driveType = new DriveType();
            ElectricEngine.CreateElectricEngine(driveType, averagePowerConsumption, maximumChargingCurrent);

            vehicle.SetDriveType(driveType);
        }

        public static void CreateCombustionDrive(IVehicle vehicle, decimal capacity, decimal averageFuelConsumption)
        {
            if (vehicle is null)
                throw new ArgumentNullException("Vehicle can't be null!");

            var driveType = new DriveType();
            CombustionEngine.CreateCombustionEngine(driveType, capacity, averageFuelConsumption);

            vehicle.SetDriveType(driveType);
        }

        public static void CreateHybridDrive(IVehicle vehicle, decimal averagePowerConsumption, decimal maximumChargingCurrent, decimal capacity, decimal averageFuelConsumption)
        {
            if (vehicle is null)
                throw new ArgumentNullException("Vehicle can't be null!");

            var driveType = new DriveType();

            CombustionEngine.CreateCombustionEngine(driveType, capacity, averageFuelConsumption);
            ElectricEngine.CreateElectricEngine(driveType, averagePowerConsumption, maximumChargingCurrent);

            vehicle.SetDriveType(driveType);
        }

        internal void SetCombustionEngine(CombustionEngine combustionEngine)
        {
            if (combustionEngine is null)
                throw new ArgumentNullException("Combustion Engine can't be null!");

            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            CombustionEngine = combustionEngine;
        }

        internal void SetElectricEngine(ElectricEngine electricEngine)
        {
            if (electricEngine is null)
                throw new ArgumentNullException("Electric Engine can't be null!");

            // dodac sprawdzenie czy gdzies juz sa przyczepione !!!!

            ElectricEngine = electricEngine;
        }
    }
}
