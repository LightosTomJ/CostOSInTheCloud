using System;
using System.Collections.Generic;
using System.Text;

namespace Models.proj
{

	using ExprException = org.boris.expr.ExprException;
	using GraphCycleException = org.boris.expr.util.GraphCycleException;
	using Query = org.hibernate.Query;
	using Session = org.hibernate.Session;
	using Transaction = org.hibernate.Transaction;
	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using BaseTable = nomitech.common.@base.BaseTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using LayoutTable = nomitech.common.db.layout.LayoutTable;
	using AssemblyAssemblyTable = nomitech.common.db.local.AssemblyAssemblyTable;
	using AssemblyConsumableTable = nomitech.common.db.local.AssemblyConsumableTable;
	using AssemblyEquipmentTable = nomitech.common.db.local.AssemblyEquipmentTable;
	using AssemblyLaborTable = nomitech.common.db.local.AssemblyLaborTable;
	using AssemblyMaterialTable = nomitech.common.db.local.AssemblyMaterialTable;
	using AssemblySubcontractorTable = nomitech.common.db.local.AssemblySubcontractorTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using SupplierTable = nomitech.common.db.local.SupplierTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BoqItemDependencyEngine = nomitech.common.expr.boqitem.BoqItemDependencyEngine;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;

	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="BOQITEM" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
	//#RXL_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class BoqItemTable extends nomitech.common.base.ResourceWithAssignmentsTable implements java.awt.datatransfer.Transferable, nomitech.common.base.ProjectIdEntity, java.io.Serializable
	[Serializable]
	public class BoqItemTable : ResourceWithAssignmentsTable, Transferable, ProjectIdEntity
	{

		public static bool calculationsEnabled = true;

		public static bool CalculationsEnabled
		{
			set
			{
				calculationsEnabled = value;
			}
		}

		public static readonly long? ONLINE_DB_CREATE_DATE = new long?(-1);
		public static readonly long? MISSING_DB_CREATE_DATE = new long?(100);

		public const sbyte RATE_TYPE_QUOTED = 0; // 6
		public const sbyte RATE_TYPE_LOCAL = 1; // 5
		public const sbyte RATE_TYPE_ONLINE = 2; // 4
		public const sbyte RATE_TYPE_TREND = 3; // 3
		public const sbyte RATE_TYPE_VIRTUAL = 4; // 1
		public const sbyte RATE_TYPE_CONCEPTUAL = 5; // 2
		public const sbyte RATE_TYPE_EMPTY = 6;
		public const sbyte RATE_TYPE_PROJECT = 7; // PROJECT OVERRIDEN
		public const sbyte RATE_TYPE_OVERRIDEN = 8; // DATABASE OVERRIDEN
		public const sbyte RATE_TYPE_OSTRAKON = 9; // OSTRAKON ASSEMBLY

		public const sbyte TAKEOFF_TYPE_NONE = 0;
		public const sbyte TAKEOFF_TYPE_MANUAL = 1;
		public const sbyte TAKEOFF_TYPE_FUNCTION = 2;
		public const sbyte TAKEOFF_TYPE_OST = 3;
		public const sbyte TAKEOFF_TYPE_BIM = 4;
		public const sbyte TAKEOFF_TYPE_MAP = 5;

		public const string s_ESTIMATED_ACCURACY = "enum.quotation.accuracy.estimated";
		public const string s_BOTH_ACCURACY = "enum.quotation.accuracy.semiquoted";
		public const string s_QUOTED_ACCURACY = "enum.quotation.accuracy.quoted";

		public static string s_PRODUCTIVITY_METHOD = "Productivity";
		public static string s_TOTAL_UNITS_METHOD = "Total Units";

		public static string s_SCHEDULED = "Scheduled";
		public static string s_UNPLANNED = "Unplanned";
		public static string s_SUPERSTRUCTURE_SURFACE_TYPE = "enum.boqsurfacetype.superstructure";
		public static string s_BASEMENT_SURFACE_TYPE = "enum.boqsurfacetype.basement";

		public const string s_PENDING_STATUS = "enum.boqstatus.pending";
		public const string s_APPROVED_STATUS = "enum.boqstatus.approved";
		public const string s_COMPLETED_STATUS = "enum.boqstatus.completed";
		public const string s_UNDERREVIEW_STATUS = "enum.boqstatus.underreview";

		public static string ProducivityTypeString
		{
			set
			{
				s_PRODUCTIVITY_METHOD = value;
			}
		}

		public static string TotalUnitsTypeString
		{
			set
			{
				s_TOTAL_UNITS_METHOD = value;
			}
		}

		public static string ScheduledTypeString
		{
			set
			{
				s_SCHEDULED = value;
			}
		}

		public static string UnplannedTypeString
		{
			set
			{
				s_UNPLANNED = value;
			}
		}

		private const long serialVersionUID = 1L;

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"boqitemId", "code", "publishedItemCode", "publishedRevisionCode", "title", "planningType", "paymentDate", "unit", "secondUnit", "unitsDiv", "calculationType", "activityBased", "productivity", "laborManhours", "equipmentHours", "unitManhours", "adjustedUnitManhours", "duration", "prodFactor", "mhoursFactor", "adjustedProd", "estimatedQuantity", "measuredQuantity", "quantityLoss", "quantity", "secondQuantity", "assemblyRate", "equipmentRate", "subcontractorRate", "quotedSubcontractorRate", "laborRate", "materialRate", "quotedMaterialRate", "consumableRate", "fabricationRate", "shipmentRate", "publishedRate", "rate", "secondRate", "offeredRate", "offeredSecondRate", "markup", "awardedMaterialRate", "awardedInsuranceRate", "awardedSubcontractorRate", "awardedManhours", "awardedIndirectRate", "awardedShipmentRate", "awardedTotalRate", "escalationCost", "assemblyTotalCost", "equipmentTotalCost", "subcontractorTotalCost", "laborTotalCost", "materialTotalCost", "consumableTotalCost", "fabricationTotalCost", "shipmentTotalCost", "totalCost", "offeredPrice", "surfaceType", "status", "accuracy", "flag", "notes", "description", "bimMaterial", "bimType", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "customCumRate1", "customCumRate2", "customCumRate3", "customCumRate4", "customCumRate5", "customCumRate6", "customCumRate7", "customCumRate8", "customCumRate9", "customCumRate10", "customPercentRate1", "customPercentRate2", "customPercentRate3", "customPercentRate4", "customPercentRate5", "customPercentRate6", "customPercentRate7", "customPercentRate8", "customPercentRate9", "customPercentRate10", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "editorId", "estimatorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "wbsCode", "wbs2Code", "location", "puGroupCodeFactor", "puGekCodeFactor", "puExtraCode1Factor", "puExtraCode2Factor", "puExtraCode3Factor", "puExtraCode4Factor", "puExtraCode5Factor", "puExtraCode6Factor", "puExtraCode7Factor", "locProfile", "locFactor", "locCountry", "locState", "paramItemId", "paramItemCode", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20", "customCumRate11", "customCumRate12", "customCumRate13", "customCumRate14", "customCumRate15", "customCumRate16", "customCumRate17", "customCumRate18", "customCumRate19", "customCumRate20", "customPercentRate11", "customPercentRate12", "customPercentRate13", "customPercentRate14", "customPercentRate15", "customPercentRate16", "customPercentRate17", "customPercentRate18", "customPercentRate19", "customPercentRate20", "customText21", "customText22", "customText23", "customText24", "customText25", "customDate1", "customDate2", "customDate3", "customDate4", "customDate5", "fixedCost"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(Boolean), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(Integer), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(Long), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(decimal)};

		public static readonly string[] FORMULA_FIELDS = new string[] {"titleFormula", "descriptionFormula", "markupFormula", "quantityFormula", "productivityFormula", "unitManhoursFormula", "adjustedUnitManhoursFormula", "durationFormula", "prodFactorFormula", "mhoursFactorFormula", "adjustedProdFormula", "estimatedQuantityFormula", "quantityLossFormula", "totalCostFormula", "offeredPriceFormula", "rateFormula", "offeredRateFormula", "offeredSecondRateFormula", "secondRateFormula", "secondQuantityFormula", "secondUnitFormula", "unitsDivFormula", "assemblyTotalCostFormula", "equipmentTotalCostFormula", "materialTotalCostFormula", "subcontractorTotalCostFormula", "laborTotalCostFormula", "consumableTotalCostFormula", "wbsCodeFormula", "wbs2CodeFormula", "customRate1Formula", "customRate2Formula", "customRate3Formula", "customRate4Formula", "customRate5Formula", "customRate6Formula", "customRate7Formula", "customRate8Formula", "customRate9Formula", "customRate10Formula", "customRate11Formula", "customRate12Formula", "customRate13Formula", "customRate14Formula", "customRate15Formula", "customRate16Formula", "customRate17Formula", "customRate18Formula", "customRate19Formula", "customRate20Formula", "customCumRate1Formula", "customCumRate2Formula", "customCumRate3Formula", "customCumRate4Formula", "customCumRate5Formula", "customCumRate6Formula", "customCumRate7Formula", "customCumRate8Formula", "customCumRate9Formula", "customCumRate10Formula", "customCumRate11Formula", "customCumRate12Formula", "customCumRate13Formula", "customCumRate14Formula", "customCumRate15Formula", "customCumRate16Formula", "customCumRate17Formula", "customCumRate18Formula", "customCumRate19Formula", "customCumRate20Formula", "customPercentRate1Formula", "customPercentRate2Formula", "customPercentRate3Formula", "customPercentRate4Formula", "customPercentRate5Formula", "customPercentRate6Formula", "customPercentRate7Formula", "customPercentRate8Formula", "customPercentRate9Formula", "customPercentRate10Formula", "customPercentRate11Formula", "customPercentRate12Formula", "customPercentRate13Formula", "customPercentRate14Formula", "customPercentRate15Formula", "customPercentRate16Formula", "customPercentRate17Formula", "customPercentRate18Formula", "customPercentRate19Formula", "customPercentRate20Formula", "customText1Formula", "customText2Formula", "customText3Formula", "customText4Formula", "customText5Formula", "customText6Formula", "customText7Formula", "customText8Formula", "customText9Formula", "customText10Formula", "customText11Formula", "customText12Formula", "customText13Formula", "customText14Formula", "customText15Formula", "customText16Formula", "customText17Formula", "customText18Formula", "customText19Formula", "customText20Formula", "customText21Formula", "customText22Formula", "customText23Formula", "customText24Formula", "customText25Formula"};

		public static bool isFieldNullable(string fieldName)
		{ // nullable ?
			if (fieldName.Equals("paramItemId") || fieldName.Equals("paramItemCode") || fieldName.Equals("customDate1") || fieldName.Equals("customDate2") || fieldName.Equals("customDate3") || fieldName.Equals("customDate4") || fieldName.Equals("customDate5"))
			{
				return true;
			}

			return false;
		}

		public static bool isFieldDate(string fieldName)
		{ // nullable ?
			if (fieldName.Equals("customDate1") || fieldName.Equals("customDate2") || fieldName.Equals("customDate3") || fieldName.Equals("customDate4") || fieldName.Equals("customDate5"))
			{
				return true;
			}

			return false;
		}

		public static bool isFieldEditable(string fieldName)
		{ // editable ?
			if (fieldName.Equals("rate") || fieldName.Equals("laborManhours") || fieldName.Equals("equipmentHours") || fieldName.Equals("adjustedUnitManhours") || fieldName.Equals("secondQuantity") || fieldName.Equals("secondRate") || fieldName.Equals("offeredRate") || fieldName.Equals("offeredSecondRate") || fieldName.Equals("assemblyTotalCost") || fieldName.Equals("equipmentTotalCost") || fieldName.Equals("subcontractorTotalCost") || fieldName.Equals("laborTotalCost") || fieldName.Equals("materialTotalCost") || fieldName.Equals("fabricationTotalCost") || fieldName.Equals("shipmentTotalCost") || fieldName.Equals("consumableTotalCost") || fieldName.Equals("totalCost") || fieldName.Equals("offeredPrice") || fieldName.Equals("shipmentRate") || fieldName.Equals("fabricationRate") || fieldName.Equals("quotedMaterialRate") || fieldName.Equals("quotedSubcontractorRate") || fieldName.Equals("accuracy") || fieldName.Equals("createUserId") || fieldName.Equals("editorId") || fieldName.Equals("escalationCost") || fieldName.Equals("quantityLoss") || fieldName.Equals("boqitemId") || fieldName.Equals("status") || fieldName.Equals("measuredQuantity") || fieldName.Equals("locProfile") || fieldName.Equals("locFactor") || fieldName.Equals("locCountry") || fieldName.Equals("locState") || fieldName.Equals("adjustedProd") || fieldName.Equals("estimatorId") || fieldName.StartsWith("awarded", StringComparison.Ordinal) || fieldName.Equals("paramItemId") || fieldName.Equals("paramItemCode") || fieldName.Equals("assemblyRate") || fieldName.Equals("fixedCost"))
			{
				return false;
			}
			return true;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> boqitemId;
		private long? boqitemId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<long> code;
		private long? code;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String secondUnit;
		private string secondUnit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitsDiv;
		private decimal unitsDiv;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantity;
		private decimal quantity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal measuredQuantity;
		private decimal measuredQuantity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal estimatedQuantity;
		private decimal estimatedQuantity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantityLoss;
		private decimal quantityLoss;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal markup;
		private decimal markup;

		private decimal awardedMaterialRate;
		private decimal awardedInsuranceRate;
		private decimal awardedSubcontractorRate;
		private decimal awardedManhours;
		private decimal awardedIndirectRate;
		private decimal awardedShipmentRate;
		private decimal awardedTotalRate;

		//	@Field( store = Store.YES )
		//	private String activityId = "";	
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal duration;
		private decimal duration;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal productivity;
		private decimal productivity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal laborManhours;
		private decimal laborManhours; // Total Labor
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal equipmentHours;
		private decimal equipmentHours; // Total Equipment
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitManhours;
		private decimal unitManhours; // Labor
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal adjustedUnitManhours;
		private decimal adjustedUnitManhours;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> activityBased;
		private bool? activityBased;

		/// <summary>
		/// This boolean determines if this boq item has at least one assignment 
		/// with at least one boq field involved in its formula.
		/// </summary>
		private bool? hasAssignmentFormula;

		/// <summary>
		/// This boolean determines if this boq item has in any formula field
		/// any global PV variable involved e.g. <code>VAR("mitsos") or PRJVARIABLE("george")</code>
		/// 
		/// </summary>
		private bool? hasPVFormula;

		/// <summary>
		/// This String declares which column contains which PV Variables
		/// 	e.g. <code>CUSRATE1:var1,var2;CUSTXT1:mitsos,george;MARKUP:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		// Custom local variables:
		private string vars;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode;
		private string groupCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode;
		private string gekCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String publishedItemCode;
		private string publishedItemCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal publishedRate;
		private decimal publishedRate;
		private decimal calculatedRate;
		private decimal escalationCost;

		private decimal rate;
		private decimal fixedCost;
		private decimal totalCost;
		private decimal offeredPrice;
		private decimal offeredRate;
		private decimal secondRate;
		private decimal secondQuantity;
		private decimal offeredSecondRate;
		private decimal assemblyRate;
		private decimal laborRate;
		private decimal subcontractorRate;
		private decimal quotedSubcontractorRate;
		private decimal equipmentRate;
		private decimal consumableRate;
		private decimal assemblyTotalCost;
		private decimal laborTotalCost;
		private decimal subcontractorTotalCost;
		private decimal equipmentTotalCost;
		private decimal consumableTotalCost;
		private decimal materialTotalCost;
		private decimal fabricationTotalCost;
		private decimal shipmentTotalCost;
		private decimal materialResourceTotalCost;
		private decimal materialRate;
		private decimal quotedMaterialRate;
		private decimal fabricationRate;
		private decimal shipmentRate;

		// Used for saving previous estimated rates:
		//	private BigDecimal estimRate;
		//	private BigDecimal estimAssemblyRate;
		//	private BigDecimal estimLaborRate;
		//	private BigDecimal estimConsumableRate;
		//	private BigDecimal estimMaterialRate;
		//	private BigDecimal estimFabricationRate;
		//	private BigDecimal estimShipmentRate;
		//	private BigDecimal estimSubcontractorRate;
		//	private BigDecimal estimEquipmentRate;
		//	private BigDecimal quotedMaterialRate;
		//	private BigDecimal quotedSubcontractorRate;
		//
		//	private BigDecimal estimTotalCost;
		//	private BigDecimal estimAssemblyTotalCost;
		//	private BigDecimal estimLaborTotalCost;
		//	private BigDecimal estimConsumableTotalCost;
		//	private BigDecimal estimMaterialTotalCost;
		//	private BigDecimal estimFabricationTotalCost;
		//	private BigDecimal estimShipmentTotalCost;
		//	private BigDecimal estimSubcontractorTotalCost;
		//	private BigDecimal estimEquipmentTotalCost;
		//	private BigDecimal quotedMaterialTotalCost;
		//	private BigDecimal quotedSubcontractorTotalCost;

		private decimal calculatedTotalCost;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String publishedRevisionCode;
		private string publishedRevisionCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String surfaceType;
		private string surfaceType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String status;
		private string status;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<int> flag;
		private int? flag;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String estimatorId;
		private string estimatorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String accuracy;
		private string accuracy;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rollUP;
		private string rollUP;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String location;
		private string location;

		private decimal adjustedProd; // =IF(LOCFACTOR=0,PRODUCTIVITY,PRODUCTIVITY*LOCFACTOR)
		private decimal prodFactor;
		private decimal mhoursFactor;
		private string locProfile;
		private string locFactor;
		private string locCountry;
		private string locState;

		//Field( index = Index.TOKENIZED )
		private DateTime paymentDate;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode1;
		private string extraCode1;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode2;
		private string extraCode2;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String wbsCode;
		private string wbsCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String wbs2Code;
		private string wbs2Code;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode3;
		private string extraCode3;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode4;
		private string extraCode4;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode5;
		private string extraCode5;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode6;
		private string extraCode6;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode7;
		private string extraCode7;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode8 = "";
		private string extraCode8 = "";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode9 = "";
		private string extraCode9 = "";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode10 = "";
		private string extraCode10 = "";

		private string worksheetLookup;

		private DateTime lastUpdate;
		private DateTime createDate;

		private bool? hasProductivity = true;
		private bool? isScheduled = true;
		private ISet<object> boqItemAssemblySet;
		private ISet<object> boqItemLaborSet;
		private ISet<object> boqItemEquipmentSet;
		private ISet<object> boqItemMaterialSet;
		private ISet<object> boqItemConsumableSet;
		private ISet<object> boqItemSubcontractorSet;
		private ISet<object> boqItemConditionSet;
		private ISet<object> quoteItemSet;
		private ISet<object> paramItemSet;

		private long? globalParamItemId;
		private long? paramItemId;
		private ParamItemTable paramItemTable;
		private string paramItemCode;
		private string generationId;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimType;
		private string bimType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimMaterial;
		private string bimMaterial;

		private sbyte? equipmentRateType;
		private sbyte? assemblyRateType;
		private sbyte? subcontractorRateType;
		private sbyte? laborRateType;
		private sbyte? materialRateType;
		private sbyte? consumableRateType;
		private sbyte? takeoffQuantityType;

		// Custom Rates:
		private decimal customRate1;
		private decimal customRate2;
		private decimal customRate3;
		private decimal customRate4;
		private decimal customRate5;
		private decimal customRate6;
		private decimal customRate7;
		private decimal customRate8;
		private decimal customRate9;
		private decimal customRate10;
		private decimal customRate11;
		private decimal customRate12;
		private decimal customRate13;
		private decimal customRate14;
		private decimal customRate15;
		private decimal customRate16;
		private decimal customRate17;
		private decimal customRate18;
		private decimal customRate19;
		private decimal customRate20;

		private decimal customCumRate1;
		private decimal customCumRate2;
		private decimal customCumRate3;
		private decimal customCumRate4;
		private decimal customCumRate5;
		private decimal customCumRate6;
		private decimal customCumRate7;
		private decimal customCumRate8;
		private decimal customCumRate9;
		private decimal customCumRate10;
		private decimal customCumRate11;
		private decimal customCumRate12;
		private decimal customCumRate13;
		private decimal customCumRate14;
		private decimal customCumRate15;
		private decimal customCumRate16;
		private decimal customCumRate17;
		private decimal customCumRate18;
		private decimal customCumRate19;
		private decimal customCumRate20;

		private decimal customPercentRate1;
		private decimal customPercentRate2;
		private decimal customPercentRate3;
		private decimal customPercentRate4;
		private decimal customPercentRate5;
		private decimal customPercentRate6;
		private decimal customPercentRate7;
		private decimal customPercentRate8;
		private decimal customPercentRate9;
		private decimal customPercentRate10;
		private decimal customPercentRate11;
		private decimal customPercentRate12;
		private decimal customPercentRate13;
		private decimal customPercentRate14;
		private decimal customPercentRate15;
		private decimal customPercentRate16;
		private decimal customPercentRate17;
		private decimal customPercentRate18;
		private decimal customPercentRate19;
		private decimal customPercentRate20;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText1;
		private string customText1;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText2;
		private string customText2;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText3;
		private string customText3;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText4;
		private string customText4;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText5;
		private string customText5;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText6;
		private string customText6;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText7;
		private string customText7;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText8;
		private string customText8;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText9;
		private string customText9;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText10;
		private string customText10;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText11;
		private string customText11;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText12;
		private string customText12;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText13;
		private string customText13;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText14;
		private string customText14;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText15;
		private string customText15;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText16;
		private string customText16;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText17;
		private string customText17;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText18;
		private string customText18;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText19;
		private string customText19;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText20;
		private string customText20;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText21;
		private string customText21;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText22;
		private string customText22;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText23;
		private string customText23;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText24;
		private string customText24;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String customText25;
		private string customText25;

		// Custom Dates:
		private DateTime customDate1;
		private DateTime customDate2;
		private DateTime customDate3;
		private DateTime customDate4;
		private DateTime customDate5;

		// Formulas: 
		private string titleFormula;
		private string descriptionFormula;
		private string measuredQuantityFormula;
		private string estimatedQuantityFormula;
		private string quantityFormula;
		private string markupFormula;
		private string durationFormula;
		private string productivityFormula;
		private string unitManhoursFormula;
		private string adjustedUnitManhoursFormula;
		private string totalCostFormula;
		private string offeredPriceFormula;
		private string prodFactorFormula;
		private string mhoursFactorFormula;
		private string adjustedProdFormula;
		private string rateFormula;
		private string offeredRateFormula;
		private string offeredSecondRateFormula;
		private string secondRateFormula;
		private string secondQuantityFormula;
		private string quantityLossFormula;
		private string secondUnitFormula;
		private string unitsDivFormula;
		private string assemblyTotalCostFormula;
		private string equipmentTotalCostFormula;
		private string materialTotalCostFormula;
		private string subcontractorTotalCostFormula;
		private string laborTotalCostFormula;
		private string consumableTotalCostFormula;

		private string wbsCodeFormula;
		private string wbs2CodeFormula;

		private string customRate1Formula;
		private string customRate2Formula;
		private string customRate3Formula;
		private string customRate4Formula;
		private string customRate5Formula;
		private string customRate6Formula;
		private string customRate7Formula;
		private string customRate8Formula;
		private string customRate9Formula;
		private string customRate10Formula;
		private string customRate11Formula;
		private string customRate12Formula;
		private string customRate13Formula;
		private string customRate14Formula;
		private string customRate15Formula;
		private string customRate16Formula;
		private string customRate17Formula;
		private string customRate18Formula;
		private string customRate19Formula;
		private string customRate20Formula;

		private string customCumRate1Formula;
		private string customCumRate2Formula;
		private string customCumRate3Formula;
		private string customCumRate4Formula;
		private string customCumRate5Formula;
		private string customCumRate6Formula;
		private string customCumRate7Formula;
		private string customCumRate8Formula;
		private string customCumRate9Formula;
		private string customCumRate10Formula;
		private string customCumRate11Formula;
		private string customCumRate12Formula;
		private string customCumRate13Formula;
		private string customCumRate14Formula;
		private string customCumRate15Formula;
		private string customCumRate16Formula;
		private string customCumRate17Formula;
		private string customCumRate18Formula;
		private string customCumRate19Formula;
		private string customCumRate20Formula;

		private string customPercentRate1Formula;
		private string customPercentRate2Formula;
		private string customPercentRate3Formula;
		private string customPercentRate4Formula;
		private string customPercentRate5Formula;
		private string customPercentRate6Formula;
		private string customPercentRate7Formula;
		private string customPercentRate8Formula;
		private string customPercentRate9Formula;
		private string customPercentRate10Formula;
		private string customPercentRate11Formula;
		private string customPercentRate12Formula;
		private string customPercentRate13Formula;
		private string customPercentRate14Formula;
		private string customPercentRate15Formula;
		private string customPercentRate16Formula;
		private string customPercentRate17Formula;
		private string customPercentRate18Formula;
		private string customPercentRate19Formula;
		private string customPercentRate20Formula;

		private string customText1Formula;
		private string customText2Formula;
		private string customText3Formula;
		private string customText4Formula;
		private string customText5Formula;
		private string customText6Formula;
		private string customText7Formula;
		private string customText8Formula;
		private string customText9Formula;
		private string customText10Formula;
		private string customText11Formula;
		private string customText12Formula;
		private string customText13Formula;
		private string customText14Formula;
		private string customText15Formula;
		private string customText16Formula;
		private string customText17Formula;
		private string customText18Formula;
		private string customText19Formula;
		private string customText20Formula;
		private string customText21Formula;
		private string customText22Formula;
		private string customText23Formula;
		private string customText24Formula;
		private string customText25Formula;

		private decimal puGroupCodeFactor;
		private decimal puGekCodeFactor;
		private decimal puExtraCode1Factor;
		private decimal puExtraCode2Factor;
		private decimal puExtraCode3Factor;
		private decimal puExtraCode4Factor;
		private decimal puExtraCode5Factor;
		private decimal puExtraCode6Factor;
		private decimal puExtraCode7Factor;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.boqitemDataFlavor};
		//	private transient HashMap o_map = new HashMap(0);

		public BoqItemTable() : base()
		{
		}

		//	public Map getRepresentationMap() {
		//		return o_map;
		//	}

