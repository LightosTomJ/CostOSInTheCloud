using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ParamInput
    {
        public ParamInput()
        {
            ParamCondition = new HashSet<ParamCondition>();
        }

        public long Paraminputid { get; set; }
        public string Name { get; set; }
        public bool? Hidden { get; set; }
        public string Description { get; set; }
        public string Datatype { get; set; }
        public string Dependency { get; set; }
        public string Validation { get; set; }
        public string Selection { get; set; }
        public int? Sortorder { get; set; }
        public string Grouping { get; set; }
        public string Defvalue { get; set; }
        public string Stoval { get; set; }
        public long? Paramitemid { get; set; }
        public string Unit { get; set; }
        public bool? Pblk { get; set; }
        public string Lbl { get; set; }
        public string Artype { get; set; }
        public bool? Editable { get; set; }

        public virtual ICollection<ParamCondition> ParamCondition { get; set; }
    }
}
