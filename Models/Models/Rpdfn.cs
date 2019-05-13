using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Rpdfn
    {
        public Rpdfn()
        {
            FldFn = new HashSet<FldFn>();
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

        public virtual ICollection<FldFn> FldFn { get; set; }
    }
}