		public virtual BoqItemTable Data
		{
			set
			{
				Code = value.Code;
				ParamItemCode = value.ParamItemCode;
				ParamItemId = value.ParamItemId;
				GlobalParamItemId = value.GlobalParamItemId;
				WorksheetLookup = value.WorksheetLookup;
				Title = value.Title;
				Quantity = value.Quantity;
				SecondQuantity = value.SecondQuantity;
				MeasuredQuantity = value.MeasuredQuantity;
				EstimatedQuantity = value.EstimatedQuantity;
				QuantityLoss = value.QuantityLoss;
				Duration = value.Duration;
				Unit = value.Unit;
				SecondUnit = value.SecondUnit;
				Markup = value.Markup;
				AwardedMaterialRate = value.AwardedMaterialRate;
				AwardedInsuranceRate = value.AwardedInsuranceRate;
				AwardedSubcontractorRate = value.AwardedSubcontractorRate;
				AwardedManhours = value.AwardedManhours;
				AwardedShipmentRate = value.AwardedShipmentRate;
				AwardedIndirectRate = value.AwardedIndirectRate;
				AwardedTotalRate = value.AwardedTotalRate;
				EscalationCost = value.EscalationCost;
				UnitsDiv = value.UnitsDiv;
				Productivity = value.Productivity;
				AdjustedProd = value.AdjustedProd;
				ProdFactor = value.ProdFactor;
				MhoursFactor = value.MhoursFactor;
				LocFactor = value.LocFactor;
				LocProfile = value.LocProfile;
				LocCountry = value.LocCountry;
				LocState = value.LocState;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				PublishedItemCode = value.PublishedItemCode;
				PlanningType = value.PlanningType;
				PublishedRate = value.PublishedRate;
				PublishedRevisionCode = value.PublishedRevisionCode;
				Notes = value.Notes;
				SurfaceType = value.SurfaceType;
				Status = value.Status;
				Flag = value.Flag;
				CalculationType = value.CalculationType;
				ActivityBased = value.ActivityBased;
    
				HasAssignmentFormula = value.HasAssignmentFormula;
				HasPVFormula = value.HasPVFormula;
				PvVars = value.PvVars;
    
				Description = value.Description;
				BimMaterial = value.BimMaterial;
				BimType = value.BimType;
				CalculatedRate = value.CalculatedRate;
				CalculatedTotalCost = value.CalculatedTotalCost;
    
				PaymentDate = value.PaymentDate;
				LastUpdate = value.LastUpdate;
				EditorId = value.EditorId;
				EstimatorId = value.EstimatorId;
    
				RollUP = value.RollUP;
				Location = value.Location;
    
				ExtraCode1 = value.ExtraCode1;
				ExtraCode2 = value.ExtraCode2;
				WbsCode = value.WbsCode;
				Wbs2Code = value.Wbs2Code;
				ExtraCode3 = value.ExtraCode3;
				ExtraCode4 = value.ExtraCode4;
				ExtraCode5 = value.ExtraCode5;
				ExtraCode6 = value.ExtraCode6;
				ExtraCode7 = value.ExtraCode7;
				ExtraCode8 = value.ExtraCode8;
				ExtraCode9 = value.ExtraCode9;
				ExtraCode10 = value.ExtraCode10;
    
				PuGroupCodeFactor = value.PuGroupCodeFactor;
				PuGekCodeFactor = value.PuGekCodeFactor;
				PuExtraCode1Factor = value.PuExtraCode1Factor;
				PuExtraCode2Factor = value.PuExtraCode2Factor;
				PuExtraCode3Factor = value.PuExtraCode3Factor;
				PuExtraCode4Factor = value.PuExtraCode4Factor;
				PuExtraCode5Factor = value.PuExtraCode5Factor;
				PuExtraCode6Factor = value.PuExtraCode6Factor;
				PuExtraCode7Factor = value.PuExtraCode7Factor;
    
				if (!string.ReferenceEquals(value.GenerationId, null))
				{
					GenerationId = value.GenerationId;
				}
				// Fields stored that are not editable:
				if (value.CreateDate != null)
				{
					CreateDate = value.CreateDate;
					CreateUserId = value.CreateUserId;
				}
				//		if ( value.getActivityId() != null && !value.getActivityId().equals("") ) {
				//			setActivityId(value.getActivityId());
				//		}
				if (!string.ReferenceEquals(value.Accuracy, null))
				{
					Accuracy = value.Accuracy;
				}
				//		if ( value.getEstimRate() != null ) {
				//			setEstimRate(value.getEstimRate());
				//			setEstimAssemblyRate(value.getEstimAssemblyRate());
				//			setEstimEquipmentRate(value.getEstimEquipmentRate());
				//			setEstimMaterialRate(value.getEstimMaterialRate());
				//			setEstimFabricationRate(value.getEstimFabricationRate());
				//			setEstimShipmentRate(value.getEstimShipmentRate());			
				//			setEstimSubcontractorRate(value.getEstimSubcontractorRate());
				//			setEstimConsumableRate(value.getEstimConsumableRate());
				//			setEstimLaborRate(value.getEstimLaborRate());
				//			setQuotedMaterialRate(value.getQuotedMaterialRate());
				//			setQuotedSubcontractorRate(value.getQuotedSubcontractorRate());
				//
				//			setEstimMaterialTotalCost(value.getEstimMaterialTotalCost());
				//			setEstimSubcontractorTotalCost(value.getEstimSubcontractorTotalCost());				
				//			setEstimFabricationTotalCost(value.getEstimFabricationTotalCost());
				//			setEstimShipmentTotalCost(value.getEstimShipmentTotalCost());			
				//			setEstimLaborTotalCost(value.getEstimLaborTotalCost());
				//			setEstimAssemblyTotalCost(value.getEstimAssemblyTotalCost());
				//			setEstimConsumableTotalCost(value.getEstimConsumableTotalCost());
				//			setEstimEquipmentTotalCost(value.getEstimEquipmentTotalCost());
				//			setQuotedMaterialTotalCost(value.getQuotedMaterialTotalCost());
				//			setQuotedSubcontractorTotalCost(value.getQuotedSubcontractorTotalCost());
				//			setEstimTotalCost(value.getEstimTotalCost());
				//
				//		}
    
				Rate = value.Rate;
				TotalCost = value.TotalCost;
				FixedCost = value.FixedCost;
				OfferedPrice = value.OfferedPrice;
				OfferedRate = value.OfferedRate;
				SecondRate = value.SecondRate;
				OfferedSecondRate = value.OfferedSecondRate;
				AssemblyRate = value.AssemblyRate;
				LaborRate = value.LaborRate;
				SubcontractorRate = value.SubcontractorRate;
				QuotedSubcontractorRate = value.QuotedSubcontractorRate;
				EquipmentRate = value.EquipmentRate;
				ConsumableRate = value.ConsumableRate;
				AssemblyTotalCost = value.AssemblyTotalCost;
				LaborTotalCost = value.LaborTotalCost;
				SubcontractorTotalCost = value.SubcontractorTotalCost;
				EquipmentTotalCost = value.EquipmentTotalCost;
				ConsumableTotalCost = value.ConsumableTotalCost;
				MaterialTotalCost = value.MaterialTotalCost;
				FabricationTotalCost = value.FabricationTotalCost;
				MaterialResourceTotalCost = value.MaterialResourceTotalCost;
				ShipmentTotalCost = value.ShipmentTotalCost;
				MaterialRate = value.MaterialRate;
				QuotedMaterialRate = value.QuotedMaterialRate;
				FabricationRate = value.FabricationRate;
				ShipmentRate = value.ShipmentRate;
    
				CustomRate1 = value.CustomRate1;
				CustomRate2 = value.CustomRate2;
				CustomRate3 = value.CustomRate3;
				CustomRate4 = value.CustomRate4;
				CustomRate5 = value.CustomRate5;
				CustomRate6 = value.CustomRate6;
				CustomRate7 = value.CustomRate7;
				CustomRate8 = value.CustomRate8;
				CustomRate9 = value.CustomRate9;
				CustomRate10 = value.CustomRate10;
				CustomRate11 = value.CustomRate11;
				CustomRate12 = value.CustomRate12;
				CustomRate13 = value.CustomRate13;
				CustomRate14 = value.CustomRate14;
				CustomRate15 = value.CustomRate15;
				CustomRate16 = value.CustomRate16;
				CustomRate17 = value.CustomRate17;
				CustomRate18 = value.CustomRate18;
				CustomRate19 = value.CustomRate19;
				CustomRate20 = value.CustomRate20;
    
				CustomCumRate1 = value.CustomCumRate1;
				CustomCumRate2 = value.CustomCumRate2;
				CustomCumRate3 = value.CustomCumRate3;
				CustomCumRate4 = value.CustomCumRate4;
				CustomCumRate5 = value.CustomCumRate5;
				CustomCumRate6 = value.CustomCumRate6;
				CustomCumRate7 = value.CustomCumRate7;
				CustomCumRate8 = value.CustomCumRate8;
				CustomCumRate9 = value.CustomCumRate9;
				CustomCumRate10 = value.CustomCumRate10;
				CustomCumRate11 = value.CustomCumRate11;
				CustomCumRate12 = value.CustomCumRate12;
				CustomCumRate13 = value.CustomCumRate13;
				CustomCumRate14 = value.CustomCumRate14;
				CustomCumRate15 = value.CustomCumRate15;
				CustomCumRate16 = value.CustomCumRate16;
				CustomCumRate17 = value.CustomCumRate17;
				CustomCumRate18 = value.CustomCumRate18;
				CustomCumRate19 = value.CustomCumRate19;
				CustomCumRate20 = value.CustomCumRate20;
    
				CustomPercentRate1 = value.CustomPercentRate1;
				CustomPercentRate2 = value.CustomPercentRate2;
				CustomPercentRate3 = value.CustomPercentRate3;
				CustomPercentRate4 = value.CustomPercentRate4;
				CustomPercentRate5 = value.CustomPercentRate5;
				CustomPercentRate6 = value.CustomPercentRate6;
				CustomPercentRate7 = value.CustomPercentRate7;
				CustomPercentRate8 = value.CustomPercentRate8;
				CustomPercentRate9 = value.CustomPercentRate9;
				CustomPercentRate10 = value.CustomPercentRate10;
				CustomPercentRate11 = value.CustomPercentRate11;
				CustomPercentRate12 = value.CustomPercentRate12;
				CustomPercentRate13 = value.CustomPercentRate13;
				CustomPercentRate14 = value.CustomPercentRate14;
				CustomPercentRate15 = value.CustomPercentRate15;
				CustomPercentRate16 = value.CustomPercentRate16;
				CustomPercentRate17 = value.CustomPercentRate17;
				CustomPercentRate18 = value.CustomPercentRate18;
				CustomPercentRate19 = value.CustomPercentRate19;
				CustomPercentRate20 = value.CustomPercentRate20;
    
				CustomText1 = value.CustomText1;
				CustomText2 = value.CustomText2;
				CustomText3 = value.CustomText3;
				CustomText4 = value.CustomText4;
				CustomText5 = value.CustomText5;
				CustomText6 = value.CustomText6;
				CustomText7 = value.CustomText7;
				CustomText8 = value.CustomText8;
				CustomText9 = value.CustomText9;
				CustomText10 = value.CustomText10;
				CustomText11 = value.CustomText11;
				CustomText12 = value.CustomText12;
				CustomText13 = value.CustomText13;
				CustomText14 = value.CustomText14;
				CustomText15 = value.CustomText15;
				CustomText16 = value.CustomText16;
				CustomText17 = value.CustomText17;
				CustomText18 = value.CustomText18;
				CustomText19 = value.CustomText19;
				CustomText20 = value.CustomText20;
				CustomText21 = value.CustomText21;
				CustomText22 = value.CustomText22;
				CustomText23 = value.CustomText23;
				CustomText24 = value.CustomText24;
				CustomText25 = value.CustomText25;
    
				CustomDate1 = value.CustomDate1;
				CustomDate2 = value.CustomDate2;
				CustomDate3 = value.CustomDate3;
				CustomDate4 = value.CustomDate4;
				CustomDate5 = value.CustomDate5;
    
				TitleFormula = value.TitleFormula;
				DescriptionFormula = value.DescriptionFormula;
				BimMaterial = value.BimMaterial;
				BimType = value.BimType;
				QuantityFormula = value.QuantityFormula;
				MeasuredQuantityFormula = value.MeasuredQuantityFormula;
				EstimatedQuantityFormula = value.EstimatedQuantityFormula;
				MarkupFormula = value.MarkupFormula;
				ProductivityFormula = value.ProductivityFormula;
				UnitManhoursFormula = value.UnitManhoursFormula;
				AdjustedUnitManhoursFormula = value.AdjustedUnitManhoursFormula;
				AdjustedProdFormula = value.AdjustedProdFormula;
				ProdFactorFormula = value.ProdFactorFormula;
				MhoursFactorFormula = value.MhoursFactorFormula;
    
				WbsCodeFormula = value.WbsCodeFormula;
				Wbs2CodeFormula = value.Wbs2CodeFormula;
				TotalCostFormula = value.TotalCostFormula;
				DurationFormula = value.DurationFormula;
				OfferedPriceFormula = value.OfferedPriceFormula;
    
				RateFormula = value.RateFormula;
				SecondRateFormula = value.SecondRateFormula;
				OfferedRateFormula = value.OfferedRateFormula;
				OfferedSecondRateFormula = value.OfferedSecondRateFormula;
				SecondQuantityFormula = value.SecondQuantityFormula;
				QuantityLossFormula = value.QuantityLossFormula;
				SecondUnitFormula = value.SecondUnitFormula;
				UnitsDivFormula = value.UnitsDivFormula;
				AssemblyTotalCostFormula = value.AssemblyTotalCostFormula;
				EquipmentTotalCostFormula = value.EquipmentTotalCostFormula;
				SubcontractorTotalCostFormula = value.SubcontractorTotalCostFormula;
				LaborTotalCostFormula = value.LaborTotalCostFormula;
				MaterialTotalCostFormula = value.MaterialTotalCostFormula;
				ConsumableTotalCostFormula = value.ConsumableTotalCostFormula;
    
				CustomRate1Formula = value.CustomRate1Formula;
				CustomRate2Formula = value.CustomRate2Formula;
				CustomRate3Formula = value.CustomRate3Formula;
				CustomRate4Formula = value.CustomRate4Formula;
				CustomRate5Formula = value.CustomRate5Formula;
				CustomRate6Formula = value.CustomRate6Formula;
				CustomRate7Formula = value.CustomRate7Formula;
				CustomRate8Formula = value.CustomRate8Formula;
				CustomRate9Formula = value.CustomRate9Formula;
				CustomRate10Formula = value.CustomRate10Formula;
				CustomRate11Formula = value.CustomRate11Formula;
				CustomRate12Formula = value.CustomRate12Formula;
				CustomRate13Formula = value.CustomRate13Formula;
				CustomRate14Formula = value.CustomRate14Formula;
				CustomRate15Formula = value.CustomRate15Formula;
				CustomRate16Formula = value.CustomRate16Formula;
				CustomRate17Formula = value.CustomRate17Formula;
				CustomRate18Formula = value.CustomRate18Formula;
				CustomRate19Formula = value.CustomRate19Formula;
				CustomRate20Formula = value.CustomRate20Formula;
    
				CustomCumRate1Formula = value.CustomCumRate1Formula;
				CustomCumRate2Formula = value.CustomCumRate2Formula;
				CustomCumRate3Formula = value.CustomCumRate3Formula;
				CustomCumRate4Formula = value.CustomCumRate4Formula;
				CustomCumRate5Formula = value.CustomCumRate5Formula;
				CustomCumRate6Formula = value.CustomCumRate6Formula;
				CustomCumRate7Formula = value.CustomCumRate7Formula;
				CustomCumRate8Formula = value.CustomCumRate8Formula;
				CustomCumRate9Formula = value.CustomCumRate9Formula;
				CustomCumRate10Formula = value.CustomCumRate10Formula;
				CustomCumRate11Formula = value.CustomCumRate11Formula;
				CustomCumRate12Formula = value.CustomCumRate12Formula;
				CustomCumRate13Formula = value.CustomCumRate13Formula;
				CustomCumRate14Formula = value.CustomCumRate14Formula;
				CustomCumRate15Formula = value.CustomCumRate15Formula;
				CustomCumRate16Formula = value.CustomCumRate16Formula;
				CustomCumRate17Formula = value.CustomCumRate17Formula;
				CustomCumRate18Formula = value.CustomCumRate18Formula;
				CustomCumRate19Formula = value.CustomCumRate19Formula;
				CustomCumRate20Formula = value.CustomCumRate20Formula;
    
				CustomPercentRate1Formula = value.CustomPercentRate1Formula;
				CustomPercentRate2Formula = value.CustomPercentRate2Formula;
				CustomPercentRate3Formula = value.CustomPercentRate3Formula;
				CustomPercentRate4Formula = value.CustomPercentRate4Formula;
				CustomPercentRate5Formula = value.CustomPercentRate5Formula;
				CustomPercentRate6Formula = value.CustomPercentRate6Formula;
				CustomPercentRate7Formula = value.CustomPercentRate7Formula;
				CustomPercentRate8Formula = value.CustomPercentRate8Formula;
				CustomPercentRate9Formula = value.CustomPercentRate9Formula;
				CustomPercentRate10Formula = value.CustomPercentRate10Formula;
				CustomPercentRate11Formula = value.CustomPercentRate11Formula;
				CustomPercentRate12Formula = value.CustomPercentRate12Formula;
				CustomPercentRate13Formula = value.CustomPercentRate13Formula;
				CustomPercentRate14Formula = value.CustomPercentRate14Formula;
				CustomPercentRate15Formula = value.CustomPercentRate15Formula;
				CustomPercentRate16Formula = value.CustomPercentRate16Formula;
				CustomPercentRate17Formula = value.CustomPercentRate17Formula;
				CustomPercentRate18Formula = value.CustomPercentRate18Formula;
				CustomPercentRate19Formula = value.CustomPercentRate19Formula;
				CustomPercentRate20Formula = value.CustomPercentRate20Formula;
    
				CustomText1Formula = value.CustomText1Formula;
				CustomText2Formula = value.CustomText2Formula;
				CustomText3Formula = value.CustomText3Formula;
				CustomText4Formula = value.CustomText4Formula;
				CustomText5Formula = value.CustomText5Formula;
				CustomText6Formula = value.CustomText6Formula;
				CustomText7Formula = value.CustomText7Formula;
				CustomText8Formula = value.CustomText8Formula;
				CustomText9Formula = value.CustomText9Formula;
				CustomText10Formula = value.CustomText10Formula;
				CustomText11Formula = value.CustomText11Formula;
				CustomText12Formula = value.CustomText12Formula;
				CustomText13Formula = value.CustomText13Formula;
				CustomText14Formula = value.CustomText14Formula;
				CustomText15Formula = value.CustomText15Formula;
				CustomText16Formula = value.CustomText16Formula;
				CustomText17Formula = value.CustomText17Formula;
				CustomText18Formula = value.CustomText18Formula;
				CustomText19Formula = value.CustomText19Formula;
				CustomText20Formula = value.CustomText20Formula;
				CustomText21Formula = value.CustomText21Formula;
				CustomText22Formula = value.CustomText22Formula;
				CustomText23Formula = value.CustomText23Formula;
				CustomText24Formula = value.CustomText24Formula;
				CustomText25Formula = value.CustomText25Formula;
    
				AssemblyRateType = value.AssemblyRateType;
				EquipmentRateType = value.EquipmentRateType;
				SubcontractorRateType = value.SubcontractorRateType;
    
				LaborRateType = value.LaborRateType;
				MaterialRateType = value.MaterialRateType;
				ConsumableRateType = value.ConsumableRateType;
				TakeoffQuantityType = value.TakeoffQuantityType;
    
				Vars = value.Vars;
			}
		}

		public virtual decimal calculateQuantityLoss()
		{
			if (EstimatedQuantity == null || MeasuredQuantity == null)
			{
				return BigDecimalMath.ZERO;
			}
			return BigDecimalMath.abs(EstimatedQuantity - MeasuredQuantity);
		}

		public virtual object clone()
		{
			BoqItemTable obj = new BoqItemTable();

			obj.BoqitemId = BoqitemId;
			obj.Code = Code;
			obj.ParamItemCode = ParamItemCode;
			obj.ParamItemId = ParamItemId;
			obj.GlobalParamItemId = GlobalParamItemId;
			obj.WorksheetLookup = WorksheetLookup;
			obj.Title = Title;
			obj.CalculationType = CalculationType;
			obj.ActivityBased = ActivityBased;
			obj.HasProductivity = HasProductivity;
			obj.IsScheduled = IsScheduled;

			obj.HasAssignmentFormula = HasAssignmentFormula;
			obj.HasPVFormula = HasPVFormula;
			obj.PvVars = PvVars;

			obj.Quantity = Quantity;
			obj.SecondQuantity = SecondQuantity;
			obj.MeasuredQuantity = MeasuredQuantity;

			obj.EstimatedQuantity = EstimatedQuantity;
			obj.EstimatedQuantityFormula = EstimatedQuantityFormula;

			obj.QuantityLoss = QuantityLoss;
			obj.UnitsDiv = UnitsDiv;
			obj.Markup = Markup;
			obj.AwardedMaterialRate = AwardedMaterialRate;
			obj.AwardedInsuranceRate = AwardedInsuranceRate;
			obj.AwardedSubcontractorRate = AwardedSubcontractorRate;
			obj.AwardedManhours = AwardedManhours;
			obj.AwardedShipmentRate = AwardedShipmentRate;
			obj.AwardedIndirectRate = AwardedIndirectRate;
			obj.AwardedTotalRate = AwardedTotalRate;

			obj.EscalationCost = EscalationCost;
			obj.Duration = Duration;
			obj.DurationFormula = DurationFormula;
			//obj.setRate(getRate());
			obj.Unit = Unit;
			obj.SecondUnit = SecondUnit;
			obj.Productivity = Productivity;
			obj.AdjustedProd = AdjustedProd;
			obj.ProdFactor = ProdFactor;
			obj.MhoursFactor = MhoursFactor;
			obj.LocFactor = LocFactor;
			obj.LocProfile = LocProfile;
			obj.LocCountry = LocCountry;
			obj.LocState = LocState;
			obj.LaborManhours = LaborManhours;
			obj.EquipmentHours = EquipmentHours;
			obj.UnitManhours = UnitManhours;
			obj.AdjustedUnitManhours = AdjustedUnitManhours;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.PublishedItemCode = PublishedItemCode;
			//obj.setActivityId(getActivityId());		
			obj.GenerationId = GenerationId;
			obj.PlanningType = PlanningType;
			obj.PublishedRate = PublishedRate;
			obj.PublishedRevisionCode = PublishedRevisionCode;
			obj.Notes = Notes;
			obj.SurfaceType = SurfaceType;
			obj.Status = Status;
			obj.Flag = Flag;
			obj.Description = Description;
			obj.BimMaterial = BimMaterial;
			obj.BimType = BimType;
			obj.CalculatedRate = CalculatedRate;
			obj.CalculatedTotalCost = CalculatedTotalCost;

			obj.PaymentDate = PaymentDate;
			obj.LastUpdate = LastUpdate;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.EditorId = EditorId;
			obj.EstimatorId = EstimatorId;
			obj.Location = Location;
			obj.Accuracy = Accuracy;
			obj.RollUP = RollUP;

			obj.ExtraCode1 = ExtraCode1;
			obj.ExtraCode2 = ExtraCode2;
			obj.WbsCode = WbsCode;
			obj.Wbs2Code = Wbs2Code;
			obj.ExtraCode3 = ExtraCode3;
			obj.ExtraCode4 = ExtraCode4;
			obj.ExtraCode5 = ExtraCode5;
			obj.ExtraCode6 = ExtraCode6;
			obj.ExtraCode7 = ExtraCode7;
			obj.ExtraCode8 = ExtraCode8;
			obj.ExtraCode9 = ExtraCode9;
			obj.ExtraCode10 = ExtraCode10;

			obj.PuGroupCodeFactor = PuGroupCodeFactor;
			obj.PuGekCodeFactor = PuGekCodeFactor;
			obj.PuExtraCode1Factor = PuExtraCode1Factor;
			obj.PuExtraCode2Factor = PuExtraCode2Factor;
			obj.PuExtraCode3Factor = PuExtraCode3Factor;
			obj.PuExtraCode4Factor = PuExtraCode4Factor;
			obj.PuExtraCode5Factor = PuExtraCode5Factor;
			obj.PuExtraCode6Factor = PuExtraCode6Factor;
			obj.PuExtraCode7Factor = PuExtraCode7Factor;

			obj.Rate = Rate;
			obj.TotalCost = TotalCost;
			obj.FixedCost = FixedCost;
			obj.OfferedPrice = OfferedPrice;
			obj.OfferedRate = OfferedRate;
			obj.SecondRate = SecondRate;
			obj.OfferedSecondRate = OfferedSecondRate;
			obj.AssemblyRate = AssemblyRate;
			obj.LaborRate = LaborRate;
			obj.SubcontractorRate = SubcontractorRate;
			obj.QuotedSubcontractorRate = QuotedSubcontractorRate;

			obj.EquipmentRate = EquipmentRate;
			obj.ConsumableRate = ConsumableRate;
			obj.AssemblyTotalCost = AssemblyTotalCost;
			obj.LaborTotalCost = LaborTotalCost;
			obj.SubcontractorTotalCost = SubcontractorTotalCost;
			obj.EquipmentTotalCost = EquipmentTotalCost;
			obj.ConsumableTotalCost = ConsumableTotalCost;
			obj.MaterialTotalCost = MaterialTotalCost;
			obj.FabricationTotalCost = FabricationTotalCost;
			obj.MaterialResourceTotalCost = MaterialResourceTotalCost;
			obj.ShipmentTotalCost = ShipmentTotalCost;
			obj.MaterialRate = MaterialRate;
			obj.QuotedMaterialRate = QuotedMaterialRate;
			obj.FabricationRate = FabricationRate;
			obj.ShipmentRate = ShipmentRate;

			// Custom Fields
			obj.CustomRate1 = CustomRate1;
			obj.CustomRate2 = CustomRate2;
			obj.CustomRate3 = CustomRate3;
			obj.CustomRate4 = CustomRate4;
			obj.CustomRate5 = CustomRate5;
			obj.CustomRate6 = CustomRate6;
			obj.CustomRate7 = CustomRate7;
			obj.CustomRate8 = CustomRate8;
			obj.CustomRate9 = CustomRate9;
			obj.CustomRate10 = CustomRate10;
			obj.CustomRate11 = CustomRate11;
			obj.CustomRate12 = CustomRate12;
			obj.CustomRate13 = CustomRate13;
			obj.CustomRate14 = CustomRate14;
			obj.CustomRate15 = CustomRate15;
			obj.CustomRate16 = CustomRate16;
			obj.CustomRate17 = CustomRate17;
			obj.CustomRate18 = CustomRate18;
			obj.CustomRate19 = CustomRate19;
			obj.CustomRate20 = CustomRate20;

			obj.CustomCumRate1 = CustomCumRate1;
			obj.CustomCumRate2 = CustomCumRate2;
			obj.CustomCumRate3 = CustomCumRate3;
			obj.CustomCumRate4 = CustomCumRate4;
			obj.CustomCumRate5 = CustomCumRate5;
			obj.CustomCumRate6 = CustomCumRate6;
			obj.CustomCumRate7 = CustomCumRate7;
			obj.CustomCumRate8 = CustomCumRate8;
			obj.CustomCumRate9 = CustomCumRate9;
			obj.CustomCumRate10 = CustomCumRate10;
			obj.CustomCumRate11 = CustomCumRate11;
			obj.CustomCumRate12 = CustomCumRate12;
			obj.CustomCumRate13 = CustomCumRate13;
			obj.CustomCumRate14 = CustomCumRate14;
			obj.CustomCumRate15 = CustomCumRate15;
			obj.CustomCumRate16 = CustomCumRate16;
			obj.CustomCumRate17 = CustomCumRate17;
			obj.CustomCumRate18 = CustomCumRate18;
			obj.CustomCumRate19 = CustomCumRate19;
			obj.CustomCumRate20 = CustomCumRate20;

			obj.CustomPercentRate1 = CustomPercentRate1;
			obj.CustomPercentRate2 = CustomPercentRate2;
			obj.CustomPercentRate3 = CustomPercentRate3;
			obj.CustomPercentRate4 = CustomPercentRate4;
			obj.CustomPercentRate5 = CustomPercentRate5;
			obj.CustomPercentRate6 = CustomPercentRate6;
			obj.CustomPercentRate7 = CustomPercentRate7;
			obj.CustomPercentRate8 = CustomPercentRate8;
			obj.CustomPercentRate9 = CustomPercentRate9;
			obj.CustomPercentRate10 = CustomPercentRate10;
			obj.CustomPercentRate11 = CustomPercentRate11;
			obj.CustomPercentRate12 = CustomPercentRate12;
			obj.CustomPercentRate13 = CustomPercentRate13;
			obj.CustomPercentRate14 = CustomPercentRate14;
			obj.CustomPercentRate15 = CustomPercentRate15;
			obj.CustomPercentRate16 = CustomPercentRate16;
			obj.CustomPercentRate17 = CustomPercentRate17;
			obj.CustomPercentRate18 = CustomPercentRate18;
			obj.CustomPercentRate19 = CustomPercentRate19;
			obj.CustomPercentRate20 = CustomPercentRate20;

			obj.CustomText1 = CustomText1;
			obj.CustomText2 = CustomText2;
			obj.CustomText3 = CustomText3;
			obj.CustomText4 = CustomText4;
			obj.CustomText5 = CustomText5;
			obj.CustomText6 = CustomText6;
			obj.CustomText7 = CustomText7;
			obj.CustomText8 = CustomText8;
			obj.CustomText9 = CustomText9;
			obj.CustomText10 = CustomText10;
			obj.CustomText11 = CustomText11;
			obj.CustomText12 = CustomText12;
			obj.CustomText13 = CustomText13;
			obj.CustomText14 = CustomText14;
			obj.CustomText15 = CustomText15;
			obj.CustomText16 = CustomText16;
			obj.CustomText17 = CustomText17;
			obj.CustomText18 = CustomText18;
			obj.CustomText19 = CustomText19;
			obj.CustomText20 = CustomText20;
			obj.CustomText21 = CustomText21;
			obj.CustomText22 = CustomText22;
			obj.CustomText23 = CustomText23;
			obj.CustomText24 = CustomText24;
			obj.CustomText25 = CustomText25;

			obj.CustomDate1 = CustomDate1;
			obj.CustomDate2 = CustomDate2;
			obj.CustomDate3 = CustomDate3;
			obj.CustomDate4 = CustomDate4;
			obj.CustomDate5 = CustomDate5;

			// Set Formulas
			obj.ProductivityFormula = ProductivityFormula;
			obj.UnitManhoursFormula = UnitManhoursFormula;
			obj.AdjustedUnitManhoursFormula = AdjustedUnitManhoursFormula;
			obj.AdjustedProdFormula = AdjustedProdFormula;
			obj.ProdFactorFormula = ProdFactorFormula;
			obj.MhoursFactorFormula = MhoursFactorFormula;
			obj.DurationFormula = DurationFormula;
			obj.MarkupFormula = MarkupFormula;

			obj.TitleFormula = TitleFormula;
			obj.DescriptionFormula = DescriptionFormula;
			obj.QuantityFormula = QuantityFormula;
			obj.MeasuredQuantityFormula = MeasuredQuantityFormula;
			obj.EstimatedQuantityFormula = EstimatedQuantityFormula;
			obj.TotalCostFormula = TotalCostFormula;
			obj.OfferedPriceFormula = OfferedPriceFormula;

			obj.WbsCodeFormula = WbsCodeFormula;
			obj.Wbs2CodeFormula = Wbs2CodeFormula;
			obj.RateFormula = RateFormula;
			obj.SecondRateFormula = SecondRateFormula;
			obj.OfferedRateFormula = OfferedRateFormula;
			obj.OfferedSecondRateFormula = OfferedSecondRateFormula;
			obj.SecondQuantityFormula = SecondQuantityFormula;
			obj.QuantityLossFormula = QuantityLossFormula;
			obj.SecondUnitFormula = SecondUnitFormula;
			obj.UnitsDivFormula = UnitsDivFormula;
			obj.AssemblyTotalCostFormula = AssemblyTotalCostFormula;
			obj.EquipmentTotalCostFormula = EquipmentTotalCostFormula;
			obj.SubcontractorTotalCostFormula = SubcontractorTotalCostFormula;
			obj.LaborTotalCostFormula = LaborTotalCostFormula;
			obj.MaterialTotalCostFormula = MaterialTotalCostFormula;
			obj.ConsumableTotalCostFormula = ConsumableTotalCostFormula;

			obj.CustomRate1Formula = CustomRate1Formula;
			obj.CustomRate2Formula = CustomRate2Formula;
			obj.CustomRate3Formula = CustomRate3Formula;
			obj.CustomRate4Formula = CustomRate4Formula;
			obj.CustomRate5Formula = CustomRate5Formula;
			obj.CustomRate6Formula = CustomRate6Formula;
			obj.CustomRate7Formula = CustomRate7Formula;
			obj.CustomRate8Formula = CustomRate8Formula;
			obj.CustomRate9Formula = CustomRate9Formula;
			obj.CustomRate10Formula = CustomRate10Formula;
			obj.CustomRate11Formula = CustomRate11Formula;
			obj.CustomRate12Formula = CustomRate12Formula;
			obj.CustomRate13Formula = CustomRate13Formula;
			obj.CustomRate14Formula = CustomRate14Formula;
			obj.CustomRate15Formula = CustomRate15Formula;
			obj.CustomRate16Formula = CustomRate16Formula;
			obj.CustomRate17Formula = CustomRate17Formula;
			obj.CustomRate18Formula = CustomRate18Formula;
			obj.CustomRate19Formula = CustomRate19Formula;
			obj.CustomRate20Formula = CustomRate20Formula;

			obj.CustomCumRate1Formula = CustomCumRate1Formula;
			obj.CustomCumRate2Formula = CustomCumRate2Formula;
			obj.CustomCumRate3Formula = CustomCumRate3Formula;
			obj.CustomCumRate4Formula = CustomCumRate4Formula;
			obj.CustomCumRate5Formula = CustomCumRate5Formula;
			obj.CustomCumRate6Formula = CustomCumRate6Formula;
			obj.CustomCumRate7Formula = CustomCumRate7Formula;
			obj.CustomCumRate8Formula = CustomCumRate8Formula;
			obj.CustomCumRate9Formula = CustomCumRate9Formula;
			obj.CustomCumRate10Formula = CustomCumRate10Formula;
			obj.CustomCumRate11Formula = CustomCumRate11Formula;
			obj.CustomCumRate12Formula = CustomCumRate12Formula;
			obj.CustomCumRate13Formula = CustomCumRate13Formula;
			obj.CustomCumRate14Formula = CustomCumRate14Formula;
			obj.CustomCumRate15Formula = CustomCumRate15Formula;
			obj.CustomCumRate16Formula = CustomCumRate16Formula;
			obj.CustomCumRate17Formula = CustomCumRate17Formula;
			obj.CustomCumRate18Formula = CustomCumRate18Formula;
			obj.CustomCumRate19Formula = CustomCumRate19Formula;
			obj.CustomCumRate20Formula = CustomCumRate20Formula;

			obj.CustomPercentRate1Formula = CustomPercentRate1Formula;
			obj.CustomPercentRate2Formula = CustomPercentRate2Formula;
			obj.CustomPercentRate3Formula = CustomPercentRate3Formula;
			obj.CustomPercentRate4Formula = CustomPercentRate4Formula;
			obj.CustomPercentRate5Formula = CustomPercentRate5Formula;
			obj.CustomPercentRate6Formula = CustomPercentRate6Formula;
			obj.CustomPercentRate7Formula = CustomPercentRate7Formula;
			obj.CustomPercentRate8Formula = CustomPercentRate8Formula;
			obj.CustomPercentRate9Formula = CustomPercentRate9Formula;
			obj.CustomPercentRate10Formula = CustomPercentRate10Formula;
			obj.CustomPercentRate11Formula = CustomPercentRate11Formula;
			obj.CustomPercentRate12Formula = CustomPercentRate12Formula;
			obj.CustomPercentRate13Formula = CustomPercentRate13Formula;
			obj.CustomPercentRate14Formula = CustomPercentRate14Formula;
			obj.CustomPercentRate15Formula = CustomPercentRate15Formula;
			obj.CustomPercentRate16Formula = CustomPercentRate16Formula;
			obj.CustomPercentRate17Formula = CustomPercentRate17Formula;
			obj.CustomPercentRate18Formula = CustomPercentRate18Formula;
			obj.CustomPercentRate19Formula = CustomPercentRate19Formula;
			obj.CustomPercentRate20Formula = CustomPercentRate20Formula;

			obj.CustomText1Formula = CustomText1Formula;
			obj.CustomText2Formula = CustomText2Formula;
			obj.CustomText3Formula = CustomText3Formula;
			obj.CustomText4Formula = CustomText4Formula;
			obj.CustomText5Formula = CustomText5Formula;
			obj.CustomText6Formula = CustomText6Formula;
			obj.CustomText7Formula = CustomText7Formula;
			obj.CustomText8Formula = CustomText8Formula;
			obj.CustomText9Formula = CustomText9Formula;
			obj.CustomText10Formula = CustomText10Formula;
			obj.CustomText11Formula = CustomText11Formula;
			obj.CustomText12Formula = CustomText12Formula;
			obj.CustomText13Formula = CustomText13Formula;
			obj.CustomText14Formula = CustomText14Formula;
			obj.CustomText15Formula = CustomText15Formula;
			obj.CustomText16Formula = CustomText16Formula;
			obj.CustomText17Formula = CustomText17Formula;
			obj.CustomText18Formula = CustomText18Formula;
			obj.CustomText19Formula = CustomText19Formula;
			obj.CustomText20Formula = CustomText20Formula;
			obj.CustomText21Formula = CustomText21Formula;
			obj.CustomText22Formula = CustomText22Formula;
			obj.CustomText23Formula = CustomText23Formula;
			obj.CustomText24Formula = CustomText24Formula;
			obj.CustomText25Formula = CustomText25Formula;

			obj.AssemblyRateType = AssemblyRateType;
			obj.EquipmentRateType = EquipmentRateType;
			obj.SubcontractorRateType = SubcontractorRateType;
			obj.LaborRateType = LaborRateType;
			obj.MaterialRateType = MaterialRateType;
			obj.ConsumableRateType = ConsumableRateType;
			obj.TakeoffQuantityType = TakeoffQuantityType;

			obj.Vars = Vars;

			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual object deepCopyWithParamItems(bool ciclic, bool copyHistory, bool copyQuoteItemRelations)
		{
			BoqItemTable obj = (BoqItemTable) deepCopy(ciclic, copyHistory, copyQuoteItemRelations);

			if (ParamItemSet != null)
			{

				obj.paramItemSet = new HashSet<object>(2);
				System.Collections.IEnumerator iter = ParamItemSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ParamItemTable cur = (ParamItemTable) iter.Current;
					ParamItemTable table = (ParamItemTable) cur.deepCopy(false);

					if (ciclic)
					{
						table.ParentBoqItem = obj;
					}

					obj.paramItemSet.Add(table);
				}
				obj.ParamItemSet = obj.paramItemSet;
			}

			return obj;
		}

		public virtual object deepCopy(bool ciclic)
		{
			return deepCopy(ciclic, false);
		}

		public virtual object deepCopy(bool ciclic, bool copyHistory)
		{
			return deepCopy(ciclic, copyHistory, false);
		}

