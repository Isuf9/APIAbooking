using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class CheckBetweenRoomOwner
    {
        public string RoomIdFk { get; set; }
        public string OwnerIdFk { get; set; }

        public virtual RoomOwner OwnerIdFkNavigation { get; set; }
        public virtual Room RoomIdFkNavigation { get; set; }
    }
}
