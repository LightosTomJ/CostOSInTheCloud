using System;
using System.Collections.Generic;

namespace Models
{
    public partial class AssemblyHhistory
    {
        public long Id { get; set; }
        public long? Assemlbyid { get; set; }
        public string Basetableid { get; set; }
        public string Resource { get; set; }
        public DateTime? Preddate { get; set; }
        public long? Assemblyid { get; set; }
        public string Rsrc { get; set; }

        public virtual Assembly Assembly { get; set; }
        public virtual Assembly Assemlby { get; set; }
    }
}
