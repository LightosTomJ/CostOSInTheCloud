using System;
using System.Collections.Generic;

namespace Models.local
{


	using PredictionTable = Desktop.common.nomitech.common.@base.PredictionTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = Desktop.common.nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceToResourceTable = Desktop.common.nomitech.common.@base.ResourceToResourceTable;
	using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
	using BoqItemMaterialTable = Desktop.common.nomitech.common.db.project.BoqItemMaterialTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using MaterialHistoryTable = Desktop.common.nomitech.common.db.project.MaterialHistoryTable;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = Desktop.common.nomitech.common.util.ExchangeRateUtil;
	using ImperialToMetric = Desktop.common.nomitech.common.util.ImperialToMetric;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using IndexedEmbedded = org.hibernate.search.annotations.IndexedEmbedded;
	using Store = org.hibernate.search.annotations.Store;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="MATERIAL" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class MaterialTable extends nomitech.common.base.ResourceToResourceTable implements nomitech.common.base.PredictionTable, nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class MaterialTable : ResourceToResourceTable, PredictionTable, ProjectIdEntity, Transferable
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
		public static readonly string[] VIEWABLE_FIELDS = new string[] {"materialId", "itemCode", "title", "supplierName", "stateProvince", "country", "quantity", "unit", "rate", "fabricationRate", "shipmentRate", "totalRate", "currency", "weight", "weightUnit", "volFlow", "volFlowUnit", "massFlow", "massFlowUnit", "duty", "dutyUnit", "operPress", "operPressUnit", "operTemp", "operTempUnit", "rawMaterial", "rawMaterialReliance", "rawMaterial2", "rawMaterialReliance2", "rawMaterial3", "rawMaterialReliance3", "rawMaterial4", "rawMaterialReliance4", "rawMaterial5", "rawMaterialReliance5", "distanceToSite", "distanceUnit", "accuracy", "inclusion", "project", "bimType", "bimMaterial", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> materialId = null;
		private long? materialId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title = null;
		private string title = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimMaterial = null;
		private string bimMaterial = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bimType = null;
		private string bimType = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country = null;
		private string country = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit = null;
		private string unit = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rate = null;
		private decimal rate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal weight = null;
		private decimal weight = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String weightUnit = null;
		private string weightUnit = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantity = null;
		private decimal quantity = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode = null;
		private string groupCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode = null;
		private string gekCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rawMaterial = null;
		private string rawMaterial = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rawMaterialReliance = null;
		private decimal rawMaterialReliance = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rawMaterial2;
		private string rawMaterial2;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rawMaterialReliance2;
		private decimal rawMaterialReliance2;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rawMaterial3;
		private string rawMaterial3;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rawMaterialReliance3;
		private decimal rawMaterialReliance3;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rawMaterial4;
		private string rawMaterial4;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rawMaterialReliance4;
		private decimal rawMaterialReliance4;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String rawMaterial5;
		private string rawMaterial5;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rawMaterialReliance5;
		private decimal rawMaterialReliance5;

		private decimal buildUpRate;
		private int? overrideType;

		// New Fields by OIL & GAS:	
		private decimal volFlow;
		private decimal massFlow;
		private decimal duty;
		private decimal operPress;
		private decimal operTemp;

		private string volFlowUnit;
		private string massFlowUnit;
		private string dutyUnit;
		private string operTempUnit;
		private string operPressUnit;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String project = null;
		private string project = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes = null;
		private string notes = null;


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince = null;
		private string stateProvince = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String supplierName = null;
		private string supplierName = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency = null;
		private string currency = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate = null;
		private DateTime lastUpdate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date createDate;
		private DateTime createDate;

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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String accuracy;
		private string accuracy;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal shipmentRate;
		private decimal shipmentRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal fabricationRate;
		private decimal fabricationRate;
		private decimal totalRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String inclusion;
		private string inclusion;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal distanceToSite;
		private decimal distanceToSite;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String distanceUnit;
		private string distanceUnit;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @IndexedEmbedded(depth = 1, prefix = "supplier") private SupplierTable supplierTable = null;
		private SupplierTable supplierTable = null;
		private bool? @virtual;
		private bool? conceptual;

		private bool? predicted;
		// The prediction state
		private int? trendChartType;
		private decimal trendValue;
		private string trendUnit;
		private int? trendColorCode;
		private DateTime trendDate;
		private int? trendRegType;
		private string trendIds;
		private string accessRights;
		private string keywords;
		private string itemCode;

		private ISet<AssemblyMaterialTable> assemblyMaterialSet = new HashSet<AssemblyMaterialTable>();
		[NonSerialized]
		private ISet<object> boqItemMaterialSet;
		private ISet<MaterialHistoryTable> materialHistorySet;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.materialDataFlavor};

