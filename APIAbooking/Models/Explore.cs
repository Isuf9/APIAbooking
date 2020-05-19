using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Explore
    {
        public Explore()
        {
            Aventures = new HashSet<Aventure>();
            Foods = new HashSet<Food>();
            Places = new HashSet<Place>();
            Rooms = new HashSet<Room>();
        }

        public int ExploreId { get; set; }

        public virtual ICollection<Aventure> Aventures { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
