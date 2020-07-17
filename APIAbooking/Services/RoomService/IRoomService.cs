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

        Room Edit(string id);

        bool Delete(string id);

        Room GetById(string id);

        void Save();

        void SaveChangesAsync();
        RoomOwner GetByIdOwner(string id);
        RoomOwner GetByIdRoom(string id);
        RoomOwner GetByIdClient(string id);

        Booking CreateBooking(string id, Booking book);

        Booking CancelBooking(string id, Booking book);

    }
}
