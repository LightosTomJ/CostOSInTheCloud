using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class Paramreturn
    {
        public long Paramreturnid { get; set; }
        public string Reteq { get; set; }
        public long? Paramitemid { get; set; }

        public virtual Paramitem Paramitem { get; set; }
    }
}
