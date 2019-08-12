using Models.project;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model.local
{
    [Serializable]
    public class EquipmentTable
    {
        public static readonly int? USER_DEFINED_METHOD = new int?(0);
        public static readonly int? CATERPILLAR_METHOD = new int?(1);
        public static readonly int? BGL_1991_METHOD = new int?(2);
        public static readonly int? PRECIZE_METHOD = new int?(3);
        /*
			public  static final String[] FIELDS = new String[] {
				"title",	
				"equipmentId", 			
				"model",
				"make",
				"unit",
				"currency",
				"country",
				"stateProvince",
				"groupCode",
				"gekCode",
				"editorId",
				"fuelType",
				"fuelConsumption",
				"depreciationRate",
				"lubricatesRate",
				"fuelRate",
				"tiresRate",
				"sparePartsRate",
				"reservationRate",
				"totalRate",
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

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "equipmentId", "itemCode", "title", "model", "make", "unit", "currency", "country", "stateProvince", "fuelType", "fuelConsumption", "depreciationRate", "lubricatesRate", "fuelRate", "tiresRate", "sparePartsRate", "reservationRate", "totalRate", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

        public long? equipmentId { get; set; }
        public DateTime lastUpdate { get; set; }
        public string notes { get; set; }
        public string fuelType { get; set; }
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public decimal fuelConsumption { get; set; }
        public decimal depreciationRate { get; set; }
        public decimal lubricatesRate { get; set; }
        public decimal fuelRate { get; set; }
        public decimal tiresRate { get; set; }
        public decimal sparePartsRate { get; set; }
        public decimal reservationRate { get; set; }
        public string model { get; set; }
        public string make { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string currency { get; set; }
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
        public bool? conceptual { get; set; }
        // The prediction state
        public int? trendChartType { get; set; }
        public decimal trendValue { get; set; }
        public string trendUnit { get; set; }
        public int? trendColorCode { get; set; }
        public DateTime trendDate { get; set; }
        public int? trendRegType { get; set; }
        public string trendIds { get; set; }
        public string country { get; set; }
        public string stateProvince { get; set; }
        public string accessRights { get; set; }
        public string keywords { get; set; }
        public string itemCode { get; set; }

        public decimal buildUpRate { get; set; }
        public int? overrideType { get; set; }

        public decimal initAquasitionPrice { get; set; }
        public decimal salvageValue { get; set; }
        public decimal interestRate { get; set; }
        public BigInteger depreciationYears { get; set; }
        public decimal occupationHoursPerMonth { get; set; }
        public decimal occupationalFactor { get; set; }
        public decimal totalRate { get; set; }
        public int? depreciationCalculationMethod = new int?(0);

        public ISet<object> boqItemEquipmentSet { get; set; }
        public ISet<EquipmentHistoryTable> equipmentHistorySet { get; set; }
        public ISet<AssemblyEquipmentTable> assemblyEquipmentSet = new HashSet<AssemblyEquipmentTable>();

        public EquipmentTable()
        { }
    }
}