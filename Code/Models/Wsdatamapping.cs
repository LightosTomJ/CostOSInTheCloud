using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Wsdatamapping
    {
        public Wsdatamapping()
        {
            Wscolident = new HashSet<Wscolident>();
            Wsrevision = new HashSet<Wsrevision>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Celldtingn { get; set; }
        public int? Groupcol { get; set; }
        public string Treemapping { get; set; }
        public bool? Commentdetect { get; set; }
        public bool? Treedetect { get; set; }
        public string Tableprefer { get; set; }

        public virtual ICollection<Wscolident> Wscolident { get; set; }
        public virtual ICollection<Wsrevision> Wsrevision { get; set; }
    }
}
