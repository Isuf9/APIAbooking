using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class CancelReservation
    {
        public CancelReservation()
        {
            ReservationRooms = new HashSet<ReservationRoom>();
        }

        public string ReservationId { get; set; }
        public string ClientIdFk { get; set; }
        public DateTime? TimeCancel { get; set; }

        public virtual ClientServices ClientIdFkNavigation { get; set; }
        public virtual ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
