using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BoQitemMaterial
    {
        public long Boqitemmaterialid { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Divider { get; set; }
        public decimal? Totalunits { get; set; }
        public bool? Usertotalunits { get; set; }
        public decimal? Costcenter { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? Materialid { get; set; }
        public long? Boqitemid { get; set; }
        public long? Quoteitemid { get; set; }
        public decimal? Escalation { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Qtypunit { get; set; }

        public virtual Material Material { get; set; }
        public virtual QuoteItem Quoteitem { get; set; }
    }
}
