using APIAbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Services
{
    public interface IClientService 
    {
        public IEnumerable<Client> GetAll();

        public IEnumerable<Client> GetById(string id_client);

        public void FindById(string id);

        public bool IfEmailExist(string email);

        public void LoginSuccses(string email, string password);

        public void Save();

        public void ChangePassword(string id, string password);

        public string GenerateIdRandom(string id);

        public string EncryptPassword(Encoding encoding, string password);

        public string DecryptPassword(string password, Encoding encoding);
    }
}
