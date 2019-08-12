using System;

namespace Model.local
{
    [Serializable]
    public class BoqMetadataTable
    {
        public static readonly string[] FIELDS = new string[] { "id", "fieldName", "columnName", "initialdisplayName", "fieldKey" };

        public long? id { get; set; }
        public string fieldName { get; set; }
        public string columnName { get; set; }
        public string initialDisplayName { get; set; }
        public string fieldKey { get; set; }

        public BoqMetadataTable()
        { }
    }
}