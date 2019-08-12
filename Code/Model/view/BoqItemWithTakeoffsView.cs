using System;

namespace Model.view
{

	[Serializable]
	public class BoqItemWithTakeoffsView
	{

		private string projectName;
		private string projectCode;
		private string projectCurrency;
		private string projectCountry;
		private string projectClientName;
		private string projectSignature;
		private string projectDescription;
		private string projectClientBudget;
		private string projectJobSize;
		private string projectUnit;
		private string projectBasementSize;
		private string projectDuration;
		private string projectEPS;
		private string projectEPSLevel1Code;
		private string projectEPSLevel1Title;
		private string projectEPSLevel2Code;
		private string projectEPSLevel2Title;
		private string projectEPSLevel3Code;
		private string projectEPSLevel3Title;
		private string projectEPSLevel4Code;
		private string projectEPSLevel4Title;
		private string projectEPSLevel5Code;
		private string projectEPSLevel5Title;

		private long? boqitemId;
		private long? boqItemCode;
		private string boqItemTitle;
		private string boqItemAssemblyId;
		private string boqItemAssemblyTitle;
		private string boqItemEditorId;
		private string boqItemCreateUserId;
		private string boqItemEstimator;
		private DateTime boqItemPaymentDate;
		private DateTime boqItemLastUpdate;
		private DateTime boqItemCreateDate;
		private string boqItemStatus;
		private string boqItemAccuracy;
		private int? boqItemFlag;
		private string boqItemLocalizationCountry;
		private string boqItemLocalizationState;
		private string boqItemLocalizationFactor;
		private decimal boqItemQuantity1;
		private decimal boqItemQuantity2;
		private bool? boqItemActivityBased;
		private decimal boqItemEstimatedQuantity;
		private decimal boqItemTakeoffQuantity;
		private decimal boqItemQuantityLoss;
		private sbyte? boqItemConditionQT;
		private bool? boqItemHasProductivity;
		private decimal boqItemDuration;
		private decimal boqItemProductivity;
		private decimal boqItemProductivityFactor;
		private decimal boqItemAdjustedProductivity;
		private decimal boqItemTotalManHours;
		private decimal boqItemEquipmentHours;
		private decimal boqItemUnitManHours;
		private decimal boqItemUnitManHoursFactor;
		private decimal boqItemAdjustedUnitManHours;
		private string boqItemUnit1;
		private string boqItemUnit2;
		private decimal boqItemUnitDivider;
		private decimal boqItemLineItemRate;
		private sbyte? boqItemLineItemRT;
		private decimal boqItemEquipmentRate;
		private sbyte? boqItemEquipmentRT;
		private decimal boqItemSubcontractorRate;
		private decimal boqItemSubcontractorQuotedRate;
		private sbyte? boqItemSubcontractorRateRT;
		private decimal boqItemLaborRate;
		private sbyte? boqItemLaborRT;
		private decimal boqItemMaterialRate;
		private decimal boqItemMaterialQuotedRate;
		private sbyte? boqItemMaterialRateRT;
		private decimal boqItemConsumableRate;
		private sbyte? boqItemConsumableRateRT;
		private decimal boqItemFabricationRate;
		private decimal boqItemShipmentRate;
		private decimal boqItemTotalRate1;
		private decimal boqItemTotalRate2;
		private decimal boqItemPublishedRate;
		private decimal boqItemOfferedRate1;
		private decimal boqItemOfferedRate2;
		private decimal boqItemLineItemCost;
		private decimal boqItemEquipmentCost;
		private decimal boqItemSubcontractorCost;
		private decimal boqItemLaborCost;
		private decimal boqItemMaterialCost;
		private decimal boqItemConsumableCost;
		private decimal boqItemFabricationCost;
		private decimal boqItemShipmentCost;
		private decimal boqItemMaterialResourcesCost;
		private decimal boqItemTotalCost;
		private decimal boqItemOfferedPrice;
		private decimal boqItemMarkup;
		private decimal boqItemEscalation;
		private string boqItemCustomText1;
		private string boqItemCustomText2;
		private string boqItemCustomText3;
		private string boqItemCustomText4;
		private string boqItemCustomText5;
		private string boqItemCustomText6;
		private string boqItemCustomText7;
		private string boqItemCustomText8;
		private string boqItemCustomText9;
		private string boqItemCustomText10;
		private string boqItemCustomText11;
		private string boqItemCustomText12;
		private string boqItemCustomText13;
		private string boqItemCustomText14;
		private string boqItemCustomText15;
		private string boqItemCustomText16;
		private string boqItemCustomText17;
		private string boqItemCustomText18;
		private string boqItemCustomText19;
		private string boqItemCustomText20;
		private decimal boqItemCustomDecimal1;
		private decimal boqItemCustomDecimal2;
		private decimal boqItemCustomDecimal3;
		private decimal boqItemCustomDecimal4;
		private decimal boqItemCustomDecimal5;
		private decimal boqItemCustomDecimal6;
		private decimal boqItemCustomDecimal7;
		private decimal boqItemCustomDecimal8;
		private decimal boqItemCustomDecimal9;
		private decimal boqItemCustomDecimal10;
		private decimal boqItemCustomCumDecimal1;
		private decimal boqItemCustomCumDecimal2;
		private decimal boqItemCustomCumDecimal3;
		private decimal boqItemCustomCumDecimal4;
		private decimal boqItemCustomCumDecimal5;
		private decimal boqItemCustomPercentange1;
		private decimal boqItemCustomPercentange2;
		private decimal boqItemCustomPercentange3;
		private decimal boqItemCustomPercentange4;
		private decimal boqItemCustomPercentange5;
		private decimal boqItemCustomPercentange6;
		private decimal boqItemCustomPercentange7;
		private decimal boqItemCustomPercentange8;
		private decimal boqItemCustomPercentange9;
		private decimal boqItemCustomPercentange10;
		private string boqItemPublishedItemCode;
		private string boqItemPublishedRevisionCode;
		private string boqItemWbsCode1;
		private string boqItemWbsCode1Level1Code;
		private string boqItemWbsCode1Level2Code;
		private string boqItemWbsCode1Level3Code;
		private string boqItemWbsCode1Level4Code;
		private string boqItemWbsCode1Level5Code;
		private string boqItemWbsCode1Level1Title;
		private string boqItemWbsCode1Level2Title;
		private string boqItemWbsCode1Level3Title;
		private string boqItemWbsCode1Level4Title;
		private string boqItemWbsCode1Level5Title;
		private string boqItemWbsCode2;
		private string boqItemWbsCode2Level1Code;
		private string boqItemWbsCode2Level2Code;
		private string boqItemWbsCode2Level3Code;
		private string boqItemWbsCode2Level4Code;
		private string boqItemWbsCode2Level5Code;
		private string boqItemWbsCode2Level1Title;
		private string boqItemWbsCode2Level2Title;
		private string boqItemWbsCode2Level3Title;
		private string boqItemWbsCode2Level4Title;
		private string boqItemWbsCode2Level5Title;
		private string boqItemLocation;
		private string boqItemLocationLevel1Code;
		private string boqItemLocationLevel2Code;
		private string boqItemLocationLevel3Code;
		private string boqItemLocationLevel4Code;
		private string boqItemLocationLevel5Code;
		private string boqItemLocationLevel1Title;
		private string boqItemLocationLevel2Title;
		private string boqItemLocationLevel3Title;
		private string boqItemLocationLevel4Title;
		private string boqItemLocationLevel5Title;
		private string boqItemGroupCode1;
		private string boqItemGroupCode1Level1Code;
		private string boqItemGroupCode1Level2Code;
		private string boqItemGroupCode1Level3Code;
		private string boqItemGroupCode1Level4Code;
		private string boqItemGroupCode1Level5Code;
		private string boqItemGroupCode1Level1Title;
		private string boqItemGroupCode1Level2Title;
		private string boqItemGroupCode1Level3Title;
		private string boqItemGroupCode1Level4Title;
		private string boqItemGroupCode1Level5Title;
		private string boqItemGroupCode1Level1Description;
		private string boqItemGroupCode1Level2Description;
		private string boqItemGroupCode1Level3Description;
		private string boqItemGroupCode1Level4Description;
		private string boqItemGroupCode1Level5Description;
		private string boqItemGroupCode1Level1Unit;
		private string boqItemGroupCode1Level2Unit;
		private string boqItemGroupCode1Level3Unit;
		private string boqItemGroupCode1Level4Unit;
		private string boqItemGroupCode1Level5Unit;
		private string boqItemGroupCode2;
		private string boqItemGroupCode2Level1Code;
		private string boqItemGroupCode2Level2Code;
		private string boqItemGroupCode2Level3Code;
		private string boqItemGroupCode2Level4Code;
		private string boqItemGroupCode2Level5Code;
		private string boqItemGroupCode2Level1Title;
		private string boqItemGroupCode2Level2Title;
		private string boqItemGroupCode2Level3Title;
		private string boqItemGroupCode2Level4Title;
		private string boqItemGroupCode2Level5Title;
		private string boqItemGroupCode2Level1Description;
		private string boqItemGroupCode2Level2Description;
		private string boqItemGroupCode2Level3Description;
		private string boqItemGroupCode2Level4Description;
		private string boqItemGroupCode2Level5Description;
		private string boqItemGroupCode2Level1Unit;
		private string boqItemGroupCode2Level2Unit;
		private string boqItemGroupCode2Level3Unit;
		private string boqItemGroupCode2Level4Unit;
		private string boqItemGroupCode2Level5Unit;
		private string boqItemGroupCode3;
		private string boqItemGroupCode3Level1Code;
		private string boqItemGroupCode3Level2Code;
		private string boqItemGroupCode3Level3Code;
		private string boqItemGroupCode3Level4Code;
		private string boqItemGroupCode3Level5Code;
		private string boqItemGroupCode3Level1Title;
		private string boqItemGroupCode3Level2Title;
		private string boqItemGroupCode3Level3Title;
		private string boqItemGroupCode3Level4Title;
		private string boqItemGroupCode3Level5Title;
		private string boqItemGroupCode3Level1Description;
		private string boqItemGroupCode3Level2Description;
		private string boqItemGroupCode3Level3Description;
		private string boqItemGroupCode3Level4Description;
		private string boqItemGroupCode3Level5Description;
		private string boqItemGroupCode3Level1Unit;
		private string boqItemGroupCode3Level2Unit;
		private string boqItemGroupCode3Level3Unit;
		private string boqItemGroupCode3Level4Unit;
		private string boqItemGroupCode3Level5Unit;
		private string boqItemGroupCode4;
		private string boqItemGroupCode4Level1Code;
		private string boqItemGroupCode4Level2Code;
		private string boqItemGroupCode4Level3Code;
		private string boqItemGroupCode4Level4Code;
		private string boqItemGroupCode4Level5Code;
		private string boqItemGroupCode4Level1Title;
		private string boqItemGroupCode4Level2Title;
		private string boqItemGroupCode4Level3Title;
		private string boqItemGroupCode4Level4Title;
		private string boqItemGroupCode4Level5Title;
		private string boqItemGroupCode4Level1Description;
		private string boqItemGroupCode4Level2Description;
		private string boqItemGroupCode4Level3Description;
		private string boqItemGroupCode4Level4Description;
		private string boqItemGroupCode4Level5Description;
		private string boqItemGroupCode4Level1Unit;
		private string boqItemGroupCode4Level2Unit;
		private string boqItemGroupCode4Level3Unit;
		private string boqItemGroupCode4Level4Unit;
		private string boqItemGroupCode4Level5Unit;
		private string boqItemGroupCode5;
		private string boqItemGroupCode5Level1Code;
		private string boqItemGroupCode5Level2Code;
		private string boqItemGroupCode5Level3Code;
		private string boqItemGroupCode5Level4Code;
		private string boqItemGroupCode5Level5Code;
		private string boqItemGroupCode5Level1Title;
		private string boqItemGroupCode5Level2Title;
		private string boqItemGroupCode5Level3Title;
		private string boqItemGroupCode5Level4Title;
		private string boqItemGroupCode5Level5Title;
		private string boqItemGroupCode5Level1Description;
		private string boqItemGroupCode5Level2Description;
		private string boqItemGroupCode5Level3Description;
		private string boqItemGroupCode5Level4Description;
		private string boqItemGroupCode5Level5Description;
		private string boqItemGroupCode5Level1Unit;
		private string boqItemGroupCode5Level2Unit;
		private string boqItemGroupCode5Level3Unit;
		private string boqItemGroupCode5Level4Unit;
		private string boqItemGroupCode5Level5Unit;
		private string boqItemGroupCode6;
		private string boqItemGroupCode6Level1Code;
		private string boqItemGroupCode6Level2Code;
		private string boqItemGroupCode6Level3Code;
		private string boqItemGroupCode6Level4Code;
		private string boqItemGroupCode6Level5Code;
		private string boqItemGroupCode6Level1Title;
		private string boqItemGroupCode6Level2Title;
		private string boqItemGroupCode6Level3Title;
		private string boqItemGroupCode6Level4Title;
		private string boqItemGroupCode6Level5Title;
		private string boqItemGroupCode6Level1Description;
		private string boqItemGroupCode6Level2Description;
		private string boqItemGroupCode6Level3Description;
		private string boqItemGroupCode6Level4Description;
		private string boqItemGroupCode6Level5Description;
		private string boqItemGroupCode6Level1Unit;
		private string boqItemGroupCode6Level2Unit;
		private string boqItemGroupCode6Level3Unit;
		private string boqItemGroupCode6Level4Unit;
		private string boqItemGroupCode6Level5Unit;
		private string boqItemGroupCode7;
		private string boqItemGroupCode7Level1Code;
		private string boqItemGroupCode7Level2Code;
		private string boqItemGroupCode7Level3Code;
		private string boqItemGroupCode7Level4Code;
		private string boqItemGroupCode7Level5Code;
		private string boqItemGroupCode7Level1Title;
		private string boqItemGroupCode7Level2Title;
		private string boqItemGroupCode7Level3Title;
		private string boqItemGroupCode7Level4Title;
		private string boqItemGroupCode7Level5Title;
		private string boqItemGroupCode7Level1Description;
		private string boqItemGroupCode7Level2Description;
		private string boqItemGroupCode7Level3Description;
		private string boqItemGroupCode7Level4Description;
		private string boqItemGroupCode7Level5Description;
		private string boqItemGroupCode7Level1Unit;
		private string boqItemGroupCode7Level2Unit;
		private string boqItemGroupCode7Level3Unit;
		private string boqItemGroupCode7Level4Unit;
		private string boqItemGroupCode7Level5Unit;
		private string boqItemGroupCode8;
		private string boqItemGroupCode8Level1Code;
		private string boqItemGroupCode8Level2Code;
		private string boqItemGroupCode8Level3Code;
		private string boqItemGroupCode8Level4Code;
		private string boqItemGroupCode8Level5Code;
		private string boqItemGroupCode8Level1Title;
		private string boqItemGroupCode8Level2Title;
		private string boqItemGroupCode8Level3Title;
		private string boqItemGroupCode8Level4Title;
		private string boqItemGroupCode8Level5Title;
		private string boqItemGroupCode8Level1Description;
		private string boqItemGroupCode8Level2Description;
		private string boqItemGroupCode8Level3Description;
		private string boqItemGroupCode8Level4Description;
		private string boqItemGroupCode8Level5Description;
		private string boqItemGroupCode8Level1Unit;
		private string boqItemGroupCode8Level2Unit;
		private string boqItemGroupCode8Level3Unit;
		private string boqItemGroupCode8Level4Unit;
		private string boqItemGroupCode8Level5Unit;
		private string boqItemGroupCode9;
		private string boqItemGroupCode9Level1Code;
		private string boqItemGroupCode9Level2Code;
		private string boqItemGroupCode9Level3Code;
		private string boqItemGroupCode9Level4Code;
		private string boqItemGroupCode9Level5Code;
		private string boqItemGroupCode9Level1Title;
		private string boqItemGroupCode9Level2Title;
		private string boqItemGroupCode9Level3Title;
		private string boqItemGroupCode9Level4Title;
		private string boqItemGroupCode9Level5Title;
		private string boqItemGroupCode9Level1Description;
		private string boqItemGroupCode9Level2Description;
		private string boqItemGroupCode9Level3Description;
		private string boqItemGroupCode9Level4Description;
		private string boqItemGroupCode9Level5Description;
		private string boqItemGroupCode9Level1Unit;
		private string boqItemGroupCode9Level2Unit;
		private string boqItemGroupCode9Level3Unit;
		private string boqItemGroupCode9Level4Unit;
		private string boqItemGroupCode9Level5Unit;
		private string boqItemDescription;
		private string boqItemNotes;

