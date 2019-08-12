using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Extdatasource
    {
        public Extdatasource()
        {
            Extquery = new HashSet<Extquery>();
        }

        public long Datasourceid { get; set; }
        public string Dstitle { get; set; }
        public byte? Dstype { get; set; }
        public byte? Jdbctype { get; set; }
        public string Jdbcdriver { get; set; }
        public string Jdbcurl { get; set; }
        public string Jdbcuser { get; set; }
        public string Jdbcpsw { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Editorid { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual ICollection<Extquery> Extquery { get; set; }
    }
}
