using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Models
{
    class Rent
    {
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal RentalAmount { get; set; }
        public bool IsCompleted { get; set; }

        public Client Client { get; private set; }
        public Vehicle Vehicle { get; private set; }

        private Rent(DateTime rentalDate, DateTime returnDate, decimal rentalAmount, Client client, Vehicle vehicle)
        {
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            RentalAmount = rentalAmount;
            IsCompleted = false;
            Client = client;
            Vehicle = vehicle;
        }

        public static Rent CreateRent(Client client, Vehicle vehicle, DateTime rentalDate, DateTime returnDate, decimal rentalAmount)
        {
            if (client is null)
                throw new ArgumentNullException("Client can't be null!");

            if (vehicle is null)
                throw new ArgumentNullException("Client can't be null!");

            var rent = new Rent(rentalDate, returnDate, rentalAmount, client, vehicle);

            client.AddRent(rent);
            vehicle.AddRent(rent);

            return rent;
        }

        public void SendRemind()
        {
            //integration with sms/email send service
        }
    }
}
