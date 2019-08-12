using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Queryresource
    {
        public Queryresource()
        {
            Queryrow = new HashSet<Queryrow>();
        }

        public long Qresid { get; set; }
        public int? Exectype { get; set; }
        public int? Type { get; set; }
        public string Title { get; set; }
        public string Jsonurl { get; set; }
        public string Restype { get; set; }
        public string Ordfld { get; set; }
        public bool? Ascdng { get; set; }
        public bool? Sngsel { get; set; }
        public string Tlteq { get; set; }
        public string Dsceq { get; set; }
        public string Ntseq { get; set; }
        public string Loceq { get; set; }
        public string Pdteq { get; set; }
        public string Prdeq { get; set; }
        public string Prfeq { get; set; }
        public string Wb1eq { get; set; }
        public string Wb2eq { get; set; }
        public string Piceq { get; set; }
        public string Gc1eq { get; set; }
        public string Gc2eq { get; set; }
        public string Gc3eq { get; set; }
        public string Gc4eq { get; set; }
        public string Gc5eq { get; set; }
        public string Gc6eq { get; set; }
        public string Gc7eq { get; set; }
        public string Gc8eq { get; set; }
        public string Gc9eq { get; set; }
        public string Ct01eq { get; set; }
        public string Ct02eq { get; set; }
        public string Ct03eq { get; set; }
        public string Ct04eq { get; set; }
        public string Ct05eq { get; set; }
        public string Ct06eq { get; set; }
        public string Ct07eq { get; set; }
        public string Ct08eq { get; set; }
        public string Ct09eq { get; set; }
        public string Ct10eq { get; set; }
        public string Ct11eq { get; set; }
        public string Ct12eq { get; set; }
        public string Ct13eq { get; set; }
        public string Ct14eq { get; set; }
        public string Ct15eq { get; set; }
        public string Ct16eq { get; set; }
        public string Ct17eq { get; set; }
        public string Ct18eq { get; set; }
        public string Ct19eq { get; set; }
        public string Ct20eq { get; set; }
        public string Ct21eq { get; set; }
        public string Ct22eq { get; set; }
        public string Ct23eq { get; set; }
        public string Ct24eq { get; set; }
        public string Ct25eq { get; set; }
        public string Cr01eq { get; set; }
        public string Cr02eq { get; set; }
        public string Cr03eq { get; set; }
        public string Cr04eq { get; set; }
        public string Cr05eq { get; set; }
        public string Cr06eq { get; set; }
        public string Cr07eq { get; set; }
        public string Cr08eq { get; set; }
        public string Cr09eq { get; set; }
        public string Cr10eq { get; set; }
        public string Cr11eq { get; set; }
        public string Cr12eq { get; set; }
        public string Cr13eq { get; set; }
        public string Cr14eq { get; set; }
        public string Cr15eq { get; set; }
        public string Cr16eq { get; set; }
        public string Cr17eq { get; set; }
        public string Cr18eq { get; set; }
        public string Cr19eq { get; set; }
        public string Cr20eq { get; set; }
        public string Cc01eq { get; set; }
        public string Cc02eq { get; set; }
        public string Cc03eq { get; set; }
        public string Cc04eq { get; set; }
        public string Cc05eq { get; set; }
        public string Cc06eq { get; set; }
        public string Cc07eq { get; set; }
        public string Cc08eq { get; set; }
        public string Cc09eq { get; set; }
        public string Cc10eq { get; set; }
        public string Cc11eq { get; set; }
        public string Cc12eq { get; set; }
        public string Cc13eq { get; set; }
        public string Cc14eq { get; set; }
        public string Cc15eq { get; set; }
        public string Cc16eq { get; set; }
        public string Cc17eq { get; set; }
        public string Cc18eq { get; set; }
        public string Cc19eq { get; set; }
        public string Cc20eq { get; set; }
        public long? Paramoutputid { get; set; }

        public virtual Paramoutput Paramoutput { get; set; }
        public virtual ICollection<Queryrow> Queryrow { get; set; }
    }
}
