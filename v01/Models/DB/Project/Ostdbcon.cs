using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Ostdbcon
    {
        public long Ostconid { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Databasename { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
    }
}
