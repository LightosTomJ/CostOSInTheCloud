using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Fncton
    {
        public Fncton()
        {
            FnctonArgument = new HashSet<FnctonArgument>();
        }

        public long Functionid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public bool? Takeoff { get; set; }
        public string Createuserid { get; set; }
        public string Editorid { get; set; }
        public DateTime? Createdate { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Grouping { get; set; }
        public string Description { get; set; }
        public string Lang { get; set; }
        public string Pswd { get; set; }
        public string Snum { get; set; }
        public string Prttype { get; set; }
        public string Impl { get; set; }
        public string Restype { get; set; }

        public virtual ICollection<FnctonArgument> FnctonArgument { get; set; }
    }
}
