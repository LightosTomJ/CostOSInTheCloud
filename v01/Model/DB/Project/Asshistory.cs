using System;
using System.Collections.Generic;

namespace Model.DB.Project
{
    public partial class Asshistory
    {
        public long Id { get; set; }
        public long? Assemlbyid { get; set; }
        public string Basetableid { get; set; }
        public string Rsrc { get; set; }
        public DateTime? Preddate { get; set; }
        public long? Prjid { get; set; }
        public long? Assemblyid { get; set; }
        public long? RefId { get; set; }

        public virtual Assembly Assembly { get; set; }
        public virtual Assembly Assemlby { get; set; }
    }
}
