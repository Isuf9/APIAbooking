using APIAbooking.Models;
using APIAbooking.Services;
using APIAbooking.Services.RoomService;
using Microsoft.AspNetCore.Http;
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

        public Booking CancelBooking(string roomId, string clientId, Booking book)
        {
            throw new NotImplementedException();
        }

        public Room Create(Room room)
        {
            if(room != null)
            {
                room.RoomId = GenerateIdRandom(room.RoomId);
                room.Reserved = false;
                _dbContext.Rooms.Add(room);
                Save();
                return room;
            }
            else
            {
                return null;
            }
        }

        public Booking CreateBooking(string roomId, string clientId, Booking book)
        {
            if (roomId == null && clientId == null)
            {
                return null;
            }
            else
            {
                book.BookId = GenerateIdRandom(book.BookId);
                book.RoomIdFk = roomId;
                book.ClientIdFk = clientId;
                book.TypeIdFk = "1";
                book.NumberOfBooking = GenerateNumberOfBooking(book.NumberOfBooking);
                _dbContext.Bookings.Add(book);
                SaveChangesAsync();
                var _room = GetById(roomId);
                _room.Reserved = true;
                SaveChangesAsync();
                return book;
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

        public string GenerateIdRandom(string bookingId)
        {
                Random _random = new System.Random();
                bookingId = _random.Next(1, 100).ToString();

            return bookingId;
        }

        public string GenerateNumberOfBooking(string bookingId)
        {
            Random _random = new System.Random();
            bookingId ="#"+ _random.Next(1000, 10000).ToString();

            return bookingId;
        }

        public Room GetById(string id)
        {
            if (id == null) { return null; }
            var room = _dbContext.Rooms.Find(id);
            return room;
        }

        public Models.Client GetByIdClient(string id)
        {
            if (id == null) { return null; }
            var client = _dbContext.Clients.Find(id);
            return client;
        }

        public RoomOwner GetByIdOwner(string id)
        {
            if (id == null) { return null; }
            var owner = _dbContext.RoomOwners.Find(id);
            return owner;
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
