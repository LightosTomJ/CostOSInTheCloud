using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcGroupprop
    {
        public long Id { get; set; }
        public string Grpname { get; set; }
        public string Name { get; set; }
        public bool? Isnum { get; set; }
        public decimal? Numval { get; set; }
        public int? Qtytype { get; set; }
        public string Txtval { get; set; }
        public long? GroupId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcGroup Group { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
