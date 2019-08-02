using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Takeoffpoint
    {
        public long Id { get; set; }
        public decimal? Zpos { get; set; }
        public decimal? Xpos { get; set; }
        public decimal? Ypos { get; set; }
        public long? Pid { get; set; }
        public long? Sid { get; set; }
        public long? Cid { get; set; }
        public int? Polycount { get; set; }
        public int? Pointcount { get; set; }
        public int? Elevcount { get; set; }

        public virtual Takeoffcon C { get; set; }
        public virtual Takeoffarea P { get; set; }
        public virtual Takeoffline S { get; set; }
    }
}
