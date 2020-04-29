using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class RpdFn
    {
        public RpdFn()
        {
            Fldfn = new HashSet<FldFn>();
        }

        public long Rpdfnid { get; set; }
        public string Rname { get; set; }
        public string Ricn { get; set; }
        public string Rdsgn { get; set; }
        public string Rdesc { get; set; }
        public string Redtid { get; set; }
        public string Rcreuser { get; set; }
        public DateTime? Rlastupd { get; set; }
        public DateTime? Rcredate { get; set; }
        public string Rgrp { get; set; }
        public bool? Rpblk { get; set; }
        public bool? Rusrrep { get; set; }
        public bool? Mltusrrpt { get; set; }
        public string Reporttype { get; set; }
        public string Rjsurl { get; set; }
        public string Reportroles { get; set; }

        public virtual ICollection<FldFn> Fldfn { get; set; }
    }
}
