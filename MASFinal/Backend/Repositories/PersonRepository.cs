using MASFinal.Backend.Context;
using MASFinal.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASFinal.Backend.Services
{
    class PersonRepository
    {


        private readonly DatabaseContext _databaseContext;

        public PersonRepository()
        {
            _databaseContext = new DatabaseContext();
        }

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


            _databaseContext.Clients.Add(client);
            _databaseContext.SaveChanges();
        }

        public Client GetClientById(Guid id)
        {
            var client = _databaseContext.Clients.FirstOrDefault(x => x.Id == id);

            if (client is null)
                throw new Exception($"Not found client with following id: {id}");

            return client;
        }

        public Mechanic GetMechanicById(Guid id)
        {
            var mechanic = _databaseContext.Mechanics.FirstOrDefault(x => x.Id == id);

            if (mechanic is null)
                throw new Exception($"Not found mechanic with following id: {id}");

            return mechanic;
        }

        public void DeleteMechanic(Mechanic mechanic)
        {
            _databaseContext.Mechanics.Remove(mechanic);
            _databaseContext.SaveChanges();
        }

        public void DeleteClient(Client client)
        {
            _databaseContext.Clients.Remove(client);
            _databaseContext.SaveChanges();
        }


        public IEnumerable<Client> GetAllClients() => _databaseContext.Clients.AsNoTracking();

        public IEnumerable<Mechanic> GetAllMechanics() => _databaseContext.Mechanics.AsNoTracking();
    }
}
