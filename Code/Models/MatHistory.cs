using System;
using System.Collections.Generic;

namespace Models
{
    public partial class MatHistory
    {
        public long Id { get; set; }
        public long? Materialid { get; set; }
        public string Basetableid { get; set; }
        public string Resource { get; set; }
        public DateTime? Preddate { get; set; }
        public string Rsrc { get; set; }

        public virtual Material Material { get; set; }
    }
}
