using System;
using System.Collections.Generic;

namespace APIAbooking.Models
{
    public partial class Client
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int? TypeOfUser { get; set; }
    }
}
