using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Material
    {
        public Material()
        {
            AssemblyMaterial = new HashSet<AssemblyMaterial>();
        }

        public long Materialid { get; set; }
        public string Accuracy { get; set; }
        public string Description { get; set; }
        public bool? Virtual { get; set; }
        public bool? Predicted { get; set; }
        public int? Tchtype { get; set; }
        public decimal? Tval { get; set; }
        public string Tunit { get; set; }
        public int? Tcolor { get; set; }
        public int? Tregtype { get; set; }
        public string Trids { get; set; }
        public DateTime? Trdate { get; set; }
        public bool? Conceptual { get; set; }
        public string Bimmaterial { get; set; }
        public string Bimtype { get; set; }
        public string Country { get; set; }
        public string Rawmat { get; set; }
        public decimal? Reliance { get; set; }
        public string Rawmat2 { get; set; }
        public decimal? Reliance2 { get; set; }
        public string Rawmat3 { get; set; }
        public decimal? Reliance3 { get; set; }
        public string Rawmat4 { get; set; }
        public decimal? Reliance4 { get; set; }
        public string Rawmat5 { get; set; }
        public decimal? Reliance5 { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Shiprate { get; set; }
        public decimal? Fabrate { get; set; }
        public decimal? Totalrate { get; set; }
        public string Inclusion { get; set; }
        public decimal? Distance { get; set; }
        public string Distunit { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Project { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public string Stateprovince { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public string Rescode { get; set; }
        public string Title { get; set; }
        public string Suppliername { get; set; }
        public string Currency { get; set; }
        public decimal? Weight { get; set; }
        public string Weightunit { get; set; }
        public decimal? Volflow { get; set; }
        public decimal? Msflow { get; set; }
        public decimal? Duty { get; set; }
        public decimal? Opres { get; set; }
        public decimal? Optmp { get; set; }
        public string Vlflowut { get; set; }
        public string Msflowut { get; set; }
        public string Dutyut { get; set; }
        public string Optemput { get; set; }
        public string Opresut { get; set; }
        public decimal? Qty { get; set; }
        public long? Supplierid { get; set; }
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
        public int? Overtype { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<AssemblyMaterial> AssemblyMaterial { get; set; }
    }
}
