using System;
using System.Collections.Generic;

namespace Models.local
{

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using DatabaseTable = nomitech.common.@base.DatabaseTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTINFO"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ProjectInfoTable implements java.awt.datatransfer.Transferable, java.io.Serializable, nomitech.common.base.DatabaseTable
	[Serializable]
	public class ProjectInfoTable : Transferable, DatabaseTable
	{

		public const string DOTTED_STYLE = "dotted";
		public const string NUMERIC5_STYLE = "numeric5";
		public const string NUMERIC6_STYLE = "numeric6";
		// public static final String ALPHABETIC_STYLE = "alphabetic";
		public const string RICHARDSON_STYLE = "richardson";

		public const string FILE_STORAGE = "CEP File";
		public const string SERVER_STORAGE = "Server";

		// MONO CUSTOMEPS EDW:
		public static readonly string[] CUSTOM_EPS_FIELDS = new string[] {"customEpsRate1", "customEpsRate2", "customEpsRate3", "customEpsRate4", "customEpsRate5", "customEpsRate6", "customEpsRate7", "customEpsRate8", "customEpsRate9", "customEpsRate10", "customEpsText1", "customEpsText2", "customEpsText3", "customEpsText4", "customEpsText5", "customEpsText6", "customEpsText7", "customEpsText8", "customEpsText9", "customEpsText10", "customEpsText11", "customEpsText12", "customEpsText13", "customEpsText14", "customEpsText15", "customEpsText16", "customEpsText17", "customEpsText18", "customEpsText19", "customEpsText20", "customEpsDate1", "customEpsDate2", "customEpsDate3", "customEpsDate4", "customEpsDate5", "customEpsDate6", "customEpsDate7", "customEpsDate8", "customEpsDate9", "customEpsDate10"};

		public static readonly string[] FIELDS = new string[] {"code", "title", "projectType", "client", "location", "stateProvince", "country", "currency", "status", "submissionDate", "unitCost", "basementSize", "superstructureSize", "unit", "customEpsRate1", "customEpsRate2", "customEpsRate3", "customEpsRate4", "customEpsRate5", "customEpsRate6", "customEpsRate7", "customEpsRate8", "customEpsRate9", "customEpsRate10", "customEpsText1", "customEpsText2", "customEpsText3", "customEpsText4", "customEpsText5", "customEpsText6", "customEpsText7", "customEpsText8", "customEpsText9", "customEpsText10", "customCumRate1", "customCumRate2", "customCumRate3", "customCumRate4", "customCumRate5", "customCumRate6", "customCumRate7", "customCumRate8", "customCumRate9", "customCumRate10", "equipmentTotalCost", "subcontractorTotalCost", "laborTotalCost", "materialTotalCost", "consumableTotalCost", "laborManhours", "equipmentHours", "totalCost", "offeredPrice", "lastUpdate", "customEpsText11", "customEpsText12", "customEpsText13", "customEpsText14", "customEpsText15", "customEpsText16", "customEpsText17", "customEpsText18", "customEpsText19", "customEpsText20", "customCumRate11", "customCumRate12", "customCumRate13", "customCumRate14", "customCumRate15", "customCumRate16", "customCumRate17", "customCumRate18", "customCumRate19", "customCumRate20", "customEpsDate1", "customEpsDate2", "customEpsDate3", "customEpsDate4", "customEpsDate5", "customEpsDate6", "customEpsDate7", "customEpsDate8", "customEpsDate9", "customEpsDate10", "defaultRevision"};

