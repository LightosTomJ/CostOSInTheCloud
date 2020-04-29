using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcGPUServer
    {
        public long Id { get; set; }
        public bool? Active { get; set; }
        public long? AvaMem { get; set; }
        public long? Capacity { get; set; }
        public long? CurMem { get; set; }
        public int? CurSessions { get; set; }
        public string Dedicated { get; set; }
        public string Hostname { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? Maxsessions { get; set; }
        public string Name { get; set; }
        public bool? Onln { get; set; }
        public string Paswd { get; set; }
        public string Port { get; set; }
        public string Renderer { get; set; }
        public string Username { get; set; }
        public string Vendor { get; set; }
    }
}
