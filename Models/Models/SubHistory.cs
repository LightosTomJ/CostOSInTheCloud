using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SubHistory
    {
        public long Id { get; set; }
        public long? Subcontractorid { get; set; }
        public string Basetableid { get; set; }
        public string Resource { get; set; }
        public DateTime? Preddate { get; set; }
        public string Rsrc { get; set; }

        public virtual Subcontractor Subcontractor { get; set; }
    }
}
