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
        
        Client GetById(string id_client);
        IEnumerable<Room> GetAllPost();//list e numrushme
        public bool IfEmailExist(string email);
        public Client Login(string email, string password);
        public Client Create(Client client);
        public Client Edit(string id);
        public Client Delete(string id);
        public void Save();
        public void SaveAsync();
        public void ChangePassword(string id, string password);
        public string GenerateIdRandom(string id);
        public string EncryptPassword(Encoding encoding, string password);
        public string DecryptPassword(string password, Encoding encoding);

    }
}
