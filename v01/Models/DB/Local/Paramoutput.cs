using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Paramoutput
    {
        public Paramoutput()
        {
            Conceptuals = new HashSet<Conceptuals>();
            Queryresource = new HashSet<Queryresource>();
        }

        public long Paramoutputid { get; set; }
        public string Qtyeq { get; set; }
        public string Factoreq { get; set; }
        public string Labloceq { get; set; }
        public string Matloceq { get; set; }
        public string Equloceq { get; set; }
        public string Subloceq { get; set; }
        public string Conloceq { get; set; }
        public string Prdeq { get; set; }
        public string Title { get; set; }
        public string Resids { get; set; }
        public string Generation { get; set; }
        public int? Sortorder { get; set; }
        public string Loopvar { get; set; }
        public long? Paramitemid { get; set; }

        public virtual Paramitem Paramitem { get; set; }
        public virtual ICollection<Conceptuals> Conceptuals { get; set; }
        public virtual ICollection<Queryresource> Queryresource { get; set; }
    }
}
