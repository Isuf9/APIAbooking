using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Models
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients { get; }
        
    }
}
