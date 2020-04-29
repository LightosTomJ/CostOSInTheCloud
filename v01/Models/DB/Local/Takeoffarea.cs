using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class TakeOffArea
    {
        public TakeOffArea()
        {
            Takeoffpoint = new HashSet<TakeOffPoint>();
            Takeofftriangle = new HashSet<TakeOffTriangle>();
        }

        public long Id { get; set; }
        public bool? Blankfill { get; set; }
        public bool? Conline { get; set; }
        public decimal? Tension { get; set; }
        public long? Aid { get; set; }
        public int? Areacount { get; set; }

        public virtual TakeOffCon A { get; set; }
        public virtual ICollection<TakeOffPoint> Takeoffpoint { get; set; }
        public virtual ICollection<TakeOffTriangle> Takeofftriangle { get; set; }
    }
}
