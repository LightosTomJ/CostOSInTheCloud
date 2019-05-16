using System;
using System.Collections.Generic;

namespace Models
{
    public partial class QuoteItem
    {
        public QuoteItem()
        {
            BoQitemMaterial = new HashSet<BoQitemMaterial>();
            BoQitemSubcontractor = new HashSet<BoQitemSubcontractor>();
        }

        public long Quoteitemid { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public decimal? Quantity { get; set; }
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
        public decimal? Parqrty { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public bool? Rsrc { get; set; }

        public virtual Quote Quotation { get; set; }
        public virtual ICollection<BoQitemMaterial> BoQitemMaterial { get; set; }
        public virtual ICollection<BoQitemSubcontractor> BoQitemSubcontractor { get; set; }
    }
}
