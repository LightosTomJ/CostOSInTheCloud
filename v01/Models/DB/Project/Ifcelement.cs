using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Ifcelement
    {
        public Ifcelement()
        {
            Ifcproperty = new HashSet<Ifcproperty>();
        }

        public long Elemid { get; set; }
        public int? Cndid { get; set; }
        public string Ifcid { get; set; }
        public string Ifcfname { get; set; }
        public string Ifcfile { get; set; }
        public string Ifclabel { get; set; }
        public string Ifclocation { get; set; }
        public string Ifctype { get; set; }
        public string Ifcmaterial { get; set; }
        public string Ifclayer { get; set; }
        public string Ifcbuilding { get; set; }
        public string Ifcstorey { get; set; }
        public string Ifcmodel { get; set; }
        public string Ifczone { get; set; }
        public DateTime? Ifcdate { get; set; }
        public string Ifcname { get; set; }
        public string Ifcobjecttype { get; set; }
        public string Ifccolor { get; set; }
        public double? Ifctransparency { get; set; }
        public decimal? Ifcqty1 { get; set; }
        public string Ifcuom1 { get; set; }
        public string Ifcqtyname1 { get; set; }
        public decimal? Ifcqty2 { get; set; }
        public string Ifcuom2 { get; set; }
        public string Ifcqtyname2 { get; set; }
        public decimal? Ifcqty3 { get; set; }
        public string Ifcuom3 { get; set; }
        public string Ifcqtyname3 { get; set; }
        public string Ifctitle { get; set; }
        public string Ifcdescription { get; set; }
        public string Ifcappname { get; set; }
        public decimal? Topelev { get; set; }
        public decimal? Bottomelev { get; set; }
        public string Parentid { get; set; }
        public bool? Decomposes { get; set; }
        public string Parentspaceid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual ICollection<Ifcproperty> Ifcproperty { get; set; }
    }
}
