using System;
using System.Collections.Generic;

namespace Models.local
{


	using PredictionTable = nomitech.common.@base.PredictionTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using BoqItemSubcontractorTable = nomitech.common.db.project.BoqItemSubcontractorTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = nomitech.common.util.ExchangeRateUtil;
	using ImperialToMetric = nomitech.common.util.ImperialToMetric;
	using Unit1ToUnit2Util = nomitech.common.util.Unit1ToUnit2Util;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="SUBCONTRACTOR" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class SubcontractorTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.PredictionTable, nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class SubcontractorTable : ResourceTable, PredictionTable, ProjectIdEntity, Transferable
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

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"subcontractorId", "itemCode", "title", "stateProvince", "country", "quantity", "unit", "rate", "subMaterialRate", "IKA", "totalRate", "currency", "accuracy", "inclusion", "project", "performance", "company", "contactPerson", "phoneNumber", "mobileNumber", "faxNumber", "email", "address", "city", "url", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> subcontractorId;
		private long? subcontractorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rate;
		private decimal rate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal IKA;
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private decimal IKA_Conflict;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal subMaterialRate;
		private decimal subMaterialRate;
		private decimal totalRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal quantity;
		private decimal quantity;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String contactPerson;
		private string contactPerson;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String company;
		private string company;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String phoneNumber;
		private string phoneNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String mobileNumber;
		private string mobileNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String faxNumber;
		private string faxNumber;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String performance;
		private string performance;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String project;
		private string project;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String email;
		private string email;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String url;
		private string url;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country;
		private string country;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String city;
		private string city;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince;
		private string stateProvince;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String address;
		private string address;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency;
		private string currency;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String accuracy;
		private string accuracy;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String inclusion;
		private string inclusion;
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

		private decimal buildUpRate;
		private int? overrideType;

