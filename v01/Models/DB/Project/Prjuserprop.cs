using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class PrjUserProp
    {
        public long Id { get; set; }
        public string Pkey { get; set; }
        public string Pval { get; set; }
        public string Propuser { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
    }
}
