using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Queryrow
    {
        public long Qrowid { get; set; }
        public string Fname { get; set; }
        public string Rname { get; set; }
        public string Cndn { get; set; }
        public string Ctype { get; set; }
        public long? Qresid { get; set; }
        public int? Qrowscount { get; set; }

        public virtual Queryresource Qres { get; set; }
    }
}
