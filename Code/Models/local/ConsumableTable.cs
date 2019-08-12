using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ConsumableTable
    {
        /*
		public  static final String[] FIELDS = new String[] {
			"title",
			"consumableId",
			"stateProvince",
			"country",
			"unit",
			"currency",
			"rate",
			"quantity",
			"groupCode",
			"gekCode",
			"project",
			"editorId",
			"notes",
			"description",
			"lastUpdate",
			"extraCode1",
			"extraCode2",
			"extraCode3",
			"extraCode4",
			"extraCode5",
			"extraCode6",
			"extraCode7",		
		};
		 */

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "consumableId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "rate", "currency", "project", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

        public long? consumableId { get; set; }
        public DateTime lastUpdate { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public decimal rate { get; set; }
        public decimal quantity { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string editorId { get; set; }
        public string title { get; set; }
        public string notes { get; set; }
        public string project { get; set; }
        public string currency { get; set; }
        public string stateProvince { get; set; }
        public string country { get; set; }
        public string createUserId { get; set; }
        public DateTime createDate { get; set; }

        public string extraCode1 { get; set; }
        public string extraCode2 { get; set; }
        public string extraCode3 { get; set; }
        public string extraCode4 { get; set; }
        public string extraCode5 { get; set; }
        public string extraCode6 { get; set; }
        public string extraCode7 { get; set; }
        public string extraCode8  { get; set; }
        public string extraCode9 { get; set; }
        public string extraCode10 { get; set; }

        public decimal buildUpRate { get; set; }
        public bool? @virtual { get; set; }
        public bool? predicted { get; set; }
        public bool? conceptual { get; set; }
        public int? overrideType { get; set; }
        // The prediction state
        public int? trendChartType { get; set; }
        public decimal trendValue { get; set; }
        public string trendUnit { get; set; }
        public int? trendColorCode { get; set; }
        public DateTime trendDate { get; set; }
        public int? trendRegType { get; set; }
        public string trendIds { get; set; }
        public string accessRights { get; set; }
        public string keywords { get; set; }
        public string itemCode { get; set; }

        public ISet<object> boqItemConsumableSet { get; set; }
        public ISet<ConsumableHistoryTable> consumableHistorySet { get; set; }
        public ISet<AssemblyConsumableTable> assemblyConsumableSet = new HashSet<AssemblyConsumableTable>();

        public ConsumableTable()
        { }
    }
}