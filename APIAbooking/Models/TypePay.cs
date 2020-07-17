using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class TypePay
    {
        public TypePay()
        {
            Bookings = new HashSet<Booking>();
        }

        public string TypePayId { get; set; }
        public int? PayPal { get; set; }
        public int? MasterCart { get; set; }
        public int? VistaCart { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
