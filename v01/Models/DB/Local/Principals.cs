using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Principals
    {
        public string Principalid { get; set; }
        public string Authtype { get; set; }
        public string Color { get; set; }
        public string Email { get; set; }
        public bool? Enbl { get; set; }
        public string Hashkey { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
