using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class FiltroProperty
    {
        public long Filtropropertyid { get; set; }
        public bool? Used { get; set; }
        public string Usetype { get; set; }
        public string Field { get; set; }
        public string Restriction { get; set; }
        public long? Filtroid { get; set; }
        public int? Filtropropertiescount { get; set; }

        public virtual Filtro Filtro { get; set; }
    }
}
