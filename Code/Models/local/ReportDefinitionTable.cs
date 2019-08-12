using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ReportDefinitionTable
    {
        public long? id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string design { get; set; }
        public string description { get; set; }
        public string group { get; set; }
        public string editorId { get; set; }
        public string createUserId { get; set; }
        public DateTime lastUpdate { get; set; }
        public DateTime createDate { get; set; }
        public bool? pblk { get; set; }
        public bool? userReport { get; set; }
        public bool? multiUserReport { get; set; }
        public string reportType { get; set; }
        public string reportUrl { get; set; }
        public string reportRoles { get; set; }

        public List<FileDefinitionTable> fileDefinitionList { get; set; }
        public const string JRXML_REPORT = "0";
        public const string JASPER_SERVER_REPORT = "1";
        public const string JASPER_SERVER_DASHBOARD = "2";

        public ReportDefinitionTable()
        {
            fileDefinitionList = new List<FileDefinitionTable>();
        }
    }
}