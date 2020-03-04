using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class Filtro
    {
        public Filtro()
        {
            Filtroproperty = new HashSet<Filtroproperty>();
        }

        public long Filtroid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Filtroname { get; set; }
        public string Filtrotype { get; set; }
        public string Filtrodescription { get; set; }

        public virtual ICollection<Filtroproperty> Filtroproperty { get; set; }
    }
}
