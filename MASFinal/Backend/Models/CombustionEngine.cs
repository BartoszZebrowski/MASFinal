using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class CombustionEngine : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public decimal Capacity { get; set; }
        public decimal AverageFuelConsumption { get; set; }
        public DriveType Drive { get; set; }

        private CombustionEngine(DriveType drive, decimal capacity, decimal averageFuelConsumption)
        {
            Drive = drive;
            Capacity = capacity;
            AverageFuelConsumption = averageFuelConsumption;
        }

        public static CombustionEngine CreateCombustionEngine(DriveType driveType, decimal capacity, decimal averageFuelConsumption)
        {
            if (driveType is null) 
                throw new ArgumentNullException("DriveType can't be null");

            var combustionEngine = new CombustionEngine(driveType, capacity, averageFuelConsumption);
            driveType.SetCombustionEngine(combustionEngine);

            return combustionEngine; 
        }


    }
}
