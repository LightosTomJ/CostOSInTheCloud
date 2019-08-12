using System;

namespace Model.local
{
    [Serializable]
    public class GroupCodeTable
    {
        public static readonly string[] FIELDS = new string[] { "groupCodeId", "groupCode", "title", "unit", "unitFactor", "editorId", "notes", "description", "lastUpdate" };

        public long? groupCodeId { get; set; }
        public string groupCode { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public DateTime lastUpdate { get; set; }
        public string unit { get; set; }
        public decimal unitFactor { get; set; }

        public GroupCodeTable()
        { }
    }
}