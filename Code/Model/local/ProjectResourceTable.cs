using System;
using System.Collections.Generic;

namespace Model.local
{

	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using Indexed = org.hibernate.search.annotations.Indexed;

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using LayoutTable = Desktop.common.nomitech.common.db.layout.LayoutTable;
	using BoqItemConsumableTable = Desktop.common.nomitech.common.db.project.BoqItemConsumableTable;
	using BoqItemEquipmentTable = Desktop.common.nomitech.common.db.project.BoqItemEquipmentTable;
	using BoqItemLaborTable = Desktop.common.nomitech.common.db.project.BoqItemLaborTable;
	using BoqItemMaterialTable = Desktop.common.nomitech.common.db.project.BoqItemMaterialTable;
	using BoqItemSubcontractorTable = Desktop.common.nomitech.common.db.project.BoqItemSubcontractorTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using ExprAbstractEvaluationContext = Desktop.common.nomitech.common.expr.ExprAbstractEvaluationContext;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BoqItemEvaluationContext = Desktop.common.nomitech.common.expr.boqitem.BoqItemEvaluationContext;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using ExchangeRateUtil = Desktop.common.nomitech.common.util.ExchangeRateUtil;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;

	//#RXL_START
	/// <summary>
	/// @author dimitris
	/// @hibernate.class table="PROJECTRESOURCE" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
	//#RXL_END

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ProjectResourceTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class ProjectResourceTable : ResourceTable, ProjectIdEntity, Transferable
	{

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.projectResourceDataFlavor};

		public static readonly string[] ASSIGNMENT_RESOURCE_FIELDS = new string[] {"itemCode", "title", "notes", "unit", "resourceAssignmentRate", "currency"};

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"projectResourceId", "resourceType", "itemCode", "title", "description", "notes", "unit", "rate", "rateFormula", "currency", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20", "customPercentRate1", "customPercentRate2", "customPercentRate3", "customPercentRate4", "customPercentRate5", "customPercentRate6", "customPercentRate7", "customPercentRate8", "customPercentRate9", "customPercentRate10", "customPercentRate11", "customPercentRate12", "customPercentRate13", "customPercentRate14", "customPercentRate15", "customPercentRate16", "customPercentRate17", "customPercentRate18", "customPercentRate19", "customPercentRate20"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal)};

		public static readonly string[] FORMULA_FIELDS = new string[]{"rateFormula"};

		private static BoqItemTable boqItemTableSingleInstance;

		private long? projectResourceId;
		private long? projectId;
		private long? parentId;

		private string resourceType;
		private string itemCode;
		private string title;
		private string description;
		private string notes;
		private string unit;
		private decimal rate;
		private string rateFormula;
		private string currency;

		private string editorId;
		private DateTime lastUpdate;
		private string createUserId;
		private DateTime createDate;

		// Group Codes:
		private string groupCode;
		private string gekCode;
		private string extraCode1;
		private string extraCode2;
		private string extraCode3;
		private string extraCode4;
		private string extraCode5;
		private string extraCode6;
		private string extraCode7;

		// Custom Texts:
		private string customText1;
		private string customText2;
		private string customText3;
		private string customText4;
		private string customText5;
		private string customText6;
		private string customText7;
		private string customText8;
		private string customText9;
		private string customText10;
		private string customText11;
		private string customText12;
		private string customText13;
		private string customText14;
		private string customText15;
		private string customText16;
		private string customText17;
		private string customText18;
		private string customText19;
		private string customText20;
		private string customText21;
		private string customText22;
		private string customText23;
		private string customText24;
		private string customText25;

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

		// Custom Percentage Rates:
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