		// inside transaction
		public virtual object deepCopy(bool ciclic, bool copyHistory, bool copyQuoteItemRelations)
		{
			BoqItemTable obj = (BoqItemTable) clone();
			//System.out.println("copying started: "+obj);

			if (BoqItemAssemblySet != null)
			{

				obj.boqItemAssemblySet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable cur = (BoqItemAssemblyTable) iter.Current;
					BoqItemAssemblyTable table = (BoqItemAssemblyTable) cur.clone(false);
					if (cur.AssemblyTable != null)
					{
						table.AssemblyTable = (AssemblyTable) cur.AssemblyTable.deepCopy();
						if (copyHistory)
						{
							table.AssemblyTable.AssemblyHistorySet = copyHistorySet(cur.AssemblyTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemAssemblySet.Add(table);
				}
				obj.BoqItemAssemblySet = obj.boqItemAssemblySet;
			}

			if (BoqItemEquipmentSet != null)
			{
				obj.boqItemEquipmentSet = new HashSet<object>();
				//Iterator iter = getBoqItemEquipmentSet().iterator();
				foreach (BoqItemEquipmentTable cur in BoqItemEquipmentSet)
				{
					//BoqItemEquipmentTable cur = (BoqItemEquipmentTable)iter.next();				
					BoqItemEquipmentTable table = (BoqItemEquipmentTable) cur.clone(false);
					if (cur.EquipmentTable != null)
					{
						table.EquipmentTable = (EquipmentTable) cur.EquipmentTable.clone();
						if (copyHistory)
						{
							table.EquipmentTable.EquipmentHistorySet = copyHistorySet(cur.EquipmentTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemEquipmentSet.Add(table);
				}
				obj.BoqItemEquipmentSet = obj.boqItemEquipmentSet;
			}

			if (BoqItemSubcontractorSet != null)
			{

				obj.boqItemSubcontractorSet = new HashSet<object>(20);
				foreach (BoqItemSubcontractorTable cur in BoqItemSubcontractorSet)
				{
					BoqItemSubcontractorTable table = (BoqItemSubcontractorTable) cur.clone(false);
					if (cur.SubcontractorTable != null)
					{
						table.SubcontractorTable = (SubcontractorTable) cur.SubcontractorTable.clone();
						if (copyHistory)
						{
							table.SubcontractorTable.SubcontractorHistorySet = copyHistorySet(cur.SubcontractorTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemSubcontractorSet.Add(table);
				}
				obj.BoqItemSubcontractorSet = obj.boqItemSubcontractorSet;
			}

			if (BoqItemLaborSet != null)
			{

				obj.boqItemLaborSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable cur = (BoqItemLaborTable) iter.Current;
					BoqItemLaborTable table = (BoqItemLaborTable) cur.clone(false);
					if (cur.LaborTable != null)
					{
						//System.out.println("copying: "+cur.getLaborTable());
						table.LaborTable = (LaborTable) cur.LaborTable.clone();
						if (copyHistory)
						{
							table.LaborTable.LaborHistorySet = copyHistorySet(cur.LaborTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemLaborSet.Add(table);
				}
				obj.BoqItemLaborSet = obj.boqItemLaborSet;
			}

			if (BoqItemMaterialSet != null)
			{

				obj.boqItemMaterialSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable cur = (BoqItemMaterialTable) iter.Current;
					BoqItemMaterialTable table = (BoqItemMaterialTable) cur.clone(false);
					if (cur.MaterialTable != null)
					{
						table.MaterialTable = cur.MaterialTable.copyWithSupplier();
						if (copyHistory)
						{
							table.MaterialTable.MaterialHistorySet = copyHistorySet(cur.MaterialTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemMaterialSet.Add(table);
				}
				obj.BoqItemMaterialSet = obj.boqItemMaterialSet;
			}

			if (BoqItemConsumableSet != null)
			{

				obj.boqItemConsumableSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConsumableTable cur = (BoqItemConsumableTable) iter.Current;
					BoqItemConsumableTable table = (BoqItemConsumableTable) cur.clone(false);
					if (cur.ConsumableTable != null)
					{
						table.ConsumableTable = (ConsumableTable) cur.ConsumableTable.clone();
						if (copyHistory)
						{
							table.ConsumableTable.ConsumableHistorySet = copyHistorySet(cur.ConsumableTable);
						}
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemConsumableSet.Add(table);
				}
				obj.BoqItemConsumableSet = obj.boqItemConsumableSet;
			}

			if (BoqItemConditionSet != null)
			{

				obj.boqItemConditionSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemConditionSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConditionTable cur = (BoqItemConditionTable) iter.Current;
					BoqItemConditionTable table = (BoqItemConditionTable) cur.clone(false);
					if (cur.ConditionTable != null)
					{
						table.ConditionTable = (ConditionTable) cur.ConditionTable.clone();
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.boqItemConditionSet.Add(table);
				}
				obj.BoqItemConditionSet = obj.boqItemConditionSet;
			}

			if (QuoteItemSet != null)
			{

				obj.quoteItemSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = QuoteItemSet.GetEnumerator();
				while (iter.MoveNext())
				{
					QuoteItemTable cur = (QuoteItemTable) iter.Current;
					QuoteItemTable table = (QuoteItemTable) cur.clone(false);
					if (cur.QuotationTable != null)
					{
						table.QuotationTable = (QuotationTable) cur.QuotationTable.clone();
					}
					if (copyQuoteItemRelations && cur.BoqItemMaterialTable != null)
					{
						table.BoqItemMaterialTable = (BoqItemMaterialTable) cur.BoqItemMaterialTable.clone();
					}
					if (copyQuoteItemRelations && cur.BoqItemSubcontractorTable != null)
					{
						table.BoqItemSubcontractorTable = (BoqItemSubcontractorTable) cur.BoqItemSubcontractorTable.clone();
					}
					if (ciclic)
					{
						table.BoqItemTable = obj;
					}

					obj.quoteItemSet.Add(table);
				}
				obj.QuoteItemSet = obj.quoteItemSet;
			}

			if (ParamItemTable != null)
			{
				obj.ParamItemTable = (ParamItemTable) ParamItemTable.clone();
			}

			return obj;
		}

		private ISet<object> copyHistorySet(ResourceTable resourceTable)
		{
			ISet<object> set = resourceTable.ResourceHistorySet;
			if (set == null)
			{
				return new HashSet<object>();
			}
			ISet<object> resultSet = new HashSet<object>();
			IEnumerator<ResourceHistoryTable> iter = set.GetEnumerator();

			while (iter.MoveNext())
			{
				ResourceHistoryTable table = (ResourceHistoryTable) iter.Current.clone();
				resultSet.Add(table);
			}
			return resultSet;
		}

		public virtual object copy()
		{
			BoqItemTable obj = (BoqItemTable) clone();

			if (BoqItemAssemblySet != null)
			{

				obj.boqItemAssemblySet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable cur = (BoqItemAssemblyTable) iter.Current;
					BoqItemAssemblyTable table = new BoqItemAssemblyTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.boqItemAssemblySet.Add(table);
				}
				obj.BoqItemAssemblySet = obj.boqItemAssemblySet;
			}

			if (BoqItemLaborSet != null)
			{

				obj.boqItemLaborSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable cur = (BoqItemLaborTable) iter.Current;
					BoqItemLaborTable table = new BoqItemLaborTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.boqItemLaborSet.Add(table);
				}
				obj.BoqItemLaborSet = obj.boqItemLaborSet;
			}

			if (BoqItemConsumableSet != null)
			{

				obj.boqItemConsumableSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConsumableTable cur = (BoqItemConsumableTable) iter.Current;
					BoqItemConsumableTable table = new BoqItemConsumableTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.boqItemConsumableSet.Add(table);
				}
				obj.BoqItemConsumableSet = obj.boqItemConsumableSet;
			}

			if (BoqItemConditionSet != null)
			{

				obj.boqItemConditionSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemConditionSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConditionTable cur = (BoqItemConditionTable) iter.Current;
					BoqItemConditionTable table = new BoqItemConditionTable();
					table.FinalQuantity = new BigDecimalFixed(cur.FinalQuantity.ToString());
					obj.boqItemConditionSet.Add(table);
				}
				obj.BoqItemConditionSet = obj.boqItemConditionSet;
			}

			if (QuoteItemSet != null)
			{

				obj.quoteItemSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = QuoteItemSet.GetEnumerator();
				while (iter.MoveNext())
				{
					QuoteItemTable cur = (QuoteItemTable) iter.Current;
					QuoteItemTable table = (QuoteItemTable) cur.clone(false);
					if (cur.QuotationTable != null)
					{
						table.QuotationTable = (QuotationTable) cur.QuotationTable.clone();
					}
					obj.quoteItemSet.Add(table);
				}
				obj.QuoteItemSet = obj.quoteItemSet;
			}

			if (BoqItemSubcontractorSet != null)
			{

				obj.boqItemSubcontractorSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemSubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemSubcontractorTable cur = (BoqItemSubcontractorTable) iter.Current;
					BoqItemSubcontractorTable table = new BoqItemSubcontractorTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.boqItemSubcontractorSet.Add(table);
				}
				obj.BoqItemSubcontractorSet = obj.boqItemSubcontractorSet;
			}

			if (BoqItemEquipmentSet != null)
			{

				obj.boqItemEquipmentSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemEquipmentTable cur = (BoqItemEquipmentTable) iter.Current;
					BoqItemEquipmentTable table = new BoqItemEquipmentTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.boqItemEquipmentSet.Add(table);
				}
				obj.BoqItemEquipmentSet = obj.boqItemEquipmentSet;
			}

			if (BoqItemMaterialSet != null)
			{

				obj.boqItemMaterialSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable cur = (BoqItemMaterialTable) iter.Current;
					BoqItemMaterialTable table = new BoqItemMaterialTable();
					table.FinalRate = cur.calculateFinalRate();
					table.FinalShipmentRate = cur.FinalShipmentRate;
					table.FinalFabricationRate = cur.FinalFabricationRate;
					table.FinalMaterialRate = cur.FinalMaterialRate;
					table.FinalFixedCost = cur.FinalFixedCost;

					obj.boqItemMaterialSet.Add(table);
				}
				obj.BoqItemMaterialSet = obj.boqItemMaterialSet;
			}

			if (ParamItemTable != null)
			{
				obj.ParamItemTable = (ParamItemTable) ParamItemTable.clone();
			}

			return obj;
		}

		//	public static BoqItemTable deepPaste(Session session, BoqItemTable boqItemTable) throws Exception {
		//
		//		boqItemTable.setEditorId(DatabaseDBUtil.getProperties().getUserId());
		//		Long id = (Long)session.save(boqItemTable.clone()); 
		//		boqItemTable.setBoqitemId(id); 	
		//
		//		BoqItemTable newDBBoqItem = (BoqItemTable)session.load(BoqItemTable.class,id);
		//		boqItemTable.setParamItemTable(null); // in case we copied a parametric item
		//		if ( boqItemTable.getBoqItemAssemblySet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemAssemblySet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//				AssemblyTable assemblyTable = boqItemAssembly.getAssemblyTable();
		//				AssemblyTable newAssemblyTable = assemblyTable;
		//				id = (Long)session.save(boqItemAssembly.clone(false));
		//				boqItemAssembly = (BoqItemAssemblyTable)session.load(BoqItemAssemblyTable.class,id);
		//				boolean newlyAdded = false;
		//				if ( assemblyTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(assemblyTable.clone());
		//					assemblyTable = (AssemblyTable)session.load(AssemblyTable.class,id); 
		//				}
		//				else {
		//					// WE ALWAYS ADD NEW TO SUPPORT CREWS!
		//					//List res = session.createQuery("from AssemblyTable as o where o.databaseId = "+assemblyTable.getDatabaseId()+" and o.databaseCreationDate = "+assemblyTable.getDatabaseCreationDate()).list();
		//					//if ( res.size() == 0 ) {
		//					// does not exist so add it!
		//					id = (Long)session.save(assemblyTable.clone());
		//					assemblyTable = (AssemblyTable)session.load(AssemblyTable.class,id); 
		//					newlyAdded = true;
		//					//}
		//					//else {
		//					// exists so load it:
		//					//assemblyTable = (AssemblyTable)res.iterator().next();
		//					//}
		//				}
		////				if ( assemblyTable.getBoqItemAssemblySet() == null )
		////					assemblyTable.setBoqItemAssemblySet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemEquipmentSet() == null )
		//					newDBBoqItem.setBoqItemAssemblySet(new HashSet());
		//				// do the addition
		//				newDBBoqItem.getBoqItemAssemblySet().add(boqItemAssembly);
		////				assemblyTable.getBoqItemAssemblySet().add(boqItemAssembly); 		 
		//				boqItemAssembly.setAssemblyTable(assemblyTable);
		//				boqItemAssembly.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(assemblyTable);
		//				session.update(boqItemAssembly);
		//				if ( newlyAdded ) {
		//					// persist associations
		//					AssemblyTable.deepPersist(session,assemblyTable,newAssemblyTable,false);
		//				}
		//			}
		//		}
		//
		//		if ( boqItemTable.getBoqItemEquipmentSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemEquipmentSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemEquipmentTable boqItemEquipment = (BoqItemEquipmentTable)iter.next();
		//				EquipmentTable equipmentTable = boqItemEquipment.getEquipmentTable();
		//				id = (Long)session.save(boqItemEquipment.clone(false));
		//				boqItemEquipment = (BoqItemEquipmentTable)session.load(BoqItemEquipmentTable.class,id);
		//
		//				if ( equipmentTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(equipmentTable.clone());
		//					equipmentTable = (EquipmentTable)session.load(EquipmentTable.class,id); 
		//				}
		//				else {
		//					List res = session.createQuery("from EquipmentTable as o where o.databaseId = "+equipmentTable.getDatabaseId()+" and o.databaseCreationDate = "+equipmentTable.getDatabaseCreationDate()).list();
		//					if ( res.size() == 0 ) {
		//						// does not exist so add it!
		//						id = (Long)session.save(equipmentTable.clone());
		//						equipmentTable = (EquipmentTable)session.load(EquipmentTable.class,id); 
		//					}
		//					else {
		//						// exists so load it:
		//						equipmentTable = (EquipmentTable)res.iterator().next();
		//					}
		//				}
		////				if ( equipmentTable.getBoqItemEquipmentSet() == null )
		////					equipmentTable.setBoqItemEquipmentSet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemEquipmentSet() == null )
		//					newDBBoqItem.setBoqItemEquipmentSet(new HashSet());
		//				// do the addition
		//				newDBBoqItem.getBoqItemEquipmentSet().add(boqItemEquipment);
		////				equipmentTable.getBoqItemEquipmentSet().add(boqItemEquipment); 		 
		//				boqItemEquipment.setEquipmentTable(equipmentTable);
		//				boqItemEquipment.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(equipmentTable);
		//				session.update(boqItemEquipment); 		 
		//			}
		//		}
		//		if ( boqItemTable.getBoqItemSubcontractorSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemSubcontractorSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemSubcontractorTable boqItemSubcontractor = (BoqItemSubcontractorTable)iter.next();
		//				SubcontractorTable subcontractorTable = boqItemSubcontractor.getSubcontractorTable();
		//				id = (Long)session.save(boqItemSubcontractor.clone(false));
		//				boqItemSubcontractor = (BoqItemSubcontractorTable)session.load(BoqItemSubcontractorTable.class,id);
		//				if ( subcontractorTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(subcontractorTable.clone());
		//					subcontractorTable = (SubcontractorTable)session.load(SubcontractorTable.class,id); 
		//				}
		//				else {
		//					List res = session.createQuery("from SubcontractorTable as o where o.databaseId = "+subcontractorTable.getDatabaseId()+" and o.databaseCreationDate = "+subcontractorTable.getDatabaseCreationDate()).list();
		//					if ( res.size() == 0 ) {
		//						// does not exist so add it!
		//						id = (Long)session.save(subcontractorTable.clone());
		//						subcontractorTable = (SubcontractorTable)session.load(SubcontractorTable.class,id); 	
		//					}
		//					else {
		//						// exists so load it:
		//						subcontractorTable = (SubcontractorTable)res.iterator().next();
		//					}
		//				}
		////				if ( subcontractorTable.getBoqItemSubcontractorSet() == null )
		////					subcontractorTable.setBoqItemSubcontractorSet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemSubcontractorSet() == null )
		//					newDBBoqItem.setBoqItemSubcontractorSet(new HashSet());
		//				// do the addition
		//				newDBBoqItem.getBoqItemSubcontractorSet().add(boqItemSubcontractor);
		////				subcontractorTable.getBoqItemSubcontractorSet().add(boqItemSubcontractor); 		 
		//				boqItemSubcontractor.setSubcontractorTable(subcontractorTable);
		//				boqItemSubcontractor.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(subcontractorTable);
		//				session.update(boqItemSubcontractor);
		//			}
		//		}
		//
		//		if ( boqItemTable.getBoqItemLaborSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemLaborSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemLaborTable boqItemLabor = (BoqItemLaborTable)iter.next();
		//				LaborTable laborTable = boqItemLabor.getLaborTable();
		//				id = (Long)session.save(boqItemLabor.clone(false));
		//				boqItemLabor = (BoqItemLaborTable)session.load(BoqItemLaborTable.class,id);
		//				//System.out.println("searching for "+laborTable.getDatabaseId()+". "+laborTable.getTitle());
		//				if ( laborTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(laborTable.clone());
		//					laborTable = (LaborTable)session.load(LaborTable.class,id); 
		//				}
		//				else {
		//					List res = session.createQuery("from LaborTable as o where o.databaseId = "+laborTable.getDatabaseId()+" and o.databaseCreationDate = "+laborTable.getDatabaseCreationDate()).list();
		//					if ( res.size() == 0 ) {
		//						// does not exist so add it!
		//						id = (Long)session.save(laborTable.clone());
		//						laborTable = (LaborTable)session.load(LaborTable.class,id); 	 		 	 
		//					}
		//					else {
		//						// exists so load it:
		//						laborTable = (LaborTable)res.iterator().next();
		//					}
		//				}
		////				if ( laborTable.getBoqItemLaborSet() == null )
		////					laborTable.setBoqItemLaborSet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemLaborSet() == null )
		//					newDBBoqItem.setBoqItemLaborSet(new HashSet());
		//				// do the addition
		//				newDBBoqItem.getBoqItemLaborSet().add(boqItemLabor);
		////				laborTable.getBoqItemLaborSet().add(boqItemLabor); 		 
		//				boqItemLabor.setLaborTable(laborTable);
		//				boqItemLabor.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(laborTable);
		//				session.update(boqItemLabor);
		//			}
		//		}
		//		if ( boqItemTable.getBoqItemMaterialSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemMaterialSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemMaterialTable boqItemMaterial = (BoqItemMaterialTable)iter.next();
		//				MaterialTable materialTable = boqItemMaterial.getMaterialTable();
		//				MaterialTable actualMaterialTable = materialTable;
		//				id = (Long)session.save(boqItemMaterial.clone(false));
		//				boqItemMaterial = (BoqItemMaterialTable)session.load(BoqItemMaterialTable.class,id);
		//				boolean newlyAdded = false;
		//				if ( materialTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(materialTable.clone());
		//					materialTable = (MaterialTable)session.load(MaterialTable.class,id); 
		//					newlyAdded = true;
		//				}
		//				else {
		//					List res = session.createQuery("from MaterialTable as o where o.databaseId = "+materialTable.getDatabaseId()+" and o.databaseCreationDate = "+materialTable.getDatabaseCreationDate()).list();
		//					if ( res.size() == 0 ) {
		//						// does not exist so add it!
		//						id = (Long)session.save(materialTable.clone());
		//						materialTable = (MaterialTable)session.load(MaterialTable.class,id); 	
		//						newlyAdded = true;
		//					}
		//					else {
		//						// exists so load it:
		//						materialTable = (MaterialTable)res.iterator().next();
		//					}
		//				}
		//
		////				if ( materialTable.getBoqItemMaterialSet() == null )
		////					materialTable.setBoqItemMaterialSet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemMaterialSet() == null )
		//					newDBBoqItem.setBoqItemMaterialSet(new HashSet());
		//
		//				// do the addition
		//				newDBBoqItem.getBoqItemMaterialSet().add(boqItemMaterial);
		////				materialTable.getBoqItemMaterialSet().add(boqItemMaterial); 		 
		//				boqItemMaterial.setMaterialTable(materialTable);
		//				boqItemMaterial.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(materialTable);
		//				session.update(boqItemMaterial);
		//
		//				SupplierTable supplierTable = actualMaterialTable.getSupplierTable();
		//				if ( supplierTable != null && newlyAdded ) {
		//					//System.out.println("adding supplier : "+supplierTable);
		//					if ( supplierTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//						id = (Long)session.save(supplierTable.clone());
		//						supplierTable = (SupplierTable)session.load(SupplierTable.class,id); 
		//					}
		//					else {
		//						List res = session.createQuery("from SupplierTable as o where o.databaseId = "+supplierTable.getDatabaseId()+" and o.databaseCreationDate = "+supplierTable.getDatabaseCreationDate()).list();
		//
		//						if ( res.size() == 0 ) {
		//							// does not exist so add it!
		//							id = (Long)session.save(supplierTable.clone());
		//							supplierTable = (SupplierTable)session.load(SupplierTable.class,id); 	
		//						}
		//						else {
		//							// exists so load it:
		//							supplierTable = (SupplierTable)res.iterator().next();
		//						}
		//					}
		//					if ( supplierTable.getMaterialSet() == null ) {
		//						supplierTable.setMaterialSet(new HashSet());
		//					}
		//					// make the association:
		//					materialTable.setSupplierTable(supplierTable);
		//					supplierTable.getMaterialSet().add(materialTable);
		//					session.update(supplierTable);
		//					session.update(materialTable);
		//				}
		//			}
		//		}	
		//		if ( boqItemTable.getBoqItemConsumableSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemConsumableSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemConsumableTable boqItemConsumable = (BoqItemConsumableTable)iter.next();
		//				ConsumableTable consumableTable = boqItemConsumable.getConsumableTable();
		//				id = (Long)session.save(boqItemConsumable.clone(false));
		//				boqItemConsumable = (BoqItemConsumableTable)session.load(BoqItemConsumableTable.class,id);
		//
		//				if ( consumableTable.getDatabaseCreationDate() == MISSING_DB_CREATE_DATE ) {
		//					id = (Long)session.save(consumableTable.clone());
		//					consumableTable = (ConsumableTable)session.load(ConsumableTable.class,id); 
		//				}
		//				else {
		//					List res = session.createQuery("from ConsumableTable as o where o.databaseId = "+consumableTable.getDatabaseId()+" and o.databaseCreationDate = "+consumableTable.getDatabaseCreationDate()).list();
		//					if ( res.size() == 0 ) {
		//						// does not exist so add it!
		//						id = (Long)session.save(consumableTable.clone());
		//						consumableTable = (ConsumableTable)session.load(ConsumableTable.class,id); 	
		//					}
		//					else {
		//						// exists so load it:
		//						consumableTable = (ConsumableTable)res.iterator().next();
		//					}
		//				}
		////				if ( consumableTable.getBoqItemConsumableSet() == null )
		////					consumableTable.setBoqItemConsumableSet(new HashSet());
		//				if ( newDBBoqItem.getBoqItemConsumableSet() == null )
		//					newDBBoqItem.setBoqItemConsumableSet(new HashSet());
		//				// do the addition
		//				newDBBoqItem.getBoqItemConsumableSet().add(boqItemConsumable);
		////				consumableTable.getBoqItemConsumableSet().add(boqItemConsumable); 		 
		//				boqItemConsumable.setConsumableTable(consumableTable);
		//				boqItemConsumable.setBoqItemTable(newDBBoqItem);
		//				session.update(newDBBoqItem);
		//				session.update(consumableTable);
		//				session.update(boqItemConsumable);
		//			}
		//		}
		//		int count = 0;
		//		if ( boqItemTable.getBoqItemConditionSet() != null ) {
		//			Iterator iter = boqItemTable.getBoqItemConditionSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemConditionTable boqItemCondition = (BoqItemConditionTable)iter.next();
		//				ConditionTable conditionTable = boqItemCondition.getConditionTable();
		//				id = (Long)session.save(boqItemCondition.clone(false));
		//				boqItemCondition = (BoqItemConditionTable)session.load(BoqItemConditionTable.class,id);
		//
		//				List res = null;
		//
		//				if ( conditionTable.getTakeOffType() != null && !conditionTable.getTakeOffType().equals(ConditionTable.TAKEOFF) ) {
		//					//							String query = "from ConditionTable as o where o.globalId=:gId";
		//					//							q = session.createQuery(query);
		//					//							q.setString("gId", conditionTable.getGlobalId());
		//					res = new ArrayList(); // always create new 
		//				}
		//				else {
		//					String query = "from ConditionTable as o where o.databaseName = :databaseName and o.host = :host and o.cndId = :cndId";
		//					Query q = session.createQuery(query);
		//					q.setString("databaseName", conditionTable.getDatabaseName());
		//					q.setString("host", conditionTable.getHost());
		//					q.setInteger("cndId", conditionTable.getCndId());	
		//					res = q.list();
		//				}
		//
		//				if ( res.size() == 0 ) {
		//					// does not exist so add it!
		//					id = (Long)session.save(conditionTable.clone());
		//					conditionTable = (ConditionTable)session.load(ConditionTable.class,id); 
		//					//					ProjectTreeNode prjTreeNode = (ProjectTreeNode)getTreeNode().getParent();
		//					//					boolean mustRecreateGrid = prjTreeNode.getVisualizerTreeNode().addConditionTable((ConditionTable)conditionTable.clone());
		//					//					if ( mustRefreshGrid == false && mustRecreateGrid == true )
		//					//						mustRefreshGrid = true;
		//				}
		//				else {
		//					// exists so load it:
		//					conditionTable = (ConditionTable)res.iterator().next();
		//				}
		//				boqItemCondition.setConditionTable(conditionTable);
		//				boqItemCondition.setBoqItemTable(newDBBoqItem);
		//				newDBBoqItem.recalculate();
		//				session.update(newDBBoqItem);
		//				session.update(conditionTable);
		//				session.update(boqItemCondition);
		//			}
		//		}
		//
		//		return (BoqItemTable)boqItemTable.deepCopy(true);
		//	}

		//	public Object valueForField(String field) {
		//
		//		if ( field.equals("rate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.formatObject(getRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedRate"));			
		//		}
		//		else if ( field.equals("secondRate") ) {
		//			if ( o_map.get("forcedSecondRate") == null )
		//				return DBFieldFormatUtil.formatObject(getSecondRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedSecondRate"));			
		//		}
		//		else if ( field.equals("calculationType") ) {
		//			return getCalculationType();
		//		}
		//		else if ( field.equals("activityId") ) {
		//			return getActivityId();
		//		}
		//		else if ( field.equals("planningType") ) {
		//			return getPlanningType();
		//		}
		//		else if ( field.equals("surfaceType") ) {			
		//			return getSurfaceType();
		//		}
		//		else if ( field.equals("status") ) {			
		//			return getStatus();
		//		}
		//		else if ( field.equals("secondQuantity") ) {
		//			return getSecondQuantity();		
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.formatObject(getTotalCost());
		//			return DBFieldFormatUtil.formatObject(new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()));		
		//		}
		//		else if ( field.equals("offeredPrice") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.formatObject(getOfferedPrice());
		//			return DBFieldFormatUtil.formatObject(new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup()).add(getEscalationCost()));		
		//		}
		//		else if ( field.equals("offeredRate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.formatObject(getOfferedRate());
		//			BigDecimal offeredRate = new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup().add(getEscalationCost()));
		//			offeredRate = offeredRate.divide(getQuantity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);
		//			return DBFieldFormatUtil.formatObject(offeredRate);		
		//		}
		//		else if ( field.equals("offeredSecondRate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateOfferedSecondRate());
		//			BigDecimal offeredRate = new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup().add(getEscalationCost()));
		//			offeredRate = offeredRate.divide(getSecondQuantity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);
		//			return DBFieldFormatUtil.formatObject(offeredRate);		
		//		}
		//		else if ( field.equals("assemblyTotalCost") ) {
		//			if ( o_map.get("forcedAssemblyCost") == null )
		//				return DBFieldFormatUtil.formatObject(getAssemblyTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedAssemblyCost"));			
		//		}
		//		else if ( field.equals("equipmentTotalCost") ) {
		//			if ( o_map.get("forcedEquipmentCost") == null )
		//				return DBFieldFormatUtil.formatObject(getEquipmentTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedEquipmentCost"));			
		//		}
		//		else if ( field.equals("laborTotalCost") ) {
		//			if ( o_map.get("forcedLaborCost") == null )
		//				return DBFieldFormatUtil.formatObject(getLaborTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedLaborCost"));		
		//		}
		//		else if ( field.equals("subcontractorTotalCost") ) {
		//			if ( o_map.get("forcedSubcontractorCost") == null )
		//				return DBFieldFormatUtil.formatObject(getSubcontractorTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedSubcontractorCost"));		
		//		}
		//		else if ( field.equals("consumableTotalCost") ) {
		//			if ( o_map.get("forcedConsumableCost") == null )
		//				return DBFieldFormatUtil.formatObject(getConsumableTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedConsumableCost"));	
		//		}
		//		else if ( field.equals("materialTotalCost") ) {
		//			if ( o_map.get("forcedMaterialCost") == null )
		//				return DBFieldFormatUtil.formatObject(getMaterialTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedMaterialCost"));			
		//		}		
		//		else if ( field.equals("fabricationTotalCost") ) {
		//			if ( o_map.get("forcedFabricationCost") == null )
		//				return DBFieldFormatUtil.formatObject(getFabricationTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedFabricationCost"));			
		//		}		
		//		else if ( field.equals("shipmentTotalCost") ) {
		//			if ( o_map.get("forcedShipmentCost") == null )
		//				return DBFieldFormatUtil.formatObject(getShipmentTotalCost());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedShipmentCost"));			
		//		}
		//		else if ( field.equals("assemblyRate") ) {
		//			if ( o_map.get("forcedAssemblyRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateAssemblyRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedAssemblyRate"));			
		//		}
		//		else if ( field.equals("equipmentRate") ) {
		//			if ( o_map.get("forcedEquipmentRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateEquipmentRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedEquipmentRate"));			
		//		}
		//		else if ( field.equals("laborRate") ) {
		//			if ( o_map.get("forcedLaborRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateLaborRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedLaborRate"));		
		//		}
		//		else if ( field.equals("subcontractorRate") ) {
		//			if ( o_map.get("forcedSubcontractorRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateSubcontractorRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedSubcontractorRate"));		
		//		}
		//		else if ( field.equals("consumableRate") ) {
		//			if ( o_map.get("forcedConsumableRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateConsumableRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedConsumableRate"));	
		//		}
		//		else if ( field.equals("materialRate") ) {
		//			if ( o_map.get("forcedMaterialRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateMaterialRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedMaterialRate"));			
		//		}		
		//		else if ( field.equals("fabricationRate") ) {
		//			if ( o_map.get("forcedFabricationRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateFabricationRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedFabricationRate"));			
		//		}		
		//		else if ( field.equals("shipmentRate") ) {
		//			if ( o_map.get("forcedShipmentRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateShipmentRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedShipmentRate"));			
		//		}
		//		else if ( field.equals("publishedItemCode") ) {
		//			return getPublishedItemCode();
		//		}
		//		else if ( field.equals("groupCode") ) {			
		//			return getGroupCode();
		//		}
		//		else if ( field.equals("gekCode") ) {			
		//			return getGekCode();
		//		}
		//		else if ( field.equals("location") ) {			
		//			return getLocation();
		//		}
		//		else if ( field.equals("wbsCode") || field.equals("wbs") ) {			
		//			return getWbsCode();
		//		}
		//		else if ( field.equals("wbs2Code") ) {			
		//			return getWbs2Code();
		//		}
		//		else if ( field.equals("assemblyCode") ) {			
		//			return getParamItemTable()==null?"":getParamItemTable().toString();
		//		}
		//		else if ( field.equals("locationCode") ) {			
		//			return getLocation()+" - "+getLocation(); // set as group code
		//		}
		//		else if ( field.startsWith("estim") ) {
		//			if ( field.equals("estimTotalCost") ) {
		//				if ( getEstimTotalCost() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimAssemblyTotalCost") ) {
		//				if ( getEstimAssemblyRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimAssemblyTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimEquipmentTotalCost") ) {
		//				if ( getEstimEquipmentRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimEquipmentTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimLaborTotalCost") ) {
		//				if ( getEstimLaborRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimLaborTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimMaterialTotalCost") ) {
		//				if ( getEstimMaterialRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimMaterialTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimFabricationTotalCost") ) {
		//				if ( getEstimFabricationRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimFabricationTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimShipmentTotalCost") ) {
		//				if ( getEstimShipmentRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimShipmentTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimSubcontractorTotalCost") ) {
		//				if ( getEstimSubcontractorRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimSubcontractorTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimConsumableTotalCost") ) {
		//				if ( getEstimConsumableRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimConsumableTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimRate") ) {
		//				if ( getEstimRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimAssemblyRate") ) {
		//				if ( getEstimAssemblyRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimAssemblyRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimLaborRate") ) {
		//				if ( getEstimLaborRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimLaborRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimSubcontractorRate") ) {
		//				if ( getEstimSubcontractorRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimSubcontractorRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimEquipmentRate") ) {
		//				if ( getEstimEquipmentRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimEquipmentRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimMaterialRate") ) {
		//				if ( getEstimMaterialRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimMaterialRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimShipmentRate") ) {
		//				if ( getEstimShipmentRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimShipmentRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimFabricationRate") ) {
		//				if ( getEstimFabricationRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimFabricationRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("estimConsumableRate") ) {
		//				if ( getEstimConsumableRate() != null )
		//					return DBFieldFormatUtil.formatObject(getEstimConsumableRate());			
		//				return "-";
		//			}
		//		}
		//		else if ( field.startsWith("quoted") ) {
		//			if ( field.equals("quotedMaterialTotalCost") ) {
		//				if ( getQuotedMaterialTotalCost() != null )
		//					return DBFieldFormatUtil.formatObject(getQuotedMaterialTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("quotedSubcontractorTotalCost") ) {
		//				if ( getQuotedSubcontractorTotalCost() != null )
		//					return DBFieldFormatUtil.formatObject(getQuotedSubcontractorTotalCost());			
		//				return "-";
		//			}
		//			else if ( field.equals("quotedMaterialRate") ) {
		//				if ( getQuotedMaterialRate() != null )
		//					return DBFieldFormatUtil.formatObject(getQuotedMaterialRate());			
		//				return "-";
		//			}
		//			else if ( field.equals("quotedSubcontractorRate") ) {
		//				if ( getQuotedSubcontractorRate() != null )
		//					return DBFieldFormatUtil.formatObject(getQuotedSubcontractorRate());			
		//				return "-";
		//			}
		//		}
		//		else if ( field.startsWith("extraCode") ) {			
		//			if ( field.equals("extraCode1") ) {			
		//				return getExtraCode1();
		//			}
		//			else if ( field.equals("extraCode2") ) {			
		//				return getExtraCode2();
		//			}
		//			else if ( field.equals("extraCode3") ) {			
		//				return getExtraCode3();
		//			}
		//			else if ( field.equals("extraCode4") ) {			
		//				return getExtraCode4();
		//			}
		//			else if ( field.equals("extraCode5") ) {			
		//				return getExtraCode5();
		//			}
		//			else if ( field.equals("extraCode6") ) {			
		//				return getExtraCode6();
		//			}
		//			else if ( field.equals("extraCode7") ) {			
		//				return getExtraCode7();
		//			}
		//			else if ( field.equals("extraCode8") ) {			
		//				return getExtraCode8();
		//			}
		//			else if ( field.equals("extraCode9") ) {			
		//				return getExtraCode9();
		//			}
		//			else if ( field.equals("extraCode10") ) {			
		//				return getExtraCode10();
		//			}
		//		}
		//		else if ( field.equals("paymentDate") ) {			
		//			return DBFieldFormatUtil.formatDate(getPaymentDate());
		//		}
		//
		//		return DBFieldFormatUtil.formatObject(o_map.get(field));
		//	}
		//
		//	public Object scaledValueForField(String field) {
		//		if ( field.equals("rate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(getRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(o_map.get("forcedRate"));			
		//		}
		//		else if ( field.equals("secondRate") ) {
		//			if ( o_map.get("forcedSecondRate") == null )
		//				return DBFieldFormatUtil.formatObject(getSecondRate());
		//			return DBFieldFormatUtil.formatObject(o_map.get("forcedSecondRate"));			
		//		}
		//		else if ( field.equals("calculationType") ) {
		//			return getCalculationType();
		//		}
		//		else if ( field.equals("activityId") ) {
		//			return getActivityId();
		//		}
		//		else if ( field.equals("planningType") ) {
		//			return getPlanningType();
		//		}
		//		else if ( field.equals("surfaceType") ) {
		//			return getSurfaceType();
		//		}
		//		else if ( field.equals("status") ) {
		//			return getStatus();
		//		}
		//		else if ( field.equals("secondQuantity") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(getSecondQuantity());		
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()));		
		//		}
		//		else if ( field.equals("offeredPrice") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getOfferedPrice());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup()).add(getEscalationCost()));		
		//		}
		//		else if ( field.equals("offeredRate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(getOfferedRate());
		//			BigDecimal offeredRate = new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup().add(getEscalationCost()));
		//			offeredRate = offeredRate.divide(getQuantity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);
		//			return DBFieldFormatUtil.scaleAndFormatObject(offeredRate);		
		//		}
		//		else if ( field.equals("offeredSecondRate") ) {
		//			if ( o_map.get("forcedRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateOfferedSecondRate());
		//			BigDecimal offeredRate = new BigDecimalFixed(o_map.get("forcedRate").toString()).multiply(getQuantity()).add(getMarkup().add(getEscalationCost()));
		//			offeredRate = offeredRate.divide(getSecondQuantity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);
		//			return DBFieldFormatUtil.scaleAndFormatObject(offeredRate);		
		//		}
		//		else if ( field.equals("assemblyTotalCost") ) {
		//			if ( o_map.get("forcedAssemblyCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getAssemblyTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedAssemblyCost").toString()));			
		//		}
		//		else if ( field.equals("equipmentTotalCost") ) {
		//			if ( o_map.get("forcedEquipmentCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getEquipmentTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedEquipmentCost").toString()));			
		//		}
		//		else if ( field.equals("laborTotalCost") ) {
		//			if ( o_map.get("forcedLaborCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getLaborTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedLaborCost").toString()));	
		//		}
		//		else if ( field.equals("subcontractorTotalCost") ) {
		//			if ( o_map.get("forcedSubcontractorCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getSubcontractorTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedSubcontractorCost").toString()));		
		//		}
		//		else if ( field.equals("consumableTotalCost") ) {
		//			if ( o_map.get("forcedConsumableCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getConsumableTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedConsumableCost").toString()));	
		//		}
		//		else if ( field.equals("materialTotalCost") ) {
		//			if ( o_map.get("forcedMaterialCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getMaterialTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency(new BigDecimalFixed(o_map.get("forcedMaterialCost").toString()));		
		//		}
		//		else if ( field.equals("fabricationTotalCost") ) {
		//			if ( o_map.get("forcedFabricationCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getFabricationTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency( new BigDecimalFixed(o_map.get("forcedFabricationCost").toString()) );			
		//		}		
		//		else if ( field.equals("shipmentTotalCost") ) {
		//			if ( o_map.get("forcedShipmentCost") == null )
		//				return DBFieldFormatUtil.scaleAndFormatCurrency(getShipmentTotalCost());
		//			return DBFieldFormatUtil.scaleAndFormatCurrency( new BigDecimalFixed(o_map.get("forcedShipmentCost").toString()) );			
		//		}
		//		else if ( field.equals("assemblyRate") ) {
		//			if ( o_map.get("forcedAssemblyRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateAssemblyRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedAssemblyRate").toString()));			
		//		}
		//		else if ( field.equals("equipmentRate") ) {
		//			if ( o_map.get("forcedEquipmentRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateEquipmentRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedEquipmentRate").toString()));			
		//		}
		//		else if ( field.equals("laborRate") ) {
		//			if ( o_map.get("forcedLaborRate") == null )
		//				return DBFieldFormatUtil.formatObject(calculateLaborRate());
		//			return DBFieldFormatUtil.formatObject(new BigDecimalFixed(o_map.get("forcedLaborRate").toString()));	
		//		}
		//		else if ( field.equals("subcontractorRate") ) {
		//			if ( o_map.get("forcedSubcontractorRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateSubcontractorRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedSubcontractorRate").toString()));		
		//		}
		//		else if ( field.equals("consumableRate") ) {
		//			if ( o_map.get("forcedConsumableRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateConsumableRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedConsumableRate").toString()));	
		//		}
		//		else if ( field.equals("materialRate") ) {
		//			if ( o_map.get("forcedMaterialRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateMaterialRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedMaterialRate").toString()));		
		//		}
		//		else if ( field.equals("fabricationRate") ) {
		//			if ( o_map.get("forcedFabricationRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateFabricationRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedFabricationRate").toString()));			
		//		}		
		//		else if ( field.equals("shipmentRate") ) {
		//			if ( o_map.get("forcedShipmentRate") == null )
		//				return DBFieldFormatUtil.scaleAndFormatObject(calculateShipmentRate());
		//			return DBFieldFormatUtil.scaleAndFormatObject(new BigDecimalFixed(o_map.get("forcedShipmentRate").toString()));			
		//		}
		//		else if ( field.equals("publishedItemCode") ) {
		//			return getPublishedItemCode();
		//		}
		//		else if ( field.equals("groupCode") ) {			
		//			return getGroupCode();
		//		}
		//		else if ( field.equals("gekCode") ) {			
		//			return getGekCode();
		//		}
		//		else if ( field.equals("wbsCode") ) {			
		//			return getWbsCode();
		//		}
		//		else if ( field.equals("wbs2Code") ) {			
		//			return getWbs2Code();
		//		}
		//		else if ( field.equals("location") ) {			
		//			return getLocation();
		//		}
		//		else if ( field.startsWith("extraCode") ) {			
		//			if ( field.equals("extraCode1") ) {			
		//				return getExtraCode1();
		//			}
		//			else if ( field.equals("extraCode2") ) {			
		//				return getExtraCode2();
		//			}
		//			else if ( field.equals("extraCode3") ) {			
		//				return getExtraCode3();
		//			}
		//			else if ( field.equals("extraCode4") ) {			
		//				return getExtraCode4();
		//			}
		//			else if ( field.equals("extraCode5") ) {			
		//				return getExtraCode5();
		//			}
		//			else if ( field.equals("extraCode6") ) {			
		//				return getExtraCode6();
		//			}
		//			else if ( field.equals("extraCode7") ) {			
		//				return getExtraCode7();
		//			}
		//			else if ( field.equals("extraCode8") ) {			
		//				return getExtraCode8();
		//			}
		//			else if ( field.equals("extraCode9") ) {			
		//				return getExtraCode9();
		//			}
		//			else if ( field.equals("extraCode10") ) {			
		//				return getExtraCode10();
		//			}
		//		}
		//		else if ( field.equals("paymentDate") ) {			
		//			return DBFieldFormatUtil.formatDate(getPaymentDate());
		//		}
		//		return DBFieldFormatUtil.scaleAndFormatObject(o_map.get(field));
		//	}

		//	public boolean equals(Object val) {
		//		if ( !(val instanceof BoqItemTable) ) {
		//			return false;
		//		}
		//
		//		BoqItemTable boqItem = (BoqItemTable)val;
		//		Iterator iter = boqItem.o_map.keySet().iterator();
		//		while ( iter.hasNext() ) {
		//			String key = (String)iter.next();
		//			if ( !boqItem.o_map.get(key).equals(o_map.get(key)) ) {
		//				return false;
		//			}
		//		}
		//
		//		return true;
		//	}

		public override long? Id
		{
			get
			{
				return BoqitemId;
			}
			set
			{
				BoqitemId = boqitemId;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqitemId
		{
			get
			{
				return boqitemId;
			}
			set
			{
				this.boqitemId = value;
			}
		}


		//@Column(updatable = false, insertable = false, name = "PARAMITEMID")
		/// <summary>
		/// @hibernate.many-to-one
		///  column="PARAMITEMID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ParamItemTable ParamItemTable
		{
			get
			{
				return paramItemTable;
			}
			set
			{
				this.paramItemTable = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PARAMITEMID" type="long" insert="false" update="false" </summary>
		/// <returns> Long </returns>
		public virtual long? ParamItemId
		{
			get
			{
				return paramItemId;
			}
			set
			{
				this.paramItemId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GLBPARAMITEMID" type="long" </summary>
		/// <returns> globalParamItemId </returns>
		public virtual long? GlobalParamItemId
		{
			get
			{
				return globalParamItemId;
			}
			set
			{
				this.globalParamItemId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PARAMCODE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ParamItemCode
		{
			get
			{
				return paramItemCode;
			}
			set
			{
				paramItemCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CODE" type="long" index="IDX_CODE" </summary>
		/// <returns> Long </returns>
		public virtual long? Code
		{
			get
			{
				if (code == null)
				{
					Code = 0L;
				}
				return code;
			}
			set
			{
				this.code = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MQTYFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string MeasuredQuantityFormula
		{
			get
			{
				return measuredQuantityFormula;
			}
			set
			{
				this.measuredQuantityFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EQTYFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string EstimatedQuantityFormula
		{
			get
			{
				return estimatedQuantityFormula;
			}
			set
			{
				this.estimatedQuantityFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TTLFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string TitleFormula
		{
			get
			{
				return titleFormula;
			}
			set
			{
				this.titleFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DSCFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string DescriptionFormula
		{
			get
			{
				return descriptionFormula;
			}
			set
			{
				this.descriptionFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WBSFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string WbsCodeFormula
		{
			get
			{
				return wbsCodeFormula;
			}
			set
			{
				this.wbsCodeFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WBS2FORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Wbs2CodeFormula
		{
			get
			{
				return wbs2CodeFormula;
			}
			set
			{
				this.wbs2CodeFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string QuantityFormula
		{
			get
			{
				return quantityFormula;
			}
			set
			{
				this.quantityFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MARKUPFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string MarkupFormula
		{
			get
			{
				return markupFormula;
			}
			set
			{
				this.markupFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DURATIONFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string DurationFormula
		{
			get
			{
				return durationFormula;
			}
			set
			{
				this.durationFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRODFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ProductivityFormula
		{
			get
			{
				return productivityFormula;
			}
			set
			{
				this.productivityFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="UMHFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string UnitManhoursFormula
		{
			get
			{
				return unitManhoursFormula;
			}
			set
			{
				this.unitManhoursFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AUMHFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string AdjustedUnitManhoursFormula
		{
			get
			{
				return adjustedUnitManhoursFormula;
			}
			set
			{
				this.adjustedUnitManhoursFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TOTALCOSTFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string TotalCostFormula
		{
			get
			{
				return totalCostFormula;
			}
			set
			{
				this.totalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OFFEREDPRICEFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string OfferedPriceFormula
		{
			get
			{
				return offeredPriceFormula;
			}
			set
			{
				this.offeredPriceFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RATEFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string RateFormula
		{
			get
			{
				return rateFormula;
			}
			set
			{
				this.rateFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OFFRATEFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string OfferedRateFormula
		{
			get
			{
				return offeredRateFormula;
			}
			set
			{
				this.offeredRateFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OFFSECRATEFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string OfferedSecondRateFormula
		{
			get
			{
				return offeredSecondRateFormula;
			}
			set
			{
				this.offeredSecondRateFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SECRATEFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string SecondRateFormula
		{
			get
			{
				return secondRateFormula;
			}
			set
			{
				this.secondRateFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SECQTYFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string SecondQuantityFormula
		{
			get
			{
				return secondQuantityFormula;
			}
			set
			{
				this.secondQuantityFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYLOSSFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string QuantityLossFormula
		{
			get
			{
				return quantityLossFormula;
			}
			set
			{
				this.quantityLossFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SECUNITFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string SecondUnitFormula
		{
			get
			{
				return secondUnitFormula;
			}
			set
			{
				this.secondUnitFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="UNITSDIVFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string UnitsDivFormula
		{
			get
			{
				return unitsDivFormula;
			}
			set
			{
				this.unitsDivFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ASSTOTALFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string AssemblyTotalCostFormula
		{
			get
			{
				return assemblyTotalCostFormula;
			}
			set
			{
				this.assemblyTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EQUTOTALFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string EquipmentTotalCostFormula
		{
			get
			{
				return equipmentTotalCostFormula;
			}
			set
			{
				this.equipmentTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MATTOTALFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string MaterialTotalCostFormula
		{
			get
			{
				return materialTotalCostFormula;
			}
			set
			{
				this.materialTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SUBTOTALFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string SubcontractorTotalCostFormula
		{
			get
			{
				return subcontractorTotalCostFormula;
			}
			set
			{
				this.subcontractorTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LABTOTALFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string LaborTotalCostFormula
		{
			get
			{
				return laborTotalCostFormula;
			}
			set
			{
				this.laborTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CONTOTALFORM" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ConsumableTotalCostFormula
		{
			get
			{
				return consumableTotalCostFormula;
			}
			set
			{
				this.consumableTotalCostFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SCHEDULED" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? IsScheduled
		{
			get
			{
				if (isScheduled == null)
				{
					isScheduled = true; // null not allowed
				}
				return isScheduled;
			}
			set
			{
				isScheduled = value;
			}
		}


		public virtual string PlanningType
		{
			get
			{
				if (IsScheduled.Value)
				{
					return s_SCHEDULED;
				}
				return s_UNPLANNED;
			}
			set
			{
				if (value.Equals(s_SCHEDULED))
				{
					IsScheduled = true;
				}
				else
				{
					IsScheduled = false;
				}
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="HAS_PRODUCTIVITY" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? HasProductivity
		{
			get
			{
				if (hasProductivity == null)
				{
					hasProductivity = true; // null not allowed
				}
				return hasProductivity;
			}
			set
			{
				hasProductivity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ACTBASED" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ActivityBased
		{
			get
			{
				return activityBased;
			}
			set
			{
				this.activityBased = value;
			}
		}


		/// <summary>
		/// This boolean determines if this boq item has at least one assignment 
		/// with at least one boq field involved in assignment quantity per unit formula.
		/// 
		/// @hibernate.property column="HAS_ASSFORM" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? HasAssignmentFormula
		{
			get
			{
				return hasAssignmentFormula;
			}
			set
			{
				this.hasAssignmentFormula = value;
			}
		}


		/// <summary>
		/// This boolean determines if this boq item has in any formula field
		/// any global PV variable involved e.g. <code>VAR("mitsos") or PRJVARIABLE("george")</code>
		/// 
		/// @hibernate.property column="HAS_PVFORM" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? HasPVFormula
		{
			get
			{
				return hasPVFormula;
			}
			set
			{
				this.hasPVFormula = value;
			}
		}


		/// <summary>
		/// This String declares which column contains which PV Variables
		/// 	e.g. <code>CUSRATE1:var1,var2;CUSTXT1:mitsos,george;MARKUP:var2,mitsos</code>
		/// 
		/// @hibernate.property column="PV_VARS" type="costos_text" </summary>
		/// <returns> pvVars </returns>
		public virtual string PvVars
		{
			get
			{
				return pvVars;
			}
			set
			{
				this.pvVars = value;
			}
		}


		public virtual string CalculationType
		{
			get
			{
				if (HasProductivity.Value)
				{
					return s_PRODUCTIVITY_METHOD;
				}
				return s_TOTAL_UNITS_METHOD;
			}
			set
			{
				if (value.Equals(s_PRODUCTIVITY_METHOD))
				{
					HasProductivity = true;
				}
				else
				{
					HasProductivity = false;
				}
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DURATION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Duration
		{
			get
			{
				return duration;
			}
			set
			{
				this.duration = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GROUPCODE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string GroupCode
		{
			get
			{
				return groupCode;
			}
			set
			{
				this.groupCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GEKCODE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string GekCode
		{
			get
			{
				return gekCode;
			}
			set
			{
				this.gekCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="NOTES" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				this.notes = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SURFACETYPE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string SurfaceType
		{
			get
			{
				return surfaceType;
			}
			set
			{
				this.surfaceType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATUS" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Status
		{
			get
			{
				return status;
			}
			set
			{
				this.status = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FLAG" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? Flag
		{
			get
			{
				return flag;
			}
			set
			{
				this.flag = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRODUCTIVITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Productivity
		{
			get
			{
				return productivity;
			}
			set
			{
				this.productivity = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ADJPROD" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AdjustedProd
		{
			get
			{
				return adjustedProd;
			}
			set
			{
				this.adjustedProd = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRODFACFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ProdFactorFormula
		{
			get
			{
				return prodFactorFormula;
			}
			set
			{
				this.prodFactorFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MHFACFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string MhoursFactorFormula
		{
			get
			{
				return mhoursFactorFormula;
			}
			set
			{
				this.mhoursFactorFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ADJPRODFORM" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string AdjustedProdFormula
		{
			get
			{
				return adjustedProdFormula;
			}
			set
			{
				this.adjustedProdFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRODFACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ProdFactor
		{
			get
			{
				return prodFactor;
			}
			set
			{
				this.prodFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MHOURSFACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MhoursFactor
		{
			get
			{
				return mhoursFactor;
			}
			set
			{
				this.mhoursFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCPROF" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string LocProfile
		{
			get
			{
				return locProfile;
			}
			set
			{
				this.locProfile = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCFAC" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string LocFactor
		{
			get
			{
				return locFactor;
			}
			set
			{
				this.locFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCCOUNTRY" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string LocCountry
		{
			get
			{
				return locCountry;
			}
			set
			{
				this.locCountry = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCSTATE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string LocState
		{
			get
			{
				return locState;
			}
			set
			{
				this.locState = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MANHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal LaborManhours
		{
			get
			{
				return laborManhours;
			}
			set
			{
				this.laborManhours = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EQUHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal EquipmentHours
		{
			get
			{
				return equipmentHours;
			}
			set
			{
				this.equipmentHours = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNITMHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal UnitManhours
		{
			get
			{
				return unitManhours;
			}
			set
			{
				this.unitManhours = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="AUNITMHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AdjustedUnitManhours
		{
			get
			{
				return adjustedUnitManhours;
			}
			set
			{
				this.adjustedUnitManhours = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PUBLISHEDITEMCODE" type="costos_string" index="IDX_PBCODE" </summary>
		/// <returns> String </returns>
		public virtual string PublishedItemCode
		{
			get
			{
				return publishedItemCode;
			}
			set
			{
				this.publishedItemCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PUBLISHEDRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal PublishedRate
		{
			get
			{
				return publishedRate;
			}
			set
			{
				this.publishedRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PUBLISHEDREVISIONCODE" type="costos_string" index="IDX_PBRVCODE" </summary>
		/// <returns> String </returns>
		public virtual string PublishedRevisionCode
		{
			get
			{
				return publishedRevisionCode;
			}
			set
			{
				this.publishedRevisionCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// hibernate.property column="ACTIVITYID" type="costos_string"
		/// return String
		/// </summary>
		//	public String getActivityId() {
		//		return activityId;
		//	}
		//
		//	public void setActivityId(String activityId) {
		//		this.activityId = activityId;
		//	}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GENERATIONID" type="costos_string" index="IDX_GENID" </summary>
		/// <returns> String </returns>
		public virtual string GenerationId
		{
			get
			{
				return generationId;
			}
			set
			{
				this.generationId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="VARS" type="costos_text" </summary>
		/// <returns> Custom BOQ Item Variables (key:value pairs separated by ;) </returns>
		public virtual string Vars
		{
			get
			{
				return vars;
			}
			set
			{
				this.vars = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BIMTYPE" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string BimType
		{
			get
			{
				return bimType;
			}
			set
			{
				this.bimType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BIMMATERIAL" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string BimMaterial
		{
			get
			{
				return bimMaterial;
			}
			set
			{
				this.bimMaterial = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUANTITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				this.quantity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MEASQUANT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MeasuredQuantity
		{
			get
			{
				return measuredQuantity;
			}
			set
			{
				this.measuredQuantity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ESTQUANT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal EstimatedQuantity
		{
			get
			{
				return estimatedQuantity;
			}
			set
			{
				this.estimatedQuantity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUANTLOSS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal QuantityLoss
		{
			get
			{
				return quantityLoss;
			}
			set
			{
				this.quantityLoss = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SECQUANTITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SecondQuantity
		{
			get
			{
				return secondQuantity;
			}
			set
			{
				this.secondQuantity = value;
			}
		}


		public virtual decimal calculateSecondQuantity()
		{
			decimal secondQuantity = BigDecimalMath.ZERO;
			try
			{
				secondQuantity = BigDecimalMath.div(Quantity, UnitsDiv);
			}
			catch (ArithmeticException)
			{
				secondQuantity = BigDecimalMath.ZERO;
			}

			return secondQuantity;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ACCURACY" type="costos_string" </summary>
		/// <returns> BigDecimal </returns>
		public virtual string Accuracy
		{
			get
			{
				return accuracy;
			}
			set
			{
				this.accuracy = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MARKUP" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Markup
		{
			get
			{
				return markup;
			}
			set
			{
				this.markup = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDMAT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedMaterialRate
		{
			get
			{
				return awardedMaterialRate;
			}
			set
			{
				this.awardedMaterialRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDINS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedInsuranceRate
		{
			get
			{
				return awardedInsuranceRate;
			}
			set
			{
				this.awardedInsuranceRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDSUB" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedSubcontractorRate
		{
			get
			{
				return awardedSubcontractorRate;
			}
			set
			{
				this.awardedSubcontractorRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDMHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedManhours
		{
			get
			{
				return awardedManhours;
			}
			set
			{
				this.awardedManhours = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDIND" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedIndirectRate
		{
			get
			{
				return awardedIndirectRate;
			}
			set
			{
				this.awardedIndirectRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDSHIP" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedShipmentRate
		{
			get
			{
				return awardedShipmentRate;
			}
			set
			{
				this.awardedShipmentRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="AWDTOTAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AwardedTotalRate
		{
			get
			{
				return awardedTotalRate;
			}
			set
			{
				this.awardedTotalRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ESCALATION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal EscalationCost
		{
			get
			{
				return escalationCost;
			}
			set
			{
				this.escalationCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNITS_DIV" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal UnitsDiv
		{
			get
			{
				return unitsDiv;
			}
			set
			{
				if (value == null)
				{
					value = BigDecimalMath.ONE;
				}
				this.unitsDiv = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ASSRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AssemblyRate
		{
			get
			{
				return assemblyRate;
			}
			set
			{
				this.assemblyRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal LaborRate
		{
			get
			{
				return laborRate;
			}
			set
			{
				this.laborRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SubcontractorRate
		{
			get
			{
				return subcontractorRate;
			}
			set
			{
				this.subcontractorRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBQUOTERATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal QuotedSubcontractorRate
		{
			get
			{
				return quotedSubcontractorRate;
			}
			set
			{
				this.quotedSubcontractorRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EQURATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal EquipmentRate
		{
			get
			{
				return equipmentRate;
			}
			set
			{
				this.equipmentRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ConsumableRate
		{
			get
			{
				return consumableRate;
			}
			set
			{
				this.consumableRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MaterialRate
		{
			get
			{
				return materialRate;
			}
			set
			{
				this.materialRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATQUOTERATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal QuotedMaterialRate
		{
			get
			{
				return quotedMaterialRate;
			}
			set
			{
				this.quotedMaterialRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal FabricationRate
		{
			get
			{
				return fabricationRate;
			}
			set
			{
				this.fabricationRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SHIPRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ShipmentRate
		{
			get
			{
				return shipmentRate;
			}
			set
			{
				this.shipmentRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ASSCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal AssemblyTotalCost
		{
			get
			{
				return assemblyTotalCost;
			}
			set
			{
				this.assemblyTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LABCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal LaborTotalCost
		{
			get
			{
				return laborTotalCost;
			}
			set
			{
				this.laborTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SubcontractorTotalCost
		{
			get
			{
				return subcontractorTotalCost;
			}
			set
			{
				this.subcontractorTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EQUCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal EquipmentTotalCost
		{
			get
			{
				return equipmentTotalCost;
			}
			set
			{
				this.equipmentTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ConsumableTotalCost
		{
			get
			{
				return consumableTotalCost;
			}
			set
			{
				this.consumableTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MaterialTotalCost
		{
			get
			{
				return materialTotalCost;
			}
			set
			{
				this.materialTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FABCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal FabricationTotalCost
		{
			get
			{
				return fabricationTotalCost;
			}
			set
			{
				this.fabricationTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SHIPCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ShipmentTotalCost
		{
			get
			{
				return shipmentTotalCost;
			}
			set
			{
				this.shipmentTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATRESCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MaterialResourceTotalCost
		{
			get
			{
				return materialResourceTotalCost;
			}
			set
			{
				this.materialResourceTotalCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Rate
		{
			get
			{
				return rate;
			}
			set
			{
				this.rate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TOTALCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> totalCost </returns>
		public virtual decimal TotalCost
		{
			get
			{
				return totalCost;
			}
			set
			{
				this.totalCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fixedCost </returns>
		public virtual decimal FixedCost
		{
			get
			{
				return fixedCost;
			}
			set
			{
				this.fixedCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OFFSECRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal OfferedSecondRate
		{
			get
			{
				return offeredSecondRate;
			}
			set
			{
				this.offeredSecondRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OFFPRICE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal OfferedPrice
		{
			get
			{
				return offeredPrice;
			}
			set
			{
				this.offeredPrice = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OFFRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal OfferedRate
		{
			get
			{
				return offeredRate;
			}
			set
			{
				this.offeredRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SECRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SecondRate
		{
			get
			{
				return secondRate;
			}
			set
			{
				this.secondRate = value;
			}
		}


		//////////////////////////////////////////////
		// CALCULATION METHODS:
		//////////////////////////////////////////////
		//	public Map<String,BigDecimal> getBoqItemLaborCurrenciesTotalCost() {
		//		Map<String,BigDecimal> map = new HashMap<String,BigDecimal>();		
		//		if ( getBoqItemLaborSet() != null ) {
		//			Iterator iter = getBoqItemLaborSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable)iter.next();				
		//				BigDecimal boqItemLaborRate = map.get(boqItemLaborTable.getLaborTable().getCurrency());
		//				if ( boqItemLaborRate == null )
		//					boqItemLaborRate = new BigDecimalFixed("0.0");
		//				boqItemLaborRate = boqItemLaborRate.add(boqItemLaborTable.getTotalCost());
		//				map.put(boqItemLaborTable.getLaborTable().getCurrency(), boqItemLaborRate);				
		//			}
		//		}
		//
		//		return map;
		//	}

		public virtual decimal BoqItemLaborTotalCost
		{
			get
			{
				decimal boqItemLaborRate = BigDecimalMath.ZERO;
    
				if (BoqItemLaborSet != null)
				{
					System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
					while (iter.MoveNext())
					{
						BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable) iter.Current;
						boqItemLaborRate = boqItemLaborRate + boqItemLaborTable.TotalCost;
					}
				}
    
				return boqItemLaborRate;
			}
		}

		public virtual decimal calculateLaborManhours()
		{
			decimal laborManhours = BigDecimalMath.ZERO;

			if (BoqItemLaborSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable) iter.Current;
					laborManhours = laborManhours + boqItemLaborTable.TotalUnits;
				}
			}

			return laborManhours;
		}

		public virtual decimal calculateAssemblyLaborManhours()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + (boqItemAssemblyTable.calculateFinalLaborManhours() * Quantity);
				}
			}

			return boqItemRate;
		}

		public virtual decimal calculateEquipmentHours()
		{
			decimal equipmentHours = BigDecimalMath.ZERO;

			if (BoqItemEquipmentSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable) iter.Current;
					equipmentHours = equipmentHours + boqItemEquipmentTable.TotalUnits;
				}
			}

			return equipmentHours;
		}

		public virtual decimal calculateAssemblyEquipmentHours()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + (boqItemAssemblyTable.calculateFinalEquipmentHours() * Quantity);
				}
			}

			return boqItemRate;
		}

		public virtual decimal calculateLaborRate(bool ds)
		{
			decimal boqItemLaborRate = BigDecimalMath.ZERO;

			if (BoqItemLaborSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable) iter.Current;
					boqItemLaborRate = boqItemLaborRate + boqItemLaborTable.calculateFinalRate(ds);
				}
			}

			return boqItemLaborRate;
		}

		public virtual decimal calculateAssemblyLaborRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalLaborRate();
				}
			}

			return boqItemRate;
		}

		public virtual decimal calculateLaborRate()
		{
			decimal boqItemLaborRate = BigDecimalMath.ZERO;

			if (BoqItemLaborSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable) iter.Current;
					boqItemLaborRate = boqItemLaborRate + boqItemLaborTable.calculateFinalRate();
				}
			}

			return boqItemLaborRate;
		}

		//	public BigDecimal getBoqItemLaborIKARate() {
		//		BigDecimal boqItemLaborRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemLaborSet() != null ) {
		//			Iterator iter = getBoqItemLaborSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable)iter.next();
		//				boqItemLaborRate = boqItemLaborRate.add(boqItemLaborTable.getFinalIKARate());
		//			}
		//		}
		//
		//		return boqItemLaborRate;
		//	}

		//	public Map<String,BigDecimal> getBoqItemConsumableCurrenciesTotalCost() {
		//		Map<String,BigDecimal> map = new HashMap<String,BigDecimal>();		
		//		if ( getBoqItemConsumableSet() != null ) {
		//			Iterator iter = getBoqItemConsumableSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemConsumableTable boqItemConsumableTable = (BoqItemConsumableTable)iter.next();				
		//				BigDecimal boqItemConsumableRate = map.get(boqItemConsumableTable.getConsumableTable().getCurrency());
		//				if ( boqItemConsumableRate == null )
		//					boqItemConsumableRate = new BigDecimalFixed("0.0");
		//				boqItemConsumableRate = boqItemConsumableRate.add(boqItemConsumableTable.getTotalCost());
		//				map.put(boqItemConsumableTable.getConsumableTable().getCurrency(), boqItemConsumableRate);				
		//			}
		//		}
		//
		//		return map;
		//	}

		//	public BigDecimal getBoqItemConsumableTotalCost() {
		//		BigDecimal boqItemConsumableRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemLaborSet() != null ) {
		//			Iterator iter = getBoqItemConsumableSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemConsumableTable boqItemConsumableTable = (BoqItemConsumableTable)iter.next();
		//				boqItemConsumableRate = boqItemConsumableRate.add(boqItemConsumableTable.getTotalCost());
		//			}
		//		}
		//
		//		return boqItemConsumableRate;
		//	}

		public virtual decimal calculateConsumableRate()
		{
			decimal boqItemConsumableRate = BigDecimalMath.ZERO;

			if (BoqItemConsumableSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConsumableTable boqItemConsumableTable = (BoqItemConsumableTable) iter.Current;
					boqItemConsumableRate = boqItemConsumableRate + boqItemConsumableTable.calculateFinalRate();
				}
			}

			return boqItemConsumableRate;
		}

		public virtual decimal calculateAssemblyConsumableRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalConsumableRate();
				}
			}

			return boqItemRate;
		}

		//	public Map<String,BigDecimal> getBoqItemMaterialCurrenciesTotalCost() {
		//		Map<String,BigDecimal> map = new HashMap<String,BigDecimal>();		
		//		if ( getBoqItemMaterialSet() != null ) {
		//			Iterator iter = getBoqItemMaterialSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();				
		//				BigDecimal boqItemMaterialRate = map.get(boqItemMaterialTable.getMaterialTable().getCurrency());
		//				if ( boqItemMaterialRate == null )
		//					boqItemMaterialRate = new BigDecimalFixed("0.0");
		//				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getTotalCost());
		//				map.put(boqItemMaterialTable.getMaterialTable().getCurrency(), boqItemMaterialRate);				
		//			}
		//		}
		//
		//		return map;
		//	}

		//	public BigDecimal getBoqItemMaterialTotalCost() {
		////		BigDecimal boqItemMaterialRate = BigDecimalMath.ZERO;
		////
		////		if ( getBoqItemMaterialSet() != null ) {
		////			Iterator iter = getBoqItemMaterialSet().iterator();
		////			while ( iter.hasNext() ) {
		////				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();
		////				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getTotalCost());
		////			}
		////		}
		////
		////		return boqItemMaterialRate;
		//		return fabricationRate.multiply(getQuantity());
		//	}

		//	public BigDecimal getBoqItemMaterialCost() {
		//		BigDecimal boqItemMaterialRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemMaterialSet() != null ) {
		//			Iterator iter = getBoqItemMaterialSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();
		//				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getTotalMaterialCost());
		//			}
		//		}
		//
		//		return boqItemMaterialRate;
		//	}

		public virtual decimal calculateMaterialFabricationTotalCost()
		{
			//		BigDecimal boqItemMaterialRate = BigDecimalMath.ZERO;
			//
			//		if ( getBoqItemMaterialSet() != null ) {
			//			Iterator iter = getBoqItemMaterialSet().iterator();
			//			while ( iter.hasNext() ) {
			//				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();
			//				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getTotalFabricationCost());
			//			}
			//		}
			//
			//		return boqItemMaterialRate;
			return fabricationRate * Quantity;
		}

		public virtual decimal calculateMaterialShipmentTotalCost()
		{
			//		BigDecimal boqItemMaterialRate = BigDecimalMath.ZERO;
			//
			//		if ( getBoqItemMaterialSet() != null ) {
			//			Iterator iter = getBoqItemMaterialSet().iterator();
			//			while ( iter.hasNext() ) {
			//				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();
			//				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getTotalShipmentCost());
			//			}
			//		}
			//		return boqItemMaterialRate;
			return shipmentRate * Quantity;
		}

		// Important to have this invoked before others:
		public virtual decimal calculateMaterialResourceRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					boqItemMaterialRate = boqItemMaterialRate + boqItemMaterialTable.calculateFinalRate();
				}
			}

			return boqItemMaterialRate;
		}

		public virtual decimal calculateQuotedMaterialRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					if (boqItemMaterialTable.MaterialTable.Quoted != null && boqItemMaterialTable.MaterialTable.Quoted.Value)
					{
						boqItemMaterialRate = boqItemMaterialRate + boqItemMaterialTable.calculateFinalRate();
					}
				}
			}

			return boqItemMaterialRate;
		}

		public virtual decimal calculateAssemblyMaterialResourceRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalMaterialResourceRate();
				}
			}

			return boqItemRate;
		}

		//	public BigDecimal calculateMaterialRate() {
		//		BigDecimal boqItemMaterialRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemMaterialSet() != null ) {
		//			Iterator iter = getBoqItemMaterialSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable)iter.next();
		//				boqItemMaterialRate = boqItemMaterialRate.add(boqItemMaterialTable.getFinalMaterialRate());
		//			}
		//		}
		//
		//		return boqItemMaterialRate;
		//	}

		public virtual decimal calculateEscalationRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					decimal finalEscalationRate = boqItemMaterialTable.FinalEscalationRate;
					if (finalEscalationRate != null)
					{
						boqItemMaterialRate = boqItemMaterialRate + finalEscalationRate;
					}
				}
			}

			return boqItemMaterialRate;
		}

		public virtual decimal calculateShipmentRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					decimal finalShipmentRate = boqItemMaterialTable.FinalShipmentRate;
					if (finalShipmentRate != null)
					{
						boqItemMaterialRate = boqItemMaterialRate + finalShipmentRate;
					}
				}
			}

			return boqItemMaterialRate;
		}

		public virtual decimal calculateAssemblyShipmentRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalShipmentRate();
				}
			}

			return boqItemRate;
		}

		public virtual decimal calculateFabricationRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					if (boqItemMaterialTable.FinalFabricationRate == null)
					{
						boqItemMaterialTable.calculateFinalRate();
					}
					boqItemMaterialRate = boqItemMaterialRate + boqItemMaterialTable.FinalFabricationRate;
				}
			}

			return boqItemMaterialRate;
		}

		public virtual decimal calculateAssemblyFabricationRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalFabricationRate();
				}
			}

			return boqItemRate;
		}

		public virtual IDictionary<string, decimal> BoqItemEquipmentCurrenciesTotalCost
		{
			get
			{
				IDictionary<string, decimal> map = new Dictionary<string, decimal>();
				if (BoqItemEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable) iter.Current;
						decimal boqItemEquipmentRate = map[boqItemEquipmentTable.EquipmentTable.Currency];
						if (boqItemEquipmentRate == null)
						{
							boqItemEquipmentRate = new BigDecimalFixed("0.0");
						}
						boqItemEquipmentRate = boqItemEquipmentRate + boqItemEquipmentTable.TotalCost;
						map[boqItemEquipmentTable.EquipmentTable.Currency] = boqItemEquipmentRate;
					}
				}
    
				return map;
			}
		}

		public virtual decimal BoqItemEquipmentTotalCost
		{
			get
			{
				decimal boqItemEquipmentRate = BigDecimalMath.ZERO;
    
				if (BoqItemEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable) iter.Current;
						boqItemEquipmentRate = boqItemEquipmentRate + boqItemEquipmentTable.TotalCost;
					}
				}
    
				return boqItemEquipmentRate;
			}
		}

		public virtual decimal calculateEquipmentRate()
		{
			decimal boqItemEquipmentRate = BigDecimalMath.ZERO;

			if (BoqItemEquipmentSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable) iter.Current;
					boqItemEquipmentRate = boqItemEquipmentRate + boqItemEquipmentTable.calculateFinalRate();
				}
			}

			return boqItemEquipmentRate;
		}

		public virtual decimal calculateAssemblyEquipmentRate()
		{
			decimal boqItemRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemRate = boqItemRate + boqItemAssemblyTable.calculateFinalEquipmentRate();
				}
			}

			return boqItemRate;
		}

		//	public BigDecimal getBoqItemEquipmentDepreciationRate() {
		//		BigDecimal boqItemEquipmentDepreciationRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemEquipmentSet() != null ) {
		//			Iterator iter = getBoqItemEquipmentSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable)iter.next();
		//				boqItemEquipmentDepreciationRate = boqItemEquipmentDepreciationRate.add(boqItemEquipmentTable.calculateFinalDepreciationRate());
		//			}
		//		}
		//
		//		return boqItemEquipmentDepreciationRate;
		//	}

		/*
		public BigDecimal getBoqItemEquipmentFuelRate() {
			BigDecimal boqItemEquipmentFuelRate = BigDecimalMath.ZERO;
		
			if ( getBoqItemEquipmentSet() != null ) {
				Iterator iter = getBoqItemEquipmentSet().iterator();
				while ( iter.hasNext() ) {
					BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable)iter.next();
					boqItemEquipmentFuelRate = boqItemEquipmentFuelRate.add(boqItemEquipmentTable.calculateFinalFuelRate());
				}
			}
		
			return boqItemEquipmentFuelRate;
		}*/

		//	public Map<String,BigDecimal> getBoqItemSubcontractorCurrenciesTotalCost() {
		//		Map<String,BigDecimal> map = new HashMap<String,BigDecimal>();		
		//		if ( getBoqItemSubcontractorSet() != null ) {
		//			Iterator iter = getBoqItemSubcontractorSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable)iter.next();				
		//				BigDecimal boqItemSubcontractorRate = map.get(boqItemSubcontractorTable.getSubcontractorTable().getCurrency());
		//				if ( boqItemSubcontractorRate == null )
		//					boqItemSubcontractorRate = new BigDecimalFixed("0.0");
		//				boqItemSubcontractorRate = boqItemSubcontractorRate.add(boqItemSubcontractorTable.getTotalCost());
		//				map.put(boqItemSubcontractorTable.getSubcontractorTable().getCurrency(), boqItemSubcontractorRate);				
		//			}
		//		}
		//
		//		return map;
		//	}

		//	public BigDecimal getBoqItemSubcontractorTotalCost() {
		//		BigDecimal boqItemSubcontractorRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemSubcontractorSet() != null ) {
		//			Iterator iter = getBoqItemSubcontractorSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable)iter.next();
		//				boqItemSubcontractorRate = boqItemSubcontractorRate.add(boqItemSubcontractorTable.getTotalCost());
		//			}
		//		}
		//
		//		return boqItemSubcontractorRate;
		//	}

		public virtual decimal calculateSubcontractorRate()
		{
			decimal boqItemSubcontractorRate = BigDecimalMath.ZERO;

			if (BoqItemSubcontractorSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemSubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable) iter.Current;
					boqItemSubcontractorRate = boqItemSubcontractorRate + boqItemSubcontractorTable.calculateFinalRate();
				}
			}

			return boqItemSubcontractorRate;
		}

		public virtual decimal calculateQuotedSubcontractorRate()
		{
			decimal boqItemSubcontractorRate = BigDecimalMath.ZERO;

			if (BoqItemSubcontractorSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemSubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable) iter.Current;
					if (boqItemSubcontractorTable.SubcontractorTable.Quoted != null && boqItemSubcontractorTable.SubcontractorTable.Quoted.Value)
					{
						boqItemSubcontractorRate = boqItemSubcontractorRate + boqItemSubcontractorTable.calculateFinalRate();
					}
				}
			}

			return boqItemSubcontractorRate;
		}

		public virtual decimal calculateAssemblySubcontractorRate()
		{
			decimal boqItemMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemMaterialRate = boqItemMaterialRate + boqItemAssemblyTable.calculateFinalSubcontractorRate();
				}
			}

			return boqItemMaterialRate;
		}

		//	public BigDecimal getBoqItemSubcontractorIKARate() {
		//		BigDecimal boqItemSubcontractorRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemSubcontractorSet() != null ) {
		//			Iterator iter = getBoqItemSubcontractorSet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable)iter.next();
		//				boqItemSubcontractorRate = boqItemSubcontractorRate.add(boqItemSubcontractorTable.getFinalIKARate());
		//			}
		//		}
		//
		//		return boqItemSubcontractorRate;
		//	}

		public virtual decimal calculateAssemblyRate(bool deepRecalc)
		{
			decimal boqItemAssemblyRate = BigDecimalMath.ZERO;

			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					boqItemAssemblyRate = boqItemAssemblyRate + boqItemAssemblyTable.calculateFinalRate(deepRecalc);
				}
			}

			return boqItemAssemblyRate;
		}

		public virtual decimal calculateTotalFixedCost()
		{
			decimal totalFixedCost = decimal.Zero;

			// LineItem:
			if (BoqItemAssemblySet != null)
			{
				System.Collections.IEnumerator iter = BoqItemAssemblySet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemAssemblyTable.FinalFixedCost;
				}
			}

			// Consumable:
			if (BoqItemConsumableSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemConsumableTable boqItemConsumableTable = (BoqItemConsumableTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemConsumableTable.FinalFixedCost;
				}
			}

			// Equipment:
			if (BoqItemEquipmentSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemEquipmentTable boqItemEquipmentTable = (BoqItemEquipmentTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemEquipmentTable.FinalFixedCost;
				}
			}

			// Labor:
			if (BoqItemLaborSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemLaborTable boqItemLaborTable = (BoqItemLaborTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemLaborTable.FinalFixedCost;
				}
			}

			// Material:
			if (BoqItemMaterialSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemMaterialTable boqItemMaterialTable = (BoqItemMaterialTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemMaterialTable.FinalFixedCost;
				}
			}

			// Sub-contractor:
			if (BoqItemSubcontractorSet != null)
			{
				System.Collections.IEnumerator iter = BoqItemSubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					BoqItemSubcontractorTable boqItemSubcontractorTable = (BoqItemSubcontractorTable) iter.Current;
					totalFixedCost = totalFixedCost + boqItemSubcontractorTable.FinalFixedCost;
				}
			}

			return totalFixedCost;
		}

		//	public Map<String,BigDecimal> calculateAssemblyCurrenciesTotalCost() {
		//		Map<String,BigDecimal> map = new HashMap<String,BigDecimal>();		
		//		if ( getBoqItemAssemblySet() != null ) {
		//			Iterator iter = getBoqItemAssemblySet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable)iter.next();				
		//				BigDecimal boqItemAssemblyRate = map.get(boqItemAssemblyTable.getAssemblyTable().getCurrency());
		//				if ( boqItemAssemblyRate == null )
		//					boqItemAssemblyRate = new BigDecimalFixed("0.0");
		//				boqItemAssemblyRate = boqItemAssemblyRate.add(boqItemAssemblyTable.getTotalCost());
		//				map.put(boqItemAssemblyTable.getAssemblyTable().getCurrency(), boqItemAssemblyRate);				
		//			}
		//		}
		//
		//		return map;
		//	}

		//	public BigDecimal getBoqItemAssemblyTotalCost() {
		//		BigDecimal boqItemAssemblyRate = BigDecimalMath.ZERO;
		//
		//		if ( getBoqItemAssemblySet() != null ) {
		//			Iterator iter = getBoqItemAssemblySet().iterator();
		//			while ( iter.hasNext() ) {
		//				BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable)iter.next();
		//				boqItemAssemblyRate = boqItemAssemblyRate.add(boqItemAssemblyTable.getTotalCost());
		//			}
		//		}
		//
		//		return boqItemAssemblyRate;
		//	}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CALCULATED_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CalculatedRate
		{
			get
			{
				return calculatedRate;
			}
			set
			{
				this.calculatedRate = value;
			}
		}


		public virtual decimal calculateRate()
		{
			decimal rate = BigDecimalMath.ZERO;

			rate = rate + (calculateLaborRate() + calculateAssemblyLaborRate());
			rate = rate + (calculateConsumableRate() + calculateAssemblyConsumableRate());
			rate = rate + (calculateSubcontractorRate() + calculateAssemblySubcontractorRate());
			rate = rate + (calculateEquipmentRate() + calculateAssemblyEquipmentRate());
			rate = rate + (calculateMaterialResourceRate() + calculateAssemblyMaterialResourceRate());
			rate = rate + (calculateShipmentRate() + calculateAssemblyShipmentRate());
			rate = rate + (calculateFabricationRate() + calculateAssemblyFabricationRate());
			//rate = rate.add(calculateAssemblyRate());

			//if ( getHasProductivity() )
			// rate = rate.multiply(getQuantity());

			return rate;
		}

		public virtual decimal calculateSecondRate()
		{
			if (Rate == null || UnitsDiv == null)
			{
				return BigDecimalMath.ZERO;
			}
			try
			{
				return BigDecimalMath.mult(Rate, UnitsDiv);
			}
			catch (ArithmeticException)
			{
				return BigDecimalMath.ZERO;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CALCULATED_TOTAL_COST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CalculatedTotalCost
		{
			get
			{
				return calculatedTotalCost;
			}
			set
			{
				this.calculatedTotalCost = value;
			}
		}


		public virtual decimal calculateTotalCost()
		{
			if (Quantity == null || Rate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = Rate * Quantity;
			val + fixedCost;
			return val;
		}

		public virtual decimal calculateOfferedPrice()
		{
			if (TotalCost == null || Markup == null || EscalationCost == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = TotalCost + Markup.add(EscalationCost);
			return val;
		}

		public virtual decimal calculateOfferedRate()
		{
			if (Quantity == null || OfferedPrice == null)
			{
				return BigDecimalMath.ZERO;
			}
			try
			{
				return BigDecimalMath.div(OfferedPrice, Quantity);
			}
			catch (ArithmeticException)
			{
				return BigDecimalMath.ZERO;
			}
		}

		public virtual decimal calculateOfferedSecondRate()
		{
			if (SecondQuantity == null || OfferedPrice == null)
			{
				return BigDecimalMath.ZERO;
			}
			try
			{
				return BigDecimalMath.div(OfferedPrice, SecondQuantity);
			}
			catch (ArithmeticException)
			{
				return BigDecimalMath.ZERO;
			}
		}

		public virtual decimal calculateAssemblyTotalCost()
		{
			if (Quantity == null || AssemblyRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = AssemblyRate * Quantity;
			return val;
		}

		public virtual decimal calculateLaborTotalCost()
		{
			if (Quantity == null || LaborRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = LaborRate * Quantity;
			return val;
		}

		public virtual decimal calculateEquipmentTotalCost()
		{
			if (Quantity == null || EquipmentRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = EquipmentRate * Quantity;
			return val;
		}

		public virtual decimal calculateSubcontractorTotalCost()
		{
			if (Quantity == null || SubcontractorRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = SubcontractorRate * Quantity;
			return val;
		}

		public virtual decimal calculateMaterialResourceTotalCost()
		{
			if (Quantity == null || MaterialRate == null || FabricationRate == null || ShipmentRate == null)
			{
				return decimal.Zero;
			}
			decimal materialResourceRate = MaterialRate - FabricationRate - ShipmentRate;
			//BigDecimal val = getBoqItemMaterialResourceRate().multiply(getQuantity());
			decimal val = materialResourceRate * Quantity;
			return val;
		}

		public virtual decimal calculateMaterialTotalCost()
		{
			if (Quantity == null || MaterialRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = MaterialRate * Quantity;
			return val;
		}

		public virtual decimal calculateFabricationTotalCost()
		{
			if (Quantity == null || FabricationRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = FabricationRate * Quantity;
			return val;
		}

		public virtual decimal calculateShipmentTotalCost()
		{
			if (Quantity == null || ShipmentRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = ShipmentRate * Quantity;
			return val;
		}

		public virtual decimal calculateConsumableTotalCost()
		{
			if (Quantity == null || ConsumableRate == null)
			{
				return BigDecimalMath.ZERO;
			}
			decimal val = ConsumableRate * Quantity;
			return val;
		}

		//	
		//	public BigDecimal calculateEstimTotalCost() {
		//		if ( getEstimRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimRate().multiply(getQuantity());
		//		return val; 
		//	}	
		//
		//	public BigDecimal calculateQuotedMaterialTotalCost() {
		//		if ( getQuotedMaterialRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getQuotedMaterialRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateQuotedSubcontractorTotalCost() {
		//		if ( getQuotedSubcontractorRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getQuotedSubcontractorRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimAssemblyTotalCost() {
		//		if ( getEstimAssemblyRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimAssemblyRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimLaborTotalCost() {
		//		if ( getEstimLaborRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimLaborRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimMaterialTotalCost() {
		//		if ( getEstimMaterialRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimMaterialRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimFabricationTotalCost() {
		//		if ( getEstimFabricationRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimFabricationRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimShipmentTotalCost() {
		//		if ( getEstimShipmentRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimShipmentRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimSubcontractorTotalCost() {
		//		if ( getEstimSubcontractorRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimSubcontractorRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimEquipmentTotalCost() {
		//		if ( getEstimEquipmentRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimEquipmentRate().multiply(getQuantity());
		//		return val; 
		//	}
		//
		//	public BigDecimal calculateEstimConsumableTotalCost() {
		//		if ( getEstimConsumableRate() == null || getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal val = getEstimConsumableRate().multiply(getQuantity());
		//		return val;
		//	}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SECOND_UNIT" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string SecondUnit
		{
			get
			{
				return secondUnit;
			}
			set
			{
				if (string.ReferenceEquals(value, null))
				{
					value = unit;
				}
				this.secondUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WRSLKP" type="costos_string" index="IDX_WSLKP" </summary>
		/// <returns> Date </returns>
		public virtual string WorksheetLookup
		{
			get
			{
				return worksheetLookup;
			}
			set
			{
				this.worksheetLookup = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PAYMENT_DATE" type="timestamp" </summary>
		/// <returns> String </returns>
		public virtual DateTime PaymentDate
		{
			get
			{
				return paymentDate;
			}
			set
			{
				this.paymentDate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATE_DATE" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CreateDate
		{
			get
			{
				return createDate;
			}
			set
			{
				this.createDate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LAST_UPDATE" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				this.lastUpdate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EDITORID" type="costos_string" index="IDX_EDITORID" </summary>
		/// <returns> Date </returns>
		public virtual string EditorId
		{
			get
			{
				return editorId;
			}
			set
			{
				this.editorId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ESTIMATOR" type="costos_string" index="IDX_ESTIMATORID" </summary>
		/// <returns> Date </returns>
		public virtual string EstimatorId
		{
			get
			{
				return estimatorId;
			}
			set
			{
				this.estimatorId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEUSERID" type="costos_string" </summary>
		/// <returns> Date </returns>
		public virtual string CreateUserId
		{
			get
			{
				return createUserId;
			}
			set
			{
				this.createUserId = value;
			}
		}


		public virtual decimal calculateTotalConditionsQuantity()
		{

			int manualType = 0;
			int bimType = 0;
			int ostType = 0;
			int mapType = 0;
			int functionType = 0;

			decimal totalQty = BigDecimalMath.ZERO;
			if (BoqItemConditionSet == null)
			{
				return totalQty;
			}

			IEnumerator<BoqItemConditionTable> iter = BoqItemConditionSet.GetEnumerator();
			while (iter.MoveNext())
			{
				BoqItemConditionTable boqItemConditionTable = iter.Current;
				if (boqItemConditionTable.ConditionTable.Operand == null)
				{
					totalQty = totalQty + boqItemConditionTable.FinalQuantity;
				}
				else if (boqItemConditionTable.ConditionTable.Operand.Equals(ConditionTable.DEDUCTION_OPERAND))
				{
					totalQty = totalQty - boqItemConditionTable.FinalQuantity;
				}
				else
				{
					totalQty = totalQty + boqItemConditionTable.FinalQuantity;
				}

				string type = boqItemConditionTable.ConditionTable.TakeOffType;
				if (type.Equals(ConditionTable.MANUAL))
				{
					manualType++;
				}
				else if (type.Equals(ConditionTable.TAKEOFF))
				{
					ostType++;
				}
				else if (type.Equals(ConditionTable.FUNCTION))
				{
					functionType++;
				}
				else if (type.Equals(ConditionTable.IFC_FILE))
				{
					bimType++;
				}
				else if (type.Equals(ConditionTable.MAP))
				{
					mapType++;
				}
			}

			if (mapType > bimType && mapType > manualType && mapType > ostType && mapType > functionType)
			{
				TakeoffQuantityType = TAKEOFF_TYPE_MAP;
			}
			else if (bimType > mapType && bimType > manualType && bimType > ostType && bimType > functionType)
			{
				TakeoffQuantityType = TAKEOFF_TYPE_BIM;
			}
			else if (ostType > mapType && ostType > manualType && ostType > bimType && ostType > functionType)
			{
				TakeoffQuantityType = TAKEOFF_TYPE_OST;
			}
			else if (functionType > mapType && functionType > manualType && functionType > bimType && functionType > ostType)
			{
				TakeoffQuantityType = TAKEOFF_TYPE_FUNCTION;
			}
			else if (manualType > mapType && manualType > functionType && manualType > bimType && manualType > ostType)
			{
				TakeoffQuantityType = TAKEOFF_TYPE_MANUAL;
			}
			else
			{
				TakeoffQuantityType = TAKEOFF_TYPE_NONE;
			}

			return totalQty;
		}

		//	public BigDecimal calculateTotalEquipmentCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal equipmentRate = calculateEquipmentRate();
		//
		//		totalRate = equipmentRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyEquipmentRate = boqItemAssembly.getAssemblyTable().getAssemblyEquipmentRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor3());
		//
		//				try {
		//					assemblyEquipmentRate = BigDecimalMath.div(assemblyEquipmentRate,getAdjustedProd());
		//				} catch(ArithmeticException ex) {
		//					assemblyEquipmentRate = BigDecimalMath.ZERO;
		//				}
		//			}
		//			else { // Total Units
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//
		//			assemblyEquipmentRate = assemblyEquipmentRate.multiply(getQuantity());
		//			totalRate = totalRate.add(assemblyEquipmentRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalEquipmentDepreciationCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal equipmentDepreciationRate = getBoqItemEquipmentDepreciationRate();
		//
		//		totalRate = equipmentDepreciationRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyEquipmentRate = boqItemAssembly.getAssemblyTable().getAssemblyEquipmentDepreciationRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor3());
		//				try {
		//					assemblyEquipmentRate = BigDecimalMath.div(assemblyEquipmentRate,getAdjustedProd());
		//				} catch(ArithmeticException ex) {
		//					assemblyEquipmentRate = BigDecimalMath.ZERO;
		//				}
		//			}
		//			else { // Total Units
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//
		//			assemblyEquipmentRate = assemblyEquipmentRate.multiply(getQuantity());
		//			totalRate = totalRate.add(assemblyEquipmentRate);
		//		}
		//
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalEquipmentFuelCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal equipmentRate = getBoqItemEquipmentFuelRate();
		//
		//		totalRate = equipmentRate.multiply(getQuantity());
		//		// Find Equipment in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyEquipmentRate = boqItemAssembly.getAssemblyTable().getAssemblyEquipmentFuelRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getFactor3());				
		//				try {
		//					assemblyEquipmentRate = BigDecimalMath.div(assemblyEquipmentRate,getAdjustedProd());
		//				} catch(ArithmeticException ex) {
		//					assemblyEquipmentRate = BigDecimalMath.ZERO;
		//				}
		//			}
		//			else { // Total Units
		//				assemblyEquipmentRate = assemblyEquipmentRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//
		//			assemblyEquipmentRate = assemblyEquipmentRate.multiply(getQuantity());
		//			totalRate = totalRate.add(assemblyEquipmentRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalLaborCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal laborRate = calculateLaborRate();
		//
		//		totalRate = laborRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyLaborRate = boqItemAssembly.getAssemblyTable().getAssemblyLaborRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor3());				
		//				try {
		//					assemblyLaborRate = BigDecimalMath.div(assemblyLaborRate,getAdjustedProd());
		//				} catch(ArithmeticException ex) {
		//					assemblyLaborRate = BigDecimalMath.ZERO;
		//				}
		//			}
		//			else { // Total Units
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblyLaborRate = assemblyLaborRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblyLaborRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalLaborIKACost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal laborIKARate = getBoqItemLaborIKARate();
		//
		//		totalRate = laborIKARate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyLaborRate = boqItemAssembly.getAssemblyTable().getAssemblyLaborIKARate();			
		//			if ( getHasProductivity() ) {
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getFactor3());				
		//				try {
		//					assemblyLaborRate = BigDecimalMath.div(assemblyLaborRate,getAdjustedProd());
		//				} catch(ArithmeticException ex) {
		//					assemblyLaborRate = BigDecimalMath.ZERO;
		//				}
		//			}
		//			else { // Total Units
		//				assemblyLaborRate = assemblyLaborRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblyLaborRate = assemblyLaborRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblyLaborRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	// INCLUDES FABRICATION + SHIPMENT + MATERIAL
		//	public BigDecimal calculateTotalMaterialCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal materialRate = calculateMaterialRate();
		//
		//		materialRate = materialRate.add(calculateFabricationRate());
		//		materialRate = materialRate.add(calculateShipmentRate());
		//
		//		totalRate = materialRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyMaterialRate = boqItemAssembly.getAssemblyTable().getAssemblyMaterialTotalRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyMaterialRate = assemblyMaterialRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyMaterialRate = assemblyMaterialRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyMaterialRate = assemblyMaterialRate.multiply(boqItemAssembly.getFactor3());	
		//
		//				//				try {
		//				//					assemblyMaterialRate = BigDecimalMath.div(assemblyMaterialRate,getProductivity());
		//				//				} catch(ArithmeticException ex) {
		//				//					assemblyMaterialRate = BigDecimalMath.ZERO;
		//				//				}
		//			}
		//			else { // Total Units
		//				assemblyMaterialRate = assemblyMaterialRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblyMaterialRate = assemblyMaterialRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblyMaterialRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalSubcontractorCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal subcontractorRate = calculateSubcontractorRate();
		//
		//		totalRate = subcontractorRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblySubcontractorRate = boqItemAssembly.getAssemblyTable().getAssemblySubcontractorRate();			
		//			if ( getHasProductivity() ) {
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor1());
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor2());
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor3());					
		//				//				try {
		//				//					assemblySubcontractorRate = BigDecimalMath.div(assemblySubcontractorRate,getProductivity());
		//				//				} catch(ArithmeticException ex) {
		//				//					assemblySubcontractorRate = BigDecimalMath.ZERO;
		//				//				}
		//			}
		//			else { // Total Units
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblySubcontractorRate = assemblySubcontractorRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblySubcontractorRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalSubcontractorIKACost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal subcontractorIKARate = getBoqItemSubcontractorIKARate();
		//
		//		totalRate = subcontractorIKARate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblySubcontractorRate = boqItemAssembly.getAssemblyTable().getAssemblySubcontractorIKARate();			
		//			if ( getHasProductivity() ) {
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor1());
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor2());
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getFactor3());				
		//				//assemblySubcontractorRate = assemblySubcontractorRate.divide(getProductivity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);				
		//			}
		//			else { // Total Units
		//				assemblySubcontractorRate = assemblySubcontractorRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblySubcontractorRate = assemblySubcontractorRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblySubcontractorRate);
		//		}
		//		return totalRate;
		//	}
		//
		//	public BigDecimal calculateTotalConsumableCost() {
		//		if ( getQuantity() == null )
		//			return BigDecimalMath.ZERO;
		//		BigDecimal totalRate = BigDecimalMath.ZERO;
		//		BigDecimal consumableRate = calculateConsumableRate();
		//
		//		totalRate = consumableRate.multiply(getQuantity());
		//		// Find Labors in Assemblies:
		//		Iterator iter = getBoqItemAssemblySet().iterator();
		//		while ( iter.hasNext() ) {
		//			BoqItemAssemblyTable boqItemAssembly = (BoqItemAssemblyTable)iter.next();
		//			BigDecimal assemblyConsumableRate = boqItemAssembly.getAssemblyTable().getAssemblyConsumableRate();			
		//			if ( getHasProductivity() ) {
		//				assemblyConsumableRate = assemblyConsumableRate.multiply(boqItemAssembly.getFactor1());
		//				assemblyConsumableRate = assemblyConsumableRate.multiply(boqItemAssembly.getFactor2());
		//				assemblyConsumableRate = assemblyConsumableRate.multiply(boqItemAssembly.getFactor3());				
		//				//assemblyConsumableRate = assemblyConsumableRate.divide(getProductivity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);				
		//			}
		//			else { // Total Units
		//				assemblyConsumableRate = assemblyConsumableRate.multiply(boqItemAssembly.getTotalUnits());
		//			}
		//			assemblyConsumableRate = assemblyConsumableRate.multiply(getQuantity());
		//
		//			totalRate = totalRate.add(assemblyConsumableRate);
		//		}
		//		return totalRate;
		//	}

		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemAssemblyTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemAssemblyTable> BoqItemAssemblySet
		{
			get
			{
				return boqItemAssemblySet;
			}
			set
			{
				this.boqItemAssemblySet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemLaborTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemLaborTable> BoqItemLaborSet
		{
			get
			{
				return boqItemLaborSet;
			}
			set
			{
				this.boqItemLaborSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemMaterialTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemMaterialTable> BoqItemMaterialSet
		{
			get
			{
				return boqItemMaterialSet;
			}
			set
			{
				this.boqItemMaterialSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemSubcontractorTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemSubcontractorTable> BoqItemSubcontractorSet
		{
			get
			{
				return boqItemSubcontractorSet;
			}
			set
			{
				this.boqItemSubcontractorSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemConsumableTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemConsumableTable> BoqItemConsumableSet
		{
			get
			{
				return boqItemConsumableSet;
			}
			set
			{
				this.boqItemConsumableSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemConditionTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemConditionTable> BoqItemConditionSet
		{
			get
			{
				return boqItemConditionSet;
			}
			set
			{
				this.boqItemConditionSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.QuoteItemTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<object> QuoteItemSet
		{
			get
			{
				return quoteItemSet;
			}
			set
			{
				this.quoteItemSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemEquipmentTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<BoqItemEquipmentTable> BoqItemEquipmentSet
		{
			get
			{
				return boqItemEquipmentSet;
			}
			set
			{
				this.boqItemEquipmentSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="BOQITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemTable> ParamItemSet
		{
			get
			{
				return paramItemSet;
			}
			set
			{
				this.paramItemSet = value;
			}
		}


		public override string ToString()
		{
			return Code + ". " + Title;
		}

		public override DataFlavor[] TransferDataFlavors
		{
			get
			{
				lock (this)
				{
					return s_supportedDataFlavors;
				}
			}
		}

		public override bool isDataFlavorSupported(DataFlavor flavor)
		{
			return DataFlavors.boqitemDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public override object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.boqitemDataFlavor.Equals(flavor))
				{
					return this;
				}
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public virtual IList<BaseTable> NewDatabaseResources
		{
			get
			{
				IList<BaseTable> list = new List<BaseTable>();
				long? dbCreationDate = DatabaseDBUtil.Properties.getLongProperty("database.creationdate");
    
				Session session = DatabaseDBUtil.currentSession();
				Transaction tx = session.beginTransaction();
    
				try
				{
					if (BoqItemEquipmentSet != null)
					{
						IEnumerator<BoqItemEquipmentTable> iter = BoqItemEquipmentSet.GetEnumerator();
						while (iter.MoveNext())
						{
							EquipmentTable equipmentTable = (EquipmentTable) iter.Current.EquipmentTable.clone();
							equipmentTable.EquipmentId = equipmentTable.DatabaseId;
							if (!equipmentTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(EquipmentTable), equipmentTable.DatabaseId) == null)
							{
								// this does not relate to current database
								list.Add(equipmentTable);
							}
						}
					}
    
					if (BoqItemSubcontractorSet != null)
					{
						IEnumerator<BoqItemSubcontractorTable> iter = BoqItemSubcontractorSet.GetEnumerator();
						while (iter.MoveNext())
						{
							SubcontractorTable subcontractorTable = (SubcontractorTable) iter.Current.SubcontractorTable.clone();
							subcontractorTable.SubcontractorId = subcontractorTable.DatabaseId;
							if (!subcontractorTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(SubcontractorTable), subcontractorTable.DatabaseId) == null)
							{
								// this does not relate to current database
								list.Add(subcontractorTable);
							}
						}
					}
    
					if (BoqItemLaborSet != null)
					{
						IEnumerator<BoqItemLaborTable> iter = BoqItemLaborSet.GetEnumerator();
						while (iter.MoveNext())
						{
							LaborTable laborTable = (LaborTable) iter.Current.LaborTable.clone();
							laborTable.LaborId = laborTable.DatabaseId;
							if (!laborTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(LaborTable), laborTable.DatabaseId) == null)
							{
								// this does not relate to current database
								list.Add(laborTable);
							}
						}
					}
    
					if (BoqItemMaterialSet != null)
					{
						IEnumerator<BoqItemMaterialTable> iter = BoqItemMaterialSet.GetEnumerator();
						while (iter.MoveNext())
						{
							MaterialTable materialTable = (MaterialTable) iter.Current.MaterialTable.clone();
							materialTable.MaterialId = materialTable.DatabaseId;
							if (!materialTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(MaterialTable), materialTable.DatabaseId) == null)
							{
								// this does not relate to current database
								list.Add(materialTable);
							}
						}
					}
    
					if (BoqItemConsumableSet != null)
					{
						IEnumerator<BoqItemConsumableTable> iter = BoqItemConsumableSet.GetEnumerator();
						while (iter.MoveNext())
						{
							ConsumableTable consumableTable = (ConsumableTable) iter.Current.ConsumableTable.clone();
							consumableTable.ConsumableId = consumableTable.DatabaseId;
							if (!consumableTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(ConsumableTable), consumableTable.DatabaseId) == null)
							{
								// this does not relate to current database
								list.Add(consumableTable);
							}
						}
					}
    
					tx.commit();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					Console.Write(ex.StackTrace);
					tx.rollback();
					DatabaseDBUtil.closeSession();
					return new List<BaseTable>();
				}
				DatabaseDBUtil.closeSession();
				return list;
			}
		}

		public virtual void loadBimMaterialsAndTypes()
		{
			StringBuilder matBuf = new StringBuilder();
			StringBuilder typBuf = new StringBuilder();

			// Find Bim Materials and Types:
			if (BoqItemConditionSet != null)
			{
				ISet<string> materialNames = new HashSet<string>();
				ISet<string> typeNames = new HashSet<string>();
				IEnumerator<BoqItemConditionTable> iter = BoqItemConditionSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemConditionTable boqConTable = iter.Current;
					ConditionTable conTable = boqConTable.ConditionTable;
					if (!string.ReferenceEquals(conTable.TakeOffType, null) && conTable.TakeOffType.Equals(ConditionTable.IFC_FILE))
					{
						string material = conTable.BimMaterial;
						string type = conTable.BimType;
						if (!string.ReferenceEquals(material, null) && !material.Equals("") && !materialNames.Contains(material))
						{
							materialNames.Add(material);
							if (matBuf.Length != 0)
							{
								matBuf.Append(", ");
							}
							matBuf.Append(material);
						}
						if (!string.ReferenceEquals(type, null) && !type.Equals("") && !typeNames.Contains(type))
						{
							typeNames.Add(type);
							if (typBuf.Length != 0)
							{
								typBuf.Append(", ");
							}
							typBuf.Append(type);
						}
					}
				}
			}
			BimMaterial = matBuf.ToString();
			BimType = typBuf.ToString();
		}

		public virtual AssemblyTable convertToAssembly(ProjectDBUtil prjDBUtil, string currencyCode, bool createNew, bool replaceMissing, bool replaceOnline, bool keepIds)
		{

			loadBimMaterialsAndTypes();
			Query q = null;
			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());
			long? dbCreationDate = DatabaseDBUtil.Properties.getLongProperty("database.creationdate");

			AssemblyTable obj = BlankResourceInitializer.createBlankAssembly(this);

			obj.ItemCode = PublishedItemCode;
			obj.PublishedRevisionCode = PublishedRevisionCode;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.UnitManhours = AdjustedUnitManhours;
			obj.ActivityBased = ActivityBased;
			obj.Quantity = Quantity;
			obj.Accuracy = Accuracy;
			obj.LastUpdate = LastUpdate;
			obj.Description = Description;
			obj.BimType = BimType;
			obj.BimMaterial = BimMaterial;
			obj.Virtual = false;
			obj.VirtualEquipment = false;
			obj.VirtualSubcontractor = false;
			obj.VirtualLabor = false;
			obj.VirtualMaterial = false;
			obj.VirtualConsumable = false;
			obj.Vars = Vars;

			if (prjDBUtil != null && StringUtils.isNullOrBlank(LocState))
			{
				obj.StateProvince = prjDBUtil.Properties.getProperty("project.state.province");
			}
			else
			{
				obj.StateProvince = LocState;
			}

			if (prjDBUtil != null && StringUtils.isNullOrBlank(LocCountry))
			{
				obj.Country = prjDBUtil.Properties.getProperty("project.country"); // MUST ADD A FIELD IN PROJECT!
			}
			else
			{
				obj.Country = LocCountry;
			}

			obj.Unit = Unit;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Productivity = AdjustedProd;
			obj.PublishedRate = PublishedRate;
			obj.PublishedRevisionCode = PublishedItemCode;
			obj.Title = Title;
			obj.Notes = Notes;
			obj.ExtraCode1 = ExtraCode1;
			obj.ExtraCode2 = ExtraCode2;
			obj.ExtraCode3 = ExtraCode3;
			obj.ExtraCode4 = ExtraCode4;
			obj.ExtraCode5 = ExtraCode5;
			obj.ExtraCode6 = ExtraCode6;
			obj.ExtraCode7 = ExtraCode7;
			obj.ExtraCode8 = ExtraCode8;
			obj.ExtraCode9 = ExtraCode9;
			obj.ExtraCode10 = ExtraCode10;
			obj.PuGroupCodeFactor = PuGroupCodeFactor;
			obj.PuGekCodeFactor = PuGekCodeFactor;
			obj.PuExtraCode1Factor = PuExtraCode1Factor;
			obj.PuExtraCode2Factor = PuExtraCode2Factor;
			obj.PuExtraCode3Factor = PuExtraCode3Factor;
			obj.PuExtraCode4Factor = PuExtraCode4Factor;
			obj.PuExtraCode5Factor = PuExtraCode5Factor;
			obj.PuExtraCode6Factor = PuExtraCode6Factor;
			obj.PuExtraCode7Factor = PuExtraCode7Factor;
			obj.CustomText1 = CustomText1;
			obj.CustomText2 = CustomText2;
			obj.CustomText3 = CustomText3;
			obj.CustomText4 = CustomText4;
			obj.CustomText5 = CustomText5;
			obj.CustomText6 = CustomText6;
			obj.CustomText7 = CustomText7;
			obj.CustomText8 = CustomText8;
			obj.CustomText9 = CustomText9;
			obj.CustomText10 = CustomText10;
			obj.CustomText11 = CustomText11;
			obj.CustomText12 = CustomText12;
			obj.CustomText13 = CustomText13;
			obj.CustomText14 = CustomText14;
			obj.CustomText15 = CustomText15;
			obj.CustomText16 = CustomText16;
			obj.CustomText17 = CustomText17;
			obj.CustomText18 = CustomText18;
			obj.CustomText19 = CustomText19;
			obj.CustomText20 = CustomText20;
			obj.Currency = currencyCode;
			obj.EditorId = DatabaseDBUtil.Properties.UserId;
			if (prjDBUtil != null)
			{
				obj.Project = prjDBUtil.Properties.getProperty("project.code") + " - " + prjDBUtil.Properties.getProperty("project.name");
			}

			if (keepIds)
			{
				obj.Id = Id;
			}

			//obj.setRate(getRate());

			bool closeProjectSession = false;

			Session prjSession = prjDBUtil.currentSession();
			Session session = DatabaseDBUtil.currentSession();
			Transaction tx = session.beginTransaction();

			if (createNew)
			{
				prjSession = prjDBUtil.currentSession();
				session = DatabaseDBUtil.currentSession();
				tx = session.beginTransaction();
				closeProjectSession = !prjDBUtil.hasOpenedSession();
			}

			try
			{
				ISet<object> assemblySet = new HashSet<object>();
				ISet<object> equipmentSet = new HashSet<object>();
				ISet<object> subcontractorSet = new HashSet<object>();
				ISet<object> laborSet = new HashSet<object>();
				ISet<object> materialSet = new HashSet<object>();
				ISet<object> consumableSet = new HashSet<object>();

				if (BoqItemAssemblySet != null)
				{
					assemblySet.addAll(BoqItemAssemblySet);
				}
				if (BoqItemEquipmentSet != null)
				{
					equipmentSet.addAll(BoqItemEquipmentSet);
				}
				if (BoqItemSubcontractorSet != null)
				{
					subcontractorSet.addAll(BoqItemSubcontractorSet);
				}
				if (BoqItemLaborSet != null)
				{
					laborSet.addAll(BoqItemLaborSet);
				}
				if (BoqItemMaterialSet != null)
				{
					materialSet.addAll(BoqItemMaterialSet);
				}
				if (BoqItemConsumableSet != null)
				{
					consumableSet.addAll(BoqItemConsumableSet);
				}

				obj.AssemblyChildSet = new HashSet<object>();
				obj.AssemblyEquipmentSet = new HashSet<object>();
				obj.AssemblySubcontractorSet = new HashSet<object>();
				obj.AssemblyLaborSet = new HashSet<object>();
				obj.AssemblyMaterialSet = new HashSet<object>();
				obj.AssemblyConsumableSet = new HashSet<object>();

				if (ActivityBased.Equals(false))
				{
					Productivity = BigDecimalMath.ONE;
					Duration = BigDecimalMath.ONE;
				}

				System.Collections.IEnumerator iter = assemblySet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemAssemblyTable cur = (BoqItemAssemblyTable) iter.Current;
					AssemblyAssemblyTable table = new AssemblyAssemblyTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;
					table.ExchangeRate = cur.ExchangeRate;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					table.LastUpdate = cur.LastUpdate;

					AssemblyTable assemblyTable = (AssemblyTable) cur.AssemblyTable.deepRoundCopy();
					//				assemblyTable.setAssemblyId(assemblyTable.getDatabaseId());
					if (keepIds)
					{
						assemblyTable.Id = assemblyTable.Id;
					}
					else
					{
						assemblyTable.AssemblyId = null;
					}
					if (createNew && (!cur.AssemblyTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(AssemblyTable), assemblyTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!	
						assemblyTable.DatabaseId = null;
						assemblyTable.DatabaseCreationDate = null;
						assemblyTable.Description = assemblyTable.Description + "\nProject: " + obj.Project;
						long? id = (long?) session.save((AssemblyTable) assemblyTable.clone());
						assemblyTable.AssemblyId = id;

						AssemblyTable.deepPersist(session, (AssemblyTable) assemblyTable.clone(), assemblyTable, projectId, false);

						assemblyTable = (AssemblyTable) assemblyTable.deepRoundCopy();

						bool isOnline = cur.AssemblyTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							AssemblyTable res = cur.AssemblyTable;
							res.Description = assemblyTable.Description + "\nProject: " + obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}
					if (!keepIds)
					{
						assemblyTable.DatabaseId = null;
						assemblyTable.DatabaseCreationDate = null;
						assemblyTable.BuildUpRate = null;
					}
					table.ParentTable = obj;
					table.ChildTable = assemblyTable;

					obj.AssemblyChildSet.Add(table);
				}
				obj.AssemblyChildSet = obj.AssemblyChildSet;

				////////////////////////////////////////////
				// WE ARE TRYING TO EXPLODE HERE
				// CAUSE NO SUPPORT FOR INNER ASSEMPLIES YET
				////////////////////////////////////////////
				// Get Resources from Assembly:
				/*
				
				while ( iter.hasNext() ) {
					BoqItemAssemblyTable cur = (BoqItemAssemblyTable)iter.next();
				
					BigDecimal factor1 = cur.getFactor1();
					BigDecimal factor2 = cur.getFactor2();
					BigDecimal factor3 = cur.getFactor3();
					BigDecimal factors = factor1.multiply(factor2).multiply(factor3).multiply(cur.getQuantityPerUnit());
				
					AssemblyTable assemblyTable = (AssemblyTable)cur.getAssemblyTable();
				
					if ( assemblyTable.getActivityBased().equals(Boolean.FALSE) ) {
						assemblyTable.setProductivity(BigDecimalMath.ONE);
					}
				
					Iterator iter1 = cur.getAssemblyTable().getAssemblyEquipmentSet().iterator();
					while ( iter1.hasNext() ) {
						AssemblyEquipmentTable cur1 = (AssemblyEquipmentTable)iter1.next();
						AssemblyEquipmentTable table = new AssemblyEquipmentTable();
				
						BigDecimal lf = factors.multiply(cur1.getFactor1()).multiply(cur1.getFactor2()).multiply(cur1.getFactor3()).multiply(cur1.getLocalFactor());
						BigDecimal pr = null;
						try {
							pr = BigDecimalMath.div(BigDecimalMath.ONE,cur.getAssemblyTable().getProductivity());
						} catch(ArithmeticException ex) {
							pr = BigDecimalMath.ZERO;
						}
				
						table.setFactor1(lf);
						table.setFactor2(pr);
						table.setFactor3(obj.getProductivity());
						table.setQuantityPerUnit(assemblyTable.getActivityBased().booleanValue()?BigDecimalMath.ONE:cur1.getQuantityPerUnit());
				
						table.setLocalCountry("");
						table.setLocalStateProvince("");
						table.setLocalFactor(BigDecimalMath.ONE);					
						table.setExchangeRate(cur.getExchangeRate().multiply(cur1.getExchangeRate()));
						table.setLastUpdate(cur1.getLastUpdate());
						table.setEnergyPrice(cur1.getEnergyPrice());
						table.setFuelRate(cur1.getFuelRate());
				
						EquipmentTable equipmentTable = (EquipmentTable)cur1.getEquipmentTable().clone();
						equipmentTable.setEquipmentId(equipmentTable.getDatabaseId());
				
						if ( createNew && (!cur1.getEquipmentTable().getDatabaseCreationDate().equals(dbCreationDate) || session.get(EquipmentTable.class, equipmentTable.getDatabaseId()) == null ) ) {
							// does not relate we will add a new one!	
							equipmentTable.setDatabaseId(null);
							equipmentTable.setDatabaseCreationDate(null);
							equipmentTable.setDescription(equipmentTable.getDescription()+"\nProject: "+obj.getProject());
				//						equipmentTable.setEditorId(obj.getEditorId());
				//						equipmentTable.setVirtual(Boolean.FALSE);
							Long id = (Long)session.save(equipmentTable);
							equipmentTable.setEquipmentId(id);
							equipmentTable = (EquipmentTable)equipmentTable.clone();
							boolean isOnline = cur1.getEquipmentTable().getDatabaseCreationDate() == ONLINE_DB_CREATE_DATE;
				
							if ( (replaceMissing && !isOnline) || (replaceOnline && isOnline) ) {
								// was from another database we replace missing with new ones
								EquipmentTable res = cur1.getEquipmentTable();
								res.setDescription(equipmentTable.getDescription()+"\nProject: "+obj.getProject());
								res.setEditorId(obj.getEditorId());
								res.setDatabaseId(id);
								res.setDatabaseCreationDate(dbCreationDate);
								res.setVirtual(Boolean.FALSE);
								prjSession.merge(res);
							}
						}
				
						table.setAssemblyTable(obj);
						table.setEquipmentTable(equipmentTable);
				
						obj.getAssemblyEquipmentSet().add(table);
					}
				
					iter1 = cur.getAssemblyTable().getAssemblySubcontractorSet().iterator();
					while ( iter1.hasNext() ) {
						AssemblySubcontractorTable cur1 = (AssemblySubcontractorTable)iter1.next();
						AssemblySubcontractorTable table = new AssemblySubcontractorTable();
				
						BigDecimal lf = factors.multiply(cur1.getFactor1()).multiply(cur1.getFactor2()).multiply(cur1.getFactor3()).multiply(cur1.getLocalFactor());
				
						table.setFactor1(lf);
						table.setFactor2(BigDecimalMath.ONE);
						table.setFactor3(BigDecimalMath.ONE);
						table.setQuantityPerUnit(cur1.getQuantityPerUnit());
						table.setLocalCountry("");
						table.setLocalStateProvince("");
						table.setLocalFactor(BigDecimalMath.ONE);
						table.setExchangeRate(cur.getExchangeRate().multiply(cur1.getExchangeRate()));
						table.setLastUpdate(cur1.getLastUpdate());
				
						SubcontractorTable subcontractorTable = (SubcontractorTable)cur1.getSubcontractorTable().clone();
						subcontractorTable.setSubcontractorId(subcontractorTable.getDatabaseId());
				
						if ( createNew && (!cur1.getSubcontractorTable().getDatabaseCreationDate().equals(dbCreationDate) || session.get(SubcontractorTable.class, subcontractorTable.getDatabaseId()) == null ) ) {
							// does not relate we will add a new one!	
							subcontractorTable.setDatabaseId(null);
							subcontractorTable.setDatabaseCreationDate(null);
				//						subcontractorTable.setProject(obj.getProject());
				//						subcontractorTable.setEditorId(obj.getEditorId());
				//						subcontractorTable.setVirtual(Boolean.FALSE);
				
							Long id = (Long)session.save(subcontractorTable);
							subcontractorTable.setSubcontractorId(id);
							subcontractorTable = (SubcontractorTable)subcontractorTable.clone();
							boolean isOnline = cur1.getSubcontractorTable().getDatabaseCreationDate() == ONLINE_DB_CREATE_DATE;
				
							if ( (replaceMissing && !isOnline) || (replaceOnline && isOnline) ) {
								// was from another database we replace missing with new ones
								SubcontractorTable res = cur1.getSubcontractorTable();
								res.setProject(obj.getProject());
								res.setEditorId(obj.getEditorId());
								res.setDatabaseId(id);
								res.setDatabaseCreationDate(dbCreationDate);
								res.setVirtual(Boolean.FALSE);
								prjSession.merge(res);
							}
						}
				
						table.setAssemblyTable(obj);
						table.setSubcontractorTable(subcontractorTable);
				
						obj.getAssemblySubcontractorSet().add(table);
					}
				
					iter1 = cur.getAssemblyTable().getAssemblyLaborSet().iterator();
					while ( iter1.hasNext() ) {
						AssemblyLaborTable cur1 = (AssemblyLaborTable)iter1.next();
						AssemblyLaborTable table = new AssemblyLaborTable();
				
						// recalculate single factor with productivity
						BigDecimal lf = factors.multiply(cur1.getFactor1()).multiply(cur1.getFactor2()).multiply(cur1.getFactor3()).multiply(cur1.getLocalFactor());
						BigDecimal pr = null;
						try {
							pr = BigDecimalMath.div(BigDecimalMath.ONE,cur.getAssemblyTable().getProductivity());
						} catch(ArithmeticException ex) {
							pr = BigDecimalMath.ZERO;
						}
						table.setFactor1(lf);
						table.setFactor2(pr);
						table.setFactor3(obj.getProductivity());
						table.setQuantityPerUnit(assemblyTable.getActivityBased().booleanValue()?BigDecimalMath.ONE:cur1.getQuantityPerUnit());
						table.setLocalCountry("");
						table.setLocalStateProvince("");
						table.setLocalFactor(BigDecimalMath.ONE);
						table.setExchangeRate(cur.getExchangeRate().multiply(cur1.getExchangeRate()));
						table.setLastUpdate(cur1.getLastUpdate());
				
						LaborTable laborTable = (LaborTable)cur1.getLaborTable().clone();
						laborTable.setLaborId(laborTable.getDatabaseId());
				
						if ( createNew && (!cur1.getLaborTable().getDatabaseCreationDate().equals(dbCreationDate) || session.get(LaborTable.class, laborTable.getDatabaseId()) == null ) ) {
							// does not relate we will add a new one!	
							laborTable.setDatabaseId(null);
							laborTable.setDatabaseCreationDate(null);
				//						laborTable.setProject(obj.getProject());
				//						laborTable.setEditorId(obj.getEditorId());
				//						laborTable.setVirtual(Boolean.FALSE);
				
							Long id = (Long)session.save(laborTable);
							laborTable.setLaborId(id);
							laborTable = (LaborTable)laborTable.clone();
							boolean isOnline = cur1.getLaborTable().getDatabaseCreationDate() == ONLINE_DB_CREATE_DATE;
				
							if ( (replaceMissing && !isOnline) || (replaceOnline && isOnline) ) {
								// was from another database we replace missing with new ones
								LaborTable res = cur1.getLaborTable();
								res.setProject(obj.getProject());
								res.setEditorId(obj.getEditorId());
								res.setDatabaseId(id);
								res.setDatabaseCreationDate(dbCreationDate);
								res.setVirtual(Boolean.FALSE);
								prjSession.merge(res);
							}
						}
				
						table.setAssemblyTable(obj);
						table.setLaborTable(laborTable);
				
						obj.getAssemblyLaborSet().add(table);
					}
				
					iter1 = cur.getAssemblyTable().getAssemblyMaterialSet().iterator();
					while ( iter1.hasNext() ) {
						AssemblyMaterialTable cur1 = (AssemblyMaterialTable)iter1.next();
						AssemblyMaterialTable table = new AssemblyMaterialTable();
				
						BigDecimal lf = factors.multiply(cur1.getFactor1()).multiply(cur1.getFactor2()).multiply(cur1.getLocalFactor());
				
						table.setFactor1(lf);
						table.setFactor2(BigDecimalMath.ONE);
						table.setFactor3(cur1.getFactor3());
						table.setQuantityPerUnit(cur1.getQuantityPerUnit());
						table.setLocalCountry("");
						table.setLocalStateProvince("");
						table.setLocalFactor(BigDecimalMath.ONE);
						table.setExchangeRate(cur.getExchangeRate().multiply(cur1.getExchangeRate()));
						table.setLastUpdate(cur1.getLastUpdate());
				
						MaterialTable materialTable = (MaterialTable)cur1.getMaterialTable().clone();
						materialTable.setMaterialId(materialTable.getDatabaseId());
				
						if ( createNew && (!cur1.getMaterialTable().getDatabaseCreationDate().equals(dbCreationDate) || session.get(MaterialTable.class, materialTable.getDatabaseId()) == null ) ) {
							// does not relate we will add a new one!	
							materialTable.setDatabaseId(null);
							materialTable.setDatabaseCreationDate(null);
				//  					materialTable.setProject(obj.getProject());
				//						materialTable.setEditorId(obj.getEditorId());
							materialTable.setBimMaterial(getBimMaterial());
							materialTable.setBimType(getBimType());	
				//						materialTable.setVirtual(Boolean.FALSE);
							Long id = (Long)session.save(materialTable);
							materialTable.setMaterialId(id);
							materialTable = (MaterialTable)materialTable.clone();
							boolean isOnline = cur1.getMaterialTable().getDatabaseCreationDate() == ONLINE_DB_CREATE_DATE;
				
							if ( (replaceMissing && !isOnline) || (replaceOnline && isOnline) ) {
								// was from another database we replace missing with new ones
								MaterialTable res = cur1.getMaterialTable();
								res.setProject(obj.getProject());
								res.setEditorId(obj.getEditorId());
								res.setBimMaterial(getBimMaterial());
								res.setBimType(getBimType());	
								res.setDatabaseId(id);
								res.setDatabaseCreationDate(dbCreationDate);
								res.setVirtual(Boolean.FALSE);
								prjSession.merge(res);
							}
						}
				
						table.setAssemblyTable(obj);
						table.setMaterialTable(materialTable);
				
						obj.getAssemblyMaterialSet().add(table);
					}
				
					iter1 = cur.getAssemblyTable().getAssemblyConsumableSet().iterator();
					while ( iter1.hasNext() ) {
						AssemblyConsumableTable cur1 = (AssemblyConsumableTable)iter1.next();
						AssemblyConsumableTable table = new AssemblyConsumableTable();
				
						BigDecimal lf = factors.multiply(cur1.getFactor1()).multiply(cur1.getFactor2()).multiply(cur1.getLocalFactor());
				
						table.setFactor1(lf);
						table.setFactor2(BigDecimalMath.ONE);
						table.setFactor3(cur1.getFactor3());
						table.setQuantityPerUnit(cur1.getQuantityPerUnit());
						table.setLocalCountry("");
						table.setLocalStateProvince("");
						table.setLocalFactor(BigDecimalMath.ONE);				
						table.setExchangeRate(cur.getExchangeRate().multiply(cur1.getExchangeRate()));
						table.setLastUpdate(cur1.getLastUpdate());
				
						ConsumableTable consumableTable = (ConsumableTable)cur1.getConsumableTable().clone();
						consumableTable.setConsumableId(consumableTable.getDatabaseId());
				
						if ( createNew && (!cur1.getConsumableTable().getDatabaseCreationDate().equals(dbCreationDate) || session.get(ConsumableTable.class, consumableTable.getDatabaseId()) == null ) ) {
							// does not relate we will add a new one!	
							consumableTable.setDatabaseId(null);
							consumableTable.setDatabaseCreationDate(null);
				//						consumableTable.setProject(obj.getProject());
				//						consumableTable.setEditorId(obj.getEditorId());
				//						consumableTable.setVirtual(Boolean.FALSE);
							Long id = (Long)session.save(consumableTable);
							consumableTable.setConsumableId(id);
							consumableTable = (ConsumableTable)consumableTable.clone();
							boolean isOnline = cur1.getConsumableTable().getDatabaseCreationDate() == ONLINE_DB_CREATE_DATE;
				
							if ( (replaceMissing && !isOnline) || (replaceOnline && isOnline) ) {
								// was from another database we replace missing with new ones
								ConsumableTable res = cur1.getConsumableTable();
								res.setProject(obj.getProject());
								res.setEditorId(obj.getEditorId());
								res.setDatabaseId(id);
								res.setDatabaseCreationDate(dbCreationDate);
								res.setVirtual(Boolean.FALSE);
								prjSession.merge(res);
							}
						}
				
						table.setAssemblyTable(obj);
						table.setConsumableTable(consumableTable);
				
						obj.getAssemblyConsumableSet().add(table);
					}
				}
				 */
				////////////////////
				// End Explosion
				////////////////////

				iter = equipmentSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemEquipmentTable cur = (BoqItemEquipmentTable) iter.Current;
					AssemblyEquipmentTable table = new AssemblyEquipmentTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;
					table.ExchangeRate = cur.ExchangeRate;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					table.LastUpdate = cur.LastUpdate;
					table.EnergyPrice = cur.EnergyPrice;
					table.FuelRate = cur.FinalFuelRate;

					EquipmentTable equipmentTable = (EquipmentTable) cur.EquipmentTable.clone();
					//				if ( cur.getEquipmentTable().getDatabaseCreationDate() != null && cur.getEquipmentTable().getDatabaseCreationDate().equals(dbCreationDate) )
					//					equipmentTable.setEquipmentId(equipmentTable.getDatabaseId()); // Also chance here not to be found in database?
					//				else
					if (keepIds)
					{
						equipmentTable.Id = equipmentTable.Id;
					}
					else
					{
						equipmentTable.EquipmentId = null;
					}
					//				equipmentTable.setEquipmentId(equipmentTable.getDatabaseId());
					//				if ( equipmentTable.getDatabaseId() != null && equipmentTable.getDatabaseCreationDate().longValue() ) {
					//				}

					if (createNew && (!cur.EquipmentTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(EquipmentTable), equipmentTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!
						equipmentTable.DatabaseId = null;
						equipmentTable.DatabaseCreationDate = null;
						equipmentTable.BuildUpRate = null;
						equipmentTable.Description = equipmentTable.Description + "\nProject: " + obj.Project;
						//					equipmentTable.setEditorId(obj.getEditorId());
						//					equipmentTable.setVirtual(Boolean.FALSE);
						long? id = (long?) session.save(equipmentTable);
						equipmentTable.EquipmentId = id;
						equipmentTable = (EquipmentTable) equipmentTable.clone();

						bool isOnline = cur.EquipmentTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							EquipmentTable res = cur.EquipmentTable;
							res.Description = equipmentTable.Description + "\nProject: " + obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}
					if (!keepIds)
					{
						equipmentTable.DatabaseId = null;
						equipmentTable.DatabaseCreationDate = null;
						equipmentTable.BuildUpRate = null;
					}
					table.AssemblyTable = obj;
					table.EquipmentTable = equipmentTable;

					obj.AssemblyEquipmentSet.Add(table);
				}
				obj.AssemblyEquipmentSet = obj.AssemblyEquipmentSet;

				iter = subcontractorSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemSubcontractorTable cur = (BoqItemSubcontractorTable) iter.Current;
					AssemblySubcontractorTable table = new AssemblySubcontractorTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;
					table.ExchangeRate = cur.ExchangeRate;
					table.LastUpdate = cur.LastUpdate;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					SubcontractorTable subcontractorTable = (SubcontractorTable) cur.SubcontractorTable.clone();
					//subcontractorTable.setSubcontractorId(subcontractorTable.getDatabaseId());
					if (keepIds)
					{
						subcontractorTable.Id = subcontractorTable.Id;
					}
					else
					{
						subcontractorTable.SubcontractorId = null;
					}
					if (createNew && (!cur.SubcontractorTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(SubcontractorTable), subcontractorTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!	
						subcontractorTable.DatabaseId = null;
						subcontractorTable.DatabaseCreationDate = null;
						subcontractorTable.BuildUpRate = null;
						//					subcontractorTable.setProject(obj.getProject());
						//					subcontractorTable.setEditorId(obj.getEditorId());
						//					subcontractorTable.setVirtual(Boolean.FALSE);
						long? id = (long?) session.save(subcontractorTable);
						subcontractorTable.SubcontractorId = id;
						subcontractorTable = (SubcontractorTable) subcontractorTable.clone();
						bool isOnline = cur.SubcontractorTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							SubcontractorTable res = cur.SubcontractorTable;
							res.Project = obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}
					if (!keepIds)
					{
						subcontractorTable.DatabaseId = null;
						subcontractorTable.DatabaseCreationDate = null;
						subcontractorTable.BuildUpRate = null;
					}
					table.AssemblyTable = obj;
					table.SubcontractorTable = subcontractorTable;

					obj.AssemblySubcontractorSet.Add(table);
				}
				obj.AssemblySubcontractorSet = obj.AssemblySubcontractorSet;

				iter = laborSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemLaborTable cur = (BoqItemLaborTable) iter.Current;
					AssemblyLaborTable table = new AssemblyLaborTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					table.ExchangeRate = cur.ExchangeRate;
					table.LastUpdate = cur.LastUpdate;

					LaborTable laborTable = (LaborTable) cur.LaborTable.clone();
					//laborTable.setLaborId(laborTable.getDatabaseId());
					if (keepIds)
					{
						laborTable.Id = laborTable.Id;
					}
					else
					{
						laborTable.LaborId = null;
					}
					if (createNew && (!cur.LaborTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(LaborTable), laborTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!	
						laborTable.DatabaseId = null;
						laborTable.DatabaseCreationDate = null;
						laborTable.BuildUpRate = null;
						//					laborTable.setProject(obj.getProject());
						//					laborTable.setEditorId(obj.getEditorId());
						//					laborTable.setVirtual(Boolean.FALSE);
						long? id = (long?) session.save(laborTable);
						laborTable.LaborId = id;
						laborTable = (LaborTable) laborTable.clone();
						bool isOnline = cur.LaborTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							LaborTable res = cur.LaborTable;
							res.Project = obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}
					if (!keepIds)
					{
						laborTable.DatabaseId = null;
						laborTable.DatabaseCreationDate = null;
						laborTable.BuildUpRate = null;
					}
					table.AssemblyTable = obj;
					table.LaborTable = laborTable;

					obj.AssemblyLaborSet.Add(table);
				}
				obj.AssemblyLaborSet = obj.AssemblyLaborSet;

				iter = materialSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemMaterialTable cur = (BoqItemMaterialTable) iter.Current;
					AssemblyMaterialTable table = new AssemblyMaterialTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					table.ExchangeRate = cur.ExchangeRate;
					table.LastUpdate = cur.LastUpdate;

					MaterialTable materialTable = (MaterialTable) cur.MaterialTable.clone();
					//materialTable.setMaterialId(materialTable.getDatabaseId());
					if (keepIds)
					{
						materialTable.Id = materialTable.Id;
					}
					else
					{
						materialTable.MaterialId = null;
					}
					if (createNew && (!cur.MaterialTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(MaterialTable), materialTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!	
						materialTable.DatabaseId = null;
						materialTable.DatabaseCreationDate = null;
						materialTable.BuildUpRate = null;
						//					materialTable.setProject(obj.getProject());
						//					materialTable.setEditorId(obj.getEditorId());
						materialTable.BimType = BimType;
						materialTable.BimMaterial = BimMaterial;
						//					materialTable.setVirtual(Boolean.FALSE);
						long? id = (long?) session.save(materialTable);
						materialTable.MaterialId = id;
						materialTable = (MaterialTable) materialTable.clone();
						bool isOnline = cur.MaterialTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							MaterialTable res = cur.MaterialTable;
							res.BimMaterial = BimMaterial;
							res.BimType = BimType;
							res.Project = obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}
					if (!keepIds)
					{
						materialTable.DatabaseId = null;
						materialTable.DatabaseCreationDate = null;
						materialTable.BuildUpRate = null;
					}
					if (cur.MaterialTable.SupplierTable != null)
					{
						SupplierTable supplierTable = (SupplierTable) cur.MaterialTable.SupplierTable.clone();
						bool saveNew = false;
						//System.out.println("THE SUPPLIER DATABASE ID IS: "+supplierTable.getDatabaseId()+" for "+supplierTable.getTitle());
						if (supplierTable.DatabaseId != null)
						{
							IList<SupplierTable> resList = DatabaseDBUtil.loadBulk(typeof(SupplierTable), new long?[] {supplierTable.DatabaseId});
							if (resList.Count == 0)
							{
								// try searching be name and company name:
								q = DatabaseDBUtil.currentSession().createQuery("from SupplierTable o where o.title = :companyName and o.contactPerson = :contactPerson");
								q.setString("companyName", supplierTable.Title);
								q.setString("contactPerson", supplierTable.ContactPerson);
								resList = q.list();
								if (resList.Count == 0)
								{
									// still null we need to save as new in resource database:
									saveNew = true;
								}
								else
								{
									supplierTable = (SupplierTable) resList[0].clone();
								}
							}
							else
							{
								supplierTable = (SupplierTable) resList[0].clone();
							}
						}
						else
						{
							q = DatabaseDBUtil.currentSession().createQuery("from SupplierTable o where o.title = :companyName and o.contactPerson = :contactPerson");
							q.setString("companyName", supplierTable.Title);
							q.setString("contactPerson", supplierTable.ContactPerson);
							IList<SupplierTable> resList = q.list();
							if (resList.Count == 0)
							{
								// still null we need to save as new in resource database:
								saveNew = true;
							}
							else
							{
								supplierTable = (SupplierTable) resList[0].clone();
							}
						}

						if (saveNew)
						{
							supplierTable.DatabaseId = null;
							supplierTable.DatabaseCreationDate = null;
							long? id = (long?) DatabaseDBUtil.currentSession().save(supplierTable);
							supplierTable.SupplierId = id;
							supplierTable = (SupplierTable) supplierTable.clone();
						}

						materialTable.SupplierTable = supplierTable;
					}

					table.AssemblyTable = obj;
					table.MaterialTable = materialTable;

					obj.AssemblyMaterialSet.Add(table);
				}
				obj.AssemblyMaterialSet = obj.AssemblyMaterialSet;

				iter = consumableSet.GetEnumerator();

				while (iter.MoveNext())
				{
					BoqItemConsumableTable cur = (BoqItemConsumableTable) iter.Current;
					AssemblyConsumableTable table = new AssemblyConsumableTable();

					table.Factor1 = cur.Factor1;
					table.Factor2 = cur.Factor2;
					table.Factor3 = cur.Factor3;

					table.QuantityPerUnit = cur.QuantityPerUnit;
					table.QuantityPerUnitFormula = cur.QuantityPerUnitFormula;
					table.QuantityPerUnitFormulaState = cur.QuantityPerUnitFormulaState;

					table.LocalFactor = cur.LocalFactor;
					table.LocalCountry = cur.LocalCountry;
					table.LocalStateProvince = cur.LocalStateProvince;

					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;

					table.ExchangeRate = cur.ExchangeRate;
					table.LastUpdate = cur.LastUpdate;

					ConsumableTable consumableTable = (ConsumableTable) cur.ConsumableTable.clone();
					//consumableTable.setConsumableId(consumableTable.getDatabaseId());
					if (keepIds)
					{
						consumableTable.Id = consumableTable.Id;
					}
					else
					{
						consumableTable.ConsumableId = null;
					}
					if (createNew && (!cur.ConsumableTable.DatabaseCreationDate.Equals(dbCreationDate) || session.get(typeof(ConsumableTable), consumableTable.DatabaseId) == null))
					{
						// does not relate we will add a new one!	
						consumableTable.DatabaseId = null;
						consumableTable.DatabaseCreationDate = null;
						consumableTable.BuildUpRate = null;
						//					consumableTable.setProject(obj.getProject());
						//					consumableTable.setEditorId(obj.getEditorId());
						//					consumableTable.setVirtual(Boolean.FALSE);
						long? id = (long?) session.save(consumableTable);
						consumableTable.ConsumableId = id;
						consumableTable = (ConsumableTable) consumableTable.clone();
						bool isOnline = cur.ConsumableTable.DatabaseCreationDate < 0;

						if ((replaceMissing && !isOnline) || (replaceOnline && isOnline))
						{
							// was from another database we replace missing with new ones
							ConsumableTable res = cur.ConsumableTable;
							res.Project = obj.Project;
							res.EditorId = obj.EditorId;
							res.DatabaseId = id;
							res.DatabaseCreationDate = dbCreationDate;
							res.Virtual = false;
							prjSession.merge(res);
						}
					}

					if (!keepIds)
					{
						consumableTable.DatabaseId = null;
						consumableTable.DatabaseCreationDate = null;
						consumableTable.BuildUpRate = null;
					}

					table.AssemblyTable = obj;
					table.ConsumableTable = consumableTable;

					obj.AssemblyConsumableSet.Add(table);
				}
				obj.AssemblyConsumableSet = obj.AssemblyConsumableSet;

				if (tx != null && tx.Active)
				{
					tx.commit();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.Write(ex.StackTrace);
				if (tx != null && tx.Active)
				{
					tx.rollback();
				}
				//throw ex;
			}
			if (tx != null)
			{
				DatabaseDBUtil.closeSession();
			}

			obj.calculateRate();

			if (closeProjectSession)
			{
				prjDBUtil.closeSession();
			}

			return obj;
		}

		public virtual bool? assignmentsHaveBoqDependedFormula(BoqItemTable boqItemTable)
		{
			foreach (object resourceToAssignment in boqItemTable.ResourceAssignmentsList)
			{
				ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable) resourceToAssignment;

				if (resourceToAssignmentTable.QuantityPerUnitFormulaState != null && (resourceToAssignmentTable.QuantityPerUnitFormulaState.Equals(ResourceToAssignmentTable.QTYPUFORM_BOQ_DEPENDENT) || resourceToAssignmentTable.QuantityPerUnitFormulaState.Equals(ResourceToAssignmentTable.QTYPUFORM_BOQ_AND_PRJVAR_DEPENDENT)))
				{
					return true;
				}

				if (resourceToAssignmentTable is BoqItemAssemblyTable)
				{
					BoqItemAssemblyTable boqItemAssemblyTable = (BoqItemAssemblyTable) resourceToAssignmentTable;
					if (assemblyChildsHaveBoqDependedFormula(boqItemAssemblyTable.AssemblyTable))
					{
						return true;
					}
				}
			}

			return false;
		}

		public virtual bool assemblyChildsHaveBoqDependedFormula(AssemblyTable assemblyTable)
		{
			foreach (object resourceToAssignment in assemblyTable.ResourceAssignmentsList)
			{
				ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable) resourceToAssignment;

				if (resourceToAssignmentTable.QuantityPerUnitFormulaState != null && (resourceToAssignmentTable.QuantityPerUnitFormulaState.Equals(ResourceToAssignmentTable.QTYPUFORM_BOQ_DEPENDENT) || resourceToAssignmentTable.QuantityPerUnitFormulaState.Equals(ResourceToAssignmentTable.QTYPUFORM_BOQ_AND_PRJVAR_DEPENDENT)))
				{
					return true;
				}

				if (resourceToAssignmentTable is AssemblyAssemblyTable)
				{
					AssemblyAssemblyTable assemblyAssemblyTable = (AssemblyAssemblyTable) resourceToAssignmentTable;
					if (assemblyChildsHaveBoqDependedFormula(assemblyAssemblyTable.ChildTable))
					{
						return true;
					}
				}
			}

			return false;
		}

		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimTotalCost() {
		//		return estimTotalCost;
		//	}
		//
		//	public void setEstimTotalCost(BigDecimal estimTotalCost) {
		//		this.estimTotalCost = estimTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMASSCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimAssemblyTotalCost() {
		//		return estimAssemblyTotalCost;
		//	}
		//
		//	public void setEstimAssemblyTotalCost(BigDecimal estimAssemblyTotalCost) {
		//		this.estimAssemblyTotalCost = estimAssemblyTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMLABCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimLaborTotalCost() {
		//		return estimLaborTotalCost;
		//	}
		//
		//	public void setEstimLaborTotalCost(BigDecimal estimLaborTotalCost) {
		//		this.estimLaborTotalCost = estimLaborTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMCONCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimConsumableTotalCost() {
		//		return estimConsumableTotalCost;
		//	}
		//
		//	public void setEstimConsumableTotalCost(BigDecimal estimConsumableTotalCost) {
		//		this.estimConsumableTotalCost = estimConsumableTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMMATCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimMaterialTotalCost() {
		//		return estimMaterialTotalCost;
		//	}
		//
		//	public void setEstimMaterialTotalCost(BigDecimal estimMaterialTotalCost) {
		//		this.estimMaterialTotalCost = estimMaterialTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMFABCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimFabricationTotalCost() {
		//		return estimFabricationTotalCost;
		//	}
		//
		//	public void setEstimFabricationTotalCost(BigDecimal estimFabricationTotalCost) {
		//		this.estimFabricationTotalCost = estimFabricationTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMSHPCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimShipmentTotalCost() {
		//		return estimShipmentTotalCost;
		//	}
		//
		//	public void setEstimShipmentTotalCost(BigDecimal estimShipmentTotalCost) {
		//		this.estimShipmentTotalCost = estimShipmentTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMSUBCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimSubcontractorTotalCost() {
		//		return estimSubcontractorTotalCost;
		//	}
		//
		//	public void setEstimSubcontractorTotalCost(
		//			BigDecimal estimSubcontractorTotalCost) {
		//		this.estimSubcontractorTotalCost = estimSubcontractorTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMEQUCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimEquipmentTotalCost() {
		//		return estimEquipmentTotalCost;
		//	}
		//
		//	public void setEstimEquipmentTotalCost(BigDecimal estimEquipmentTotalCost) {
		//		this.estimEquipmentTotalCost = estimEquipmentTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column=QUOTMATCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getQuotedMaterialTotalCost() {
		//		return quotedMaterialTotalCost;
		//	}
		//
		//	public void setQuotedMaterialTotalCost(BigDecimal quotedMaterialTotalCost) {
		//		this.quotedMaterialTotalCost = quotedMaterialTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column=QUOTSUBCOST" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getQuotedSubcontractorTotalCost() {
		//		return quotedSubcontractorTotalCost;
		//	}
		//
		//	public void setQuotedSubcontractorTotalCost(
		//			BigDecimal quotedSubcontractorTotalCost) {
		//		this.quotedSubcontractorTotalCost = quotedSubcontractorTotalCost;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMRATE" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimRate() {
		//		return estimRate;
		//	}
		//
		//	public void setEstimRate(BigDecimal estimRate) {
		//		this.estimRate = estimRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="QUOTMAT" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getQuotedMaterialRate() {
		//		return quotedMaterialRate;
		//	}
		//
		//	public void setQuotedMaterialRate(BigDecimal quotedMaterialRate) {
		//		this.quotedMaterialRate = quotedMaterialRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="QUOTSUB" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getQuotedSubcontractorRate() {
		//		return quotedSubcontractorRate;
		//	}
		//
		//	public void setQuotedSubcontractorRate(BigDecimal quotedSubcontractorRate) {
		//		this.quotedSubcontractorRate = quotedSubcontractorRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMSUB" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimSubcontractorRate() {
		//		return estimSubcontractorRate;
		//	}
		//
		//	public void setEstimSubcontractorRate(BigDecimal estimSubcontractorRate) {
		//		this.estimSubcontractorRate = estimSubcontractorRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMASS" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimAssemblyRate() {
		//		return estimAssemblyRate;
		//	}
		//
		//	public void setEstimAssemblyRate(BigDecimal estimAssemblyRate) {
		//		this.estimAssemblyRate = estimAssemblyRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMLAB" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimLaborRate() {
		//		return estimLaborRate;
		//	}
		//
		//	public void setEstimLaborRate(BigDecimal estimLaborRate) {
		//		this.estimLaborRate = estimLaborRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * @hibernate.property column="ESTIMCON" type="big_decimal" precision="30" scale="10"
		//	 * @return BigDecimal
		//	 */
		//	public BigDecimal getEstimConsumableRate() {
		//		return estimConsumableRate;
		//	}
		//
		//	public void setEstimConsumableRate(BigDecimal estimConsumableRate) {
		//		this.estimConsumableRate = estimConsumableRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMFAB" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimFabricationRate() {
		//		return estimFabricationRate;
		//	}
		//
		//	public void setEstimFabricationRate(BigDecimal estimFabricationRate) {
		//		this.estimFabricationRate = estimFabricationRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMSHIP" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimShipmentRate() {
		//		return estimShipmentRate;
		//	}
		//
		//	public void setEstimShipmentRate(BigDecimal estimShipmentRate) {
		//		this.estimShipmentRate = estimShipmentRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMMAT" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimMaterialRate() {
		//		return estimMaterialRate;
		//	}
		//
		//	public void setEstimMaterialRate(BigDecimal estimMaterialRate) {
		//		this.estimMaterialRate = estimMaterialRate;
		//	}
		//
		//	/**
		//	 * Description Here
		//	 *
		//	 * hibernate.property column="ESTIMEQU" type="big_decimal" precision="30" scale="10"
		//	 * return BigDecimal
		//	 */
		//	public BigDecimal getEstimEquipmentRate() {
		//		return estimEquipmentRate;
		//	}
		//
		//	public void setEstimEquipmentRate(BigDecimal estimEquipmentRate) {
		//		this.estimEquipmentRate = estimEquipmentRate;
		//	}

		/// <summary>
		/// @hibernate.property column="EXTRACODE1" type="costos_string" </summary>
		/// <returns> extraCode1 </returns>
		public virtual string ExtraCode1
		{
			get
			{
				return extraCode1;
			}
			set
			{
				this.extraCode1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE2" type="costos_string" </summary>
		/// <returns> extraCode2 </returns>
		public virtual string ExtraCode2
		{
			get
			{
				return extraCode2;
			}
			set
			{
				this.extraCode2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WBSCODE" type="costos_string" </summary>
		/// <returns> wbsCode </returns>
		public virtual string WbsCode
		{
			get
			{
				return wbsCode;
			}
			set
			{
				this.wbsCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WBS2CODE" type="costos_string" </summary>
		/// <returns> wbsCode </returns>
		public virtual string Wbs2Code
		{
			get
			{
				return wbs2Code;
			}
			set
			{
				this.wbs2Code = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ROLLUP" type="costos_string" </summary>
		/// <returns> rollUP </returns>
		public virtual string RollUP
		{
			get
			{
				return rollUP;
			}
			set
			{
				this.rollUP = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCATION" type="costos_string" </summary>
		/// <returns> location </returns>
		public virtual string Location
		{
			get
			{
				return location;
			}
			set
			{
				this.location = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE3" type="costos_string" </summary>
		/// <returns> extraCode3 </returns>
		public virtual string ExtraCode3
		{
			get
			{
				return extraCode3;
			}
			set
			{
				this.extraCode3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE4" type="costos_string" </summary>
		/// <returns> extraCode4 </returns>
		public virtual string ExtraCode4
		{
			get
			{
				return extraCode4;
			}
			set
			{
				this.extraCode4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE5" type="costos_string" </summary>
		/// <returns> extraCode5 </returns>
		public virtual string ExtraCode5
		{
			get
			{
				return extraCode5;
			}
			set
			{
				this.extraCode5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE6" type="costos_string" </summary>
		/// <returns> extraCode6 </returns>
		public virtual string ExtraCode6
		{
			get
			{
				return extraCode6;
			}
			set
			{
				this.extraCode6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE7" type="costos_string" </summary>
		/// <returns> extraCode7 </returns>
		public virtual string ExtraCode7
		{
			get
			{
				return extraCode7;
			}
			set
			{
				this.extraCode7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE8" type="costos_string" </summary>
		/// <returns> extraCode8 </returns>
		public virtual string ExtraCode8
		{
			get
			{
				return extraCode8;
			}
			set
			{
				this.extraCode8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE9" type="costos_string" </summary>
		/// <returns> extraCode9 </returns>
		public virtual string ExtraCode9
		{
			get
			{
				return extraCode9;
			}
			set
			{
				this.extraCode9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE10" type="costos_string" </summary>
		/// <returns> extraCode10 </returns>
		public virtual string ExtraCode10
		{
			get
			{
				return extraCode10;
			}
			set
			{
				this.extraCode10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUGRCFACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuGroupCodeFactor
		{
			get
			{
				return puGroupCodeFactor;
			}
			set
			{
				this.puGroupCodeFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUGEKFACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuGekCodeFactor
		{
			get
			{
				return puGekCodeFactor;
			}
			set
			{
				this.puGekCodeFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX1FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode1Factor
		{
			get
			{
				return puExtraCode1Factor;
			}
			set
			{
				this.puExtraCode1Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX2FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode2Factor
		{
			get
			{
				return puExtraCode2Factor;
			}
			set
			{
				this.puExtraCode2Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX3FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode3Factor
		{
			get
			{
				return puExtraCode3Factor;
			}
			set
			{
				this.puExtraCode3Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX4FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode4Factor
		{
			get
			{
				return puExtraCode4Factor;
			}
			set
			{
				this.puExtraCode4Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX5FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode5Factor
		{
			get
			{
				return puExtraCode5Factor;
			}
			set
			{
				this.puExtraCode5Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX6FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode6Factor
		{
			get
			{
				return puExtraCode6Factor;
			}
			set
			{
				this.puExtraCode6Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PUEX7FACTOR" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal PuExtraCode7Factor
		{
			get
			{
				return puExtraCode7Factor;
			}
			set
			{
				this.puExtraCode7Factor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE1" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate1
		{
			get
			{
				return customRate1;
			}
			set
			{
				this.customRate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE2" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate2
		{
			get
			{
				return customRate2;
			}
			set
			{
				this.customRate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE3" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate3
		{
			get
			{
				return customRate3;
			}
			set
			{
				this.customRate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE4" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate4
		{
			get
			{
				return customRate4;
			}
			set
			{
				this.customRate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE5" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate5
		{
			get
			{
				return customRate5;
			}
			set
			{
				this.customRate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE6" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate6
		{
			get
			{
				return customRate6;
			}
			set
			{
				this.customRate6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE7" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate7
		{
			get
			{
				return customRate7;
			}
			set
			{
				this.customRate7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE8" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate8
		{
			get
			{
				return customRate8;
			}
			set
			{
				this.customRate8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE9" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate9
		{
			get
			{
				return customRate9;
			}
			set
			{
				this.customRate9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE10" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate10
		{
			get
			{
				return customRate10;
			}
			set
			{
				this.customRate10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE11" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate11
		{
			get
			{
				return customRate11;
			}
			set
			{
				this.customRate11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE12" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate12
		{
			get
			{
				return customRate12;
			}
			set
			{
				this.customRate12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE13" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate13
		{
			get
			{
				return customRate13;
			}
			set
			{
				this.customRate13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE14" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate14
		{
			get
			{
				return customRate14;
			}
			set
			{
				this.customRate14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE15" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate15
		{
			get
			{
				return customRate15;
			}
			set
			{
				this.customRate15 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE16" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate16
		{
			get
			{
				return customRate16;
			}
			set
			{
				this.customRate16 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE17" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate17
		{
			get
			{
				return customRate17;
			}
			set
			{
				this.customRate17 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE18" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate18
		{
			get
			{
				return customRate18;
			}
			set
			{
				this.customRate18 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE19" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate19
		{
			get
			{
				return customRate19;
			}
			set
			{
				this.customRate19 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE20" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomRate20
		{
			get
			{
				return customRate20;
			}
			set
			{
				this.customRate20 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE1" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate1
		{
			get
			{
				return customCumRate1;
			}
			set
			{
				this.customCumRate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE2" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate2
		{
			get
			{
				return customCumRate2;
			}
			set
			{
				this.customCumRate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE3" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate3
		{
			get
			{
				return customCumRate3;
			}
			set
			{
				this.customCumRate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE4" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate4
		{
			get
			{
				return customCumRate4;
			}
			set
			{
				this.customCumRate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE5" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate5
		{
			get
			{
				return customCumRate5;
			}
			set
			{
				this.customCumRate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE6" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate6
		{
			get
			{
				return customCumRate6;
			}
			set
			{
				this.customCumRate6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE7" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate7
		{
			get
			{
				return customCumRate7;
			}
			set
			{
				this.customCumRate7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE8" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate8
		{
			get
			{
				return customCumRate8;
			}
			set
			{
				this.customCumRate8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE9" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate9
		{
			get
			{
				return customCumRate9;
			}
			set
			{
				this.customCumRate9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE10" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate10
		{
			get
			{
				return customCumRate10;
			}
			set
			{
				this.customCumRate10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE11" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate11
		{
			get
			{
				return customCumRate11;
			}
			set
			{
				this.customCumRate11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE12" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate12
		{
			get
			{
				return customCumRate12;
			}
			set
			{
				this.customCumRate12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE13" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate13
		{
			get
			{
				return customCumRate13;
			}
			set
			{
				this.customCumRate13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE14" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate14
		{
			get
			{
				return customCumRate14;
			}
			set
			{
				this.customCumRate14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE15" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate15
		{
			get
			{
				return customCumRate15;
			}
			set
			{
				this.customCumRate15 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE16" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate16
		{
			get
			{
				return customCumRate16;
			}
			set
			{
				this.customCumRate16 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE17" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate17
		{
			get
			{
				return customCumRate17;
			}
			set
			{
				this.customCumRate17 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE18" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate18
		{
			get
			{
				return customCumRate18;
			}
			set
			{
				this.customCumRate18 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE19" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate19
		{
			get
			{
				return customCumRate19;
			}
			set
			{
				this.customCumRate19 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUMRATE20" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomCumRate20
		{
			get
			{
				return customCumRate20;
			}
			set
			{
				this.customCumRate20 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER1" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate1
		{
			get
			{
				return customPercentRate1;
			}
			set
			{
				this.customPercentRate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER2" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate2
		{
			get
			{
				return customPercentRate2;
			}
			set
			{
				this.customPercentRate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER3" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate3
		{
			get
			{
				return customPercentRate3;
			}
			set
			{
				this.customPercentRate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER4" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate4
		{
			get
			{
				return customPercentRate4;
			}
			set
			{
				this.customPercentRate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER5" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate5
		{
			get
			{
				return customPercentRate5;
			}
			set
			{
				this.customPercentRate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER6" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate6
		{
			get
			{
				return customPercentRate6;
			}
			set
			{
				this.customPercentRate6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER7" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate7
		{
			get
			{
				return customPercentRate7;
			}
			set
			{
				this.customPercentRate7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER8" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate8
		{
			get
			{
				return customPercentRate8;
			}
			set
			{
				this.customPercentRate8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER9" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate9
		{
			get
			{
				return customPercentRate9;
			}
			set
			{
				this.customPercentRate9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER10" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate10
		{
			get
			{
				return customPercentRate10;
			}
			set
			{
				this.customPercentRate10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER11" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate11
		{
			get
			{
				return customPercentRate11;
			}
			set
			{
				this.customPercentRate11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER12" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate12
		{
			get
			{
				return customPercentRate12;
			}
			set
			{
				this.customPercentRate12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER13" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate13
		{
			get
			{
				return customPercentRate13;
			}
			set
			{
				this.customPercentRate13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER14" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate14
		{
			get
			{
				return customPercentRate14;
			}
			set
			{
				this.customPercentRate14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER15" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate15
		{
			get
			{
				return customPercentRate15;
			}
			set
			{
				this.customPercentRate15 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER16" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate16
		{
			get
			{
				return customPercentRate16;
			}
			set
			{
				this.customPercentRate16 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER17" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate17
		{
			get
			{
				return customPercentRate17;
			}
			set
			{
				this.customPercentRate17 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER18" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate18
		{
			get
			{
				return customPercentRate18;
			}
			set
			{
				this.customPercentRate18 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER19" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate19
		{
			get
			{
				return customPercentRate19;
			}
			set
			{
				this.customPercentRate19 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER20" type="big_decimal" precision="30" scale="10"
		/// </summary>
		public virtual decimal CustomPercentRate20
		{
			get
			{
				return customPercentRate20;
			}
			set
			{
				this.customPercentRate20 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT1" type="costos_string" 
		/// </summary>
		public virtual string CustomText1
		{
			get
			{
				return customText1;
			}
			set
			{
				this.customText1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT2" type="costos_string" 
		/// </summary>
		public virtual string CustomText2
		{
			get
			{
				return customText2;
			}
			set
			{
				this.customText2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT3" type="costos_string" 
		/// </summary>
		public virtual string CustomText3
		{
			get
			{
				return customText3;
			}
			set
			{
				this.customText3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT4" type="costos_string" 
		/// </summary>
		public virtual string CustomText4
		{
			get
			{
				return customText4;
			}
			set
			{
				this.customText4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT5" type="costos_string" 
		/// </summary>
		public virtual string CustomText5
		{
			get
			{
				return customText5;
			}
			set
			{
				this.customText5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT6" type="costos_string" 
		/// </summary>
		public virtual string CustomText6
		{
			get
			{
				return customText6;
			}
			set
			{
				this.customText6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT7" type="costos_string" 
		/// </summary>
		public virtual string CustomText7
		{
			get
			{
				return customText7;
			}
			set
			{
				this.customText7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT8" type="costos_string" 
		/// </summary>
		public virtual string CustomText8
		{
			get
			{
				return customText8;
			}
			set
			{
				this.customText8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT9" type="costos_string" 
		/// </summary>
		public virtual string CustomText9
		{
			get
			{
				return customText9;
			}
			set
			{
				this.customText9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT10" type="costos_string" 
		/// </summary>
		public virtual string CustomText10
		{
			get
			{
				return customText10;
			}
			set
			{
				this.customText10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT11" type="costos_string" 
		/// </summary>
		public virtual string CustomText11
		{
			get
			{
				return customText11;
			}
			set
			{
				this.customText11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT12" type="costos_string" 
		/// </summary>
		public virtual string CustomText12
		{
			get
			{
				return customText12;
			}
			set
			{
				this.customText12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT13" type="costos_string" 
		/// </summary>
		public virtual string CustomText13
		{
			get
			{
				return customText13;
			}
			set
			{
				this.customText13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT14" type="costos_string" 
		/// </summary>
		public virtual string CustomText14
		{
			get
			{
				return customText14;
			}
			set
			{
				this.customText14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT15" type="costos_string" 
		/// </summary>
		public virtual string CustomText15
		{
			get
			{
				return customText15;
			}
			set
			{
				this.customText15 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT16" type="costos_string" 
		/// </summary>
		public virtual string CustomText16
		{
			get
			{
				return customText16;
			}
			set
			{
				this.customText16 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT17" type="costos_string" 
		/// </summary>
		public virtual string CustomText17
		{
			get
			{
				return customText17;
			}
			set
			{
				this.customText17 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT18" type="costos_string" 
		/// </summary>
		public virtual string CustomText18
		{
			get
			{
				return customText18;
			}
			set
			{
				this.customText18 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT19" type="costos_string" 
		/// </summary>
		public virtual string CustomText19
		{
			get
			{
				return customText19;
			}
			set
			{
				this.customText19 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT20" type="costos_string"
		/// </summary>
		public virtual string CustomText20
		{
			get
			{
				return customText20;
			}
			set
			{
				this.customText20 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT21" type="costos_string"
		/// </summary>
		public virtual string CustomText21
		{
			get
			{
				return customText21;
			}
			set
			{
				this.customText21 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT22" type="costos_string"
		/// </summary>
		public virtual string CustomText22
		{
			get
			{
				return customText22;
			}
			set
			{
				this.customText22 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT23" type="costos_string"
		/// </summary>
		public virtual string CustomText23
		{
			get
			{
				return customText23;
			}
			set
			{
				this.customText23 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT24" type="costos_string"
		/// </summary>
		public virtual string CustomText24
		{
			get
			{
				return customText24;
			}
			set
			{
				this.customText24 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT25" type="costos_string"
		/// </summary>
		public virtual string CustomText25
		{
			get
			{
				return customText25;
			}
			set
			{
				this.customText25 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE1FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate1Formula
		{
			get
			{
				return customRate1Formula;
			}
			set
			{
				this.customRate1Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE2FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate2Formula
		{
			get
			{
				return customRate2Formula;
			}
			set
			{
				this.customRate2Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE3FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate3Formula
		{
			get
			{
				return customRate3Formula;
			}
			set
			{
				this.customRate3Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE4FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate4Formula
		{
			get
			{
				return customRate4Formula;
			}
			set
			{
				this.customRate4Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE5FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate5Formula
		{
			get
			{
				return customRate5Formula;
			}
			set
			{
				this.customRate5Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE6FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate6Formula
		{
			get
			{
				return customRate6Formula;
			}
			set
			{
				this.customRate6Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE7FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate7Formula
		{
			get
			{
				return customRate7Formula;
			}
			set
			{
				this.customRate7Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE8FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate8Formula
		{
			get
			{
				return customRate8Formula;
			}
			set
			{
				this.customRate8Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE9FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate9Formula
		{
			get
			{
				return customRate9Formula;
			}
			set
			{
				this.customRate9Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE10FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate10Formula
		{
			get
			{
				return customRate10Formula;
			}
			set
			{
				this.customRate10Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE11FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate11Formula
		{
			get
			{
				return customRate11Formula;
			}
			set
			{
				this.customRate11Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE12FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate12Formula
		{
			get
			{
				return customRate12Formula;
			}
			set
			{
				this.customRate12Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE13FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate13Formula
		{
			get
			{
				return customRate13Formula;
			}
			set
			{
				this.customRate13Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE14FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate14Formula
		{
			get
			{
				return customRate14Formula;
			}
			set
			{
				this.customRate14Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE15FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate15Formula
		{
			get
			{
				return customRate15Formula;
			}
			set
			{
				this.customRate15Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE16FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate16Formula
		{
			get
			{
				return customRate16Formula;
			}
			set
			{
				this.customRate16Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE17FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate17Formula
		{
			get
			{
				return customRate17Formula;
			}
			set
			{
				this.customRate17Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE18FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate18Formula
		{
			get
			{
				return customRate18Formula;
			}
			set
			{
				this.customRate18Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE19FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate19Formula
		{
			get
			{
				return customRate19Formula;
			}
			set
			{
				this.customRate19Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSRATE20FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomRate20Formula
		{
			get
			{
				return customRate20Formula;
			}
			set
			{
				this.customRate20Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM1FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate1Formula
		{
			get
			{
				return customCumRate1Formula;
			}
			set
			{
				this.customCumRate1Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM2FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate2Formula
		{
			get
			{
				return customCumRate2Formula;
			}
			set
			{
				this.customCumRate2Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM3FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate3Formula
		{
			get
			{
				return customCumRate3Formula;
			}
			set
			{
				this.customCumRate3Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM4FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate4Formula
		{
			get
			{
				return customCumRate4Formula;
			}
			set
			{
				this.customCumRate4Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM5FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate5Formula
		{
			get
			{
				return customCumRate5Formula;
			}
			set
			{
				this.customCumRate5Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM6FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate6Formula
		{
			get
			{
				return customCumRate6Formula;
			}
			set
			{
				this.customCumRate6Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM7FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate7Formula
		{
			get
			{
				return customCumRate7Formula;
			}
			set
			{
				this.customCumRate7Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM8FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate8Formula
		{
			get
			{
				return customCumRate8Formula;
			}
			set
			{
				this.customCumRate8Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM9FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate9Formula
		{
			get
			{
				return customCumRate9Formula;
			}
			set
			{
				this.customCumRate9Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM10FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate10Formula
		{
			get
			{
				return customCumRate10Formula;
			}
			set
			{
				this.customCumRate10Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM11FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate11Formula
		{
			get
			{
				return customCumRate11Formula;
			}
			set
			{
				this.customCumRate11Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM12FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate12Formula
		{
			get
			{
				return customCumRate12Formula;
			}
			set
			{
				this.customCumRate12Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM13FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate13Formula
		{
			get
			{
				return customCumRate13Formula;
			}
			set
			{
				this.customCumRate13Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM14FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate14Formula
		{
			get
			{
				return customCumRate14Formula;
			}
			set
			{
				this.customCumRate14Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM15FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate15Formula
		{
			get
			{
				return customCumRate15Formula;
			}
			set
			{
				this.customCumRate15Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM16FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate16Formula
		{
			get
			{
				return customCumRate16Formula;
			}
			set
			{
				this.customCumRate16Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM17FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate17Formula
		{
			get
			{
				return customCumRate17Formula;
			}
			set
			{
				this.customCumRate17Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM18FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate18Formula
		{
			get
			{
				return customCumRate18Formula;
			}
			set
			{
				this.customCumRate18Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM19FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate19Formula
		{
			get
			{
				return customCumRate19Formula;
			}
			set
			{
				this.customCumRate19Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSCUM20FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomCumRate20Formula
		{
			get
			{
				return customCumRate20Formula;
			}
			set
			{
				this.customCumRate20Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER1FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate1Formula
		{
			get
			{
				return customPercentRate1Formula;
			}
			set
			{
				this.customPercentRate1Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER2FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate2Formula
		{
			get
			{
				return customPercentRate2Formula;
			}
			set
			{
				this.customPercentRate2Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER3FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate3Formula
		{
			get
			{
				return customPercentRate3Formula;
			}
			set
			{
				this.customPercentRate3Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER4FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate4Formula
		{
			get
			{
				return customPercentRate4Formula;
			}
			set
			{
				this.customPercentRate4Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER5FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate5Formula
		{
			get
			{
				return customPercentRate5Formula;
			}
			set
			{
				this.customPercentRate5Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER6FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate6Formula
		{
			get
			{
				return customPercentRate6Formula;
			}
			set
			{
				this.customPercentRate6Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER7FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate7Formula
		{
			get
			{
				return customPercentRate7Formula;
			}
			set
			{
				this.customPercentRate7Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER8FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate8Formula
		{
			get
			{
				return customPercentRate8Formula;
			}
			set
			{
				this.customPercentRate8Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER9FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate9Formula
		{
			get
			{
				return customPercentRate9Formula;
			}
			set
			{
				this.customPercentRate9Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER10FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate10Formula
		{
			get
			{
				return customPercentRate10Formula;
			}
			set
			{
				this.customPercentRate10Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER11FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate11Formula
		{
			get
			{
				return customPercentRate11Formula;
			}
			set
			{
				this.customPercentRate11Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER12FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate12Formula
		{
			get
			{
				return customPercentRate12Formula;
			}
			set
			{
				this.customPercentRate12Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER13FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate13Formula
		{
			get
			{
				return customPercentRate13Formula;
			}
			set
			{
				this.customPercentRate13Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER14FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate14Formula
		{
			get
			{
				return customPercentRate14Formula;
			}
			set
			{
				this.customPercentRate14Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER15FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate15Formula
		{
			get
			{
				return customPercentRate15Formula;
			}
			set
			{
				this.customPercentRate15Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER16FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate16Formula
		{
			get
			{
				return customPercentRate16Formula;
			}
			set
			{
				this.customPercentRate16Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER17FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate17Formula
		{
			get
			{
				return customPercentRate17Formula;
			}
			set
			{
				this.customPercentRate17Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER18FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate18Formula
		{
			get
			{
				return customPercentRate18Formula;
			}
			set
			{
				this.customPercentRate18Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER19FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate19Formula
		{
			get
			{
				return customPercentRate19Formula;
			}
			set
			{
				this.customPercentRate19Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSPER20FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomPercentRate20Formula
		{
			get
			{
				return customPercentRate20Formula;
			}
			set
			{
				this.customPercentRate20Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT1FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText1Formula
		{
			get
			{
				return customText1Formula;
			}
			set
			{
				this.customText1Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT2FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText2Formula
		{
			get
			{
				return customText2Formula;
			}
			set
			{
				this.customText2Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT3FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText3Formula
		{
			get
			{
				return customText3Formula;
			}
			set
			{
				this.customText3Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT4FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText4Formula
		{
			get
			{
				return customText4Formula;
			}
			set
			{
				this.customText4Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT5FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText5Formula
		{
			get
			{
				return customText5Formula;
			}
			set
			{
				this.customText5Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT6FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText6Formula
		{
			get
			{
				return customText6Formula;
			}
			set
			{
				this.customText6Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT7FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText7Formula
		{
			get
			{
				return customText7Formula;
			}
			set
			{
				this.customText7Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT8FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText8Formula
		{
			get
			{
				return customText8Formula;
			}
			set
			{
				this.customText8Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT9FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText9Formula
		{
			get
			{
				return customText9Formula;
			}
			set
			{
				this.customText9Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT10FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText10Formula
		{
			get
			{
				return customText10Formula;
			}
			set
			{
				this.customText10Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT11FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText11Formula
		{
			get
			{
				return customText11Formula;
			}
			set
			{
				this.customText11Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT12FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText12Formula
		{
			get
			{
				return customText12Formula;
			}
			set
			{
				this.customText12Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT13FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText13Formula
		{
			get
			{
				return customText13Formula;
			}
			set
			{
				this.customText13Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT14FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText14Formula
		{
			get
			{
				return customText14Formula;
			}
			set
			{
				this.customText14Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT15FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText15Formula
		{
			get
			{
				return customText15Formula;
			}
			set
			{
				this.customText15Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT16FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText16Formula
		{
			get
			{
				return customText16Formula;
			}
			set
			{
				this.customText16Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT17FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText17Formula
		{
			get
			{
				return customText17Formula;
			}
			set
			{
				this.customText17Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT18FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText18Formula
		{
			get
			{
				return customText18Formula;
			}
			set
			{
				this.customText18Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT19FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText19Formula
		{
			get
			{
				return customText19Formula;
			}
			set
			{
				this.customText19Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT20FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText20Formula
		{
			get
			{
				return customText20Formula;
			}
			set
			{
				this.customText20Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT21FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText21Formula
		{
			get
			{
				return customText21Formula;
			}
			set
			{
				this.customText21Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT22FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText22Formula
		{
			get
			{
				return customText22Formula;
			}
			set
			{
				this.customText22Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT23FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText23Formula
		{
			get
			{
				return customText23Formula;
			}
			set
			{
				this.customText23Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT24FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText24Formula
		{
			get
			{
				return customText24Formula;
			}
			set
			{
				this.customText24Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSTXT25FORM" type="costos_text" 
		/// </summary>
		public virtual string CustomText25Formula
		{
			get
			{
				return customText25Formula;
			}
			set
			{
				this.customText25Formula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSDATE1" type="timestamp"
		/// </summary>
		public virtual DateTime CustomDate1
		{
			get
			{
				return customDate1;
			}
			set
			{
				this.customDate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSDATE2" type="timestamp"
		/// </summary>
		public virtual DateTime CustomDate2
		{
			get
			{
				return customDate2;
			}
			set
			{
				this.customDate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSDATE3" type="timestamp"
		/// </summary>
		public virtual DateTime CustomDate3
		{
			get
			{
				return customDate3;
			}
			set
			{
				this.customDate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSDATE4" type="timestamp"
		/// </summary>
		public virtual DateTime CustomDate4
		{
			get
			{
				return customDate4;
			}
			set
			{
				this.customDate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSDATE5" type="timestamp"
		/// </summary>
		public virtual DateTime CustomDate5
		{
			get
			{
				return customDate5;
			}
			set
			{
				this.customDate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ASRT" type="byte" 
		/// </summary>
		public virtual sbyte? AssemblyRateType
		{
			get
			{
				return assemblyRateType;
			}
			set
			{
				this.assemblyRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EQRT" type="byte" 
		/// </summary>
		public virtual sbyte? EquipmentRateType
		{
			get
			{
				return equipmentRateType;
			}
			set
			{
				this.equipmentRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SBRT" type="byte" 
		/// </summary>
		public virtual sbyte? SubcontractorRateType
		{
			get
			{
				return subcontractorRateType;
			}
			set
			{
				this.subcontractorRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LBRT" type="byte" 
		/// </summary>
		public virtual sbyte? LaborRateType
		{
			get
			{
				return laborRateType;
			}
			set
			{
				this.laborRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MART" type="byte" 
		/// </summary>
		public virtual sbyte? MaterialRateType
		{
			get
			{
				return materialRateType;
			}
			set
			{
				this.materialRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CMRT" type="byte" 
		/// </summary>
		public virtual sbyte? ConsumableRateType
		{
			get
			{
				return consumableRateType;
			}
			set
			{
				this.consumableRateType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CNQT" type="byte" 
		/// </summary>
		public virtual sbyte? TakeoffQuantityType
		{
			get
			{
				return takeoffQuantityType;
			}
			set
			{
				this.takeoffQuantityType = value;
			}
		}


		public override decimal TableRate
		{
			get
			{
				return Rate;
			}
			set
			{
				Rate = value;
			}
		}

		//	// DELETE THIS:
		//	public String formulaForField(String field) {		
		//		if ( field.equals("quantity") && getQuantityFormula() != null ) {
		//			return getQuantityFormula();
		//		}
		//		else if ( field.equals("markup") && getMarkupFormula() != null ) {
		//			return getMarkupFormula();
		//		}
		//		else if ( field.equals("estimatedQuantity") && getEstimatedQuantityFormula() != null ) {
		//			return getEstimatedQuantityFormula();
		//		}
		//		else if ( field.equals("measuredQuantity") && getMeasuredQuantityFormula() != null ) {
		//			return getMeasuredQuantityFormula();
		//		}
		//		else if ( field.equals("duration") && getDurationFormula() != null ) {
		//			return getDurationFormula();
		//		}
		//		else if ( field.equals("productivity") && getProductivityFormula() != null ) {
		//			return getProductivityFormula();
		//		}
		//		return null;
		//	}

		public virtual bool hasFormulas()
		{
			if (!string.ReferenceEquals(TitleFormula, null) || !string.ReferenceEquals(DescriptionFormula, null) || !string.ReferenceEquals(MeasuredQuantityFormula, null) || !string.ReferenceEquals(EstimatedQuantityFormula, null) || !string.ReferenceEquals(QuantityFormula, null) || !string.ReferenceEquals(MarkupFormula, null) || !string.ReferenceEquals(DurationFormula, null) || !string.ReferenceEquals(ProductivityFormula, null) || !string.ReferenceEquals(TotalCostFormula, null) || !string.ReferenceEquals(OfferedPriceFormula, null) || !string.ReferenceEquals(RateFormula, null) || !string.ReferenceEquals(OfferedRateFormula, null) || !string.ReferenceEquals(OfferedSecondRateFormula, null) || !string.ReferenceEquals(SecondRateFormula, null) || !string.ReferenceEquals(SecondQuantityFormula, null) || !string.ReferenceEquals(QuantityLossFormula, null) || !string.ReferenceEquals(SecondUnitFormula, null) || !string.ReferenceEquals(UnitsDivFormula, null) || !string.ReferenceEquals(AssemblyTotalCostFormula, null) || !string.ReferenceEquals(EquipmentTotalCostFormula, null) || !string.ReferenceEquals(MaterialTotalCostFormula, null) || !string.ReferenceEquals(SubcontractorTotalCostFormula, null) || !string.ReferenceEquals(LaborTotalCostFormula, null) || !string.ReferenceEquals(ConsumableTotalCostFormula, null) || !string.ReferenceEquals(WbsCodeFormula, null) || !string.ReferenceEquals(Wbs2CodeFormula, null) || !string.ReferenceEquals(CustomRate1Formula, null) || !string.ReferenceEquals(CustomRate2Formula, null) || !string.ReferenceEquals(CustomRate3Formula, null) || !string.ReferenceEquals(CustomRate4Formula, null) || !string.ReferenceEquals(CustomRate5Formula, null) || !string.ReferenceEquals(CustomRate6Formula, null) || !string.ReferenceEquals(CustomRate7Formula, null) || !string.ReferenceEquals(CustomRate8Formula, null) || !string.ReferenceEquals(CustomRate9Formula, null) || !string.ReferenceEquals(CustomRate10Formula, null) || !string.ReferenceEquals(CustomCumRate1Formula, null) || !string.ReferenceEquals(CustomCumRate2Formula, null) || !string.ReferenceEquals(CustomCumRate3Formula, null) || !string.ReferenceEquals(CustomCumRate4Formula, null) || !string.ReferenceEquals(CustomCumRate5Formula, null) || !string.ReferenceEquals(CustomCumRate6Formula, null) || !string.ReferenceEquals(CustomCumRate7Formula, null) || !string.ReferenceEquals(CustomCumRate8Formula, null) || !string.ReferenceEquals(CustomCumRate9Formula, null) || !string.ReferenceEquals(CustomCumRate10Formula, null) || !string.ReferenceEquals(CustomPercentRate1Formula, null) || !string.ReferenceEquals(CustomPercentRate2Formula, null) || !string.ReferenceEquals(CustomPercentRate3Formula, null) || !string.ReferenceEquals(CustomPercentRate4Formula, null) || !string.ReferenceEquals(CustomPercentRate5Formula, null) || !string.ReferenceEquals(CustomPercentRate6Formula, null) || !string.ReferenceEquals(CustomPercentRate7Formula, null) || !string.ReferenceEquals(CustomPercentRate8Formula, null) || !string.ReferenceEquals(CustomPercentRate9Formula, null) || !string.ReferenceEquals(CustomPercentRate10Formula, null) || !string.ReferenceEquals(CustomText1Formula, null) || !string.ReferenceEquals(CustomText2Formula, null) || !string.ReferenceEquals(CustomText3Formula, null) || !string.ReferenceEquals(CustomText4Formula, null) || !string.ReferenceEquals(CustomText5Formula, null) || !string.ReferenceEquals(CustomText6Formula, null) || !string.ReferenceEquals(CustomText7Formula, null) || !string.ReferenceEquals(CustomText8Formula, null) || !string.ReferenceEquals(CustomText9Formula, null) || !string.ReferenceEquals(CustomText10Formula, null) || !string.ReferenceEquals(CustomText11Formula, null) || !string.ReferenceEquals(CustomText12Formula, null) || !string.ReferenceEquals(CustomText13Formula, null) || !string.ReferenceEquals(CustomText14Formula, null) || !string.ReferenceEquals(CustomText15Formula, null) || !string.ReferenceEquals(CustomText16Formula, null) || !string.ReferenceEquals(CustomText17Formula, null) || !string.ReferenceEquals(CustomText18Formula, null) || !string.ReferenceEquals(CustomText19Formula, null) || !string.ReferenceEquals(CustomText20Formula, null))
			{
				return true;
			}
			return false;
		}

		public override void recalculate()
		{
			recalculate(true);
		}

		public virtual void recalculate(bool calcResources)
		{
			if (!calculationsEnabled)
			{
				return;
			}

			forceRecalculate(calcResources);
		}

		public virtual void forceRecalculate(bool calcResources)
		{
			forceRecalculate(calcResources, false);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void detectCirculaReference() throws org.boris.expr.util.GraphCycleException
		public virtual void detectCirculaReference()
		{
			BoqItemDependencyEngine engine;
			try
			{
				engine = new BoqItemDependencyEngine(this, "");
				engine.detectCirculaReference();
			}
			catch (ExprException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

		}

		public virtual void forceRecalculate(bool calcResources, bool deepRecalc)
		{
			forceRecalculate(calcResources, calcResources, deepRecalc);
		}

		public virtual void forceRecalculate(bool calcResources, bool calcConditions, bool deepRecalc)
		{
			try
			{
				BoqItemDependencyEngine engine = new BoqItemDependencyEngine(this, "");
				//System.out.println("ENGINE CREATION: "+(System.currentTimeMillis()-t));			

				if (calcConditions)
				{
					decimal measuredQty = calculateTotalConditionsQuantity();
					MeasuredQuantity = measuredQty;

					if (!StringUtils.isNullOrBlank(QuantityFormula))
					{
						object val = engine.valueFromExpression(QuantityFormula);
						if (val is decimal)
						{
							Quantity = (decimal) val;
						}
					}
				}

				// Maybe Productivity and Quantity Calculation needs to be done first?
				engine.calculate(true);

				//			if ( engine.getUpdatedFromFormulaAssignments().size() != 0 ) {
				//				calcResources = true;
				//				deepRecalc = true;
				//			}

				// This determines if we have to deep recalculate based on the first calculation [engine.calculate(true);]
				bool someAssignemntFormulaValueChanged = engine.SomeAssignemntFormulaValueChanged;

				if (calcResources || calcConditions || someAssignemntFormulaValueChanged)
				{
					//System.out.println("CALCULAITION 1: "+(System.currentTimeMillis()-t));

					if (someAssignemntFormulaValueChanged)
					{
						deepRecalc = true;
					}

					calculateRatesAndCosts(engine, calcResources, deepRecalc);
					calculateAwardedRates(engine);
					//System.out.println("Accuracy: "+(System.currentTimeMillis()-t));
					engine.calculate(true); // Actual Values being calculated now!
					//System.out.println("i am moving to accuracy with rate = "+getRate());
					calculateAccuracy(engine); // Last Calculate Status and Accuracy of Item.
				}

				//System.out.println("calculation 2: "+(System.currentTimeMillis()-t));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.Write(ex.StackTrace);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void calculateRatesAndCosts(nomitech.common.expr.boqitem.BoqItemDependencyEngine engine, boolean calcResources, boolean deepRecalc) throws Exception
		private void calculateRatesAndCosts(BoqItemDependencyEngine engine, bool calcResources, bool deepRecalc)
		{

			if (calcResources)
			{
				AssemblyRate = calculateAssemblyRate(deepRecalc);
				LaborRate = calculateLaborRate(true) + calculateAssemblyLaborRate();
				MaterialRate = calculateMaterialResourceRate() + calculateAssemblyMaterialResourceRate();
				SubcontractorRate = calculateSubcontractorRate() + calculateAssemblySubcontractorRate();
				EquipmentRate = calculateEquipmentRate() + calculateAssemblyEquipmentRate();
				ConsumableRate = calculateConsumableRate() + calculateAssemblyConsumableRate();
				FabricationRate = calculateFabricationRate() + calculateAssemblyFabricationRate();
				ShipmentRate = calculateShipmentRate() + calculateAssemblyShipmentRate();
				LaborManhours = calculateLaborManhours() + calculateAssemblyLaborManhours(); // Total
				EquipmentHours = calculateEquipmentHours() + calculateAssemblyEquipmentHours(); // Total

				QuotedSubcontractorRate = calculateQuotedSubcontractorRate();
				QuotedMaterialRate = calculateQuotedMaterialRate();

				FixedCost = calculateTotalFixedCost();
			}

			engine.setFieldValue("assemblyRate", AssemblyRate);
			engine.setFieldValue("laborRate", LaborRate);
			engine.setFieldValue("subcontractorRate", SubcontractorRate);
			engine.setFieldValue("equipmentRate", EquipmentRate);
			engine.setFieldValue("consumableRate", ConsumableRate);
			engine.setFieldValue("measuredQuantity", MeasuredQuantity);
			engine.setFieldValue("materialRate", MaterialRate);
			engine.setFieldValue("fabricationRate", FabricationRate);
			engine.setFieldValue("shipmentRate", ShipmentRate);
			engine.setFieldValue("quotedSubcontractorRate", QuotedSubcontractorRate);
			engine.setFieldValue("quotedMaterialRate", QuotedMaterialRate);
			engine.setFieldValue("laborManhours", LaborManhours);
			engine.setFieldValue("equipmentHours", EquipmentHours);
			engine.setFieldValue("fixedCost", FixedCost);

			if (string.ReferenceEquals(RateFormula, null) || Rate == null)
			{
				Rate = calculateRate();
				engine.setFieldValue("rate", Rate);
			}

			if (string.ReferenceEquals(AssemblyTotalCostFormula, null) || AssemblyTotalCost == null)
			{
				AssemblyTotalCost = calculateAssemblyTotalCost();
				engine.setFieldValue("assemblyTotalCost", AssemblyTotalCost);
			}
			if (string.ReferenceEquals(LaborTotalCostFormula, null) || LaborTotalCost == null)
			{
				LaborTotalCost = calculateLaborTotalCost();
				engine.setFieldValue("laborTotalCost", LaborTotalCost);
			}
			if (string.ReferenceEquals(SubcontractorTotalCostFormula, null) || SubcontractorTotalCost == null)
			{
				SubcontractorTotalCost = calculateSubcontractorTotalCost();
				engine.setFieldValue("subcontractorTotalCost", SubcontractorTotalCost);
			}
			if (string.ReferenceEquals(EquipmentTotalCostFormula, null) || EquipmentTotalCost == null)
			{
				EquipmentTotalCost = calculateEquipmentTotalCost();
				engine.setFieldValue("equipmentTotalCost", EquipmentTotalCost);
			}
			if (string.ReferenceEquals(ConsumableTotalCostFormula, null) || ConsumableTotalCost == null)
			{
				ConsumableTotalCost = calculateConsumableTotalCost();
				engine.setFieldValue("consumableTotalCost", ConsumableTotalCost);
			}
			if (string.ReferenceEquals(MaterialTotalCostFormula, null) || MaterialTotalCost == null)
			{
				MaterialTotalCost = calculateMaterialTotalCost();
				engine.setFieldValue("materialTotalCost", MaterialTotalCost);
			}

			MaterialResourceTotalCost = calculateMaterialResourceTotalCost();
			engine.setFieldValue("materialResourceTotalCost", MaterialResourceTotalCost);
			FabricationTotalCost = calculateMaterialFabricationTotalCost();
			engine.setFieldValue("fabricationTotalCost", FabricationTotalCost);
			ShipmentTotalCost = calculateMaterialShipmentTotalCost();
			engine.setFieldValue("shipmentTotalCost", ShipmentTotalCost);

			if (string.ReferenceEquals(TotalCostFormula, null) || TotalCost == null)
			{
				TotalCost = calculateTotalCost();
				engine.setFieldValue("totalCost", TotalCost);
			}
			if (OfferedPrice == null || OfferedPrice == null)
			{
				OfferedPrice = calculateOfferedPrice();
				engine.setFieldValue("offeredPrice", OfferedPrice);
			}

			if (string.ReferenceEquals(OfferedRateFormula, null) || OfferedRate == null)
			{
				OfferedRate = calculateOfferedRate();
				engine.setFieldValue("offeredRate", OfferedRate);
			}
			if (string.ReferenceEquals(SecondRateFormula, null) || SecondRate == null)
			{
				SecondRate = calculateSecondRate();
				engine.setFieldValue("secondRate", SecondRate);
			}
			if (string.ReferenceEquals(SecondQuantityFormula, null) || SecondQuantity == null)
			{
				SecondQuantity = calculateSecondQuantity();
				engine.setFieldValue("secondQuantity", SecondQuantity);
			}
			if (string.ReferenceEquals(OfferedSecondRateFormula, null) || OfferedSecondRate == null)
			{
				OfferedSecondRate = calculateOfferedSecondRate();
				engine.setFieldValue("offeredSecondRate", OfferedSecondRate);
			}
			if (string.ReferenceEquals(QuantityLossFormula, null) || QuantityLoss == null)
			{
				QuantityLoss = calculateQuantityLoss();
				engine.setFieldValue("quantityLoss", QuantityLoss);
			}

			if (ParamItemTable != null)
			{
				ParamItemCode = ParamItemTable.ToString();
				ParamItemId = ParamItemTable.Id;
				GlobalParamItemId = ParamItemTable.GlobalId;
			}
			else
			{
				ParamItemCode = null;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void calculateAwardedRates(nomitech.common.expr.boqitem.BoqItemDependencyEngine engine) throws Exception
		private void calculateAwardedRates(BoqItemDependencyEngine engine)
		{
			if (QuoteItemSet == null)
			{
				QuoteItemSet = new HashSet<object>();
			}

			AwardedMaterialRate = BigDecimalMath.ZERO;
			AwardedInsuranceRate = BigDecimalMath.ZERO;
			AwardedSubcontractorRate = BigDecimalMath.ZERO;
			AwardedManhours = BigDecimalMath.ZERO;
			AwardedIndirectRate = BigDecimalMath.ZERO;
			AwardedShipmentRate = BigDecimalMath.ZERO;
			AwardedTotalRate = BigDecimalMath.ZERO;

			IEnumerator<QuoteItemTable> iter0 = QuoteItemSet.GetEnumerator();
			while (iter0.MoveNext())
			{
				QuoteItemTable quoteItemTable = iter0.Current;
				if (quoteItemTable.QuotationTable.QuoteType.Equals(QuotationTable.SUBCONTRACTOR_QUOTE))
				{
					if (quoteItemTable.State.Equals(QuoteItemTable.AWARDED_STATE))
					{
						if (quoteItemTable.MaterialRate != null)
						{
							AwardedMaterialRate = AwardedMaterialRate + quoteItemTable.MaterialRate;
						}
						if (quoteItemTable.Rate != null)
						{
							AwardedSubcontractorRate = AwardedSubcontractorRate + quoteItemTable.Rate;
						}
						if (quoteItemTable.ManHours != null)
						{
							AwardedManhours = AwardedManhours + quoteItemTable.ManHours;
						}
						if (quoteItemTable.Insurance != null)
						{
							AwardedInsuranceRate = AwardedInsuranceRate + quoteItemTable.Insurance;
						}
						if (quoteItemTable.IndirectCost != null)
						{
							AwardedIndirectRate = AwardedIndirectRate + quoteItemTable.IndirectRate;
						}

						AwardedTotalRate = AwardedTotalRate + quoteItemTable.FinalRate;
					}

					//if ( hasReceivedMaterialQuotes )
					//break;
				}
				else if (quoteItemTable.State.Equals(QuoteItemTable.AWARDED_STATE))
				{
					if (quoteItemTable.MaterialRate != null)
					{
						AwardedMaterialRate = AwardedMaterialRate + quoteItemTable.Rate;
					}
					if (quoteItemTable.ShipmentCost != null)
					{
						AwardedShipmentRate = AwardedIndirectRate + quoteItemTable.ShipmentRate;
					}

					AwardedTotalRate = AwardedTotalRate + quoteItemTable.FinalRate;
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void calculateAccuracy(nomitech.common.expr.boqitem.BoqItemDependencyEngine engine) throws Exception
		private void calculateAccuracy(BoqItemDependencyEngine engine)
		{

			// First Calculate All Rates / Prices:	
			AssemblyRateType = RATE_TYPE_EMPTY;
			EquipmentRateType = RATE_TYPE_EMPTY;
			SubcontractorRateType = RATE_TYPE_EMPTY;
			LaborRateType = RATE_TYPE_EMPTY;
			MaterialRateType = RATE_TYPE_EMPTY;
			ConsumableRateType = RATE_TYPE_EMPTY;

			bool hasEstimated = false;
			bool hasQuoted = false;

			bool hasReceivedSubcontractorQuotes = false;
			bool hasReceivedMaterialQuotes = false;

			bool hasPendingSubcontractorQuotes = false;
			bool hasPendingMaterialQuotes = false;

			bool isAMaterialQuoted = false;
			bool isASubcontractorQuoted = false;

			//		BigDecimal estMaterialRate = BigDecimalMath.ZERO;
			//		BigDecimal estFabricationRate = BigDecimalMath.ZERO;
			//		BigDecimal estShipmentRate = BigDecimalMath.ZERO;		
			//		BigDecimal estSubcontractorRate = BigDecimalMath.ZERO;
			//		BigDecimal estLaborRate = BigDecimalMath.ZERO;
			//		BigDecimal estEquipmentRate = BigDecimalMath.ZERO;		
			//		BigDecimal estAssemblyRate = BigDecimalMath.ZERO;
			//		BigDecimal estConsumableRate = BigDecimalMath.ZERO;
			//		BigDecimal quotSubcontractorRate = BigDecimalMath.ZERO;
			//		BigDecimal quotMaterialRate = BigDecimalMath.ZERO;

			if (BoqItemMaterialSet == null)
			{
				BoqItemMaterialSet = new HashSet<object>();
			}
			if (BoqItemSubcontractorSet == null)
			{
				BoqItemSubcontractorSet = new HashSet<object>();
			}
			if (BoqItemAssemblySet == null)
			{
				BoqItemAssemblySet = new HashSet<object>();
			}
			if (BoqItemLaborSet == null)
			{
				BoqItemLaborSet = new HashSet<object>();
			}
			if (BoqItemEquipmentSet == null)
			{
				BoqItemEquipmentSet = new HashSet<object>();
			}
			if (BoqItemConsumableSet == null)
			{
				BoqItemConsumableSet = new HashSet<object>();
			}
			if (QuoteItemSet == null)
			{
				QuoteItemSet = new HashSet<object>();
			}

			IEnumerator<QuoteItemTable> iter0 = QuoteItemSet.GetEnumerator();
			while (iter0.MoveNext())
			{
				QuoteItemTable quoteItemTable = iter0.Current;
				if (quoteItemTable.State.Equals(QuoteItemTable.PENDING_STATE))
				{
					if (quoteItemTable.QuotationTable.QuoteType.Equals(QuotationTable.SUBCONTRACTOR_QUOTE))
					{
						hasPendingSubcontractorQuotes = true;
					}
					else
					{
						hasPendingMaterialQuotes = true;
					}
					continue;
				}
				else if (quoteItemTable.State.Equals(QuoteItemTable.NOTAVAILABLE_STATE))
				{
					continue;
				}
				else if (quoteItemTable.QuotationTable.QuoteType.Equals(QuotationTable.SUBCONTRACTOR_QUOTE))
				{
					hasReceivedSubcontractorQuotes = true;
				}
				else
				{
					hasReceivedMaterialQuotes = true;
					//if ( hasReceivedSubcontractorQuotes )
					//break;
				}
			}

			IEnumerator<BoqItemMaterialTable> iter1 = BoqItemMaterialSet.GetEnumerator();
			while (iter1.MoveNext())
			{
				BoqItemMaterialTable boqMatTable = iter1.Current;
				MaterialTable matTable = boqMatTable.MaterialTable;
				if (matTable.Accuracy.Equals(MaterialTable.ESTIMATED_ACCURACY))
				{
					hasEstimated = true;
					//				estMaterialRate = estMaterialRate.add(boqMatTable.getFinalMaterialRate());
					//				estFabricationRate = estFabricationRate.add(boqMatTable.getFinalFabricationRate());
					//				estShipmentRate = estMaterialRate.add(boqMatTable.getFinalShipmentRate());				
				}
				else
				{
					//System.out.println("I FOUND A QUOTED CAUSE: "+matTable.getAccuracy());
					hasQuoted = true;
					isAMaterialQuoted = true;
					//				quotMaterialRate = quotMaterialRate.add(boqMatTable.calculateFinalRate());
				}
				MaterialRateType = calculateRateType(matTable, MaterialRateType);
			}

			IEnumerator<BoqItemSubcontractorTable> iter2 = BoqItemSubcontractorSet.GetEnumerator();
			while (iter2.MoveNext())
			{
				BoqItemSubcontractorTable boqSubTable = iter2.Current;
				SubcontractorTable matTable = boqSubTable.SubcontractorTable;
				if (matTable.Accuracy.Equals(SubcontractorTable.ESTIMATED_ACCURACY))
				{
					hasEstimated = true;
					//				estSubcontractorRate = estSubcontractorRate.add(boqSubTable.calculateFinalRate());	
				}
				else
				{
					hasQuoted = true;
					isASubcontractorQuoted = true;
					//				quotSubcontractorRate = quotSubcontractorRate.add(boqSubTable.calculateFinalRate());
				}
				SubcontractorRateType = calculateRateType(matTable, SubcontractorRateType);
			}

			IEnumerator<BoqItemAssemblyTable> iter3 = BoqItemAssemblySet.GetEnumerator();
			while (iter3.MoveNext())
			{
				BoqItemAssemblyTable boqAssTable = iter3.Current;
				//			estAssemblyRate = estAssemblyRate.add(boqAssTable.calculateFinalRate());			
				hasEstimated = true;
				AssemblyRateType = calculateRateType(boqAssTable.AssemblyTable, AssemblyRateType);
			}

			//		System.out.println("\n\n\n\nCalcualting PLUGGED IN FOR: "+getTitle());
			IEnumerator<BoqItemLaborTable> iter4 = BoqItemLaborSet.GetEnumerator();
			while (iter4.MoveNext())
			{
				BoqItemLaborTable boqLabTable = iter4.Current;
				//			estLaborRate = estLaborRate.add(boqLabTable.calculateFinalRate());			
				hasEstimated = true;
				//			System.out.println("WAS: "+boqLabTable.getId()+" = "+boqLabTable.getLaborTable().getVirtual()+","+getLaborRateType());
				LaborRateType = calculateRateType(boqLabTable.LaborTable, LaborRateType);
				//			System.out.println("BECOMES: "+boqLabTable.getId()+" = "+boqLabTable.getLaborTable().getVirtual()+","+getLaborRateType());			
			}

			IEnumerator<BoqItemEquipmentTable> iter5 = BoqItemEquipmentSet.GetEnumerator();
			while (iter5.MoveNext())
			{
				BoqItemEquipmentTable boqEquTable = iter5.Current;
				//			estEquipmentRate = estEquipmentRate.add(boqEquTable.calculateFinalRate());			
				hasEstimated = true;
				EquipmentRateType = calculateRateType(boqEquTable.EquipmentTable, EquipmentRateType);
			}

			IEnumerator<BoqItemConsumableTable> iter6 = BoqItemConsumableSet.GetEnumerator();
			while (iter6.MoveNext())
			{
				BoqItemConsumableTable boqConTable = iter6.Current;
				//			estConsumableRate = estConsumableRate.add(boqConTable.calculateFinalRate());			
				hasEstimated = true;
				ConsumableRateType = calculateRateType(boqConTable.ConsumableTable, ConsumableRateType);
			}

			if ((!hasQuoted && hasEstimated) || (!hasQuoted && !hasEstimated))
			{
				//			setEstimRate(
				//					estMaterialRate.add(estSubcontractorRate).add(estLaborRate).add(estAssemblyRate).add(estConsumableRate).add(estEquipmentRate).add(estFabricationRate).add(estShipmentRate)
				//					);
				//
				//			setEstimMaterialRate(estMaterialRate);
				//			setEstimSubcontractorRate(estSubcontractorRate);				
				//			setEstimFabricationRate(estFabricationRate);
				//			setEstimShipmentRate(estShipmentRate);			
				//			setEstimLaborRate(estLaborRate);
				//			setEstimAssemblyRate(estAssemblyRate);
				//			setEstimConsumableRate(estConsumableRate);
				//			setEstimEquipmentRate(estEquipmentRate);			
				Accuracy = s_ESTIMATED_ACCURACY;
				//			engine.setFieldValue("estimRate", getEstimRate());
				//			engine.setFieldValue("estimSubcontractorRate", getEstimSubcontractorRate());
				//			engine.setFieldValue("estimFabricationRate", getEstimFabricationRate());
				//			engine.setFieldValue("estimShipmentRate", getEstimShipmentRate());
				//			engine.setFieldValue("estimLaborRate", getEstimLaborRate());
				//
				//			engine.setFieldValue("estimAssemblyRate", getEstimAssemblyRate());
				//			engine.setFieldValue("estimConsumableRate", getEstimConsumableRate());
				//			engine.setFieldValue("estimEquipmentRate", getEstimEquipmentRate());
				engine.setFieldValue("accuracy", Accuracy);

			}
			else if (hasQuoted && hasEstimated)
			{
				Accuracy = s_BOTH_ACCURACY;
				engine.setFieldValue("accuracy", Accuracy);
			}
			else if (hasQuoted && !hasEstimated)
			{
				Accuracy = s_QUOTED_ACCURACY;
				engine.setFieldValue("accuracy", Accuracy);
			}
			else
			{
				Accuracy = s_ESTIMATED_ACCURACY;
				engine.setFieldValue("accuracy", Accuracy);
			}

			//		setQuotedMaterialRate(quotMaterialRate);
			//		setQuotedSubcontractorRate(quotSubcontractorRate);

			//		engine.setFieldValue("quotedMaterialRate", getQuotedMaterialRate());
			//		engine.setFieldValue("quotedSubcontractorRate", getQuotedSubcontractorRate());

			//		setEstimMaterialTotalCost(calculateEstimMaterialTotalCost());
			//		setEstimSubcontractorTotalCost(calculateEstimSubcontractorTotalCost());				
			//		setEstimFabricationTotalCost(calculateEstimFabricationTotalCost());
			//		setEstimShipmentTotalCost(calculateEstimShipmentTotalCost());			
			//		setEstimLaborTotalCost(calculateEstimLaborTotalCost());
			//		setEstimAssemblyTotalCost(calculateEstimAssemblyTotalCost());
			//		setEstimConsumableTotalCost(calculateEstimConsumableTotalCost());
			//		setEstimEquipmentTotalCost(calculateEstimEquipmentTotalCost());
			//		setQuotedMaterialTotalCost(calculateQuotedMaterialTotalCost());
			//		setQuotedSubcontractorTotalCost(calculateQuotedSubcontractorTotalCost());
			//		setEstimTotalCost(calculateEstimTotalCost());		

			//		engine.setFieldValue("estimMaterialTotalCost", getEstimMaterialTotalCost());
			//		engine.setFieldValue("estimSubcontractorTotalCost", getEstimSubcontractorTotalCost());
			//		engine.setFieldValue("estimFabricationTotalCost", getEstimFabricationTotalCost());
			//		engine.setFieldValue("estimShipmentTotalCost", getEstimShipmentTotalCost());
			//		engine.setFieldValue("estimLaborTotalCost", getEstimLaborTotalCost());
			//		engine.setFieldValue("estimConsumableTotalCost", getEstimConsumableTotalCost());
			//		engine.setFieldValue("estimEquipmentTotalCost", getEstimEquipmentTotalCost());
			//		engine.setFieldValue("quotedMaterialTotalCost", getQuotedMaterialTotalCost());
			//		engine.setFieldValue("quotedSubcontractorTotalCost", getQuotedSubcontractorTotalCost());
			//		engine.setFieldValue("estimTotalCost", getEstimTotalCost());

			CalculatedRate = Rate;

			if (Quantity != null)
			{
				CalculatedTotalCost = CalculatedRate * Quantity;
			}

			if (Rate.CompareTo(BigDecimalMath.ZERO) <= 0 && Quantity.CompareTo(BigDecimalMath.ZERO) <= 0)
			{
				Status = s_PENDING_STATUS;
				engine.setFieldValue("status", Status);
			}
			else
			{ // if ( getStatus().equals(s_PENDING_STATUS) ) {
				Status = s_UNDERREVIEW_STATUS;
				engine.setFieldValue("status", Status);
			}
			if (Status.Equals(s_UNDERREVIEW_STATUS) && TotalCost.CompareTo(BigDecimalMath.ZERO) > 0)
			{
				Status = s_COMPLETED_STATUS;
				//System.out.println("Completed because: "+getTotalCost());
				engine.setFieldValue("status", Status);
			}

			bool hasMaterialQuotes = hasPendingMaterialQuotes || hasReceivedMaterialQuotes;
			bool hasSubcontractorQuotes = hasPendingSubcontractorQuotes || hasReceivedSubcontractorQuotes;

			// Setup new status for quoted only:
			if (hasQuoted)
			{
				if (hasMaterialQuotes && hasSubcontractorQuotes)
				{
					if (isASubcontractorQuoted && isAMaterialQuoted && !hasPendingSubcontractorQuotes && !hasPendingMaterialQuotes)
					{
						Status = s_APPROVED_STATUS;
					}
					else if (isASubcontractorQuoted && isAMaterialQuoted && hasPendingSubcontractorQuotes && !hasPendingMaterialQuotes)
					{
						Status = s_COMPLETED_STATUS;
					}
					else if (isASubcontractorQuoted && isAMaterialQuoted && !hasPendingSubcontractorQuotes && hasPendingMaterialQuotes)
					{
						Status = s_COMPLETED_STATUS;
					}
					engine.setFieldValue("status", Status);

					//else 
					//setStatus(s_UNDERREVIEW_STATUS);										
					//				else if ( isASubcontractorQuoted && !isAMaterialQuoted && hasMaterialQuotes ) 
					//					setStatus(s_UNDERREVIEW_STATUS);					
					//				else if ( !isASubcontractorQuoted && isAMaterialQuoted && hasSubcontractorQuotes ) 
					//					setStatus(s_UNDERREVIEW_STATUS);					

				}
				else if (hasSubcontractorQuotes)
				{
					if (isASubcontractorQuoted && !hasPendingSubcontractorQuotes)
					{
						Status = s_APPROVED_STATUS;
					}
					else if (isASubcontractorQuoted && hasPendingSubcontractorQuotes)
					{
						Status = s_COMPLETED_STATUS;
					}
					//else
					//setStatus(s_UNDERREVIEW_STATUS);								
					engine.setFieldValue("status", Status);
				}
				else if (hasMaterialQuotes)
				{
					if (isAMaterialQuoted && !hasPendingMaterialQuotes)
					{
						Status = s_APPROVED_STATUS;
					}
					else if (isAMaterialQuoted && hasPendingMaterialQuotes)
					{
						Status = s_COMPLETED_STATUS;
					}
					//else
					//setStatus(s_UNDERREVIEW_STATUS);			
					engine.setFieldValue("status", Status);
				}
				else
				{
					// leave as is quoted came from database as quoted
				}
			}
			//		else if ( hasReceivedMaterialQuotes || hasReceivedSubcontractorQuotes || hasPendingMaterialQuotes || hasPendingSubcontractorQuotes ) {
			//			if ( getTotalCost().compareTo(BigDecimalMath.ZERO) <= 0 )
			//				setStatus(s_PENDING_STATUS);
			//			else
			//				setStatus(s_UNDERREVIEW_STATUS);											
			//		}
		}

		private sbyte? calculateRateType(ResourceTable resTable, sbyte? curType)
		{

			sbyte? assignmentType = null;
			if (resTable.Conceptual != null && resTable.Conceptual.Equals(true))
			{
				assignmentType = RATE_TYPE_CONCEPTUAL;
			}
			else if (resTable.Virtual != null && resTable.Virtual.Equals(true))
			{
				assignmentType = RATE_TYPE_VIRTUAL;
			}
			else if (resTable.Predicted != null && resTable.Predicted.Equals(true))
			{
				assignmentType = RATE_TYPE_TREND;
			}
			else if (resTable.Quoted != null && resTable.Quoted.Equals(true))
			{
				assignmentType = RATE_TYPE_QUOTED;
			}
			else if (resTable.DatabaseCreationDate != null)
			{
				if (resTable.DatabaseCreationDate.Equals(ONLINE_DB_CREATE_DATE))
				{
					assignmentType = RATE_TYPE_ONLINE;
				}
				else if (resTable.DatabaseCreationDate.Equals(MISSING_DB_CREATE_DATE))
				{
					if (resTable.OverrideType.Equals(ResourceTable.OT_OSTRAKON))
					{
						assignmentType = RATE_TYPE_OSTRAKON;
					}
					else
					{
						assignmentType = RATE_TYPE_EMPTY;
					}
				}
				else if (!resTable.DatabaseCreationDate.Equals(MISSING_DB_CREATE_DATE))
				{
					if (resTable.OverrideType != null && resTable.OverrideType.Equals(ResourceTable.OT_PROJECT_OVERRIDEN))
					{
						assignmentType = RATE_TYPE_PROJECT;
					}
					else if (resTable.OverrideType != null && resTable.OverrideType.Equals(ResourceTable.OT_DATABASE_OVERRIDEN))
					{
						assignmentType = RATE_TYPE_OVERRIDEN;
					}
					else
					{
						assignmentType = RATE_TYPE_LOCAL;
					}
				}
				else
				{ // That is a rate typed by the user on new user assignment!
					assignmentType = RATE_TYPE_VIRTUAL;
				}
			}
			else
			{
				return curType;
			}

			//System.out.println("Current Type: "+curType+", assignment type: "+assignmentType);

			if (assignmentType.Equals(RATE_TYPE_OSTRAKON))
			{
				return RATE_TYPE_OSTRAKON;
			}

			if (curType.Equals(RATE_TYPE_VIRTUAL) || assignmentType.Equals(RATE_TYPE_VIRTUAL)) // Always wins!
			{
				return RATE_TYPE_VIRTUAL;
			}
			else if (curType.Equals(RATE_TYPE_CONCEPTUAL) || assignmentType.Equals(RATE_TYPE_CONCEPTUAL)) // Conceptual wins all except virtual etc
			{
				return RATE_TYPE_CONCEPTUAL;
			}
			else if (curType.Equals(RATE_TYPE_TREND) || assignmentType.Equals(RATE_TYPE_TREND))
			{
				return RATE_TYPE_TREND;
			}
			else if (curType.Equals(RATE_TYPE_PROJECT) || assignmentType.Equals(RATE_TYPE_PROJECT))
			{
				return RATE_TYPE_PROJECT;
			}
			else if (curType.Equals(RATE_TYPE_OVERRIDEN) || assignmentType.Equals(RATE_TYPE_OVERRIDEN))
			{
				return RATE_TYPE_OVERRIDEN;
			}
			else if (curType.Equals(RATE_TYPE_ONLINE) || assignmentType.Equals(RATE_TYPE_ONLINE))
			{
				return RATE_TYPE_ONLINE;
			}
			else if (curType.Equals(RATE_TYPE_LOCAL) || assignmentType.Equals(RATE_TYPE_LOCAL))
			{
				return RATE_TYPE_LOCAL;
			}
			else if (curType.Equals(RATE_TYPE_QUOTED) || assignmentType.Equals(RATE_TYPE_QUOTED))
			{
				return RATE_TYPE_QUOTED;
			}

			return curType; // Should never happen

			//		if ( resTable.getConceptual() != null && resTable.getConceptual().equals(Boolean.TRUE) && curType > RATE_TYPE_CONCEPTUAL ) {
			//			return RATE_TYPE_CONCEPTUAL;
			//		}
			//		if ( resTable.getVirtual() != null && resTable.getVirtual().equals(Boolean.TRUE) && curType > RATE_TYPE_VIRTUAL ) {
			//			return RATE_TYPE_VIRTUAL;
			//		}
			//		if ( resTable.getPredicted() != null && resTable.getPredicted().equals(Boolean.TRUE) && curType > RATE_TYPE_TREND ) {
			//			return RATE_TYPE_TREND;
			//		}
			//		if ( resTable.getDatabaseCreationDate() != null ) {
			//			if ( resTable.getDatabaseCreationDate().longValue() == ONLINE_DB_CREATE_DATE && curType > RATE_TYPE_ONLINE )
			//				return RATE_TYPE_ONLINE;
			//			else if ( resTable.getDatabaseCreationDate().longValue() != MISSING_DB_CREATE_DATE && curType > RATE_TYPE_LOCAL )
			//				return RATE_TYPE_LOCAL;
			//		}
			//		if ( resTable.getQuoted() != null && resTable.getQuoted().equals(Boolean.TRUE) && curType > RATE_TYPE_QUOTED ) {
			//			return RATE_TYPE_QUOTED;
			//		}
			//
			//		return curType;
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (BoqItemTable) value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (BoqItemTable) databaseTable);
		}

		public override string Project
		{
			set
			{
    
			}
			get
			{
				return null;
			}
		}


		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return null; // no to assemblies
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				return null;
			}
		}

		public override ISet<object> getResourceAssignments(string resourceName)
		{

			if (!string.ReferenceEquals(resourceName, null))
			{
				if (resourceName.Equals(LayoutTable.MATERIAL))
				{
					return BoqItemMaterialSet;
				}
				else if (resourceName.Equals(LayoutTable.LABOR))
				{
					return BoqItemLaborSet;
				}
				else if (resourceName.Equals(LayoutTable.SUBCONTRACTOR))
				{
					return BoqItemSubcontractorSet;
				}
				else if (resourceName.Equals(LayoutTable.EQUIPMENT))
				{
					return BoqItemEquipmentSet;
				}
				else if (resourceName.Equals(LayoutTable.CONSUMABLE))
				{
					return BoqItemConsumableSet;
				}
				else if (resourceName.Equals(LayoutTable.ASSEMBLY))
				{
					return BoqItemAssemblySet;
				}
				else if (resourceName.Equals(LayoutTable.CONDITION))
				{
					return BoqItemConditionSet;
				}
				else if (resourceName.Equals(LayoutTable.QUOTATION))
				{
					return QuoteItemSet;
				}
				else if (resourceName.Equals(LayoutTable.WORKITEM))
				{
					return QuoteItemSet;
				}
				else if (resourceName.Equals(LayoutTable.PARAMITEM))
				{
					return ParamItemSet;
				}
			}
			ISet<object> set = new HashSet<object>();
			if (BoqItemMaterialSet != null)
			{
				set.addAll(BoqItemMaterialSet);
			}
			if (BoqItemLaborSet != null)
			{
				set.addAll(BoqItemLaborSet);
			}
			if (BoqItemSubcontractorSet != null)
			{
				set.addAll(BoqItemSubcontractorSet);
			}
			if (BoqItemEquipmentSet != null)
			{
				set.addAll(BoqItemEquipmentSet);
			}
			if (BoqItemAssemblySet != null)
			{
				set.addAll(BoqItemAssemblySet);
			}
			if (BoqItemConditionSet != null)
			{
				set.addAll(BoqItemConditionSet);
			}
			if (BoqItemConsumableSet != null)
			{
				set.addAll(BoqItemConsumableSet);
			}
			if (QuoteItemSet != null)
			{
				set.addAll(QuoteItemSet);
			}

			return set;
		}

		public override System.Collections.IList ResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new LinkedList();
    
				if (BoqItemAssemblySet != null)
				{
					set.AddRange(BoqItemAssemblySet);
				}
				if (BoqItemEquipmentSet != null)
				{
					set.AddRange(BoqItemEquipmentSet);
				}
				if (BoqItemSubcontractorSet != null)
				{
					set.AddRange(BoqItemSubcontractorSet);
				}
				if (BoqItemLaborSet != null)
				{
					set.AddRange(BoqItemLaborSet);
				}
				if (BoqItemMaterialSet != null)
				{
					set.AddRange(BoqItemMaterialSet);
				}
				if (BoqItemConsumableSet != null)
				{
					set.AddRange(BoqItemConsumableSet);
				}
    
				return set;
			}
		}

		public virtual System.Collections.IList OrderedResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new LinkedList();
    
				if (BoqItemAssemblySet != null)
				{
					set.AddRange(orderedList(BoqItemAssemblySet));
				}
				if (BoqItemEquipmentSet != null)
				{
					set.AddRange(orderedList(BoqItemEquipmentSet));
				}
				if (BoqItemSubcontractorSet != null)
				{
					set.AddRange(orderedList(BoqItemSubcontractorSet));
				}
				if (BoqItemLaborSet != null)
				{
					set.AddRange(orderedList(BoqItemLaborSet));
				}
				if (BoqItemMaterialSet != null)
				{
					set.AddRange(orderedList(BoqItemMaterialSet));
				}
				if (BoqItemConsumableSet != null)
				{
					set.AddRange(orderedList(BoqItemConsumableSet));
				}
    
				return set;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient public System.Nullable<bool> getVirtual()
		public override bool? Virtual
		{
			get
			{
				return false;
			}
		}

		public override bool? Predicted
		{
			get
			{
				return false;
			}
		}

		public override string ItemCode
		{
			get
			{
				return PublishedItemCode;
			}
			set
			{
				PublishedItemCode = value;
			}
		}


		private long? projectId;

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}


	}
}