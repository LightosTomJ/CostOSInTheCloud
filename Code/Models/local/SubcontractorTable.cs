using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class SubcontractorTable
    {
        public const string ESTIMATED_ACCURACY = "enum.quotation.accuracy.estimated";
        public const string QUOTED_ACCURACY = "enum.quotation.accuracy.quoted";

        public const string NONE_INCLUSION = "enum.inclusion.subonly";
        public const string MATERIAL_INCLUSION = "enum.inclusion.material";
        public const string MATERIAL_AND_SHIPMENT_INCLUSION = "enum.inclusion.matship";

        /*
		public  static final String[] FIELDS = new String[] {
			"title",	
			"subcontractorId",
			"stateProvince",
			"unit",
			"currency",
			"rate",
			"IKA", //yek new
			"totalRate", //yek new
			"accuracy",
			"inclusion",
			"quantity",		
			"groupCode",
			"gekCode",
			"performance",
			"project",
			"editorId",
			"company",
			"contactPerson",
			"phoneNumber",
			"mobileNumber",
			"faxNumber",			
			"email",
			"address",	
			"city",
			"country",
			"url",
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
		};*/

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "subcontractorId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "rate", "subMaterialRate", "IKA", "totalRate", "currency", "accuracy", "inclusion", "project", "performance", "company", "contactPerson", "phoneNumber", "mobileNumber", "faxNumber", "email", "address", "city", "url", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };
        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

        public long? subcontractorId { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string unit { get; set; }
        public decimal rate { get; set; }
        public decimal IKA_Conflict { get; set; }
        public decimal subMaterialRate { get; set; }
        public decimal totalRate { get; set; }
        public decimal quantity { get; set; }
        public string contactPerson { get; set; }
        public string company { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public string faxNumber { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string editorId { get; set; }
        public string performance { get; set; }
        public string project { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string stateProvince { get; set; }
        public string address { get; set; }
        public string notes { get; set; }
        public string currency { get; set; }
        public DateTime lastUpdate { get; set; }
        public string accuracy { get; set; }
        public string inclusion { get; set; }
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

        public bool? @virtual { get; set; }
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

        public decimal buildUpRate { get; set; }
        public int? overrideType { get; set; }

        public bool? conceptual { get; set; }
        public ISet<AssemblySubcontractorTable> assemblySubcontractorSet = new HashSet<AssemblySubcontractorTable>();
        [NonSerialized]
        public ISet<object> boqItemSubcontractorSet;
        public ISet<object> subcontractorHistorySet;


        public SubcontractorTable()
        { }
    }
}