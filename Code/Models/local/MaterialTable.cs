using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class MaterialTable
    {

        public const string UNSPECIFIED_RAWMAT = "enum.rm.unspecified";

        public const string ESTIMATED_ACCURACY = "enum.quotation.accuracy.estimated";
        public const string QUOTED_ACCURACY = "enum.quotation.accuracy.quoted";

        public const string NONE_INCLUSION = "enum.inclusion.matonly";
        public const string SHIPMENT_INCLUSION = "enum.inclusion.shipment";

        // EDITABLE FIELDS:
        /*public  static final String[] FIELDS = new String[] {
			"title",	
			"materialId",			
			"stateProvince",
			"country",
			"unit",
			"currency",
			"rate",	
			"fabricationRate",
			"shipmentRate",			
			"totalRate",
			"accuracy",
			"inclusion",		
			"quantity",
			"rawMaterial",
			"rawMaterialReliance",
			"rawMaterial2",
			"rawMaterialReliance2",
			"rawMaterial3",
			"rawMaterialReliance3",
			"rawMaterial4",
			"rawMaterialReliance4",
			"rawMaterial5",
			"rawMaterialReliance5",		
			"weight",
			"weightUnit",
			//OIL & GAS
			"volFlow",
			"volFlowUnit",
			"massFlow",
			"massFlowUnit",
			"duty",
			"dutyUnit",
			"operPress",
			"operPressUnit",
			"operTemp",		
			"operTempUnit",
			//oil & gas end 
			"distanceToSite",
			"distanceUnit",		
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
			"bimType",
			"bimMaterial",
		};*/

        // ONLY VIEWABLE IN PANELS
        public static readonly string[] VIEWABLE_FIELDS = new string[] { "materialId", "itemCode", "title", "supplierName", "stateProvince", "country", "quantity", "unit", "rate", "fabricationRate", "shipmentRate", "totalRate", "currency", "weight", "weightUnit", "volFlow", "volFlowUnit", "massFlow", "massFlowUnit", "duty", "dutyUnit", "operPress", "operPressUnit", "operTemp", "operTempUnit", "rawMaterial", "rawMaterialReliance", "rawMaterial2", "rawMaterialReliance2", "rawMaterial3", "rawMaterialReliance3", "rawMaterial4", "rawMaterialReliance4", "rawMaterial5", "rawMaterialReliance5", "distanceToSite", "distanceUnit", "accuracy", "inclusion", "project", "bimType", "bimMaterial", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

        public long? materialId { get; set; }
        public string title { get; set; }
        public string bimMaterial { get; set; }
        public string bimType { get; set; }
        public string description { get; set; }
        public string country { get; set; }
        public string unit { get; set; }
        public decimal rate { get; set; }
        public decimal weight { get; set; }
        public string weightUnit { get; set; }
        public decimal quantity { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string rawMaterial { get; set; }
        public decimal rawMaterialReliance { get; set; }
        public string rawMaterial2 { get; set; }
        public decimal rawMaterialReliance2 { get; set; }
        public string rawMaterial3 { get; set; }
        public decimal rawMaterialReliance3 { get; set; }
        public string rawMaterial4 { get; set; }
        public decimal rawMaterialReliance4 { get; set; }
        public string rawMaterial5 { get; set; }
        public decimal rawMaterialReliance5 { get; set; }

        public decimal buildUpRate { get; set; }
        public int? overrideType { get; set; }

        // New Fields by OIL & GAS:	
        public decimal volFlow { get; set; }
        public decimal massFlow { get; set; }
        public decimal duty { get; set; }
        public decimal operPress { get; set; }
        public decimal operTemp { get; set; }

        public string volFlowUnit { get; set; }
        public string massFlowUnit { get; set; }
        public string dutyUnit { get; set; }
        public string operTempUnit { get; set; }
        public string operPressUnit { get; set; }

        public string project { get; set; }
        public string editorId { get; set; }
        public string notes { get; set; }


        public string stateProvince { get; set; }
        public string supplierName { get; set; }
        public string currency { get; set; }
        public DateTime lastUpdate { get; set; }
        public string createUserId { get; set; }
        public DateTime createDate { get; set; }

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
        public string accuracy { get; set; }
        public decimal shipmentRate { get; set; }
        public decimal fabricationRate { get; set; }
        public decimal totalRate { get; set; }
        public string inclusion { get; set; }
        public decimal distanceToSite { get; set; }
        public string distanceUnit { get; set; }

        public SupplierTable supplierTable { get; set; }
        public bool? @virtual { get; set; }
        public bool? conceptual { get; set; }

        public bool? predicted { get; set; }
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

        public ISet<object> boqItemMaterialSet { get; set; }
        public ISet<MaterialHistoryTable> materialHistorySet { get; set; }
        public ISet<AssemblyMaterialTable> assemblyMaterialSet = new HashSet<AssemblyMaterialTable>();

        public MaterialTable()
        { }
    }
}