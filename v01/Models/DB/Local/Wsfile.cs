using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Wsfile
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

        public virtual Wsrevision Filerev { get; set; }
    }
}
