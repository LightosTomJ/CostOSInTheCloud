using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class QueryRow
    {
        public long Qrowid { get; set; }
        public string Fname { get; set; }
        public string Rname { get; set; }
        public string Cndn { get; set; }
        public string Ctype { get; set; }
        public long? Qresid { get; set; }
        public int? Qrowscount { get; set; }

        public virtual QueryResource Qres { get; set; }
    }
}
