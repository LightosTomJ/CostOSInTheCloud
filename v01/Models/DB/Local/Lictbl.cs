using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Lictbl
    {
        public long Id { get; set; }
        public byte[] Hashkey { get; set; }
    }
}
