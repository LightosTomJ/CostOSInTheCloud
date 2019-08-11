using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Ad
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Statusmsg { get; set; }
        public int? Port { get; set; }
        public bool? Isssl { get; set; }
        public string Binddn { get; set; }
        public string Searchfilter { get; set; }
        public string Password { get; set; }
        public string Basedn { get; set; }
        public bool? Enable { get; set; }
        public decimal? Synctime { get; set; }
        public string Hostname { get; set; }
        public string Profile { get; set; }
    }
}
