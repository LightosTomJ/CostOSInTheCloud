using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class WsDataMapping
    {
        public WsDataMapping()
        {
            Wscolident = new HashSet<Wscolident>();
            Wsrevision = new HashSet<WsRevision>();
        }

        public long Id { get; set; }
        public byte[] Xcellfile { get; set; }
        public string Title { get; set; }
        public string Celldtingn { get; set; }
        public int? Groupcol { get; set; }
        public string Treemapping { get; set; }
        public bool? Commentdetect { get; set; }
        public bool? Treedetect { get; set; }
        public string Tableprefer { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
        public bool? Keepitems { get; set; }

        public virtual ICollection<Wscolident> Wscolident { get; set; }
        public virtual ICollection<WsRevision> Wsrevision { get; set; }
    }
}
