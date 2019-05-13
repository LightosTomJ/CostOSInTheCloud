using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BoQitemAssembly
    {
        public long Boqitemassemblyid { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Factor3 { get; set; }
        public decimal? Costcenter { get; set; }
        public decimal? Totalunits { get; set; }
        public bool? Usertotalunits { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? Assemblyid { get; set; }
        public long? Boqitemid { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Fequrate { get; set; }
        public decimal? Flabrate { get; set; }
        public decimal? Fmatrate { get; set; }
        public decimal? Fshprate { get; set; }
        public decimal? Ffabrate { get; set; }
        public decimal? Fsubrate { get; set; }
        public decimal? Fconrate { get; set; }
        public decimal? Labcost { get; set; }
        public decimal? Equcost { get; set; }
        public decimal? Subcost { get; set; }
        public decimal? Mattotcost { get; set; }
        public decimal? Concost { get; set; }
        public decimal? Qtypunit { get; set; }

        public virtual Assembly Assembly { get; set; }
    }
}
