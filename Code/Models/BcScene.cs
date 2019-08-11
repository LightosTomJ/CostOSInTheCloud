using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class BcScene
    {
        public long Id { get; set; }
        public Guid Sguid { get; set; }
        public string Sname { get; set; }
        public byte[] Sdata { get; set; }
        public int? Stype { get; set; }
    }
}
