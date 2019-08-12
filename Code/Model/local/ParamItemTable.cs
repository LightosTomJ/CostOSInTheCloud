using System;
using System.Collections.Generic;

namespace Model.local
{

	using Session = org.hibernate.Session;
	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ImperialToMetric = Desktop.common.nomitech.common.util.ImperialToMetric;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;


	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PARAMITEM" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ParamItemTable extends nomitech.common.base.ResourceWithAssignmentsTable implements java.awt.datatransfer.Transferable, nomitech.common.base.ProjectIdEntity, java.io.Serializable, nomitech.common.base.BaseTable
	[Serializable]
	public class ParamItemTable : ResourceWithAssignmentsTable, Transferable, ProjectIdEntity, BaseTable
	{

		public const string PROTECT_PASSWORD = "PSWD";
		public const string PROTECT_SERIAL = "SERL";
		public const string PROTECT_NONE = "NONE";

		/*
		public static final String[] FIELDS = new String[] {			
			"title",
			"costModel",
			"groupName",
			"icon",
			"unit",
			"sampleRate",
			"protectionType",
			"notes",		
			"groupCode",
			"gekCode",
			"extraCode1",
			"extraCode2",
			"extraCode3",
			"extraCode4",
			"extraCode5",
			"extraCode6",
			"extraCode7",	
		};*/

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"paramitemId", "itemCode", "title", "titleFormula", "costModel", "groupName", "icon", "unit", "multUnitQty", "sampleRate", "protectionType", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(Boolean), typeof(string), typeof(string), typeof(string), typeof(Boolean), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> paramitemId = null;
		private long? paramitemId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String variable;
		private string variable;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode = null;
		private string groupCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode = null;
		private string gekCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes = null;
		private string notes = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate = null;
		private DateTime lastUpdate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal sampleRate;
		private decimal sampleRate;

		private string password;
		private string serialNumber;
		private string protectionType;

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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String wbsCode;
		private string wbsCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String wbs2Code;
		private string wbs2Code;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String location;
		private string location;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String icon;
		private string icon;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> costModel;
		private bool? costModel;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupName;
		private string groupName;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date createDate;
		private DateTime createDate;

		private decimal quantity;
		private bool? multUnitQty;

		private ISet<ParamItemInputTable> inputSet;
		private ISet<ParamItemOutputTable> outputSet;
		private ISet<ParamItemReturnTable> returnSet;
		private ISet<BoqItemTable> boqItemSet;
		private ISet<ParamItemConditionTable> conditionSet;
		private decimal totalCost;

		private BoqItemTable parentBoqItem;

		private string accessRights; // accessRights
		private string keywords;
		private string itemCode;
		private string titleFormula;

		private string groupIdentifier;

		private bool? wasExploded; // Applies Only on Project Database after generation

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.paramItemDataFlavor};

		public ParamItemTable()
		{

		}

		public virtual object Clone()
		{
			ParamItemTable obj = new ParamItemTable();

			obj.ParamitemId = ParamitemId;
			obj.Variable = Variable;
			obj.LastUpdate = LastUpdate;
			obj.Description = Description;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.ItemCode = ItemCode;
			obj.TitleFormula = TitleFormula;
			obj.GroupIdentifier = GroupIdentifier;
			obj.Title = Title;
			obj.Notes = Notes;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.EditorId = EditorId;
			obj.Unit = Unit;
			obj.SampleRate = SampleRate;
			obj.WasExploded = WasExploded;
			obj.TotalCost = TotalCost;
			obj.Quantity = Quantity;
			obj.MultUnitQty = MultUnitQty;
			obj.Icon = Icon;
			obj.CostModel = CostModel;
			obj.GroupName = GroupName;
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
			obj.WbsCode = WbsCode;
			obj.Wbs2Code = Wbs2Code;
			obj.Location = Location;
			obj.ProtectionType = ProtectionType;
			obj.Password = Password;
			obj.SerialNumber = SerialNumber;
			obj.ProjectId = ProjectId;
			obj.GlobalId = GlobalId;

			return obj;
		}

		public virtual object conversionClone(bool metric, bool demo)
		{
			ParamItemTable obj = (ParamItemTable)Clone();
			if (metric)
			{ // make a recalculation here:
				obj.SampleRate = ImperialToMetric.getRate(unit, sampleRate);
				obj.Unit = ImperialToMetric.getUnit(unit);
			}
			if (demo)
			{
				obj.SampleRate = BigDecimalMath.ZERO;
			}

			return obj;
		}