		private long? assignmentId;
		private decimal assignmentFactor1;
		private decimal assignmentFactor2;
		private decimal assignmentWaste;
		private decimal assignmentSelectedQuantity;
		private decimal assignmentFinalQuantity;
		private string assignmentFinalUnit;
		private string assignmentQuantityName;
		private decimal assignmentTotalCost;
		private decimal assignmentLaborCost;
		private decimal assignmentMaterialCost;
		private decimal assignmentEquipmentCost;
		private decimal assignmentSubcontractorCost;
		private decimal assignmentLineItemCost;
		private decimal assignmentConsumableCost;

		private long? takeoffId;
		private string takeoffTitle;
		private string takeoffDescription;
		private string takeoffBimMaterial;
		private string takeoffBimType;
		private string takeoffGlobalId;
		private string takeoffType;
		private string takeoffGroup;
		private string takeoffBuilding;
		private string takeoffStorey;
		private string takeoffLocation;
		private string takeoffLayer;
		private string takeoffContainer;
		private decimal takeoffQuantity1;
		private decimal takeoffQuantity2;
		private decimal takeoffQuantity3;
		private string takeoffQuantity1Name;
		private string takeoffQuantity2Name;
		private string takeoffQuantity3Name;
		private string takeoffUnit1;
		private string takeoffUnit2;
		private string takeoffUnit3;

		private sbyte? boqItemEquipmentRateType;
		private sbyte? boqItemAssemblyRateType;
		private sbyte? boqItemSubcontractorRateType;
		private sbyte? boqItemLaborRateType;
		private sbyte? boqItemMaterialRateType;
		private sbyte? boqItemConsumableRateType;
		private sbyte? boqItemTakeoffQuantityType;

		private string boqItemWbsCode1Level1ItemCode;
		private string boqItemWbsCode1Level2ItemCode;
		private string boqItemWbsCode1Level3ItemCode;
		private string boqItemWbsCode1Level4ItemCode;
		private string boqItemWbsCode1Level5ItemCode;
		private string boqItemWbsCode2Level1ItemCode;
		private string boqItemWbsCode2Level2ItemCode;
		private string boqItemWbsCode2Level3ItemCode;
		private string boqItemWbsCode2Level4ItemCode;
		private string boqItemWbsCode2Level5ItemCode;

