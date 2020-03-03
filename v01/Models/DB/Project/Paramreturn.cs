using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Paramreturn
    {
        public long Paramreturnid { get; set; }
        public string Reteq { get; set; }
        public long? Prjid { get; set; }
        public long? Paramitemid { get; set; }
        public long? RefId { get; set; }

        public virtual Paramitem Paramitem { get; set; }
    }
}