		public override object Clone()
		{
			ProjectResourceTable obj = new ProjectResourceTable();

			obj.ProjectResourceId = ProjectResourceId;
			obj.ProjectId = ProjectId;
			obj.ParentId = ParentId;

			obj.ResourceType = ResourceType;
			obj.Project = Project;
			obj.ItemCode = ItemCode;
			obj.Title = Title;
			obj.Description = Description;
			obj.Notes = Notes;
			obj.Unit = Unit;
			obj.Rate = Rate;
			obj.RateFormula = RateFormula;
			obj.Currency = Currency;

			obj.EditorId = EditorId;
			obj.LastUpdate = LastUpdate;
			obj.CreateUserId = CreateUserId;
			obj.CreateDate = CreateDate;

			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.ExtraCode1 = ExtraCode1;
			obj.ExtraCode2 = ExtraCode2;
			obj.ExtraCode3 = ExtraCode3;
			obj.ExtraCode4 = ExtraCode4;
			obj.ExtraCode5 = ExtraCode5;
			obj.ExtraCode6 = ExtraCode6;
			obj.ExtraCode7 = ExtraCode7;

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

			return (object) obj;
		}

		public virtual ProjectResourceTable Data
		{
			set
			{
				ResourceType = value.ResourceType;
				Project = value.Project;
				ItemCode = value.ItemCode;
				Title = value.Title;
				Description = value.Description;
				Notes = value.Notes;
				Unit = value.Unit;
				Rate = value.Rate;
				RateFormula = value.RateFormula;
				Currency = value.Currency;
    
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
				CreateUserId = value.CreateUserId;
				CreateDate = value.CreateDate;
    
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				ExtraCode1 = value.ExtraCode1;
				ExtraCode2 = value.ExtraCode2;
				ExtraCode3 = value.ExtraCode3;
				ExtraCode4 = value.ExtraCode4;
				ExtraCode5 = value.ExtraCode5;
				ExtraCode6 = value.ExtraCode6;
				ExtraCode7 = value.ExtraCode7;
    
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
			return DataFlavors.projectResourceDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.projectResourceDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public virtual BoqItemTable convertToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			switch (resourceType)
			{
			case LayoutTable.LABOR:
				return convertLaborProjectResourceToBoqItem(paymentDate, code, prjDBUtil, useProductivity);
			case LayoutTable.EQUIPMENT:
				return convertEquipmentProjectResourceToBoqItem(paymentDate, code, prjDBUtil, useProductivity);
			case LayoutTable.CONSUMABLE:
				return convertConsumableProjectResourceToBoqItem(paymentDate, code, prjDBUtil, useProductivity);
			case LayoutTable.SUBCONTRACTOR:
				return convertSubcontractorProjectResourceToBoqItem(paymentDate, code, prjDBUtil, useProductivity);
			default:
				return convertMaterialProjectResourceToBoqItem(paymentDate, code, prjDBUtil, useProductivity);
			}
		}

		public virtual BoqItemTable convertLaborProjectResourceToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			if (!resourceType.Equals(LayoutTable.LABOR))
			{
				return null;
			}

			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);

			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(Unit);
			boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(Unit);
			boqTable.ActivityBased = false;

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

			LaborTable laborTable = BlankResourceInitializer.createBlankLabor(this);
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

			boqLaborTable.LaborTable = laborTable;
			boqLaborTable.BoqItemTable = boqTable;

			boqLaborTable.QuantityPerUnit = boqLaborTable.UnitHours;
			boqLaborTable.TotalUnits = boqLaborTable.UnitHours;

			boqTable.BoqItemLaborSet.Add(boqLaborTable);

			boqTable.recalculate();

