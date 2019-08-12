using System;

namespace Model.local
{
    [Serializable]
    public class ExtraCode1Table
    {
        public static readonly string[] FIELDS = new string[] { "extraCode1Id", "groupCode", "title", "unit", "unitFactor", "editorId", "notes", "description", "lastUpdate" };

        public long? extraCode1Id { get; set; }
        public string extraCode1 { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public DateTime lastUpdate { get; set; }
        public string unit { get; set; }
        public decimal unitFactor { get; set; }

        public ExtraCode1Table()
        { }
    }
}