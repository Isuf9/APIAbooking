using APIAbooking.Models;
using APIAbooking.Services;
using Microsoft.EntityFrameworkCore;
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
                if (id != null && password != null)
                {
                    var client = _dbContext.Clients.Find(id);
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

        public Models.Client Create(Models.Client client)
        {
            _dbContext.Add(client);
            Save();
            return client;
        }

       

        public Models.Client Delete(string id)
        {
            var client = GetById(id);
            _dbContext.Remove(client);
            SaveAsync();

            return client;
        }

        public Models.Client Edit(string id)
        {
            var client = GetById(id);
            _dbContext.Update(client);
            SaveAsync();

            return client;
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

        public  Models.Client GetById(string id_client)
        {
            if(id_client == null) { return null; }
            var client =  _dbContext.Clients.Find(id_client);
            return client; 
        }

        public bool IfEmailExist(string email)
        {
            if (email == null) { return false; }

            var result = _dbContext.Clients;

            foreach (var item in result)
            {
                if (item.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public Models.Client Login(string email, string password)
        {
           var result = _dbContext.Clients
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

        //public IQueryable<Room> Rooms()
        //{
        //    return _dbContext.Rooms
        //                        .Select(x => new Room
        //                        {

        //                            RoomId = x.RoomId,
        //                            MaxGuest = x.MaxGuest,
        //                            NrBathroom = x.NrBathroom,
        //                            Longtitude = x.Longtitude,
        //                            Latitude = x.Latitude,
        //                            Country = x.Country,
        //                            Street = x.Street,
        //                            City = x.City,
        //                            NoHouse = x.NoHouse,
        //                            Zip = x.Zip,
        //                            WhatSpaceCanUseGuests = x.WhatSpaceCanUseGuests,
        //                            SpecialItem = x.SpecialItem,
        //                            Photo = x.Photo,
        //                            Describe = x.Describe,
        //                            PhoneNumber = x.PhoneNumber,
        //                            NoticeGuest = x.NoticeGuest,
        //                            Checkin = x.Checkin,
        //                            Checkout = x.Checkout,
        //                            Reserved = x.Reserved,
        //                            Price = x.Price,
        //                            OwnerIdFk = x.OwnerIdFk
        //                        }).AsNoTracking();
        //}
    }
}
