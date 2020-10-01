using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public string RoomId { get; set; }
        public int? MaxGuest { get; set; }
        public int? NrBathroom { get; set; }
        public float? Longtitude { get; set; }
        public float? Latitude { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public short? NoHouse { get; set; }
        public string Zip { get; set; }
        public int? WhatSpaceCanUseGuests { get; set; }
        public string SpecialItem { get; set; }
        public string Describe { get; set; }
        public string PhoneNumber { get; set; }
        public string NoticeGuest { get; set; }
        public DateTime? Checkout { get; set; }
        public DateTime? Checkin { get; set; }
        public bool Reserved { get; set; }
        public decimal Price { get; set; }
        public string OwnerIdFk { get; set; }
        public string Photo { get; set; }
        public string NameOfRoom { get; set; }
        public string Category { get; set; }

        public virtual RoomOwner OwnerIdFkNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