		public MaterialTable()
		{
		}

		public virtual object valueForField(string field)
		{
			return null;
		}
		public virtual object scaledValueForField(string field)
		{
			return null;
		}

		public virtual object Clone()
		{
			MaterialTable obj = new MaterialTable();

			obj.MaterialId = MaterialId;
			obj.ItemCode = ItemCode;
			obj.BuildUpRate = BuildUpRate;
			obj.OverrideType = OverrideType;
			obj.Title = Title;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Project = Project;
			obj.StateProvince = StateProvince;
			obj.SupplierName = SupplierName;
			obj.Country = Country;
			obj.Description = Description;
			obj.BimMaterial = BimMaterial;
			obj.BimType = BimType;
			obj.Notes = Notes;
			obj.LastUpdate = LastUpdate;
			obj.Virtual = Virtual;
			obj.Predicted = Predicted;
			obj.TrendChartType = TrendChartType;
			obj.TrendValue = TrendValue;
			obj.TrendUnit = TrendUnit;
			obj.TrendColorCode = TrendColorCode;
			obj.TrendDate = TrendDate;
			obj.TrendRegType = TrendRegType;
			obj.TrendIds = TrendIds;
			obj.Conceptual = Conceptual;
			obj.Rate = Rate;
			obj.Unit = Unit;
			obj.EditorId = EditorId;
			obj.DatabaseId = DatabaseId;
			obj.Currency = Currency;
			obj.RawMaterial = RawMaterial;
			obj.RawMaterialReliance = RawMaterialReliance;
			obj.RawMaterial2 = RawMaterial2;
			obj.RawMaterialReliance2 = RawMaterialReliance2;
			obj.RawMaterial3 = RawMaterial3;
			obj.RawMaterialReliance3 = RawMaterialReliance3;
			obj.RawMaterial4 = RawMaterial4;
			obj.RawMaterialReliance4 = RawMaterialReliance4;
			obj.RawMaterial5 = RawMaterial5;
			obj.RawMaterialReliance5 = RawMaterialReliance5;

			obj.VolFlow = VolFlow;
			obj.VolFlowUnit = VolFlowUnit;
			obj.MassFlow = MassFlow;
			obj.MassFlowUnit = MassFlowUnit;
			obj.Duty = Duty;
			obj.DutyUnit = DutyUnit;
			obj.OperPress = OperPress;
			obj.OperPressUnit = OperPressUnit;
			obj.OperTemp = OperTemp;
			obj.OperTempUnit = OperTempUnit;
			obj.AccessRights = AccessRights;

			obj.Weight = Weight;
			obj.WeightUnit = WeightUnit;
			obj.Quantity = Quantity;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.DistanceToSite = DistanceToSite;
			obj.DistanceUnit = DistanceUnit;
			obj.Inclusion = Inclusion;
			obj.ShipmentRate = ShipmentRate;
			obj.FabricationRate = FabricationRate;
			obj.TotalRate = TotalRate;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.Accuracy = Accuracy;

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

			obj.ProjectId = ProjectId;

			//if ( getSupplierTable() != null )
			//   obj.setSupplierTable((SupplierTable)getSupplierTable().clone());

			return obj;
		}

