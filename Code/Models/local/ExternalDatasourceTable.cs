using System;
using System.Collections.Generic;

namespace Model.local
{
    public class ExternalDatasourceTable
    {
        public const sbyte JDBC_DATASOURCE_TYPE = 0;
        public const sbyte JSON_DATASOURCE_TYPE = 1;
        public const sbyte XML_DATASOURCE_TYPE = 2;

        public const sbyte JTDS_JDBC_TYPE = 0;
        public const sbyte ORACLE_JDBC_TYPE = 1;
        public const sbyte MariaDB_JDBC_TYPE = 2;
        public const sbyte POSTGRES_JDBC_TYPE = 3;

        public long? id { get; set; }
        public string title { get; set; }
        public sbyte? type { get; set; }

        // JDBC
        public sbyte? jdbcDatabaseType { get; set; }
        public string jdbcDriverClass { get; set; }
        public string jdbcDatabaseUrl { get; set; }

        public string jdbcUsername { get; set; }
        public string jdbcPassword { get; set; }

        // General:
        public string createUserId { get; set; }
        public DateTime createUserDate { get; set; }
        public string editorId { get; set; }
        public DateTime lastUpdate { get; set; }
        public ISet<ExternalQueryTable> querySet { get; set; }

        public ExternalDatasourceTable()
        { }
    }
}