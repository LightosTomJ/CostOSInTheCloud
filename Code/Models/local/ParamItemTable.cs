using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemTable
    {

        public const string PROTECT_PASSWORD = "PSWD";
        public const string PROTECT_SERIAL = "SERL";
        public const string PROTECT_NONE = "NONE";

        /*
		public static final String[] FIELDS = new String[] {			
			"title",
			"costModel",
			"groupName",
			"icon",
			"unit",
			"sampleRate",
			"protectionType",
			"notes",		
			"groupCode",
			"gekCode",
			"extraCode1",
			"extraCode2",
			"extraCode3",
			"extraCode4",
			"extraCode5",
			"extraCode6",
			"extraCode7",	
		};*/

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "paramitemId", "itemCode", "title", "titleFormula", "costModel", "groupName", "icon", "unit", "multUnitQty", "sampleRate", "protectionType", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(Boolean), typeof(string), typeof(string), typeof(string), typeof(Boolean), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
        public long? paramitemId { get; set; }
        public string description { get; set; }
        public string variable { get; set; }
        public string title { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string editorId { get; set; }
        public string notes { get; set; }
        public DateTime lastUpdate { get; set; }
        public string unit { get; set; }
        public decimal sampleRate { get; set; }

        public string password { get; set; }
        public string serialNumber { get; set; }
        public string protectionType { get; set; }
        public string extraCode1 { get; set; }
        public string extraCode2 { get; set; }
        public string extraCode3 { get; set; }
        public string extraCode4 { get; set; }
        public string extraCode5 { get; set; }
        public string extraCode6 { get; set; }
        public string extraCode7 { get; set; }
        public string extraCode8 { get; set; }
        public string extraCode9 { get; set; }
        public string extraCode10 { get; set; }

        public string wbsCode{ get; set; }
        public string wbs2Code{ get; set; }
        public string location{ get; set; }

        public string icon{ get; set; }
        public bool? costModel{ get; set; }
        public string groupName{ get; set; }

        public string createUserId{ get; set; }
        public DateTime createDate{ get; set; }

        public decimal quantity{ get; set; }
        public bool? multUnitQty{ get; set; }

        public ISet<ParamItemInputTable> inputSet{ get; set; }
        public ISet<ParamItemOutputTable> outputSet{ get; set; }
        public ISet<ParamItemReturnTable> returnSet{ get; set; }
        public ISet<BoqItemTable> boqItemSet{ get; set; }
        public ISet<ParamItemConditionTable> conditionSet{ get; set; }
        public decimal totalCost{ get; set; }

        public BoqItemTable parentBoqItem{ get; set; }

        public string accessRights{ get; set; } // accessRights
        public string keywords{ get; set; }
        public string itemCode{ get; set; }
        public string titleFormula{ get; set; }

        public string groupIdentifier{ get; set; }

        public bool? wasExploded{ get; set; } // Applies Only on Project Database after generation

        public ParamItemTable()
        { }
    }
}