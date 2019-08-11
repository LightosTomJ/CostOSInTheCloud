using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class FnctonArgument
    {
        public long Fargid { get; set; }
        public string Name { get; set; }
        public int? Sorder { get; set; }
        public string Artype { get; set; }
        public bool? Editable { get; set; }
        public long? Fid { get; set; }
        public string Description { get; set; }
        public string Sellist { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string Valsta { get; set; }
        public string Depsta { get; set; }
        public string Defval { get; set; }
        public string Grouping { get; set; }
        public int? Varscount { get; set; }

        public virtual Fncton F { get; set; }
    }
}
