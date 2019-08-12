using System;
using System.Collections.Generic;

namespace Model.local
{
    public class ExternalQueryTable
    {
        public long? id{ get; set; }
        public string title{ get; set; }
        public string query{ get; set; }
        public string resourceType{ get; set; }
        public ExternalDatasourceTable datasourceTable{ get; set; }
        public ISet<ExternalQueryAliasTable> queryAliasSet{ get; set; }

        // General:
        public string createUserId{ get; set; }
        public DateTime createUserDate{ get; set; }
        public string editorId{ get; set; }
        public DateTime lastUpdate{ get; set; }

        public ExternalQueryTable()
        { }
    }
}