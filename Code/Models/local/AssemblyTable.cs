using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class AssemblyTable
    {
        public static long? _dbCreationDate;

        public const string s_ESTIMATED_ACCURACY = "enum.quotation.accuracy.estimated";
        public const string s_BOTH_ACCURACY = "enum.quotation.accuracy.semiquoted";
        public const string s_QUOTED_ACCURACY = "enum.quotation.accuracy.quoted";

        /*
		public  static final String[] FIELDS = new String[] {			
			"title",
			"assemblyId",
			"stateProvince",
			"country",
			"unit",
			"currency",
			"rate",
			"productivity",
			"unitManhours",
			"unitEquipmentHours",		
			"accuracy",
			"activityBased",
			"quantity",		
			"groupCode",
			"gekCode",
			"project",
			"editorId",
			"publishedRate",
			"publishedRevisionCode",
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
			"bimType",
			"bimMaterial"
		};*/

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "assemblyId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "equipmentRate", "subcontractorRate", "laborRate", "materialRate", "consumableRate", "rate", "currency", "productivity", "unitManhours", "unitEquipmentHours", "accuracy", "activityBased", "project", "publishedRate", "publishedRevisionCode", "bimType", "bimMaterial", "notes", "description", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "puGroupCodeFactor", "puGekCodeFactor", "puExtraCode1Factor", "puExtraCode2Factor", "puExtraCode3Factor", "puExtraCode4Factor", "puExtraCode5Factor", "puExtraCode6Factor", "puExtraCode7Factor", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(Boolean), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal) };

        public long? assemblyId { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public decimal productivity { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string editorId { get; set; }
        public string title { get; set; }
        public string project { get; set; }
        public string notes { get; set; }
        public string currency { get; set; }
        public string stateProvince { get; set; }
        public string country { get; set; }
        public decimal publishedRate { get; set; }
        public decimal rate { get; set; }
        public string publishedRevisionCode { get; set; }
        public string bimType { get; set; }
        public string bimMaterial { get; set; }

        public decimal laborRate { get; set; }
        public decimal materialRate { get; set; }
        public decimal subcontractorRate { get; set; }
        public decimal consumableRate { get; set; }
        public decimal equipmentRate { get; set; }
        public decimal unitManhours { get; set; }
        public decimal unitEquipmentHours { get; set; }

        public decimal quantity { get; set; }
        public string accuracy { get; set; }
        public string createUserId { get; set; }
        public DateTime createDate { get; set; }

        public bool? virtualEquipment { get; set; }
        public bool? virtualSubcontractor { get; set; }
        public bool? virtualLabor { get; set; }
        public bool? virtualMaterial { get; set; }
        public bool? virtualConsumable { get; set; }
        public int? overrideType { get; set; }

        public bool? activityBased { get; set; }

        public string accessRights { get; set; }
        public string keywords { get; set; }
        public string itemCode { get; set; }

        public decimal customRate1 { get; set; }
        public decimal customRate2 { get; set; }
        public decimal customRate3 { get; set; }
        public decimal customRate4 { get; set; }
        public decimal customRate5 { get; set; }
        public decimal customRate6 { get; set; }
        public decimal customRate7 { get; set; }
        public decimal customRate8 { get; set; }
        public decimal customRate9 { get; set; }
        public decimal customRate10 { get; set; }
        public decimal customRate11 { get; set; }
        public decimal customRate12 { get; set; }
        public decimal customRate13 { get; set; }
        public decimal customRate14 { get; set; }
        public decimal customRate15 { get; set; }
        public decimal customRate16 { get; set; }
        public decimal customRate17 { get; set; }
        public decimal customRate18 { get; set; }
        public decimal customRate19 { get; set; }
        public decimal customRate20 { get; set; }

        // Custom Variables:
        public string vars { get; set; }

        public DateTime lastUpdate { get; set; }

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

        public string customText1 { get; set; }
        public string customText2 { get; set; }
        public string customText3 { get; set; }
        public string customText4 { get; set; }
        public string customText5 { get; set; }
        public string customText6 { get; set; }
        public string customText7 { get; set; }
        public string customText8 { get; set; }
        public string customText9 { get; set; }
        public string customText10 { get; set; }
        public string customText11 { get; set; }
        public string customText12 { get; set; }
        public string customText13 { get; set; }
        public string customText14 { get; set; }
        public string customText15 { get; set; }
        public string customText16 { get; set; }
        public string customText17 { get; set; }
        public string customText18 { get; set; }
        public string customText19 { get; set; }
        public string customText20 { get; set; }
        public string customText21 { get; set; }
        public string customText22 { get; set; }
        public string customText23 { get; set; }
        public string customText24 { get; set; }
        public string customText25 { get; set; }

        public bool? @virtual { get; set; }

        public decimal puGroupCodeFactor { get; set; }
        public decimal puGekCodeFactor { get; set; }
        public decimal puExtraCode1Factor { get; set; }
        public decimal puExtraCode2Factor { get; set; }
        public decimal puExtraCode3Factor { get; set; }
        public decimal puExtraCode4Factor { get; set; }
        public decimal puExtraCode5Factor { get; set; }
        public decimal puExtraCode6Factor { get; set; }
        public decimal puExtraCode7Factor { get; set; }

        public ISet<AssemblyLaborTable> assemblyLaborSet = new HashSet<AssemblyLaborTable>();
        public ISet<AssemblyAssemblyTable> assemblyChildSet = new HashSet<AssemblyAssemblyTable>();
        public ISet<AssemblyAssemblyTable> assemblyParentSet = new HashSet<AssemblyAssemblyTable>();
        public ISet<AssemblyEquipmentTable> assemblyEquipmentSet = new HashSet<AssemblyEquipmentTable>();
        public ISet<AssemblyMaterialTable> assemblyMaterialSet = new HashSet<AssemblyMaterialTable>();
        public ISet<AssemblyConsumableTable> assemblyConsumableSet = new HashSet<AssemblyConsumableTable>();
        public ISet<AssemblySubcontractorTable> assemblySubcontractorSet = new HashSet<AssemblySubcontractorTable>();
        public ISet<MaterialHistoryTable> assemblyHistorySet = new HashSet<MaterialHistoryTable>();
        public ISet<object> boqItemAssemblySet = new HashSet<object>();

        public AssemblyTable()
        { }
    }
}