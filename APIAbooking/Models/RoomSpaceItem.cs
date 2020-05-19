using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class RoomSpaceItem
    {
        public RoomSpaceItem()
        {
            Rooms = new HashSet<Room>();
        }

        public int SpaceId { get; set; }
        public string SpaceItem { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
