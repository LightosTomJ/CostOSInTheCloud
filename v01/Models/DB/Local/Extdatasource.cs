using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class ExtDatasource
    {
        public ExtDatasource()
        {
            Extquery = new HashSet<ExtQuery>();
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

        public virtual ICollection<ExtQuery> Extquery { get; set; }
    }
}
