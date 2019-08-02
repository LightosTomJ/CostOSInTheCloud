using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Takeoffline
    {
        public Takeoffline()
        {
            Takeoffpoint = new HashSet<Takeoffpoint>();
        }

        public long Id { get; set; }
        public decimal? Sx { get; set; }
        public decimal? Sy { get; set; }
        public decimal? Ex { get; set; }
        public decimal? Ey { get; set; }
        public long? Lid { get; set; }
        public int? Linescount { get; set; }

        public virtual Takeoffcon L { get; set; }
        public virtual ICollection<Takeoffpoint> Takeoffpoint { get; set; }
    }
}
