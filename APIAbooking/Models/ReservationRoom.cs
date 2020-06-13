using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class ReservationRoom
    {
        public string Id { get; set; }
        public string ReservationIdFk { get; set; }
        public string CancelReservationIdFk { get; set; }
        public string RoomIdFk { get; set; }
        public string PayMethodFk { get; set; }

        public virtual CancelReservation CancelReservationIdFkNavigation { get; set; }
        public virtual PayMethod PayMethodFkNavigation { get; set; }
        public virtual Reservation ReservationIdFkNavigation { get; set; }
        public virtual Room RoomIdFkNavigation { get; set; }
    }
}
