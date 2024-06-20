using MASFinal.Backend.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    public class Bus : Entity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        public decimal TrunkCapacity { get; set; }
        public BodyType TypeOfBody { get; set; }
        public GroundVehicle GroundVehicle { get; set; }

        private Bus(GroundVehicle groundVehicle, decimal trunkCapacity, BodyType typeOfBody)
        {
            GroundVehicle = groundVehicle;
            TrunkCapacity = trunkCapacity;
            TypeOfBody = typeOfBody;
        }

        private Bus() { }

        public static void CreateCamper(GroundVehicle groundVehicle, decimal trunkCapacity, BodyType typeOfBody)
        {
            if (groundVehicle is null)
                throw new ArgumentNullException("Ground Vehicle can't be null!");

            var bus = new Bus(groundVehicle, trunkCapacity, typeOfBody);
            groundVehicle.SetBus(bus);
        }
    }
}
