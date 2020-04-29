using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class TakeOffLine
    {
        public TakeOffLine()
        {
            Takeoffpoint = new HashSet<TakeOffPoint>();
        }

        public long Id { get; set; }
        public decimal? Sx { get; set; }
        public decimal? Sy { get; set; }
        public decimal? Ex { get; set; }
        public decimal? Ey { get; set; }
        public long? Lid { get; set; }
        public int? Linescount { get; set; }

        public virtual TakeOffCon L { get; set; }
        public virtual ICollection<TakeOffPoint> Takeoffpoint { get; set; }
    }
}
