using System;
using System.Collections.Generic;

namespace Models
{
    public partial class EquHistory
    {
        public long Id { get; set; }
        public long? Equipmentid { get; set; }
        public string Basetableid { get; set; }
        public string Resource { get; set; }
        public DateTime? Preddate { get; set; }
        public string Rsrc { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
