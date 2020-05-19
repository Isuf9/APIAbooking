using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class RoomOwner
    {
        public RoomOwner()
        {
            Rooms = new HashSet<Room>();
        }

        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public int? TypeOfUser { get; set; }

        public virtual SentMoney SentMoney { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
