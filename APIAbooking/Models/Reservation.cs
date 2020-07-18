using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationRooms = new HashSet<ReservationRoom>();
        }

        public string ReservationId { get; set; }
        public string ClientIdFk { get; set; }
        public DateTime? TimeBooking { get; set; }

        public virtual Client ClientIdFkNavigation { get; set; }
        public virtual ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
