using System;

namespace Model.local
{
    [Serializable]
    public class FileDefinitionTable
    {

        public const string ICON_TYPE = "icon";
        public const string JRXML_TYPE = "jrxml";
        public const string IMAGE_TYPE = "image";

        public long? id { get; set; }
        public string type { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public ReportDefinitionTable reportDefinitionTable { get; set; }

        public FileDefinitionTable()
        { }
    }
}