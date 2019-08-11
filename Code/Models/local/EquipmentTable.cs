using System;
using System.Collections.Generic;
using System.Numerics;

namespace Models.local
{


	using PredictionTable = Desktop.common.nomitech.common.@base.PredictionTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = Desktop.common.nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using BoqItemEquipmentTable = Desktop.common.nomitech.common.db.project.BoqItemEquipmentTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using EquipmentHistoryTable = Desktop.common.nomitech.common.db.project.EquipmentHistoryTable;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = Desktop.common.nomitech.common.util.ExchangeRateUtil;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="EQUIPMENT" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class EquipmentTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.PredictionTable, nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class EquipmentTable : ResourceTable, PredictionTable, ProjectIdEntity, Transferable
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

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"equipmentId", "itemCode", "title", "model", "make", "unit", "currency", "country", "stateProvince", "fuelType", "fuelConsumption", "depreciationRate", "lubricatesRate", "fuelRate", "tiresRate", "sparePartsRate", "reservationRate", "totalRate", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> equipmentId;
		private long? equipmentId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String fuelType;
		private string fuelType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode;
		private string groupCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode;
		private string gekCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal fuelConsumption;
		private decimal fuelConsumption;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal depreciationRate;
		private decimal depreciationRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal lubricatesRate;
		private decimal lubricatesRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal fuelRate;
		private decimal fuelRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal tiresRate;
		private decimal tiresRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal sparePartsRate;
		private decimal sparePartsRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal reservationRate;
		private decimal reservationRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String model;
		private string model;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String make;
		private string make;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency;
		private string currency;
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

		private bool? @virtual;
		private bool? predicted;
		private bool? conceptual;
		// The prediction state
		private int? trendChartType;
		private decimal trendValue;
		private string trendUnit;
		private int? trendColorCode;
		private DateTime trendDate;
		private int? trendRegType;
		private string trendIds;
		private string country;
		private string stateProvince;
		private string accessRights;
		private string keywords;
		private string itemCode;

		private decimal buildUpRate;
		private int? overrideType;

		private decimal initAquasitionPrice;
		private decimal salvageValue;
		private decimal interestRate;
		private BigInteger depreciationYears;
		private decimal occupationHoursPerMonth;
		private decimal occupationalFactor;
		private decimal totalRate;
		private int? depreciationCalculationMethod = new int?(0);

