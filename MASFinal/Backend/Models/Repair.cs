using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Repair : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RepairCost { get; set; }
        public string Description { get; set; }
        public Mechanic? Mechanic { get; set; }
        public GroundVehicle GroundVehicle { get; set; }

        private Repair(Mechanic? mechanic, GroundVehicle groundVehicle, DateTime startDate, DateTime endDate, decimal repairCost, string description)
        {
            StartDate = startDate;
            EndDate = endDate;
            RepairCost = repairCost;
            Description = description;
            Mechanic = mechanic;
            GroundVehicle = groundVehicle;
        }

        private Repair() { }    

        public static void CreateRepair(Mechanic? mechanic, GroundVehicle groundVehicle, DateTime startDate, DateTime endDate, decimal repairCost, string description)
        {
            if (groundVehicle is null)
                throw new ArgumentNullException("Vehicle can't be null");

            var repair = new Repair(mechanic, groundVehicle, startDate, endDate, repairCost, description);
            groundVehicle.AddRepair(repair);

            if (mechanic is not null)
                mechanic.AddRepair(repair);
        }
    }
}
