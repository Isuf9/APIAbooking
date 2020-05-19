using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class SentMoney
    {
        public int MoneyId { get; set; }
        public decimal AcceptAmount { get; set; }
        public DateTime DataOfAcceptAmount { get; set; }
        public decimal SentAmount { get; set; }
        public DateTime DataOfSentAmount { get; set; }

        public virtual RoomOwner Money { get; set; }
        public virtual PayMethod MoneyNavigation { get; set; }
    }
}
