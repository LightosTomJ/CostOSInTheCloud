using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Extquery
    {
        public Extquery()
        {
            Extalias = new HashSet<Extalias>();
        }

        public long Queryid { get; set; }
        public string Title { get; set; }
        public string Dsquery { get; set; }
        public string Resourcetype { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Editorid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public long? Datasourceid { get; set; }

        public virtual Extdatasource Datasource { get; set; }
        public virtual ICollection<Extalias> Extalias { get; set; }
    }
}
