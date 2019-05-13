using System;
using System.Collections.Generic;

namespace Models
{
    public partial class OstDbcon
    {
        public long Ostconid { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Databasename { get; set; }
    }
}