		private bool? conceptual;
		private ISet<AssemblySubcontractorTable> assemblySubcontractorSet = new HashSet<AssemblySubcontractorTable>();
		[NonSerialized]
		private ISet<object> boqItemSubcontractorSet;
		private ISet<object> subcontractorHistorySet;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.subcontractorDataFlavor};

		public SubcontractorTable()
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

		public virtual object clone()
		{
			SubcontractorTable obj = new SubcontractorTable();

			obj.Address = Address;
			obj.ItemCode = ItemCode;
			obj.BuildUpRate = BuildUpRate;
			obj.OverrideType = OverrideType;
			obj.Title = Title;
			obj.ContactPerson = ContactPerson;
			obj.SubcontractorId = SubcontractorId;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Performance = Performance;
			obj.Project = Project;
			obj.Description = Description;
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
			obj.Notes = Notes;
			obj.EditorId = EditorId;
			obj.PhoneNumber = PhoneNumber;
			obj.MobileNumber = MobileNumber;
			obj.Email = Email;
			obj.Country = Country;
			obj.City = City;
			obj.StateProvince = StateProvince;
			obj.Rate = Rate;
			obj.SubMaterialRate = SubMaterialRate;
			obj.IKA = IKA;
			obj.Quantity = Quantity;
			obj.TotalRate = TotalRate;
			obj.Unit = Unit;
			obj.Url = Url;
			obj.Company = Company;
			obj.FaxNumber = FaxNumber;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.Currency = Currency;
			obj.Accuracy = Accuracy;
			obj.Inclusion = Inclusion;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.AccessRights = AccessRights;

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
			SubcontractorTable obj = (SubcontractorTable)clone();
			if (metric)
			{
				obj.IKA = ImperialToMetric.getRate(unit, IKA_Conflict);
				obj.Rate = ImperialToMetric.getRate(unit, rate);
				obj.SubMaterialRate = ImperialToMetric.getRate(unit, subMaterialRate);
				obj.TotalRate = ImperialToMetric.getRate(unit, totalRate);
				obj.Unit = ImperialToMetric.getUnit(unit);
			}
			if (demo)
			{
				obj.IKA = BigDecimalMath.ZERO;
				obj.Rate = BigDecimalMath.ZERO;
				obj.SubMaterialRate = BigDecimalMath.ZERO;
				obj.TotalRate = BigDecimalMath.ZERO;
			}
			return obj;
		}

		public virtual SubcontractorTable copyToAssembly()
		{
			SubcontractorTable obj = (SubcontractorTable)clone();

			ISet<AssemblySubcontractorTable> assSubcontractorSet = new HashSet<AssemblySubcontractorTable>();
			IEnumerator<AssemblySubcontractorTable> iter = this.AssemblySubcontractorSet.GetEnumerator();

			while (iter.MoveNext())
			{
				assSubcontractorSet.Add((AssemblySubcontractorTable)iter.Current.clone(true,false));
			}
			obj.AssemblySubcontractorSet = assSubcontractorSet;

			return obj;
		}

		public virtual SubcontractorTable Data
		{
			set
			{
				Address = value.Address;
				Virtual = value.Virtual;
				Predicted = value.Predicted;
				TrendChartType = value.TrendChartType;
				TrendValue = value.TrendValue;
				TrendUnit = value.TrendUnit;
				TrendColorCode = value.TrendColorCode;
				TrendDate = value.TrendDate;
				TrendRegType = value.TrendRegType;
				TrendIds = value.TrendIds;
				Conceptual = value.Conceptual;
				ItemCode = value.ItemCode;
				BuildUpRate = value.BuildUpRate;
				OverrideType = value.OverrideType;
				Title = value.Title;
				ContactPerson = value.ContactPerson;
				//setSubcontractorId(value.getSubcontractorId());
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				Performance = value.Performance;
				Project = value.Project;
				Description = value.Description;
				LastUpdate = value.LastUpdate;
				Notes = value.Notes;
				EditorId = value.EditorId;
				PhoneNumber = value.PhoneNumber;
				MobileNumber = value.MobileNumber;
				Email = value.Email;
				Country = value.Country;
				City = value.City;
				StateProvince = value.StateProvince;
				Rate = value.Rate;
				SubMaterialRate = value.SubMaterialRate;
				IKA = value.IKA;
				Quantity = value.Quantity;
				TotalRate = value.TotalRate;
				Unit = value.Unit;
				Url = value.Url;
				Company = value.Company;
				FaxNumber = value.FaxNumber;
				Currency = value.Currency;
				Accuracy = value.Accuracy;
				Inclusion = value.Inclusion;
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
		public virtual void setFieldData(string field, SubcontractorTable data)
		{
		}

		public virtual long? Id
		{
			get
			{
				return SubcontractorId;
			}
			set
			{
				SubcontractorId = value;
			}
		}



		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="SUBCONTRACTORID" </summary>
		/// <returns> Long </returns>
		public virtual long? SubcontractorId
		{
			get
			{
				return subcontractorId;
			}
			set
			{
				subcontractorId = value;
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
		/// @hibernate.property column="ACCURACY" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="INCLUSION" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="MATRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> materialRate </returns>
		public virtual decimal SubMaterialRate
		{
			get
			{
				return subMaterialRate;
			}
			set
			{
				this.subMaterialRate = value;
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

		/// <summary>
		/// IKA
		/// 
		/// @hibernate.property column="IKA" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> IKA </returns>
		public virtual decimal IKA
		{
			get
			{
				return IKA_Conflict;
			}
			set
			{
				IKA_Conflict = value;
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
		/// Description Here
		/// 
		/// @hibernate.property column="GROUPCODE" type="costos_string" </summary>
		/// <returns> phoneNumber </returns>
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
		/// custom editorId
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
		/// @hibernate.property column="PERFORMANCE" type="costos_string" </summary>
		/// <returns> phoneNumber </returns>
		public virtual string Performance
		{
			get
			{
				return performance;
			}
			set
			{
				performance = value;
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
		/// Description Here
		/// 
		/// @hibernate.property column="CONTACTPERSON" type="costos_string" </summary>
		/// <returns> firstName </returns>
		public virtual string ContactPerson
		{
			get
			{
				return contactPerson;
			}
			set
			{
				contactPerson = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="COMPANY" type="costos_string" </summary>
		/// <returns> company </returns>
		public virtual string Company
		{
			get
			{
				return company;
			}
			set
			{
				company = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PHONENUMBER" type="costos_string" </summary>
		/// <returns> phoneNumber </returns>
		public virtual string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				phoneNumber = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MOBILENUMBER" type="costos_string" </summary>
		/// <returns> mobileNumber </returns>
		public virtual string MobileNumber
		{
			get
			{
				return mobileNumber;
			}
			set
			{
				mobileNumber = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FAXNUMBER" type="costos_string" </summary>
		/// <returns> faxNumber </returns>
		public virtual string FaxNumber
		{
			get
			{
				return faxNumber;
			}
			set
			{
				faxNumber = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EMAIL" type="costos_string" </summary>
		/// <returns> eMail </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="URL" type="costos_string" </summary>
		/// <returns> url </returns>
		public virtual string Url
		{
			get
			{
				return url;
			}
			set
			{
				url = value;
			}
		}
		/// <summary>
		/// Description Here
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
		/// Description Here
		/// 
		/// @hibernate.property column="CITY" type="costos_string" </summary>
		/// <returns> city </returns>
		public virtual string City
		{
			get
			{
				return city;
			}
			set
			{
				city = value;
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
				stateProvince = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ADDRESS" type="costos_string" </summary>
		/// <returns> streetNumber </returns>
		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
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
		///  lazy="true"
		/// @hibernate.key
		///  column="SUBCONTRACTORID"
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
		///  column="SUBCONTRACTORID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemSubcontractorTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> BoqItemSubcontractorSet
		{
			get
			{
				return boqItemSubcontractorSet;
			}
			set
			{
				boqItemSubcontractorSet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return SubcontractorId + ". " + Title;
		}
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="SUBCONTRACTORID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.SubcontractorHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> SubcontractorHistorySet
		{
			get
			{
				return subcontractorHistorySet;
			}
			set
			{
				this.subcontractorHistorySet = value;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return SubcontractorHistorySet;
			}
			set
			{
				SubcontractorHistorySet = value;
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
			return DataFlavors.subcontractorDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.subcontractorDataFlavor.Equals(flavor))
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

			boqTable.LastUpdate = updateTime;
			boqTable.CreateDate = updateTime;
			boqTable.calculateQuantityLoss();
			boqTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			boqTable.EditorId = boqTable.CreateUserId;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			SubcontractorTable subcontractorTable = (SubcontractorTable)clone();
			BoqItemSubcontractorTable boqSubcontractorTable = new BoqItemSubcontractorTable();

			boqSubcontractorTable.Factor1 = BigDecimalMath.ONE;
			boqSubcontractorTable.Factor2 = BigDecimalMath.ONE;
			boqSubcontractorTable.Factor3 = BigDecimalMath.ONE;

			boqSubcontractorTable.QuantityPerUnit = BigDecimalMath.ONE;
			boqSubcontractorTable.QuantityPerUnitFormula = "";
			boqSubcontractorTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqSubcontractorTable.LocalFactor = BigDecimalMath.ONE;
			boqSubcontractorTable.LocalCountry = "";
			boqSubcontractorTable.LocalStateProvince = "";
			boqSubcontractorTable.TotalUnits = BigDecimalMath.ONE;
			boqSubcontractorTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, subcontractorTable.Currency, paymentDate);
			boqSubcontractorTable.HasUserTotalUnits = false;
			boqSubcontractorTable.LastUpdate = updateTime;

			//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

			boqSubcontractorTable.SubcontractorTable = subcontractorTable;
			boqSubcontractorTable.BoqItemTable = boqTable;

			subcontractorTable.DatabaseCreationDate = dbCreationDate;
			subcontractorTable.DatabaseId = subcontractorTable.Id;
			boqTable.BoqItemSubcontractorSet.Add(boqSubcontractorTable);

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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getIKA_sorted()
		public virtual decimal IKA_sorted
		{
			get
			{
				return IKA_Conflict;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getContactPerson_sorted()
		public virtual string ContactPerson_sorted
		{
			get
			{
				return contactPerson;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCompany_sorted()
		public virtual string Company_sorted
		{
			get
			{
				return company;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getPhoneNumber_sorted()
		public virtual string PhoneNumber_sorted
		{
			get
			{
				return phoneNumber;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getMobileNumber_sorted()
		public virtual string MobileNumber_sorted
		{
			get
			{
				return mobileNumber;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getFaxNumber_sorted()
		public virtual string FaxNumber_sorted
		{
			get
			{
				return faxNumber;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getPerformance_sorted()
		public virtual string Performance_sorted
		{
			get
			{
				return performance;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEmail_sorted()
		public virtual string Email_sorted
		{
			get
			{
				return email;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getUrl_sorted()
		public virtual string Url_sorted
		{
			get
			{
				return url;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCity_sorted()
		public virtual string City_sorted
		{
			get
			{
				return city;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getAddress_sorted()
		public virtual string Address_sorted
		{
			get
			{
				return address;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getTotalRate_sorted()
		public virtual decimal TotalRate_sorted
		{
			get
			{
				return totalRate;
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
				Data = (SubcontractorTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (SubcontractorTable)databaseTable);
		}

		public override void recalculate()
		{
			totalRate = BigDecimalMath.ZERO;

			if (Rate != null && IKA != null && SubMaterialRate != null)
			{
				totalRate = Rate + IKA + SubMaterialRate;
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

			if (Virtual.Value && AssemblyAssignments.Count > 1)
			{
				Virtual = false;
			}
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return AssemblySubcontractorSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemSubcontractorSet == null)
				{
					boqItemSubcontractorSet = new HashSet<BoqItemSubcontractorTable>();
				}
				return BoqItemSubcontractorSet;
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