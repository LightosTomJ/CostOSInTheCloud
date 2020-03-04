using System;
using System.Collections.Generic;

namespace Model.DB.Project
{
    public partial class Equhistory
    {
        public long Id { get; set; }
        public long? Equipmentid { get; set; }
        public string Basetableid { get; set; }
        public string Rsrc { get; set; }
        public DateTime? Preddate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
