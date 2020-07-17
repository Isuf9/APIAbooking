using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Booking
    {
        public string ClientIdFk { get; set; }
        public string RoomIdFk { get; set; }
        public string TypeIdFk { get; set; }
        public string BookId { get; set; }
        public string NumberOfBooking { get; set; }

        public virtual ClientServices ClientIdFkNavigation { get; set; }
        public virtual Room RoomIdFkNavigation { get; set; }
        public virtual TypePay TypeIdFkNavigation { get; set; }
    }
}
