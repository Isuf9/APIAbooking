using APIAbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Services
{
    public interface IClientService : IService
    {
        
        ClientServices GetById(string id_client);

        public bool IfEmailExist(string email);

        public ClientServices Login(string email, string password);

        public ClientServices Create(ClientServices client);
        public ClientServices Edit(string id);
        public ClientServices Delete(string id);
       
        public void Save();
        public void SaveAsync();

        public void ChangePassword(string id, string password);

        public string GenerateIdRandom(string id);

        public string EncryptPassword(Encoding encoding, string password);

        public string DecryptPassword(string password, Encoding encoding);

       // IQueryable<Room> Rooms();
    }
}
