using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Consumable
    {
        public Consumable()
        {
            AssemblyConsumable = new HashSet<AssemblyConsumable>();
            BoQitemConsumable = new HashSet<BoQitemConsumable>();
            CnmHistory = new HashSet<CnmHistory>();
        }

        public long Consumableid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Qty { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Project { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public string Editorid { get; set; }
        public string Stateprovince { get; set; }
        public string Country { get; set; }
        public long? Databaseid { get; set; }
        public long? Databasecreationdate { get; set; }
        public string Extracode1 { get; set; }
        public string Extracode2 { get; set; }
        public string Extracode3 { get; set; }
        public string Extracode4 { get; set; }
        public string Extracode5 { get; set; }
        public string Extracode6 { get; set; }
        public string Extracode7 { get; set; }
        public string Extracode8 { get; set; }
        public string Extracode9 { get; set; }
        public string Extracode10 { get; set; }
        public bool? Virtual { get; set; }
        public bool? Predicted { get; set; }
        public int? Tchtype { get; set; }
        public decimal? Tval { get; set; }
        public string Tunit { get; set; }
        public int? Tcolor { get; set; }
        public int? Tregtype { get; set; }
        public string Trids { get; set; }
        public DateTime? Trdate { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public bool? Conceptual { get; set; }

        public virtual ICollection<AssemblyConsumable> AssemblyConsumable { get; set; }
        public virtual ICollection<BoQitemConsumable> BoQitemConsumable { get; set; }
        public virtual ICollection<CnmHistory> CnmHistory { get; set; }
    }
}
