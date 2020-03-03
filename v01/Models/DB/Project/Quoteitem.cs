using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Quoteitem
    {
        public Quoteitem()
        {
            BoqitemMaterial = new HashSet<BoqitemMaterial>();
            BoqitemSubcontractor = new HashSet<BoqitemSubcontractor>();
        }

        public long Quoteitemid { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Parqrty { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Manhours { get; set; }
        public decimal? Matrate { get; set; }
        public decimal? Indirect { get; set; }
        public decimal? Factor2 { get; set; }
        public bool? Rsrc { get; set; }
        public string Status { get; set; }
        public long? Quotationid { get; set; }
        public long? Boqitemid { get; set; }
        public decimal? Insurance { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Shipmentcost { get; set; }
        public decimal? Finalrate { get; set; }
        public long? Databaseid { get; set; }
        public long? Supdbid { get; set; }
        public long? Dbcreatedate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Boqitem Boqitem { get; set; }
        public virtual Quote Quotation { get; set; }
        public virtual ICollection<BoqitemMaterial> BoqitemMaterial { get; set; }
        public virtual ICollection<BoqitemSubcontractor> BoqitemSubcontractor { get; set; }
    }
}
