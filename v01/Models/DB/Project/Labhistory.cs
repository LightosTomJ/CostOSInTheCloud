using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class LabHistory
    {
        public long Id { get; set; }
        public long? Laborid { get; set; }
        public string Basetableid { get; set; }
        public string Rsrc { get; set; }
        public DateTime? Preddate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Labor Labor { get; set; }
    }
}
