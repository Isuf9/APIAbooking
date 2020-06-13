using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class PayMethod
    {
        public PayMethod()
        {
            ReservationRooms = new HashSet<ReservationRoom>();
        }

        public string PayId { get; set; }
        public string TypePayFk { get; set; }

        public virtual TypePay TypePayFkNavigation { get; set; }
        public virtual ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
