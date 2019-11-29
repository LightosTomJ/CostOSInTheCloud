using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Projectspecvar
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Datatype { get; set; }
        public string Defval { get; set; }
        public string Stoval { get; set; }
        public int? Sortorder { get; set; }
        public int? Cellx { get; set; }
        public int? Celly { get; set; }
        public int? Sheetno { get; set; }
        public bool? Mapped { get; set; }
        public decimal? Stovalnum { get; set; }
        public bool? Isnumber { get; set; }
        public bool? Mandatory { get; set; }
        public string Pushfield { get; set; }

        public virtual Projecttemplate Template { get; set; }
    }
}
