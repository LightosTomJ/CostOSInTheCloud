using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="QUERYRESOURCE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ParamItemQueryResourceTable : BaseTable, ProjectIdEntity
	{

		public const int CUSTOM_FIELDS_INDEX_START = 19;

		public static readonly string[] ITEM_VARIABLES = new string[] {"ITEM_TITLE", "ITEM_ESTIMATED_QUANTITY", "ITEM_DESCRIPTION", "ITEM_NOTES", "ITEM_PRODUCTIVITY", "ITEM_PRODUCTIVITY_FACTOR", "ITEM_PAYMENT_DATE", "ITEM_WBS_CODE1", "ITEM_WBS_CODE2", "ITEM_PUBLISHED_ITEM_CODE", "ITEM_LOCATION", "ITEM_GROUP_CODE1", "ITEM_GROUP_CODE2", "ITEM_GROUP_CODE3", "ITEM_GROUP_CODE4", "ITEM_GROUP_CODE5", "ITEM_GROUP_CODE6", "ITEM_GROUP_CODE7", "ITEM_GROUP_CODE8", "ITEM_GROUP_CODE9", "ITEM_CUSTOM_TEXT1", "ITEM_CUSTOM_TEXT2", "ITEM_CUSTOM_TEXT3", "ITEM_CUSTOM_TEXT4", "ITEM_CUSTOM_TEXT5", "ITEM_CUSTOM_TEXT6", "ITEM_CUSTOM_TEXT7", "ITEM_CUSTOM_TEXT8", "ITEM_CUSTOM_TEXT9", "ITEM_CUSTOM_TEXT10", "ITEM_CUSTOM_TEXT11", "ITEM_CUSTOM_TEXT12", "ITEM_CUSTOM_TEXT13", "ITEM_CUSTOM_TEXT14", "ITEM_CUSTOM_TEXT15", "ITEM_CUSTOM_TEXT16", "ITEM_CUSTOM_TEXT17", "ITEM_CUSTOM_TEXT18", "ITEM_CUSTOM_TEXT19", "ITEM_CUSTOM_TEXT20", "ITEM_CUSTOM_TEXT21", "ITEM_CUSTOM_TEXT22", "ITEM_CUSTOM_TEXT23", "ITEM_CUSTOM_TEXT24", "ITEM_CUSTOM_TEXT25", "ITEM_CUSTOM_DECIMAL1", "ITEM_CUSTOM_DECIMAL2", "ITEM_CUSTOM_DECIMAL3", "ITEM_CUSTOM_DECIMAL4", "ITEM_CUSTOM_DECIMAL5", "ITEM_CUSTOM_DECIMAL6", "ITEM_CUSTOM_DECIMAL7", "ITEM_CUSTOM_DECIMAL8", "ITEM_CUSTOM_DECIMAL9", "ITEM_CUSTOM_DECIMAL10", "ITEM_CUSTOM_DECIMAL11", "ITEM_CUSTOM_DECIMAL12", "ITEM_CUSTOM_DECIMAL13", "ITEM_CUSTOM_DECIMAL14", "ITEM_CUSTOM_DECIMAL15", "ITEM_CUSTOM_DECIMAL16", "ITEM_CUSTOM_DECIMAL17", "ITEM_CUSTOM_DECIMAL18", "ITEM_CUSTOM_DECIMAL19", "ITEM_CUSTOM_DECIMAL20", "ITEM_CUSTOM_CUM_DECIMAL1", "ITEM_CUSTOM_CUM_DECIMAL2", "ITEM_CUSTOM_CUM_DECIMAL3", "ITEM_CUSTOM_CUM_DECIMAL4", "ITEM_CUSTOM_CUM_DECIMAL5", "ITEM_CUSTOM_CUM_DECIMAL6", "ITEM_CUSTOM_CUM_DECIMAL7", "ITEM_CUSTOM_CUM_DECIMAL8", "ITEM_CUSTOM_CUM_DECIMAL9", "ITEM_CUSTOM_CUM_DECIMAL10", "ITEM_CUSTOM_CUM_DECIMAL11", "ITEM_CUSTOM_CUM_DECIMAL12", "ITEM_CUSTOM_CUM_DECIMAL13", "ITEM_CUSTOM_CUM_DECIMAL14", "ITEM_CUSTOM_CUM_DECIMAL15", "ITEM_CUSTOM_CUM_DECIMAL16", "ITEM_CUSTOM_CUM_DECIMAL17", "ITEM_CUSTOM_CUM_DECIMAL18", "ITEM_CUSTOM_CUM_DECIMAL19", "ITEM_CUSTOM_CUM_DECIMAL20"};

		public static readonly string[] ITEM_FIELDS = new string[] {"title", "estimatedQuantity", "description", "notes", "productivity", "prodFactor", "paymentDate", "wbsCode", "wbs2Code", "publishedItemCode", "location", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20", "customCumRate1", "customCumRate2", "customCumRate3", "customCumRate4", "customCumRate5", "customCumRate6", "customCumRate7", "customCumRate8", "customCumRate9", "customCumRate10", "customCumRate11", "customCumRate12", "customCumRate13", "customCumRate14", "customCumRate15", "customCumRate16", "customCumRate17", "customCumRate18", "customCumRate19", "customCumRate20"};

		public static readonly Type[] ITEM_CLASSES = new Type[] {typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal)};

		public const int EXEC_TYPE_ALWAYS = 0; // or null
		public const int EXEC_TYPE_AFTER_FAIL = 1;
		public const int EXEC_TYPE_AFTER_SUCCESS = 2;

		public const int SQL_TYPE = 0; // or null
		public const int JSON_TYPE = 1;

		private long? id;
		private string title;
		private string jsonUrl;
		private string resourceType;
		private string orderField;
		private bool? asceding;
		private bool? singleSelection;
		private string titleEquation;
		private string estimatedQuantityEquation;
		private string descriptionEquation;
		private string notesEquation;
		private string paymentDateEquation;
		private string productivityEquation;
		private string prodFactorEquation;

		// Group Codes
		private string wbsCodeEquation;
		private string wbs2CodeEquation;
		private string locationEquation;
		private string publishedItemCodeEquation;

		private string groupCodeEquation;
		private string gekCodeEquation;
		private string extraCode1Equation;
		private string extraCode2Equation;
		private string extraCode3Equation;
		private string extraCode4Equation;
		private string extraCode5Equation;
		private string extraCode6Equation;
		private string extraCode7Equation;

		// Custom Text
		private string customText1Equation;
		private string customText2Equation;
		private string customText3Equation;
		private string customText4Equation;
		private string customText5Equation;
		private string customText6Equation;
		private string customText7Equation;
		private string customText8Equation;
		private string customText9Equation;
		private string customText10Equation;
		private string customText11Equation;
		private string customText12Equation;
		private string customText13Equation;
		private string customText14Equation;
		private string customText15Equation;
		private string customText16Equation;
		private string customText17Equation;
		private string customText18Equation;
		private string customText19Equation;
		private string customText20Equation;
		private string customText21Equation;
		private string customText22Equation;
		private string customText23Equation;
		private string customText24Equation;
		private string customText25Equation;

		// Custom Decimal
		private string customRate1Equation;
		private string customRate2Equation;
		private string customRate3Equation;
		private string customRate4Equation;
		private string customRate5Equation;
		private string customRate6Equation;
		private string customRate7Equation;
		private string customRate8Equation;
		private string customRate9Equation;
		private string customRate10Equation;
		private string customRate11Equation;
		private string customRate12Equation;
		private string customRate13Equation;
		private string customRate14Equation;
		private string customRate15Equation;
		private string customRate16Equation;
		private string customRate17Equation;
		private string customRate18Equation;
		private string customRate19Equation;
		private string customRate20Equation;

		// Custom Cumulative Rate
		private string customCumRate1Equation;
		private string customCumRate2Equation;
		private string customCumRate3Equation;
		private string customCumRate4Equation;
		private string customCumRate5Equation;
		private string customCumRate6Equation;
		private string customCumRate7Equation;
		private string customCumRate8Equation;
		private string customCumRate9Equation;
		private string customCumRate10Equation;
		private string customCumRate11Equation;
		private string customCumRate12Equation;
		private string customCumRate13Equation;
		private string customCumRate14Equation;
		private string customCumRate15Equation;
		private string customCumRate16Equation;
		private string customCumRate17Equation;
		private string customCumRate18Equation;
		private string customCumRate19Equation;
		private string customCumRate20Equation;

		// Types
		private int? executionType;
		private int? type;

		private ParamItemOutputTable paramItemOutputTable;
		private IList<ParamItemQueryRowTable> queryRowList = new List<ParamItemQueryRowTable>(0);

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="QRESID" </summary>
		/// <returns> Long </returns>
		public override long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXECTYPE" type="int" </summary>
		/// <returns> executionType </returns>
		public virtual int? ExecutionType
		{
			get
			{
				return executionType;
			}
			set
			{
				this.executionType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TYPE" type="int" </summary>
		/// <returns> type </returns>
		public virtual int? Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="JSONURL" type="costos_string" </summary>
		/// <returns> jsonUrl </returns>
		public virtual string JsonUrl
		{
			get
			{
				return jsonUrl;
			}
			set
			{
				this.jsonUrl = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESTYPE" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string ResourceType
		{
			get
			{
				return resourceType;
			}
			set
			{
				this.resourceType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ORDFLD" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string OrderField
		{
			get
			{
				return orderField;
			}
			set
			{
				this.orderField = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ASCDNG" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? Asceding
		{
			get
			{
				return asceding;
			}
			set
			{
				this.asceding = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SNGSEL" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? SingleSelection
		{
			get
			{
				return singleSelection;
			}
			set
			{
				this.singleSelection = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TLTEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string TitleEquation
		{
			get
			{
				return titleEquation;
			}
			set
			{
				this.titleEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ESTQNTEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string EstimatedQuantityEquation
		{
			get
			{
				return estimatedQuantityEquation;
			}
			set
			{
				this.estimatedQuantityEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DSCEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string DescriptionEquation
		{
			get
			{
				return descriptionEquation;
			}
			set
			{
				this.descriptionEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="NTSEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string NotesEquation
		{
			get
			{
				return notesEquation;
			}
			set
			{
				this.notesEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string LocationEquation
		{
			get
			{
				return locationEquation;
			}
			set
			{
				this.locationEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PDTEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string PaymentDateEquation
		{
			get
			{
				return paymentDateEquation;
			}
			set
			{
				this.paymentDateEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRDEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string ProductivityEquation
		{
			get
			{
				return productivityEquation;
			}
			set
			{
				this.productivityEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRFEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string ProdFactorEquation
		{
			get
			{
				return prodFactorEquation;
			}
			set
			{
				this.prodFactorEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WB1EQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string WbsCodeEquation
		{
			get
			{
				return wbsCodeEquation;
			}
			set
			{
				this.wbsCodeEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="WB2EQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Wbs2CodeEquation
		{
			get
			{
				return wbs2CodeEquation;
			}
			set
			{
				this.wbs2CodeEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PICEQ" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string PublishedItemCodeEquation
		{
			get
			{
				return publishedItemCodeEquation;
			}
			set
			{
				this.publishedItemCodeEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC1EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string GroupCodeEquation
		{
			get
			{
				return groupCodeEquation;
			}
			set
			{
				this.groupCodeEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC2EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string GekCodeEquation
		{
			get
			{
				return gekCodeEquation;
			}
			set
			{
				this.gekCodeEquation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC3EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode1Equation
		{
			get
			{
				return extraCode1Equation;
			}
			set
			{
				this.extraCode1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC4EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode2Equation
		{
			get
			{
				return extraCode2Equation;
			}
			set
			{
				this.extraCode2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC5EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode3Equation
		{
			get
			{
				return extraCode3Equation;
			}
			set
			{
				this.extraCode3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC6EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode4Equation
		{
			get
			{
				return extraCode4Equation;
			}
			set
			{
				this.extraCode4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC7EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode5Equation
		{
			get
			{
				return extraCode5Equation;
			}
			set
			{
				this.extraCode5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC8EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode6Equation
		{
			get
			{
				return extraCode6Equation;
			}
			set
			{
				this.extraCode6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GC9EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string ExtraCode7Equation
		{
			get
			{
				return extraCode7Equation;
			}
			set
			{
				this.extraCode7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText1Equation
		{
			get
			{
				return customText1Equation;
			}
			set
			{
				this.customText1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText2Equation
		{
			get
			{
				return customText2Equation;
			}
			set
			{
				this.customText2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText3Equation
		{
			get
			{
				return customText3Equation;
			}
			set
			{
				this.customText3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText4Equation
		{
			get
			{
				return customText4Equation;
			}
			set
			{
				this.customText4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText5Equation
		{
			get
			{
				return customText5Equation;
			}
			set
			{
				this.customText5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText6Equation
		{
			get
			{
				return customText6Equation;
			}
			set
			{
				this.customText6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText7Equation
		{
			get
			{
				return customText7Equation;
			}
			set
			{
				this.customText7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText8Equation
		{
			get
			{
				return customText8Equation;
			}
			set
			{
				this.customText8Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText9Equation
		{
			get
			{
				return customText9Equation;
			}
			set
			{
				this.customText9Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT10EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText10Equation
		{
			get
			{
				return customText10Equation;
			}
			set
			{
				this.customText10Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT11EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText11Equation
		{
			get
			{
				return customText11Equation;
			}
			set
			{
				this.customText11Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT12EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText12Equation
		{
			get
			{
				return customText12Equation;
			}
			set
			{
				this.customText12Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT13EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText13Equation
		{
			get
			{
				return customText13Equation;
			}
			set
			{
				this.customText13Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT14EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText14Equation
		{
			get
			{
				return customText14Equation;
			}
			set
			{
				this.customText14Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT15EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText15Equation
		{
			get
			{
				return customText15Equation;
			}
			set
			{
				this.customText15Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT16EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText16Equation
		{
			get
			{
				return customText16Equation;
			}
			set
			{
				this.customText16Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT17EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText17Equation
		{
			get
			{
				return customText17Equation;
			}
			set
			{
				this.customText17Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT18EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText18Equation
		{
			get
			{
				return customText18Equation;
			}
			set
			{
				this.customText18Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT19EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomText19Equation
		{
			get
			{
				return customText19Equation;
			}
			set
			{
				this.customText19Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText20Equation
		{
			get
			{
				return customText20Equation;
			}
			set
			{
				this.customText20Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT21EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText21Equation
		{
			get
			{
				return customText21Equation;
			}
			set
			{
				this.customText21Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT22EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText22Equation
		{
			get
			{
				return customText22Equation;
			}
			set
			{
				this.customText22Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT23EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText23Equation
		{
			get
			{
				return customText23Equation;
			}
			set
			{
				this.customText23Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT24EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText24Equation
		{
			get
			{
				return customText24Equation;
			}
			set
			{
				this.customText24Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CT25EQ" type="costos_text"
		/// </summary>
		public virtual string CustomText25Equation
		{
			get
			{
				return customText25Equation;
			}
			set
			{
				this.customText25Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate1Equation
		{
			get
			{
				return customRate1Equation;
			}
			set
			{
				this.customRate1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate2Equation
		{
			get
			{
				return customRate2Equation;
			}
			set
			{
				this.customRate2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate3Equation
		{
			get
			{
				return customRate3Equation;
			}
			set
			{
				this.customRate3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate4Equation
		{
			get
			{
				return customRate4Equation;
			}
			set
			{
				this.customRate4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate5Equation
		{
			get
			{
				return customRate5Equation;
			}
			set
			{
				this.customRate5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate6Equation
		{
			get
			{
				return customRate6Equation;
			}
			set
			{
				this.customRate6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate7Equation
		{
			get
			{
				return customRate7Equation;
			}
			set
			{
				this.customRate7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate8Equation
		{
			get
			{
				return customRate8Equation;
			}
			set
			{
				this.customRate8Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate9Equation
		{
			get
			{
				return customRate9Equation;
			}
			set
			{
				this.customRate9Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR10EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate10Equation
		{
			get
			{
				return customRate10Equation;
			}
			set
			{
				this.customRate10Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR11EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate11Equation
		{
			get
			{
				return customRate11Equation;
			}
			set
			{
				this.customRate11Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR12EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate12Equation
		{
			get
			{
				return customRate12Equation;
			}
			set
			{
				this.customRate12Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR13EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate13Equation
		{
			get
			{
				return customRate13Equation;
			}
			set
			{
				this.customRate13Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR14EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomRate14Equation
		{
			get
			{
				return customRate14Equation;
			}
			set
			{
				this.customRate14Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR15EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate15Equation
		{
			get
			{
				return customRate15Equation;
			}
			set
			{
				this.customRate15Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR16EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate16Equation
		{
			get
			{
				return customRate16Equation;
			}
			set
			{
				this.customRate16Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR17EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate17Equation
		{
			get
			{
				return customRate17Equation;
			}
			set
			{
				this.customRate17Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR18EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate18Equation
		{
			get
			{
				return customRate18Equation;
			}
			set
			{
				this.customRate18Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR19EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate19Equation
		{
			get
			{
				return customRate19Equation;
			}
			set
			{
				this.customRate19Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CR20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomRate20Equation
		{
			get
			{
				return customRate20Equation;
			}
			set
			{
				this.customRate20Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC01EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate1Equation
		{
			get
			{
				return customCumRate1Equation;
			}
			set
			{
				this.customCumRate1Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC02EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate2Equation
		{
			get
			{
				return customCumRate2Equation;
			}
			set
			{
				this.customCumRate2Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC03EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate3Equation
		{
			get
			{
				return customCumRate3Equation;
			}
			set
			{
				this.customCumRate3Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC04EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate4Equation
		{
			get
			{
				return customCumRate4Equation;
			}
			set
			{
				this.customCumRate4Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC05EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate5Equation
		{
			get
			{
				return customCumRate5Equation;
			}
			set
			{
				this.customCumRate5Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC06EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate6Equation
		{
			get
			{
				return customCumRate6Equation;
			}
			set
			{
				this.customCumRate6Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC07EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate7Equation
		{
			get
			{
				return customCumRate7Equation;
			}
			set
			{
				this.customCumRate7Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC08EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate8Equation
		{
			get
			{
				return customCumRate8Equation;
			}
			set
			{
				this.customCumRate8Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC09EQ" type="costos_text" </summary>
		/// <returns> groupCodeEquation </returns>
		public virtual string CustomCumRate9Equation
		{
			get
			{
				return customCumRate9Equation;
			}
			set
			{
				this.customCumRate9Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC10EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate10Equation
		{
			get
			{
				return customCumRate10Equation;
			}
			set
			{
				this.customCumRate10Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC11EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate11Equation
		{
			get
			{
				return customCumRate11Equation;
			}
			set
			{
				this.customCumRate11Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC12EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate12Equation
		{
			get
			{
				return customCumRate12Equation;
			}
			set
			{
				this.customCumRate12Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC13EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate13Equation
		{
			get
			{
				return customCumRate13Equation;
			}
			set
			{
				this.customCumRate13Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC14EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate14Equation
		{
			get
			{
				return customCumRate14Equation;
			}
			set
			{
				this.customCumRate14Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC15EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate15Equation
		{
			get
			{
				return customCumRate15Equation;
			}
			set
			{
				this.customCumRate15Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC16EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate16Equation
		{
			get
			{
				return customCumRate16Equation;
			}
			set
			{
				this.customCumRate16Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC17EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate17Equation
		{
			get
			{
				return customCumRate17Equation;
			}
			set
			{
				this.customCumRate17Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC18EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate18Equation
		{
			get
			{
				return customCumRate18Equation;
			}
			set
			{
				this.customCumRate18Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC19EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate19Equation
		{
			get
			{
				return customCumRate19Equation;
			}
			set
			{
				this.customCumRate19Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CC20EQ" type="costos_text"
		/// </summary>
		public virtual string CustomCumRate20Equation
		{
			get
			{
				return customCumRate20Equation;
			}
			set
			{
				this.customCumRate20Equation = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="PARAMOUTPUTID" </summary>
		/// <returns> ParamItemOutputTable </returns>
		public virtual ParamItemOutputTable ParamItemOutputTable
		{
			get
			{
				return paramItemOutputTable;
			}
			set
			{
				this.paramItemOutputTable = value;
			}
		}


		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="QRESID"
		/// @hibernate.list-index
		///  column="QROWSCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemQueryRowTable" </summary>
		/// <returns> List </returns>
		public virtual IList<ParamItemQueryRowTable> QueryRowList
		{
			get
			{
				return queryRowList;
			}
			set
			{
				this.queryRowList = value;
			}
		}


		public override DateTime LastUpdate
		{
			get
			{
				return null;
			}
		}

		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}

		public virtual object Clone()
		{
			ParamItemQueryResourceTable obj = new ParamItemQueryResourceTable();
			obj.Id = Id;
			obj.Data = this;
			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual ParamItemQueryResourceTable copy()
		{
			ParamItemQueryResourceTable obj = (ParamItemQueryResourceTable) Clone();

			if (QueryRowList != null)
			{
				obj.QueryRowList = new List<ParamItemQueryRowTable>();
				foreach (ParamItemQueryRowTable queryRowTable in QueryRowList)
				{
					obj.QueryRowList.Add((ParamItemQueryRowTable) queryRowTable.clone());
				}
			}

			return obj;
		}

		public virtual ParamItemQueryResourceTable Data
		{
			set
			{
				ResourceType = value.ResourceType;
				Title = value.Title;
				JsonUrl = value.JsonUrl;
				Type = value.Type;
				ExecutionType = value.ExecutionType;
				Asceding = value.Asceding;
				SingleSelection = value.SingleSelection;
				OrderField = value.OrderField;
    
				TitleEquation = value.TitleEquation;
				EstimatedQuantityEquation = value.EstimatedQuantityEquation;
				DescriptionEquation = value.DescriptionEquation;
				NotesEquation = value.NotesEquation;
				PaymentDateEquation = value.PaymentDateEquation;
				GroupCodeEquation = value.GroupCodeEquation;
				GekCodeEquation = value.GekCodeEquation;
				PublishedItemCodeEquation = value.PublishedItemCodeEquation;
				ProductivityEquation = value.ProductivityEquation;
				ProdFactorEquation = value.ProdFactorEquation;
    
				WbsCodeEquation = value.WbsCodeEquation;
				Wbs2CodeEquation = value.Wbs2CodeEquation;
				LocationEquation = value.LocationEquation;
				ExtraCode1Equation = value.ExtraCode1Equation;
				ExtraCode2Equation = value.ExtraCode2Equation;
				ExtraCode3Equation = value.ExtraCode3Equation;
				ExtraCode4Equation = value.ExtraCode4Equation;
				ExtraCode5Equation = value.ExtraCode5Equation;
				ExtraCode6Equation = value.ExtraCode6Equation;
				ExtraCode7Equation = value.ExtraCode7Equation;
    
				CustomRate1Equation = value.CustomRate1Equation;
				CustomRate2Equation = value.CustomRate2Equation;
				CustomRate3Equation = value.CustomRate3Equation;
				CustomRate4Equation = value.CustomRate4Equation;
				CustomRate5Equation = value.CustomRate5Equation;
				CustomRate6Equation = value.CustomRate6Equation;
				CustomRate7Equation = value.CustomRate7Equation;
				CustomRate8Equation = value.CustomRate8Equation;
				CustomRate9Equation = value.CustomRate9Equation;
				CustomRate10Equation = value.CustomRate10Equation;
				CustomRate11Equation = value.CustomRate11Equation;
				CustomRate12Equation = value.CustomRate12Equation;
				CustomRate13Equation = value.CustomRate13Equation;
				CustomRate14Equation = value.CustomRate14Equation;
				CustomRate15Equation = value.CustomRate15Equation;
				CustomRate16Equation = value.CustomRate16Equation;
				CustomRate17Equation = value.CustomRate17Equation;
				CustomRate18Equation = value.CustomRate18Equation;
				CustomRate19Equation = value.CustomRate19Equation;
				CustomRate20Equation = value.CustomRate20Equation;
    
				CustomCumRate1Equation = value.CustomCumRate1Equation;
				CustomCumRate2Equation = value.CustomCumRate2Equation;
				CustomCumRate3Equation = value.CustomCumRate3Equation;
				CustomCumRate4Equation = value.CustomCumRate4Equation;
				CustomCumRate5Equation = value.CustomCumRate5Equation;
				CustomCumRate6Equation = value.CustomCumRate6Equation;
				CustomCumRate7Equation = value.CustomCumRate7Equation;
				CustomCumRate8Equation = value.CustomCumRate8Equation;
				CustomCumRate9Equation = value.CustomCumRate9Equation;
				CustomCumRate10Equation = value.CustomCumRate10Equation;
				CustomCumRate11Equation = value.CustomCumRate11Equation;
				CustomCumRate12Equation = value.CustomCumRate12Equation;
				CustomCumRate13Equation = value.CustomCumRate13Equation;
				CustomCumRate14Equation = value.CustomCumRate14Equation;
				CustomCumRate15Equation = value.CustomCumRate15Equation;
				CustomCumRate16Equation = value.CustomCumRate16Equation;
				CustomCumRate17Equation = value.CustomCumRate17Equation;
				CustomCumRate18Equation = value.CustomCumRate18Equation;
				CustomCumRate19Equation = value.CustomCumRate19Equation;
				CustomCumRate20Equation = value.CustomCumRate20Equation;
    
				CustomText1Equation = value.CustomText1Equation;
				CustomText2Equation = value.CustomText2Equation;
				CustomText3Equation = value.CustomText3Equation;
				CustomText4Equation = value.CustomText4Equation;
				CustomText5Equation = value.CustomText5Equation;
				CustomText6Equation = value.CustomText6Equation;
				CustomText7Equation = value.CustomText7Equation;
				CustomText8Equation = value.CustomText8Equation;
				CustomText9Equation = value.CustomText9Equation;
				CustomText10Equation = value.CustomText10Equation;
				CustomText11Equation = value.CustomText11Equation;
				CustomText12Equation = value.CustomText12Equation;
				CustomText13Equation = value.CustomText13Equation;
				CustomText14Equation = value.CustomText14Equation;
				CustomText15Equation = value.CustomText15Equation;
				CustomText16Equation = value.CustomText16Equation;
				CustomText17Equation = value.CustomText17Equation;
				CustomText18Equation = value.CustomText18Equation;
				CustomText19Equation = value.CustomText19Equation;
				CustomText20Equation = value.CustomText20Equation;
				CustomText21Equation = value.CustomText21Equation;
				CustomText22Equation = value.CustomText22Equation;
				CustomText23Equation = value.CustomText23Equation;
				CustomText24Equation = value.CustomText24Equation;
				CustomText25Equation = value.CustomText25Equation;
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