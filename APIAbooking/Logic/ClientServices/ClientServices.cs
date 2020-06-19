using APIAbooking.Models;
using APIAbooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAbooking.Logic.Client
{
    public class ClientServices : IClientService
    {
        private APIAbookingContext _dbContext;
        
        public ClientServices(APIAbookingContext db)
        {
            _dbContext = db;
        }


        public void ChangePassword(string id, string password)
        {
          try
          { 

               if(id != null && password != null)
                {
                    var client = _dbContext.Clients.Find(id);
                    client.Password = password;
                    Save();
                }
                else
                {

                } 
           
          }catch(ArgumentNullException ex)
            { 
                
            }
        }

        public string DecryptPassword(string password, Encoding encoding)
        {
            var result = Convert.FromBase64String(password);
            return encoding.GetString(result);
        }

        public string EncryptPassword( Encoding encoding, string password)
        {
           
            var textAsBytes = encoding.GetBytes(password);
            return Convert.ToBase64String(textAsBytes);
        }

        public void FindById(string? id) => _dbContext.Clients.Find(id);

        public string GenerateIdRandom(string id)
        {
            var guid = Guid.NewGuid().ToString();
            id = guid;

            return id;
        }

        public IEnumerable<Models.Client> GetAll()
        {
            return _dbContext.Clients;
        }

        public IEnumerable<Models.Client> GetById(string id_client)
        {
            var client = _dbContext.Clients.Find(id_client);
            yield return client;
        }

        public bool IfEmailExist(string? email)
        {   
            
            var result =_dbContext.Clients;
            
            foreach(var item in result)
            { 
                if(item.Email == email)
                {
                    return true;
                }
               
            }
            return false;
        }

        public void LoginSuccses(string email, string password)
        {
            throw new NotImplementedException();
        }

        public  void Save() => _dbContext.SaveChanges();

    }
}
