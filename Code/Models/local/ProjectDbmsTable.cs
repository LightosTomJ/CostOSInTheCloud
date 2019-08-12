using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectDbmsTable
    {

        public long? id { get; set; }

        public string hostName { get; set; }
        public string hostPort { get; set; }
        public int? dbms { get; set; }
        public string instanceName { get; set; }
        public string hostUsername { get; set; }
        public string hostPassword { get; set; }
        public string databaseName { get; set; }
        public ISet<ProjectUrlTable> projectUrls { get; set; }

        public ProjectDbmsTable()
        { }
    }
}