		// For online databases only:
		public virtual object conversionClone(bool metric, bool demo)
		{
			MaterialTable obj = (MaterialTable)Clone();
			if (metric)
			{
				obj.Rate = ImperialToMetric.getRate(unit, rate);
				obj.Unit = ImperialToMetric.getUnit(unit);
			}
			if (demo)
			{
				obj.Rate = BigDecimalMath.ZERO;
			}

			return obj;
		}

		public virtual MaterialTable copyToAssembly()
		{
			MaterialTable obj = (MaterialTable)Clone();

			ISet<AssemblyMaterialTable> assMaterialSet = new HashSet<AssemblyMaterialTable>();
			IEnumerator<AssemblyMaterialTable> iter = this.AssemblyMaterialSet.GetEnumerator();

			while (iter.MoveNext())
			{
				assMaterialSet.Add((AssemblyMaterialTable)iter.Current.clone(true,false));
			}
			obj.AssemblyMaterialSet = assMaterialSet;

			if (SupplierTable != null)
			{
				obj.SupplierTable = (SupplierTable)SupplierTable.clone();
			}

			return obj;
		}

		public virtual MaterialTable copyWithSupplier()
		{
			MaterialTable obj = (MaterialTable)Clone();

			if (SupplierTable != null)
			{
				obj.SupplierTable = (SupplierTable)SupplierTable.clone();
			}

			return obj;
		}

		public virtual MaterialTable conversionCopyWithSupplier(bool metric, bool demo)
		{
			MaterialTable obj = (MaterialTable)conversionClone(metric, demo);

			if (SupplierTable != null)
			{
				obj.SupplierTable = (SupplierTable)SupplierTable.clone();
			}

			return obj;
		}

