using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class FldFn
    {
        public long Fldfnid { get; set; }
        public string Name { get; set; }
        public string Ftype { get; set; }
        public string Fpath { get; set; }
        public long? Rpdfnid { get; set; }
        public int? Rpdfnfildefcount { get; set; }

        public virtual RpdFn Rpdfn { get; set; }
    }
}
