using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Paraminput
    {
        public long Paraminputid { get; set; }
        public string Name { get; set; }
        public string Lbl { get; set; }
        public bool? Hidden { get; set; }
        public bool? Pblk { get; set; }
        public string Artype { get; set; }
        public string Arsizevar { get; set; }
        public bool? Editable { get; set; }
        public bool? Wasshown { get; set; }
        public byte? Calcvaldigits { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public bool? Frmrowvis { get; set; }
        public string Datatype { get; set; }
        public string Dependency { get; set; }
        public string Validation { get; set; }
        public string Selection { get; set; }
        public int? Sortorder { get; set; }
        public string Grouping { get; set; }
        public string Defvalue { get; set; }
        public string Unit { get; set; }
        public string Stoval { get; set; }
        public long? Paramitemid { get; set; }

        public virtual Paramitem Paramitem { get; set; }
    }
}