		public virtual string ProjectName
		{
			get
			{
				return projectName;
			}
			set
			{
				this.projectName = value;
			}
		}
		public virtual string ProjectCode
		{
			get
			{
				return projectCode;
			}
			set
			{
				this.projectCode = value;
			}
		}
		public virtual string ProjectCurrency
		{
			get
			{
				return projectCurrency;
			}
			set
			{
				this.projectCurrency = value;
			}
		}
		public virtual string ProjectCountry
		{
			get
			{
				return projectCountry;
			}
			set
			{
				this.projectCountry = value;
			}
		}
		public virtual string ProjectClientName
		{
			get
			{
				return projectClientName;
			}
			set
			{
				this.projectClientName = value;
			}
		}
		public virtual string ProjectSignature
		{
			get
			{
				return projectSignature;
			}
			set
			{
				this.projectSignature = value;
			}
		}
		public virtual string ProjectDescription
		{
			get
			{
				return projectDescription;
			}
			set
			{
				this.projectDescription = value;
			}
		}
		public virtual string ProjectEPS
		{
			get
			{
				return projectEPS;
			}
			set
			{
				this.projectEPS = value;
			}
		}
		public virtual string ProjectEPSLevel1Code
		{
			get
			{
				return projectEPSLevel1Code;
			}
			set
			{
				this.projectEPSLevel1Code = value;
			}
		}
		public virtual string ProjectEPSLevel1Title
		{
			get
			{
				return projectEPSLevel1Title;
			}
			set
			{
				this.projectEPSLevel1Title = value;
			}
		}
		public virtual string ProjectEPSLevel2Code
		{
			get
			{
				return projectEPSLevel2Code;
			}
			set
			{
				this.projectEPSLevel2Code = value;
			}
		}
		public virtual string ProjectEPSLevel2Title
		{
			get
			{
				return projectEPSLevel2Title;
			}
			set
			{
				this.projectEPSLevel2Title = value;
			}
		}
		public virtual string ProjectEPSLevel3Code
		{
			get
			{
				return projectEPSLevel3Code;
			}
			set
			{
				this.projectEPSLevel3Code = value;
			}
		}
		public virtual string ProjectEPSLevel3Title
		{
			get
			{
				return projectEPSLevel3Title;
			}
			set
			{
				this.projectEPSLevel3Title = value;
			}
		}
		public virtual string ProjectEPSLevel4Code
		{
			get
			{
				return projectEPSLevel4Code;
			}
			set
			{
				this.projectEPSLevel4Code = value;
			}
		}
		public virtual string ProjectEPSLevel4Title
		{
			get
			{
				return projectEPSLevel4Title;
			}
			set
			{
				this.projectEPSLevel4Title = value;
			}
		}
		public virtual string ProjectEPSLevel5Code
		{
			get
			{
				return projectEPSLevel5Code;
			}
			set
			{
				this.projectEPSLevel5Code = value;
			}
		}
		public virtual string ProjectEPSLevel5Title
		{
			get
			{
				return projectEPSLevel5Title;
			}
			set
			{
				this.projectEPSLevel5Title = value;
			}
		}
		public virtual string ProjectClientBudget
		{
			get
			{
				return projectClientBudget;
			}
			set
			{
				this.projectClientBudget = value;
			}
		}
		public virtual string ProjectJobSize
		{
			get
			{
				return projectJobSize;
			}
			set
			{
				this.projectJobSize = value;
			}
		}
		public virtual string ProjectUnit
		{
			get
			{
				return projectUnit;
			}
			set
			{
				this.projectUnit = value;
			}
		}
		public virtual string ProjectBasementSize
		{
			get
			{
				return projectBasementSize;
			}
			set
			{
				this.projectBasementSize = value;
			}
		}
		public virtual string ProjectDuration
		{
			get
			{
				return projectDuration;
			}
			set
			{
				this.projectDuration = value;
			}
		}
		public virtual long? BoqitemId
		{
			get
			{
				return boqitemId;
			}
			set
			{
				this.boqitemId = value;
			}
		}
		public virtual long? BoqItemCode
		{
			get
			{
				return boqItemCode;
			}
			set
			{
				this.boqItemCode = value;
			}
		}
		public virtual string BoqItemTitle
		{
			get
			{
				return boqItemTitle;
			}
			set
			{
				this.boqItemTitle = value;
			}
		}
		public virtual string BoqItemAssemblyId
		{
			get
			{
				return boqItemAssemblyId;
			}
			set
			{
				this.boqItemAssemblyId = value;
			}
		}
		public virtual string BoqItemAssemblyTitle
		{
			get
			{
				return boqItemAssemblyTitle;
			}
			set
			{
				this.boqItemAssemblyTitle = value;
			}
		}
		public virtual string BoqItemEditorId
		{
			get
			{
				return boqItemEditorId;
			}
			set
			{
				this.boqItemEditorId = value;
			}
		}
		public virtual string BoqItemCreateUserId
		{
			get
			{
				return boqItemCreateUserId;
			}
			set
			{
				this.boqItemCreateUserId = value;
			}
		}
		public virtual string BoqItemEstimator
		{
			get
			{
				return boqItemEstimator;
			}
			set
			{
				this.boqItemEstimator = value;
			}
		}
		public virtual DateTime BoqItemPaymentDate
		{
			get
			{
				return boqItemPaymentDate;
			}
			set
			{
				this.boqItemPaymentDate = value;
			}
		}
		public virtual DateTime BoqItemLastUpdate
		{
			get
			{
				return boqItemLastUpdate;
			}
			set
			{
				this.boqItemLastUpdate = value;
			}
		}
		public virtual DateTime BoqItemCreateDate
		{
			get
			{
				return boqItemCreateDate;
			}
			set
			{
				this.boqItemCreateDate = value;
			}
		}
		public virtual string BoqItemStatus
		{
			get
			{
				return boqItemStatus;
			}
			set
			{
				this.boqItemStatus = value;
			}
		}
		public virtual string BoqItemAccuracy
		{
			get
			{
				return boqItemAccuracy;
			}
			set
			{
				this.boqItemAccuracy = value;
			}
		}
		public virtual int? BoqItemFlag
		{
			get
			{
				return boqItemFlag;
			}
			set
			{
				this.boqItemFlag = value;
			}
		}
		public virtual string BoqItemLocalizationCountry
		{
			get
			{
				return boqItemLocalizationCountry;
			}
			set
			{
				this.boqItemLocalizationCountry = value;
			}
		}
		public virtual string BoqItemLocalizationState
		{
			get
			{
				return boqItemLocalizationState;
			}
			set
			{
				this.boqItemLocalizationState = value;
			}
		}
		public virtual string BoqItemLocalizationFactor
		{
			get
			{
				return boqItemLocalizationFactor;
			}
			set
			{
				this.boqItemLocalizationFactor = value;
			}
		}
		public virtual decimal BoqItemQuantity1
		{
			get
			{
				return boqItemQuantity1;
			}
			set
			{
				this.boqItemQuantity1 = value;
			}
		}
		public virtual decimal BoqItemQuantity2
		{
			get
			{
				return boqItemQuantity2;
			}
			set
			{
				this.boqItemQuantity2 = value;
			}
		}
		public virtual bool? BoqItemActivityBased
		{
			get
			{
				return boqItemActivityBased;
			}
			set
			{
				this.boqItemActivityBased = value;
			}
		}
		public virtual decimal BoqItemEstimatedQuantity
		{
			get
			{
				return boqItemEstimatedQuantity;
			}
			set
			{
				this.boqItemEstimatedQuantity = value;
			}
		}
		public virtual decimal BoqItemTakeoffQuantity
		{
			get
			{
				return boqItemTakeoffQuantity;
			}
			set
			{
				this.boqItemTakeoffQuantity = value;
			}
		}
		public virtual decimal BoqItemQuantityLoss
		{
			get
			{
				return boqItemQuantityLoss;
			}
			set
			{
				this.boqItemQuantityLoss = value;
			}
		}
		public virtual sbyte? BoqItemConditionQT
		{
			get
			{
				return boqItemConditionQT;
			}
			set
			{
				this.boqItemConditionQT = value;
			}
		}
		public virtual bool? BoqItemHasProductivity
		{
			get
			{
				return boqItemHasProductivity;
			}
			set
			{
				this.boqItemHasProductivity = value;
			}
		}
		public virtual decimal BoqItemDuration
		{
			get
			{
				return boqItemDuration;
			}
			set
			{
				this.boqItemDuration = value;
			}
		}
		public virtual decimal BoqItemProductivity
		{
			get
			{
				return boqItemProductivity;
			}
			set
			{
				this.boqItemProductivity = value;
			}
		}
		public virtual decimal BoqItemProductivityFactor
		{
			get
			{
				return boqItemProductivityFactor;
			}
			set
			{
				this.boqItemProductivityFactor = value;
			}
		}
		public virtual decimal BoqItemAdjustedProductivity
		{
			get
			{
				return boqItemAdjustedProductivity;
			}
			set
			{
				this.boqItemAdjustedProductivity = value;
			}
		}
		public virtual decimal BoqItemTotalManHours
		{
			get
			{
				return boqItemTotalManHours;
			}
			set
			{
				this.boqItemTotalManHours = value;
			}
		}
		public virtual decimal BoqItemEquipmentHours
		{
			get
			{
				return boqItemEquipmentHours;
			}
			set
			{
				this.boqItemEquipmentHours = value;
			}
		}
		public virtual decimal BoqItemUnitManHours
		{
			get
			{
				return boqItemUnitManHours;
			}
			set
			{
				this.boqItemUnitManHours = value;
			}
		}
		public virtual decimal BoqItemUnitManHoursFactor
		{
			get
			{
				return boqItemUnitManHoursFactor;
			}
			set
			{
				this.boqItemUnitManHoursFactor = value;
			}
		}
		public virtual decimal BoqItemAdjustedUnitManHours
		{
			get
			{
				return boqItemAdjustedUnitManHours;
			}
			set
			{
				this.boqItemAdjustedUnitManHours = value;
			}
		}
		public virtual string BoqItemUnit1
		{
			get
			{
				return boqItemUnit1;
			}
			set
			{
				this.boqItemUnit1 = value;
			}
		}
		public virtual string BoqItemUnit2
		{
			get
			{
				return boqItemUnit2;
			}
			set
			{
				this.boqItemUnit2 = value;
			}
		}
		public virtual decimal BoqItemUnitDivider
		{
			get
			{
				return boqItemUnitDivider;
			}
			set
			{
				this.boqItemUnitDivider = value;
			}
		}
		public virtual decimal BoqItemLineItemRate
		{
			get
			{
				return boqItemLineItemRate;
			}
			set
			{
				this.boqItemLineItemRate = value;
			}
		}
		public virtual sbyte? BoqItemLineItemRT
		{
			get
			{
				return boqItemLineItemRT;
			}
			set
			{
				this.boqItemLineItemRT = value;
			}
		}
		public virtual decimal BoqItemEquipmentRate
		{
			get
			{
				return boqItemEquipmentRate;
			}
			set
			{
				this.boqItemEquipmentRate = value;
			}
		}
		public virtual sbyte? BoqItemEquipmentRT
		{
			get
			{
				return boqItemEquipmentRT;
			}
			set
			{
				this.boqItemEquipmentRT = value;
			}
		}
		public virtual decimal BoqItemSubcontractorRate
		{
			get
			{
				return boqItemSubcontractorRate;
			}
			set
			{
				this.boqItemSubcontractorRate = value;
			}
		}
		public virtual decimal BoqItemSubcontractorQuotedRate
		{
			get
			{
				return boqItemSubcontractorQuotedRate;
			}
			set
			{
				this.boqItemSubcontractorQuotedRate = value;
			}
		}
		public virtual sbyte? BoqItemSubcontractorRateRT
		{
			get
			{
				return boqItemSubcontractorRateRT;
			}
			set
			{
				this.boqItemSubcontractorRateRT = value;
			}
		}
		public virtual decimal BoqItemLaborRate
		{
			get
			{
				return boqItemLaborRate;
			}
			set
			{
				this.boqItemLaborRate = value;
			}
		}
		public virtual sbyte? BoqItemLaborRT
		{
			get
			{
				return boqItemLaborRT;
			}
			set
			{
				this.boqItemLaborRT = value;
			}
		}
		public virtual decimal BoqItemMaterialRate
		{
			get
			{
				return boqItemMaterialRate;
			}
			set
			{
				this.boqItemMaterialRate = value;
			}
		}
		public virtual decimal BoqItemMaterialQuotedRate
		{
			get
			{
				return boqItemMaterialQuotedRate;
			}
			set
			{
				this.boqItemMaterialQuotedRate = value;
			}
		}
		public virtual sbyte? BoqItemMaterialRateRT
		{
			get
			{
				return boqItemMaterialRateRT;
			}
			set
			{
				this.boqItemMaterialRateRT = value;
			}
		}
		public virtual decimal BoqItemConsumableRate
		{
			get
			{
				return boqItemConsumableRate;
			}
			set
			{
				this.boqItemConsumableRate = value;
			}
		}
		public virtual sbyte? BoqItemConsumableRateRT
		{
			get
			{
				return boqItemConsumableRateRT;
			}
			set
			{
				this.boqItemConsumableRateRT = value;
			}
		}
		public virtual decimal BoqItemFabricationRate
		{
			get
			{
				return boqItemFabricationRate;
			}
			set
			{
				this.boqItemFabricationRate = value;
			}
		}
		public virtual decimal BoqItemShipmentRate
		{
			get
			{
				return boqItemShipmentRate;
			}
			set
			{
				this.boqItemShipmentRate = value;
			}
		}
		public virtual decimal BoqItemTotalRate1
		{
			get
			{
				return boqItemTotalRate1;
			}
			set
			{
				this.boqItemTotalRate1 = value;
			}
		}
		public virtual decimal BoqItemTotalRate2
		{
			get
			{
				return boqItemTotalRate2;
			}
			set
			{
				this.boqItemTotalRate2 = value;
			}
		}
		public virtual decimal BoqItemPublishedRate
		{
			get
			{
				return boqItemPublishedRate;
			}
			set
			{
				this.boqItemPublishedRate = value;
			}
		}
		public virtual decimal BoqItemOfferedRate1
		{
			get
			{
				return boqItemOfferedRate1;
			}
			set
			{
				this.boqItemOfferedRate1 = value;
			}
		}
		public virtual decimal BoqItemOfferedRate2
		{
			get
			{
				return boqItemOfferedRate2;
			}
			set
			{
				this.boqItemOfferedRate2 = value;
			}
		}
		public virtual decimal BoqItemLineItemCost
		{
			get
			{
				return boqItemLineItemCost;
			}
			set
			{
				this.boqItemLineItemCost = value;
			}
		}
		public virtual decimal BoqItemEquipmentCost
		{
			get
			{
				return boqItemEquipmentCost;
			}
			set
			{
				this.boqItemEquipmentCost = value;
			}
		}
		public virtual decimal BoqItemSubcontractorCost
		{
			get
			{
				return boqItemSubcontractorCost;
			}
			set
			{
				this.boqItemSubcontractorCost = value;
			}
		}
		public virtual decimal BoqItemLaborCost
		{
			get
			{
				return boqItemLaborCost;
			}
			set
			{
				this.boqItemLaborCost = value;
			}
		}
		public virtual decimal BoqItemMaterialCost
		{
			get
			{
				return boqItemMaterialCost;
			}
			set
			{
				this.boqItemMaterialCost = value;
			}
		}
		public virtual decimal BoqItemConsumableCost
		{
			get
			{
				return boqItemConsumableCost;
			}
			set
			{
				this.boqItemConsumableCost = value;
			}
		}
		public virtual decimal BoqItemFabricationCost
		{
			get
			{
				return boqItemFabricationCost;
			}
			set
			{
				this.boqItemFabricationCost = value;
			}
		}
		public virtual decimal BoqItemShipmentCost
		{
			get
			{
				return boqItemShipmentCost;
			}
			set
			{
				this.boqItemShipmentCost = value;
			}
		}
		public virtual decimal BoqItemMaterialResourcesCost
		{
			get
			{
				return boqItemMaterialResourcesCost;
			}
			set
			{
				this.boqItemMaterialResourcesCost = value;
			}
		}
		public virtual decimal BoqItemTotalCost
		{
			get
			{
				return boqItemTotalCost;
			}
			set
			{
				this.boqItemTotalCost = value;
			}
		}
		public virtual decimal BoqItemOfferedPrice
		{
			get
			{
				return boqItemOfferedPrice;
			}
			set
			{
				this.boqItemOfferedPrice = value;
			}
		}
		public virtual decimal BoqItemMarkup
		{
			get
			{
				return boqItemMarkup;
			}
			set
			{
				this.boqItemMarkup = value;
			}
		}
		public virtual decimal BoqItemEscalation
		{
			get
			{
				return boqItemEscalation;
			}
			set
			{
				this.boqItemEscalation = value;
			}
		}
		public virtual string BoqItemCustomText1
		{
			get
			{
				return boqItemCustomText1;
			}
			set
			{
				this.boqItemCustomText1 = value;
			}
		}
		public virtual string BoqItemCustomText2
		{
			get
			{
				return boqItemCustomText2;
			}
			set
			{
				this.boqItemCustomText2 = value;
			}
		}
		public virtual string BoqItemCustomText3
		{
			get
			{
				return boqItemCustomText3;
			}
			set
			{
				this.boqItemCustomText3 = value;
			}
		}
		public virtual string BoqItemCustomText4
		{
			get
			{
				return boqItemCustomText4;
			}
			set
			{
				this.boqItemCustomText4 = value;
			}
		}
		public virtual string BoqItemCustomText5
		{
			get
			{
				return boqItemCustomText5;
			}
			set
			{
				this.boqItemCustomText5 = value;
			}
		}
		public virtual string BoqItemCustomText6
		{
			get
			{
				return boqItemCustomText6;
			}
			set
			{
				this.boqItemCustomText6 = value;
			}
		}
		public virtual string BoqItemCustomText7
		{
			get
			{
				return boqItemCustomText7;
			}
			set
			{
				this.boqItemCustomText7 = value;
			}
		}
		public virtual string BoqItemCustomText8
		{
			get
			{
				return boqItemCustomText8;
			}
			set
			{
				this.boqItemCustomText8 = value;
			}
		}
		public virtual string BoqItemCustomText9
		{
			get
			{
				return boqItemCustomText9;
			}
			set
			{
				this.boqItemCustomText9 = value;
			}
		}
		public virtual string BoqItemCustomText10
		{
			get
			{
				return boqItemCustomText10;
			}
			set
			{
				this.boqItemCustomText10 = value;
			}
		}
		public virtual string BoqItemCustomText11
		{
			get
			{
				return boqItemCustomText11;
			}
			set
			{
				this.boqItemCustomText11 = value;
			}
		}
		public virtual string BoqItemCustomText12
		{
			get
			{
				return boqItemCustomText12;
			}
			set
			{
				this.boqItemCustomText12 = value;
			}
		}
		public virtual string BoqItemCustomText13
		{
			get
			{
				return boqItemCustomText13;
			}
			set
			{
				this.boqItemCustomText13 = value;
			}
		}
		public virtual string BoqItemCustomText14
		{
			get
			{
				return boqItemCustomText14;
			}
			set
			{
				this.boqItemCustomText14 = value;
			}
		}
		public virtual string BoqItemCustomText15
		{
			get
			{
				return boqItemCustomText15;
			}
			set
			{
				this.boqItemCustomText15 = value;
			}
		}
		public virtual string BoqItemCustomText16
		{
			get
			{
				return boqItemCustomText16;
			}
			set
			{
				this.boqItemCustomText16 = value;
			}
		}
		public virtual string BoqItemCustomText17
		{
			get
			{
				return boqItemCustomText17;
			}
			set
			{
				this.boqItemCustomText17 = value;
			}
		}
		public virtual string BoqItemCustomText18
		{
			get
			{
				return boqItemCustomText18;
			}
			set
			{
				this.boqItemCustomText18 = value;
			}
		}
		public virtual string BoqItemCustomText19
		{
			get
			{
				return boqItemCustomText19;
			}
			set
			{
				this.boqItemCustomText19 = value;
			}
		}
		public virtual string BoqItemCustomText20
		{
			get
			{
				return boqItemCustomText20;
			}
			set
			{
				this.boqItemCustomText20 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal1
		{
			get
			{
				return boqItemCustomDecimal1;
			}
			set
			{
				this.boqItemCustomDecimal1 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal2
		{
			get
			{
				return boqItemCustomDecimal2;
			}
			set
			{
				this.boqItemCustomDecimal2 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal3
		{
			get
			{
				return boqItemCustomDecimal3;
			}
			set
			{
				this.boqItemCustomDecimal3 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal4
		{
			get
			{
				return boqItemCustomDecimal4;
			}
			set
			{
				this.boqItemCustomDecimal4 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal5
		{
			get
			{
				return boqItemCustomDecimal5;
			}
			set
			{
				this.boqItemCustomDecimal5 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal6
		{
			get
			{
				return boqItemCustomDecimal6;
			}
			set
			{
				this.boqItemCustomDecimal6 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal7
		{
			get
			{
				return boqItemCustomDecimal7;
			}
			set
			{
				this.boqItemCustomDecimal7 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal8
		{
			get
			{
				return boqItemCustomDecimal8;
			}
			set
			{
				this.boqItemCustomDecimal8 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal9
		{
			get
			{
				return boqItemCustomDecimal9;
			}
			set
			{
				this.boqItemCustomDecimal9 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal10
		{
			get
			{
				return boqItemCustomDecimal10;
			}
			set
			{
				this.boqItemCustomDecimal10 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal1
		{
			get
			{
				return boqItemCustomCumDecimal1;
			}
			set
			{
				this.boqItemCustomCumDecimal1 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal2
		{
			get
			{
				return boqItemCustomCumDecimal2;
			}
			set
			{
				this.boqItemCustomCumDecimal2 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal3
		{
			get
			{
				return boqItemCustomCumDecimal3;
			}
			set
			{
				this.boqItemCustomCumDecimal3 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal4
		{
			get
			{
				return boqItemCustomCumDecimal4;
			}
			set
			{
				this.boqItemCustomCumDecimal4 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal5
		{
			get
			{
				return boqItemCustomCumDecimal5;
			}
			set
			{
				this.boqItemCustomCumDecimal5 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange1
		{
			get
			{
				return boqItemCustomPercentange1;
			}
			set
			{
				this.boqItemCustomPercentange1 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange2
		{
			get
			{
				return boqItemCustomPercentange2;
			}
			set
			{
				this.boqItemCustomPercentange2 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange3
		{
			get
			{
				return boqItemCustomPercentange3;
			}
			set
			{
				this.boqItemCustomPercentange3 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange4
		{
			get
			{
				return boqItemCustomPercentange4;
			}
			set
			{
				this.boqItemCustomPercentange4 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange5
		{
			get
			{
				return boqItemCustomPercentange5;
			}
			set
			{
				this.boqItemCustomPercentange5 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange6
		{
			get
			{
				return boqItemCustomPercentange6;
			}
			set
			{
				this.boqItemCustomPercentange6 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange7
		{
			get
			{
				return boqItemCustomPercentange7;
			}
			set
			{
				this.boqItemCustomPercentange7 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange8
		{
			get
			{
				return boqItemCustomPercentange8;
			}
			set
			{
				this.boqItemCustomPercentange8 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange9
		{
			get
			{
				return boqItemCustomPercentange9;
			}
			set
			{
				this.boqItemCustomPercentange9 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange10
		{
			get
			{
				return boqItemCustomPercentange10;
			}
			set
			{
				this.boqItemCustomPercentange10 = value;
			}
		}
		public virtual string BoqItemPublishedItemCode
		{
			get
			{
				return boqItemPublishedItemCode;
			}
			set
			{
				this.boqItemPublishedItemCode = value;
			}
		}
		public virtual string BoqItemPublishedRevisionCode
		{
			get
			{
				return boqItemPublishedRevisionCode;
			}
			set
			{
				this.boqItemPublishedRevisionCode = value;
			}
		}

		public virtual string BoqItemWbsCode1
		{
			get
			{
				return boqItemWbsCode1;
			}
			set
			{
				this.boqItemWbsCode1 = value;
			}
		}
		public virtual string BoqItemWbsCode2
		{
			get
			{
				return boqItemWbsCode2;
			}
			set
			{
				this.boqItemWbsCode2 = value;
			}
		}
		public virtual string BoqItemLocation
		{
			get
			{
				return boqItemLocation;
			}
			set
			{
				this.boqItemLocation = value;
			}
		}
		public virtual string BoqItemGroupCode1
		{
			get
			{
				return boqItemGroupCode1;
			}
			set
			{
				this.boqItemGroupCode1 = value;
			}
		}
		public virtual string BoqItemGroupCode2
		{
			get
			{
				return boqItemGroupCode2;
			}
			set
			{
				this.boqItemGroupCode2 = value;
			}
		}
		public virtual string BoqItemGroupCode3
		{
			get
			{
				return boqItemGroupCode3;
			}
			set
			{
				this.boqItemGroupCode3 = value;
			}
		}
		public virtual string BoqItemGroupCode4
		{
			get
			{
				return boqItemGroupCode4;
			}
			set
			{
				this.boqItemGroupCode4 = value;
			}
		}
		public virtual string BoqItemGroupCode5
		{
			get
			{
				return boqItemGroupCode5;
			}
			set
			{
				this.boqItemGroupCode5 = value;
			}
		}
		public virtual string BoqItemGroupCode6
		{
			get
			{
				return boqItemGroupCode6;
			}
			set
			{
				this.boqItemGroupCode6 = value;
			}
		}
		public virtual string BoqItemGroupCode7
		{
			get
			{
				return boqItemGroupCode7;
			}
			set
			{
				this.boqItemGroupCode7 = value;
			}
		}
		public virtual string BoqItemGroupCode8
		{
			get
			{
				return boqItemGroupCode8;
			}
			set
			{
				this.boqItemGroupCode8 = value;
			}
		}
		public virtual string BoqItemGroupCode9
		{
			get
			{
				return boqItemGroupCode9;
			}
			set
			{
				this.boqItemGroupCode9 = value;
			}
		}
		public virtual string BoqItemDescription
		{
			get
			{
				return boqItemDescription;
			}
			set
			{
				this.boqItemDescription = value;
			}
		}
		public virtual string BoqItemNotes
		{
			get
			{
				return boqItemNotes;
			}
			set
			{
				this.boqItemNotes = value;
			}
		}
		public virtual string BoqItemWbsCode1Level1Code
		{
			get
			{
				return boqItemWbsCode1Level1Code;
			}
			set
			{
				this.boqItemWbsCode1Level1Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level2Code
		{
			get
			{
				return boqItemWbsCode1Level2Code;
			}
			set
			{
				this.boqItemWbsCode1Level2Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level3Code
		{
			get
			{
				return boqItemWbsCode1Level3Code;
			}
			set
			{
				this.boqItemWbsCode1Level3Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level4Code
		{
			get
			{
				return boqItemWbsCode1Level4Code;
			}
			set
			{
				this.boqItemWbsCode1Level4Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5
		{
			get
			{
				return boqItemWbsCode1Level5Code;
			}
			set
			{
				this.boqItemWbsCode1Level5Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level1Code
		{
			get
			{
				return boqItemWbsCode2Level1Code;
			}
			set
			{
				this.boqItemWbsCode2Level1Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level2Code
		{
			get
			{
				return boqItemWbsCode2Level2Code;
			}
			set
			{
				this.boqItemWbsCode2Level2Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level3Code
		{
			get
			{
				return boqItemWbsCode2Level3Code;
			}
			set
			{
				this.boqItemWbsCode2Level3Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level4Code
		{
			get
			{
				return boqItemWbsCode2Level4Code;
			}
			set
			{
				this.boqItemWbsCode2Level4Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5
		{
			get
			{
				return boqItemWbsCode2Level5Code;
			}
			set
			{
				this.boqItemWbsCode2Level5Code = value;
			}
		}
		public virtual string BoqItemLocationLevel1Code
		{
			get
			{
				return boqItemLocationLevel1Code;
			}
			set
			{
				this.boqItemLocationLevel1Code = value;
			}
		}
		public virtual string BoqItemLocationLevel2Code
		{
			get
			{
				return boqItemLocationLevel2Code;
			}
			set
			{
				this.boqItemLocationLevel2Code = value;
			}
		}
		public virtual string BoqItemLocationLevel3Code
		{
			get
			{
				return boqItemLocationLevel3Code;
			}
			set
			{
				this.boqItemLocationLevel3Code = value;
			}
		}
		public virtual string BoqItemLocationLevel4Code
		{
			get
			{
				return boqItemLocationLevel4Code;
			}
			set
			{
				this.boqItemLocationLevel4Code = value;
			}
		}
		public virtual string BoqItemLocationLevel5
		{
			get
			{
				return boqItemLocationLevel5Code;
			}
			set
			{
				this.boqItemLocationLevel5Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level1Code
		{
			get
			{
				return boqItemGroupCode1Level1Code;
			}
			set
			{
				this.boqItemGroupCode1Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level2Code
		{
			get
			{
				return boqItemGroupCode1Level2Code;
			}
			set
			{
				this.boqItemGroupCode1Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level3Code
		{
			get
			{
				return boqItemGroupCode1Level3Code;
			}
			set
			{
				this.boqItemGroupCode1Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level4Code
		{
			get
			{
				return boqItemGroupCode1Level4Code;
			}
			set
			{
				this.boqItemGroupCode1Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level5
		{
			get
			{
				return boqItemGroupCode1Level5Code;
			}
			set
			{
				this.boqItemGroupCode1Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level1Code
		{
			get
			{
				return boqItemGroupCode2Level1Code;
			}
			set
			{
				this.boqItemGroupCode2Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level2Code
		{
			get
			{
				return boqItemGroupCode2Level2Code;
			}
			set
			{
				this.boqItemGroupCode2Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level3Code
		{
			get
			{
				return boqItemGroupCode2Level3Code;
			}
			set
			{
				this.boqItemGroupCode2Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level4Code
		{
			get
			{
				return boqItemGroupCode2Level4Code;
			}
			set
			{
				this.boqItemGroupCode2Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level5
		{
			get
			{
				return boqItemGroupCode2Level5Code;
			}
			set
			{
				this.boqItemGroupCode2Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level1Code
		{
			get
			{
				return boqItemGroupCode3Level1Code;
			}
			set
			{
				this.boqItemGroupCode3Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level2Code
		{
			get
			{
				return boqItemGroupCode3Level2Code;
			}
			set
			{
				this.boqItemGroupCode3Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level3Code
		{
			get
			{
				return boqItemGroupCode3Level3Code;
			}
			set
			{
				this.boqItemGroupCode3Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level4Code
		{
			get
			{
				return boqItemGroupCode3Level4Code;
			}
			set
			{
				this.boqItemGroupCode3Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level5
		{
			get
			{
				return boqItemGroupCode3Level5Code;
			}
			set
			{
				this.boqItemGroupCode3Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level1Code
		{
			get
			{
				return boqItemGroupCode4Level1Code;
			}
			set
			{
				this.boqItemGroupCode4Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level2Code
		{
			get
			{
				return boqItemGroupCode4Level2Code;
			}
			set
			{
				this.boqItemGroupCode4Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level3Code
		{
			get
			{
				return boqItemGroupCode4Level3Code;
			}
			set
			{
				this.boqItemGroupCode4Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level4Code
		{
			get
			{
				return boqItemGroupCode4Level4Code;
			}
			set
			{
				this.boqItemGroupCode4Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level5
		{
			get
			{
				return boqItemGroupCode4Level5Code;
			}
			set
			{
				this.boqItemGroupCode4Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level1Code
		{
			get
			{
				return boqItemGroupCode5Level1Code;
			}
			set
			{
				this.boqItemGroupCode5Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level2Code
		{
			get
			{
				return boqItemGroupCode5Level2Code;
			}
			set
			{
				this.boqItemGroupCode5Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level3Code
		{
			get
			{
				return boqItemGroupCode5Level3Code;
			}
			set
			{
				this.boqItemGroupCode5Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level4Code
		{
			get
			{
				return boqItemGroupCode5Level4Code;
			}
			set
			{
				this.boqItemGroupCode5Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level5
		{
			get
			{
				return boqItemGroupCode5Level5Code;
			}
			set
			{
				this.boqItemGroupCode5Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level1Code
		{
			get
			{
				return boqItemGroupCode6Level1Code;
			}
			set
			{
				this.boqItemGroupCode6Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level2Code
		{
			get
			{
				return boqItemGroupCode6Level2Code;
			}
			set
			{
				this.boqItemGroupCode6Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level3Code
		{
			get
			{
				return boqItemGroupCode6Level3Code;
			}
			set
			{
				this.boqItemGroupCode6Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level4Code
		{
			get
			{
				return boqItemGroupCode6Level4Code;
			}
			set
			{
				this.boqItemGroupCode6Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level5
		{
			get
			{
				return boqItemGroupCode6Level5Code;
			}
			set
			{
				this.boqItemGroupCode6Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level1Code
		{
			get
			{
				return boqItemGroupCode7Level1Code;
			}
			set
			{
				this.boqItemGroupCode7Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level2Code
		{
			get
			{
				return boqItemGroupCode7Level2Code;
			}
			set
			{
				this.boqItemGroupCode7Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level3Code
		{
			get
			{
				return boqItemGroupCode7Level3Code;
			}
			set
			{
				this.boqItemGroupCode7Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level4Code
		{
			get
			{
				return boqItemGroupCode7Level4Code;
			}
			set
			{
				this.boqItemGroupCode7Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level5
		{
			get
			{
				return boqItemGroupCode7Level5Code;
			}
			set
			{
				this.boqItemGroupCode7Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level1Code
		{
			get
			{
				return boqItemGroupCode8Level1Code;
			}
			set
			{
				this.boqItemGroupCode8Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level2Code
		{
			get
			{
				return boqItemGroupCode8Level2Code;
			}
			set
			{
				this.boqItemGroupCode8Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level3Code
		{
			get
			{
				return boqItemGroupCode8Level3Code;
			}
			set
			{
				this.boqItemGroupCode8Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level4Code
		{
			get
			{
				return boqItemGroupCode8Level4Code;
			}
			set
			{
				this.boqItemGroupCode8Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level5
		{
			get
			{
				return boqItemGroupCode8Level5Code;
			}
			set
			{
				this.boqItemGroupCode8Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level1Code
		{
			get
			{
				return boqItemGroupCode9Level1Code;
			}
			set
			{
				this.boqItemGroupCode9Level1Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level2Code
		{
			get
			{
				return boqItemGroupCode9Level2Code;
			}
			set
			{
				this.boqItemGroupCode9Level2Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level3Code
		{
			get
			{
				return boqItemGroupCode9Level3Code;
			}
			set
			{
				this.boqItemGroupCode9Level3Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level4Code
		{
			get
			{
				return boqItemGroupCode9Level4Code;
			}
			set
			{
				this.boqItemGroupCode9Level4Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level5
		{
			get
			{
				return boqItemGroupCode9Level5Code;
			}
			set
			{
				this.boqItemGroupCode9Level5Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5Code
		{
			get
			{
				return boqItemWbsCode1Level5Code;
			}
			set
			{
				this.boqItemWbsCode1Level5Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level1Title
		{
			get
			{
				return boqItemWbsCode1Level1Title;
			}
			set
			{
				this.boqItemWbsCode1Level1Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level2Title
		{
			get
			{
				return boqItemWbsCode1Level2Title;
			}
			set
			{
				this.boqItemWbsCode1Level2Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level3Title
		{
			get
			{
				return boqItemWbsCode1Level3Title;
			}
			set
			{
				this.boqItemWbsCode1Level3Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level4Title
		{
			get
			{
				return boqItemWbsCode1Level4Title;
			}
			set
			{
				this.boqItemWbsCode1Level4Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5Title
		{
			get
			{
				return boqItemWbsCode1Level5Title;
			}
			set
			{
				this.boqItemWbsCode1Level5Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5Code
		{
			get
			{
				return boqItemWbsCode2Level5Code;
			}
			set
			{
				this.boqItemWbsCode2Level5Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level1Title
		{
			get
			{
				return boqItemWbsCode2Level1Title;
			}
			set
			{
				this.boqItemWbsCode2Level1Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level2Title
		{
			get
			{
				return boqItemWbsCode2Level2Title;
			}
			set
			{
				this.boqItemWbsCode2Level2Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level3Title
		{
			get
			{
				return boqItemWbsCode2Level3Title;
			}
			set
			{
				this.boqItemWbsCode2Level3Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level4Title
		{
			get
			{
				return boqItemWbsCode2Level4Title;
			}
			set
			{
				this.boqItemWbsCode2Level4Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5Title
		{
			get
			{
				return boqItemWbsCode2Level5Title;
			}
			set
			{
				this.boqItemWbsCode2Level5Title = value;
			}
		}
		public virtual string BoqItemLocationLevel5Code
		{
			get
			{
				return boqItemLocationLevel5Code;
			}
			set
			{
				this.boqItemLocationLevel5Code = value;
			}
		}
		public virtual string BoqItemLocationLevel1Title
		{
			get
			{
				return boqItemLocationLevel1Title;
			}
			set
			{
				this.boqItemLocationLevel1Title = value;
			}
		}
		public virtual string BoqItemLocationLevel2Title
		{
			get
			{
				return boqItemLocationLevel2Title;
			}
			set
			{
				this.boqItemLocationLevel2Title = value;
			}
		}
		public virtual string BoqItemLocationLevel3Title
		{
			get
			{
				return boqItemLocationLevel3Title;
			}
			set
			{
				this.boqItemLocationLevel3Title = value;
			}
		}
		public virtual string BoqItemLocationLevel4Title
		{
			get
			{
				return boqItemLocationLevel4Title;
			}
			set
			{
				this.boqItemLocationLevel4Title = value;
			}
		}
		public virtual string BoqItemLocationLevel5Title
		{
			get
			{
				return boqItemLocationLevel5Title;
			}
			set
			{
				this.boqItemLocationLevel5Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level5Code
		{
			get
			{
				return boqItemGroupCode1Level5Code;
			}
			set
			{
				this.boqItemGroupCode1Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level1Title
		{
			get
			{
				return boqItemGroupCode1Level1Title;
			}
			set
			{
				this.boqItemGroupCode1Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level2Title
		{
			get
			{
				return boqItemGroupCode1Level2Title;
			}
			set
			{
				this.boqItemGroupCode1Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level3Title
		{
			get
			{
				return boqItemGroupCode1Level3Title;
			}
			set
			{
				this.boqItemGroupCode1Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level4Title
		{
			get
			{
				return boqItemGroupCode1Level4Title;
			}
			set
			{
				this.boqItemGroupCode1Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level5Title
		{
			get
			{
				return boqItemGroupCode1Level5Title;
			}
			set
			{
				this.boqItemGroupCode1Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level1Description
		{
			get
			{
				return boqItemGroupCode1Level1Description;
			}
			set
			{
				this.boqItemGroupCode1Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level2Description
		{
			get
			{
				return boqItemGroupCode1Level2Description;
			}
			set
			{
				this.boqItemGroupCode1Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level3Description
		{
			get
			{
				return boqItemGroupCode1Level3Description;
			}
			set
			{
				this.boqItemGroupCode1Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level4Description
		{
			get
			{
				return boqItemGroupCode1Level4Description;
			}
			set
			{
				this.boqItemGroupCode1Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level5Description
		{
			get
			{
				return boqItemGroupCode1Level5Description;
			}
			set
			{
				this.boqItemGroupCode1Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level1Unit
		{
			get
			{
				return boqItemGroupCode1Level1Unit;
			}
			set
			{
				this.boqItemGroupCode1Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level2Unit
		{
			get
			{
				return boqItemGroupCode1Level2Unit;
			}
			set
			{
				this.boqItemGroupCode1Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level3Unit
		{
			get
			{
				return boqItemGroupCode1Level3Unit;
			}
			set
			{
				this.boqItemGroupCode1Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level4Unit
		{
			get
			{
				return boqItemGroupCode1Level4Unit;
			}
			set
			{
				this.boqItemGroupCode1Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level5Unit
		{
			get
			{
				return boqItemGroupCode1Level5Unit;
			}
			set
			{
				this.boqItemGroupCode1Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level5Code
		{
			get
			{
				return boqItemGroupCode2Level5Code;
			}
			set
			{
				this.boqItemGroupCode2Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level1Title
		{
			get
			{
				return boqItemGroupCode2Level1Title;
			}
			set
			{
				this.boqItemGroupCode2Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level2Title
		{
			get
			{
				return boqItemGroupCode2Level2Title;
			}
			set
			{
				this.boqItemGroupCode2Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level3Title
		{
			get
			{
				return boqItemGroupCode2Level3Title;
			}
			set
			{
				this.boqItemGroupCode2Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level4Title
		{
			get
			{
				return boqItemGroupCode2Level4Title;
			}
			set
			{
				this.boqItemGroupCode2Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level5Title
		{
			get
			{
				return boqItemGroupCode2Level5Title;
			}
			set
			{
				this.boqItemGroupCode2Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level1Description
		{
			get
			{
				return boqItemGroupCode2Level1Description;
			}
			set
			{
				this.boqItemGroupCode2Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level2Description
		{
			get
			{
				return boqItemGroupCode2Level2Description;
			}
			set
			{
				this.boqItemGroupCode2Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level3Description
		{
			get
			{
				return boqItemGroupCode2Level3Description;
			}
			set
			{
				this.boqItemGroupCode2Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level4Description
		{
			get
			{
				return boqItemGroupCode2Level4Description;
			}
			set
			{
				this.boqItemGroupCode2Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level5Description
		{
			get
			{
				return boqItemGroupCode2Level5Description;
			}
			set
			{
				this.boqItemGroupCode2Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level1Unit
		{
			get
			{
				return boqItemGroupCode2Level1Unit;
			}
			set
			{
				this.boqItemGroupCode2Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level2Unit
		{
			get
			{
				return boqItemGroupCode2Level2Unit;
			}
			set
			{
				this.boqItemGroupCode2Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level3Unit
		{
			get
			{
				return boqItemGroupCode2Level3Unit;
			}
			set
			{
				this.boqItemGroupCode2Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level4Unit
		{
			get
			{
				return boqItemGroupCode2Level4Unit;
			}
			set
			{
				this.boqItemGroupCode2Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level5Unit
		{
			get
			{
				return boqItemGroupCode2Level5Unit;
			}
			set
			{
				this.boqItemGroupCode2Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level5Code
		{
			get
			{
				return boqItemGroupCode3Level5Code;
			}
			set
			{
				this.boqItemGroupCode3Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level1Title
		{
			get
			{
				return boqItemGroupCode3Level1Title;
			}
			set
			{
				this.boqItemGroupCode3Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level2Title
		{
			get
			{
				return boqItemGroupCode3Level2Title;
			}
			set
			{
				this.boqItemGroupCode3Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level3Title
		{
			get
			{
				return boqItemGroupCode3Level3Title;
			}
			set
			{
				this.boqItemGroupCode3Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level4Title
		{
			get
			{
				return boqItemGroupCode3Level4Title;
			}
			set
			{
				this.boqItemGroupCode3Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level5Title
		{
			get
			{
				return boqItemGroupCode3Level5Title;
			}
			set
			{
				this.boqItemGroupCode3Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level1Description
		{
			get
			{
				return boqItemGroupCode3Level1Description;
			}
			set
			{
				this.boqItemGroupCode3Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level2Description
		{
			get
			{
				return boqItemGroupCode3Level2Description;
			}
			set
			{
				this.boqItemGroupCode3Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level3Description
		{
			get
			{
				return boqItemGroupCode3Level3Description;
			}
			set
			{
				this.boqItemGroupCode3Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level4Description
		{
			get
			{
				return boqItemGroupCode3Level4Description;
			}
			set
			{
				this.boqItemGroupCode3Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level5Description
		{
			get
			{
				return boqItemGroupCode3Level5Description;
			}
			set
			{
				this.boqItemGroupCode3Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level1Unit
		{
			get
			{
				return boqItemGroupCode3Level1Unit;
			}
			set
			{
				this.boqItemGroupCode3Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level2Unit
		{
			get
			{
				return boqItemGroupCode3Level2Unit;
			}
			set
			{
				this.boqItemGroupCode3Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level3Unit
		{
			get
			{
				return boqItemGroupCode3Level3Unit;
			}
			set
			{
				this.boqItemGroupCode3Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level4Unit
		{
			get
			{
				return boqItemGroupCode3Level4Unit;
			}
			set
			{
				this.boqItemGroupCode3Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level5Unit
		{
			get
			{
				return boqItemGroupCode3Level5Unit;
			}
			set
			{
				this.boqItemGroupCode3Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level5Code
		{
			get
			{
				return boqItemGroupCode4Level5Code;
			}
			set
			{
				this.boqItemGroupCode4Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level1Title
		{
			get
			{
				return boqItemGroupCode4Level1Title;
			}
			set
			{
				this.boqItemGroupCode4Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level2Title
		{
			get
			{
				return boqItemGroupCode4Level2Title;
			}
			set
			{
				this.boqItemGroupCode4Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level3Title
		{
			get
			{
				return boqItemGroupCode4Level3Title;
			}
			set
			{
				this.boqItemGroupCode4Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level4Title
		{
			get
			{
				return boqItemGroupCode4Level4Title;
			}
			set
			{
				this.boqItemGroupCode4Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level5Title
		{
			get
			{
				return boqItemGroupCode4Level5Title;
			}
			set
			{
				this.boqItemGroupCode4Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level1Description
		{
			get
			{
				return boqItemGroupCode4Level1Description;
			}
			set
			{
				this.boqItemGroupCode4Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level2Description
		{
			get
			{
				return boqItemGroupCode4Level2Description;
			}
			set
			{
				this.boqItemGroupCode4Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level3Description
		{
			get
			{
				return boqItemGroupCode4Level3Description;
			}
			set
			{
				this.boqItemGroupCode4Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level4Description
		{
			get
			{
				return boqItemGroupCode4Level4Description;
			}
			set
			{
				this.boqItemGroupCode4Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level5Description
		{
			get
			{
				return boqItemGroupCode4Level5Description;
			}
			set
			{
				this.boqItemGroupCode4Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level1Unit
		{
			get
			{
				return boqItemGroupCode4Level1Unit;
			}
			set
			{
				this.boqItemGroupCode4Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level2Unit
		{
			get
			{
				return boqItemGroupCode4Level2Unit;
			}
			set
			{
				this.boqItemGroupCode4Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level3Unit
		{
			get
			{
				return boqItemGroupCode4Level3Unit;
			}
			set
			{
				this.boqItemGroupCode4Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level4Unit
		{
			get
			{
				return boqItemGroupCode4Level4Unit;
			}
			set
			{
				this.boqItemGroupCode4Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level5Unit
		{
			get
			{
				return boqItemGroupCode4Level5Unit;
			}
			set
			{
				this.boqItemGroupCode4Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level5Code
		{
			get
			{
				return boqItemGroupCode5Level5Code;
			}
			set
			{
				this.boqItemGroupCode5Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level1Title
		{
			get
			{
				return boqItemGroupCode5Level1Title;
			}
			set
			{
				this.boqItemGroupCode5Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level2Title
		{
			get
			{
				return boqItemGroupCode5Level2Title;
			}
			set
			{
				this.boqItemGroupCode5Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level3Title
		{
			get
			{
				return boqItemGroupCode5Level3Title;
			}
			set
			{
				this.boqItemGroupCode5Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level4Title
		{
			get
			{
				return boqItemGroupCode5Level4Title;
			}
			set
			{
				this.boqItemGroupCode5Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level5Title
		{
			get
			{
				return boqItemGroupCode5Level5Title;
			}
			set
			{
				this.boqItemGroupCode5Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level1Description
		{
			get
			{
				return boqItemGroupCode5Level1Description;
			}
			set
			{
				this.boqItemGroupCode5Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level2Description
		{
			get
			{
				return boqItemGroupCode5Level2Description;
			}
			set
			{
				this.boqItemGroupCode5Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level3Description
		{
			get
			{
				return boqItemGroupCode5Level3Description;
			}
			set
			{
				this.boqItemGroupCode5Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level4Description
		{
			get
			{
				return boqItemGroupCode5Level4Description;
			}
			set
			{
				this.boqItemGroupCode5Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level5Description
		{
			get
			{
				return boqItemGroupCode5Level5Description;
			}
			set
			{
				this.boqItemGroupCode5Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level1Unit
		{
			get
			{
				return boqItemGroupCode5Level1Unit;
			}
			set
			{
				this.boqItemGroupCode5Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level2Unit
		{
			get
			{
				return boqItemGroupCode5Level2Unit;
			}
			set
			{
				this.boqItemGroupCode5Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level3Unit
		{
			get
			{
				return boqItemGroupCode5Level3Unit;
			}
			set
			{
				this.boqItemGroupCode5Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level4Unit
		{
			get
			{
				return boqItemGroupCode5Level4Unit;
			}
			set
			{
				this.boqItemGroupCode5Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level5Unit
		{
			get
			{
				return boqItemGroupCode5Level5Unit;
			}
			set
			{
				this.boqItemGroupCode5Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level5Code
		{
			get
			{
				return boqItemGroupCode6Level5Code;
			}
			set
			{
				this.boqItemGroupCode6Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level1Title
		{
			get
			{
				return boqItemGroupCode6Level1Title;
			}
			set
			{
				this.boqItemGroupCode6Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level2Title
		{
			get
			{
				return boqItemGroupCode6Level2Title;
			}
			set
			{
				this.boqItemGroupCode6Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level3Title
		{
			get
			{
				return boqItemGroupCode6Level3Title;
			}
			set
			{
				this.boqItemGroupCode6Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level4Title
		{
			get
			{
				return boqItemGroupCode6Level4Title;
			}
			set
			{
				this.boqItemGroupCode6Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level5Title
		{
			get
			{
				return boqItemGroupCode6Level5Title;
			}
			set
			{
				this.boqItemGroupCode6Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level1Description
		{
			get
			{
				return boqItemGroupCode6Level1Description;
			}
			set
			{
				this.boqItemGroupCode6Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level2Description
		{
			get
			{
				return boqItemGroupCode6Level2Description;
			}
			set
			{
				this.boqItemGroupCode6Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level3Description
		{
			get
			{
				return boqItemGroupCode6Level3Description;
			}
			set
			{
				this.boqItemGroupCode6Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level4Description
		{
			get
			{
				return boqItemGroupCode6Level4Description;
			}
			set
			{
				this.boqItemGroupCode6Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level5Description
		{
			get
			{
				return boqItemGroupCode6Level5Description;
			}
			set
			{
				this.boqItemGroupCode6Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level1Unit
		{
			get
			{
				return boqItemGroupCode6Level1Unit;
			}
			set
			{
				this.boqItemGroupCode6Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level2Unit
		{
			get
			{
				return boqItemGroupCode6Level2Unit;
			}
			set
			{
				this.boqItemGroupCode6Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level3Unit
		{
			get
			{
				return boqItemGroupCode6Level3Unit;
			}
			set
			{
				this.boqItemGroupCode6Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level4Unit
		{
			get
			{
				return boqItemGroupCode6Level4Unit;
			}
			set
			{
				this.boqItemGroupCode6Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level5Unit
		{
			get
			{
				return boqItemGroupCode6Level5Unit;
			}
			set
			{
				this.boqItemGroupCode6Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level5Code
		{
			get
			{
				return boqItemGroupCode7Level5Code;
			}
			set
			{
				this.boqItemGroupCode7Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level1Title
		{
			get
			{
				return boqItemGroupCode7Level1Title;
			}
			set
			{
				this.boqItemGroupCode7Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level2Title
		{
			get
			{
				return boqItemGroupCode7Level2Title;
			}
			set
			{
				this.boqItemGroupCode7Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level3Title
		{
			get
			{
				return boqItemGroupCode7Level3Title;
			}
			set
			{
				this.boqItemGroupCode7Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level4Title
		{
			get
			{
				return boqItemGroupCode7Level4Title;
			}
			set
			{
				this.boqItemGroupCode7Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level5Title
		{
			get
			{
				return boqItemGroupCode7Level5Title;
			}
			set
			{
				this.boqItemGroupCode7Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level1Description
		{
			get
			{
				return boqItemGroupCode7Level1Description;
			}
			set
			{
				this.boqItemGroupCode7Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level2Description
		{
			get
			{
				return boqItemGroupCode7Level2Description;
			}
			set
			{
				this.boqItemGroupCode7Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level3Description
		{
			get
			{
				return boqItemGroupCode7Level3Description;
			}
			set
			{
				this.boqItemGroupCode7Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level4Description
		{
			get
			{
				return boqItemGroupCode7Level4Description;
			}
			set
			{
				this.boqItemGroupCode7Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level5Description
		{
			get
			{
				return boqItemGroupCode7Level5Description;
			}
			set
			{
				this.boqItemGroupCode7Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level1Unit
		{
			get
			{
				return boqItemGroupCode7Level1Unit;
			}
			set
			{
				this.boqItemGroupCode7Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level2Unit
		{
			get
			{
				return boqItemGroupCode7Level2Unit;
			}
			set
			{
				this.boqItemGroupCode7Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level3Unit
		{
			get
			{
				return boqItemGroupCode7Level3Unit;
			}
			set
			{
				this.boqItemGroupCode7Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level4Unit
		{
			get
			{
				return boqItemGroupCode7Level4Unit;
			}
			set
			{
				this.boqItemGroupCode7Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level5Unit
		{
			get
			{
				return boqItemGroupCode7Level5Unit;
			}
			set
			{
				this.boqItemGroupCode7Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level5Code
		{
			get
			{
				return boqItemGroupCode8Level5Code;
			}
			set
			{
				this.boqItemGroupCode8Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level1Title
		{
			get
			{
				return boqItemGroupCode8Level1Title;
			}
			set
			{
				this.boqItemGroupCode8Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level2Title
		{
			get
			{
				return boqItemGroupCode8Level2Title;
			}
			set
			{
				this.boqItemGroupCode8Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level3Title
		{
			get
			{
				return boqItemGroupCode8Level3Title;
			}
			set
			{
				this.boqItemGroupCode8Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level4Title
		{
			get
			{
				return boqItemGroupCode8Level4Title;
			}
			set
			{
				this.boqItemGroupCode8Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level5Title
		{
			get
			{
				return boqItemGroupCode8Level5Title;
			}
			set
			{
				this.boqItemGroupCode8Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level1Description
		{
			get
			{
				return boqItemGroupCode8Level1Description;
			}
			set
			{
				this.boqItemGroupCode8Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level2Description
		{
			get
			{
				return boqItemGroupCode8Level2Description;
			}
			set
			{
				this.boqItemGroupCode8Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level3Description
		{
			get
			{
				return boqItemGroupCode8Level3Description;
			}
			set
			{
				this.boqItemGroupCode8Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level4Description
		{
			get
			{
				return boqItemGroupCode8Level4Description;
			}
			set
			{
				this.boqItemGroupCode8Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level5Description
		{
			get
			{
				return boqItemGroupCode8Level5Description;
			}
			set
			{
				this.boqItemGroupCode8Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level1Unit
		{
			get
			{
				return boqItemGroupCode8Level1Unit;
			}
			set
			{
				this.boqItemGroupCode8Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level2Unit
		{
			get
			{
				return boqItemGroupCode8Level2Unit;
			}
			set
			{
				this.boqItemGroupCode8Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level3Unit
		{
			get
			{
				return boqItemGroupCode8Level3Unit;
			}
			set
			{
				this.boqItemGroupCode8Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level4Unit
		{
			get
			{
				return boqItemGroupCode8Level4Unit;
			}
			set
			{
				this.boqItemGroupCode8Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level5Unit
		{
			get
			{
				return boqItemGroupCode8Level5Unit;
			}
			set
			{
				this.boqItemGroupCode8Level5Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level5Code
		{
			get
			{
				return boqItemGroupCode9Level5Code;
			}
			set
			{
				this.boqItemGroupCode9Level5Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level1Title
		{
			get
			{
				return boqItemGroupCode9Level1Title;
			}
			set
			{
				this.boqItemGroupCode9Level1Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level2Title
		{
			get
			{
				return boqItemGroupCode9Level2Title;
			}
			set
			{
				this.boqItemGroupCode9Level2Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level3Title
		{
			get
			{
				return boqItemGroupCode9Level3Title;
			}
			set
			{
				this.boqItemGroupCode9Level3Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level4Title
		{
			get
			{
				return boqItemGroupCode9Level4Title;
			}
			set
			{
				this.boqItemGroupCode9Level4Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level5Title
		{
			get
			{
				return boqItemGroupCode9Level5Title;
			}
			set
			{
				this.boqItemGroupCode9Level5Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level1Description
		{
			get
			{
				return boqItemGroupCode9Level1Description;
			}
			set
			{
				this.boqItemGroupCode9Level1Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level2Description
		{
			get
			{
				return boqItemGroupCode9Level2Description;
			}
			set
			{
				this.boqItemGroupCode9Level2Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level3Description
		{
			get
			{
				return boqItemGroupCode9Level3Description;
			}
			set
			{
				this.boqItemGroupCode9Level3Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level4Description
		{
			get
			{
				return boqItemGroupCode9Level4Description;
			}
			set
			{
				this.boqItemGroupCode9Level4Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level5Description
		{
			get
			{
				return boqItemGroupCode9Level5Description;
			}
			set
			{
				this.boqItemGroupCode9Level5Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level1Unit
		{
			get
			{
				return boqItemGroupCode9Level1Unit;
			}
			set
			{
				this.boqItemGroupCode9Level1Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level2Unit
		{
			get
			{
				return boqItemGroupCode9Level2Unit;
			}
			set
			{
				this.boqItemGroupCode9Level2Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level3Unit
		{
			get
			{
				return boqItemGroupCode9Level3Unit;
			}
			set
			{
				this.boqItemGroupCode9Level3Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level4Unit
		{
			get
			{
				return boqItemGroupCode9Level4Unit;
			}
			set
			{
				this.boqItemGroupCode9Level4Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level5Unit
		{
			get
			{
				return boqItemGroupCode9Level5Unit;
			}
			set
			{
				this.boqItemGroupCode9Level5Unit = value;
			}
		}
		public virtual long? AssignmentId
		{
			get
			{
				return assignmentId;
			}
			set
			{
				this.assignmentId = value;
			}
		}
		public virtual decimal AssignmentFactor1
		{
			get
			{
				return assignmentFactor1;
			}
			set
			{
				this.assignmentFactor1 = value;
			}
		}
		public virtual decimal AssignmentFactor2
		{
			get
			{
				return assignmentFactor2;
			}
			set
			{
				this.assignmentFactor2 = value;
			}
		}
		public virtual decimal AssignmentWaste
		{
			get
			{
				return assignmentWaste;
			}
			set
			{
				this.assignmentWaste = value;
			}
		}
		public virtual decimal AssignmentSelectedQuantity
		{
			get
			{
				return assignmentSelectedQuantity;
			}
			set
			{
				this.assignmentSelectedQuantity = value;
			}
		}
		public virtual decimal AssignmentFinalQuantity
		{
			get
			{
				return assignmentFinalQuantity;
			}
			set
			{
				this.assignmentFinalQuantity = value;
			}
		}
		public virtual string AssignmentFinalUnit
		{
			get
			{
				return assignmentFinalUnit;
			}
			set
			{
				this.assignmentFinalUnit = value;
			}
		}
		public virtual string AssignmentQuantityName
		{
			get
			{
				return assignmentQuantityName;
			}
			set
			{
				this.assignmentQuantityName = value;
			}
		}
		public virtual decimal AssignmentTotalCost
		{
			get
			{
				return assignmentTotalCost;
			}
			set
			{
				this.assignmentTotalCost = value;
			}
		}
		public virtual decimal AssignmentLaborCost
		{
			get
			{
				return assignmentLaborCost;
			}
			set
			{
				this.assignmentLaborCost = value;
			}
		}
		public virtual decimal AssignmentMaterialCost
		{
			get
			{
				return assignmentMaterialCost;
			}
			set
			{
				this.assignmentMaterialCost = value;
			}
		}
		public virtual decimal AssignmentEquipmentCost
		{
			get
			{
				return assignmentEquipmentCost;
			}
			set
			{
				this.assignmentEquipmentCost = value;
			}
		}
		public virtual decimal AssignmentSubcontractorCost
		{
			get
			{
				return assignmentSubcontractorCost;
			}
			set
			{
				this.assignmentSubcontractorCost = value;
			}
		}
		public virtual decimal AssignmentLineItemCost
		{
			get
			{
				return assignmentLineItemCost;
			}
			set
			{
				this.assignmentLineItemCost = value;
			}
		}
		public virtual decimal AssignmentConsumableCost
		{
			get
			{
				return assignmentConsumableCost;
			}
			set
			{
				this.assignmentConsumableCost = value;
			}
		}
		public virtual long? TakeoffId
		{
			get
			{
				return takeoffId;
			}
			set
			{
				this.takeoffId = value;
			}
		}
		public virtual string TakeoffTitle
		{
			get
			{
				return takeoffTitle;
			}
			set
			{
				this.takeoffTitle = value;
			}
		}
		public virtual string TakeoffDescription
		{
			get
			{
				return takeoffDescription;
			}
			set
			{
				this.takeoffDescription = value;
			}
		}
		public virtual string TakeoffBimMaterial
		{
			get
			{
				return takeoffBimMaterial;
			}
			set
			{
				this.takeoffBimMaterial = value;
			}
		}
		public virtual string TakeoffBimType
		{
			get
			{
				return takeoffBimType;
			}
			set
			{
				this.takeoffBimType = value;
			}
		}
		public virtual string TakeoffGlobalId
		{
			get
			{
				return takeoffGlobalId;
			}
			set
			{
				this.takeoffGlobalId = value;
			}
		}
		public virtual string TakeoffGroup
		{
			get
			{
				return takeoffGroup;
			}
			set
			{
				this.takeoffGroup = value;
			}
		}
		public virtual string TakeoffBuilding
		{
			get
			{
				return takeoffBuilding;
			}
			set
			{
				this.takeoffBuilding = value;
			}
		}
		public virtual string TakeoffStorey
		{
			get
			{
				return takeoffStorey;
			}
			set
			{
				this.takeoffStorey = value;
			}
		}
		public virtual string TakeoffLocation
		{
			get
			{
				return takeoffLocation;
			}
			set
			{
				this.takeoffLocation = value;
			}
		}
		public virtual string TakeoffLayer
		{
			get
			{
				return takeoffLayer;
			}
			set
			{
				this.takeoffLayer = value;
			}
		}
		public virtual string TakeoffContainer
		{
			get
			{
				return takeoffContainer;
			}
			set
			{
				this.takeoffContainer = value;
			}
		}
		public virtual decimal TakeoffQuantity1
		{
			get
			{
				return takeoffQuantity1;
			}
			set
			{
				this.takeoffQuantity1 = value;
			}
		}
		public virtual decimal TakeoffQuantity2
		{
			get
			{
				return takeoffQuantity2;
			}
			set
			{
				this.takeoffQuantity2 = value;
			}
		}
		public virtual decimal TakeoffQuantity3
		{
			get
			{
				return takeoffQuantity3;
			}
			set
			{
				this.takeoffQuantity3 = value;
			}
		}
		public virtual string TakeoffQuantity1Name
		{
			get
			{
				return takeoffQuantity1Name;
			}
			set
			{
				this.takeoffQuantity1Name = value;
			}
		}
		public virtual string TakeoffQuantity2Name
		{
			get
			{
				return takeoffQuantity2Name;
			}
			set
			{
				this.takeoffQuantity2Name = value;
			}
		}
		public virtual string TakeoffQuantity3Name
		{
			get
			{
				return takeoffQuantity3Name;
			}
			set
			{
				this.takeoffQuantity3Name = value;
			}
		}
		public virtual string TakeoffUnit1
		{
			get
			{
				return takeoffUnit1;
			}
			set
			{
				this.takeoffUnit1 = value;
			}
		}
		public virtual string TakeoffUnit2
		{
			get
			{
				return takeoffUnit2;
			}
			set
			{
				this.takeoffUnit2 = value;
			}
		}
		public virtual string TakeoffUnit3
		{
			get
			{
				return takeoffUnit3;
			}
			set
			{
				this.takeoffUnit3 = value;
			}
		}
		public virtual string TakeoffType
		{
			get
			{
				return takeoffType;
			}
			set
			{
				this.takeoffType = value;
			}
		}
		public virtual sbyte? BoqItemEquipmentRateType
		{
			get
			{
				return boqItemEquipmentRateType;
			}
			set
			{
				this.boqItemEquipmentRateType = value;
			}
		}
		public virtual sbyte? BoqItemAssemblyRateType
		{
			get
			{
				return boqItemAssemblyRateType;
			}
			set
			{
				this.boqItemAssemblyRateType = value;
			}
		}
		public virtual sbyte? BoqItemSubcontractorRateType
		{
			get
			{
				return boqItemSubcontractorRateType;
			}
			set
			{
				this.boqItemSubcontractorRateType = value;
			}
		}
		public virtual sbyte? BoqItemLaborRateType
		{
			get
			{
				return boqItemLaborRateType;
			}
			set
			{
				this.boqItemLaborRateType = value;
			}
		}
		public virtual sbyte? BoqItemMaterialRateType
		{
			get
			{
				return boqItemMaterialRateType;
			}
			set
			{
				this.boqItemMaterialRateType = value;
			}
		}
		public virtual sbyte? BoqItemConsumableRateType
		{
			get
			{
				return boqItemConsumableRateType;
			}
			set
			{
				this.boqItemConsumableRateType = value;
			}
		}
		public virtual sbyte? BoqItemTakeoffQuantityType
		{
			get
			{
				return boqItemTakeoffQuantityType;
			}
			set
			{
				this.boqItemTakeoffQuantityType = value;
			}
		}
		public virtual string BoqItemWbsCode1Level1ItemCode
		{
			get
			{
				return boqItemWbsCode1Level1ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level1ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level2ItemCode
		{
			get
			{
				return boqItemWbsCode1Level2ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level2ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level3ItemCode
		{
			get
			{
				return boqItemWbsCode1Level3ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level3ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level4ItemCode
		{
			get
			{
				return boqItemWbsCode1Level4ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level4ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5ItemCode
		{
			get
			{
				return boqItemWbsCode1Level5ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level5ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level1ItemCode
		{
			get
			{
				return boqItemWbsCode2Level1ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level1ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level2ItemCode
		{
			get
			{
				return boqItemWbsCode2Level2ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level2ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level3ItemCode
		{
			get
			{
				return boqItemWbsCode2Level3ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level3ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level4ItemCode
		{
			get
			{
				return boqItemWbsCode2Level4ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level4ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5ItemCode
		{
			get
			{
				return boqItemWbsCode2Level5ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level5ItemCode = value;
			}
		}
	}

}