		public virtual MaterialTable Data
		{
			set
			{
				//setMaterialId(matTable.getMaterialId());
				ItemCode = value.ItemCode;
				BuildUpRate = value.BuildUpRate;
				OverrideType = value.OverrideType;
				Title = value.Title;
				Virtual = value.Virtual;
				Predicted = value.Predicted;
				Conceptual = value.Conceptual;
				TrendChartType = value.TrendChartType;
				TrendValue = value.TrendValue;
				TrendUnit = value.TrendUnit;
				TrendColorCode = value.TrendColorCode;
				TrendDate = value.TrendDate;
				TrendRegType = value.TrendRegType;
				TrendIds = value.TrendIds;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				Project = value.Project;
				StateProvince = value.StateProvince;
				Country = value.Country;
				Description = value.Description;
				BimMaterial = value.BimMaterial;
				BimType = value.BimType;
				Notes = value.Notes;
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
				Rate = value.Rate;
				Unit = value.Unit;
				Currency = value.Currency;
				Weight = value.Weight;
				WeightUnit = value.WeightUnit;
				RawMaterial = value.RawMaterial;
				RawMaterialReliance = value.RawMaterialReliance;
				RawMaterial2 = value.RawMaterial2;
				RawMaterialReliance2 = value.RawMaterialReliance2;
				RawMaterial3 = value.RawMaterial3;
				RawMaterialReliance3 = value.RawMaterialReliance3;
				RawMaterial4 = value.RawMaterial4;
				RawMaterialReliance4 = value.RawMaterialReliance4;
				RawMaterial5 = value.RawMaterial5;
				RawMaterialReliance5 = value.RawMaterialReliance5;
    
				Quantity = value.Quantity;
				Accuracy = value.Accuracy;
				DistanceToSite = value.DistanceToSite;
				DistanceUnit = value.DistanceUnit;
				Inclusion = value.Inclusion;
				ShipmentRate = value.ShipmentRate;
				FabricationRate = value.FabricationRate;
				TotalRate = value.TotalRate;
				AccessRights = value.AccessRights;
    
				VolFlow = value.VolFlow;
				VolFlowUnit = value.VolFlowUnit;
				MassFlow = value.MassFlow;
				MassFlowUnit = value.MassFlowUnit;
				Duty = value.Duty;
				DutyUnit = value.DutyUnit;
				OperPress = value.OperPress;
				OperPressUnit = value.OperPressUnit;
				OperTemp = value.OperTemp;
				OperTempUnit = value.OperTempUnit;
    
				ExtraCode1 = value.ExtraCode1;
				ExtraCode2 = value.ExtraCode2;
				ExtraCode3 = value.ExtraCode3;
				ExtraCode4 = value.ExtraCode4;
				ExtraCode5 = value.ExtraCode5;
				ExtraCode6 = value.ExtraCode6;
				ExtraCode7 = value.ExtraCode7;
				ExtraCode8 = value.ExtraCode8;
				ExtraCode9 = value.ExtraCode9;
				ExtraCode10 = value.ExtraCode10;
    
				//setDatabaseId(matTable.getDatabaseId());
				//setDatabaseCreationDate(matTable.getDatabaseCreationDate());
    
				if (value.CreateDate != null)
				{
					CreateDate = value.CreateDate;
					CreateUserId = value.CreateUserId;
				}
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, MaterialTable data)
		{
		}

		public virtual long? Id
		{
			get
			{
				return MaterialId;
			}
			set
			{
				MaterialId = value;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="0"
		///               column="MATERIALID" </summary>
		/// <returns> Long </returns>
		public virtual long? MaterialId
		{
			get
			{
				return materialId;
			}
			set
			{
				materialId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ACCURACY" type="costos_string" </summary>
		/// <returns> status </returns>
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
		/// descrioption of the material
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
		/// @hibernate.property column="PREDICTED" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? Predicted
		{
			get
			{
				return predicted;
			}
			set
			{
				this.predicted = value;
			}
		}


		public virtual bool? Quoted
		{
			get
			{
				if (string.ReferenceEquals(accuracy, null))
				{
					return false;
				}
				return Accuracy.Equals(QUOTED_ACCURACY);
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TCHTYPE" type="int" </summary>
		/// <returns> BigDecimal </returns>
		public virtual int? TrendChartType
		{
			get
			{
				return trendChartType;
			}
			set
			{
				this.trendChartType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TVAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal TrendValue
		{
			get
			{
				return trendValue;
			}
			set
			{
				this.trendValue = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TUNIT" type="costos_string" </summary>
		/// <returns> BigDecimal </returns>
		public virtual string TrendUnit
		{
			get
			{
				return trendUnit;
			}
			set
			{
				this.trendUnit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TCOLOR" type="int" </summary>
		/// <returns> BigDecimal </returns>
		public virtual int? TrendColorCode
		{
			get
			{
				return trendColorCode;
			}
			set
			{
				this.trendColorCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TREGTYPE" type="int" </summary>
		/// <returns> BigDecimal </returns>
		public virtual int? TrendRegType
		{
			get
			{
				return trendRegType;
			}
			set
			{
				this.trendRegType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TRIDS" type="costos_text" </summary>
		/// <returns> BigDecimal </returns>
		public virtual string TrendIds
		{
			get
			{
				return trendIds;
			}
			set
			{
				this.trendIds = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TRDATE" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime TrendDate
		{
			get
			{
				return trendDate;
			}
			set
			{
				this.trendDate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONCEPTUAL" type="boolean" </summary>
		/// <returns> BigDecimal </returns>
		public virtual bool? Conceptual
		{
			get
			{
				return conceptual;
			}
			set
			{
				this.conceptual = value;
			}
		}


		/// <summary>
		/// descrioption of the material
		/// 
		/// @hibernate.property column="BIMMATERIAL" type="costos_text" </summary>
		/// <returns> description </returns>
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
		/// descrioption of the material
		/// 
		/// @hibernate.property column="BIMTYPE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// material country of origin
		/// 
		/// @hibernate.property column="COUNTRY" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string Country
		{
			get
			{
				return country;
			}
			set
			{
				country = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RAWMAT" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string RawMaterial
		{
			get
			{
				return rawMaterial;
			}
			set
			{
				this.rawMaterial = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="RELIANCE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RawMaterialReliance
		{
			get
			{
				return rawMaterialReliance;
			}
			set
			{
				this.rawMaterialReliance = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RAWMAT2" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string RawMaterial2
		{
			get
			{
				return rawMaterial2;
			}
			set
			{
				this.rawMaterial2 = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="RELIANCE2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RawMaterialReliance2
		{
			get
			{
				return rawMaterialReliance2;
			}
			set
			{
				this.rawMaterialReliance2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RAWMAT3" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string RawMaterial3
		{
			get
			{
				return rawMaterial3;
			}
			set
			{
				this.rawMaterial3 = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="RELIANCE3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RawMaterialReliance3
		{
			get
			{
				return rawMaterialReliance3;
			}
			set
			{
				this.rawMaterialReliance3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RAWMAT4" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string RawMaterial4
		{
			get
			{
				return rawMaterial4;
			}
			set
			{
				this.rawMaterial4 = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="RELIANCE4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RawMaterialReliance4
		{
			get
			{
				return rawMaterialReliance4;
			}
			set
			{
				this.rawMaterialReliance4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RAWMAT5" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string RawMaterial5
		{
			get
			{
				return rawMaterial5;
			}
			set
			{
				this.rawMaterial5 = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="RELIANCE5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal RawMaterialReliance5
		{
			get
			{
				return rawMaterialReliance5;
			}
			set
			{
				this.rawMaterialReliance5 = value;
			}
		}


		/// <summary>
		/// material unit of measure
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
		/// the cost per unit of the material
		/// 
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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
		/// the shipment rate per unit of the material
		/// 
		/// @hibernate.property column="SHIPRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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
		/// the shipment rate per unit of the material
		/// 
		/// @hibernate.property column="FABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
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


		/// 
		/// <summary>
		/// @hibernate.property column="TOTALRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) public java.math.BigDecimal getTotalRate()
		public virtual decimal TotalRate
		{
			get
			{
				return totalRate;
			}
			set
			{
				totalRate = value;
			}
		}

		public virtual decimal RateForCalculation
		{
			get
			{
				if (BuildUpRate != null)
				{
					return BuildUpRate;
				}
				return TotalRate;
			}
		}

		/// <summary>
		/// code of material group
		/// 
		/// @hibernate.property column="INCLUSION" type="costos_string" </summary>
		/// <returns> inclusion </returns>
		public virtual string Inclusion
		{
			get
			{
				return inclusion;
			}
			set
			{
				this.inclusion = value;
			}
		}


		/// <summary>
		/// distance to site
		/// 
		/// @hibernate.property column="DISTANCE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal DistanceToSite
		{
			get
			{
				return distanceToSite;
			}
			set
			{
				this.distanceToSite = value;
			}
		}


		/// <summary>
		/// distance unit
		/// 
		/// @hibernate.property column="DISTUNIT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string DistanceUnit
		{
			get
			{
				return distanceUnit;
			}
			set
			{
				this.distanceUnit = value;
			}
		}


		/// <summary>
		/// code of material group
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
		/// custom notes
		/// 
		/// @hibernate.property column="NOTES" type="costos_string" </summary>
		/// <returns> notes </returns>
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

		/// <summary>
		/// future
		/// 
		/// @hibernate.property column="STATEPROVINCE" type="costos_string" </summary>
		/// <returns> geographicalPlace </returns>
		public virtual string StateProvince
		{
			get
			{
				return stateProvince;
			}
			set
			{
				stateProvince = value;
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
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> name </returns>
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
		/// @hibernate.property column="SUPPLIERNAME" type="costos_string" </summary>
		/// <returns> name </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) public String getSupplierName()
		public virtual string SupplierName
		{
			get
			{
				return supplierName;
			}
			set
			{
				this.supplierName = value;
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
		/// the weight of the material
		/// 
		/// @hibernate.property column="WEIGHT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> weight </returns>
		public virtual decimal Weight
		{
			get
			{
				return weight;
			}
			set
			{
				this.weight = value;
			}
		}


		/// <summary>
		/// the weightUnit of the material
		/// 
		/// @hibernate.property column="WEIGHTUNIT" type="costos_string" </summary>
		/// <returns> weight </returns>
		public virtual string WeightUnit
		{
			get
			{
				return weightUnit;
			}
			set
			{
				this.weightUnit = value;
			}
		}


		/// <summary>
		/// the weight of the flowRate
		/// 
		/// @hibernate.property column="VOLFLOW" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> weight </returns>
		public virtual decimal VolFlow
		{
			get
			{
				return volFlow;
			}
			set
			{
				this.volFlow = value;
			}
		}


		/// <summary>
		/// the weight of the flowRate
		/// 
		/// @hibernate.property column="MSFLOW" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> weight </returns>
		public virtual decimal MassFlow
		{
			get
			{
				return massFlow;
			}
			set
			{
				this.massFlow = value;
			}
		}


		/// <summary>
		/// the weight of the flowRate
		/// 
		/// @hibernate.property column="DUTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> weight </returns>
		public virtual decimal Duty
		{
			get
			{
				return duty;
			}
			set
			{
				this.duty = value;
			}
		}


		/// <summary>
		/// the weight of the flowRate
		/// 
		/// @hibernate.property column="OPRES" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> weight </returns>
		public virtual decimal OperPress
		{
			get
			{
				return operPress;
			}
			set
			{
				this.operPress = value;
			}
		}


		/// <summary>
		/// the weight of the flowRate
		/// 
		/// @hibernate.property column="OPTMP" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> operTemp </returns>
		public virtual decimal OperTemp
		{
			get
			{
				return operTemp;
			}
			set
			{
				this.operTemp = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="VLFLOWUT" type="costos_string" </summary>
		/// <returns> volFlowUnit </returns>
		public virtual string VolFlowUnit
		{
			get
			{
				return volFlowUnit;
			}
			set
			{
				this.volFlowUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MSFLOWUT" type="costos_string" </summary>
		/// <returns> massFlowUnit </returns>
		public virtual string MassFlowUnit
		{
			get
			{
				return massFlowUnit;
			}
			set
			{
				this.massFlowUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DUTYUT" type="costos_string" </summary>
		/// <returns> dutyUnit </returns>
		public virtual string DutyUnit
		{
			get
			{
				return dutyUnit;
			}
			set
			{
				this.dutyUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OPTEMPUT" type="costos_string" </summary>
		/// <returns> dutyUnit </returns>
		public virtual string OperTempUnit
		{
			get
			{
				return operTempUnit;
			}
			set
			{
				this.operTempUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OPRESUT" type="costos_string" </summary>
		/// <returns> dutyUnit </returns>
		public virtual string OperPressUnit
		{
			get
			{
				return operPressUnit;
			}
			set
			{
				this.operPressUnit = value;
			}
		}


		/// <summary>
		/// the weight of the material
		/// 
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


		private long? databaseId = null;
		//#RXL_START
		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASEID" type="long" index="IDX_MDBID" index="IDX_MDBID" </summary>
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

		private long? databaseCreationDate = null;
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
		///  lazy="true"
		/// @hibernate.key
		///  column="MATERIALID"
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
		/// @hibernate.many-to-one
		///  column="SUPPLIERID"
		///  cascade="none" </summary>
		/// <returns> SupplierTable </returns>
		public virtual SupplierTable SupplierTable
		{
			get
			{
				return supplierTable;
			}
			set
			{
				this.supplierTable = value;
			}
		}
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="MATERIALID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemMaterialTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> BoqItemMaterialSet
		{
			get
			{
				return boqItemMaterialSet;
			}
			set
			{
				boqItemMaterialSet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return MaterialId + ". " + Title;
		}
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="MATERIALID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.MaterialHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> MaterialHistorySet
		{
			get
			{
				return materialHistorySet;
			}
			set
			{
				this.materialHistorySet = value;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return MaterialHistorySet;
			}
			set
			{
				MaterialHistorySet = value;
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
			return DataFlavors.materialDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.materialDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public virtual BoqItemTable convertToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool online, bool useProductivity)
		{
			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate,useProductivity);
			long dbCreationDate = -1;
			if (!online)
			{
				dbCreationDate = DatabaseDBUtil.Properties.getLongProperty("database.creationdate");
			}

			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(Unit);
			boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(Unit);
			boqTable.Code = code;
			if (useProductivity)
			{
				boqTable.CalculationType = BoqItemTable.s_PRODUCTIVITY_METHOD;
			}
			else
			{
				boqTable.CalculationType = BoqItemTable.s_TOTAL_UNITS_METHOD;
			}

			boqTable.LastUpdate = updateTime;
			boqTable.CreateDate = updateTime;
			boqTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			boqTable.EditorId = DatabaseDBUtil.Properties.UserId;
			boqTable.Accuracy = Accuracy;
			boqTable.BimMaterial = BimMaterial;
			boqTable.BimType = BimType;
			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			MaterialTable materialTable = (MaterialTable)copyWithSupplier();
			BoqItemMaterialTable boqMaterialTable = new BoqItemMaterialTable();

			boqMaterialTable.Factor1 = BigDecimalMath.ONE;
			boqMaterialTable.Factor2 = BigDecimalMath.ONE;
			boqMaterialTable.Factor3 = BigDecimalMath.ONE;

			boqMaterialTable.QuantityPerUnit = BigDecimalMath.ONE;
			boqMaterialTable.QuantityPerUnitFormula = "";
			boqMaterialTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqMaterialTable.LocalFactor = BigDecimalMath.ONE;
			boqMaterialTable.LocalCountry = "";
			boqMaterialTable.LocalStateProvince = "";
			boqMaterialTable.TotalUnits = BigDecimalMath.ONE;
			boqMaterialTable.Escalation = ExchangeRateUtil.findRawMaterialRate(prjDBUtil,materialTable.RawMaterial, paymentDate);
			boqMaterialTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, materialTable.Currency, paymentDate);
			boqMaterialTable.HasUserTotalUnits = false;
			boqMaterialTable.LastUpdate = updateTime;

			//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

			boqMaterialTable.MaterialTable = materialTable;
			boqMaterialTable.BoqItemTable = boqTable;

			materialTable.DatabaseCreationDate = dbCreationDate;
			materialTable.DatabaseId = materialTable.Id;
			boqTable.BoqItemMaterialSet.Add(boqMaterialTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		////////////////////////////////////////
		// SORTING FIELDS                     //
		////////////////////////////////////////
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getCreateDate_sorted()
		public virtual DateTime CreateDate_sorted
		{
			get
			{
				return createDate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getAccuracy_sorted()
		public virtual string Accuracy_sorted
		{
			get
			{
				return accuracy;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getInclusion_sorted()
		public virtual string Inclusion_sorted
		{
			get
			{
				return inclusion;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCreateUserId_sorted()
		public virtual string CreateUserId_sorted
		{
			get
			{
				return createUserId;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getWeightUnit_sorted()
		public virtual string WeightUnit_sorted
		{
			get
			{
				return weightUnit;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDistanceUnit_sorted()
		public virtual string DistanceUnit_sorted
		{
			get
			{
				return distanceUnit;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getRawMaterialUnit_sorted()
		public virtual string RawMaterialUnit_sorted
		{
			get
			{
				return rawMaterial;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getTitle_sorted()
		public virtual string Title_sorted
		{
			get
			{
				return title;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getBimMaterial_sorted()
		public virtual string BimMaterial_sorted
		{
			get
			{
				return bimMaterial;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getBimType_sorted()
		public virtual string BimType_sorted
		{
			get
			{
				return bimType;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCountry_sorted()
		public virtual string Country_sorted
		{
			get
			{
				return country;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getUnit_sorted()
		public virtual string Unit_sorted
		{
			get
			{
				return unit;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getRate_sorted()
		public virtual decimal Rate_sorted
		{
			get
			{
				return rate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getShipmentRate_sorted()
		public virtual decimal ShipmentRate_sorted
		{
			get
			{
				return shipmentRate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getTotalRate_sorted()
		public virtual decimal TotalRate_sorted
		{
			get
			{
				return totalRate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getWeight_sorted()
		public virtual decimal Weight_sorted
		{
			get
			{
				return weight;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getQuantity_sorted()
		public virtual decimal Quantity_sorted
		{
			get
			{
				return quantity;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getGroupCode_sorted()
		public virtual string GroupCode_sorted
		{
			get
			{
				return groupCode;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getGekCode_sorted()
		public virtual string GekCode_sorted
		{
			get
			{
				return gekCode;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getProject_sorted()
		public virtual string Project_sorted
		{
			get
			{
				return project;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEditorId_sorted()
		public virtual string EditorId_sorted
		{
			get
			{
				return editorId;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getNotes_sorted()
		public virtual string Notes_sorted
		{
			get
			{
				return notes;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getStateProvince_sorted()
		public virtual string StateProvince_sorted
		{
			get
			{
				return stateProvince;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getSupplierName_sorted()
		public virtual string SupplierName_sorted
		{
			get
			{
				return supplierName;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCurrency_sorted()
		public virtual string Currency_sorted
		{
			get
			{
				return currency;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getLastUpdate_sorted()
		public virtual DateTime LastUpdate_sorted
		{
			get
			{
				return lastUpdate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode1_sorted()
		public virtual string ExtraCode1_sorted
		{
			get
			{
				return extraCode1;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode2_sorted()
		public virtual string ExtraCode2_sorted
		{
			get
			{
				return extraCode2;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode3_sorted()
		public virtual string ExtraCode3_sorted
		{
			get
			{
				return extraCode3;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode4_sorted()
		public virtual string ExtraCode4_sorted
		{
			get
			{
				return extraCode4;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode5_sorted()
		public virtual string ExtraCode5_sorted
		{
			get
			{
				return extraCode5;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode6_sorted()
		public virtual string ExtraCode6_sorted
		{
			get
			{
				return extraCode6;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode7_sorted()
		public virtual string ExtraCode7_sorted
		{
			get
			{
				return extraCode7;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode8_sorted()
		public virtual string ExtraCode8_sorted
		{
			get
			{
				return extraCode8;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode9_sorted()
		public virtual string ExtraCode9_sorted
		{
			get
			{
				return extraCode9;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode10_sorted()
		public virtual string ExtraCode10_sorted
		{
			get
			{
				return extraCode10;
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

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="BURATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> description </returns>
		//#RXL_END
		public virtual decimal BuildUpRate
		{
			get
			{
				return buildUpRate;
			}
			set
			{
				this.buildUpRate = value;
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


		public override decimal TableRate
		{
			get
			{
				return RateForCalculation;
			}
			set
			{
				Rate = value;
			}
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (MaterialTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (MaterialTable)databaseTable);
		}

		public override void recalculate()
		{
			totalRate = BigDecimalMath.ZERO;

			if (Rate != null && ShipmentRate != null && FabricationRate != null)
			{
				totalRate = rate + shipmentRate + fabricationRate;
			}

			if (Quoted == null)
			{
				Quoted = false;
			}
			if (Virtual == null)
			{
				Virtual = false;
			}
			if (Predicted == null)
			{
				Predicted = false;
			}
			if (Conceptual == null)
			{
				Conceptual = false;
			}

			if (SupplierTable != null)
			{
				SupplierName = SupplierTable.Title;
			}
			else
			{
				SupplierName = "";
			}

			if (Virtual.Value && AssemblyAssignments.Count > 1)
			{
				Virtual = false;
			}
		}

		public override ResourceWithAssignmentsTable ParentResourceTable
		{
			get
			{
				return SupplierTable;
			}
			set
			{
				SupplierTable = (SupplierTable) value;
			}
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return AssemblyMaterialSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemMaterialSet == null)
				{
					boqItemMaterialSet = new HashSet<BoqItemMaterialTable>();
				}
    
				return BoqItemMaterialSet;
			}
		}


		public override ResourceToResourceTable copyWithParent()
		{
			return copyWithSupplier();
		}


		public override string ParentResourceTitle
		{
			get
			{
				return SupplierName;
			}
			set
			{
				SupplierName = value;
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