using System;
using System.Collections.Generic;

namespace Models
{
    public partial class QueryResource
    {
        public QueryResource()
        {
            QueryRow = new HashSet<QueryRow>();
        }

        public long Qresid { get; set; }
        public string Title { get; set; }
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
        public string Cc01eq { get; set; }
        public string Cc02eq { get; set; }
        public string Cc03eq { get; set; }
        public string Cc04eq { get; set; }
        public string Cc05eq { get; set; }
        public long? Paramoutputid { get; set; }

        public virtual ParamOutput Paramoutput { get; set; }
        public virtual ICollection<QueryRow> QueryRow { get; set; }
    }
}
