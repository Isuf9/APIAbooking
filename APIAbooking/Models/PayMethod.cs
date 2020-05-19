using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class PayMethod
    {
        public int PayId { get; set; }
        public int PayIdForSentMoney { get; set; }
        public string Pay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNr { get; set; }
        public string ZipCode { get; set; }
        public DateTime? ExperationDate { get; set; }
        public string SecurityCode { get; set; }
        public bool Confirmaton { get; set; }
        public int? Reservation { get; set; }

        public virtual Reservation ReservationNavigation { get; set; }
        public virtual SentMoney SentMoney { get; set; }
    }
}