		public static readonly Type[] CLASSES = new Type[] {typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> projectInfoId = null;
		private long? projectInfoId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String code = null;
		private string code = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title = null;
		private string title = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String codeStyle = DOTTED_STYLE;
		private string codeStyle = DOTTED_STYLE;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate = null;
		private DateTime lastUpdate = null;
		private DateTime createDate = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String storageType = FILE_STORAGE;
		private string storageType = FILE_STORAGE;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String location = null;
		private string location = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country;
		private string country;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String client;
		private string client;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince;
		private string stateProvince;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String contractor;
		private string contractor;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String geoLocation;
		private string geoLocation;

		private bool? hasBimTakeoff;
		private bool? hasOnScreenTakeoff;

		private bool? primaveraConnected;

		private bool? locationFactors;
		private string locationProfile;
		private string selectedFactor;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String projectType;
		private string projectType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String subCategory;
		private string subCategory;
		private string projectIconMediaId;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal basementSize;
		private decimal basementSize;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal superstructureSize;
		private decimal superstructureSize;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitCost;
		private decimal unitCost;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal clientBudget;
		private decimal clientBudget;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<int> floors;
		private int? floors;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<int> paymentDuration;
		private int? paymentDuration;

		private decimal totalCost;
		private decimal offeredPrice;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String status;
		private string status;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency;
		private string currency;
		private DateTime submissionDate;

		private string defaultRevision;

		private decimal customEpsRate1;
		private decimal customEpsRate2;
		private decimal customEpsRate3;
		private decimal customEpsRate4;
		private decimal customEpsRate5;
		private decimal customEpsRate6;
		private decimal customEpsRate7;
		private decimal customEpsRate8;
		private decimal customEpsRate9;
		private decimal customEpsRate10;

		private string customEpsText1;
		private string customEpsText2;
		private string customEpsText3;
		private string customEpsText4;
		private string customEpsText5;
		private string customEpsText6;
		private string customEpsText7;
		private string customEpsText8;
		private string customEpsText9;
		private string customEpsText10;
		private string customEpsText11;
		private string customEpsText12;
		private string customEpsText13;
		private string customEpsText14;
		private string customEpsText15;
		private string customEpsText16;
		private string customEpsText17;
		private string customEpsText18;
		private string customEpsText19;
		private string customEpsText20;

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

		private DateTime customEpsDate1;
		private DateTime customEpsDate2;
		private DateTime customEpsDate3;
		private DateTime customEpsDate4;
		private DateTime customEpsDate5;
		private DateTime customEpsDate6;
		private DateTime customEpsDate7;
		private DateTime customEpsDate8;
		private DateTime customEpsDate9;
		private DateTime customEpsDate10;

		private decimal equipmentTotalCost;
		private decimal subcontractorTotalCost;
		private decimal laborTotalCost;
		private decimal materialTotalCost;
		private decimal consumableTotalCost;
		private decimal laborManhours;
		private decimal equipmentHours;

		private ProjectEPSTable projectEPSTable;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String epsCode;
		private string epsCode;

		//ContainedIn
		//OneToMany(mappedBy="projectInfoTable")
		private ISet<ProjectWBSTable> wbsSet = new HashSet<ProjectWBSTable>(0);
		private ISet<ProjectWBS2Table> wbs2Set = new HashSet<ProjectWBS2Table>(0);
		private ISet<ProjectUrlTable> urlSet = new HashSet<ProjectUrlTable>(0);
		private ISet<TakeoffConditionTable> takeoffSet = new HashSet<TakeoffConditionTable>(0);
		private ISet<ProjectUserTable> userSet = new HashSet<ProjectUserTable>(0);

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.projectInfoDataFlavor};

		public ProjectInfoTable()
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
	//	public boolean equals(Object val) {
	//		if ( !(val instanceof ProjectInfoTable) ) {
	//			return false;
	//		}
	//		final String lastUpdate = "lastUpdate";
	//		ProjectInfoTable group = (ProjectInfoTable)val;
	//		Iterator iter = group.o_map.keySet().iterator();
	//		while ( iter.hasNext() ) {
	//			String key = (String)iter.next();
	//			if ( key.equals(lastUpdate) )
	//				continue;
	//			else if ( !group.o_map.get(key).equals(o_map.get(key)) ) {
	//				return false;
	//			}
	//		}
	//		return true;
	//	}

