using System;
using System.Collections.Generic;

namespace Models
{
    public partial class AssemblyChild
    {
        public long Assemblychildid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Divider { get; set; }
        public decimal? Qtypunit { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Exchangerate { get; set; }
        public long? Childid { get; set; }
        public long? Assemblyid { get; set; }
    }
}
