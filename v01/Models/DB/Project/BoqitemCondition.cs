using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class BoqitemCondition
    {
        public long Boqitemconditionid { get; set; }
        public string Funit { get; set; }
        public string Selqtyname { get; set; }
        public decimal? Selqty { get; set; }
        public string Overunit { get; set; }
        public decimal? Overqty { get; set; }
        public decimal? Fqty { get; set; }
        public long? Paramitemid { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Sumup { get; set; }
        public string Selunit { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? Conditionid { get; set; }
        public long? Boqitemid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Boqitem Boqitem { get; set; }
        public virtual Cndon Condition { get; set; }
        public virtual Paramitem Paramitem { get; set; }
    }
}
