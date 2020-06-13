using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Food
    {
        public string FoodId { get; set; }
        public string Expl { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public int? Rating { get; set; }

        public virtual Explore ExplNavigation { get; set; }
    }
}
