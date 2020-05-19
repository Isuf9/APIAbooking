using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIAbooking.Models
{
    public partial class Client
    {
        public Client()
        {
            Rooms = new HashSet<Room>();
        }
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public int? TypeOfUser { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
