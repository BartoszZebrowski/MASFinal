using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class PersonService
    {
        private readonly DatabaseContext _databaseContext = DatabaseContext.GetInstance();

        public void AddMechanic(Mechanic mechanic)
        {
            if (mechanic is null)
                throw new ArgumentNullException("This Mechanic isn't camper!");

            _databaseContext.Mechanics.Add(mechanic);
            _databaseContext.SaveChanges();
        }

        public void AddClient(Client client)
        {
            if (client is null)
                throw new ArgumentNullException("This Client isn't camper!");

            //_databaseContext.Clients.Add(client);
            //_databaseContext.SaveChanges();
        }



    }
}
