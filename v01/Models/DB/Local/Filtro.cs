using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Filtro
    {
        public Filtro()
        {
            Filtroproperty = new HashSet<FiltroProperty>();
        }

        public long Filtroid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Filtroname { get; set; }
        public string Filtrotype { get; set; }
        public string Filtrodescription { get; set; }

        public virtual ICollection<FiltroProperty> Filtroproperty { get; set; }
    }
}
