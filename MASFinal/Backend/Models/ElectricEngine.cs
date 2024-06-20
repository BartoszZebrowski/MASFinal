using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class ElectricEngine : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public decimal AveragePowerConsumption { get; set; }
        public decimal MaximumChargingCurrent { get; set; }
        public DriveType Drive { get; set; }

        private ElectricEngine(DriveType driveType, decimal averagePowerConsumption, decimal maximumChargingCurrent)
        {
            Drive = driveType;
            AveragePowerConsumption = averagePowerConsumption;
            MaximumChargingCurrent = maximumChargingCurrent;
        }

        private ElectricEngine() { }

        public static ElectricEngine CreateElectricEngine(DriveType driveType, decimal averagePowerConsumption, decimal maximumChargingCurrent)
        {
            if(driveType is null)
                throw new ArgumentNullException("DriveType can't be null");

            var electricEngine = new ElectricEngine(driveType, averagePowerConsumption, maximumChargingCurrent);
            driveType.SetElectricEngine(electricEngine);

            return electricEngine;
        }
    }
}
