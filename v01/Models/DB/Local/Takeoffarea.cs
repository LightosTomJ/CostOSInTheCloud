using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Takeoffarea
    {
        public Takeoffarea()
        {
            Takeoffpoint = new HashSet<Takeoffpoint>();
            Takeofftriangle = new HashSet<Takeofftriangle>();
        }

        public long Id { get; set; }
        public bool? Blankfill { get; set; }
        public bool? Conline { get; set; }
        public decimal? Tension { get; set; }
        public long? Aid { get; set; }
        public int? Areacount { get; set; }

        public virtual Takeoffcon A { get; set; }
        public virtual ICollection<Takeoffpoint> Takeoffpoint { get; set; }
        public virtual ICollection<Takeofftriangle> Takeofftriangle { get; set; }
    }
}
