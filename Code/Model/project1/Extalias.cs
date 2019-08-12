using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Extalias
    {
        public long Aliasid { get; set; }
        public short? Linenumber { get; set; }
        public string Fromaliasclassname { get; set; }
        public string Fromalias { get; set; }
        public string Tofield { get; set; }
        public string Datamapping { get; set; }
        public bool? Isquerycolumnid { get; set; }
        public long? Queryid { get; set; }

        public virtual Extquery Query { get; set; }
    }
}
