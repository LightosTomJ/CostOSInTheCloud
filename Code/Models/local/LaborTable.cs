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
	using BoqItemLaborTable = Desktop.common.nomitech.common.db.project.BoqItemLaborTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using LaborHistoryTable = Desktop.common.nomitech.common.db.project.LaborHistoryTable;
	using BigDecimalFixed = Desktop.common.nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = Desktop.common.nomitech.common.util.ExchangeRateUtil;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="LABOR" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class LaborTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.PredictionTable, nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class LaborTable : ResourceTable, PredictionTable, ProjectIdEntity, Transferable
	{

		//	public  static final String[] FIELDS = new String[] {
		//		"title",	
		//		"laborId",
		//		"stateProvince",
		//		"unit",
		//		"currency",
		//		"rate",
		//		"IKA", //yek new
		//		"totalRate", //yek new
		//		"groupCode",
		//		"gekCode",
		//		"project",
		//		"editorId",
		//		"contactPerson",
		//		"phoneNumber",
		//		"mobileNumber",
		//		"faxNumber",
		//		"email",
		//		"address",
		//		"city",
		//		"country",
		//		"notes",
		//		"description",
		//		"lastUpdate",
		//		"extraCode1",
		//		"extraCode2",
		//		"extraCode3",
		//		"extraCode4",
		//		"extraCode5",
		//		"extraCode6",
		//		"extraCode7",
		//	};

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"laborId", "itemCode", "title", "stateProvince", "country", "unit", "rate", "IKA", "totalRate", "currency", "project", "contactPerson", "phoneNumber", "mobileNumber", "faxNumber", "email", "address", "city", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> laborId = null;
		private long? laborId = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title = null;
		private string title = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit = null;
		private string unit = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal rate = null;
		private decimal rate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal IKA = null;
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
		private decimal IKA_Conflict = null;
		private decimal totalRate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode = null;
		private string groupCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode = null;
		private string gekCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String project = null;
		private string project = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String contactPerson = null;
		private string contactPerson = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String phoneNumber = null;
		private string phoneNumber = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String mobileNumber = null;
		private string mobileNumber = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String faxNumber = null;
		private string faxNumber = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String email = null;
		private string email = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String city = null;
		private string city = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String address = null;
		private string address = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes = null;
		private string notes = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince = null;
		private string stateProvince = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country = null;
		private string country = null;
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
		private string accessRights;
		private string keywords;
		private string itemCode;
		private decimal buildUpRate;
		private int? overrideType;

		private ISet<AssemblyLaborTable> assemblyLaborSet = new HashSet<AssemblyLaborTable>();
		[NonSerialized]
		private ISet<object> boqItemLaborSet;
		private ISet<LaborHistoryTable> laborHistorySet;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.laborDataFlavor};

		public LaborTable()
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

		// only for writeable fields!
		public virtual void setFieldData(string field, LaborTable data)
		{

		}

		public virtual object Clone()
		{
			LaborTable obj = new LaborTable();

			obj.Address = Address;
			obj.ItemCode = ItemCode;
			obj.BuildUpRate = BuildUpRate;
			obj.OverrideType = OverrideType;
			obj.Title = Title;
			obj.ContactPerson = ContactPerson;
			obj.LaborId = LaborId;
			obj.Description = Description;
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
			obj.Notes = Notes;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.Project = Project;
			obj.PhoneNumber = PhoneNumber;
			obj.MobileNumber = MobileNumber;
			obj.FaxNumber = FaxNumber;
			obj.Email = Email;
			obj.Country = Country;
			obj.City = City;
			obj.StateProvince = StateProvince;
			obj.Rate = Rate;
			obj.IKA = IKA;
			obj.TotalRate = TotalRate;
			obj.Unit = Unit;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.Currency = Currency;
			obj.EditorId = EditorId;
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

			return (object)obj;
		}

		// For online databases only:
		public virtual object conversionClone(bool metric, bool demo)
		{
			LaborTable obj = (LaborTable)Clone();
			if (demo)
			{
				obj.IKA = BigDecimalMath.ZERO;
				obj.Rate = BigDecimalMath.ZERO;
				obj.TotalRate = BigDecimalMath.ZERO;
			}
			return obj;
		}

		public virtual LaborTable copyToAssembly()
		{
			LaborTable obj = (LaborTable)Clone();

			ISet<AssemblyLaborTable> assLaborSet = new HashSet<AssemblyLaborTable>();
			IEnumerator<AssemblyLaborTable> iter = this.AssemblyLaborSet.GetEnumerator();

			while (iter.MoveNext())
			{
				assLaborSet.Add((AssemblyLaborTable)iter.Current.clone(true,false));
			}
			obj.AssemblyLaborSet = assLaborSet;

			return obj;
		}

		public virtual LaborTable Data
		{
			set
			{
    
				Address = value.Address;
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
				ItemCode = value.ItemCode;
				BuildUpRate = value.BuildUpRate;
				OverrideType = value.OverrideType;
				Title = value.Title;
				ContactPerson = value.ContactPerson;
				//setLaborId(getLaborId());
				Description = value.Description;
				LastUpdate = value.LastUpdate;
				Notes = value.Notes;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				Project = value.Project;
				PhoneNumber = value.PhoneNumber;
				MobileNumber = value.MobileNumber;
				FaxNumber = value.FaxNumber;
				Email = value.Email;
				Country = value.Country;
				City = value.City;
				StateProvince = value.StateProvince;
				Rate = value.Rate;
				IKA = value.IKA;
				TotalRate = value.TotalRate;
				Unit = value.Unit;
				EditorId = value.EditorId;
				Currency = value.Currency;
				AccessRights = value.AccessRights;
				//setDatabaseId(getDatabaseId());
				//setDatabaseCreationDate(getDatabaseCreationDate());
    
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

		public override long? Id
		{
			get
			{
				return LaborId;
			}
			set
			{
				LaborId = value;
			}
		}


		/// <summary>
		/// @hibernate.id column="ID"
		///               generator-class="native" 
		///               unsaved-value="null"
		///               column="LABORID" </summary>
		/// <returns> Long </returns>
		public virtual long? LaborId
		{
			get
			{
				return laborId;
			}
			set
			{
				laborId = value;
			}
		}


		/// <summary>
		/// description of the labor
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
		/// labor unit
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
		/// cost per unit
		/// 
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate
		{
			get
			{
				if (rate == null)
				{
					Rate = new BigDecimalFixed(0);
				}
    
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
				if (IKA_Conflict == null)
				{
					IKA = new BigDecimalFixed(0);
				}
    
				return IKA_Conflict;
			}
			set
			{
				IKA_Conflict = value;
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
		/// @hibernate.property column="TUNIT" type="big_decimal" precision="30" scale="10" </summary>
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
		/// @hibernate.property column="TVAL" type="costos_string" </summary>
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
		/// name of the labor
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
		/// phoneNumber of labor
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
		/// phoneNumber of labor
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
		/// faxNumber of supplier
		/// 
		/// @hibernate.property column="FAXNUMBER" type="costos_string" </summary>
		/// <returns> mobileNumber </returns>
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
		/// eMail of labor
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
		/// @hibernate.property column="ADDRESS" type="costos_string" </summary>
		/// <returns> address </returns>
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
				stateProvince = value;
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


		private long? databaseId = null;
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
		///  column="LABORID"
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

		// #RXL_START 
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="LABORID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemLaborTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		// #RXL_END 
		public virtual ISet<object> BoqItemLaborSet
		{
			get
			{
				return boqItemLaborSet;
			}
			set
			{
				boqItemLaborSet = value;
			}
		}


		public override string ToString()
		{
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return LaborId + ". " + Title;
		}
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="LABORID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.LaborHistoryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<object> LaborHistorySet
		{
			get
			{
				return laborHistorySet;
			}
			set
			{
				this.laborHistorySet = value;
			}
		}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient @XmlTransient public java.util.Set<nomitech.common.base.ResourceHistoryTable> getResourceHistorySet()
		public override ISet<ResourceHistoryTable> ResourceHistorySet
		{
			get
			{
				return LaborHistorySet;
			}
			set
			{
				LaborHistorySet = value;
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
			return DataFlavors.laborDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.laborDataFlavor.Equals(flavor))
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
			boqTable.CreateUserId = DatabaseDBUtil.Properties.UserId;
			boqTable.EditorId = boqTable.CreateUserId;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			LaborTable laborTable = (LaborTable)Clone();
			BoqItemLaborTable boqLaborTable = new BoqItemLaborTable();

			boqLaborTable.Factor1 = BigDecimalMath.ONE;
			boqLaborTable.Factor2 = BigDecimalMath.ONE;
			boqLaborTable.Factor3 = BigDecimalMath.ONE;

			boqLaborTable.QuantityPerUnitFormula = "";
			boqLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			boqLaborTable.LocalFactor = BigDecimalMath.ONE;
			boqLaborTable.LocalCountry = "";
			boqLaborTable.LocalStateProvince = "";

			boqLaborTable.ExchangeRate = ExchangeRateUtil.findExchangeRate(prjDBUtil, laborTable.Currency, paymentDate);
			boqLaborTable.HasUserTotalUnits = false;
			boqLaborTable.LastUpdate = updateTime;

			//boqConsumableTable.setExchangeRate(ExchangeRateUtil.findExchangeRate(prjDBUtil,getCurrency(), paymentDate, false));

			boqLaborTable.LaborTable = laborTable;
			boqLaborTable.BoqItemTable = boqTable;

			boqLaborTable.QuantityPerUnit = boqLaborTable.UnitHours;
			boqLaborTable.TotalUnits = boqLaborTable.UnitHours;

			laborTable.DatabaseCreationDate = dbCreationDate;
			laborTable.DatabaseId = laborTable.Id;
			boqTable.BoqItemLaborSet.Add(boqLaborTable);

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
			assemblyTable.AssemblyLaborSet = new HashSet<object>();
			assemblyTable.AssemblyMaterialSet = new HashSet<object>();
			assemblyTable.AssemblyConsumableSet = new HashSet<object>();

			LaborTable laborTable = (LaborTable)Clone();
			laborTable.ResourceHistorySet = ResourceHistorySet;
			laborTable.recalculate();

			AssemblyLaborTable assLaborTable = new AssemblyLaborTable();

			assLaborTable.Factor1 = BigDecimalMath.ONE;
			assLaborTable.Factor2 = BigDecimalMath.ONE;
			assLaborTable.Factor3 = BigDecimalMath.ONE;

			assLaborTable.QuantityPerUnitFormula = "";
			assLaborTable.QuantityPerUnitFormulaState = ResourceToAssignmentTable.QTYPUFORM_NOFORMULA;

			assLaborTable.LocalFactor = BigDecimalMath.ONE;
			assLaborTable.LocalCountry = "";
			assLaborTable.LocalStateProvince = "";
			assLaborTable.ExchangeRate = BigDecimalMath.ONE;
			assLaborTable.LastUpdate = updateTime;

			assLaborTable.LaborTable = laborTable;
			assLaborTable.AssemblyTable = assemblyTable;

			assLaborTable.QuantityPerUnit = assLaborTable.UnitHours;

			assemblyTable.AssemblyLaborSet.Add(assLaborTable);

			assemblyTable.recalculate();

			return assemblyTable;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCreateUserId_sorted()
		public virtual string CreateUserId_sorted
		{
			get
			{
				return createUserId;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.math.BigDecimal getTotalRate_sorted()
		public virtual decimal TotalRate_sorted
		{
			get
			{
				return totalRate;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getContactPerson_sorted()
		public virtual string ContactPerson_sorted
		{
			get
			{
				return contactPerson;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEmail_sorted()
		public virtual string Email_sorted
		{
			get
			{
				return email;
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
				Data = (LaborTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (LaborTable)databaseTable);
		}

		public override void recalculate()
		{
			totalRate = BigDecimalMath.ZERO;

			if (Rate != null && IKA != null)
			{
				totalRate = Rate + IKA;
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
				return AssemblyLaborSet;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				if (boqItemLaborSet == null)
				{
					boqItemLaborSet = new HashSet<BoqItemLaborTable>();
				}
    
				return BoqItemLaborSet;
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