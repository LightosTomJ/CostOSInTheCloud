using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class TakeOffLegend
    {
        public long Id { get; set; }
        public decimal? Xpos { get; set; }
        public decimal? Ypos { get; set; }
        public int? Zoom { get; set; }
        public decimal? Rotangle { get; set; }
        public string Legtxt { get; set; }
        public string Fnt { get; set; }
        public string Fntcolor { get; set; }
        public long? Cid { get; set; }
        public int? Lgdcount { get; set; }

        public virtual TakeOffCon C { get; set; }
    }
}
