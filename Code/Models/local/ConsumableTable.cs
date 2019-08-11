using System;
using System.Collections.Generic;

namespace Models.local
{



	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using PredictionTable = Desktop.common.nomitech.common.@base.PredictionTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = Desktop.common.nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using BoqItemConsumableTable = Desktop.common.nomitech.common.db.project.BoqItemConsumableTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using ConsumableHistoryTable = Desktop.common.nomitech.common.db.project.ConsumableHistoryTable;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = Desktop.common.nomitech.common.util.ExchangeRateUtil;
	using ImperialToMetric = Desktop.common.nomitech.common.util.ImperialToMetric;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="CONSUMABLE" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ConsumableTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.PredictionTable, nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class ConsumableTable : ResourceTable, PredictionTable, ProjectIdEntity, Transferable
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

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"consumableId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "rate", "currency", "project", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> consumableId;
		private long? consumableId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rate;
		private decimal rate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantity;
		private decimal quantity;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String project;
		private string project;
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

		private decimal buildUpRate;
		private bool? @virtual;
		private bool? predicted;
		private bool? conceptual;
		private int? overrideType;
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

		[NonSerialized]
		private ISet<object> boqItemConsumableSet;
		private ISet<AssemblyConsumableTable> assemblyConsumableSet = new HashSet<AssemblyConsumableTable>();
		private ISet<ConsumableHistoryTable> consumableHistorySet;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.consumableDataFlavor};

		public ConsumableTable()
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
			ConsumableTable obj = new ConsumableTable();

			obj.ConsumableId = ConsumableId;
			obj.ItemCode = ItemCode;
			obj.BuildUpRate = BuildUpRate;
			obj.OverrideType = OverrideType;
			obj.Title = Title;
			obj.LastUpdate = LastUpdate;
			obj.Virtual = Virtual;
			obj.Predicted = Predicted;
			obj.Conceptual = Conceptual;
			obj.TrendChartType = TrendChartType;
			obj.TrendValue = TrendValue;
			obj.TrendUnit = TrendUnit;
			obj.TrendColorCode = TrendColorCode;
			obj.TrendDate = TrendDate;
			obj.TrendRegType = TrendRegType;
			obj.TrendIds = TrendIds;
			obj.Description = Description;
			obj.Unit = Unit;
			obj.Project = Project;
			obj.StateProvince = StateProvince;
			obj.Country = Country;
			obj.Quantity = Quantity;
			obj.Rate = Rate;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Notes = Notes;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.Currency = Currency;
			obj.EditorId = EditorId;
			obj.AccessRights = AccessRights;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;

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

			return obj;
		}

		// For online databases only:
		public virtual object conversionClone(bool metric, bool demo)
		{
			ConsumableTable obj = (ConsumableTable)Clone();

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

		public virtual ConsumableTable copyToAssembly()
		{
			ConsumableTable obj = (ConsumableTable)Clone();

			ISet<AssemblyConsumableTable> assConsumableSet = new HashSet<AssemblyConsumableTable>();
			IEnumerator<AssemblyConsumableTable> iter = this.AssemblyConsumableSet.GetEnumerator();

			while (iter.MoveNext())
			{
				assConsumableSet.Add((AssemblyConsumableTable)iter.Current.clone(true,false));
			}
			obj.AssemblyConsumableSet = assConsumableSet;

			return obj;
		}

		public virtual ConsumableTable Data
		{
			set
			{
				//setConsumableId(value.getConsumableId());
				LastUpdate = value.LastUpdate;
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
				Description = value.Description;
				Project = value.Project;
				StateProvince = value.StateProvince;
				Country = value.Country;
				Unit = value.Unit;
				Rate = value.Rate;
				Quantity = value.Quantity;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				ItemCode = value.ItemCode;
				BuildUpRate = value.BuildUpRate;
				OverrideType = value.OverrideType;
				Title = value.Title;
				Notes = value.Notes;
				Currency = value.Currency;
				EditorId = value.EditorId;
				AccessRights = value.AccessRights;
				//setDatabaseId(value.getDatabaseId());
				//setDatabaseCreationDate(value.getDatabaseCreationDate());
    
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
    
				if (value.CreateDate != null)
				{
					CreateDate = value.CreateDate;
					CreateUserId = value.CreateUserId;
				}
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, ConsumableTable data)
		{

		}

		public override long? Id
		{
			get
			{
				return ConsumableId;
			}
			set
			{
				ConsumableId = value;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="CONSUMABLEID" </summary>
		/// <returns> Long </returns>
		public virtual long? ConsumableId
		{
			get
			{
				return consumableId;
			}
			set
			{
				consumableId = value;
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

		public virtual decimal RateForCalculation
		{
			get
			{
				if (BuildUpRate != null)
				{
					return BuildUpRate;
				}
				return Rate;
			}
		}

		/// <summary>
		/// QTY
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
		/// @hibernate.property column="NOTES" type="costos_string" </summary>
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
		/// @hibernate.property column="CURRENCY" type="costos_string" </summary>
		/// <returns> groupCode </returns>
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
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="CONSUMABLEID"
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

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="CONSUMABLEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemConsumableTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> BoqItemConsumableSet
		{
			get
			{
				return boqItemConsumableSet;
			}
			set
			{
				boqItemConsumableSet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return ConsumableId + ". " + Title;
		}
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="CONSUMABLEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.ConsumableHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> ConsumableHistorySet
		{
			get
			{
				return consumableHistorySet;
			}
			set
			{
				this.consumableHistorySet = value;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return ConsumableHistorySet;
			}
			set
			{
				ConsumableHistorySet = value;
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
			return DataFlavors.consumableDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.consumableDataFlavor.Equals(flavor))
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

			ConsumableTable consumableTable = (ConsumableTable)Clone();
			BoqItemConsumableTable boqConsumableTable = new BoqItemConsumableTable();

			boqConsumableTable.Factor1 = BigDecimalMath.ONE;
			boqConsumableTable.Factor2 = BigDecimalMath.ONE;
			boqConsumableTable.Factor3 = BigDecimalMath.ONE;

			boqConsumableTable.QuantityPerUnit = BigDecimalMath.ONE;
			boqConsumableTable.QuantityPerUnitFormula = "";
			boqConsumableTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqConsumableTable.LocalFactor = BigDecimalMath.ONE;
			boqConsumableTable.LocalCountry = "";
			boqConsumableTable.LocalStateProvince = "";

			boqConsumableTable.TotalUnits = BigDecimalMath.ONE;
			boqConsumableTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, consumableTable.Currency, paymentDate);
			boqConsumableTable.HasUserTotalUnits = false;
			boqConsumableTable.LastUpdate = updateTime;

			//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

			boqConsumableTable.ConsumableTable = consumableTable;
			boqConsumableTable.BoqItemTable = boqTable;

			consumableTable.DatabaseCreationDate = dbCreationDate;
			consumableTable.DatabaseId = consumableTable.Id;
			boqTable.BoqItemConsumableSet.Add(boqConsumableTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getQuantity_sorted()
		public virtual decimal Quantity_sorted
		{
			get
			{
				return quantity;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getLastUpdate_sorted()
		public virtual DateTime LastUpdate_sorted
		{
			get
			{
				return lastUpdate;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEditorId_sorted()
		public virtual string EditorId_sorted
		{
			get
			{
				return editorId;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getNotes_sorted()
		public virtual string Notes_sorted
		{
			get
			{
				return notes;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCurrency_sorted()
		public virtual string Currency_sorted
		{
			get
			{
				return currency;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCountry_sorted()
		public virtual string Country_sorted
		{
			get
			{
				return country;
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

		public override decimal TotalRate
		{
			get
			{
				return Rate;
			}
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (ConsumableTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (ConsumableTable)databaseTable);
		}

		public override void recalculate()
		{
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

			if (Virtual && AssemblyAssignments.Count > 1)
			{
				Virtual = false;
			}
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return AssemblyConsumableSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemConsumableSet == null)
				{
					boqItemConsumableSet = new HashSet<BoqItemConsumableTable>();
				}
				return BoqItemConsumableSet;
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