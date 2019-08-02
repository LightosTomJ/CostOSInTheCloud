using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Fldfn
    {
        public long Fldfnid { get; set; }
        public string Name { get; set; }
        public string Ftype { get; set; }
        public string Fpath { get; set; }
        public long? Rpdfnid { get; set; }
        public int? Rpdfnfildefcount { get; set; }

        public virtual Rpdfn Rpdfn { get; set; }
    }
}
