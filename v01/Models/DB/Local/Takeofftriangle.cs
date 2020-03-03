using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Takeofftriangle
    {
        public long Id { get; set; }
        public decimal? Xpos1 { get; set; }
        public decimal? Ypos1 { get; set; }
        public decimal? Zpos1 { get; set; }
        public decimal? Xpos2 { get; set; }
        public decimal? Ypos2 { get; set; }
        public decimal? Zpos2 { get; set; }
        public decimal? Xpos3 { get; set; }
        public decimal? Ypos3 { get; set; }
        public decimal? Zpos3 { get; set; }
        public long? Tid { get; set; }
        public int? Triacount { get; set; }

        public virtual Takeoffarea T { get; set; }
    }
}
