using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BcElemprop
    {
        public long Id { get; set; }
        public string Grpname { get; set; }
        public string Name { get; set; }
        public bool? Isnum { get; set; }
        public decimal? Numval { get; set; }
        public int? Qtytype { get; set; }
        public string Txtval { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
