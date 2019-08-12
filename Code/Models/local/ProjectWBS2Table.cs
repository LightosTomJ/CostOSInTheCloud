using System;

namespace Model.local
{
    [Serializable]
	public class ProjectWBS2Table
	{

		public static readonly string[] FIELDS = new string[] {"projectWBSId", "groupCode", "itemCode", "title", "unit", "unitFactor", "editorId", "description", "lastUpdate"};
        public long? projectWBSId { get; set; }
        public string groupCode { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string description { get; set; }
        public DateTime lastUpdate { get; set; }
        public string unit { get; set; }
        public decimal unitFactor { get; set; }
        public string itemCode { get; set; }
        public decimal quantity { get; set; }

        public ProjectInfoTable projectInfoTable { get; set; }

        public string projectName { get; set; }

        public ProjectWBS2Table()
        { }
    }
}