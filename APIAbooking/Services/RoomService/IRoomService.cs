using APIAbooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAbooking.Services.RoomService
{
    public interface IRoomService : IService
    {
        Room Create(Room room);
        Room Edit(Room room);
        bool Delete(string id);
        void Save();
        void SaveChangesAsync();
        Room GetById(string id);
        Booking GetByIdBooking(string id);
        RoomOwner GetByIdOwner(string id);
        Client GetByIdClient(string id);
        Booking CreateBooking(string roomId, string clientId, Booking book);
        Booking CancelBooking(string roomId, string clientId, Booking book);
        public string GenerateIdRandom(string bookingId);
        public string GenerateNumberOfBooking(string bookingId);
    }
}
