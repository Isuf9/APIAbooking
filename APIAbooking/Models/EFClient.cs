using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Models
{
    public class EFClient : IClientRepository
    {
        private APIAbookingContext _dbContext;// loose coupling

        public EFClient(APIAbookingContext db)
        {
            _dbContext = db;
        }
        public IEnumerable<Client> GetClients => _dbContext.Clients;
    }
}
