using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Usersessions
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Serialkey { get; set; }
        public DateTime? LoggedinDate { get; set; }
        public DateTime? LastupdateDate { get; set; }
    }
}
