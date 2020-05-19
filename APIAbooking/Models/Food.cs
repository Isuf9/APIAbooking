using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Food
    {
        public int FoodId { get; set; }
        public int? Expl { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public int? Rating { get; set; }

        public virtual Explore ExplNavigation { get; set; }
    }
}
