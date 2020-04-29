using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class WsFile
    {
        public long Id { get; set; }
        public bool? Xmlfile { get; set; }
        public string Title { get; set; }
        public string Fpath { get; set; }
        public byte[] Xcellfile { get; set; }
        public int? Numsheets { get; set; }
        public long? Filerevid { get; set; }
        public string Actsheets { get; set; }
        public bool? Tcmfile { get; set; }
        public long? Prjid { get; set; }
        public int? Findex { get; set; }
        public long? RefId { get; set; }

        public virtual WsRevision Filerev { get; set; }
    }
}
