using APIAbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Services.OwnerService
{
    public interface IOwnerService : IService
    {

        RoomOwner GetById(string id_client);
        Task<IList<Room>> GetPostRoomByOwnerId(string ownerId);
        public bool IfEmailExist(string email);
        public RoomOwner Login(string email, string password);
        public RoomOwner Create(RoomOwner client);
        public RoomOwner Edit(string id);
        public RoomOwner Delete(string id);
        public void Save();
        public void SaveAsync();
        public void ChangePassword(string id, string password);
        public string GenerateIdRandom(string id);
        public string EncryptPassword(Encoding encoding, string password);
        public string DecryptPassword(string password, Encoding encoding);

    }
}