		public virtual ParamItemTable Data
		{
			set
			{
				if (ParamitemId == null)
				{
				ParamitemId = value.ParamitemId;
				}
				Variable = value.Variable;
				Unit = value.Unit;
				SampleRate = value.SampleRate;
				WasExploded = value.WasExploded;
				TotalCost = value.TotalCost;
				Quantity = value.Quantity;
				MultUnitQty = value.MultUnitQty;
				Icon = value.Icon;
				CostModel = value.CostModel;
				GroupName = value.GroupName;
				Description = value.Description;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				Title = value.Title;
				ItemCode = value.ItemCode;
				TitleFormula = value.TitleFormula;
				GroupIdentifier = value.GroupIdentifier;
    
				Notes = value.Notes;
				DatabaseId = value.DatabaseId;
				DatabaseCreationDate = value.DatabaseCreationDate;
    
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
				AccessRights = value.AccessRights;
    
				CreateDate = value.CreateDate;
				CreateUserId = value.CreateUserId;
    
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
				WbsCode = value.WbsCode;
				Wbs2Code = value.Wbs2Code;
				Location = value.Location;
				ProtectionType = value.ProtectionType;
				Password = value.Password;
				SerialNumber = value.SerialNumber;
    
				GlobalId = value.GlobalId;
			}
		}

		//	public Object scaledValueForField(String field) {
		//		return null;
		//	}
		//
		//	public Object valueForField(String field) {
		//		return null;
		//	}

