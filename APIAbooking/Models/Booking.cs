using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Booking
    {
        public string ClientIdFk { get; set; }
        public string RoomIdFk { get; set; }
        public string TypeIdFk { get; set; }

        public virtual Client ClientIdFkNavigation { get; set; }
        public virtual Room RoomIdFkNavigation { get; set; }
        public virtual TypePay TypeIdFkNavigation { get; set; }
    }
}
