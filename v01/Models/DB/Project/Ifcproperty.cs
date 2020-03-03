using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Ifcproperty
    {
        public long Propid { get; set; }
        public string Ifcpropgroup { get; set; }
        public string Ifcpropname { get; set; }
        public int? Ifcqtytype { get; set; }
        public bool? Ifcisnum { get; set; }
        public string Ifcvalue { get; set; }
        public decimal? Ifcnumval { get; set; }
        public string Ifcmtuom { get; set; }
        public long? Elemid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Ifcelement Elem { get; set; }
    }
}