		private ISet<AssemblyEquipmentTable> assemblyEquipmentSet = new HashSet<AssemblyEquipmentTable>();
		[NonSerialized]
		private ISet<object> boqItemEquipmentSet;
		private ISet<EquipmentHistoryTable> equipmentHistorySet;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.equipmentDataFlavor};

		public EquipmentTable()
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
			EquipmentTable obj = new EquipmentTable();

			obj.EquipmentId = EquipmentId;
			obj.ItemCode = ItemCode;
			obj.BuildUpRate = BuildUpRate;
			obj.OverrideType = OverrideType;
			obj.Title = Title;
			obj.Model = Model;
			obj.Make = Make;
			obj.Unit = Unit;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.FuelType = FuelType;
			obj.FuelConsumption = FuelConsumption;
			obj.DepreciationRate = DepreciationRate;
			obj.FuelRate = FuelRate;
			obj.TiresRate = TiresRate;
			obj.LubricatesRate = LubricatesRate;
			obj.SparePartsRate = SparePartsRate;
			obj.ReservationRate = ReservationRate;
			obj.Description = Description;
			obj.Notes = Notes;
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
			obj.DepreciationCalculationMethod = DepreciationCalculationMethod;
			obj.InitAquasitionPrice = InitAquasitionPrice;
			obj.SalvageValue = SalvageValue;
			obj.InterestRate = InterestRate;
			obj.DepreciationYears = DepreciationYears;
			obj.OccupationHoursPerMonth = OccupationHoursPerMonth;
			obj.OccupationalFactor = OccupationalFactor;
			obj.Currency = Currency;
			obj.Country = Country;
			obj.StateProvince = StateProvince;
			obj.EditorId = EditorId;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.AccessRights = AccessRights;

			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;

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

			try
			{
				obj.TotalRate = TotalRate;
			}
			catch (System.NullReferenceException)
			{

			}

			return obj;
		}

		// For online databases only:
		public virtual object conversionClone(bool metric, bool demo)
		{
			EquipmentTable obj = (EquipmentTable) Clone();

			if (demo)
			{
				obj.DepreciationRate = BigDecimalMath.ZERO;
				obj.ReservationRate = BigDecimalMath.ZERO;
				obj.DepreciationRate = BigDecimalMath.ZERO;
				obj.FuelConsumption = BigDecimalMath.ZERO;
				obj.FuelRate = BigDecimalMath.ZERO;
				obj.LubricatesRate = BigDecimalMath.ZERO;
				obj.SparePartsRate = BigDecimalMath.ZERO;
				obj.TotalRate = BigDecimalMath.ZERO;
			}

			return obj;
		}

		public virtual EquipmentTable copyToAssembly()
		{
			EquipmentTable obj = (EquipmentTable) Clone();

			ISet<AssemblyEquipmentTable> assEquipmentSet = new HashSet<AssemblyEquipmentTable>();
			IEnumerator<AssemblyEquipmentTable> iter = this.AssemblyEquipmentSet.GetEnumerator();

			while (iter.MoveNext())
			{
				assEquipmentSet.Add((AssemblyEquipmentTable) iter.Current.clone(true, false));
			}
			obj.AssemblyEquipmentSet = assEquipmentSet;

			return obj;
		}

		public virtual EquipmentTable Data
		{
			set
			{
				//setEquipmentId(value.getEquipmentId());
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
				Model = value.Model;
				Make = value.Make;
				Unit = value.Unit;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				FuelType = value.FuelType;
				FuelConsumption = value.FuelConsumption;
				DepreciationRate = value.DepreciationRate;
				FuelRate = value.FuelRate;
				TiresRate = value.TiresRate;
				LubricatesRate = value.LubricatesRate;
				SparePartsRate = value.SparePartsRate;
				ReservationRate = value.ReservationRate;
				Description = value.Description;
				Notes = value.Notes;
				LastUpdate = value.LastUpdate;
				DepreciationCalculationMethod = value.DepreciationCalculationMethod;
				InitAquasitionPrice = value.InitAquasitionPrice;
				SalvageValue = value.SalvageValue;
				InterestRate = value.InterestRate;
				DepreciationYears = value.DepreciationYears;
				EditorId = value.EditorId;
				CreateDate = value.CreateDate;
				CreateUserId = value.CreateUserId;
				AccessRights = value.AccessRights;
    
				OccupationHoursPerMonth = value.OccupationHoursPerMonth;
				OccupationalFactor = value.OccupationalFactor;
				Currency = value.Currency;
				Country = value.Country;
				StateProvince = value.StateProvince;
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
				TotalRate = value.TotalRate;
    
				if (value.CreateDate != null)
				{
					CreateDate = value.CreateDate;
					CreateUserId = value.CreateUserId;
				}
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, EquipmentTable data)
		{
		}

		public virtual long? Id
		{
			get
			{
				return EquipmentId;
			}
			set
			{
				EquipmentId = value;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="EQUIPMENTID" </summary>
		/// <returns> Long </returns>
		public virtual long? EquipmentId
		{
			get
			{
				return equipmentId;
			}
			set
			{
				equipmentId = value;
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
		/// make
		/// 
		/// @hibernate.property column="MAKE" type="costos_string" </summary>
		/// <returns> make </returns>
		public virtual string Make
		{
			get
			{
				return make;
			}
			set
			{
				make = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MODEL" type="costos_string" </summary>
		/// <returns> model </returns>
		public virtual string Model
		{
			get
			{
				return model;
			}
			set
			{
				model = value;
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
		/// group code
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
		/// @hibernate.property column="FUELTYPE" type="costos_string" </summary>
		/// <returns> unit </returns>
		public virtual string FuelType
		{
			get
			{
				return fuelType;
			}
			set
			{
				fuelType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RESERVATIONRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> reservationRate </returns>
		public virtual decimal ReservationRate
		{
			get
			{
				return reservationRate;
			}
			set
			{
				reservationRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SPAREPARTSRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> sparePartsRate </returns>
		public virtual decimal SparePartsRate
		{
			get
			{
				return sparePartsRate;
			}
			set
			{
				sparePartsRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TIRESRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> tiresRate </returns>
		public virtual decimal TiresRate
		{
			get
			{
				return tiresRate;
			}
			set
			{
				tiresRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FUELRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fuelRate </returns>
		public virtual decimal FuelRate
		{
			get
			{
				return fuelRate;
			}
			set
			{
				fuelRate = value;
			}
		}


		public virtual decimal CalculatedFuelRate
		{
			get
			{
    
				if (BothDBPreferences.Instance.hasCustomFuelPrices())
				{
					if (FuelConsumption.CompareTo(BigDecimalMath.ZERO) <= 0)
					{
						return FuelRate;
					}
    
					decimal rate = BigDecimalMath.ZERO;
					decimal energyPrice = BothDBPreferences.Instance.getCustomFuelPrice(this);
					rate = FuelConsumption * energyPrice;
					return rate;
				}
    
				return FuelRate;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LUBRICATESRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> lubricatesRate </returns>
		public virtual decimal LubricatesRate
		{
			get
			{
				return lubricatesRate;
			}
			set
			{
				lubricatesRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DEPRECIATIONRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> depreciationRate </returns>
		public virtual decimal DepreciationRate
		{
			get
			{
				return depreciationRate;
			}
			set
			{
				depreciationRate = value;
			}
		}


		/// <summary>
		/// lt per unit
		/// 
		/// @hibernate.property column="FUELCONSUMPTION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fuelConsumption </returns>
		public virtual decimal FuelConsumption
		{
			get
			{
				return fuelConsumption;
			}
			set
			{
				fuelConsumption = value;
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
				this.country = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATE" type="costos_string" </summary>
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
		/// total rate
		/// 
		/// @hibernate.property column="TOTALRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fuelConsumption </returns>
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
		/// Description Here
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
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="DEPRECATION_CALC_METHOD" type="integer" </summary>
		/// <returns> lastUpdate </returns>
		public virtual int? DepreciationCalculationMethod
		{
			get
			{
				return depreciationCalculationMethod;
			}
			set
			{
				depreciationCalculationMethod = value;
			}
		}


		////////////////////////
		// DEPRECIATION CALCS

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="INIT_AQUASITION_PRICE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal InitAquasitionPrice
		{
			get
			{
				return initAquasitionPrice;
			}
			set
			{
				initAquasitionPrice = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SALVAGE_VALUE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SalvageValue
		{
			get
			{
				return salvageValue;
			}
			set
			{
				salvageValue = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="INTEREST_RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal InterestRate
		{
			get
			{
				return interestRate;
			}
			set
			{
				interestRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DEPRECIATION_YEARS" type="big_integer" precision="30" scale="10" </summary>
		/// <returns> BigInteger </returns>
		public virtual BigInteger DepreciationYears
		{
			get
			{
				return depreciationYears;
			}
			set
			{
				depreciationYears = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OCCUPATION_HOURS_PER_MONTH" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal OccupationHoursPerMonth
		{
			get
			{
				return occupationHoursPerMonth;
			}
			set
			{
				occupationHoursPerMonth = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OCCUPATIONAL_FACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal OccupationalFactor
		{
			get
			{
				return occupationalFactor;
			}
			set
			{
				occupationalFactor = value;
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
		///  column="EQUIPMENTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.AssemblyEquipmentTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
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


		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="EQUIPMENTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemEquipmentTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> BoqItemEquipmentSet
		{
			get
			{
				return boqItemEquipmentSet;
			}
			set
			{
				boqItemEquipmentSet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return EquipmentId + ". " + Title;
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="EQUIPMENTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.EquipmentHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> EquipmentHistorySet
		{
			get
			{
				return equipmentHistorySet;
			}
			set
			{
				this.equipmentHistorySet = value;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return EquipmentHistorySet;
			}
			set
			{
				EquipmentHistorySet = value;
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
			return DataFlavors.equipmentDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.equipmentDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public virtual BoqItemTable convertToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool online, bool useProductivity)
		{
			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);
			long dbCreationDate = -1;
			if (!online)
			{
				dbCreationDate = DatabaseDBUtil.Properties.getLongProperty("database.creationdate");
			}
			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(Unit);
			boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(Unit);
			boqTable.Code = code;

			boqTable.PaymentDate = paymentDate;
			boqTable.LastUpdate = updateTime;
			boqTable.CreateDate = updateTime;
			boqTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			boqTable.EditorId = DatabaseDBUtil.Properties.UserId;
			boqTable.Accuracy = BoqItemTable.s_ESTIMATED_ACCURACY;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			EquipmentTable equipmentTable = (EquipmentTable) Clone();
			BoqItemEquipmentTable boqEquipmentTable = new BoqItemEquipmentTable();

			boqEquipmentTable.Factor1 = BigDecimalMath.ONE;
			boqEquipmentTable.Factor2 = BigDecimalMath.ONE;
			boqEquipmentTable.Factor3 = BigDecimalMath.ONE;

			boqEquipmentTable.QuantityPerUnitFormula = "";
			boqEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqEquipmentTable.LocalFactor = BigDecimalMath.ONE;
			boqEquipmentTable.LocalCountry = "";
			boqEquipmentTable.LocalStateProvince = "";
			boqEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
			boqEquipmentTable.FinalFuelRate = equipmentTable.FuelRate;
			boqEquipmentTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, equipmentTable.Currency, paymentDate);
			boqEquipmentTable.HasUserTotalUnits = false;
			boqEquipmentTable.LastUpdate = updateTime;

			//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

			boqEquipmentTable.EquipmentTable = equipmentTable;
			boqEquipmentTable.BoqItemTable = boqTable;

			boqEquipmentTable.QuantityPerUnit = boqEquipmentTable.UnitHours;
			boqEquipmentTable.TotalUnits = boqEquipmentTable.UnitHours;

			equipmentTable.DatabaseCreationDate = dbCreationDate;
			equipmentTable.DatabaseId = equipmentTable.Id;
			boqTable.BoqItemEquipmentSet.Add(boqEquipmentTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public virtual AssemblyTable convertToAssembly()
		{
			AssemblyTable assemblyTable = BlankResourceInitializer.createBlankAssembly(this);
			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			assemblyTable.LastUpdate = updateTime;
			assemblyTable.CreateDate = updateTime;
			assemblyTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			assemblyTable.EditorId = assemblyTable.CreateUserId;

			assemblyTable.BoqItemAssemblySet = new HashSet<object>();
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblySubcontractorSet = new HashSet<object>();
			assemblyTable.AssemblyEquipmentSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();

			EquipmentTable equipmentTable = (EquipmentTable) Clone();
			equipmentTable.ResourceHistorySet = ResourceHistorySet;
			equipmentTable.recalculate();

			AssemblyEquipmentTable assEquipmentTable = new AssemblyEquipmentTable();

			assEquipmentTable.Factor1 = BigDecimalMath.ONE;
			assEquipmentTable.Factor2 = BigDecimalMath.ONE;
			assEquipmentTable.Factor3 = BigDecimalMath.ONE;

			assEquipmentTable.QuantityPerUnitFormula = "";
			assEquipmentTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			assEquipmentTable.LocalFactor = BigDecimalMath.ONE;
			assEquipmentTable.LocalCountry = "";
			assEquipmentTable.LocalStateProvince = "";
			assEquipmentTable.EnergyPrice = BigDecimalMath.ZERO;
			assEquipmentTable.ExchangeRate = BigDecimalMath.ONE;
			assEquipmentTable.LastUpdate = updateTime;

			assEquipmentTable.EquipmentTable = equipmentTable;
			assEquipmentTable.AssemblyTable = assemblyTable;

			assEquipmentTable.QuantityPerUnit = assEquipmentTable.UnitHours;

			assemblyTable.AssemblyEquipmentSet.Add(assEquipmentTable);

			assemblyTable.recalculate();

			return assemblyTable;
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getCreateDate_sorted()
		public virtual DateTime CreateDate_sorted
		{
			get
			{
				return createDate;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getNotes_sorted()
		public virtual string Notes_sorted
		{
			get
			{
				return notes;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getFuelType_sorted()
		public virtual string FuelType_sorted
		{
			get
			{
				return fuelType;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getFuelConsumption_sorted()
		public virtual decimal FuelConsumption_sorted
		{
			get
			{
				return fuelConsumption;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getDepreciationRate_sorted()
		public virtual decimal DepreciationRate_sorted
		{
			get
			{
				return depreciationRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getLubricatesRate_sorted()
		public virtual decimal LubricatesRate_sorted
		{
			get
			{
				return lubricatesRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getFuelRate_sorted()
		public virtual decimal FuelRate_sorted
		{
			get
			{
				return fuelRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getTiresRate_sorted()
		public virtual decimal TiresRate_sorted
		{
			get
			{
				return tiresRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getSparePartsRate_sorted()
		public virtual decimal SparePartsRate_sorted
		{
			get
			{
				return sparePartsRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getReservationRate_sorted()
		public virtual decimal ReservationRate_sorted
		{
			get
			{
				return reservationRate;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getModel_sorted()
		public virtual string Model_sorted
		{
			get
			{
				return model;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getMake_sorted()
		public virtual string Make_sorted
		{
			get
			{
				return make;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getTitle_sorted()
		public virtual string Title_sorted
		{
			get
			{
				return title;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCurrency_sorted()
		public virtual string Currency_sorted
		{
			get
			{
				return currency;
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
				ReservationRate = value;
			}
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (EquipmentTable) value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (EquipmentTable) databaseTable);
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


		public override void recalculate()
		{
			totalRate = BigDecimalMath.ZERO;
			//totalRate = totalRate.add(getFuelConsumption());
			if (LubricatesRate != null)
			{
				totalRate = totalRate + LubricatesRate;
			}
			if (SparePartsRate != null)
			{
				totalRate = totalRate + SparePartsRate;
			}
			if (TiresRate != null)
			{
				totalRate = totalRate + TiresRate;
			}
			if (CalculatedFuelRate != null)
			{
				totalRate = totalRate + FuelRate;
			}
			if (DepreciationRate != null)
			{
				totalRate = totalRate + DepreciationRate;
			}
			if (ReservationRate != null)
			{
				totalRate = totalRate + ReservationRate;
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
			if (Virtual && AssemblyAssignments.Count > 1)
			{
				Virtual = false;
			}
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return AssemblyEquipmentSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemEquipmentSet == null)
				{
					boqItemEquipmentSet = new HashSet<BoqItemEquipmentTable>();
				}
				return BoqItemEquipmentSet;
			}
		}

		private decimal qty;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.math.BigDecimal getQuantity()
		public override decimal Quantity
		{
			get
			{
				return qty;
			}
			set
			{
				this.qty = value;
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