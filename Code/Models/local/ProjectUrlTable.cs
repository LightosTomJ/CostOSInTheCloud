using System;
using System.Collections.Generic;

namespace Model.local
{
    public class ProjectUrlTable
    {
        public static readonly string[] FIELDS = new string[] { "url", "defaultRevision", "type", "name", "revision", "editorId", "createUserId", "createDate", "lastUpdate", "underReviewItems", "pendingItems" };

        public const string WHATIF_TYPE = "What-IF";
        public const string SUBPROJECT_TYPE = "SubProject";
        public const string PROJECT_TYPE = "Project";

        public long? projectUrlId { get; set; }
        public string url { get; set; }
        public bool? defaultRevision { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string revision { get; set; }
        public string editorId { get; set; }
        public string createUserId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastUpdate { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string hostname { get; set; }
        public string port { get; set; }
        public int? dbms { get; set; } // 0 IS CEP
        public string dbmsName { get; set; }
        public string databaseName { get; set; }
        public int? underReviewItems { get; set; }
        public int? pendingItems { get; set; }
        public int? approvedItems { get; set; }
        public int? completedItems { get; set; }
        public bool? frozen { get; set; }
        public string tablePrefix { get; set; }
        public bool? createsNewDatabases { get; set; }
        public decimal estimatedItemsTotalCost { get; set; }
        public decimal quotedItemsTotalCost { get; set; }
        public decimal markupTotalCost { get; set; }

        public int? quotesSent { get; set; }
        public int? quotesReceived { get; set; }

        public ProjectInfoTable projectInfoTable { get; set; }
        public ProjectDbmsTable dbmsTable { get; set; }

        public long? benchmarkId { get; set; }
        public string description { get; set; }

        // not used by hibernate:
        public bool? requiresUpdate { get; set; }

        public ISet<ProjectPropertyTable> propertySet = new HashSet<ProjectPropertyTable>(0);

        public ProjectUrlTable()
        { }
    }
}