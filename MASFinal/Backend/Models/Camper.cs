using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Camper : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string Equipment { get; set; }
        public bool HasGenerator { get; set; }
        public GroundVehicle GroundVehicle { get; set; }

        private Camper(GroundVehicle groundVehicle, string equipment, bool hasGenerator)
        {
            GroundVehicle = groundVehicle;
            Equipment = equipment;
            HasGenerator = hasGenerator;
        }

        private Camper() { }

        public static void CreateCamper(GroundVehicle groundVehicle, string equipment, bool hasGenerator)
        {
            if (groundVehicle is null)
                throw new ArgumentNullException("Ground Vehicle can't be null!");

            var camper = new Camper(groundVehicle, equipment, hasGenerator);
            groundVehicle.SetCamper(camper);
        }
    }
}
