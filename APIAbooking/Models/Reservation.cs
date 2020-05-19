using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            PayMethods = new HashSet<PayMethod>();
        }

        public int ReservationId { get; set; }
        public int PayId { get; set; }
        public int? RoomId { get; set; }

        public virtual Room R { get; set; }
        public virtual ICollection<PayMethod> PayMethods { get; set; }
    }
}
