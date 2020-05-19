using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int ReservationIdFk { get; set; }
        public int RoomId { get; set; }
        public int? ClientIdFk { get; set; }
        public int? OwnerIdFk { get; set; }
        public int? RoomSpaceItemIdFk { get; set; }
        public int? ExploreIdFk { get; set; }
        public int? MaxGuest { get; set; }
        public int? NrBathroom { get; set; }
        public float? Longtitude { get; set; }
        public float? Latitude { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string NoHouse { get; set; }
        public string Zip { get; set; }
        public int? WhatAmenitiesDoYouOffer { get; set; }
        public int? WhatSpaceCanUseGuests { get; set; }
        public int? Photo { get; set; }
        public string Describe { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseRoule { get; set; }
        public long? NoticeGuest { get; set; }
        public int? Checkout { get; set; }
        public int? Checkin { get; set; }
        public float? Price { get; set; }

        public virtual Client ClientIdFkNavigation { get; set; }
        public virtual Explore ExploreIdFkNavigation { get; set; }
        public virtual RoomOwner OwnerIdFkNavigation { get; set; }
        public virtual RoomSpaceItem RoomSpaceItemIdFkNavigation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