		//	public boolean equals(Object val) {
		//		if ( !(val instanceof ParamItemTable) ) {
		//			return false;
		//		}
		//		final String lastUpdate = "lastUpdate";
		//		final String createDate = "createDate";
		//		ParamItemTable assembly = (ParamItemTable)val;
		//		Iterator iter = assembly.o_map.keySet().iterator();
		//		while ( iter.hasNext() ) {
		//			String key = (String)iter.next();
		//			if ( key.equals(lastUpdate) || key.equals(createDate) )
		//				continue;
		//			else if ( !assembly.o_map.get(key).equals(o_map.get(key)) ) {
		//				return false;
		//			}
		//		}
		//		return true;
		//	}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PARAMITEMID" </summary>
		/// <returns> Long </returns>
		public virtual long? ParamitemId
		{
			get
			{
				return paramitemId;
			}
			set
			{
				this.paramitemId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SAMPLERATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> variable </returns>
		public virtual decimal SampleRate
		{
			get
			{
				return sampleRate;
			}
			set
			{
				this.sampleRate = value;
			}
		}


		//#RXL_START
		/// <summary>
		/// @hibernate.property column="WASEXPLODED" type="boolean" </summary>
		/// <returns> wasExploded </returns>
		//#RXL_END
		public virtual bool? WasExploded
		{
			get
			{
				return wasExploded;
			}
			set
			{
				this.wasExploded = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ICON" type="costos_string" </summary>
		/// <returns> variable </returns>
		public virtual string Icon
		{
			get
			{
				return icon;
			}
			set
			{
				this.icon = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CMODEL" type="boolean" </summary>
		/// <returns> variable </returns>
		public virtual bool? CostModel
		{
			get
			{
				return costModel;
			}
			set
			{
				this.costModel = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GROUPNAME" type="costos_string" </summary>
		/// <returns> variable </returns>
		public virtual string GroupName
		{
			get
			{
				return groupName;
			}
			set
			{
				this.groupName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TOTALCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> variable </returns>
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
		/// @hibernate.property column="QTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> variable </returns>
		public override decimal Quantity
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
		/// @hibernate.property column="MULTUNITQTY" type="boolean" </summary>
		/// <returns> variable </returns>
		public virtual bool? MultUnitQty
		{
			get
			{
				return multUnitQty;
			}
			set
			{
				this.multUnitQty = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="VARIABLE" type="costos_string" </summary>
		/// <returns> variable </returns>
		public virtual string Variable
		{
			get
			{
				return variable;
			}
			set
			{
				this.variable = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> description </returns>
		public override string Description
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
		/// @hibernate.property column="TITLEEQU" type="costos_text" </summary>
		/// <returns> description </returns>
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


		//RXL_START
		/// <summary>
		/// @hibernate.property column="GROUPIDENTITY" type="costos_string" index="IDX_GROUPIDENTITY" </summary>
		/// <returns> description </returns>
		//RXL_END
		public virtual string GroupIdentifier
		{
			get
			{
				return groupIdentifier;
			}
			set
			{
				this.groupIdentifier = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" index="IDX_TITLE" </summary>
		/// <returns> title </returns>
		public override string Title
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
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> unit </returns>
		public override string Unit
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
		/// @hibernate.property column="GROUPCODE" type="costos_string" </summary>
		/// <returns> title </returns>
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
		/// <returns> gekCode </returns>
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
				this.editorId = value;
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
				this.notes = value;
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
				this.lastUpdate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EXTRACODE1" type="costos_string" </summary>
		/// <returns> editorId </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="EXTRACODE2" type="costos_string" </summary>
		/// <returns> editorId </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="EXTRACODE3" type="costos_string" </summary>
		/// <returns> editorId </returns>
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
		/// Description Here
		/// 
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
		/// Description Here
		/// 
		/// @hibernate.property column="EXTRACODE5" type="costos_string" </summary>
		/// <returns> extraCode4 </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="EXTRACODE6" type="costos_string" </summary>
		/// <returns> extraCode4 </returns>
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
		/// Description Here
		/// 
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
		/// Description Here
		/// 
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
		/// Description Here
		/// 
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
		/// Description Here
		/// 
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
		/// Description Here
		/// 
		/// @hibernate.property column="WBS" type="costos_string" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="WBS2" type="costos_string" </summary>
		/// <returns> wbs2Code </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="LOC" type="costos_string" </summary>
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
		/// @hibernate.property column="PSWD" type="nomitech.common.db.types.NotNullPasswordType" </summary>
		/// <returns> password </returns>
		public virtual string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SNUM" type="nomitech.common.db.types.NotNullBigPasswordType" </summary>
		/// <returns> serialNumber </returns>
		public virtual string SerialNumber
		{
			get
			{
				return serialNumber;
			}
			set
			{
				this.serialNumber = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRTTYPE" type="nomitech.common.db.types.NotNullPasswordType" </summary>
		/// <returns> protectionType </returns>
		public virtual string ProtectionType
		{
			get
			{
				return protectionType;
			}
			set
			{
				this.protectionType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEUSERID" type="costos_string" </summary>
		/// <returns> createUserId </returns>
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
		/// <returns> createDate </returns>
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
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemInputTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemInputTable> InputSet
		{
			get
			{
				return inputSet;
			}
			set
			{
				this.inputSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemOutputTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemOutputTable> OutputSet
		{
			get
			{
				return outputSet;
			}
			set
			{
				this.outputSet = value;
			}
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.BoqItemTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<BoqItemTable> BoqItemSet
		{
			get
			{
				return boqItemSet;
			}
			set
			{
				this.boqItemSet = value;
			}
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="delete-orphan"
		/// @hibernate.key
		///  column="PARAMITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemConditionTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<ParamItemConditionTable> ConditionSet
		{
			get
			{
				return conditionSet;
			}
			set
			{
				this.conditionSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMITEMID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemReturnTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ParamItemReturnTable> ReturnSet
		{
			get
			{
				return returnSet;
			}
			set
			{
				this.returnSet = value;
			}
		}


		//#RXL_START
		/// <summary>
		/// @hibernate.many-to-one
		///  column="BOQITEMID" </summary>
		/// <returns> BoqItemTable </returns>
		//#RXL_END
		public virtual BoqItemTable ParentBoqItem
		{
			get
			{
				return parentBoqItem;
			}
			set
			{
				this.parentBoqItem = value;
			}
		}


		public static DataFlavor[] getsSupporteddataflavors()
		{
			return s_supportedDataFlavors;
		}

		public override long? Id
		{
			get
			{
				return ParamitemId;
			}
			set
			{
				ParamitemId = value;
			}
		}


		public override decimal TableRate
		{
			get
			{
				return null;
			}
			set
			{
				SampleRate = value;
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
			return DataFlavors.paramItemDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.paramItemDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
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

		public override ParamItemTable deepCopy(bool deepCopyBoqs, bool copyWithHistory)
		{
			return copy(deepCopyBoqs);
		}

		public virtual ParamItemTable deepCopy(bool deepCopyBoqs)
		{
			return copy(deepCopyBoqs);
		}

		public virtual ParamItemTable deepCopy()
		{
			return copy(false);
		}

		public virtual ParamItemTable copy()
		{
			return copy(false);
		}
		public virtual ParamItemTable copy(bool deepCopyBoqs)
		{
			ParamItemTable pItemTable = (ParamItemTable)Clone();

			pItemTable.InputSet = new HashSet<ParamItemInputTable>();
			pItemTable.OutputSet = new HashSet<ParamItemOutputTable>();
			pItemTable.BoqItemSet = new HashSet<BoqItemTable>();
			pItemTable.ConditionSet = new HashSet<ParamItemConditionTable>();

			if (InputSet == null)
			{
				InputSet = new HashSet<ParamItemInputTable>();
			}

			if (OutputSet == null)
			{
				OutputSet = new HashSet<ParamItemOutputTable>();
			}

			if (BoqItemSet == null)
			{
				BoqItemSet = new HashSet<BoqItemTable>();
			}

			if (ConditionSet == null)
			{
				ConditionSet = new HashSet<ParamItemConditionTable>();
			}

			foreach (ParamItemInputTable pTable in InputSet)
			{
				pItemTable.InputSet.Add((ParamItemInputTable) pTable.copyWithConditions());
			}

			foreach (ParamItemOutputTable pTable in OutputSet)
			{
				pItemTable.OutputSet.Add((ParamItemOutputTable) pTable.copy());
			}

			foreach (BoqItemTable pTable in BoqItemSet)
			{
				if (!deepCopyBoqs)
				{
					pItemTable.BoqItemSet.Add((BoqItemTable) pTable.clone());
				}
				else
				{
					pItemTable.BoqItemSet.Add((BoqItemTable) pTable.deepCopy(true));
				}
			}

			foreach (ParamItemConditionTable conTable in ConditionSet)
			{
				pItemTable.ConditionSet.Add((ParamItemConditionTable) conTable.Clone());
			}

			return pItemTable;
		}

		// Use these method only in online load of assemblies
		public virtual ParamItemTable conversionDeepCopy(bool metric, bool demo)
		{
			ParamItemTable pItemTable = (ParamItemTable)conversionClone(metric, demo);

			pItemTable.InputSet = new HashSet<ParamItemInputTable>();
			pItemTable.OutputSet = new HashSet<ParamItemOutputTable>();
			pItemTable.BoqItemSet = new HashSet<BoqItemTable>();
			pItemTable.ConditionSet = new HashSet<ParamItemConditionTable>();

			if (InputSet == null)
			{
				InputSet = new HashSet<ParamItemInputTable>();
			}

			if (OutputSet == null)
			{
				OutputSet = new HashSet<ParamItemOutputTable>();
			}

			if (BoqItemSet == null)
			{
				BoqItemSet = new HashSet<BoqItemTable>();
			}

			if (ConditionSet == null)
			{
				ConditionSet = new HashSet<ParamItemConditionTable>();
			}

			foreach (ParamItemInputTable pTable in InputSet)
			{
				pItemTable.InputSet.Add((ParamItemInputTable) pTable.copyWithConditions());
			}

			foreach (ParamItemOutputTable pTable in OutputSet)
			{
				pItemTable.OutputSet.Add((ParamItemOutputTable) pTable.copy());
			}

			foreach (BoqItemTable pTable in BoqItemSet)
			{
				pItemTable.BoqItemSet.Add((BoqItemTable) pTable.deepCopy(true));
			}

			foreach (ParamItemConditionTable conTable in ConditionSet)
			{
				pItemTable.ConditionSet.Add((ParamItemConditionTable) conTable.Clone());
			}

			return pItemTable;
		}

		public override string ToString()
		{
			if (StringUtils.isNullOrBlank(ItemCode))
			{
				return Id + " - " + Title;
			}
			return ItemCode + " - " + Title;
		}

		public virtual void setFieldData(string fillDownField, ParamItemTable fillDownParamItem)
		{
			if (fillDownField.Equals("title"))
			{
				Title = fillDownParamItem.Title;
			}
			else if (fillDownField.Equals("variable"))
			{
				Variable = fillDownParamItem.Variable;
			}
			else if (fillDownField.Equals("unit"))
			{
				Unit = fillDownParamItem.Unit;
			}
			else if (fillDownField.Equals("sampleRate"))
			{
				SampleRate = fillDownParamItem.SampleRate;
			}
			else if (fillDownField.Equals("notes"))
			{
				Notes = fillDownParamItem.Notes;
			}
			else if (fillDownField.Equals("description"))
			{
				Description = fillDownParamItem.Description;
			}
			else if (fillDownField.Equals("groupCode"))
			{
				GroupCode = fillDownParamItem.GroupCode;
			}
			else if (fillDownField.Equals("gekCode"))
			{
				GekCode = fillDownParamItem.GekCode;
			}
			else if (fillDownField.Equals("extraCode1"))
			{
				ExtraCode1 = fillDownParamItem.ExtraCode1;
			}
			else if (fillDownField.Equals("extraCode2"))
			{
				ExtraCode2 = fillDownParamItem.ExtraCode2;
			}
			else if (fillDownField.Equals("extraCode3"))
			{
				ExtraCode3 = fillDownParamItem.ExtraCode3;
			}
			else if (fillDownField.Equals("extraCode4"))
			{
				ExtraCode4 = fillDownParamItem.ExtraCode4;
			}
			else if (fillDownField.Equals("extraCode5"))
			{
				ExtraCode5 = fillDownParamItem.ExtraCode5;
			}
			else if (fillDownField.Equals("extraCode6"))
			{
				ExtraCode6 = fillDownParamItem.ExtraCode6;
			}
			else if (fillDownField.Equals("extraCode7"))
			{
				ExtraCode7 = fillDownParamItem.ExtraCode7;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getCreateDate_sorted()
		public virtual DateTime CreateDate_sorted
		{
			get
			{
				return createDate;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getVariable_sorted()
		public virtual string Variable_sorted
		{
			get
			{
				return variable;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCreateUserId_sorted()
		public virtual string CreateUserId_sorted
		{
			get
			{
				return createUserId;
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

		public override bool Equals(object v)
		{
			if (!(v is ParamItemTable))
			{
				return false;
			}
			ParamItemTable p = (ParamItemTable) v;

			if (p.Id == null || Id == null)
			{
				return false;
			}

			return p.Id.Equals(Id);
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (ParamItemTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable resourceTable)
		{
			setFieldData(field,(ParamItemTable)resourceTable);
		}

		public override string Project
		{
			set
			{
				// Dummy
			}
			get
			{
				return null;
			}
		}


		public override void recalculate()
		{
		}

		public virtual bool WriteProtected
		{
			get
			{
				return !ProtectionType.Equals(PROTECT_NONE);
			}
		}

		public override bool checkWriteProtected()
		{
			return WriteProtected;
		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return null;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				return BoqItemSet;
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

		public override decimal Productivity
		{
			get
			{
				return null; // dummy here
			}
			set
			{
				// dummy here
			}
		}


		public override ISet<object> getResourceAssignments(string resourceName)
		{
			if (resourceName.Equals("ParamItemInputTable"))
			{
				return InputSet;
			}
			else if (resourceName.Equals("ParamItemOutputTable"))
			{
				return OutputSet;
			}
			return null;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static ParamItemTable deepPaste(org.hibernate.Session session, ParamItemTable assTable) throws Exception
		public static ParamItemTable deepPaste(Session session, ParamItemTable assTable)
		{

			ParamItemTable newParamItem = assTable;
			newParamItem.ParamitemId = null;
			long? id = (long?)session.save(newParamItem.Clone());

			ParamItemTable paramItemTable = (ParamItemTable)session.load(typeof(ParamItemTable), id);

			if (newParamItem.InputSet != null)
			{
				IEnumerator<ParamItemInputTable> iter = newParamItem.InputSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ParamItemInputTable inputTable = (ParamItemInputTable)iter.Current;
					id = (long?)session.save(inputTable.Clone());
					inputTable = (ParamItemInputTable)session.load(typeof(ParamItemInputTable),id);
					if (paramItemTable.InputSet == null)
					{
						paramItemTable.InputSet = new HashSet<object>();
					}

					if (DatabaseDBUtil.LocalCommunication)
					{
						// do the association
						paramItemTable.InputSet.Add(inputTable);

						inputTable.ParamItemTable = paramItemTable;
						session.update(paramItemTable);
						session.update(inputTable);
					}
					else
					{
						DatabaseDBUtil.associateParamItemWithInput(paramItemTable, inputTable);
					}
				}
			}

			if (newParamItem.OutputSet != null)
			{
				IEnumerator<ParamItemOutputTable> iter = newParamItem.OutputSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ParamItemOutputTable outputTable = (ParamItemOutputTable)iter.Current;
					id = (long?)session.save(outputTable.Clone());
					ParamItemOutputTable dbOutputTable = (ParamItemOutputTable)session.load(typeof(ParamItemOutputTable),id);

					if (outputTable.ConceptualSet != null)
					{
						dbOutputTable.ConceptualSet = new HashSet<object>();
						foreach (ParamItemConceptualResourceTable resTable in outputTable.ConceptualSet)
						{
							id = (long?)session.save(resTable.Clone());
							resTable = (ParamItemConceptualResourceTable)session.load(typeof(ParamItemConceptualResourceTable),id);
							if (DatabaseDBUtil.LocalCommunication)
							{
								resTable.ParamItemOutputTable = dbOutputTable;
								dbOutputTable.ConceptualSet.Add(resTable);
								session.update(resTable);
								session.update(dbOutputTable);
							}
							else
							{
								DatabaseDBUtil.associateParamItemOutputWithConResource(resTable, dbOutputTable);
							}
						}
					}

					if (outputTable.QueryResourceSet != null)
					{
						dbOutputTable.QueryResourceSet = new HashSet<object>();
						foreach (ParamItemQueryResourceTable sourceTable in outputTable.QueryResourceSet)
						{
							id = (long?)session.save(DatabaseDBUtil.LocalCommunication?sourceTable.Clone():sourceTable);
							ParamItemQueryResourceTable resTable = (ParamItemQueryResourceTable)session.load(typeof(ParamItemQueryResourceTable),id);
							if (DatabaseDBUtil.LocalCommunication)
							{
								resTable.ParamItemOutputTable = dbOutputTable;
								dbOutputTable.QueryResourceSet.Add(resTable);
								session.update(resTable);
								session.update(dbOutputTable);

								resTable.QueryRowList = new List<ParamItemQueryRowTable>();
								// Now store the internal query rows:
								foreach (ParamItemQueryRowTable rowTable in sourceTable.QueryRowList)
								{
									id = (long?)session.save(rowTable);
									rowTable = (ParamItemQueryRowTable)session.load(typeof(ParamItemQueryRowTable), id);
									rowTable.QueryResourceTable = resTable;
									resTable.QueryRowList.Add(rowTable);
									session.update(resTable);
									session.update(rowTable);
								}
							}
							else
							{
								DatabaseDBUtil.associateParamItemOutputWithQueryResource(resTable, dbOutputTable);
							}
						}
					}

					// do the addition
					if (paramItemTable.OutputSet == null)
					{
						paramItemTable.OutputSet = new HashSet<object>();
					}

					if (DatabaseDBUtil.LocalCommunication)
					{
						paramItemTable.OutputSet.Add(dbOutputTable);

						dbOutputTable.ParamItemTable = paramItemTable;
						session.update(paramItemTable);
						session.update(dbOutputTable);
					}
					else
					{
						DatabaseDBUtil.associateParamItemWithOutput(paramItemTable, dbOutputTable);
					}
				}
			}

			return paramItemTable;
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient public System.Nullable<bool> getPredicted()
		public override bool? Predicted
		{
			get
			{
				return false;
			}
		}

		public override System.Collections.IList ResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new LinkedList();
    
				if (InputSet != null)
				{
					set.AddRange(InputSet);
				}
				if (OutputSet != null)
				{
					set.AddRange(OutputSet);
				}
				if (ReturnSet != null)
				{
					set.AddRange(ReturnSet);
				}
				if (BoqItemSet != null)
				{
					set.AddRange(BoqItemSet);
				}
				if (ConditionSet != null)
				{
					set.AddRange(ConditionSet);
				}
    
				return set;
			}
		}

		public override System.Collections.IList OrderedResourceAssignmentsList
		{
			get
			{
				System.Collections.IList set = new List<object>();
    
				if (InputSet != null) // Only Input Set for now
				{
					set.AddRange(orderedList(InputSet));
				}
    
				return set;
			}
		}

		protected internal override System.Collections.ICollection orderedList(ISet<object> resourceSet)
		{
			ParamItemInputTable[] array = (ParamItemInputTable[])resourceSet.toArray(new ParamItemInputTable[resourceSet.Count]);
			Arrays.sort(array, new ComparatorAnonymousInnerClass(this));
			return Arrays.asList(array);
		}

		private class ComparatorAnonymousInnerClass : IComparer<ParamItemInputTable>
		{
			private readonly ParamItemTable outerInstance;

			public ComparatorAnonymousInnerClass(ParamItemTable outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public int compare(ParamItemInputTable o1, ParamItemInputTable o2)
			{
				int res = o1.SortOrder.compareTo(o2.SortOrder);
				if (res == 0)
				{
					res = o1.Id.compareTo(o2.Id);
				}
				return res;
			}
		}


		private long? globalId;
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="GLBID" type="long" </summary>
		/// <returns> globalId </returns>
		//#RXL_END
		public virtual long? GlobalId
		{
			get
			{
				return globalId;
			}
			set
			{
				this.globalId = value;
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