		public virtual object clone()
		{
			ProjectInfoTable obj = new ProjectInfoTable();

			obj.ProjectInfoId = ProjectInfoId;
			obj.EpsCode = EpsCode;
			obj.LastUpdate = LastUpdate;
			obj.CreateDate = CreateDate;
			obj.Description = Description;
			obj.Code = Code;
			obj.Title = Title;
			obj.CodeStyle = CodeStyle;
			obj.EditorId = EditorId;
			obj.StorageType = StorageType;
			obj.Status = Status;
			obj.TotalCost = TotalCost;
			obj.OfferedPrice = OfferedPrice;
			obj.SubmissionDate = SubmissionDate;
			obj.DefaultRevision = DefaultRevision;
			obj.Currency = Currency;
			obj.HasBimTakeoff = HasBimTakeoff;
			obj.HasOnScreenTakeoff = HasOnScreenTakeoff;

			obj.PrimaveraConnected = PrimaveraConnected;
			obj.Location = Location;
			obj.GeoLocation = GeoLocation;
			obj.LocationFactors = LocationFactors;
			obj.LocationProfile = LocationProfile;
			obj.SelectedFactor = SelectedFactor;

			obj.CustomEpsRate1 = CustomEpsRate1;
			obj.CustomEpsRate2 = CustomEpsRate2;
			obj.CustomEpsRate3 = CustomEpsRate3;
			obj.CustomEpsRate4 = CustomEpsRate4;
			obj.CustomEpsRate5 = CustomEpsRate5;
			obj.CustomEpsRate6 = CustomEpsRate6;
			obj.CustomEpsRate7 = CustomEpsRate7;
			obj.CustomEpsRate8 = CustomEpsRate8;
			obj.CustomEpsRate9 = CustomEpsRate9;
			obj.CustomEpsRate10 = CustomEpsRate10;

			obj.CustomEpsText1 = CustomEpsText1;
			obj.CustomEpsText2 = CustomEpsText2;
			obj.CustomEpsText3 = CustomEpsText3;
			obj.CustomEpsText4 = CustomEpsText4;
			obj.CustomEpsText5 = CustomEpsText5;
			obj.CustomEpsText6 = CustomEpsText6;
			obj.CustomEpsText7 = CustomEpsText7;
			obj.CustomEpsText8 = CustomEpsText8;
			obj.CustomEpsText9 = CustomEpsText9;
			obj.CustomEpsText10 = CustomEpsText10;
			obj.CustomEpsText11 = CustomEpsText11;
			obj.CustomEpsText12 = CustomEpsText12;
			obj.CustomEpsText13 = CustomEpsText13;
			obj.CustomEpsText14 = CustomEpsText14;
			obj.CustomEpsText15 = CustomEpsText15;
			obj.CustomEpsText16 = CustomEpsText16;
			obj.CustomEpsText17 = CustomEpsText17;
			obj.CustomEpsText18 = CustomEpsText18;
			obj.CustomEpsText19 = CustomEpsText19;
			obj.CustomEpsText20 = CustomEpsText20;

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

			obj.CustomEpsDate1 = CustomEpsDate1;
			obj.CustomEpsDate2 = CustomEpsDate2;
			obj.CustomEpsDate3 = CustomEpsDate3;
			obj.CustomEpsDate4 = CustomEpsDate4;
			obj.CustomEpsDate5 = CustomEpsDate5;
			obj.CustomEpsDate6 = CustomEpsDate6;
			obj.CustomEpsDate7 = CustomEpsDate7;
			obj.CustomEpsDate8 = CustomEpsDate8;
			obj.CustomEpsDate9 = CustomEpsDate9;
			obj.CustomEpsDate10 = CustomEpsDate10;

			obj.EquipmentHours = EquipmentHours;
			obj.LaborManhours = LaborManhours;
			obj.ConsumableTotalCost = ConsumableTotalCost;
			obj.LaborTotalCost = LaborTotalCost;
			obj.MaterialTotalCost = MaterialTotalCost;
			obj.SubcontractorTotalCost = SubcontractorTotalCost;
			obj.EquipmentTotalCost = EquipmentTotalCost;

			obj.Unit = Unit;
			obj.Country = Country;
			obj.Client = Client;
			obj.StateProvince = StateProvince;
			obj.ProjectType = ProjectType;
			obj.SubCategory = SubCategory;
			obj.ProjectIconMediaId = ProjectIconMediaId;
			obj.BasementSize = BasementSize;
			obj.Contractor = Contractor;
			obj.SuperstructureSize = SuperstructureSize;
			obj.UnitCost = UnitCost;
			obj.ClientBudget = ClientBudget;
			obj.Floors = Floors;
			obj.PaymentDuration = PaymentDuration;

			return obj;
		}

