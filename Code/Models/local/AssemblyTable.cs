using System;
using System.Collections.Generic;

namespace Models.local
{


	using ObjectNotFoundException = org.hibernate.ObjectNotFoundException;
	using Session = org.hibernate.Session;
	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using LayoutTable = nomitech.common.db.layout.LayoutTable;
	using BoqItemAssemblyTable = nomitech.common.db.project.BoqItemAssemblyTable;
	using BoqItemConsumableTable = nomitech.common.db.project.BoqItemConsumableTable;
	using BoqItemEquipmentTable = nomitech.common.db.project.BoqItemEquipmentTable;
	using BoqItemLaborTable = nomitech.common.db.project.BoqItemLaborTable;
	using BoqItemMaterialTable = nomitech.common.db.project.BoqItemMaterialTable;
	using BoqItemSubcontractorTable = nomitech.common.db.project.BoqItemSubcontractorTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using MaterialHistoryTable = nomitech.common.db.project.MaterialHistoryTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = nomitech.common.util.ExchangeRateUtil;
	using ImperialToMetric = nomitech.common.util.ImperialToMetric;
	using Unit1ToUnit2Util = nomitech.common.util.Unit1ToUnit2Util;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="ASSEMBLY" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class AssemblyTable extends nomitech.common.base.ResourceWithAssignmentsTable implements nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class AssemblyTable : ResourceWithAssignmentsTable, ProjectIdEntity, Transferable
	{

		private static long? _dbCreationDate = null;

		private static long CachedDBCreationDate
		{
			get
			{
				if (_dbCreationDate == null)
				{
					_dbCreationDate = DatabaseDBUtil.Properties.getLongProperty("database.creationdate");
				}
				return _dbCreationDate.Value;
			}
		}

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

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"assemblyId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "equipmentRate", "subcontractorRate", "laborRate", "materialRate", "consumableRate", "rate", "currency", "productivity", "unitManhours", "unitEquipmentHours", "accuracy", "activityBased", "project", "publishedRate", "publishedRevisionCode", "bimType", "bimMaterial", "notes", "description", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "puGroupCodeFactor", "puGekCodeFactor", "puExtraCode1Factor", "puExtraCode2Factor", "puExtraCode3Factor", "puExtraCode4Factor", "puExtraCode5Factor", "puExtraCode6Factor", "puExtraCode7Factor", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(Boolean), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> assemblyId;
		private long? assemblyId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal productivity;
		private decimal productivity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode;
		private string groupCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode;
		private string gekCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String project;
		private string project;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency;
		private string currency;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince;
		private string stateProvince;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country;
		private string country;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal publishedRate;
		private decimal publishedRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rate;
		private decimal rate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String publishedRevisionCode;
		private string publishedRevisionCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimType;
		private string bimType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimMaterial;
		private string bimMaterial;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal laborRate;
		private decimal laborRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal materialRate;
		private decimal materialRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal subcontractorRate;
		private decimal subcontractorRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal consumableRate;
		private decimal consumableRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal equipmentRate;
		private decimal equipmentRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitManhours;
		private decimal unitManhours;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitEquipmentHours;
		private decimal unitEquipmentHours;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantity;
		private decimal quantity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String accuracy;
		private string accuracy;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date createDate;
		private DateTime createDate;

		private bool? virtualEquipment;
		private bool? virtualSubcontractor;
		private bool? virtualLabor;
		private bool? virtualMaterial;
		private bool? virtualConsumable;
		private int? overrideType;

		private bool? activityBased;

		private string accessRights;
		private string keywords;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String itemCode;
		private string itemCode;

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

		// Custom Variables:
		private string vars;

		//	public Set<AssemblyConsumableTable> getConsumableSet() {
		//		return consumableSet;
		//	}
		//
		//	public void setConsumableSet(Set<AssemblyConsumableTable> consumableSet) {
		//		this.consumableSet = consumableSet;
		//	}

		private ISet<AssemblyLaborTable> assemblyLaborSet = new HashSet<object>();
		private ISet<AssemblyAssemblyTable> assemblyChildSet = new HashSet<object>();
		private ISet<AssemblyAssemblyTable> assemblyParentSet = new HashSet<object>();
		private ISet<AssemblyEquipmentTable> assemblyEquipmentSet = new HashSet<object>();
		private ISet<AssemblyMaterialTable> assemblyMaterialSet = new HashSet<object>();
		private ISet<AssemblyConsumableTable> assemblyConsumableSet = new HashSet<object>();
		private ISet<AssemblySubcontractorTable> assemblySubcontractorSet = new HashSet<object>();
		private ISet<MaterialHistoryTable> assemblyHistorySet;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode1;
		private string extraCode1;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode2;
		private string extraCode2;
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

		private bool? @virtual;

		private decimal puGroupCodeFactor;
		private decimal puGekCodeFactor;
		private decimal puExtraCode1Factor;
		private decimal puExtraCode2Factor;
		private decimal puExtraCode3Factor;
		private decimal puExtraCode4Factor;
		private decimal puExtraCode5Factor;
		private decimal puExtraCode6Factor;
		private decimal puExtraCode7Factor;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.assemblyDataFlavor};

		[NonSerialized]
		private ISet<object> boqItemAssemblySet;

		public AssemblyTable()
		{
		}

		public virtual object valueForField(string field)
		{
			return null;
		}

		// TO PRINTABLE FORMAT:
		public virtual object scaledValueForField(string field)
		{
			return null;
		}

		public virtual object clone()
		{
			AssemblyTable obj = new AssemblyTable();

			obj.AssemblyId = AssemblyId;
			obj.LastUpdate = LastUpdate;
			obj.Virtual = Virtual;
			obj.VirtualEquipment = VirtualEquipment;
			obj.VirtualSubcontractor = VirtualSubcontractor;
			obj.VirtualLabor = VirtualLabor;
			obj.VirtualMaterial = VirtualMaterial;
			obj.VirtualConsumable = VirtualConsumable;
			obj.OverrideType = OverrideType;
			obj.Description = Description;
			obj.ActivityBased = ActivityBased;
			obj.Project = Project;
			obj.StateProvince = StateProvince;
			obj.Country = Country;
			obj.Unit = Unit;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Productivity = Productivity;
			obj.UnitManhours = UnitManhours;
			obj.UnitEquipmentHours = UnitEquipmentHours;
			obj.PublishedRate = PublishedRate;
			obj.ItemCode = ItemCode;
			obj.PublishedRevisionCode = PublishedRevisionCode;
			obj.Title = Title;
			obj.Notes = Notes;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.Currency = Currency;
			obj.EditorId = EditorId;
			obj.AccessRights = AccessRights;
			obj.Rate = Rate;

			obj.MaterialRate = MaterialRate;
			obj.ConsumableRate = ConsumableRate;
			obj.LaborRate = LaborRate;
			obj.SubcontractorRate = SubcontractorRate;
			obj.EquipmentRate = EquipmentRate;

			obj.Accuracy = Accuracy;
			obj.Quantity = Quantity;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;

			obj.BimMaterial = BimMaterial;
			obj.BimType = BimType;

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
			obj.CustomText21 = CustomText21;
			obj.CustomText22 = CustomText22;
			obj.CustomText23 = CustomText23;
			obj.CustomText24 = CustomText24;
			obj.CustomText25 = CustomText25;

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

			obj.Vars = Vars;

			obj.ProjectId = ProjectId;

			return obj;
		}

		// For online databases only:
		public virtual object conversionClone(bool metric, bool demo)
		{
			AssemblyTable obj = (AssemblyTable) clone();
			if (metric)
			{ // make a recalculation here:
				obj.Productivity = ImperialToMetric.getInverseRate(unit, productivity);
				obj.UnitManhours = ImperialToMetric.getRate(unit, unitManhours);
				obj.UnitEquipmentHours = ImperialToMetric.getRate(unit, unitEquipmentHours);
				obj.Quantity = ImperialToMetric.getRate(unit, quantity);
				obj.PublishedRate = ImperialToMetric.getRate(unit, publishedRate);
				obj.Rate = ImperialToMetric.getRate(unit, rate);
				obj.LaborRate = ImperialToMetric.getRate(unit, laborRate);
				obj.MaterialRate = ImperialToMetric.getRate(unit, materialRate);
				obj.EquipmentRate = ImperialToMetric.getRate(unit, equipmentRate);
				obj.SubcontractorRate = ImperialToMetric.getRate(unit, subcontractorRate);
				obj.ConsumableRate = ImperialToMetric.getRate(unit, consumableRate);
				obj.Unit = ImperialToMetric.getUnit(unit);
			}
			if (demo)
			{
				obj.Rate = BigDecimalMath.ZERO;
				obj.LaborRate = BigDecimalMath.ZERO;
				obj.EquipmentRate = BigDecimalMath.ZERO;
				obj.MaterialRate = BigDecimalMath.ZERO;
				obj.EquipmentRate = BigDecimalMath.ZERO;
				obj.ConsumableRate = BigDecimalMath.ZERO;
				obj.Quantity = BigDecimalMath.ZERO;
				obj.PublishedRate = BigDecimalMath.ZERO;
				obj.Productivity = BigDecimalMath.ONE;
				obj.UnitManhours = BigDecimalMath.ONE;
				obj.UnitEquipmentHours = BigDecimalMath.ONE;
				obj.Quantity = BigDecimalMath.ZERO;
			}
			return obj;
		}

		public virtual void setData(AssemblyTable table, bool rateAlso)
		{
			//setAssemblyId(table.getAssemblyId());
			LastUpdate = table.LastUpdate;
			Virtual = table.Virtual;
			VirtualEquipment = table.VirtualEquipment;
			VirtualSubcontractor = table.VirtualSubcontractor;
			VirtualLabor = table.VirtualLabor;
			VirtualMaterial = table.VirtualMaterial;
			VirtualConsumable = table.VirtualConsumable;
			OverrideType = table.OverrideType;
			Description = table.Description;
			ActivityBased = table.ActivityBased;
			Unit = table.Unit;
			GroupCode = table.GroupCode;
			GekCode = table.GekCode;
			Project = table.Project;
			StateProvince = table.StateProvince;
			Country = table.Country;
			Productivity = table.Productivity;
			UnitManhours = table.UnitManhours;
			UnitEquipmentHours = table.UnitEquipmentHours;
			PublishedRate = table.PublishedRate;
			PublishedRevisionCode = table.PublishedRevisionCode;
			ItemCode = table.ItemCode;
			Title = table.Title;
			Notes = table.Notes;
			EditorId = table.EditorId;
			Currency = table.Currency;
			Quantity = table.Quantity;
			AccessRights = table.AccessRights;

			BimMaterial = table.BimMaterial;
			BimType = table.BimType;
			//setDatabaseId(table.getDatabaseId());
			//setDatabaseCreationDate(table.getDatabaseCreationDate());		
			ExtraCode1 = table.ExtraCode1;
			ExtraCode2 = table.ExtraCode2;
			ExtraCode3 = table.ExtraCode3;
			ExtraCode4 = table.ExtraCode4;
			ExtraCode5 = table.ExtraCode5;
			ExtraCode6 = table.ExtraCode6;
			ExtraCode7 = table.ExtraCode7;
			ExtraCode8 = table.ExtraCode8;
			ExtraCode9 = table.ExtraCode9;
			ExtraCode10 = table.ExtraCode10;

			PuGroupCodeFactor = table.PuGroupCodeFactor;
			PuGekCodeFactor = table.PuGekCodeFactor;
			PuExtraCode1Factor = table.PuExtraCode1Factor;
			PuExtraCode2Factor = table.PuExtraCode2Factor;
			PuExtraCode3Factor = table.PuExtraCode3Factor;
			PuExtraCode4Factor = table.PuExtraCode4Factor;
			PuExtraCode5Factor = table.PuExtraCode5Factor;
			PuExtraCode6Factor = table.PuExtraCode6Factor;
			PuExtraCode7Factor = table.PuExtraCode7Factor;

			CustomText1 = table.CustomText1;
			CustomText2 = table.CustomText2;
			CustomText3 = table.CustomText3;
			CustomText4 = table.CustomText4;
			CustomText5 = table.CustomText5;
			CustomText6 = table.CustomText6;
			CustomText7 = table.CustomText7;
			CustomText8 = table.CustomText8;
			CustomText9 = table.CustomText9;
			CustomText10 = table.CustomText10;
			CustomText11 = table.CustomText11;
			CustomText12 = table.CustomText12;
			CustomText13 = table.CustomText13;
			CustomText14 = table.CustomText14;
			CustomText15 = table.CustomText15;
			CustomText16 = table.CustomText16;
			CustomText17 = table.CustomText17;
			CustomText18 = table.CustomText18;
			CustomText19 = table.CustomText19;
			CustomText20 = table.CustomText20;
			CustomText21 = table.CustomText21;
			CustomText22 = table.CustomText22;
			CustomText23 = table.CustomText23;
			CustomText24 = table.CustomText24;
			CustomText25 = table.CustomText25;

			CustomRate1 = table.CustomRate1;
			CustomRate2 = table.CustomRate2;
			CustomRate3 = table.CustomRate3;
			CustomRate4 = table.CustomRate4;
			CustomRate5 = table.CustomRate5;
			CustomRate6 = table.CustomRate6;
			CustomRate7 = table.CustomRate7;
			CustomRate8 = table.CustomRate8;
			CustomRate9 = table.CustomRate9;
			CustomRate10 = table.CustomRate10;
			CustomRate11 = table.CustomRate11;
			CustomRate12 = table.CustomRate12;
			CustomRate13 = table.CustomRate13;
			CustomRate14 = table.CustomRate14;
			CustomRate15 = table.CustomRate15;
			CustomRate16 = table.CustomRate16;
			CustomRate17 = table.CustomRate17;
			CustomRate18 = table.CustomRate18;
			CustomRate19 = table.CustomRate19;
			CustomRate20 = table.CustomRate20;

			if (rateAlso)
			{
				Rate = table.Rate;
				MaterialRate = table.MaterialRate;
				SubcontractorRate = table.SubcontractorRate;
				EquipmentRate = table.EquipmentRate;
				LaborRate = table.LaborRate;
				ConsumableRate = table.ConsumableRate;
			}

			// Fields stored that are not editable:
			if (table.CreateDate != null)
			{
				CreateDate = table.CreateDate;
				CreateUserId = table.CreateUserId;
			}

			if (!string.ReferenceEquals(table.Accuracy, null))
			{
				Accuracy = table.Accuracy;
			}

			Vars = table.Vars;
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, AssemblyTable data)
		{

		}

		public virtual object deepCopy()
		{
			return deepCopy(false);
		}

		public virtual object deepCopy(bool removeIds, bool copyHistory)
		{
			return deepCopy(removeIds);
		}

		public virtual object deepCopy(bool removeIds)
		{ // removeIds to make new resource only in resource database not projectdb
			AssemblyTable obj = (AssemblyTable) clone();

			if (AssemblyChildSet != null)
			{
				obj.assemblyChildSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable cur = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable table = (AssemblyAssemblyTable) cur.clone(false, false);
					AssemblyTable childTable = (AssemblyTable) cur.ChildTable.deepCopy(removeIds);
					if (removeIds)
					{
						childTable.AssemblyId = null;
						childTable.DatabaseCreationDate = null;
						childTable.DatabaseId = null;
						childTable.BuildUpRate = null;
					}
					table.ChildTable = childTable;
					obj.assemblyChildSet.Add(table);
				}
				obj.AssemblyChildSet = obj.assemblyChildSet;
			}