			return boqTable;
		}

		public virtual BoqItemTable convertMaterialProjectResourceToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			if (!resourceType.Equals(LayoutTable.MATERIAL))
			{
				return null;
			}

			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);

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

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			MaterialTable materialTable = BlankResourceInitializer.createBlankMaterial(this);
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

			boqMaterialTable.MaterialTable = materialTable;
			boqMaterialTable.BoqItemTable = boqTable;

			boqTable.BoqItemMaterialSet.Add(boqMaterialTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public virtual BoqItemTable convertConsumableProjectResourceToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			if (!resourceType.Equals(LayoutTable.CONSUMABLE))
			{
				return null;
			}

			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);

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

			ConsumableTable consumableTable = BlankResourceInitializer.createBlankConsumable(this);
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

			boqConsumableTable.ConsumableTable = consumableTable;
			boqConsumableTable.BoqItemTable = boqTable;

			boqTable.BoqItemConsumableSet.Add(boqConsumableTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public virtual BoqItemTable convertSubcontractorProjectResourceToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			if (!resourceType.Equals(LayoutTable.SUBCONTRACTOR))
			{
				return null;
			}

			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate,useProductivity);

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

			SubcontractorTable subcontractorTable = BlankResourceInitializer.createBlankSubcontractor(this);
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

			boqSubcontractorTable.SubcontractorTable = subcontractorTable;
			boqSubcontractorTable.BoqItemTable = boqTable;

			boqTable.BoqItemSubcontractorSet.Add(boqSubcontractorTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public virtual BoqItemTable convertEquipmentProjectResourceToBoqItem(DateTime paymentDate, long? code, ProjectDBUtil prjDBUtil, bool useProductivity)
		{
			if (!resourceType.Equals(LayoutTable.EQUIPMENT))
			{
				return null;
			}

			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, paymentDate, useProductivity);

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
			boqTable.ActivityBased = false;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();

			EquipmentTable equipmentTable = BlankResourceInitializer.createBlankEquipment(this);
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

			boqEquipmentTable.EquipmentTable = equipmentTable;
			boqEquipmentTable.BoqItemTable = boqTable;

			boqEquipmentTable.QuantityPerUnit = boqEquipmentTable.UnitHours;
			boqEquipmentTable.TotalUnits = boqEquipmentTable.UnitHours;

			boqTable.BoqItemEquipmentSet.Add(boqEquipmentTable);

			boqTable.CalculatedRate = boqTable.Rate;
			boqTable.CalculatedTotalCost = boqTable.TotalCost;
			boqTable.recalculate();

			return boqTable;
		}

		public override long? Id
		{
			get
			{
				return projectResourceId;
			}
		}

		public override decimal TableRate
		{
			get
			{
				return rate;
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
				Data = (ProjectResourceTable) value;
			}
		}

		public override void setFieldData(string field, ResourceTable resourceTable)
		{
			// TODO ???
		}

		public override string ExtraCode8
		{
			get
			{
				return "";
			}
		}

		public override string ExtraCode9
		{
			get
			{
				return "";
			}
		}

		public override string ExtraCode10
		{
			get
			{
				return "";
			}
		}


		public override bool? Predicted
		{
			get
			{
				return false;
			}
		}

		public override bool? Virtual
		{
			get
			{
				return false;
			}
		}

		public override decimal Quantity
		{
			get
			{
				return null;
			}
			set
			{
    
			}
		}


		public override void recalculate()
		{
			try
			{
				if (StringUtils.isNullOrBlank(rateFormula))
				{
					return;
				}
				ExprAbstractEvaluationContext context = new BoqItemEvaluationContext(BoqItemTableSingleInstance, "rateFormula");
				Expr expr = context.parseStatement(rateFormula);
				if (expr is ExprDouble)
				{
					Rate = new decimal(((ExprDouble) expr).doubleValue());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

		private BoqItemTable BoqItemTableSingleInstance
		{
			get
			{
				lock (this)
				{
					if (boqItemTableSingleInstance == null)
					{
						boqItemTableSingleInstance = BlankResourceInitializer.createBlankBoqItem(null, null, null, false);
					}
					return boqItemTableSingleInstance;
				}
			}
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
				return null;
			}
		}

		public override string Project
		{
			get
			{
				return "";
			}
			set
			{
    
			}
		}


		/// <summary>
		/// @hibernate.id column="ID"
		///               generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public virtual long? ProjectResourceId
		{
			get
			{
				return projectResourceId;
			}
			set
			{
				this.projectResourceId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PARENTID" type="long" index="IDX_PARENTID" </summary>
		/// <returns> parentId </returns>
		public virtual long? ParentId
		{
			get
			{
				return parentId;
			}
			set
			{
				this.parentId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> projectId </returns>
		public virtual long? ProjectId
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


		/// <summary>
		/// @hibernate.property column="RESTYPE" type="costos_string" </summary>
		/// <returns> resourceType </returns>
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
		/// @hibernate.property column="RESCODE" type="costos_string" </summary>
		/// <returns> itemCode </returns>
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
		/// <returns> title </returns>
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
				this.description = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="NOTES" type="costos_text" </summary>
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
				this.rate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RATEFORM" type="costos_text" </summary>
		/// <returns> rateFormula </returns>
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
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
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


	}

}