		public virtual ProjectInfoTable copyWithWBS()
		{
			ProjectInfoTable obj = (ProjectInfoTable)copyWithEPS();

			if (WbsSet != null)
			{
				obj.wbsSet = new HashSet<object>();
				System.Collections.IEnumerator iter = wbsSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectWBSTable curWBS = (ProjectWBSTable)iter.Current;
					obj.wbsSet.Add((ProjectWBSTable)curWBS.clone());
				}
			}
			if (Wbs2Set != null)
			{
				obj.wbs2Set = new HashSet<object>();
				System.Collections.IEnumerator iter = wbs2Set.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectWBS2Table curWBS = (ProjectWBS2Table)iter.Current;
					obj.wbs2Set.Add((ProjectWBS2Table)curWBS.clone());
				}
			}
			if (UrlSet != null)
			{
				obj.urlSet = new HashSet<object>();
				System.Collections.IEnumerator iter = urlSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectUrlTable curUrl = (ProjectUrlTable)iter.Current;
					obj.urlSet.Add((ProjectUrlTable)curUrl.clone());
				}
			}
			if (UserSet != null)
			{
				obj.userSet = new HashSet<object>();
				System.Collections.IEnumerator iter = userSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectUserTable curUrl = (ProjectUserTable)iter.Current;
					obj.userSet.Add((ProjectUserTable)curUrl.clone());
				}
			}

			return obj;
		}

		public virtual ProjectInfoTable copyWithAssignments()
		{
			ProjectInfoTable obj = (ProjectInfoTable)clone();

			if (UrlSet != null)
			{
				obj.urlSet = new HashSet<object>();
				System.Collections.IEnumerator iter = urlSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectUrlTable curUrl = (ProjectUrlTable)iter.Current;
					obj.urlSet.Add((ProjectUrlTable)curUrl.copy());
				}
			}
			if (UserSet != null)
			{
				obj.userSet = new HashSet<object>();
				System.Collections.IEnumerator iter = userSet.GetEnumerator();
				while (iter.MoveNext())
				{
					ProjectUserTable curUrl = (ProjectUserTable)iter.Current;
					obj.userSet.Add((ProjectUserTable)curUrl.clone());
				}
			}

			return obj;
		}

		public virtual ProjectInfoTable copyWithEPS()
		{
			ProjectInfoTable obj = (ProjectInfoTable)clone();

			if (ProjectEPSTable != null)
			{
				obj.ProjectEPSTable = (ProjectEPSTable) projectEPSTable.clone();
			}

			return obj;
		}

		public virtual ProjectInfoTable Data
		{
			set
			{
				//setConsumableId(value.getConsumableId());
				LastUpdate = value.LastUpdate;
				Description = value.Description;
				Code = value.Code;
				Title = value.Title;
				CodeStyle = value.CodeStyle;
				EditorId = value.EditorId;
				EpsCode = value.EpsCode;
				CreateDate = value.CreateDate;
    
				PrimaveraConnected = value.PrimaveraConnected;
				Status = value.Status;
				TotalCost = value.TotalCost;
				OfferedPrice = value.OfferedPrice;
				SubmissionDate = value.SubmissionDate;
				DefaultRevision = value.DefaultRevision;
				Currency = value.Currency;
				StorageType = value.StorageType;
				HasBimTakeoff = value.HasBimTakeoff;
				HasOnScreenTakeoff = value.HasOnScreenTakeoff;
    
				Location = value.Location;
				GeoLocation = value.GeoLocation;
				LocationFactors = value.LocationFactors;
				LocationProfile = value.LocationProfile;
				SelectedFactor = value.SelectedFactor;
    
				CustomEpsRate1 = value.CustomEpsRate1;
				CustomEpsRate2 = value.CustomEpsRate2;
				CustomEpsRate3 = value.CustomEpsRate3;
				CustomEpsRate4 = value.CustomEpsRate4;
				CustomEpsRate5 = value.CustomEpsRate5;
				CustomEpsRate6 = value.CustomEpsRate6;
				CustomEpsRate7 = value.CustomEpsRate7;
				CustomEpsRate8 = value.CustomEpsRate8;
				CustomEpsRate9 = value.CustomEpsRate9;
				CustomEpsRate10 = value.CustomEpsRate10;
    
				CustomEpsText1 = value.CustomEpsText1;
				CustomEpsText2 = value.CustomEpsText2;
				CustomEpsText3 = value.CustomEpsText3;
				CustomEpsText4 = value.CustomEpsText4;
				CustomEpsText5 = value.CustomEpsText5;
				CustomEpsText6 = value.CustomEpsText6;
				CustomEpsText7 = value.CustomEpsText7;
				CustomEpsText8 = value.CustomEpsText8;
				CustomEpsText9 = value.CustomEpsText9;
				CustomEpsText10 = value.CustomEpsText10;
				CustomEpsText11 = value.CustomEpsText11;
				CustomEpsText12 = value.CustomEpsText12;
				CustomEpsText13 = value.CustomEpsText13;
				CustomEpsText14 = value.CustomEpsText14;
				CustomEpsText15 = value.CustomEpsText15;
				CustomEpsText16 = value.CustomEpsText16;
				CustomEpsText17 = value.CustomEpsText17;
				CustomEpsText18 = value.CustomEpsText18;
				CustomEpsText19 = value.CustomEpsText19;
				CustomEpsText20 = value.CustomEpsText20;
    
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
    
				CustomEpsDate1 = value.CustomEpsDate1;
				CustomEpsDate2 = value.CustomEpsDate2;
				CustomEpsDate3 = value.CustomEpsDate3;
				CustomEpsDate4 = value.CustomEpsDate4;
				CustomEpsDate5 = value.CustomEpsDate5;
				CustomEpsDate6 = value.CustomEpsDate6;
				CustomEpsDate7 = value.CustomEpsDate7;
				CustomEpsDate8 = value.CustomEpsDate8;
				CustomEpsDate9 = value.CustomEpsDate9;
				CustomEpsDate10 = value.CustomEpsDate10;
    
				EquipmentHours = value.EquipmentHours;
				LaborManhours = value.LaborManhours;
				ConsumableTotalCost = value.ConsumableTotalCost;
				LaborTotalCost = value.LaborTotalCost;
				MaterialTotalCost = value.MaterialTotalCost;
				SubcontractorTotalCost = value.SubcontractorTotalCost;
				EquipmentTotalCost = value.EquipmentTotalCost;
    
				Unit = value.Unit;
				Country = value.Country;
				Client = value.Client;
				StateProvince = value.StateProvince;
				ProjectType = value.ProjectType;
				SubCategory = value.SubCategory;
				ProjectIconMediaId = value.ProjectIconMediaId;
				BasementSize = value.BasementSize;
				Contractor = value.Contractor;
				BasementSize = value.BasementSize;
				SuperstructureSize = value.SuperstructureSize;
				UnitCost = value.UnitCost;
				ClientBudget = value.ClientBudget;
				Floors = value.Floors;
				PaymentDuration = value.PaymentDuration;
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, ProjectInfoTable data)
		{
			if (field.Equals("title"))
			{
				Title = data.Title;
			}
			else if (field.Equals("description"))
			{
				Description = data.Description;
			}
			else if (field.Equals("codeStyle"))
			{
				CodeStyle = data.CodeStyle;
			}
		}

		public virtual long? Id
		{
			get
			{
				return projectInfoId;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PROJECTINFOID" </summary>
		/// <returns> Long </returns>
		public virtual long? ProjectInfoId
		{
			get
			{
				return projectInfoId;
			}
			set
			{
				projectInfoId = value;
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
		/// @hibernate.property column="EPSCODE" type="costos_string" </summary>
		/// <returns> lastUpdate </returns>
		public virtual string EpsCode
		{
			get
			{
				return epsCode;
			}
			set
			{
				this.epsCode = value;
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
		/// @hibernate.property column="CURRENCY" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				currency = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRIMAVERA" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? PrimaveraConnected
		{
			get
			{
				return primaveraConnected;
			}
			set
			{
				this.primaveraConnected = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="LOCFAC" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? LocationFactors
		{
			get
			{
				return locationFactors;
			}
			set
			{
				this.locationFactors = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCPROF" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string LocationProfile
		{
			get
			{
				return locationProfile;
			}
			set
			{
				this.locationProfile = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SELFAC" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string SelectedFactor
		{
			get
			{
				return selectedFactor;
			}
			set
			{
				this.selectedFactor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BIMTAKEOFF" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? HasBimTakeoff
		{
			get
			{
				return hasBimTakeoff;
			}
			set
			{
				this.hasBimTakeoff = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OSTAKEOFF" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? HasOnScreenTakeoff
		{
			get
			{
				return hasOnScreenTakeoff;
			}
			set
			{
				this.hasOnScreenTakeoff = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STORAGETYPE" type="costos_string" </summary>
		/// <returns> openUrl </returns>
		public virtual string StorageType
		{
			get
			{
				return storageType;
			}
			set
			{
				this.storageType = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CODESTYLE" type="costos_string" </summary>
		/// <returns> codeStyle </returns>
		public virtual string CodeStyle
		{
			get
			{
				return codeStyle;
			}
			set
			{
				if (string.ReferenceEquals(value, null))
				{
					value = DOTTED_STYLE;
				}
    
				codeStyle = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CODE" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				code = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="TOTALCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="OFFEREDPRICE" type="big_decimal" precision="30" scale="10" </summary>
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
		/// @hibernate.property column="STATUS" type="costos_string" </summary>
		/// <returns> status </returns>
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
				this.unit = value;
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
				this.country = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CLIENT" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string Client
		{
			get
			{
				return client;
			}
			set
			{
				this.client = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BASEMENT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal BasementSize
		{
			get
			{
				return basementSize;
			}
			set
			{
				this.basementSize = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MAINSITE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal SuperstructureSize
		{
			get
			{
				return superstructureSize;
			}
			set
			{
				this.superstructureSize = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNITCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal UnitCost
		{
			get
			{
				return unitCost;
			}
			set
			{
				this.unitCost = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATE" type="costos_string" </summary>
		/// <returns> country </returns>
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
		/// @hibernate.property column="PRJTYPE" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string ProjectType
		{
			get
			{
				return projectType;
			}
			set
			{
				this.projectType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRJSUBCAT" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string SubCategory
		{
			get
			{
				return subCategory;
			}
			set
			{
				this.subCategory = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PRJICONID" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string ProjectIconMediaId
		{
			get
			{
				return projectIconMediaId;
			}
			set
			{
				this.projectIconMediaId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONTRACTOR" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string Contractor
		{
			get
			{
				return contractor;
			}
			set
			{
				this.contractor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GEOLOC" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string GeoLocation
		{
			get
			{
				return geoLocation;
			}
			set
			{
				this.geoLocation = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FLOORS" type="int" </summary>
		/// <returns> country </returns>
		public virtual int? Floors
		{
			get
			{
				return floors;
			}
			set
			{
				this.floors = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DURATION" type="int" </summary>
		/// <returns> country </returns>
		public virtual int? PaymentDuration
		{
			get
			{
				return paymentDuration;
			}
			set
			{
				this.paymentDuration = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CLIENTBUDGET" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ClientBudget
		{
			get
			{
				return clientBudget;
			}
			set
			{
				this.clientBudget = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBDATE" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime SubmissionDate
		{
			get
			{
				return submissionDate;
			}
			set
			{
				this.submissionDate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DEFREV" type="costos_string" </summary>
		/// <returns> the default project revision </returns>
		public virtual string DefaultRevision
		{
			get
			{
				return defaultRevision;
			}
			set
			{
				this.defaultRevision = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate1
		{
			get
			{
				return customEpsRate1;
			}
			set
			{
				this.customEpsRate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate2
		{
			get
			{
				return customEpsRate2;
			}
			set
			{
				this.customEpsRate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate3
		{
			get
			{
				return customEpsRate3;
			}
			set
			{
				this.customEpsRate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate4
		{
			get
			{
				return customEpsRate4;
			}
			set
			{
				this.customEpsRate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate5
		{
			get
			{
				return customEpsRate5;
			}
			set
			{
				this.customEpsRate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE6" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate6
		{
			get
			{
				return customEpsRate6;
			}
			set
			{
				this.customEpsRate6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE7" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate7
		{
			get
			{
				return customEpsRate7;
			}
			set
			{
				this.customEpsRate7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE8" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate8
		{
			get
			{
				return customEpsRate8;
			}
			set
			{
				this.customEpsRate8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE9" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate9
		{
			get
			{
				return customEpsRate9;
			}
			set
			{
				this.customEpsRate9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSRATE10" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal CustomEpsRate10
		{
			get
			{
				return customEpsRate10;
			}
			set
			{
				this.customEpsRate10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT1" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText1
		{
			get
			{
				return customEpsText1;
			}
			set
			{
				this.customEpsText1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT2" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText2
		{
			get
			{
				return customEpsText2;
			}
			set
			{
				this.customEpsText2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT3" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText3
		{
			get
			{
				return customEpsText3;
			}
			set
			{
				this.customEpsText3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT4" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText4
		{
			get
			{
				return customEpsText4;
			}
			set
			{
				this.customEpsText4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT5" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText5
		{
			get
			{
				return customEpsText5;
			}
			set
			{
				this.customEpsText5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT6" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText6
		{
			get
			{
				return customEpsText6;
			}
			set
			{
				this.customEpsText6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT7" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText7
		{
			get
			{
				return customEpsText7;
			}
			set
			{
				this.customEpsText7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT8" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText8
		{
			get
			{
				return customEpsText8;
			}
			set
			{
				this.customEpsText8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT9" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText9
		{
			get
			{
				return customEpsText9;
			}
			set
			{
				this.customEpsText9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT10" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string CustomEpsText10
		{
			get
			{
				return customEpsText10;
			}
			set
			{
				this.customEpsText10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT11" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText11
		{
			get
			{
				return customEpsText11;
			}
			set
			{
				this.customEpsText11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT12" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText12
		{
			get
			{
				return customEpsText12;
			}
			set
			{
				this.customEpsText12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT13" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText13
		{
			get
			{
				return customEpsText13;
			}
			set
			{
				this.customEpsText13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT14" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText14
		{
			get
			{
				return customEpsText14;
			}
			set
			{
				this.customEpsText14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT15" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText15
		{
			get
			{
				return customEpsText15;
			}
			set
			{
				this.customEpsText15 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT16" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText16
		{
			get
			{
				return customEpsText16;
			}
			set
			{
				this.customEpsText16 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT17" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText17
		{
			get
			{
				return customEpsText17;
			}
			set
			{
				this.customEpsText17 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT18" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText18
		{
			get
			{
				return customEpsText18;
			}
			set
			{
				this.customEpsText18 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT19" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText19
		{
			get
			{
				return customEpsText19;
			}
			set
			{
				this.customEpsText19 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSTEXT20" type="costos_string" </summary>
		/// <returns> customEpsText </returns>
		public virtual string CustomEpsText20
		{
			get
			{
				return customEpsText20;
			}
			set
			{
				this.customEpsText20 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE6" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE7" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE8" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="CUSCUMRATE9" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// @hibernate.property column="CUSCUMRATE10" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
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
		/// @hibernate.property column="CUSEPSDATE1" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate1
		{
			get
			{
				return customEpsDate1;
			}
			set
			{
				this.customEpsDate1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE2" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate2
		{
			get
			{
				return customEpsDate2;
			}
			set
			{
				this.customEpsDate2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE3" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate3
		{
			get
			{
				return customEpsDate3;
			}
			set
			{
				this.customEpsDate3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE4" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate4
		{
			get
			{
				return customEpsDate4;
			}
			set
			{
				this.customEpsDate4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE5" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate5
		{
			get
			{
				return customEpsDate5;
			}
			set
			{
				this.customEpsDate5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE6" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate6
		{
			get
			{
				return customEpsDate6;
			}
			set
			{
				this.customEpsDate6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE7" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate7
		{
			get
			{
				return customEpsDate7;
			}
			set
			{
				this.customEpsDate7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE8" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate8
		{
			get
			{
				return customEpsDate8;
			}
			set
			{
				this.customEpsDate8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE9" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate9
		{
			get
			{
				return customEpsDate9;
			}
			set
			{
				this.customEpsDate9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CUSEPSDATE10" type="timestamp" </summary>
		/// <returns> Date </returns>
		public virtual DateTime CustomEpsDate10
		{
			get
			{
				return customEpsDate10;
			}
			set
			{
				this.customEpsDate10 = value;
			}
		}


		/// <summary>
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


		public override string ToString()
		{
			return Code + " - " + Title;
		}

		public virtual void recalculate()
		{
			if (ProjectEPSTable != null)
			{
				EpsCode = ProjectEPSTable.ToString();
			}
			else
			{
				EpsCode = null;
			}
		}
		//#RXP_START
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTINFOID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectWBSTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		//#RXP_END
		public virtual ISet<ProjectWBSTable> WbsSet
		{
			get
			{
				return wbsSet;
			}
			set
			{
				this.wbsSet = value;
			}
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTINFOID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.TakeoffConditionTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<TakeoffConditionTable> TakeoffSet
		{
			get
			{
				return takeoffSet;
			}
			set
			{
				this.takeoffSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTINFOID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectUrlTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectUrlTable> UrlSet
		{
			get
			{
				return urlSet;
			}
			set
			{
				this.urlSet = value;
			}
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTINFOID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectUserTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectUserTable> UserSet
		{
			get
			{
				return userSet;
			}
			set
			{
				this.userSet = value;
			}
		}
		//#RXP_START
		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTINFOID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectWBS2Table"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		//#RXP_END
		public virtual ISet<ProjectWBS2Table> Wbs2Set
		{
			get
			{
				return wbs2Set;
			}
			set
			{
				this.wbs2Set = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTEPSID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
		public virtual ProjectEPSTable ProjectEPSTable
		{
			get
			{
				return projectEPSTable;
			}
			set
			{
				this.projectEPSTable = value;
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
			return DataFlavors.projectInfoDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.projectInfoDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCode_sorted()
		public virtual string Code_sorted
		{
			get
			{
				return code;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCodeStyle_sorted()
		public virtual string CodeStyle_sorted
		{
			get
			{
				return codeStyle;
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

		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}

		public virtual decimal calculateDiscount()
		{
			if (ClientBudget.doubleValue() == 0)
			{
				return BigDecimalMath.ZERO;
			}
			return BigDecimalMath.ONE.subtract(TotalCost.divide(ClientBudget,BothDBPreferences.Instance.BigDecimalDividerScale,BothDBPreferences.Instance.BigDecimalRoundingMode)).multiply(new BigDecimalFixed("100"));
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATORID" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public override string CreateUserId
		{
			get
			{
				return EditorId;
			}
			set
			{
    
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public override DateTime CreateDate
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

	}

}