			if (AssemblyLaborSet != null)
			{
				obj.assemblyLaborSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable cur = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable table = (AssemblyLaborTable) cur.clone(false, false);
					LaborTable laborTable = (LaborTable) cur.LaborTable.clone();
					if (removeIds)
					{
						laborTable.LaborId = null;
						laborTable.DatabaseCreationDate = null;
						laborTable.DatabaseId = null;
						laborTable.BuildUpRate = null;
					}
					table.LaborTable = laborTable;
					obj.assemblyLaborSet.Add(table);
				}
				obj.AssemblyLaborSet = obj.assemblyLaborSet;
			}

			if (AssemblyConsumableSet != null)
			{
				obj.assemblyConsumableSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable cur = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable table = (AssemblyConsumableTable) cur.clone(false);
					ConsumableTable consumableTable = (ConsumableTable) cur.ConsumableTable.clone();
					if (removeIds)
					{
						consumableTable.ConsumableId = null;
						consumableTable.DatabaseCreationDate = null;
						consumableTable.DatabaseId = null;
					}
					table.ConsumableTable = consumableTable;
					obj.assemblyConsumableSet.Add(table);
				}
				obj.AssemblyConsumableSet = obj.assemblyConsumableSet;
			}

			if (AssemblySubcontractorSet != null)
			{

				obj.assemblySubcontractorSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable cur = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable table = (AssemblySubcontractorTable) cur.clone(false);
					SubcontractorTable subcontractorTable = (SubcontractorTable) cur.SubcontractorTable.clone();
					if (removeIds)
					{
						subcontractorTable.SubcontractorId = null;
						subcontractorTable.DatabaseCreationDate = null;
						subcontractorTable.DatabaseId = null;
						subcontractorTable.BuildUpRate = null;
					}
					table.SubcontractorTable = subcontractorTable;
					obj.assemblySubcontractorSet.Add(table);
				}
				obj.AssemblySubcontractorSet = obj.assemblySubcontractorSet;
			}

			if (AssemblyEquipmentSet != null)
			{

				obj.assemblyEquipmentSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable cur = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable table = (AssemblyEquipmentTable) cur.clone(false);
					EquipmentTable equipmentTable = (EquipmentTable) cur.EquipmentTable.clone();
					if (removeIds)
					{
						equipmentTable.EquipmentId = null;
						equipmentTable.DatabaseCreationDate = null;
						equipmentTable.DatabaseId = null;
						equipmentTable.BuildUpRate = null;
					}
					table.EquipmentTable = equipmentTable;
					obj.assemblyEquipmentSet.Add(table);
				}
				obj.AssemblyEquipmentSet = obj.assemblyEquipmentSet;
			}

			if (AssemblyMaterialSet != null)
			{

				obj.assemblyMaterialSet = new HashSet<object>();
				System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable cur = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable table = (AssemblyMaterialTable) cur.clone(false);
					MaterialTable materialTable = null;
					if (removeIds)
					{
						materialTable = (MaterialTable) cur.MaterialTable.clone();
						materialTable.MaterialId = null;
						materialTable.DatabaseCreationDate = null;
						materialTable.DatabaseId = null;
						materialTable.BuildUpRate = null;
					}
					else
					{
						materialTable = (MaterialTable) cur.MaterialTable.copyWithSupplier();
					}
					table.MaterialTable = materialTable;
					obj.assemblyMaterialSet.Add(table);
				}
				obj.AssemblyMaterialSet = obj.assemblyMaterialSet;
			}

			return obj;
		}

		public virtual AssemblyTable deepRoundCopy()
		{ // to allow recalculation!
			bool removeIds = false;

			AssemblyTable obj = (AssemblyTable) clone();

			if (AssemblyChildSet != null)
			{
				obj.assemblyChildSet = new HashSet<object>(2);
				System.Collections.IEnumerator iter = AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable cur = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable table = (AssemblyAssemblyTable) cur.clone(false, false);
					AssemblyTable assemblyTable = (AssemblyTable) cur.ChildTable.deepRoundCopy();
					if (removeIds)
					{
						assemblyTable.AssemblyId = null;
						assemblyTable.DatabaseCreationDate = null;
						assemblyTable.DatabaseId = null;
					}
					table.ChildTable = assemblyTable;
					table.ParentTable = obj;
					obj.assemblyChildSet.Add(table);
					//assemblyTable.assemblyParentSet.add(table);
				}
				obj.AssemblyChildSet = obj.assemblyChildSet;
			}

			if (AssemblyLaborSet != null)
			{
				obj.assemblyLaborSet = new HashSet<object>(5);
				System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable cur = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable table = (AssemblyLaborTable) cur.clone(false, false);
					LaborTable laborTable = (LaborTable) cur.LaborTable.clone();
					if (removeIds)
					{
						laborTable.LaborId = null;
						laborTable.DatabaseCreationDate = null;
						laborTable.DatabaseId = null;
						laborTable.BuildUpRate = null;
					}
					table.LaborTable = laborTable;
					table.AssemblyTable = obj;
					obj.assemblyLaborSet.Add(table);
				}
				obj.AssemblyLaborSet = obj.assemblyLaborSet;
			}

			if (AssemblyConsumableSet != null)
			{

				obj.assemblyConsumableSet = new HashSet<object>(5);
				System.Collections.IEnumerator iter = AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable cur = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable table = (AssemblyConsumableTable) cur.clone(false);
					ConsumableTable consumableTable = (ConsumableTable) cur.ConsumableTable.clone();
					if (removeIds)
					{
						consumableTable.ConsumableId = null;
						consumableTable.DatabaseCreationDate = null;
						consumableTable.DatabaseId = null;
						consumableTable.BuildUpRate = null;
					}
					table.ConsumableTable = consumableTable;
					table.AssemblyTable = this;
					obj.assemblyConsumableSet.Add(table);
				}
				obj.AssemblyConsumableSet = obj.assemblyConsumableSet;
			}

			if (AssemblySubcontractorSet != null)
			{

				obj.assemblySubcontractorSet = new HashSet<object>(5);
				System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable cur = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable table = (AssemblySubcontractorTable) cur.clone(false);
					SubcontractorTable subcontractorTable = (SubcontractorTable) cur.SubcontractorTable.clone();
					if (removeIds)
					{
						subcontractorTable.SubcontractorId = null;
						subcontractorTable.DatabaseCreationDate = null;
						subcontractorTable.DatabaseId = null;
						subcontractorTable.BuildUpRate = null;
					}
					table.SubcontractorTable = subcontractorTable;
					table.AssemblyTable = obj;
					obj.assemblySubcontractorSet.Add(table);
				}
				obj.AssemblySubcontractorSet = obj.assemblySubcontractorSet;
			}

			if (AssemblyEquipmentSet != null)
			{

				obj.assemblyEquipmentSet = new HashSet<object>(5);
				System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable cur = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable table = (AssemblyEquipmentTable) cur.clone(false);
					EquipmentTable equipmentTable = (EquipmentTable) cur.EquipmentTable.clone();
					if (removeIds)
					{
						equipmentTable.EquipmentId = null;
						equipmentTable.DatabaseCreationDate = null;
						equipmentTable.DatabaseId = null;
						equipmentTable.BuildUpRate = null;
					}
					table.EquipmentTable = equipmentTable;
					table.AssemblyTable = obj;
					obj.assemblyEquipmentSet.Add(table);
				}
				obj.AssemblyEquipmentSet = obj.assemblyEquipmentSet;
			}

			if (AssemblyMaterialSet != null)
			{

				obj.assemblyMaterialSet = new HashSet<object>(5);
				System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable cur = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable table = (AssemblyMaterialTable) cur.clone(false);
					MaterialTable materialTable = null;
					if (removeIds)
					{
						materialTable = (MaterialTable) cur.MaterialTable.clone();
						materialTable.MaterialId = null;
						materialTable.DatabaseCreationDate = null;
						materialTable.DatabaseId = null;
						materialTable.BuildUpRate = null;
					}
					else
					{
						materialTable = (MaterialTable) cur.MaterialTable.copyWithSupplier();
					}
					table.MaterialTable = materialTable;
					table.AssemblyTable = obj;
					obj.assemblyMaterialSet.Add(table);
				}
				obj.AssemblyMaterialSet = obj.assemblyMaterialSet;
			}

			return obj;
		}

		public virtual object conversionDeepCopy(bool metric, bool demo)
		{ // removeIds to make new resource only in resource database not projectdb
			AssemblyTable obj = (AssemblyTable) conversionClone(metric, demo);

			if (AssemblyChildSet != null)
			{
				obj.assemblyChildSet = new HashSet<object>(10);
				System.Collections.IEnumerator iter = AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable cur = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable table = (AssemblyAssemblyTable) cur.clone(false, false);
					AssemblyTable assemblyTable = (AssemblyTable) cur.ChildTable.conversionClone(metric, demo);
					table.ChildTable = assemblyTable;
					obj.assemblyChildSet.Add(table);
				}
				obj.AssemblyChildSet = obj.assemblyChildSet;
			}

			if (AssemblyLaborSet != null)
			{
				obj.assemblyLaborSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable cur = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable table = (AssemblyLaborTable) cur.clone(false, false);
					LaborTable laborTable = (LaborTable) cur.LaborTable.conversionClone(metric, demo);
					table.LaborTable = laborTable;
					obj.assemblyLaborSet.Add(table);
				}
				obj.AssemblyLaborSet = obj.assemblyLaborSet;
			}

			if (AssemblyConsumableSet != null)
			{

				obj.assemblyConsumableSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable cur = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable table = (AssemblyConsumableTable) cur.clone(false);
					ConsumableTable consumableTable = (ConsumableTable) cur.ConsumableTable.conversionClone(metric, demo);
					table.ConsumableTable = consumableTable;
					obj.assemblyConsumableSet.Add(table);
				}
				obj.AssemblyConsumableSet = obj.assemblyConsumableSet;
			}

			if (AssemblySubcontractorSet != null)
			{

				obj.assemblySubcontractorSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable cur = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable table = (AssemblySubcontractorTable) cur.clone(false);
					SubcontractorTable subcontractorTable = (SubcontractorTable) cur.SubcontractorTable.conversionClone(metric, demo);
					table.SubcontractorTable = subcontractorTable;
					obj.assemblySubcontractorSet.Add(table);
				}
				obj.AssemblySubcontractorSet = obj.assemblySubcontractorSet;
			}

			if (AssemblyEquipmentSet != null)
			{

				obj.assemblyEquipmentSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable cur = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable table = (AssemblyEquipmentTable) cur.clone(false);
					EquipmentTable equipmentTable = (EquipmentTable) cur.EquipmentTable.conversionClone(metric, demo);

					table.EquipmentTable = equipmentTable;
					obj.assemblyEquipmentSet.Add(table);
				}
				obj.AssemblyEquipmentSet = obj.assemblyEquipmentSet;
			}

			if (AssemblyMaterialSet != null)
			{

				obj.assemblyMaterialSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable cur = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable table = (AssemblyMaterialTable) cur.clone(false);
					MaterialTable materialTable = (MaterialTable) cur.MaterialTable.conversionCopyWithSupplier(metric, demo);
					table.MaterialTable = materialTable;
					obj.assemblyMaterialSet.Add(table);
				}
				obj.AssemblyMaterialSet = obj.assemblyMaterialSet;
			}

			return obj;
		}

		public virtual object copy()
		{ // Possibly non working crap?
			AssemblyTable obj = (AssemblyTable) clone();

			if (AssemblyChildSet != null)
			{

				obj.assemblyChildSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable cur = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable table = new AssemblyAssemblyTable(); // ????????????
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.Comment = cur.Comment;
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.assemblyChildSet.Add(table);
				}
				obj.AssemblyChildSet = obj.assemblyChildSet;
			}
			if (AssemblyLaborSet != null)
			{

				obj.assemblyLaborSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable cur = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable table = new AssemblyLaborTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;
					table.Comment = cur.Comment;
					obj.assemblyLaborSet.Add(table);
				}
				obj.AssemblyLaborSet = obj.assemblyLaborSet;
			}

			if (AssemblyConsumableSet != null)
			{

				obj.assemblyConsumableSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable cur = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable table = new AssemblyConsumableTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.Comment = cur.Comment;
					table.FinalFixedCost = cur.FinalFixedCost;
					obj.assemblyConsumableSet.Add(table);
				}
				obj.AssemblyConsumableSet = obj.assemblyConsumableSet;
			}

			if (AssemblySubcontractorSet != null)
			{

				obj.assemblySubcontractorSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable cur = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable table = new AssemblySubcontractorTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;
					table.Comment = cur.Comment;
					obj.assemblySubcontractorSet.Add(table);
				}
				obj.AssemblySubcontractorSet = obj.assemblySubcontractorSet;
			}

			if (AssemblyEquipmentSet != null)
			{

				obj.assemblyEquipmentSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable cur = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable table = new AssemblyEquipmentTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;
					table.Comment = cur.Comment;
					obj.assemblyEquipmentSet.Add(table);
				}
				obj.AssemblyEquipmentSet = obj.assemblyEquipmentSet;
			}

			if (AssemblyMaterialSet != null)
			{

				obj.assemblyMaterialSet = new HashSet<object>(20);
				System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable cur = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable table = new AssemblyMaterialTable();
					table.FinalRate = new BigDecimalFixed(cur.calculateFinalRate().ToString());
					table.FixedCost = cur.FixedCost;
					table.FinalFixedCost = cur.FinalFixedCost;
					table.Comment = cur.Comment;
					obj.assemblyMaterialSet.Add(table);
				}
				obj.AssemblyMaterialSet = obj.assemblyMaterialSet;
			}

			return obj;
		}

		public override long? Id
		{
			get
			{
				return AssemblyId;
			}
			set
			{
				AssemblyId = value;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ASSEMBLYID" </summary>
		/// <returns> Long </returns>
		public virtual long? AssemblyId
		{
			get
			{
				return assemblyId;
			}
			set
			{
				assemblyId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUAL" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? Virtual
		{
			get
			{
				return @virtual;
			}
			set
			{
				this.@virtual = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUALEQU" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? VirtualEquipment
		{
			get
			{
				return virtualEquipment;
			}
			set
			{
				this.virtualEquipment = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUALSUB" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? VirtualSubcontractor
		{
			get
			{
				return virtualSubcontractor;
			}
			set
			{
				this.virtualSubcontractor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUALLAB" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? VirtualLabor
		{
			get
			{
				return virtualLabor;
			}
			set
			{
				this.virtualLabor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUALMAT" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? VirtualMaterial
		{
			get
			{
				return virtualMaterial;
			}
			set
			{
				this.virtualMaterial = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="VIRTUALCON" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? VirtualConsumable
		{
			get
			{
				return virtualConsumable;
			}
			set
			{
				this.virtualConsumable = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OVERTYPE" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? OverrideType
		{
			get
			{
				return overrideType;
			}
			set
			{
				this.overrideType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ACTBASED" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> unit </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				unit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRODUCTIVITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> productivity </returns>
		public virtual decimal Productivity
		{
			get
			{
				return productivity;
			}
			set
			{
				productivity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PUBLISHEDRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> productivity </returns>
		public virtual decimal PublishedRate
		{
			get
			{
				return publishedRate;
			}
			set
			{
				publishedRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PUBLISHEDCODE" type="costos_string" </summary>
		/// <returns> productivity </returns>
		public virtual string PublishedRevisionCode
		{
			get
			{
				return publishedRevisionCode;
			}
			set
			{
				publishedRevisionCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESCODE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string ItemCode
		{
			get
			{
				return itemCode;
			}
			set
			{
				this.itemCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GROUPCODE" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string GroupCode
		{
			get
			{
				return groupCode;
			}
			set
			{
				groupCode = value;
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
		/// @hibernate.property column="PROJECT" type="costos_string" </summary>
		/// <returns> project </returns>
		public virtual string Project
		{
			get
			{
				return project;
			}
			set
			{
				project = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ACCRIGHTS" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string AccessRights
		{
			get
			{
				return accessRights;
			}
			set
			{
				this.accessRights = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="KEYW" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Keywords
		{
			get
			{
				return keywords;
			}
			set
			{
				this.keywords = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="NOTES" type="costos_text" </summary>
		/// <returns> groupCode </returns>
		public virtual string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				notes = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string EditorId
		{
			get
			{
				return editorId;
			}
			set
			{
				editorId = value;
			}
		}


		public virtual decimal AssemblyLaborHours
		{
			get
			{
				decimal assemblyLaborHours = BigDecimalMath.ZERO;
    
				//		System.out.println("Calculating LABOR HOURS:");
				if (AssemblyLaborSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyLaborTable assemblyLaborTable = (AssemblyLaborTable) iter.Current;
						decimal laborHours = assemblyLaborTable.QuantityPerUnit;
						laborHours = laborHours * assemblyLaborTable.Factor1;
						laborHours = laborHours * assemblyLaborTable.Factor2;
						laborHours = laborHours * assemblyLaborTable.Factor3;
						assemblyLaborHours = assemblyLaborHours + laborHours;
						//				System.out.println(assemblyLaborTable.getLaborTable().getTitle()+" = "+
						//				assemblyLaborTable.getQuantityPerUnit()+" + "+assemblyLaborTable.getFactor1()+" + "+
						//				assemblyLaborTable.getFactor2()+" + "+assemblyLaborTable.getFactor2()+" = "+assemblyLaborHours				
						//						);
					}
				}
    
				return assemblyLaborHours;
			}
		}

		public virtual decimal AssemblyLaborHoursActivityBased
		{
			get
			{
				decimal assemblyLaborHours = BigDecimalMath.ZERO;
    
				//		System.out.println("Calculating LABOR HOURS:");
				if (AssemblyLaborSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyLaborTable assemblyLaborTable = (AssemblyLaborTable) iter.Current;
						decimal laborHours = assemblyLaborTable.Factor1;
						laborHours = laborHours * assemblyLaborTable.Factor2;
						laborHours = laborHours * assemblyLaborTable.Factor3;
						if (BigDecimalMath.cmp(Productivity, BigDecimalMath.ZERO) > 0)
						{
							laborHours = BigDecimalMath.div(laborHours, Productivity);
						}
						else
						{
							laborHours = decimal.Zero;
						}
    
						assemblyLaborHours = assemblyLaborHours + laborHours;
					}
				}
    
				return assemblyLaborHours;
			}
		}

		public virtual decimal AssemblyEquipmentHours
		{
			get
			{
				decimal assemblyEquipmentHours = BigDecimalMath.ZERO;
    
				if (AssemblyEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyEquipmentTable assemblyEquipmentTable = (AssemblyEquipmentTable) iter.Current;
						decimal equipmentHours = assemblyEquipmentTable.QuantityPerUnit;
						equipmentHours = equipmentHours * assemblyEquipmentTable.Factor1;
						equipmentHours = equipmentHours * assemblyEquipmentTable.Factor2;
						equipmentHours = equipmentHours * assemblyEquipmentTable.Factor3;
						assemblyEquipmentHours = assemblyEquipmentHours + equipmentHours;
					}
				}
    
				return assemblyEquipmentHours;
			}
		}

		public virtual decimal AssemblyEquipmentHoursActivityBased
		{
			get
			{
				decimal assemblyEquipmentHours = BigDecimalMath.ZERO;
    
				if (AssemblyEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyEquipmentTable assemblyEquipmentTable = (AssemblyEquipmentTable) iter.Current;
						decimal equipmentHours = assemblyEquipmentTable.Factor1;
						equipmentHours = equipmentHours * assemblyEquipmentTable.Factor2;
						equipmentHours = equipmentHours * assemblyEquipmentTable.Factor3;
						if (BigDecimalMath.cmp(Productivity, BigDecimalMath.ZERO) > 0)
						{
							equipmentHours = BigDecimalMath.div(equipmentHours, Productivity);
						}
						else
						{
							equipmentHours = decimal.Zero;
						}
    
						assemblyEquipmentHours = assemblyEquipmentHours + equipmentHours;
					}
				}
    
				return assemblyEquipmentHours;
			}
		}

		public virtual decimal AssemblyLaborRate
		{
			get
			{
				decimal assemblyLaborRate = BigDecimalMath.ZERO;
    
				if (AssemblyLaborSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyLaborTable assemblyLaborTable = (AssemblyLaborTable) iter.Current;
						assemblyLaborRate = assemblyLaborRate + assemblyLaborTable.calculateFinalRate();
					}
				}
    
				return assemblyLaborRate;
			}
		}

		public virtual decimal AssemblyLaborIKARate
		{
			get
			{
				decimal assemblyLaborRate = BigDecimalMath.ZERO;
    
				if (AssemblyLaborSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyLaborSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyLaborTable assemblyLaborTable = (AssemblyLaborTable) iter.Current;
						assemblyLaborRate = assemblyLaborRate + assemblyLaborTable.calculateFinalIKARate();
					}
				}
    
				return assemblyLaborRate;
			}
		}

		public virtual decimal AssemblyConsumableRate
		{
			get
			{
				decimal assemblyConsumableRate = BigDecimalMath.ZERO;
    
				if (AssemblyConsumableSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyConsumableSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyConsumableTable assemblyConsumableTable = (AssemblyConsumableTable) iter.Current;
						assemblyConsumableRate = assemblyConsumableRate + assemblyConsumableTable.calculateFinalRate();
					}
				}
    
				return assemblyConsumableRate;
			}
		}

		public virtual decimal AssemblySubcontractorRate
		{
			get
			{
				decimal assemblySubcontractorRate = BigDecimalMath.ZERO;
    
				if (AssemblySubcontractorSet != null)
				{
					System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblySubcontractorTable assemblySubcontractorTable = (AssemblySubcontractorTable) iter.Current;
						assemblySubcontractorRate = assemblySubcontractorRate + assemblySubcontractorTable.calculateFinalRate();
					}
				}
    
				return assemblySubcontractorRate;
			}
		}

		public virtual decimal AssemblySubcontractorIKARate
		{
			get
			{
				decimal assemblySubcontractorRate = BigDecimalMath.ZERO;
    
				if (AssemblySubcontractorSet != null)
				{
					System.Collections.IEnumerator iter = AssemblySubcontractorSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblySubcontractorTable assemblySubcontractorTable = (AssemblySubcontractorTable) iter.Current;
						assemblySubcontractorRate = assemblySubcontractorRate + assemblySubcontractorTable.calculateFinalIKARate();
					}
				}
    
				return assemblySubcontractorRate;
			}
		}

		public virtual decimal AssemblyEquipmentRate
		{
			get
			{
				decimal assemblyEquipmentRate = BigDecimalMath.ZERO;
    
				if (AssemblyEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyEquipmentTable assemblyEquipmentTable = (AssemblyEquipmentTable) iter.Current;
						assemblyEquipmentRate = assemblyEquipmentRate + assemblyEquipmentTable.calculateFinalRate();
					}
				}
    
				return assemblyEquipmentRate;
			}
		}

		// method for topsheet calculation
		public virtual decimal AssemblyEquipmentDepreciationRate
		{
			get
			{
				decimal assemblyEquipmentDepreciationRate = BigDecimalMath.ZERO;
    
				if (AssemblyEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyEquipmentTable assemblyEquipmentTable = (AssemblyEquipmentTable) iter.Current;
						assemblyEquipmentDepreciationRate = assemblyEquipmentDepreciationRate + assemblyEquipmentTable.calculateFinalDepreciationRate();
					}
				}
    
				return assemblyEquipmentDepreciationRate;
			}
		}

		//	method for topsheet calculation
		public virtual decimal AssemblyEquipmentFuelRate
		{
			get
			{
				decimal assemblyEquipmentFuelRate = BigDecimalMath.ZERO;
    
				if (AssemblyEquipmentSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyEquipmentSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyEquipmentTable assemblyEquipmentTable = (AssemblyEquipmentTable) iter.Current;
						assemblyEquipmentFuelRate = assemblyEquipmentFuelRate + assemblyEquipmentTable.calculateFinalFuelRate();
					}
				}
    
				return assemblyEquipmentFuelRate;
			}
		}

		public virtual decimal AssemblyMaterialTotalRate
		{
			get
			{
				decimal assemblyMaterialRate = BigDecimalMath.ZERO;
    
				if (AssemblyMaterialSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyMaterialTable assemblyMaterialTable = (AssemblyMaterialTable) iter.Current;
						assemblyMaterialRate = assemblyMaterialRate + assemblyMaterialTable.calculateFinalRate();
					}
				}
    
				return assemblyMaterialRate;
			}
		}

		public virtual decimal AssemblyFabricationRate
		{
			get
			{
				decimal assemblyMaterialRate = BigDecimalMath.ZERO;
    
				if (AssemblyMaterialSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyMaterialTable assemblyMaterialTable = (AssemblyMaterialTable) iter.Current;
						assemblyMaterialRate = assemblyMaterialRate + assemblyMaterialTable.calculateFinalFabricationRate();
					}
				}
    
				return assemblyMaterialRate;
			}
		}

		public virtual decimal AssemblyShipmentRate
		{
			get
			{
				decimal assemblyMaterialRate = BigDecimalMath.ZERO;
    
				if (AssemblyMaterialSet != null)
				{
					System.Collections.IEnumerator iter = AssemblyMaterialSet.GetEnumerator();
					while (iter.MoveNext())
					{
						AssemblyMaterialTable assemblyMaterialTable = (AssemblyMaterialTable) iter.Current;
						assemblyMaterialRate = assemblyMaterialRate + assemblyMaterialTable.calculateFinalShipmentRate();
					}
				}
    
				return assemblyMaterialRate;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CURRENCY" type="costos_string" </summary>
		/// <returns> currency </returns>
		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				this.currency = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATEPROVINCE" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
		public virtual string StateProvince
		{
			get
			{
				return stateProvince;
			}
			set
			{
				this.stateProvince = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) public java.math.BigDecimal getRate()
		public virtual decimal Rate
		{
			get
			{
				return rate;
			}
			set
			{
				rate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="MATRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="SUBRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="CONRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="EQURATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="UMHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
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
		/// @hibernate.property column="UEHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> laborRate </returns>
		public virtual decimal UnitEquipmentHours
		{
			get
			{
				return unitEquipmentHours;
			}
			set
			{
				this.unitEquipmentHours = value;
			}
		}


		public virtual decimal calculateFinalFixedCost()
		{
			decimal totalFixedCost = decimal.Zero;

			// Labor:
			foreach (AssemblyLaborTable assTable in assemblyLaborSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			// Equipment:
			foreach (AssemblyEquipmentTable assTable in assemblyEquipmentSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			// Material:
			foreach (AssemblyMaterialTable assTable in assemblyMaterialSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			// Sub-contractor:
			foreach (AssemblySubcontractorTable assTable in assemblySubcontractorSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			// Consumable:
			foreach (AssemblyConsumableTable assTable in assemblyConsumableSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			// Children:
			foreach (AssemblyAssemblyTable assTable in assemblyChildSet)
			{
				totalFixedCost = totalFixedCost + assTable.FinalFixedCost;
			}

			return totalFixedCost;
		}

		public virtual void calculateRate()
		{
			calculateRate(true);
		}

		private void calculateRate(bool fromResources)
		{
			if (fromResources)
			{
				LaborRate = calculateFinalLaborRate();
				ConsumableRate = calculateFinalConsumableRate();
				SubcontractorRate = calculateFinalSubcontractorRate();
				EquipmentRate = calculateFinalEquipmentRate();
				MaterialRate = calculateFinalMaterialRate();
				if (ActivityBased != null && ActivityBased.Equals(false))
				{
					UnitManhours = calculateFinalLaborHours();
					UnitEquipmentHours = calculateFinalEquipmentHours();
				}
				else
				{
					UnitManhours = calculateFinalLaborHoursActivityBased();
					UnitEquipmentHours = calculateFinalEquipmentHoursActivityBased();
					/*
					if ( getProductivity().compareTo(BigDecimalMath.ZERO) > 0 )
						setUnitManhours(BigDecimalMath.div(BigDecimalMath.ONE, getProductivity()));
					else
						setUnitManhours(BigDecimalMath.ZERO);
					
					setUnitEquipmentHours(getUnitManhours());
					*/
				}

			}

			rate = BigDecimalMath.ZERO;
			rate = rate + LaborRate;
			rate = rate + ConsumableRate;
			rate = rate + SubcontractorRate;
			rate = rate + EquipmentRate;
			rate = rate + MaterialRate;
			calculateAccuracy();
		}

		public virtual decimal calculateFinalLaborHoursActivityBased()
		{
			decimal total = AssemblyLaborHoursActivityBased;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalLaborManhours();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalLaborHours()
		{
			decimal total = AssemblyLaborHours;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalLaborManhours();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalEquipmentHours()
		{
			decimal total = AssemblyEquipmentHours;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalEquipmentManhours();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalEquipmentHoursActivityBased()
		{
			decimal total = AssemblyEquipmentHoursActivityBased;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalEquipmentManhours();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalLaborRate()
		{
			decimal total = AssemblyLaborRate;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalLaborRate();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalMaterialRate()
		{
			decimal total = AssemblyMaterialTotalRate;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalMaterialRate();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalSubcontractorRate()
		{
			decimal total = AssemblySubcontractorRate;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalSubcontractorRate();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalConsumableRate()
		{
			decimal total = AssemblyConsumableRate;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalConsumableRate();
				}
			}

			return total;
		}

		public virtual decimal calculateFinalEquipmentRate()
		{
			decimal total = AssemblyEquipmentRate;

			if (AssemblyChildSet != null)
			{
				foreach (AssemblyAssemblyTable assTable in AssemblyChildSet)
				{
					total = total + assTable.calculateFinalEquipmentRate();
				}
			}

			return total;
		}

		/// <summary>
		/// @hibernate.property column="QTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantity </returns>
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
		/// @hibernate.property column="ACCURACY" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
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
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
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


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> stateProvince </returns>
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
		/// @hibernate.property column="BIMTYPE" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
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
		/// <returns> stateProvince </returns>
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
		/// @hibernate.property column="COUNTRY" type="costos_string" </summary>
		/// <returns> currency </returns>
		public virtual string Country
		{
			get
			{
				return country;
			}
			set
			{
				this.country = value;
			}
		}


		private long? databaseId;

		//#RXL_START
		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASEID" type="long" index="IDX_MDBID" </summary>
		/// <returns> lastUpdate </returns>
		//#RXL_END
		public virtual long? DatabaseId
		{
			get
			{
				return databaseId;
			}
			set
			{
				databaseId = value;
			}
		}


		private long? databaseCreationDate;

		//#RXL_START
		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASECREATIONDATE" type="long" </summary>
		/// <returns> lastUpdate </returns>
		//#RXL_END
		public virtual long? DatabaseCreationDate
		{
			get
			{
				return databaseCreationDate;
			}
			set
			{
				databaseCreationDate = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="CHILDID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyAssemblyTable"
		/// @hibernate.cache usage="nonstrict-read-write"
		/// </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyAssemblyTable> AssemblyParentSet
		{
			get
			{
				return assemblyParentSet;
			}
			set
			{
				assemblyParentSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyAssemblyTable"
		/// @hibernate.cache usage="nonstrict-read-write"
		/// </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyAssemblyTable> AssemblyChildSet
		{
			get
			{
				return assemblyChildSet;
			}
			set
			{
				assemblyChildSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyEquipmentTable"
		/// @hibernate.cache usage="nonstrict-read-write"
		/// </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyEquipmentTable> AssemblyEquipmentSet
		{
			get
			{
				return assemblyEquipmentSet;
			}
			set
			{
				assemblyEquipmentSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyLaborTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyLaborTable> AssemblyLaborSet
		{
			get
			{
				return assemblyLaborSet;
			}
			set
			{
				assemblyLaborSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyConsumableTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyConsumableTable> AssemblyConsumableSet
		{
			get
			{
				return assemblyConsumableSet;
			}
			set
			{
				assemblyConsumableSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyMaterialTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblyMaterialTable> AssemblyMaterialSet
		{
			get
			{
				return assemblyMaterialSet;
			}
			set
			{
				assemblyMaterialSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblySubcontractorTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<AssemblySubcontractorTable> AssemblySubcontractorSet
		{
			get
			{
				return assemblySubcontractorSet;
			}
			set
			{
				assemblySubcontractorSet = value;
			}
		}


		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemAssemblyTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> BoqItemAssemblySet
		{
			get
			{
				return boqItemAssemblySet;
			}
			set
			{
				boqItemAssemblySet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}

			return AssemblyId + ". " + Title;
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="ASSEMBLYID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.AssemblyHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> AssemblyHistorySet
		{
			get
			{
				return assemblyHistorySet;
			}
			set
			{
				this.assemblyHistorySet = value;
			}
		}


		public virtual DataFlavor[] TransferDataFlavors
		{
			get
			{
				lock (this)
				{
					return s_supportedDataFlavors;
				}
			}
		}

		public virtual bool isDataFlavorSupported(DataFlavor flavor)
		{
			return DataFlavors.assemblyDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.assemblyDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static AssemblyTable getFromDatabase(org.hibernate.Session session, AssemblyTable childTable, String project, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static AssemblyTable getFromDatabase(Session session, AssemblyTable childTable, string project, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;

			if (childTable.DatabaseCreationDate != null)
			{
				if (childTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = childTable.DatabaseCreationDate.Value;
					if (childTable.DatabaseId != null)
					{
						databaseId = childTable.DatabaseId;
					}
					else
					{
						databaseId = childTable.AssemblyId;
					}
				}
			}
			else
			{
				databaseId = childTable.AssemblyId;
			}

			//		if ( databaseId == null )
			//			databaseId = new Long(-200);

			AssemblyTable dbChildTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			if (!inResourceDatabase)
			{
				//if ( databaseId == null ) {
				/* ALWAYS CREATE NEW FOR LINE ITEMS */
				res = Collections.EMPTY_LIST;
				//}
				//else {			
				//res = session.createQuery("from AssemblyTable as o where o.databaseCreationDate = "+dbCreationDate+" and o.databaseId = "+databaseId).list();
				//}
			}
			else
			{
				//res = session.createQuery("from AssemblyTable as o where o.consumableId = "+databaseId).list();
				res = DatabaseDBUtil.loadBulk(typeof(AssemblyTable), new long?[] {childTable.AssemblyId});
				//System.out.println("Loaded : "+res);
			}

			if (res.Count == 1)
			{
				try
				{
					dbChildTable = (AssemblyTable) res.GetEnumerator().next();
					dbChildTable.ToString();
					//System.out.println("ok loaded: "+dbChildTable);
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					childTable.DatabaseCreationDate = dbCreationDate;
					childTable.DatabaseId = databaseId;
				}
				else
				{
					childTable = (AssemblyTable) childTable.deepRoundCopy();
					childTable.EditorId = DatabaseDBUtil.Properties.UserId;
					childTable.Project = project;
					childTable.DatabaseId = null;
					childTable.BuildUpRate = null;
					childTable.DatabaseCreationDate = null;
				}
				long? id = (long?) session.save(childTable.clone());
				if (!inResourceDatabase)
				{
					dbChildTable = (AssemblyTable) session.load(typeof(AssemblyTable), id);
					if (dbChildTable.DatabaseId == null)
					{
						dbChildTable.DatabaseId = id;
						session.update(dbChildTable);
					}
				}
				else
				{
					dbChildTable = (AssemblyTable) DatabaseDBUtil.loadBulk(typeof(AssemblyTable), new long?[] {id}).get(0);
				}

				//			System.out.println("Deep persisting: "+childTable);
				AssemblyTable.deepPersist(session, dbChildTable, childTable, projectId, inResourceDatabase);
			}

			if (dbChildTable.AssemblyChildSet == null)
			{
				dbChildTable.AssemblyChildSet = new HashSet<object>();
			}
			if (dbChildTable.AssemblyParentSet == null)
			{
				dbChildTable.AssemblyParentSet = new HashSet<object>();
			}

			return dbChildTable;
		}

		// returns a new if not found
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static LaborTable getFromDatabase(org.hibernate.Session session, LaborTable laborTable, String project, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static LaborTable getFromDatabase(Session session, LaborTable laborTable, string project, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;

			if (laborTable.DatabaseCreationDate != null)
			{
				if (laborTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = laborTable.DatabaseCreationDate.Value;
					if (laborTable.DatabaseId != null)
					{
						databaseId = laborTable.DatabaseId;
					}
					else
					{
						databaseId = laborTable.LaborId;
					}
				}
			}
			else
			{
				databaseId = laborTable.LaborId;
			}

			//		System.out.println("I am seeking for: "+laborTable.getTitle()+", "+laborTable.getDatabaseCreationDate()+", "+laborTable.getDatabaseId()+", "+databaseId);

			//		if ( databaseId == null )
			//			databaseId = new Long(-200); // assumes that -200 will nerver be found in DB?

			LaborTable dbLaborTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			//		System.out.println("Labor Database Creation Date = "+dbCreationDate+" databaseId = "+databaseId);
			if (!inResourceDatabase)
			{
				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from LaborTable as o where o.projectId = " + projectId + " and o.databaseCreationDate = " + dbCreationDate + " and o.databaseId = " + databaseId).list();
				}
			}
			else
			{
				//res = session.createQuery("from LaborTable as o where o.laborId = "+databaseId).list();			
				res = DatabaseDBUtil.loadBulk(typeof(LaborTable), new long?[] {databaseId});
			}

			if (res.Count == 1)
			{
				try
				{
					//				System.out.println("found!");
					dbLaborTable = (LaborTable) res.GetEnumerator().next();
					dbLaborTable.ToString();
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					laborTable.DatabaseCreationDate = dbCreationDate;
					laborTable.DatabaseId = databaseId;
				}
				else
				{
					laborTable = (LaborTable) laborTable.clone();
					laborTable.EditorId = DatabaseDBUtil.Properties.UserId;
					laborTable.Project = project;
					laborTable.DatabaseId = null;
					laborTable.BuildUpRate = null;
					laborTable.DatabaseCreationDate = null;
				}
				long? id = (long?) session.save(laborTable.clone());
				if (!inResourceDatabase)
				{
					dbLaborTable = (LaborTable) session.load(typeof(LaborTable), id);
					if (dbLaborTable.DatabaseId == null)
					{
						laborTable.DatabaseId = id;
						dbLaborTable.DatabaseId = id;
						session.update(dbLaborTable);
					}
				}
				else
				{
					dbLaborTable = (LaborTable) DatabaseDBUtil.loadBulk(typeof(LaborTable), new long?[] {id}).get(0);
				}
			}

			if (dbLaborTable.AssemblyLaborSet == null)
			{
				dbLaborTable.AssemblyLaborSet = new HashSet<object>();
			}

			//		System.out.println("I found: "+dbLaborTable.getTitle()+", "+dbLaborTable.getDatabaseCreationDate()+", "+dbLaborTable.getDatabaseId()+", "+databaseId);

			return dbLaborTable;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static ConsumableTable getFromDatabase(org.hibernate.Session session, ConsumableTable consumableTable, String project, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static ConsumableTable getFromDatabase(Session session, ConsumableTable consumableTable, string project, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;

			if (consumableTable.DatabaseCreationDate != null)
			{
				if (consumableTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = consumableTable.DatabaseCreationDate.Value;
					if (consumableTable.DatabaseId != null)
					{
						databaseId = consumableTable.DatabaseId;
					}
					else
					{
						databaseId = consumableTable.ConsumableId;
					}
				}
			}
			else
			{
				databaseId = consumableTable.ConsumableId;
			}

			//		if ( databaseId == null )
			//			databaseId = new Long(-200);

			ConsumableTable dbConsumableTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			if (!inResourceDatabase)
			{
				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from ConsumableTable as o where o.projectId = " + projectId + " and o.databaseCreationDate = " + dbCreationDate + " and o.databaseId = " + databaseId).list();
				}
			}
			else
			{
				//res = session.createQuery("from ConsumableTable as o where o.consumableId = "+databaseId).list();			
				res = DatabaseDBUtil.loadBulk(typeof(ConsumableTable), new long?[] {databaseId});
			}

			if (res.Count == 1)
			{
				try
				{
					dbConsumableTable = (ConsumableTable) res.GetEnumerator().next();
					dbConsumableTable.ToString();
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					consumableTable.DatabaseCreationDate = dbCreationDate;
					consumableTable.DatabaseId = databaseId;
				}
				else
				{
					consumableTable = (ConsumableTable) consumableTable.clone();
					consumableTable.EditorId = DatabaseDBUtil.Properties.UserId;
					consumableTable.Project = project;
					consumableTable.DatabaseId = null;
					consumableTable.DatabaseCreationDate = null;
					consumableTable.BuildUpRate = null;
				}
				long? id = (long?) session.save(consumableTable.clone());
				if (!inResourceDatabase)
				{
					dbConsumableTable = (ConsumableTable) session.load(typeof(ConsumableTable), id);
					if (dbConsumableTable.DatabaseId == null)
					{
						dbConsumableTable.DatabaseId = id;
						session.update(dbConsumableTable);
					}
				}
				else
				{
					dbConsumableTable = (ConsumableTable) DatabaseDBUtil.loadBulk(typeof(ConsumableTable), new long?[] {id}).get(0);
				}
			}

			if (dbConsumableTable.AssemblyConsumableSet == null)
			{
				dbConsumableTable.AssemblyConsumableSet = new HashSet<object>();
			}

			return dbConsumableTable;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static EquipmentTable getFromDatabase(org.hibernate.Session session, EquipmentTable equipmentTable, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static EquipmentTable getFromDatabase(Session session, EquipmentTable equipmentTable, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;

			if (equipmentTable.DatabaseCreationDate != null)
			{
				if (equipmentTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = equipmentTable.DatabaseCreationDate.Value;
					if (equipmentTable.DatabaseId != null)
					{
						databaseId = equipmentTable.DatabaseId;
					}
					else
					{
						databaseId = equipmentTable.EquipmentId;
					}
				}
			}
			else
			{
				databaseId = equipmentTable.EquipmentId;
			}

			//		if ( databaseId == null )
			//			databaseId = new Long(-200);

			EquipmentTable dbEquipmentTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			//System.out.println("Equipment Database Creation Date = "+dbCreationDate+" databaseId = "+databaseId);
			if (!inResourceDatabase)
			{
				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from EquipmentTable as o where o.projectId = " + projectId + " and o.databaseCreationDate = " + dbCreationDate + " and o.databaseId = " + databaseId).list();
				}
			}
			else
			{
				//res = session.createQuery("from EquipmentTable as o where o.equipmentId = "+databaseId).list();			
				res = DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {databaseId});
			}

			//System.out.println("Found: "+res.size());

			if (res.Count == 1)
			{
				try
				{
					dbEquipmentTable = (EquipmentTable) res.GetEnumerator().next();
					dbEquipmentTable.ToString();
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					equipmentTable.DatabaseCreationDate = dbCreationDate;
					equipmentTable.DatabaseId = databaseId;
				}
				else
				{
					equipmentTable = (EquipmentTable) equipmentTable.clone();
					equipmentTable.EditorId = DatabaseDBUtil.Properties.UserId;
					equipmentTable.DatabaseId = null;
					equipmentTable.DatabaseCreationDate = null;
					equipmentTable.BuildUpRate = null;
				}
				long? id = (long?) session.save(equipmentTable.clone());
				if (!inResourceDatabase)
				{
					dbEquipmentTable = (EquipmentTable) session.load(typeof(EquipmentTable), id);
					if (dbEquipmentTable.DatabaseId == null)
					{
						dbEquipmentTable.DatabaseId = id;
						session.update(dbEquipmentTable);
					}
				}
				else
				{
					dbEquipmentTable = (EquipmentTable) DatabaseDBUtil.loadBulk(typeof(EquipmentTable), new long?[] {id}).get(0);
				}
			}

			if (dbEquipmentTable.AssemblyEquipmentSet == null)
			{
				dbEquipmentTable.AssemblyEquipmentSet = new HashSet<object>();
			}

			return dbEquipmentTable;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static SubcontractorTable getFromDatabase(org.hibernate.Session session, SubcontractorTable subcontractorTable, String project, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static SubcontractorTable getFromDatabase(Session session, SubcontractorTable subcontractorTable, string project, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;

			if (subcontractorTable.DatabaseCreationDate != null)
			{
				if (subcontractorTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = subcontractorTable.DatabaseCreationDate.Value;
					if (subcontractorTable.DatabaseId != null)
					{
						databaseId = subcontractorTable.DatabaseId;
					}
					else
					{
						databaseId = subcontractorTable.SubcontractorId;
					}
				}
			}
			else
			{
				databaseId = subcontractorTable.SubcontractorId;
			}

			//		if ( databaseId == null )
			//			databaseId = new Long(-200);

			SubcontractorTable dbSubcontractorTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			if (!inResourceDatabase)
			{
				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from SubcontractorTable as o where o.projectId = " + projectId + " and o.databaseCreationDate = " + dbCreationDate + " and o.databaseId = " + databaseId).list();
				}
			}
			else
			{
				//res = session.createQuery("from SubcontractorTable as o where o.subcontractorId = "+databaseId).list();			
				res = DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {databaseId});
			}

			if (res.Count == 1)
			{
				try
				{
					dbSubcontractorTable = (SubcontractorTable) res.GetEnumerator().next();
					dbSubcontractorTable.ToString();
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					subcontractorTable.DatabaseCreationDate = dbCreationDate;
					subcontractorTable.DatabaseId = databaseId;
				}
				else
				{
					subcontractorTable = (SubcontractorTable) subcontractorTable.clone();
					subcontractorTable.EditorId = DatabaseDBUtil.Properties.UserId;
					subcontractorTable.Project = project;
					subcontractorTable.DatabaseId = null;
					subcontractorTable.DatabaseCreationDate = null;
					subcontractorTable.BuildUpRate = null;
				}
				long? id = (long?) session.save(subcontractorTable.clone());
				if (!inResourceDatabase)
				{
					dbSubcontractorTable = (SubcontractorTable) session.load(typeof(SubcontractorTable), id);
					if (dbSubcontractorTable.DatabaseId == null)
					{
						dbSubcontractorTable.DatabaseId = id;
						session.update(dbSubcontractorTable);
					}
				}
				else
				{
					dbSubcontractorTable = (SubcontractorTable) DatabaseDBUtil.loadBulk(typeof(SubcontractorTable), new long?[] {id}).get(0);
				}
			}

			if (dbSubcontractorTable.AssemblySubcontractorSet == null)
			{
				dbSubcontractorTable.AssemblySubcontractorSet = new HashSet<object>();
			}

			return dbSubcontractorTable;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static MaterialTable getFromDatabase(org.hibernate.Session session, MaterialTable materialTable, String project, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		private static MaterialTable getFromDatabase(Session session, MaterialTable materialTable, string project, long? projectId, bool inResourceDatabase)
		{
			long dbCreationDate = CachedDBCreationDate;
			long? databaseId = null;
			bool newlyAdded = false;
			MaterialTable actualMaterial = materialTable;
			if (materialTable.DatabaseCreationDate != null)
			{
				if (materialTable.DatabaseCreationDate.Value == 100)
				{ // MISSING
					databaseId = null;
					dbCreationDate = 100;
				}
				else
				{
					dbCreationDate = materialTable.DatabaseCreationDate.Value;
					if (materialTable.DatabaseId != null)
					{
						databaseId = materialTable.DatabaseId;
					}
					else
					{
						databaseId = materialTable.MaterialId;
					}
				}
			}
			else
			{
				databaseId = materialTable.MaterialId;
			}

			//		if ( databaseId == null )
			//			databaseId = new Long(-200);

			MaterialTable dbMaterialTable = null;
			// has db info inside:
			System.Collections.IList res = null;

			if (!inResourceDatabase)
			{
				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from MaterialTable as o where o.projectId = " + projectId + " and o.databaseCreationDate = " + dbCreationDate + " and o.databaseId = " + databaseId).list();
				}
			}
			else
			{
				//res = session.createQuery("from MaterialTable as o where o.materialId = "+databaseId).list();			
				res = DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {databaseId});
			}

			if (res.Count == 1)
			{
				try
				{
					dbMaterialTable = (MaterialTable) res.GetEnumerator().next();
					dbMaterialTable.ToString();
				}
				catch (ObjectNotFoundException)
				{
					res = Collections.EMPTY_LIST;
				}
			}

			if (res.Count == 0)
			{
				// does not exist so add it:
				if (!inResourceDatabase)
				{
					materialTable.DatabaseCreationDate = dbCreationDate;
					materialTable.DatabaseId = databaseId;
				}
				else
				{
					materialTable = (MaterialTable) materialTable.clone();
					materialTable.EditorId = DatabaseDBUtil.Properties.UserId;
					materialTable.Project = project;
					materialTable.DatabaseId = null;
					materialTable.DatabaseCreationDate = null;
					materialTable.BuildUpRate = null;
				}
				long? id = (long?) session.save(materialTable.clone());
				if (!inResourceDatabase)
				{
					dbMaterialTable = (MaterialTable) session.load(typeof(MaterialTable), id);
					if (dbMaterialTable.DatabaseId == null)
					{
						dbMaterialTable.DatabaseId = id;
						session.update(dbMaterialTable);
					}
				}
				else
				{
					dbMaterialTable = (MaterialTable) DatabaseDBUtil.loadBulk(typeof(MaterialTable), new long?[] {id}).get(0);
				}
				newlyAdded = true;
			}

			SupplierTable supplierTable = actualMaterial.SupplierTable;

			if (supplierTable != null && newlyAdded)
			{
				if (supplierTable.DatabaseCreationDate != null)
				{
					if (materialTable.DatabaseCreationDate.Value == 100)
					{ // MISSING
						databaseId = null;
						dbCreationDate = 100;
					}
					else
					{
						dbCreationDate = supplierTable.DatabaseCreationDate.Value;
						databaseId = supplierTable.DatabaseId.Value;
						//				if ( supplierTable.getDatabaseId() != null )
						//					databaseId     = supplierTable.getDatabaseId();
						//				else
						//					databaseId     = supplierTable.getSupplierId();
					}
				}
				else
				{
					databaseId = supplierTable.SupplierId.Value;
					dbCreationDate = CachedDBCreationDate;
				}
				//System.out.println("adding supplier : "+supplierTable);

				if (databaseId == null)
				{
					res = Collections.EMPTY_LIST;
				}
				else
				{
					res = session.createQuery("from SupplierTable as o where o.projectId = " + projectId + " and o.databaseId = " + databaseId + " and o.databaseCreationDate = " + dbCreationDate).list();
				}

				if (res.Count == 1)
				{
					try
					{
						supplierTable = (SupplierTable) res.GetEnumerator().next();
						supplierTable.ToString();
					}
					catch (ObjectNotFoundException)
					{
						res = Collections.EMPTY_LIST;
					}
				}

				if (res.Count == 0)
				{
					// does not exist so add it!
					//System.out.println("addin new one from assembly : "+supplierTable);
					supplierTable.DatabaseCreationDate = dbCreationDate;
					supplierTable.DatabaseId = supplierTable.SupplierId;

					long? id = (long?) session.save(supplierTable.clone());
					if (!inResourceDatabase)
					{
						supplierTable = (SupplierTable) session.load(typeof(SupplierTable), id);
					}
					else
					{
						supplierTable = (SupplierTable) DatabaseDBUtil.loadBulk(typeof(SupplierTable), new long?[] {id}).get(0);
					}
				}

				if (supplierTable.MaterialSet == null)
				{
					supplierTable.MaterialSet = new HashSet<object>();
				}
				// make the association:
				if (!inResourceDatabase)
				{
					dbMaterialTable.SupplierTable = supplierTable;
					supplierTable.MaterialSet.Add(dbMaterialTable);
					session.update(supplierTable);
					session.update(dbMaterialTable);
				}
				else
				{
					DatabaseDBUtil.associateSupplierWithMaterial(supplierTable, dbMaterialTable);
				}
			}

			if (dbMaterialTable.AssemblyMaterialSet == null)
			{
				dbMaterialTable.AssemblyMaterialSet = new HashSet<object>();
			}

			return dbMaterialTable;
		}

		// inside transaction, persists safely with new values:
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deepPersist(org.hibernate.Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		public static void deepPersist(Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, long? projectId, bool inResourceDatabase)
		{
			curAssemblyTable = (AssemblyTable) session.load(typeof(AssemblyTable), curAssemblyTable.AssemblyId);

			if (curAssemblyTable.AssemblyChildSet == null)
			{
				curAssemblyTable.AssemblyChildSet = new HashSet<object>();
			}
			if (curAssemblyTable.AssemblyLaborSet == null)
			{
				curAssemblyTable.AssemblyLaborSet = new HashSet<object>();
			}
			if (curAssemblyTable.AssemblyConsumableSet == null)
			{
				curAssemblyTable.AssemblyConsumableSet = new HashSet<object>();
			}
			if (curAssemblyTable.AssemblyEquipmentSet == null)
			{
				curAssemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			}
			if (curAssemblyTable.AssemblySubcontractorSet == null)
			{
				curAssemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			}
			if (curAssemblyTable.AssemblyMaterialSet == null)
			{
				curAssemblyTable.AssemblyMaterialSet = new HashSet<object>();
			}

			ISet<AssemblyAssemblyTable> unSorted = newAssemblyTable.AssemblyChildSet;
			//Order the set, just to added again in the database in the same sort(resource tree panel remember the last selected item)
			IList<AssemblyAssemblyTable> sorted = unSorted.OrderBy((o1, o2) =>
			{
			if (o1.AssemblyChildId != null && o2.AssemblyChildId != null)
			{
				return o1.AssemblyChildId.compareTo(o2.AssemblyChildId);
			}
			return 0;
			}).ToList();

			System.Collections.IEnumerator iter = sorted.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyAssemblyTable newAssemblyAssembly = (AssemblyAssemblyTable) iter.Current;
				long? id = (long?) session.save(newAssemblyAssembly.clone(false, false));
				AssemblyAssemblyTable curAssemblyAssembly = (AssemblyAssemblyTable) session.load(typeof(AssemblyAssemblyTable), id);

				AssemblyTable childTable = getFromDatabase(session, newAssemblyAssembly.ChildTable, newAssemblyTable.Project, projectId, inResourceDatabase);
				// make the association
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					curAssemblyTable.AssemblyChildSet.Add(curAssemblyAssembly);
					//				childTable.getAssemblyParentSet().add(curAssemblyAssembly);
					curAssemblyAssembly.ChildTable = childTable;
					curAssemblyAssembly.ParentTable = curAssemblyTable;
					session.update(curAssemblyAssembly);
					//				session.update(childTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, childTable, curAssemblyAssembly);
				}
			}

			iter = newAssemblyTable.AssemblyLaborSet.GetEnumerator();

			while (iter.MoveNext())
			{
				AssemblyLaborTable newAssemblyLabor = (AssemblyLaborTable) iter.Current;
				long? id = (long?) session.save(newAssemblyLabor.clone(false, false));
				AssemblyLaborTable curAssemblyLabor = (AssemblyLaborTable) session.load(typeof(AssemblyLaborTable), id);

				LaborTable laborTable = getFromDatabase(session, newAssemblyLabor.LaborTable, newAssemblyTable.Project, projectId, inResourceDatabase);
				// make the association
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					curAssemblyTable.AssemblyLaborSet.Add(curAssemblyLabor);
					//				laborTable.getAssemblyLaborSet().add(curAssemblyLabor);
					curAssemblyLabor.LaborTable = laborTable;
					curAssemblyLabor.AssemblyTable = curAssemblyTable;
					session.update(curAssemblyLabor);
					//				session.update(laborTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, laborTable, curAssemblyLabor);
				}
			}

			iter = newAssemblyTable.AssemblyConsumableSet.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyConsumableTable newAssemblyConsumable = (AssemblyConsumableTable) iter.Current;
				long? id = (long?) session.save(newAssemblyConsumable.clone(false));
				AssemblyConsumableTable curAssemblyConsumable = (AssemblyConsumableTable) session.load(typeof(AssemblyConsumableTable), id);

				ConsumableTable consumableTable = getFromDatabase(session, newAssemblyConsumable.ConsumableTable, newAssemblyTable.Project, projectId, inResourceDatabase);
				// make the association
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					curAssemblyTable.AssemblyConsumableSet.Add(curAssemblyConsumable);
					//				consumableTable.getAssemblyConsumableSet().add(curAssemblyConsumable);
					curAssemblyConsumable.ConsumableTable = consumableTable;
					curAssemblyConsumable.AssemblyTable = curAssemblyTable;
					session.update(curAssemblyConsumable);
					//				session.update(consumableTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, consumableTable, curAssemblyConsumable);
				}
			}

			iter = newAssemblyTable.AssemblyEquipmentSet.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyEquipmentTable newAssemblyEquipment = (AssemblyEquipmentTable) iter.Current;
				long? id = (long?) session.save(newAssemblyEquipment.clone(false));
				AssemblyEquipmentTable curAssemblyEquipment = (AssemblyEquipmentTable) session.load(typeof(AssemblyEquipmentTable), id);

				EquipmentTable equipmentTable = getFromDatabase(session, newAssemblyEquipment.EquipmentTable, projectId, inResourceDatabase);
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					// make the association
					curAssemblyTable.AssemblyEquipmentSet.Add(curAssemblyEquipment);
					//				equipmentTable.getAssemblyEquipmentSet().add(curAssemblyEquipment);
					curAssemblyEquipment.EquipmentTable = equipmentTable;
					curAssemblyEquipment.AssemblyTable = curAssemblyTable;
					session.update(curAssemblyEquipment);
					//				session.update(equipmentTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, equipmentTable, curAssemblyEquipment);
				}
			}

			iter = newAssemblyTable.AssemblySubcontractorSet.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblySubcontractorTable newAssemblySubcontractor = (AssemblySubcontractorTable) iter.Current;
				long? id = (long?) session.save(newAssemblySubcontractor.clone(false));
				AssemblySubcontractorTable curAssemblySubcontractor = (AssemblySubcontractorTable) session.load(typeof(AssemblySubcontractorTable), id);

				SubcontractorTable subcontractorTable = getFromDatabase(session, newAssemblySubcontractor.SubcontractorTable, newAssemblyTable.Project, projectId, inResourceDatabase);
				// make the association
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					curAssemblyTable.AssemblySubcontractorSet.Add(curAssemblySubcontractor);
					//				subcontractorTable.getAssemblySubcontractorSet().add(curAssemblySubcontractor);
					curAssemblySubcontractor.SubcontractorTable = subcontractorTable;
					curAssemblySubcontractor.AssemblyTable = curAssemblyTable;
					session.update(curAssemblySubcontractor);
					//				session.update(subcontractorTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, subcontractorTable, curAssemblySubcontractor);
				}
			}

			iter = newAssemblyTable.AssemblyMaterialSet.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyMaterialTable newAssemblyMaterial = (AssemblyMaterialTable) iter.Current;
				long? id = (long?) session.save(newAssemblyMaterial.clone(false));
				AssemblyMaterialTable curAssemblyMaterial = (AssemblyMaterialTable) session.load(typeof(AssemblyMaterialTable), id);

				MaterialTable materialTable = getFromDatabase(session, newAssemblyMaterial.MaterialTable, newAssemblyTable.Project, projectId, inResourceDatabase);
				// make the association
				if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
				{
					curAssemblyTable.AssemblyMaterialSet.Add(curAssemblyMaterial);
					//				materialTable.getAssemblyMaterialSet().add(curAssemblyMaterial);
					curAssemblyMaterial.MaterialTable = materialTable;
					curAssemblyMaterial.AssemblyTable = curAssemblyTable;
					session.update(curAssemblyMaterial);
					//				session.update(materialTable);
					session.update(curAssemblyTable);
				}
				else
				{
					DatabaseDBUtil.associateAssemblyResource(curAssemblyTable, materialTable, curAssemblyMaterial);
				}
			}

			if (DatabaseDBUtil.LocalCommunication || !inResourceDatabase)
			{
				curAssemblyTable.calculateRate();
				session.update(curAssemblyTable);
			}
		}

		// deletes all associated entries does not remove Assembly it self
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deepRemove(org.hibernate.Session session, AssemblyTable assemblyTable, boolean removeUnassociatedResources) throws Exception
		public static void deepRemove(Session session, AssemblyTable assemblyTable, bool removeUnassociatedResources)
		{
			deepRemove(session, assemblyTable, removeUnassociatedResources, false, true);
		}

		//	public static void deepRemove(Session session, AssemblyTable assemblyTable,boolean removeUnassociatedResources, boolean isInProjectDatabase) {
		//		deepRemove(session, assemblyTable,removeUnassociatedResources,false, false);
		//	}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deepRemove(org.hibernate.Session session, AssemblyTable assemblyTable, boolean removeUnassociatedResources, boolean forceRemove, boolean inResourceDatabase) throws Exception
		public static void deepRemove(Session session, AssemblyTable assemblyTable, bool removeUnassociatedResources, bool forceRemove, bool inResourceDatabase)
		{
			deepRemove(session, assemblyTable, removeUnassociatedResources, forceRemove, inResourceDatabase, true);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void deepRemove(org.hibernate.Session session, AssemblyTable assemblyTable, boolean removeUnassociatedResources, boolean forceRemove, boolean inResourceDatabase, boolean flushDB) throws Exception
		public static void deepRemove(Session session, AssemblyTable assemblyTable, bool removeUnassociatedResources, bool forceRemove, bool inResourceDatabase, bool flushDB)
		{
			bool isLocalAccessDatabase = true;
			if (inResourceDatabase)
			{
				isLocalAccessDatabase = DatabaseDBUtil.LocalCommunication;
			}

			List<object> remVector = new List<object>();
			assemblyTable = (AssemblyTable) session.load(typeof(AssemblyTable), assemblyTable.AssemblyId);

			if (!isLocalAccessDatabase)
			{
				assemblyTable = ((AssemblyTable) assemblyTable).deepRoundCopy();
			}

			System.Collections.IEnumerator iter = assemblyTable.AssemblyLaborSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyLaborTable assLaborTable = (AssemblyLaborTable) iter.Current;
				LaborTable laborTable = assLaborTable.LaborTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || laborTable.Virtual;

					if (isLocalAccessDatabase)
					{
						laborTable.AssemblyLaborSet.remove(assLaborTable);
						assemblyTable.AssemblyLaborSet.remove(assLaborTable);
						assLaborTable.LaborTable = null;
						assLaborTable.AssemblyTable = null;

						session.update(laborTable);
						session.update(assemblyTable);
						session.update(assLaborTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assLaborTable);
						assLaborTable.LaborTable = null;
						assLaborTable.AssemblyTable = null;
						if (removeUnassociatedResources)
						{
							laborTable = (LaborTable) session.load(typeof(LaborTable), laborTable.Id);
						}
					}

					if (mustRemoveResource && ((laborTable.BoqItemLaborSet == null || laborTable.BoqItemLaborSet.Count == 0) && (laborTable.AssemblyLaborSet == null || laborTable.AssemblyLaborSet.Count == 0)))
					{
						// thats it delete it:
						session.delete(laborTable);
					}

					session.delete(assLaborTable);
				}
			}

			remVector.Clear();
			iter = assemblyTable.AssemblyConsumableSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyConsumableTable assConsumableTable = (AssemblyConsumableTable) iter.Current;
				ConsumableTable consumableTable = assConsumableTable.ConsumableTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || consumableTable.Virtual;

					if (isLocalAccessDatabase)
					{
						consumableTable.AssemblyConsumableSet.remove(assConsumableTable);
						assemblyTable.AssemblyConsumableSet.remove(assConsumableTable);
						assConsumableTable.ConsumableTable = null;
						assConsumableTable.AssemblyTable = null;

						session.update(consumableTable);
						session.update(assemblyTable);
						session.update(assConsumableTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assConsumableTable);
						assConsumableTable.ConsumableTable = null;
						assConsumableTable.AssemblyTable = null;
						if (mustRemoveResource)
						{
							consumableTable = (ConsumableTable) session.load(typeof(ConsumableTable), consumableTable.Id);
						}
					}

					if (mustRemoveResource && ((consumableTable.BoqItemConsumableSet == null || consumableTable.BoqItemConsumableSet.Count == 0) && (consumableTable.AssemblyConsumableSet == null || consumableTable.AssemblyConsumableSet.Count == 0)))
					{ // thats it delete it:
						session.delete(consumableTable);
					}
					session.delete(assConsumableTable);
				}
			}

			remVector.Clear();

			iter = assemblyTable.AssemblyEquipmentSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyEquipmentTable assEquipmentTable = (AssemblyEquipmentTable) iter.Current;
				EquipmentTable equipmentTable = assEquipmentTable.EquipmentTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || equipmentTable.Virtual;

					if (isLocalAccessDatabase)
					{
						equipmentTable.AssemblyEquipmentSet.remove(assEquipmentTable);
						assemblyTable.AssemblyEquipmentSet.remove(assEquipmentTable);
						assEquipmentTable.EquipmentTable = null;
						assEquipmentTable.AssemblyTable = null;

						session.update(equipmentTable);
						session.update(assemblyTable);
						session.update(assEquipmentTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assEquipmentTable);
						assEquipmentTable.EquipmentTable = null;
						assEquipmentTable.AssemblyTable = null;
						if (mustRemoveResource)
						{
							equipmentTable = (EquipmentTable) session.load(typeof(EquipmentTable), equipmentTable.Id);
						}
					}

					if (mustRemoveResource && ((equipmentTable.BoqItemEquipmentSet == null || equipmentTable.BoqItemEquipmentSet.Count == 0) && (equipmentTable.AssemblyEquipmentSet == null || equipmentTable.AssemblyEquipmentSet.Count == 0)))
					{
						// thats it delete it:				
						session.delete(equipmentTable);
					}
					session.delete(assEquipmentTable);
				}
			}

			remVector.Clear();

			iter = assemblyTable.AssemblySubcontractorSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblySubcontractorTable assSubcontractorTable = (AssemblySubcontractorTable) iter.Current;
				SubcontractorTable subcontractorTable = assSubcontractorTable.SubcontractorTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || subcontractorTable.Virtual;

					if (isLocalAccessDatabase)
					{
						subcontractorTable.AssemblySubcontractorSet.remove(assSubcontractorTable);
						assemblyTable.AssemblySubcontractorSet.remove(assSubcontractorTable);
						assSubcontractorTable.SubcontractorTable = null;
						assSubcontractorTable.AssemblyTable = null;

						session.update(subcontractorTable);
						session.update(assemblyTable);
						session.update(assSubcontractorTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assSubcontractorTable);
						assSubcontractorTable.SubcontractorTable = null;
						assSubcontractorTable.AssemblyTable = null;
						if (mustRemoveResource)
						{
							subcontractorTable = (SubcontractorTable) session.load(typeof(SubcontractorTable), subcontractorTable.Id);
						}
					}

					if (mustRemoveResource && ((subcontractorTable.BoqItemSubcontractorSet == null || subcontractorTable.BoqItemSubcontractorSet.Count == 0) && (subcontractorTable.AssemblySubcontractorSet == null || subcontractorTable.AssemblySubcontractorSet.Count == 0)))
					{
						// thats it delete it:				
						session.delete(subcontractorTable);
					}
					session.delete(assSubcontractorTable);
				}
			}

			remVector.Clear();

			iter = assemblyTable.AssemblyMaterialSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyMaterialTable assMaterialTable = (AssemblyMaterialTable) iter.Current;
				MaterialTable materialTable = assMaterialTable.MaterialTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || materialTable.Virtual;

					if (isLocalAccessDatabase)
					{
						materialTable.AssemblyMaterialSet.remove(assMaterialTable);
						assemblyTable.AssemblyMaterialSet.remove(assMaterialTable);
						assMaterialTable.MaterialTable = null;
						assMaterialTable.AssemblyTable = null;

						session.update(materialTable);
						session.update(assemblyTable);
						session.update(assMaterialTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assMaterialTable);
						assMaterialTable.MaterialTable = null;
						assMaterialTable.AssemblyTable = null;
						if (mustRemoveResource)
						{
							materialTable = (MaterialTable) session.load(typeof(MaterialTable), materialTable.Id);
						}
					}

					if (mustRemoveResource && ((materialTable.BoqItemMaterialSet == null || materialTable.BoqItemMaterialSet.Count == 0) && (materialTable.AssemblyMaterialSet == null || materialTable.AssemblyMaterialSet.Count == 0)))
					{
						// thats it delete it:
						if (materialTable.SupplierTable != null)
						{
							if (isLocalAccessDatabase)
							{
								SupplierTable supplierTable = materialTable.SupplierTable;
								supplierTable.MaterialSet.remove(materialTable);
								session.saveOrUpdate(supplierTable);
								materialTable.SupplierTable = null;
								session.update(materialTable);
								if (removeUnassociatedResources && supplierTable.MaterialSet.Count == 0)
								{
									materialTable.SupplierTable = null;
									session.delete(supplierTable);
								}
							}
							else
							{
								SupplierTable supplierTable = materialTable.SupplierTable;
								supplierTable = (SupplierTable) session.load(typeof(SupplierTable), supplierTable.Id);
								DatabaseDBUtil.deassociateMaterialFromSupplier(materialTable);
								if (removeUnassociatedResources && supplierTable.MaterialSet.Count == 0)
								{
									materialTable.SupplierTable = null;
									session.delete(supplierTable.clone());
								}
							}
						}
						session.delete(materialTable);
					}
					session.delete(assMaterialTable);
				}
			}

			remVector.Clear();
			iter = assemblyTable.AssemblyChildSet.GetEnumerator();
			while (iter.MoveNext())
			{
				remVector.Add(iter.Current);
			}
			iter = remVector.GetEnumerator();
			while (iter.MoveNext())
			{
				AssemblyAssemblyTable assAssemblyTable = (AssemblyAssemblyTable) iter.Current;
				AssemblyTable childTable = assAssemblyTable.ChildTable;

				if (forceRemove || assemblyTable.BoqItemAssemblySet == null || assemblyTable.BoqItemAssemblySet.Count == 0)
				{
					bool mustRemoveResource = removeUnassociatedResources || childTable.Virtual;

					if (isLocalAccessDatabase)
					{
						childTable.AssemblyParentSet.remove(assAssemblyTable);
						assemblyTable.AssemblyChildSet.remove(assAssemblyTable);
						assAssemblyTable.ChildTable = null;
						assAssemblyTable.ParentTable = null;

						session.update(childTable);
						session.update(assemblyTable);
						session.update(assAssemblyTable);
					}
					else
					{
						DatabaseDBUtil.deassociateAssemblyResource(assAssemblyTable);
						assAssemblyTable.ChildTable = null;
						assAssemblyTable.ParentTable = null;
						if (removeUnassociatedResources)
						{
							childTable = (AssemblyTable) session.load(typeof(AssemblyTable), childTable.Id);
						}
					}

					if (mustRemoveResource && ((childTable.BoqItemAssemblySet == null || childTable.BoqItemAssemblySet.Count == 0) && (childTable.AssemblyParentSet == null || childTable.AssemblyParentSet.Count == 0)))
					{
						// nobody else referencing this item so delete it:
						deepRemove(session, childTable, removeUnassociatedResources, forceRemove, inResourceDatabase, false);
						session.delete(childTable);
					}

					session.delete(assAssemblyTable);
				}
			}

			if (!isLocalAccessDatabase)
			{
				DatabaseDBUtil.recalculateAssemblyRate(assemblyTable);
				assemblyTable.Data = (AssemblyTable) session.load(typeof(AssemblyTable), assemblyTable.Id);
			}
			else
			{
				assemblyTable.recalculate(); // always 0!
			}

			session.update(assemblyTable);
			if (flushDB)
			{
				session.flush();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static AssemblyTable deepReplace(org.hibernate.Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, System.Nullable<long> projectId) throws Exception
		public static AssemblyTable deepReplace(Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, long? projectId)
		{
			return deepReplace(session, curAssemblyTable, newAssemblyTable, projectId, false);
		}

		// inside transaction with rela references
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static AssemblyTable deepReplace(org.hibernate.Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, System.Nullable<long> projectId, boolean inResourceDatabase) throws Exception
		public static AssemblyTable deepReplace(Session session, AssemblyTable curAssemblyTable, AssemblyTable newAssemblyTable, long? projectId, bool inResourceDatabase)
		{
			// 1st GET A REFERENCE FOR ALL BOQ ITEM ASSOCIATIONS
			List<object> boqItemAssemblyVector = new List<object>(curAssemblyTable.BoqItemAssemblySet.Count);

			System.Collections.IEnumerator iter = curAssemblyTable.BoqItemAssemblySet.GetEnumerator();
			while (iter.MoveNext())
			{
				BoqItemAssemblyTable cur = (BoqItemAssemblyTable) iter.Current;
				BoqItemAssemblyTable toSave = (BoqItemAssemblyTable) cur.clone();
				toSave.AssemblyTable = null;
				boqItemAssemblyVector.Add(toSave);

				BoqItemTable table = cur.BoqItemTable;
				table.BoqItemAssemblySet.remove(cur);
				session.update(table);
			}

			iter = boqItemAssemblyVector.GetEnumerator();
			// 2nd BREAK LINK OF ALL BOQ ITEM ASSOCIATIONS
			curAssemblyTable = (AssemblyTable) session.get(typeof(AssemblyTable), curAssemblyTable.Id);
			curAssemblyTable.BoqItemAssemblySet.Clear();
			session.update(curAssemblyTable);

			/*while ( iter.hasNext() ) {
				BoqItemAssemblyTable boqItemAssemblyTable =(BoqItemAssemblyTable)iter.next();
				AssemblyTable assemblyTable = boqItemAssemblyTable.getAssemblyTable();
				assemblyTable.getBoqItemAssemblySet().remove(boqItemAssemblyTable);
				session.update(assemblyTable);
			
				//boqItemAssemblyTable.setAssemblyTable(null); // this will remove the association
				//session.update(boqItemAssemblyTable); 
			}*/

			// 3rd DEEP REMOVE ASSEMBLY FROM DATABASE
			deepRemove(session, curAssemblyTable, true);
			curAssemblyTable = (AssemblyTable) session.get(typeof(AssemblyTable), curAssemblyTable.Id);
			//AssemblyTable dbAssemblyTable = (AssemblyTable)curAssemblyTable.clone();
			//session.delete(curAssemblyTable);
			//Long id = (Long)session.save(dbAssemblyTable);
			//curAssemblyTable = (AssemblyTable)session.get(AssemblyTable.class, id);

			// 4th DEEP PERSIST WITH NEW RESOURCES:
			deepPersist(session, curAssemblyTable, newAssemblyTable, projectId, inResourceDatabase);
			//curAssemblyTable = (AssemblyTable)session.get(AssemblyTable.class, curAssemblyTable.getId());

			// 5th PLACE BACK ASSEMBLY TO BOQ ITEM ASSEMBLIES LINK
			iter = boqItemAssemblyVector.GetEnumerator();
			while (iter.MoveNext())
			{
				BoqItemAssemblyTable boqitemAssemblyTable = (BoqItemAssemblyTable) iter.Current;
				BoqItemTable boqItemTable = (BoqItemTable) session.get(typeof(BoqItemTable), boqitemAssemblyTable.BoqItemTable.Id);

				boqitemAssemblyTable.BoqItemAssemblyId = null;
				boqitemAssemblyTable.BoqItemTable = null;
				boqitemAssemblyTable.AssemblyTable = null;
				long? id = (long?) session.save(boqitemAssemblyTable);
				boqitemAssemblyTable = (BoqItemAssemblyTable) session.get(typeof(BoqItemAssemblyTable), id);

				curAssemblyTable.BoqItemAssemblySet.Add(boqitemAssemblyTable);
				session.update(curAssemblyTable);

				boqItemTable.BoqItemAssemblySet.Add(boqitemAssemblyTable);
				session.update(boqItemTable);

				boqitemAssemblyTable.AssemblyTable = curAssemblyTable;
				boqitemAssemblyTable.BoqItemTable = boqItemTable;
				session.merge(boqitemAssemblyTable);

			}
			curAssemblyTable = (AssemblyTable) session.load(typeof(AssemblyTable), curAssemblyTable.Id);
			return curAssemblyTable;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static AssemblyTable deepPaste(org.hibernate.Session session, AssemblyTable originalAssembly) throws Exception
		public static AssemblyTable deepPaste(Session session, AssemblyTable originalAssembly)
		{
			DateTime today = DateTime.Now;
			AssemblyTable assemblyTosave = (AssemblyTable) originalAssembly.clone();
			assemblyTosave.EditorId = DatabaseDBUtil.Properties.UserId;
			assemblyTosave.CreateDate = today;
			assemblyTosave.LastUpdate = today;
			session.save(assemblyTosave);

			if (originalAssembly.AssemblyChildSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable originalAssemblyChild = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable assemblyChildToSave = (AssemblyAssemblyTable) originalAssemblyChild.clone(false);
					assemblyChildToSave.LastUpdate = today;
					assemblyChildToSave.ParentTable = assemblyTosave;
					assemblyChildToSave.ChildTable = originalAssemblyChild.ChildTable;
					session.save(assemblyChildToSave);
				}
			}
			if (originalAssembly.AssemblyEquipmentSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable originalChild = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable childToSave = (AssemblyEquipmentTable) originalChild.clone(false);
					childToSave.LastUpdate = today;
					childToSave.AssemblyTable = assemblyTosave;
					childToSave.EquipmentTable = originalChild.EquipmentTable;
					session.save(childToSave);
				}
			}
			if (originalAssembly.AssemblyMaterialSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable originalChild = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable childToSave = (AssemblyMaterialTable) originalChild.clone(false);
					childToSave.LastUpdate = today;
					childToSave.AssemblyTable = assemblyTosave;
					childToSave.MaterialTable = originalChild.MaterialTable;
					session.save(childToSave);
				}
			}
			if (originalAssembly.AssemblyLaborSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable originalChild = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable childToSave = (AssemblyLaborTable) originalChild.clone(false, false);
					childToSave.LastUpdate = today;
					childToSave.AssemblyTable = assemblyTosave;
					childToSave.LaborTable = originalChild.LaborTable;
					session.save(childToSave);
				}
			}
			if (originalAssembly.AssemblyConsumableSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable originalChild = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable childToSave = (AssemblyConsumableTable) originalChild.clone(false, false);
					childToSave.LastUpdate = today;
					childToSave.AssemblyTable = assemblyTosave;
					childToSave.ConsumableTable = originalChild.ConsumableTable;
					session.save(childToSave);
				}
			}
			if (originalAssembly.AssemblySubcontractorSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable originalChild = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable childToSave = (AssemblySubcontractorTable) originalChild.clone(false, false);
					childToSave.LastUpdate = today;
					childToSave.AssemblyTable = assemblyTosave;
					childToSave.SubcontractorTable = originalChild.SubcontractorTable;
					session.save(childToSave);
				}
			}

			return (AssemblyTable) assemblyTosave.deepCopy();

		}

		private static Dictionary<long, AssemblyTable> clonedAssembliesMap = new Dictionary<long, AssemblyTable>();
		private static Dictionary<long, EquipmentTable> clonedEquipmentMap = new Dictionary<long, EquipmentTable>();
		private static Dictionary<long, MaterialTable> clonedMaterialMap = new Dictionary<long, MaterialTable>();
		private static Dictionary<long, LaborTable> clonedlaborMap = new Dictionary<long, LaborTable>();
		private static Dictionary<long, ConsumableTable> clonedConsumableMap = new Dictionary<long, ConsumableTable>();
		private static Dictionary<long, SubcontractorTable> clonedSubcontractorMap = new Dictionary<long, SubcontractorTable>();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static AssemblyTable deepPasteasDuplicate(org.hibernate.Session session, AssemblyTable originalAssembly) throws Exception
		public static AssemblyTable deepPasteasDuplicate(Session session, AssemblyTable originalAssembly)
		{
			clonedAssembliesMap = new Dictionary<>();
			clonedEquipmentMap = new Dictionary<>();
			clonedMaterialMap = new Dictionary<>();
			clonedConsumableMap = new Dictionary<>();
			clonedSubcontractorMap = new Dictionary<>();
			clonedlaborMap = new Dictionary<>();
			AssemblyTable assemblyTable = makeDuplicatesAndSave(session, originalAssembly);

			clonedAssembliesMap = null;
			clonedEquipmentMap = null;
			clonedMaterialMap = null;
			clonedConsumableMap = null;
			clonedlaborMap = null;
			clonedSubcontractorMap = null;
			return assemblyTable;

		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static AssemblyTable makeDuplicatesAndSave(org.hibernate.Session session, AssemblyTable originalAssembly) throws Exception
		private static AssemblyTable makeDuplicatesAndSave(Session session, AssemblyTable originalAssembly)
		{
			DateTime today = DateTime.Now;
			string user = DatabaseDBUtil.Properties.UserId;
			AssemblyTable assemblyTosave = (AssemblyTable) originalAssembly.clone();
			assemblyTosave.EditorId = user;
			assemblyTosave.CreateDate = today;
			assemblyTosave.LastUpdate = today;
			assemblyTosave.Virtual = false;
			assemblyTosave.VirtualConsumable = false;
			assemblyTosave.VirtualEquipment = false;
			assemblyTosave.VirtualMaterial = false;
			assemblyTosave.VirtualSubcontractor = false;
			session.save(assemblyTosave);

			if (originalAssembly.AssemblyChildSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyChildSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyAssemblyTable relOriginalAssemblyChild = (AssemblyAssemblyTable) iter.Current;
					AssemblyAssemblyTable relAssemblyChildToSave = (AssemblyAssemblyTable) relOriginalAssemblyChild.clone(false);
					AssemblyTable assemblyChildToSave = clonedAssembliesMap[relOriginalAssemblyChild.ChildTable.Id];
					if (assemblyChildToSave == null)
					{
						assemblyChildToSave = makeDuplicatesAndSave(session, relOriginalAssemblyChild.ChildTable);
					}
					relAssemblyChildToSave.LastUpdate = today;
					relAssemblyChildToSave.ParentTable = assemblyTosave;
					relAssemblyChildToSave.ChildTable = assemblyChildToSave;
					session.save(relAssemblyChildToSave);
				}
			}
			if (originalAssembly.AssemblyEquipmentSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyEquipmentSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyEquipmentTable relOriginalChild = (AssemblyEquipmentTable) iter.Current;
					AssemblyEquipmentTable relChildToSave = (AssemblyEquipmentTable) relOriginalChild.clone(false);
					EquipmentTable childToSave = clonedEquipmentMap[relOriginalChild.EquipmentTable.Id];
					if (childToSave == null)
					{
						childToSave = (EquipmentTable) relOriginalChild.EquipmentTable.clone();
						childToSave.CreateDate = today;
						childToSave.LastUpdate = today;
						childToSave.EditorId = user;
						childToSave.Virtual = false;
						session.save(childToSave);
						clonedEquipmentMap[relOriginalChild.EquipmentTable.Id] = childToSave;
					}
					relChildToSave.LastUpdate = today;
					relChildToSave.AssemblyTable = assemblyTosave;
					relChildToSave.EquipmentTable = childToSave;
					session.save(relChildToSave);
				}
			}
			if (originalAssembly.AssemblyMaterialSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyMaterialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyMaterialTable relOriginalChild = (AssemblyMaterialTable) iter.Current;
					AssemblyMaterialTable relChildToSave = (AssemblyMaterialTable) relOriginalChild.clone(false);
					MaterialTable childToSave = clonedMaterialMap[relOriginalChild.MaterialTable.Id];
					if (childToSave == null)
					{
						childToSave = (MaterialTable) relOriginalChild.MaterialTable.clone();
						childToSave.CreateDate = today;
						childToSave.LastUpdate = today;
						childToSave.EditorId = user;
						childToSave.Virtual = false;
						session.save(childToSave);
						clonedMaterialMap[relOriginalChild.MaterialTable.Id] = childToSave;
					}
					relChildToSave.LastUpdate = today;
					relChildToSave.AssemblyTable = assemblyTosave;
					relChildToSave.MaterialTable = childToSave;
					session.save(relChildToSave);
				}
			}
			if (originalAssembly.AssemblyLaborSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyLaborSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyLaborTable relOriginalChild = (AssemblyLaborTable) iter.Current;
					AssemblyLaborTable relChildToSave = (AssemblyLaborTable) relOriginalChild.clone(false, false);
					LaborTable childToSave = clonedlaborMap[relOriginalChild.LaborTable.Id];
					if (childToSave == null)
					{
						childToSave = (LaborTable) relOriginalChild.LaborTable.clone();
						childToSave.CreateDate = today;
						childToSave.LastUpdate = today;
						childToSave.EditorId = user;
						childToSave.Virtual = false;
						session.save(childToSave);
						clonedlaborMap[relOriginalChild.LaborTable.Id] = childToSave;
					}
					relChildToSave.LastUpdate = today;
					relChildToSave.AssemblyTable = assemblyTosave;
					relChildToSave.LaborTable = childToSave;
					session.save(relChildToSave);
				}
			}
			if (originalAssembly.AssemblyConsumableSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblyConsumableSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblyConsumableTable relOriginalChild = (AssemblyConsumableTable) iter.Current;
					AssemblyConsumableTable relChildToSave = (AssemblyConsumableTable) relOriginalChild.clone(false, false);
					ConsumableTable childToSave = clonedConsumableMap[relOriginalChild.ConsumableTable.Id];
					if (childToSave == null)
					{
						childToSave = (ConsumableTable) relOriginalChild.ConsumableTable.clone();
						childToSave.CreateDate = today;
						childToSave.LastUpdate = today;
						childToSave.EditorId = user;
						childToSave.Virtual = false;
						session.save(childToSave);
						clonedConsumableMap[relOriginalChild.ConsumableTable.Id] = childToSave;
					}
					relChildToSave.LastUpdate = today;
					relChildToSave.AssemblyTable = assemblyTosave;
					relChildToSave.ConsumableTable = childToSave;
					session.save(relChildToSave);
				}
			}
			if (originalAssembly.AssemblySubcontractorSet != null)
			{
				System.Collections.IEnumerator iter = originalAssembly.AssemblySubcontractorSet.GetEnumerator();
				while (iter.MoveNext())
				{
					AssemblySubcontractorTable relOriginalChild = (AssemblySubcontractorTable) iter.Current;
					AssemblySubcontractorTable relChildToSave = (AssemblySubcontractorTable) relOriginalChild.clone(false, false);
					SubcontractorTable childToSave = clonedSubcontractorMap[relOriginalChild.SubcontractorTable.Id];
					if (childToSave == null)
					{
						childToSave = (SubcontractorTable) relOriginalChild.SubcontractorTable.clone();
						childToSave.CreateDate = today;
						childToSave.LastUpdate = today;
						childToSave.EditorId = user;
						childToSave.Virtual = false;
						session.save(childToSave);
						clonedSubcontractorMap[relOriginalChild.SubcontractorTable.Id] = childToSave;
					}
					relChildToSave.LastUpdate = today;
					relChildToSave.AssemblyTable = assemblyTosave;
					relChildToSave.SubcontractorTable = childToSave;
					session.save(relChildToSave);
				}
			}

			return assemblyTosave;

		}

		//	public static AssemblyTable deepPaste(Session session, AssemblyTable assemblyTable) throws Exception {
		//		//AssemblyTable originalTable = (AssemblyTable)assemblyTable.clone();
		//		assemblyTable.setEditorId(DatabaseDBUtil.getProperties().getUserId());
		//		AssemblyTable tableToSave = (AssemblyTable) assemblyTable.clone();
		//		tableToSave.recalculate(); // in case new table to setup not null values
		//		Long id = (Long) session.save(tableToSave);
		//		assemblyTable.setAssemblyId(id);
		//
		//		AssemblyTable newDBAssembly = (AssemblyTable) session.load(AssemblyTable.class, id);
		//
		//		if (assemblyTable.getAssemblyChildSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblyChildSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblyAssemblyTable assemblyChild = (AssemblyAssemblyTable) iter.next();
		//				//assemblyEquipment.setAssemblyEquipmentId(null);
		//				AssemblyTable childTable = assemblyChild.getChildTable();
		//				if (childTable.getVirtual() || childTable.getAssemblyId() == null) { // we create new instances for plugged in rates
		//					childTable.setAssemblyId(null);
		//					childTable.setAssemblyId((Long) session.save(childTable.clone()));
		//				}
		//				id = (Long) session.save(assemblyChild.clone(false));
		//				assemblyChild = (AssemblyAssemblyTable) session.load(AssemblyAssemblyTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					childTable = (AssemblyTable) session.load(AssemblyTable.class, childTable.getAssemblyId());
		//
		//					//					if ( childTable.getAssemblyParentSet() == null )
		//					//						childTable.setAssemblyParentSet(new HashSet());
		//					if (newDBAssembly.getAssemblyChildSet() == null)
		//						newDBAssembly.setAssemblyChildSet(new HashSet());
		//					//					// do the addition:
		//					newDBAssembly.getAssemblyChildSet().add(assemblyChild);
		//					//					childTable.getAssemblyParentSet().add(assemblyChild); 		 			
		//					assemblyChild.setChildTable(childTable);
		//					assemblyChild.setParentTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(childTable);
		//					session.update(assemblyChild);
		//				} else {
		//					assemblyChild = (AssemblyAssemblyTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, childTable, assemblyChild);
		//				}
		//			}
		//		}
		//		if (assemblyTable.getAssemblyEquipmentSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblyEquipmentSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblyEquipmentTable assemblyEquipment = (AssemblyEquipmentTable) iter.next();
		//				//assemblyEquipment.setAssemblyEquipmentId(null);
		//				EquipmentTable equipmentTable = assemblyEquipment.getEquipmentTable();
		//				if (equipmentTable.getVirtual() || equipmentTable.getEquipmentId() == null) { // we create new instances for plugged in rates
		//					equipmentTable.setEquipmentId(null);
		//					equipmentTable.setEquipmentId((Long) session.save(equipmentTable.clone()));
		//				}
		//				id = (Long) session.save(assemblyEquipment.clone(false));
		//				assemblyEquipment = (AssemblyEquipmentTable) session.load(AssemblyEquipmentTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					equipmentTable = (EquipmentTable) session.load(EquipmentTable.class, equipmentTable.getEquipmentId());
		//
		//					//					if ( equipmentTable.getAssemblyEquipmentSet() == null )
		//					//						equipmentTable.setAssemblyEquipmentSet(new HashSet());
		//					if (newDBAssembly.getAssemblyEquipmentSet() == null)
		//						newDBAssembly.setAssemblyEquipmentSet(new HashSet());
		//					//					// do the addition
		//					newDBAssembly.getAssemblyEquipmentSet().add(assemblyEquipment);
		//					//					equipmentTable.getAssemblyEquipmentSet().add(assemblyEquipment); 		 			
		//					assemblyEquipment.setEquipmentTable(equipmentTable);
		//					assemblyEquipment.setAssemblyTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(equipmentTable);
		//					session.update(assemblyEquipment);
		//				} else {
		//					assemblyEquipment = (AssemblyEquipmentTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, equipmentTable, assemblyEquipment);
		//				}
		//			}
		//		}
		//
		//		if (assemblyTable.getAssemblySubcontractorSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblySubcontractorSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblySubcontractorTable assemblySubcontractor = (AssemblySubcontractorTable) iter.next();
		//				//assemblySubcontractor.setAssemblySubcontractorId(null);
		//				SubcontractorTable subcontractorTable = assemblySubcontractor.getSubcontractorTable();
		//				if (subcontractorTable.getVirtual() || subcontractorTable.getSubcontractorId() == null) { // we create new instances for plugged in rates
		//					subcontractorTable.setSubcontractorId(null);
		//					subcontractorTable.setSubcontractorId((Long) session.save(subcontractorTable.clone()));
		//				}
		//				id = (Long) session.save(assemblySubcontractor.clone(false));
		//				assemblySubcontractor = (AssemblySubcontractorTable) session.load(AssemblySubcontractorTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					subcontractorTable = (SubcontractorTable) session.load(SubcontractorTable.class, subcontractorTable.getSubcontractorId());
		//
		//					//					if ( subcontractorTable.getAssemblySubcontractorSet() == null )
		//					//						subcontractorTable.setAssemblySubcontractorSet(new HashSet());
		//					if (newDBAssembly.getAssemblySubcontractorSet() == null)
		//						newDBAssembly.setAssemblySubcontractorSet(new HashSet());
		//					//					// do the addition
		//					newDBAssembly.getAssemblySubcontractorSet().add(assemblySubcontractor);
		//					//					subcontractorTable.getAssemblySubcontractorSet().add(assemblySubcontractor); 		 			
		//					assemblySubcontractor.setSubcontractorTable(subcontractorTable);
		//					assemblySubcontractor.setAssemblyTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(subcontractorTable);
		//					session.update(assemblySubcontractor);
		//				} else {
		//					assemblySubcontractor = (AssemblySubcontractorTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, subcontractorTable,
		//							assemblySubcontractor);
		//				}
		//			}
		//		}
		//
		//		if (assemblyTable.getAssemblyLaborSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblyLaborSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblyLaborTable assemblyLabor = (AssemblyLaborTable) iter.next();
		//				//assemblyLabor.setAssemblyLaborId(null);
		//				LaborTable laborTable = assemblyLabor.getLaborTable();
		//				if (laborTable.getVirtual() || laborTable.getLaborId() == null) { // we create new instances for plugged in rates
		//					laborTable.setLaborId(null);
		//					laborTable.setLaborId((Long) session.save(laborTable.clone()));
		//				}
		//				id = (Long) session.save(assemblyLabor.clone(false, false));
		//				assemblyLabor = (AssemblyLaborTable) session.load(AssemblyLaborTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					laborTable = (LaborTable) session.load(LaborTable.class, laborTable.getLaborId());
		//
		//					//					if ( laborTable.getAssemblyLaborSet() == null )
		//					//						laborTable.setAssemblyLaborSet(new HashSet());
		//					if (newDBAssembly.getAssemblyLaborSet() == null)
		//						newDBAssembly.setAssemblyLaborSet(new HashSet());
		//					//					// do the addition
		//					newDBAssembly.getAssemblyLaborSet().add(assemblyLabor);
		//					//					laborTable.getAssemblyLaborSet().add(assemblyLabor); 		 			
		//					assemblyLabor.setLaborTable(laborTable);
		//					assemblyLabor.setAssemblyTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(laborTable);
		//					session.update(assemblyLabor);
		//				} else {
		//					assemblyLabor = (AssemblyLaborTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, laborTable, assemblyLabor);
		//				}
		//			}
		//		}
		//
		//		if (assemblyTable.getAssemblyMaterialSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblyMaterialSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblyMaterialTable assemblyMaterial = (AssemblyMaterialTable) iter.next();
		//				//assemblyMaterial.setAssemblyMaterialId(null);
		//				MaterialTable materialTable = assemblyMaterial.getMaterialTable();
		//				if (materialTable.getVirtual() || materialTable.getMaterialId() == null) { // we create new instances for plugged in rates
		//					materialTable.setMaterialId(null);
		//					materialTable.setMaterialId((Long) session.save(materialTable.clone()));
		//				}
		//				id = (Long) session.save(assemblyMaterial.clone(false));
		//				assemblyMaterial = (AssemblyMaterialTable) session.load(AssemblyMaterialTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					materialTable = (MaterialTable) session.load(MaterialTable.class, materialTable.getMaterialId());
		//
		//					//					if ( materialTable.getAssemblyMaterialSet() == null )
		//					//						materialTable.setAssemblyMaterialSet(new HashSet());
		//					if (newDBAssembly.getAssemblyMaterialSet() == null)
		//						newDBAssembly.setAssemblyMaterialSet(new HashSet());
		//					//					// do the addition
		//					newDBAssembly.getAssemblyMaterialSet().add(assemblyMaterial);
		//					//					materialTable.getAssemblyMaterialSet().add(assemblyMaterial); 		 			
		//					assemblyMaterial.setMaterialTable(materialTable);
		//					assemblyMaterial.setAssemblyTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(materialTable);
		//					session.update(assemblyMaterial);
		//				} else {
		//					if (materialTable.getSupplierTable() != null) {
		//						DatabaseDBUtil.associateSupplierWithMaterial(materialTable.getSupplierTable(), materialTable);
		//					}
		//					materialTable.setSupplierTable(null);// just to lower down network traffic
		//					assemblyMaterial = (AssemblyMaterialTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, materialTable, assemblyMaterial);
		//				}
		//			}
		//		}
		//
		//		if (assemblyTable.getAssemblyConsumableSet() != null) {
		//			Iterator iter = assemblyTable.getAssemblyConsumableSet().iterator();
		//			while (iter.hasNext()) {
		//				AssemblyConsumableTable assemblyConsumable = (AssemblyConsumableTable) iter.next();
		//				//assemblyConsumable.setAssemblyConsumableId(null);
		//				ConsumableTable consumableTable = assemblyConsumable.getConsumableTable();
		//				if (consumableTable.getVirtual() || consumableTable.getConsumableId() == null) { // we create new instances for plugged in rates
		//					consumableTable.setConsumableId(null);
		//					consumableTable.setConsumableId((Long) session.save(consumableTable.clone()));
		//				}
		//				id = (Long) session.save(assemblyConsumable.clone(false));
		//				assemblyConsumable = (AssemblyConsumableTable) session.load(AssemblyConsumableTable.class, id);
		//
		//				if (DatabaseDBUtil.isLocalCommunication()) {
		//					consumableTable = (ConsumableTable) session.load(ConsumableTable.class, consumableTable.getConsumableId());
		//
		//					//					if ( consumableTable.getAssemblyConsumableSet() == null )
		//					//						consumableTable.setAssemblyConsumableSet(new HashSet());
		//					if (newDBAssembly.getAssemblyConsumableSet() == null)
		//						newDBAssembly.setAssemblyConsumableSet(new HashSet());
		//					//					// do the addition
		//					newDBAssembly.getAssemblyConsumableSet().add(assemblyConsumable);
		//					//					consumableTable.getAssemblyConsumableSet().add(assemblyConsumable); 		 			
		//					assemblyConsumable.setConsumableTable(consumableTable);
		//					assemblyConsumable.setAssemblyTable(newDBAssembly);
		//					//					session.update(newDBAssembly);
		//					//					session.update(consumableTable);
		//					session.update(assemblyConsumable);
		//				} else {
		//					assemblyConsumable = (AssemblyConsumableTable) DatabaseDBUtil.associateAssemblyResource(newDBAssembly, consumableTable, assemblyConsumable);
		//				}
		//			}
		//		}
		//
		//		if (!DatabaseDBUtil.isLocalCommunication()) {
		//			return (AssemblyTable) session.load(AssemblyTable.class, newDBAssembly.getId());
		//		}
		//		//session.flush();
		//
		//		//newDBAssembly = (AssemblyTable)session.load(AssemblyTable.class, newDBAssembly.getId()); // we can avoid this because we initialized the sets above.
		//		newDBAssembly.recalculate();
		//
		//		return (AssemblyTable) newDBAssembly.deepCopy();
		//	}

		public virtual BoqItemTable convertToNotExplodedBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool online, bool useProductivity)
		{
			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);
			long dbCreationDate = -1;
			if (!online)
			{
				dbCreationDate = CachedDBCreationDate;
			}
			else if (DatabaseCreationDate != null && DatabaseCreationDate.Value < 0)
			{
				dbCreationDate = DatabaseCreationDate.Value;
			}

			DateTime updateTime = new DateTime(DateTimeHelper.CurrentUnixTimeMillis());

			boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(Unit);
			boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(Unit);

			if (useProductivity)
			{
				boqTable.CalculationType = BoqItemTable.s_PRODUCTIVITY_METHOD;
			}
			else
			{
				boqTable.CalculationType = BoqItemTable.s_TOTAL_UNITS_METHOD;
			}
			boqTable.Productivity = BigDecimalMath.ONE;
			if (Quantity != null)
			{
				boqTable.Quantity = Quantity;
			}
			else
			{
				boqTable.Quantity = BigDecimalMath.ONE;
			}

			boqTable.PaymentDate = paymentDate;
			boqTable.LastUpdate = updateTime;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			AssemblyTable assemblyTable = (AssemblyTable) deepCopy();
			BoqItemAssemblyTable boqAssemblyTable = new BoqItemAssemblyTable();

			boqAssemblyTable.Factor1 = BigDecimalMath.ONE;
			boqAssemblyTable.Factor2 = BigDecimalMath.ONE;
			boqAssemblyTable.Factor3 = BigDecimalMath.ONE;

			boqAssemblyTable.QuantityPerUnit = BigDecimalMath.ONE;
			boqAssemblyTable.QuantityPerUnitFormula = "";
			boqAssemblyTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqAssemblyTable.LocalFactor = BigDecimalMath.ONE;
			boqAssemblyTable.LocalCountry = "";
			boqAssemblyTable.LocalStateProvince = "";

			boqAssemblyTable.TotalUnits = BigDecimalMath.ONE;
			boqAssemblyTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, assemblyTable.Currency, paymentDate);
			boqAssemblyTable.HasUserTotalUnits = false;
			boqAssemblyTable.LastUpdate = updateTime;

			boqAssemblyTable.AssemblyTable = assemblyTable;
			boqAssemblyTable.BoqItemTable = boqTable;

			assemblyTable.DatabaseCreationDate = dbCreationDate;
			assemblyTable.DatabaseId = assemblyTable.Id;
			boqTable.BoqItemAssemblySet.Add(boqAssemblyTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public virtual BoqItemTable convertToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool online, bool useProductivity, decimal quantity)
		{
			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);

			long dbCreationDate = -1; //ResourceUtil.ONLINE_DB_CREATE_DATE;
			if (!online)
			{
				dbCreationDate = CachedDBCreationDate;
			}
			else if (DatabaseCreationDate != null && DatabaseCreationDate.Value < 0)
			{
				dbCreationDate = DatabaseCreationDate.Value;
			}
			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(Unit);
			boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(Unit);
			boqTable.Quantity = quantity;

			if (useProductivity)
			{
				boqTable.CalculationType = BoqItemTable.s_PRODUCTIVITY_METHOD;
				boqTable.Productivity = Productivity;
				boqTable.ProductivityFormula = null;
			}
			else
			{
				boqTable.CalculationType = BoqItemTable.s_TOTAL_UNITS_METHOD;
				boqTable.Productivity = Productivity;
				boqTable.DurationFormula = null;

				//double productivity = getProductivity().doubleValue();

				ISet<object> set1 = AssemblyLaborSet;
				ISet<object> set2 = AssemblyEquipmentSet;
				//System.out.println("Set1: "+set1+" OR Set2"+set2);
				if ((set1 != null && set1.Count != 0) || (set2 != null && set2.Count != 0))
				{
					decimal duration = null;
					try
					{
						duration = BigDecimalMath.div(boqTable.Quantity, Productivity);
					}
					catch (ArithmeticException)
					{
						duration = BigDecimalMath.ZERO;
					}
					boqTable.Duration = duration;
				}
				else
				{
					boqTable.Duration = BigDecimalMath.ONE;
				}
			}

			boqTable.HasPVFormula = false;
			boqTable.PvVars = "";
			boqTable.Vars = Vars;

			boqTable.ActivityBased = ActivityBased;
			boqTable.PublishedItemCode = ItemCode;
			boqTable.PublishedRevisionCode = PublishedRevisionCode;
			boqTable.BimMaterial = BimMaterial;
			boqTable.BimType = BimType;
			boqTable.PaymentDate = paymentDate;
			boqTable.LastUpdate = updateTime;
			boqTable.CreateDate = updateTime;
			boqTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			boqTable.EditorId = boqTable.CreateUserId;
			boqTable.Accuracy = Accuracy;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			bool foundOne = false;
			IEnumerator<AssemblyAssemblyTable> iter0 = AssemblyChildSet.GetEnumerator();

			while (iter0.MoveNext())
			{
				AssemblyAssemblyTable assAssembly = iter0.Current;
				AssemblyTable assemblyTable = (AssemblyTable) assAssembly.ChildTable.deepRoundCopy();
				BoqItemAssemblyTable boqAssemblyTable = new BoqItemAssemblyTable();

				boqAssemblyTable.Factor1 = assAssembly.Factor1;
				boqAssemblyTable.Factor2 = assAssembly.Factor2;
				boqAssemblyTable.Factor3 = assAssembly.Factor3;

				boqAssemblyTable.QuantityPerUnit = assAssembly.QuantityPerUnit;
				boqAssemblyTable.QuantityPerUnitFormula = assAssembly.QuantityPerUnitFormula;
				boqAssemblyTable.QuantityPerUnitFormulaState = assAssembly.QuantityPerUnitFormulaState;

				boqAssemblyTable.LocalFactor = assAssembly.LocalFactor;
				boqAssemblyTable.LocalCountry = assAssembly.LocalCountry;
				boqAssemblyTable.LocalStateProvince = assAssembly.LocalStateProvince;
				boqAssemblyTable.TotalUnits = BigDecimalMath.ONE;
				boqAssemblyTable.ExchangeRate = BigDecimalMath.mult(assAssembly.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				boqAssemblyTable.HasUserTotalUnits = false;
				boqAssemblyTable.LastUpdate = assAssembly.LastUpdate;

				boqAssemblyTable.FixedCost = assAssembly.FixedCost;
				boqAssemblyTable.FinalFixedCost = assAssembly.FinalFixedCost;

				//boqEquipmentTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqAssemblyTable.AssemblyTable = assemblyTable;
				boqAssemblyTable.BoqItemTable = boqTable;

				if (assemblyTable.DatabaseCreationDate == null && assemblyTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					assemblyTable.DatabaseCreationDate = dbCreationDate;
					assemblyTable.DatabaseId = assemblyTable.Id;
				}
				boqTable.BoqItemAssemblySet.Add(boqAssemblyTable);
				foundOne = true;
			}

			IEnumerator<AssemblyEquipmentTable> iter1 = AssemblyEquipmentSet.GetEnumerator();

			while (iter1.MoveNext())
			{
				AssemblyEquipmentTable assEquipment = iter1.Current;
				EquipmentTable equipmentTable = (EquipmentTable) assEquipment.EquipmentTable.clone();
				BoqItemEquipmentTable boqEquipmentTable = new BoqItemEquipmentTable();

				boqEquipmentTable.Factor1 = assEquipment.Factor1;
				boqEquipmentTable.Factor2 = assEquipment.Factor2;
				boqEquipmentTable.Factor3 = assEquipment.Factor3;

				boqEquipmentTable.QuantityPerUnit = assEquipment.QuantityPerUnit;
				boqEquipmentTable.QuantityPerUnitFormula = assEquipment.QuantityPerUnitFormula;
				boqEquipmentTable.QuantityPerUnitFormulaState = assEquipment.QuantityPerUnitFormulaState;

				boqEquipmentTable.LocalFactor = assEquipment.LocalFactor;
				boqEquipmentTable.LocalCountry = assEquipment.LocalCountry;
				boqEquipmentTable.LocalStateProvince = assEquipment.LocalStateProvince;
				boqEquipmentTable.EnergyPrice = assEquipment.EnergyPrice;
				boqEquipmentTable.FinalFuelRate = assEquipment.FuelRate;
				boqEquipmentTable.TotalUnits = BigDecimalMath.ONE;
				boqEquipmentTable.ExchangeRate = BigDecimalMath.mult(assEquipment.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				boqEquipmentTable.HasUserTotalUnits = false;
				boqEquipmentTable.LastUpdate = assEquipment.LastUpdate;

				boqEquipmentTable.FixedCost = assEquipment.FixedCost;
				boqEquipmentTable.FinalFixedCost = assEquipment.FinalFixedCost;

				//boqEquipmentTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqEquipmentTable.EquipmentTable = equipmentTable;
				boqEquipmentTable.BoqItemTable = boqTable;

				if (equipmentTable.DatabaseCreationDate == null && equipmentTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					equipmentTable.DatabaseCreationDate = dbCreationDate;
					equipmentTable.DatabaseId = equipmentTable.Id;
				}

				boqTable.BoqItemEquipmentSet.Add(boqEquipmentTable);
				foundOne = true;
			}

			IEnumerator<AssemblySubcontractorTable> iter2 = AssemblySubcontractorSet.GetEnumerator();

			while (iter2.MoveNext())
			{
				AssemblySubcontractorTable assSubcontractor = iter2.Current;
				SubcontractorTable subcontractorTable = (SubcontractorTable) assSubcontractor.SubcontractorTable.clone();
				BoqItemSubcontractorTable boqSubcontractorTable = new BoqItemSubcontractorTable();

				boqSubcontractorTable.Factor1 = assSubcontractor.Factor1;
				boqSubcontractorTable.Factor2 = assSubcontractor.Factor2;
				boqSubcontractorTable.Factor3 = assSubcontractor.Factor3;

				boqSubcontractorTable.QuantityPerUnit = assSubcontractor.QuantityPerUnit;
				boqSubcontractorTable.QuantityPerUnitFormula = assSubcontractor.QuantityPerUnitFormula;
				boqSubcontractorTable.QuantityPerUnitFormulaState = assSubcontractor.QuantityPerUnitFormulaState;

				boqSubcontractorTable.LocalFactor = assSubcontractor.LocalFactor;
				boqSubcontractorTable.LocalCountry = assSubcontractor.LocalCountry;
				boqSubcontractorTable.LocalStateProvince = assSubcontractor.LocalStateProvince;
				boqSubcontractorTable.TotalUnits = BigDecimalMath.ONE;
				boqSubcontractorTable.ExchangeRate = BigDecimalMath.mult(assSubcontractor.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				boqSubcontractorTable.HasUserTotalUnits = false;
				boqSubcontractorTable.LastUpdate = assSubcontractor.LastUpdate;

				boqSubcontractorTable.FixedCost = assSubcontractor.FixedCost;
				boqSubcontractorTable.FinalFixedCost = assSubcontractor.FinalFixedCost;

				//boqSubcontractorTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqSubcontractorTable.SubcontractorTable = subcontractorTable;
				boqSubcontractorTable.BoqItemTable = boqTable;

				if (subcontractorTable.DatabaseCreationDate == null && subcontractorTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					subcontractorTable.DatabaseCreationDate = dbCreationDate;
					subcontractorTable.DatabaseId = subcontractorTable.Id;
				}

				subcontractorTable.DatabaseId = subcontractorTable.Id;
				boqTable.BoqItemSubcontractorSet.Add(boqSubcontractorTable);
				foundOne = true;
			}

			IEnumerator<AssemblyLaborTable> iter3 = AssemblyLaborSet.GetEnumerator();

			while (iter3.MoveNext())
			{
				AssemblyLaborTable assLabor = iter3.Current;
				LaborTable laborTable = (LaborTable) assLabor.LaborTable.clone();
				BoqItemLaborTable boqLaborTable = new BoqItemLaborTable();

				boqLaborTable.Factor1 = assLabor.Factor1;
				boqLaborTable.Factor2 = assLabor.Factor2;
				boqLaborTable.Factor3 = assLabor.Factor3;

				boqLaborTable.QuantityPerUnit = assLabor.QuantityPerUnit;
				boqLaborTable.QuantityPerUnitFormula = assLabor.QuantityPerUnitFormula;
				boqLaborTable.QuantityPerUnitFormulaState = assLabor.QuantityPerUnitFormulaState;

				boqLaborTable.LocalFactor = assLabor.LocalFactor;
				boqLaborTable.LocalCountry = assLabor.LocalCountry;
				boqLaborTable.LocalStateProvince = assLabor.LocalStateProvince;
				boqLaborTable.TotalUnits = BigDecimalMath.ONE;
				boqLaborTable.ExchangeRate = BigDecimalMath.mult(assLabor.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				//boqLaborTable.setExchangeRate(assLabor.getExchangeRate());//ExchangeRateUtil.findExchangeRate(prjDBUtil, laborTable.getCurrency(), paymentDate));
				boqLaborTable.HasUserTotalUnits = false;
				boqLaborTable.LastUpdate = assLabor.LastUpdate;

				boqLaborTable.FixedCost = assLabor.FixedCost;
				boqLaborTable.FinalFixedCost = assLabor.FinalFixedCost;

				//boqLaborTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqLaborTable.LaborTable = laborTable;
				boqLaborTable.BoqItemTable = boqTable;

				if (laborTable.DatabaseCreationDate == null && laborTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					laborTable.DatabaseCreationDate = dbCreationDate;
					laborTable.DatabaseId = laborTable.Id;
				}
				boqTable.BoqItemLaborSet.Add(boqLaborTable);
				foundOne = true;
			}

			IEnumerator<AssemblyMaterialTable> iter4 = AssemblyMaterialSet.GetEnumerator();

			while (iter4.MoveNext())
			{
				AssemblyMaterialTable assMaterial = iter4.Current;
				MaterialTable materialTable = (MaterialTable) assMaterial.MaterialTable.copyWithSupplier();

				BoqItemMaterialTable boqMaterialTable = new BoqItemMaterialTable();

				boqMaterialTable.Factor1 = assMaterial.Factor1;
				boqMaterialTable.Factor2 = assMaterial.Factor2;
				boqMaterialTable.Factor3 = assMaterial.Factor3;

				boqMaterialTable.QuantityPerUnit = assMaterial.QuantityPerUnit;
				boqMaterialTable.QuantityPerUnitFormula = assMaterial.QuantityPerUnitFormula;
				boqMaterialTable.QuantityPerUnitFormulaState = assMaterial.QuantityPerUnitFormulaState;

				boqMaterialTable.LocalFactor = assMaterial.LocalFactor;
				boqMaterialTable.LocalCountry = assMaterial.LocalCountry;
				boqMaterialTable.LocalStateProvince = assMaterial.LocalStateProvince;
				boqMaterialTable.TotalUnits = BigDecimalMath.ONE;
				boqMaterialTable.Escalation = ExchangeRateUtil.findRawMaterialRate(prjDBUtil, materialTable.RawMaterial, paymentDate);
				boqMaterialTable.ExchangeRate = BigDecimalMath.mult(assMaterial.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				//boqMaterialTable.setExchangeRate(assMaterial.getExchangeRate());//ExchangeRateUtil.findExchangeRate(prjDBUtil, materialTable.getCurrency(), paymentDate));
				boqMaterialTable.HasUserTotalUnits = false;
				boqMaterialTable.LastUpdate = assMaterial.LastUpdate;

				boqMaterialTable.FixedCost = assMaterial.FixedCost;
				boqMaterialTable.FinalFixedCost = assMaterial.FinalFixedCost;

				//boqMaterialTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqMaterialTable.MaterialTable = materialTable;
				boqMaterialTable.BoqItemTable = boqTable;

				if (materialTable.DatabaseCreationDate == null && materialTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					materialTable.DatabaseCreationDate = dbCreationDate;
					materialTable.DatabaseId = materialTable.Id;
				}

				if (materialTable.SupplierTable != null && materialTable.SupplierTable.DatabaseCreationDate == null && materialTable.SupplierTable.DatabaseId == null)
				{
					materialTable.SupplierTable.DatabaseCreationDate = dbCreationDate;
					materialTable.SupplierTable.DatabaseId = materialTable.SupplierTable.Id;
				}

				boqTable.BoqItemMaterialSet.Add(boqMaterialTable);
				foundOne = true;
			}

			IEnumerator<AssemblyConsumableTable> iter5 = AssemblyConsumableSet.GetEnumerator();

			while (iter5.MoveNext())
			{
				AssemblyConsumableTable assConsumable = iter5.Current;
				ConsumableTable consumableTable = (ConsumableTable) assConsumable.ConsumableTable.clone();
				BoqItemConsumableTable boqConsumableTable = new BoqItemConsumableTable();

				boqConsumableTable.Factor1 = assConsumable.Factor1;
				boqConsumableTable.Factor2 = assConsumable.Factor2;
				boqConsumableTable.Factor3 = assConsumable.Factor3;

				boqConsumableTable.QuantityPerUnit = assConsumable.QuantityPerUnit;
				boqConsumableTable.QuantityPerUnitFormula = assConsumable.QuantityPerUnitFormula;
				boqConsumableTable.QuantityPerUnitFormulaState = assConsumable.QuantityPerUnitFormulaState;

				boqConsumableTable.LocalFactor = assConsumable.LocalFactor;
				boqConsumableTable.LocalCountry = assConsumable.LocalCountry;
				boqConsumableTable.LocalStateProvince = assConsumable.LocalStateProvince;
				boqConsumableTable.ExchangeRate = BigDecimalMath.mult(assConsumable.ExchangeRate, ExchangeRateUtil.findExchangeRate(prjDBUtil, this.Currency, paymentDate));
				//boqConsumableTable.setExchangeRate(assConsumable.getExchangeRate());//ExchangeRateUtil.findExchangeRate(prjDBUtil, consumableTable.getCurrency(), paymentDate));

				boqConsumableTable.LocalFactor = assConsumable.LocalFactor;
				boqConsumableTable.LocalCountry = assConsumable.LocalCountry;
				boqConsumableTable.LocalStateProvince = assConsumable.LocalStateProvince;
				boqConsumableTable.TotalUnits = BigDecimalMath.ONE;
				boqConsumableTable.HasUserTotalUnits = false;
				boqConsumableTable.LastUpdate = assConsumable.LastUpdate;

				boqConsumableTable.FixedCost = assConsumable.FixedCost;
				boqConsumableTable.FinalFixedCost = assConsumable.FinalFixedCost;

				//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

				boqConsumableTable.ConsumableTable = consumableTable;
				boqConsumableTable.BoqItemTable = boqTable;

				if (consumableTable.DatabaseCreationDate == null && consumableTable.DatabaseId == null)
				{
					/* assume this comes from master database */
					consumableTable.DatabaseCreationDate = dbCreationDate;
					consumableTable.DatabaseId = consumableTable.Id;
				}

				boqTable.BoqItemConsumableSet.Add(boqConsumableTable);
				foundOne = true;
			}

			if (!foundOne)
			{
				boqTable.Status = "enum.boqstatus.pending";
			}

			boqTable.HasAssignmentFormula = assignmentsHaveBoqDependedFormula(boqTable);

			boqTable.recalculate();
			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;

			return boqTable;
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

		public virtual void calculateAccuracy()
		{
			bool hasEstimated = false;
			bool hasQuoted = false;

			if (AssemblyMaterialSet == null)
			{
				AssemblyMaterialSet = new HashSet<object>();
			}
			if (AssemblySubcontractorSet == null)
			{
				AssemblySubcontractorSet = new HashSet<object>();
			}
			if (AssemblyLaborSet == null)
			{
				AssemblyLaborSet = new HashSet<object>();
			}
			if (AssemblyEquipmentSet == null)
			{
				AssemblyEquipmentSet = new HashSet<object>();
			}
			if (AssemblyConsumableSet == null)
			{
				AssemblyConsumableSet = new HashSet<object>();
			}

			VirtualEquipment = false;
			VirtualSubcontractor = false;
			VirtualLabor = false;
			VirtualMaterial = false;
			VirtualConsumable = false;

			IEnumerator<AssemblyMaterialTable> iter1 = AssemblyMaterialSet.GetEnumerator();
			while (iter1.MoveNext())
			{
				AssemblyMaterialTable boqMatTable = iter1.Current;
				MaterialTable matTable = boqMatTable.MaterialTable;
				if (matTable.Virtual.Value)
				{
					VirtualMaterial = true;
				}
				if (matTable.Accuracy.Equals(MaterialTable.ESTIMATED_ACCURACY))
				{
					hasEstimated = true;
				}
				else
				{
					hasQuoted = true;
				}
			}

			IEnumerator<AssemblySubcontractorTable> iter2 = AssemblySubcontractorSet.GetEnumerator();
			while (iter2.MoveNext())
			{
				AssemblySubcontractorTable boqSubTable = iter2.Current;
				SubcontractorTable matTable = boqSubTable.SubcontractorTable;
				if (matTable.Virtual.Value)
				{
					VirtualSubcontractor = true;
				}
				if (matTable.Accuracy.Equals(SubcontractorTable.ESTIMATED_ACCURACY))
				{
					hasEstimated = true;
				}
				else
				{
					hasQuoted = true;
				}
			}

			IEnumerator<AssemblyLaborTable> iter4 = AssemblyLaborSet.GetEnumerator();
			while (iter4.MoveNext())
			{
				AssemblyLaborTable boqAssTable = iter4.Current;
				if (boqAssTable.LaborTable.Virtual.Value)
				{
					VirtualLabor = true;
				}
				hasEstimated = true;
			}

			IEnumerator<AssemblyEquipmentTable> iter5 = AssemblyEquipmentSet.GetEnumerator();
			while (iter5.MoveNext())
			{
				AssemblyEquipmentTable boqEquTable = iter5.Current;
				if (boqEquTable.EquipmentTable.Virtual.Value)
				{
					VirtualEquipment = true;
				}
				hasEstimated = true;
			}

			IEnumerator<AssemblyConsumableTable> iter6 = AssemblyConsumableSet.GetEnumerator();
			while (iter6.MoveNext())
			{
				AssemblyConsumableTable boqConTable = iter6.Current;
				if (boqConTable.ConsumableTable.Virtual.Value)
				{
					VirtualConsumable = true;
				}
				hasEstimated = true;
			}

			if ((!hasQuoted && hasEstimated) || (!hasQuoted && !hasEstimated))
			{
				Accuracy = s_ESTIMATED_ACCURACY;
			}
			else if (hasQuoted && hasEstimated)
			{
				Accuracy = s_BOTH_ACCURACY;
			}
			else if (hasQuoted && !hasEstimated)
			{
				Accuracy = s_QUOTED_ACCURACY;
			}
			else
			{
				Accuracy = s_ESTIMATED_ACCURACY;
			}
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getLastUpdate_sorted()
		public virtual DateTime LastUpdate_sorted
		{
			get
			{
				return lastUpdate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getCreateDate_sorted()
		public virtual DateTime CreateDate_sorted
		{
			get
			{
				return createDate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getQuantity_sorted()
		public virtual decimal Quantity_sorted
		{
			get
			{
				return quantity;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getAccuracy_sorted()
		public virtual string Accuracy_sorted
		{
			get
			{
				return accuracy;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getCreateUserId_sorted()
		public virtual string CreateUserId_sorted
		{
			get
			{
				return createUserId;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getLaborRate_sorted()
		public virtual decimal LaborRate_sorted
		{
			get
			{
				return laborRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getMaterialRate_sorted()
		public virtual decimal MaterialRate_sorted
		{
			get
			{
				return materialRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getSubcontractorRate_sorted()
		public virtual decimal SubcontractorRate_sorted
		{
			get
			{
				return subcontractorRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getConsumableRate_sorted()
		public virtual decimal ConsumableRate_sorted
		{
			get
			{
				return consumableRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getEquipmentRate_sorted()
		public virtual decimal EquipmentRate_sorted
		{
			get
			{
				return equipmentRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getBimMaterial_sorted()
		public virtual string BimMaterial_sorted
		{
			get
			{
				return bimMaterial;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getBimType_sorted()
		public virtual string BimType_sorted
		{
			get
			{
				return bimType;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getPublishedRevisionCode_sorted()
		public virtual string PublishedRevisionCode_sorted
		{
			get
			{
				return publishedRevisionCode;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getUnit_sorted()
		public virtual string Unit_sorted
		{
			get
			{
				return unit;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getProductivity_sorted()
		public virtual decimal Productivity_sorted
		{
			get
			{
				return productivity;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getPublishedRate_sorted()
		public virtual decimal PublishedRate_sorted
		{
			get
			{
				return publishedRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getGroupCode_sorted()
		public virtual string GroupCode_sorted
		{
			get
			{
				return groupCode;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getGekCode_sorted()
		public virtual string GekCode_sorted
		{
			get
			{
				return gekCode;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getEditorId_sorted()
		public virtual string EditorId_sorted
		{
			get
			{
				return editorId;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getTitle_sorted()
		public virtual string Title_sorted
		{
			get
			{
				return title;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getProject_sorted()
		public virtual string Project_sorted
		{
			get
			{
				return project;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getNotes_sorted()
		public virtual string Notes_sorted
		{
			get
			{
				return notes;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getCurrency_sorted()
		public virtual string Currency_sorted
		{
			get
			{
				return currency;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getStateProvince_sorted()
		public virtual string StateProvince_sorted
		{
			get
			{
				return stateProvince;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getCountry_sorted()
		public virtual string Country_sorted
		{
			get
			{
				return country;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getRate_sorted()
		public virtual decimal Rate_sorted
		{
			get
			{
				return rate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode1_sorted()
		public virtual string ExtraCode1_sorted
		{
			get
			{
				return extraCode1;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode2_sorted()
		public virtual string ExtraCode2_sorted
		{
			get
			{
				return extraCode2;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode3_sorted()
		public virtual string ExtraCode3_sorted
		{
			get
			{
				return extraCode3;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode4_sorted()
		public virtual string ExtraCode4_sorted
		{
			get
			{
				return extraCode4;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode5_sorted()
		public virtual string ExtraCode5_sorted
		{
			get
			{
				return extraCode5;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode6_sorted()
		public virtual string ExtraCode6_sorted
		{
			get
			{
				return extraCode6;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode7_sorted()
		public virtual string ExtraCode7_sorted
		{
			get
			{
				return extraCode7;
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
				return ""; //extraCode8;
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
				return ""; //extraCode9;
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
				return ""; //extraCode10;
			}
			set
			{
				this.extraCode10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="VARS" type="costos_text" </summary>
		/// <returns> Custom Line Item Variables (key:value pairs separated by ;) </returns>
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


		public override decimal TableRate
		{
			get
			{
				return Rate;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}

		public override ResourceTable Data
		{
			set
			{
				setData((AssemblyTable) value, false);
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (AssemblyTable) databaseTable);
		}

		//	@Override
		//	public void recalculateWithLocalVariables(HashMap<String, BigDecimal> localVarMap) {
		//		recalculate(true);
		//		
		//	}
		public override void recalculate()
		{
			recalculate(true);
		}

		public virtual void recalculate(bool fromResources)
		{
			if (Virtual == null)
			{
				Virtual = false;
			}
			if (Predicted == null)
			{
				Predicted = false;
			}
			calculateRate(fromResources);
			calculateFinalFixedCost();
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return AssemblyParentSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemAssemblySet == null)
				{
					boqItemAssemblySet = new HashSet<BoqItemAssemblyTable>();
				}
				return BoqItemAssemblySet;
			}
		}

		public override ISet<object> getResourceAssignments(string resourceName)
		{
			if (!string.ReferenceEquals(resourceName, null))
			{
				if (resourceName.Equals(LayoutTable.ASSEMBLY))
				{
					return AssemblyChildSet;
				}
				if (resourceName.Equals(LayoutTable.MATERIAL))
				{
					return AssemblyMaterialSet;
				}
				else if (resourceName.Equals(LayoutTable.LABOR))
				{
					return AssemblyLaborSet;
				}
				else if (resourceName.Equals(LayoutTable.SUBCONTRACTOR))
				{
					return AssemblySubcontractorSet;
				}
				else if (resourceName.Equals(LayoutTable.EQUIPMENT))
				{
					return AssemblyEquipmentSet;
				}
				else if (resourceName.Equals(LayoutTable.CONSUMABLE))
				{
					return AssemblyConsumableSet;
				}
			}

			ISet<object> set = new HashSet<object>();
			if (AssemblyMaterialSet != null)
			{
				set.addAll(AssemblyMaterialSet);
			}
			if (AssemblyLaborSet != null)
			{
				set.addAll(AssemblyLaborSet);
			}
			if (AssemblySubcontractorSet != null)
			{
				set.addAll(AssemblySubcontractorSet);
			}
			if (AssemblyEquipmentSet != null)
			{
				set.addAll(AssemblyEquipmentSet);
			}
			if (AssemblyChildSet != null)
			{
				set.addAll(AssemblyChildSet);
			}
			if (AssemblyConsumableSet != null)
			{
				set.addAll(AssemblyConsumableSet);
			}

			return set;
		}


		public override bool? Predicted
		{
			get
			{
				return false;
			}
		}

		public override bool? Quoted
		{
			get
			{
				if (string.ReferenceEquals(accuracy, null))
				{
					return false;
				}
				return Accuracy.Equals(s_QUOTED_ACCURACY);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return AssemblyHistorySet;
			}
			set
			{
				AssemblyHistorySet = value;
			}
		}


		public override System.Collections.IList ResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new LinkedList();
    
				if (AssemblyChildSet != null)
				{
					set.AddRange(AssemblyChildSet);
				}
				if (AssemblyEquipmentSet != null)
				{
					set.AddRange(AssemblyEquipmentSet);
				}
				if (AssemblySubcontractorSet != null)
				{
					set.AddRange(AssemblySubcontractorSet);
				}
				if (AssemblyLaborSet != null)
				{
					set.AddRange(AssemblyLaborSet);
				}
				if (AssemblyMaterialSet != null)
				{
					set.AddRange(AssemblyMaterialSet);
				}
				if (AssemblyConsumableSet != null)
				{
					set.AddRange(AssemblyConsumableSet);
				}
    
				return set;
			}
		}

		public override System.Collections.IList OrderedResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new LinkedList();
    
				if (AssemblyChildSet != null)
				{
					set.AddRange(orderedList(AssemblyChildSet));
				}
				if (AssemblyEquipmentSet != null)
				{
					set.AddRange(orderedList(AssemblyEquipmentSet));
				}
				if (AssemblySubcontractorSet != null)
				{
					set.AddRange(orderedList(AssemblySubcontractorSet));
				}
				if (AssemblyLaborSet != null)
				{
					set.AddRange(orderedList(AssemblyLaborSet));
				}
				if (AssemblyMaterialSet != null)
				{
					set.AddRange(orderedList(AssemblyMaterialSet));
				}
				if (AssemblyConsumableSet != null)
				{
					set.AddRange(orderedList(AssemblyConsumableSet));
				}
    
				return set;
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