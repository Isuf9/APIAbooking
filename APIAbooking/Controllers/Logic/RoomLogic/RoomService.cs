using APIAbooking.Models;
using APIAbooking.Services;
using APIAbooking.Services.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Logic.RoomLogic
{
    public class RoomService : IRoomService
    {
        private readonly APIAbookingContext _dbContext;
        //private readonly GenericRepository<Room> _genericRepository;

        public RoomService(APIAbookingContext db)
        {
            _dbContext = db;
         //   _genericRepository = repository;
        }
        public Room Create(Room room)
        {
            if(room != null)
            {
                _dbContext.Rooms.Add(room);
                Save();
                return room;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(string id)
        {
            if(id != null)
            {
                var room = GetById(id);
                _dbContext.Rooms.Remove(room);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Room Edit(string id)
        {
            if (id != null)
            {
                var room = GetById(id);
                _dbContext.Rooms.Update(room);
                Save();
                    
                return room;
            }
            else
            {
                return null;
            }
        }

        public Room GetById(string id)
        {
            if (id == null) { return null; }
            var client = _dbContext.Rooms.Find(id);
            return client;
        }

        public void Save()
        {
           _dbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
