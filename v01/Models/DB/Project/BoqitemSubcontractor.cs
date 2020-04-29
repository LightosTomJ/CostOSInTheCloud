using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class BoqItemSubcontractor
    {
        public long Boqitemsubcontractorid { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Totalcost { get; set; }
        public long? Paramitemid { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Factor3 { get; set; }
        public decimal? Qtypunit { get; set; }
        public string Qtypunitform { get; set; }
        public byte? Qtypuformstate { get; set; }
        public decimal? Costcenter { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Totalunits { get; set; }
        public bool? Usertotalunits { get; set; }
        public decimal? Fixedcost { get; set; }
        public decimal? Finalfixedcost { get; set; }
        public decimal? Variablecost { get; set; }
        public string PvVars { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? Subcontractorid { get; set; }
        public long? Quoteitemid { get; set; }
        public long? Boqitemid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual BoqItem Boqitem { get; set; }
        public virtual ParamItem Paramitem { get; set; }
        public virtual QuoteItem Quoteitem { get; set; }
        public virtual Subcontractor Subcontractor { get; set; }
    }
}
