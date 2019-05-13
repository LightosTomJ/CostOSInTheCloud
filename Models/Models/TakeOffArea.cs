using System;
using System.Collections.Generic;

namespace Models
{
    public partial class TakeOffArea
    {
        public TakeOffArea()
        {
            TakeOffPoint = new HashSet<TakeOffPoint>();
            TakeOffTriangle = new HashSet<TakeOffTriangle>();
        }

        public long Id { get; set; }
        public bool? Blankfill { get; set; }
        public long? Aid { get; set; }
        public int? Areacount { get; set; }
        public bool? Conline { get; set; }
        public decimal? Tension { get; set; }

        public virtual TakeOffCon A { get; set; }
        public virtual ICollection<TakeOffPoint> TakeOffPoint { get; set; }
        public virtual ICollection<TakeOffTriangle> TakeOffTriangle { get; set; }
    }
}
