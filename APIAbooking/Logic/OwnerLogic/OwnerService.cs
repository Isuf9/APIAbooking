using APIAbooking.Models;
using APIAbooking.Services.OwnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Logic.OwnerLogic
{
    public class OwnerService : IOwnerService
    {
        private APIAbookingContext _dbContext;

        public OwnerService(APIAbookingContext db)
        {
            _dbContext = db;
        }

        public void ChangePassword(string id, string password)
        {
            try
            {
                if (id != null && password != null)
                {
                    var client = _dbContext.RoomOwners.Find(id);
                    client.Password = password;
                    Save();
                }
                else
                {

                }
            }
            catch (ArgumentNullException ex)
            {
            }
        }

        public Models.RoomOwner Create(Models.RoomOwner owner)
        {
            _dbContext.RoomOwners.Add(owner);
            Save();
            return owner;
        }



        public Models.RoomOwner Delete(string id)
        {
            var owner = GetById(id);
            _dbContext.RoomOwners.Remove(owner);
            SaveAsync();

            return owner;
        }

        public Models.RoomOwner Edit(string id)
        {
            var owner = GetById(id);
            _dbContext.RoomOwners.Update(owner);
            SaveAsync();

            return owner;
        }

        public string DecryptPassword(string password, Encoding encoding)
        {
            var result = Convert.FromBase64String(password);
            return encoding.GetString(result);
        }

        public string EncryptPassword(Encoding encoding, string password)
        {
            var textAsBytes = encoding.GetBytes(password);
            return Convert.ToBase64String(textAsBytes);
        }

        public string GenerateIdRandom(string id)
        {
            var guid = Guid.NewGuid().ToString();
            id = guid;

            return id;
        }

        public Models.RoomOwner GetById(string id_client)
        {
            if (id_client == null) { return null; }
            var client = _dbContext.RoomOwners.Find(id_client);
            return client;
        }

        public bool IfEmailExist(string email)
        {
            if (email == null) { return false; }

            var result = _dbContext.RoomOwners;

            foreach (var item in result)
            {
                if (item.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public Models.RoomOwner Login(string email, string password)
        {
            var result = _dbContext.RoomOwners
                     .Where(x => x.Email == email && x.Password == password)
                     .FirstOrDefault();

            return result;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void SaveAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
