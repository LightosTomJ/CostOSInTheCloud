using System;
using System.Collections.Generic;

namespace Model.DB.Project
{
    public partial class Mathistory
    {
        public long Id { get; set; }
        public long? Materialid { get; set; }
        public string Basetableid { get; set; }
        public string Rsrc { get; set; }
        public DateTime? Preddate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Material Material { get; set; }
    }
}
