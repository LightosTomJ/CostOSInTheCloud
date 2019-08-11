using System;

namespace Models.view
{

	[Serializable]
	public class BoqItemWithExpandedResourcesTakeoffsView
	{

		private long? takeoffId;
		private string takeoffGlobalId;
		private string takeoffTitle;
		private string takeoffDescription;
		private string takeoffBimMaterial;
		private string takeoffBimType;
		private long? takeoffAssignmentId;
		private string takeoffGroup;
		private string takeoffType;
		private string takeoffBuilding;
		private string takeoffStorey;
		private string takeoffLocation;
		private string takeoffLayer;
		private string takeoffContainer;
		private decimal takeoffQuantity;
		private string takeoffUnit;
		private string takeoffQuantityName;
		private decimal takeoffCost;

		private long? lineItemId;
		private string lineItemTitle;
		private string lineItemDescription;
		private decimal lineItemProductivity;
		private decimal lineItemActBased;
		private string lineItemUnit;
		private string lineItemProject;
		private string lineItemCurrency;
		private decimal lineItemTotalRate;
		private decimal lineItemMaterialRate;
		private decimal lineItemLaborRate;
		private decimal lineItemSubcontractorRate;
		private decimal lineItemEquipmentRate;
		private decimal lineItemConsumablesRate;
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
		private long? id;
		private long? boqitemId;
		private long? boqItemCode;
		private string boqItemAssemblyId;
		private string boqItemAssemblyTitle;
		private string boqItemTitle;
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
		private decimal boqItemUnitManHours;
		private decimal boqItemUnitManHoursFactor;
		private decimal boqItemEquipmentHours;
		private bool? boqItemActivityBased;
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
		private string boqItemCustomText21;
		private string boqItemCustomText22;
		private string boqItemCustomText23;
		private string boqItemCustomText24;
		private string boqItemCustomText25;

		private DateTime boqItemCustomDate1;
		private DateTime boqItemCustomDate2;
		private DateTime boqItemCustomDate3;
		private DateTime boqItemCustomDate4;
		private DateTime boqItemCustomDate5;

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
		private decimal boqItemCustomDecimal11;
		private decimal boqItemCustomDecimal12;
		private decimal boqItemCustomDecimal13;
		private decimal boqItemCustomDecimal14;
		private decimal boqItemCustomDecimal15;
		private decimal boqItemCustomDecimal16;
		private decimal boqItemCustomDecimal17;
		private decimal boqItemCustomDecimal18;
		private decimal boqItemCustomDecimal19;
		private decimal boqItemCustomDecimal20;

		private decimal boqItemCustomCumDecimal1;
		private decimal boqItemCustomCumDecimal2;
		private decimal boqItemCustomCumDecimal3;
		private decimal boqItemCustomCumDecimal4;
		private decimal boqItemCustomCumDecimal5;
		private decimal boqItemCustomCumDecimal6;
		private decimal boqItemCustomCumDecimal7;
		private decimal boqItemCustomCumDecimal8;
		private decimal boqItemCustomCumDecimal9;
		private decimal boqItemCustomCumDecimal10;
		private decimal boqItemCustomCumDecimal11;
		private decimal boqItemCustomCumDecimal12;
		private decimal boqItemCustomCumDecimal13;
		private decimal boqItemCustomCumDecimal14;
		private decimal boqItemCustomCumDecimal15;
		private decimal boqItemCustomCumDecimal16;
		private decimal boqItemCustomCumDecimal17;
		private decimal boqItemCustomCumDecimal18;
		private decimal boqItemCustomCumDecimal19;
		private decimal boqItemCustomCumDecimal20;

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
		private decimal boqItemCustomPercentange11;
		private decimal boqItemCustomPercentange12;
		private decimal boqItemCustomPercentange13;
		private decimal boqItemCustomPercentange14;
		private decimal boqItemCustomPercentange15;
		private decimal boqItemCustomPercentange16;
		private decimal boqItemCustomPercentange17;
		private decimal boqItemCustomPercentange18;
		private decimal boqItemCustomPercentange19;
		private decimal boqItemCustomPercentange20;

		private string boqItemPublishedItemCode;
		private string boqItemPublishedRevisionCode;
		private bool? boqItemScheduled;
		private decimal boqItemGroupCode1UnitFactor;
		private decimal boqItemGroupCode2UnitFactor;
		private decimal boqItemGroupCode3UnitFactor;
		private decimal boqItemGroupCode4UnitFactor;
		private decimal boqItemGroupCode5UnitFactor;
		private decimal boqItemGroupCode6UnitFactor;
		private decimal boqItemGroupCode7UnitFactor;
		private decimal boqItemGroupCode8UnitFactor;
		private decimal boqItemGroupCode9UnitFactor;
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
		private string assignmentType;
		private long? assignmentId;
		private decimal assignmentFactor1;
		private decimal assignmentFactor2;
		private decimal assignmentFactor3;
		private decimal assignmentLocalFactor;
		private decimal assignmentQuantityPerUnit;
		private string assignmentLocalCountry;
		private string assignmentLocalStateProvince;
		private decimal assignmentExchangeRate;
		private decimal assignmentTotalUnits;
		private decimal assignmentFinalRate;
		private decimal assignmentTotalCost;
		private long? resourceId;
		private string resourceTitle;
		private string resourceDescription;
		private string resourceNotes;
		private decimal resourceRate;
		private string resourceCompany;
		private string resourceUnit;
		private string resourceCurrency;
		private string resourceCountry;
		private string resourceEditorId;
		private string resourceCreateUserId;
		private DateTime resourceCreateDate;
		private DateTime resourceLastUpdate;
		private string resourceGroupCode1;
		private string resourceGroupCode1Level1Code;
		private string resourceGroupCode1Level2Code;
		private string resourceGroupCode1Level3Code;
		private string resourceGroupCode1Level4Code;
		private string resourceGroupCode1Level5Code;
		private string resourceGroupCode1Level1Title;
		private string resourceGroupCode1Level2Title;
		private string resourceGroupCode1Level3Title;
		private string resourceGroupCode1Level4Title;
		private string resourceGroupCode1Level5Title;
		private string resourceGroupCode1Level1Description;
		private string resourceGroupCode1Level2Description;
		private string resourceGroupCode1Level3Description;
		private string resourceGroupCode1Level4Description;
		private string resourceGroupCode1Level5Description;
		private string resourceGroupCode1Level1Unit;
		private string resourceGroupCode1Level2Unit;
		private string resourceGroupCode1Level3Unit;
		private string resourceGroupCode1Level4Unit;
		private string resourceGroupCode1Level5Unit;
		private string resourceGroupCode2;
		private string resourceGroupCode2Level1Code;
		private string resourceGroupCode2Level2Code;
		private string resourceGroupCode2Level3Code;
		private string resourceGroupCode2Level4Code;
		private string resourceGroupCode2Level5Code;
		private string resourceGroupCode2Level1Title;
		private string resourceGroupCode2Level2Title;
		private string resourceGroupCode2Level3Title;
		private string resourceGroupCode2Level4Title;
		private string resourceGroupCode2Level5Title;
		private string resourceGroupCode2Level1Description;
		private string resourceGroupCode2Level2Description;
		private string resourceGroupCode2Level3Description;
		private string resourceGroupCode2Level4Description;
		private string resourceGroupCode2Level5Description;
		private string resourceGroupCode2Level1Unit;
		private string resourceGroupCode2Level2Unit;
		private string resourceGroupCode2Level3Unit;
		private string resourceGroupCode2Level4Unit;
		private string resourceGroupCode2Level5Unit;
		private string resourceGroupCode3;
		private string resourceGroupCode3Level1Code;
		private string resourceGroupCode3Level2Code;
		private string resourceGroupCode3Level3Code;
		private string resourceGroupCode3Level4Code;
		private string resourceGroupCode3Level5Code;
		private string resourceGroupCode3Level1Title;
		private string resourceGroupCode3Level2Title;
		private string resourceGroupCode3Level3Title;
		private string resourceGroupCode3Level4Title;
		private string resourceGroupCode3Level5Title;
		private string resourceGroupCode3Level1Description;
		private string resourceGroupCode3Level2Description;
		private string resourceGroupCode3Level3Description;
		private string resourceGroupCode3Level4Description;
		private string resourceGroupCode3Level5Description;
		private string resourceGroupCode3Level1Unit;
		private string resourceGroupCode3Level2Unit;
		private string resourceGroupCode3Level3Unit;
		private string resourceGroupCode3Level4Unit;
		private string resourceGroupCode3Level5Unit;
		private string resourceGroupCode4;
		private string resourceGroupCode4Level1Code;
		private string resourceGroupCode4Level2Code;
		private string resourceGroupCode4Level3Code;
		private string resourceGroupCode4Level4Code;
		private string resourceGroupCode4Level5Code;
		private string resourceGroupCode4Level1Title;
		private string resourceGroupCode4Level2Title;
		private string resourceGroupCode4Level3Title;
		private string resourceGroupCode4Level4Title;
		private string resourceGroupCode4Level5Title;
		private string resourceGroupCode4Level1Description;
		private string resourceGroupCode4Level2Description;
		private string resourceGroupCode4Level3Description;
		private string resourceGroupCode4Level4Description;
		private string resourceGroupCode4Level5Description;
		private string resourceGroupCode4Level1Unit;
		private string resourceGroupCode4Level2Unit;
		private string resourceGroupCode4Level3Unit;
		private string resourceGroupCode4Level4Unit;
		private string resourceGroupCode4Level5Unit;
		private string resourceGroupCode5;
		private string resourceGroupCode5Level1Code;
		private string resourceGroupCode5Level2Code;
		private string resourceGroupCode5Level3Code;
		private string resourceGroupCode5Level4Code;
		private string resourceGroupCode5Level5Code;
		private string resourceGroupCode5Level1Title;
		private string resourceGroupCode5Level2Title;
		private string resourceGroupCode5Level3Title;
		private string resourceGroupCode5Level4Title;
		private string resourceGroupCode5Level5Title;
		private string resourceGroupCode5Level1Description;
		private string resourceGroupCode5Level2Description;
		private string resourceGroupCode5Level3Description;
		private string resourceGroupCode5Level4Description;
		private string resourceGroupCode5Level5Description;
		private string resourceGroupCode5Level1Unit;
		private string resourceGroupCode5Level2Unit;
		private string resourceGroupCode5Level3Unit;
		private string resourceGroupCode5Level4Unit;
		private string resourceGroupCode5Level5Unit;
		private string resourceGroupCode6;
		private string resourceGroupCode6Level1Code;
		private string resourceGroupCode6Level2Code;
		private string resourceGroupCode6Level3Code;
		private string resourceGroupCode6Level4Code;
		private string resourceGroupCode6Level5Code;
		private string resourceGroupCode6Level1Title;
		private string resourceGroupCode6Level2Title;
		private string resourceGroupCode6Level3Title;
		private string resourceGroupCode6Level4Title;
		private string resourceGroupCode6Level5Title;
		private string resourceGroupCode6Level1Description;
		private string resourceGroupCode6Level2Description;
		private string resourceGroupCode6Level3Description;
		private string resourceGroupCode6Level4Description;
		private string resourceGroupCode6Level5Description;
		private string resourceGroupCode6Level1Unit;
		private string resourceGroupCode6Level2Unit;
		private string resourceGroupCode6Level3Unit;
		private string resourceGroupCode6Level4Unit;
		private string resourceGroupCode6Level5Unit;
		private string resourceGroupCode7;
		private string resourceGroupCode7Level1Code;
		private string resourceGroupCode7Level2Code;
		private string resourceGroupCode7Level3Code;
		private string resourceGroupCode7Level4Code;
		private string resourceGroupCode7Level5Code;
		private string resourceGroupCode7Level1Title;
		private string resourceGroupCode7Level2Title;
		private string resourceGroupCode7Level3Title;
		private string resourceGroupCode7Level4Title;
		private string resourceGroupCode7Level5Title;
		private string resourceGroupCode7Level1Description;
		private string resourceGroupCode7Level2Description;
		private string resourceGroupCode7Level3Description;
		private string resourceGroupCode7Level4Description;
		private string resourceGroupCode7Level5Description;
		private string resourceGroupCode7Level1Unit;
		private string resourceGroupCode7Level2Unit;
		private string resourceGroupCode7Level3Unit;
		private string resourceGroupCode7Level4Unit;
		private string resourceGroupCode7Level5Unit;
		private string resourceGroupCode8;
		private string resourceGroupCode8Level1Code;
		private string resourceGroupCode8Level2Code;
		private string resourceGroupCode8Level3Code;
		private string resourceGroupCode8Level4Code;
		private string resourceGroupCode8Level5Code;
		private string resourceGroupCode8Level1Title;
		private string resourceGroupCode8Level2Title;
		private string resourceGroupCode8Level3Title;
		private string resourceGroupCode8Level4Title;
		private string resourceGroupCode8Level5Title;
		private string resourceGroupCode8Level1Description;
		private string resourceGroupCode8Level2Description;
		private string resourceGroupCode8Level3Description;
		private string resourceGroupCode8Level4Description;
		private string resourceGroupCode8Level5Description;
		private string resourceGroupCode8Level1Unit;
		private string resourceGroupCode8Level2Unit;
		private string resourceGroupCode8Level3Unit;
		private string resourceGroupCode8Level4Unit;
		private string resourceGroupCode8Level5Unit;
		private string resourceGroupCode9;
		private string resourceGroupCode9Level1Code;
		private string resourceGroupCode9Level2Code;
		private string resourceGroupCode9Level3Code;
		private string resourceGroupCode9Level4Code;
		private string resourceGroupCode9Level5Code;
		private string resourceGroupCode9Level1Title;
		private string resourceGroupCode9Level2Title;
		private string resourceGroupCode9Level3Title;
		private string resourceGroupCode9Level4Title;
		private string resourceGroupCode9Level5Title;
		private string resourceGroupCode9Level1Description;
		private string resourceGroupCode9Level2Description;
		private string resourceGroupCode9Level3Description;
		private string resourceGroupCode9Level4Description;
		private string resourceGroupCode9Level5Description;
		private string resourceGroupCode9Level1Unit;
		private string resourceGroupCode9Level2Unit;
		private string resourceGroupCode9Level3Unit;
		private string resourceGroupCode9Level4Unit;
		private string resourceGroupCode9Level5Unit;

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
		public virtual long? TakeoffAssignmentId
		{
			get
			{
				return takeoffAssignmentId;
			}
			set
			{
				this.takeoffAssignmentId = value;
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
		public virtual decimal TakeoffQuantity
		{
			get
			{
				return takeoffQuantity;
			}
			set
			{
				this.takeoffQuantity = value;
			}
		}
		public virtual string TakeoffUnit
		{
			get
			{
				return takeoffUnit;
			}
			set
			{
				this.takeoffUnit = value;
			}
		}
		public virtual string TakeoffQuantityName
		{
			get
			{
				return takeoffQuantityName;
			}
			set
			{
				this.takeoffQuantityName = value;
			}
		}
		public virtual decimal TakeoffCost
		{
			get
			{
				return takeoffCost;
			}
			set
			{
				this.takeoffCost = value;
			}
		}
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
		public virtual long? Id
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
		public virtual string BoqItemCustomText21
		{
			get
			{
				return boqItemCustomText21;
			}
			set
			{
				this.boqItemCustomText21 = value;
			}
		}
		public virtual string BoqItemCustomText22
		{
			get
			{
				return boqItemCustomText22;
			}
			set
			{
				this.boqItemCustomText22 = value;
			}
		}
		public virtual string BoqItemCustomText23
		{
			get
			{
				return boqItemCustomText23;
			}
			set
			{
				this.boqItemCustomText23 = value;
			}
		}
		public virtual string BoqItemCustomText24
		{
			get
			{
				return boqItemCustomText24;
			}
			set
			{
				this.boqItemCustomText24 = value;
			}
		}
		public virtual string BoqItemCustomText25
		{
			get
			{
				return boqItemCustomText25;
			}
			set
			{
				this.boqItemCustomText25 = value;
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
		public virtual decimal BoqItemCustomDecimal11
		{
			get
			{
				return boqItemCustomDecimal11;
			}
			set
			{
				this.boqItemCustomDecimal11 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal12
		{
			get
			{
				return boqItemCustomDecimal12;
			}
			set
			{
				this.boqItemCustomDecimal12 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal13
		{
			get
			{
				return boqItemCustomDecimal13;
			}
			set
			{
				this.boqItemCustomDecimal13 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal14
		{
			get
			{
				return boqItemCustomDecimal14;
			}
			set
			{
				this.boqItemCustomDecimal14 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal15
		{
			get
			{
				return boqItemCustomDecimal15;
			}
			set
			{
				this.boqItemCustomDecimal15 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal16
		{
			get
			{
				return boqItemCustomDecimal16;
			}
			set
			{
				this.boqItemCustomDecimal16 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal17
		{
			get
			{
				return boqItemCustomDecimal17;
			}
			set
			{
				this.boqItemCustomDecimal17 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal18
		{
			get
			{
				return boqItemCustomDecimal18;
			}
			set
			{
				this.boqItemCustomDecimal18 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal19
		{
			get
			{
				return boqItemCustomDecimal19;
			}
			set
			{
				this.boqItemCustomDecimal19 = value;
			}
		}
		public virtual decimal BoqItemCustomDecimal20
		{
			get
			{
				return boqItemCustomDecimal20;
			}
			set
			{
				this.boqItemCustomDecimal20 = value;
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
		public virtual decimal BoqItemCustomCumDecimal6
		{
			get
			{
				return boqItemCustomCumDecimal6;
			}
			set
			{
				this.boqItemCustomCumDecimal6 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal7
		{
			get
			{
				return boqItemCustomCumDecimal7;
			}
			set
			{
				this.boqItemCustomCumDecimal7 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal8
		{
			get
			{
				return boqItemCustomCumDecimal8;
			}
			set
			{
				this.boqItemCustomCumDecimal8 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal9
		{
			get
			{
				return boqItemCustomCumDecimal9;
			}
			set
			{
				this.boqItemCustomCumDecimal9 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal10
		{
			get
			{
				return boqItemCustomCumDecimal10;
			}
			set
			{
				this.boqItemCustomCumDecimal10 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal11
		{
			get
			{
				return boqItemCustomCumDecimal11;
			}
			set
			{
				this.boqItemCustomCumDecimal11 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal12
		{
			get
			{
				return boqItemCustomCumDecimal12;
			}
			set
			{
				this.boqItemCustomCumDecimal12 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal13
		{
			get
			{
				return boqItemCustomCumDecimal13;
			}
			set
			{
				this.boqItemCustomCumDecimal13 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal14
		{
			get
			{
				return boqItemCustomCumDecimal14;
			}
			set
			{
				this.boqItemCustomCumDecimal14 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal15
		{
			get
			{
				return boqItemCustomCumDecimal15;
			}
			set
			{
				this.boqItemCustomCumDecimal15 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal16
		{
			get
			{
				return boqItemCustomCumDecimal16;
			}
			set
			{
				this.boqItemCustomCumDecimal16 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal17
		{
			get
			{
				return boqItemCustomCumDecimal17;
			}
			set
			{
				this.boqItemCustomCumDecimal17 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal18
		{
			get
			{
				return boqItemCustomCumDecimal18;
			}
			set
			{
				this.boqItemCustomCumDecimal18 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal19
		{
			get
			{
				return boqItemCustomCumDecimal19;
			}
			set
			{
				this.boqItemCustomCumDecimal19 = value;
			}
		}
		public virtual decimal BoqItemCustomCumDecimal20
		{
			get
			{
				return boqItemCustomCumDecimal20;
			}
			set
			{
				this.boqItemCustomCumDecimal20 = value;
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
		public virtual decimal BoqItemCustomPercentange11
		{
			get
			{
				return boqItemCustomPercentange11;
			}
			set
			{
				this.boqItemCustomPercentange11 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange12
		{
			get
			{
				return boqItemCustomPercentange12;
			}
			set
			{
				this.boqItemCustomPercentange12 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange13
		{
			get
			{
				return boqItemCustomPercentange13;
			}
			set
			{
				this.boqItemCustomPercentange13 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange14
		{
			get
			{
				return boqItemCustomPercentange14;
			}
			set
			{
				this.boqItemCustomPercentange14 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange15
		{
			get
			{
				return boqItemCustomPercentange15;
			}
			set
			{
				this.boqItemCustomPercentange15 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange16
		{
			get
			{
				return boqItemCustomPercentange16;
			}
			set
			{
				this.boqItemCustomPercentange16 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange17
		{
			get
			{
				return boqItemCustomPercentange17;
			}
			set
			{
				this.boqItemCustomPercentange17 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange18
		{
			get
			{
				return boqItemCustomPercentange18;
			}
			set
			{
				this.boqItemCustomPercentange18 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange19
		{
			get
			{
				return boqItemCustomPercentange19;
			}
			set
			{
				this.boqItemCustomPercentange19 = value;
			}
		}
		public virtual decimal BoqItemCustomPercentange20
		{
			get
			{
				return boqItemCustomPercentange20;
			}
			set
			{
				this.boqItemCustomPercentange20 = value;
			}
		}

		public virtual DateTime BoqItemCustomDate1
		{
			get
			{
				return boqItemCustomDate1;
			}
			set
			{
				this.boqItemCustomDate1 = value;
			}
		}
		public virtual DateTime BoqItemCustomDate2
		{
			get
			{
				return boqItemCustomDate2;
			}
			set
			{
				this.boqItemCustomDate2 = value;
			}
		}
		public virtual DateTime BoqItemCustomDate3
		{
			get
			{
				return boqItemCustomDate3;
			}
			set
			{
				this.boqItemCustomDate3 = value;
			}
		}
		public virtual DateTime BoqItemCustomDate4
		{
			get
			{
				return boqItemCustomDate4;
			}
			set
			{
				this.boqItemCustomDate4 = value;
			}
		}
		public virtual DateTime BoqItemCustomDate5
		{
			get
			{
				return boqItemCustomDate5;
			}
			set
			{
				this.boqItemCustomDate5 = value;
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
		public virtual bool? BoqItemScheduled
		{
			get
			{
				return boqItemScheduled;
			}
			set
			{
				this.boqItemScheduled = value;
			}
		}
		public virtual decimal BoqItemGroupCode1UnitFactor
		{
			get
			{
				return boqItemGroupCode1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2UnitFactor
		{
			get
			{
				return boqItemGroupCode2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3UnitFactor
		{
			get
			{
				return boqItemGroupCode3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4UnitFactor
		{
			get
			{
				return boqItemGroupCode4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5UnitFactor
		{
			get
			{
				return boqItemGroupCode5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6UnitFactor
		{
			get
			{
				return boqItemGroupCode6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7UnitFactor
		{
			get
			{
				return boqItemGroupCode7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8UnitFactor
		{
			get
			{
				return boqItemGroupCode8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9UnitFactor
		{
			get
			{
				return boqItemGroupCode9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9UnitFactor = value;
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
		public virtual string AssignmentType
		{
			get
			{
				return assignmentType;
			}
			set
			{
				this.assignmentType = value;
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
		public virtual decimal AssignmentFactor3
		{
			get
			{
				return assignmentFactor3;
			}
			set
			{
				this.assignmentFactor3 = value;
			}
		}
		public virtual decimal AssignmentLocalFactor
		{
			get
			{
				return assignmentLocalFactor;
			}
			set
			{
				this.assignmentLocalFactor = value;
			}
		}
		public virtual decimal AssignmentQuantityPerUnit
		{
			get
			{
				return assignmentQuantityPerUnit;
			}
			set
			{
				this.assignmentQuantityPerUnit = value;
			}
		}
		public virtual string AssignmentLocalCountry
		{
			get
			{
				return assignmentLocalCountry;
			}
			set
			{
				this.assignmentLocalCountry = value;
			}
		}
		public virtual string AssignmentLocalStateProvince
		{
			get
			{
				return assignmentLocalStateProvince;
			}
			set
			{
				this.assignmentLocalStateProvince = value;
			}
		}
		public virtual decimal AssignmentExchangeRate
		{
			get
			{
				return assignmentExchangeRate;
			}
			set
			{
				this.assignmentExchangeRate = value;
			}
		}
		public virtual decimal AssignmentTotalUnits
		{
			get
			{
				return assignmentTotalUnits;
			}
			set
			{
				this.assignmentTotalUnits = value;
			}
		}
		public virtual decimal AssignmentFinalRate
		{
			get
			{
				return assignmentFinalRate;
			}
			set
			{
				this.assignmentFinalRate = value;
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
		public virtual long? ResourceId
		{
			get
			{
				return resourceId;
			}
			set
			{
				this.resourceId = value;
			}
		}
		public virtual string ResourceTitle
		{
			get
			{
				return resourceTitle;
			}
			set
			{
				this.resourceTitle = value;
			}
		}
		public virtual string ResourceDescription
		{
			get
			{
				return resourceDescription;
			}
			set
			{
				this.resourceDescription = value;
			}
		}
		public virtual string ResourceNotes
		{
			get
			{
				return resourceNotes;
			}
			set
			{
				this.resourceNotes = value;
			}
		}
		public virtual decimal ResourceRate
		{
			get
			{
				return resourceRate;
			}
			set
			{
				this.resourceRate = value;
			}
		}
		public virtual string ResourceCompany
		{
			get
			{
				return resourceCompany;
			}
			set
			{
				this.resourceCompany = value;
			}
		}
		public virtual string ResourceUnit
		{
			get
			{
				return resourceUnit;
			}
			set
			{
				this.resourceUnit = value;
			}
		}
		public virtual string ResourceCurrency
		{
			get
			{
				return resourceCurrency;
			}
			set
			{
				this.resourceCurrency = value;
			}
		}
		public virtual string ResourceCountry
		{
			get
			{
				return resourceCountry;
			}
			set
			{
				this.resourceCountry = value;
			}
		}
		public virtual string ResourceEditorId
		{
			get
			{
				return resourceEditorId;
			}
			set
			{
				this.resourceEditorId = value;
			}
		}
		public virtual string ResourceCreateUserId
		{
			get
			{
				return resourceCreateUserId;
			}
			set
			{
				this.resourceCreateUserId = value;
			}
		}
		public virtual DateTime ResourceCreateDate
		{
			get
			{
				return resourceCreateDate;
			}
			set
			{
				this.resourceCreateDate = value;
			}
		}
		public virtual DateTime ResourceLastUpdate
		{
			get
			{
				return resourceLastUpdate;
			}
			set
			{
				this.resourceLastUpdate = value;
			}
		}
		public virtual string ResourceGroupCode1
		{
			get
			{
				return resourceGroupCode1;
			}
			set
			{
				this.resourceGroupCode1 = value;
			}
		}
		public virtual string ResourceGroupCode1Level1Code
		{
			get
			{
				return resourceGroupCode1Level1Code;
			}
			set
			{
				this.resourceGroupCode1Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode1Level2Code
		{
			get
			{
				return resourceGroupCode1Level2Code;
			}
			set
			{
				this.resourceGroupCode1Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode1Level3Code
		{
			get
			{
				return resourceGroupCode1Level3Code;
			}
			set
			{
				this.resourceGroupCode1Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode1Level4Code
		{
			get
			{
				return resourceGroupCode1Level4Code;
			}
			set
			{
				this.resourceGroupCode1Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode1Level5Code
		{
			get
			{
				return resourceGroupCode1Level5Code;
			}
			set
			{
				this.resourceGroupCode1Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode1Level1Title
		{
			get
			{
				return resourceGroupCode1Level1Title;
			}
			set
			{
				this.resourceGroupCode1Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode1Level2Title
		{
			get
			{
				return resourceGroupCode1Level2Title;
			}
			set
			{
				this.resourceGroupCode1Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode1Level3Title
		{
			get
			{
				return resourceGroupCode1Level3Title;
			}
			set
			{
				this.resourceGroupCode1Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode1Level4Title
		{
			get
			{
				return resourceGroupCode1Level4Title;
			}
			set
			{
				this.resourceGroupCode1Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode1Level5Title
		{
			get
			{
				return resourceGroupCode1Level5Title;
			}
			set
			{
				this.resourceGroupCode1Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode1Level1Description
		{
			get
			{
				return resourceGroupCode1Level1Description;
			}
			set
			{
				this.resourceGroupCode1Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode1Level2Description
		{
			get
			{
				return resourceGroupCode1Level2Description;
			}
			set
			{
				this.resourceGroupCode1Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode1Level3Description
		{
			get
			{
				return resourceGroupCode1Level3Description;
			}
			set
			{
				this.resourceGroupCode1Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode1Level4Description
		{
			get
			{
				return resourceGroupCode1Level4Description;
			}
			set
			{
				this.resourceGroupCode1Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode1Level5Description
		{
			get
			{
				return resourceGroupCode1Level5Description;
			}
			set
			{
				this.resourceGroupCode1Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode1Level1Unit
		{
			get
			{
				return resourceGroupCode1Level1Unit;
			}
			set
			{
				this.resourceGroupCode1Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode1Level2Unit
		{
			get
			{
				return resourceGroupCode1Level2Unit;
			}
			set
			{
				this.resourceGroupCode1Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode1Level3Unit
		{
			get
			{
				return resourceGroupCode1Level3Unit;
			}
			set
			{
				this.resourceGroupCode1Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode1Level4Unit
		{
			get
			{
				return resourceGroupCode1Level4Unit;
			}
			set
			{
				this.resourceGroupCode1Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode1Level5Unit
		{
			get
			{
				return resourceGroupCode1Level5Unit;
			}
			set
			{
				this.resourceGroupCode1Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode2
		{
			get
			{
				return resourceGroupCode2;
			}
			set
			{
				this.resourceGroupCode2 = value;
			}
		}
		public virtual string ResourceGroupCode2Level1Code
		{
			get
			{
				return resourceGroupCode2Level1Code;
			}
			set
			{
				this.resourceGroupCode2Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode2Level2Code
		{
			get
			{
				return resourceGroupCode2Level2Code;
			}
			set
			{
				this.resourceGroupCode2Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode2Level3Code
		{
			get
			{
				return resourceGroupCode2Level3Code;
			}
			set
			{
				this.resourceGroupCode2Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode2Level4Code
		{
			get
			{
				return resourceGroupCode2Level4Code;
			}
			set
			{
				this.resourceGroupCode2Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode2Level5Code
		{
			get
			{
				return resourceGroupCode2Level5Code;
			}
			set
			{
				this.resourceGroupCode2Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode2Level1Title
		{
			get
			{
				return resourceGroupCode2Level1Title;
			}
			set
			{
				this.resourceGroupCode2Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode2Level2Title
		{
			get
			{
				return resourceGroupCode2Level2Title;
			}
			set
			{
				this.resourceGroupCode2Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode2Level3Title
		{
			get
			{
				return resourceGroupCode2Level3Title;
			}
			set
			{
				this.resourceGroupCode2Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode2Level4Title
		{
			get
			{
				return resourceGroupCode2Level4Title;
			}
			set
			{
				this.resourceGroupCode2Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode2Level5Title
		{
			get
			{
				return resourceGroupCode2Level5Title;
			}
			set
			{
				this.resourceGroupCode2Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode2Level1Description
		{
			get
			{
				return resourceGroupCode2Level1Description;
			}
			set
			{
				this.resourceGroupCode2Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode2Level2Description
		{
			get
			{
				return resourceGroupCode2Level2Description;
			}
			set
			{
				this.resourceGroupCode2Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode2Level3Description
		{
			get
			{
				return resourceGroupCode2Level3Description;
			}
			set
			{
				this.resourceGroupCode2Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode2Level4Description
		{
			get
			{
				return resourceGroupCode2Level4Description;
			}
			set
			{
				this.resourceGroupCode2Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode2Level5Description
		{
			get
			{
				return resourceGroupCode2Level5Description;
			}
			set
			{
				this.resourceGroupCode2Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode2Level1Unit
		{
			get
			{
				return resourceGroupCode2Level1Unit;
			}
			set
			{
				this.resourceGroupCode2Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode2Level2Unit
		{
			get
			{
				return resourceGroupCode2Level2Unit;
			}
			set
			{
				this.resourceGroupCode2Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode2Level3Unit
		{
			get
			{
				return resourceGroupCode2Level3Unit;
			}
			set
			{
				this.resourceGroupCode2Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode2Level4Unit
		{
			get
			{
				return resourceGroupCode2Level4Unit;
			}
			set
			{
				this.resourceGroupCode2Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode2Level5Unit
		{
			get
			{
				return resourceGroupCode2Level5Unit;
			}
			set
			{
				this.resourceGroupCode2Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode3
		{
			get
			{
				return resourceGroupCode3;
			}
			set
			{
				this.resourceGroupCode3 = value;
			}
		}
		public virtual string ResourceGroupCode3Level1Code
		{
			get
			{
				return resourceGroupCode3Level1Code;
			}
			set
			{
				this.resourceGroupCode3Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode3Level2Code
		{
			get
			{
				return resourceGroupCode3Level2Code;
			}
			set
			{
				this.resourceGroupCode3Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode3Level3Code
		{
			get
			{
				return resourceGroupCode3Level3Code;
			}
			set
			{
				this.resourceGroupCode3Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode3Level4Code
		{
			get
			{
				return resourceGroupCode3Level4Code;
			}
			set
			{
				this.resourceGroupCode3Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode3Level5Code
		{
			get
			{
				return resourceGroupCode3Level5Code;
			}
			set
			{
				this.resourceGroupCode3Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode3Level1Title
		{
			get
			{
				return resourceGroupCode3Level1Title;
			}
			set
			{
				this.resourceGroupCode3Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode3Level2Title
		{
			get
			{
				return resourceGroupCode3Level2Title;
			}
			set
			{
				this.resourceGroupCode3Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode3Level3Title
		{
			get
			{
				return resourceGroupCode3Level3Title;
			}
			set
			{
				this.resourceGroupCode3Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode3Level4Title
		{
			get
			{
				return resourceGroupCode3Level4Title;
			}
			set
			{
				this.resourceGroupCode3Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode3Level5Title
		{
			get
			{
				return resourceGroupCode3Level5Title;
			}
			set
			{
				this.resourceGroupCode3Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode3Level1Description
		{
			get
			{
				return resourceGroupCode3Level1Description;
			}
			set
			{
				this.resourceGroupCode3Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode3Level2Description
		{
			get
			{
				return resourceGroupCode3Level2Description;
			}
			set
			{
				this.resourceGroupCode3Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode3Level3Description
		{
			get
			{
				return resourceGroupCode3Level3Description;
			}
			set
			{
				this.resourceGroupCode3Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode3Level4Description
		{
			get
			{
				return resourceGroupCode3Level4Description;
			}
			set
			{
				this.resourceGroupCode3Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode3Level5Description
		{
			get
			{
				return resourceGroupCode3Level5Description;
			}
			set
			{
				this.resourceGroupCode3Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode3Level1Unit
		{
			get
			{
				return resourceGroupCode3Level1Unit;
			}
			set
			{
				this.resourceGroupCode3Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode3Level2Unit
		{
			get
			{
				return resourceGroupCode3Level2Unit;
			}
			set
			{
				this.resourceGroupCode3Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode3Level3Unit
		{
			get
			{
				return resourceGroupCode3Level3Unit;
			}
			set
			{
				this.resourceGroupCode3Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode3Level4Unit
		{
			get
			{
				return resourceGroupCode3Level4Unit;
			}
			set
			{
				this.resourceGroupCode3Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode3Level5Unit
		{
			get
			{
				return resourceGroupCode3Level5Unit;
			}
			set
			{
				this.resourceGroupCode3Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode4
		{
			get
			{
				return resourceGroupCode4;
			}
			set
			{
				this.resourceGroupCode4 = value;
			}
		}
		public virtual string ResourceGroupCode4Level1Code
		{
			get
			{
				return resourceGroupCode4Level1Code;
			}
			set
			{
				this.resourceGroupCode4Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode4Level2Code
		{
			get
			{
				return resourceGroupCode4Level2Code;
			}
			set
			{
				this.resourceGroupCode4Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode4Level3Code
		{
			get
			{
				return resourceGroupCode4Level3Code;
			}
			set
			{
				this.resourceGroupCode4Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode4Level4Code
		{
			get
			{
				return resourceGroupCode4Level4Code;
			}
			set
			{
				this.resourceGroupCode4Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode4Level5Code
		{
			get
			{
				return resourceGroupCode4Level5Code;
			}
			set
			{
				this.resourceGroupCode4Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode4Level1Title
		{
			get
			{
				return resourceGroupCode4Level1Title;
			}
			set
			{
				this.resourceGroupCode4Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode4Level2Title
		{
			get
			{
				return resourceGroupCode4Level2Title;
			}
			set
			{
				this.resourceGroupCode4Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode4Level3Title
		{
			get
			{
				return resourceGroupCode4Level3Title;
			}
			set
			{
				this.resourceGroupCode4Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode4Level4Title
		{
			get
			{
				return resourceGroupCode4Level4Title;
			}
			set
			{
				this.resourceGroupCode4Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode4Level5Title
		{
			get
			{
				return resourceGroupCode4Level5Title;
			}
			set
			{
				this.resourceGroupCode4Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode4Level1Description
		{
			get
			{
				return resourceGroupCode4Level1Description;
			}
			set
			{
				this.resourceGroupCode4Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode4Level2Description
		{
			get
			{
				return resourceGroupCode4Level2Description;
			}
			set
			{
				this.resourceGroupCode4Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode4Level3Description
		{
			get
			{
				return resourceGroupCode4Level3Description;
			}
			set
			{
				this.resourceGroupCode4Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode4Level4Description
		{
			get
			{
				return resourceGroupCode4Level4Description;
			}
			set
			{
				this.resourceGroupCode4Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode4Level5Description
		{
			get
			{
				return resourceGroupCode4Level5Description;
			}
			set
			{
				this.resourceGroupCode4Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode4Level1Unit
		{
			get
			{
				return resourceGroupCode4Level1Unit;
			}
			set
			{
				this.resourceGroupCode4Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode4Level2Unit
		{
			get
			{
				return resourceGroupCode4Level2Unit;
			}
			set
			{
				this.resourceGroupCode4Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode4Level3Unit
		{
			get
			{
				return resourceGroupCode4Level3Unit;
			}
			set
			{
				this.resourceGroupCode4Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode4Level4Unit
		{
			get
			{
				return resourceGroupCode4Level4Unit;
			}
			set
			{
				this.resourceGroupCode4Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode4Level5Unit
		{
			get
			{
				return resourceGroupCode4Level5Unit;
			}
			set
			{
				this.resourceGroupCode4Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode5
		{
			get
			{
				return resourceGroupCode5;
			}
			set
			{
				this.resourceGroupCode5 = value;
			}
		}
		public virtual string ResourceGroupCode5Level1Code
		{
			get
			{
				return resourceGroupCode5Level1Code;
			}
			set
			{
				this.resourceGroupCode5Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode5Level2Code
		{
			get
			{
				return resourceGroupCode5Level2Code;
			}
			set
			{
				this.resourceGroupCode5Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode5Level3Code
		{
			get
			{
				return resourceGroupCode5Level3Code;
			}
			set
			{
				this.resourceGroupCode5Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode5Level4Code
		{
			get
			{
				return resourceGroupCode5Level4Code;
			}
			set
			{
				this.resourceGroupCode5Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode5Level5Code
		{
			get
			{
				return resourceGroupCode5Level5Code;
			}
			set
			{
				this.resourceGroupCode5Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode5Level1Title
		{
			get
			{
				return resourceGroupCode5Level1Title;
			}
			set
			{
				this.resourceGroupCode5Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode5Level2Title
		{
			get
			{
				return resourceGroupCode5Level2Title;
			}
			set
			{
				this.resourceGroupCode5Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode5Level3Title
		{
			get
			{
				return resourceGroupCode5Level3Title;
			}
			set
			{
				this.resourceGroupCode5Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode5Level4Title
		{
			get
			{
				return resourceGroupCode5Level4Title;
			}
			set
			{
				this.resourceGroupCode5Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode5Level5Title
		{
			get
			{
				return resourceGroupCode5Level5Title;
			}
			set
			{
				this.resourceGroupCode5Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode5Level1Description
		{
			get
			{
				return resourceGroupCode5Level1Description;
			}
			set
			{
				this.resourceGroupCode5Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode5Level2Description
		{
			get
			{
				return resourceGroupCode5Level2Description;
			}
			set
			{
				this.resourceGroupCode5Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode5Level3Description
		{
			get
			{
				return resourceGroupCode5Level3Description;
			}
			set
			{
				this.resourceGroupCode5Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode5Level4Description
		{
			get
			{
				return resourceGroupCode5Level4Description;
			}
			set
			{
				this.resourceGroupCode5Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode5Level5Description
		{
			get
			{
				return resourceGroupCode5Level5Description;
			}
			set
			{
				this.resourceGroupCode5Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode5Level1Unit
		{
			get
			{
				return resourceGroupCode5Level1Unit;
			}
			set
			{
				this.resourceGroupCode5Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode5Level2Unit
		{
			get
			{
				return resourceGroupCode5Level2Unit;
			}
			set
			{
				this.resourceGroupCode5Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode5Level3Unit
		{
			get
			{
				return resourceGroupCode5Level3Unit;
			}
			set
			{
				this.resourceGroupCode5Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode5Level4Unit
		{
			get
			{
				return resourceGroupCode5Level4Unit;
			}
			set
			{
				this.resourceGroupCode5Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode5Level5Unit
		{
			get
			{
				return resourceGroupCode5Level5Unit;
			}
			set
			{
				this.resourceGroupCode5Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode6
		{
			get
			{
				return resourceGroupCode6;
			}
			set
			{
				this.resourceGroupCode6 = value;
			}
		}
		public virtual string ResourceGroupCode6Level1Code
		{
			get
			{
				return resourceGroupCode6Level1Code;
			}
			set
			{
				this.resourceGroupCode6Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode6Level2Code
		{
			get
			{
				return resourceGroupCode6Level2Code;
			}
			set
			{
				this.resourceGroupCode6Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode6Level3Code
		{
			get
			{
				return resourceGroupCode6Level3Code;
			}
			set
			{
				this.resourceGroupCode6Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode6Level4Code
		{
			get
			{
				return resourceGroupCode6Level4Code;
			}
			set
			{
				this.resourceGroupCode6Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode6Level5Code
		{
			get
			{
				return resourceGroupCode6Level5Code;
			}
			set
			{
				this.resourceGroupCode6Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode6Level1Title
		{
			get
			{
				return resourceGroupCode6Level1Title;
			}
			set
			{
				this.resourceGroupCode6Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode6Level2Title
		{
			get
			{
				return resourceGroupCode6Level2Title;
			}
			set
			{
				this.resourceGroupCode6Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode6Level3Title
		{
			get
			{
				return resourceGroupCode6Level3Title;
			}
			set
			{
				this.resourceGroupCode6Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode6Level4Title
		{
			get
			{
				return resourceGroupCode6Level4Title;
			}
			set
			{
				this.resourceGroupCode6Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode6Level5Title
		{
			get
			{
				return resourceGroupCode6Level5Title;
			}
			set
			{
				this.resourceGroupCode6Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode6Level1Description
		{
			get
			{
				return resourceGroupCode6Level1Description;
			}
			set
			{
				this.resourceGroupCode6Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode6Level2Description
		{
			get
			{
				return resourceGroupCode6Level2Description;
			}
			set
			{
				this.resourceGroupCode6Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode6Level3Description
		{
			get
			{
				return resourceGroupCode6Level3Description;
			}
			set
			{
				this.resourceGroupCode6Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode6Level4Description
		{
			get
			{
				return resourceGroupCode6Level4Description;
			}
			set
			{
				this.resourceGroupCode6Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode6Level5Description
		{
			get
			{
				return resourceGroupCode6Level5Description;
			}
			set
			{
				this.resourceGroupCode6Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode6Level1Unit
		{
			get
			{
				return resourceGroupCode6Level1Unit;
			}
			set
			{
				this.resourceGroupCode6Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode6Level2Unit
		{
			get
			{
				return resourceGroupCode6Level2Unit;
			}
			set
			{
				this.resourceGroupCode6Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode6Level3Unit
		{
			get
			{
				return resourceGroupCode6Level3Unit;
			}
			set
			{
				this.resourceGroupCode6Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode6Level4Unit
		{
			get
			{
				return resourceGroupCode6Level4Unit;
			}
			set
			{
				this.resourceGroupCode6Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode6Level5Unit
		{
			get
			{
				return resourceGroupCode6Level5Unit;
			}
			set
			{
				this.resourceGroupCode6Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode7
		{
			get
			{
				return resourceGroupCode7;
			}
			set
			{
				this.resourceGroupCode7 = value;
			}
		}
		public virtual string ResourceGroupCode7Level1Code
		{
			get
			{
				return resourceGroupCode7Level1Code;
			}
			set
			{
				this.resourceGroupCode7Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode7Level2Code
		{
			get
			{
				return resourceGroupCode7Level2Code;
			}
			set
			{
				this.resourceGroupCode7Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode7Level3Code
		{
			get
			{
				return resourceGroupCode7Level3Code;
			}
			set
			{
				this.resourceGroupCode7Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode7Level4Code
		{
			get
			{
				return resourceGroupCode7Level4Code;
			}
			set
			{
				this.resourceGroupCode7Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode7Level5Code
		{
			get
			{
				return resourceGroupCode7Level5Code;
			}
			set
			{
				this.resourceGroupCode7Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode7Level1Title
		{
			get
			{
				return resourceGroupCode7Level1Title;
			}
			set
			{
				this.resourceGroupCode7Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode7Level2Title
		{
			get
			{
				return resourceGroupCode7Level2Title;
			}
			set
			{
				this.resourceGroupCode7Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode7Level3Title
		{
			get
			{
				return resourceGroupCode7Level3Title;
			}
			set
			{
				this.resourceGroupCode7Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode7Level4Title
		{
			get
			{
				return resourceGroupCode7Level4Title;
			}
			set
			{
				this.resourceGroupCode7Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode7Level5Title
		{
			get
			{
				return resourceGroupCode7Level5Title;
			}
			set
			{
				this.resourceGroupCode7Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode7Level1Description
		{
			get
			{
				return resourceGroupCode7Level1Description;
			}
			set
			{
				this.resourceGroupCode7Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode7Level2Description
		{
			get
			{
				return resourceGroupCode7Level2Description;
			}
			set
			{
				this.resourceGroupCode7Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode7Level3Description
		{
			get
			{
				return resourceGroupCode7Level3Description;
			}
			set
			{
				this.resourceGroupCode7Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode7Level4Description
		{
			get
			{
				return resourceGroupCode7Level4Description;
			}
			set
			{
				this.resourceGroupCode7Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode7Level5Description
		{
			get
			{
				return resourceGroupCode7Level5Description;
			}
			set
			{
				this.resourceGroupCode7Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode7Level1Unit
		{
			get
			{
				return resourceGroupCode7Level1Unit;
			}
			set
			{
				this.resourceGroupCode7Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode7Level2Unit
		{
			get
			{
				return resourceGroupCode7Level2Unit;
			}
			set
			{
				this.resourceGroupCode7Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode7Level3Unit
		{
			get
			{
				return resourceGroupCode7Level3Unit;
			}
			set
			{
				this.resourceGroupCode7Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode7Level4Unit
		{
			get
			{
				return resourceGroupCode7Level4Unit;
			}
			set
			{
				this.resourceGroupCode7Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode7Level5Unit
		{
			get
			{
				return resourceGroupCode7Level5Unit;
			}
			set
			{
				this.resourceGroupCode7Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode8
		{
			get
			{
				return resourceGroupCode8;
			}
			set
			{
				this.resourceGroupCode8 = value;
			}
		}
		public virtual string ResourceGroupCode8Level1Code
		{
			get
			{
				return resourceGroupCode8Level1Code;
			}
			set
			{
				this.resourceGroupCode8Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode8Level2Code
		{
			get
			{
				return resourceGroupCode8Level2Code;
			}
			set
			{
				this.resourceGroupCode8Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode8Level3Code
		{
			get
			{
				return resourceGroupCode8Level3Code;
			}
			set
			{
				this.resourceGroupCode8Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode8Level4Code
		{
			get
			{
				return resourceGroupCode8Level4Code;
			}
			set
			{
				this.resourceGroupCode8Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode8Level5Code
		{
			get
			{
				return resourceGroupCode8Level5Code;
			}
			set
			{
				this.resourceGroupCode8Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode8Level1Title
		{
			get
			{
				return resourceGroupCode8Level1Title;
			}
			set
			{
				this.resourceGroupCode8Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode8Level2Title
		{
			get
			{
				return resourceGroupCode8Level2Title;
			}
			set
			{
				this.resourceGroupCode8Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode8Level3Title
		{
			get
			{
				return resourceGroupCode8Level3Title;
			}
			set
			{
				this.resourceGroupCode8Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode8Level4Title
		{
			get
			{
				return resourceGroupCode8Level4Title;
			}
			set
			{
				this.resourceGroupCode8Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode8Level5Title
		{
			get
			{
				return resourceGroupCode8Level5Title;
			}
			set
			{
				this.resourceGroupCode8Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode8Level1Description
		{
			get
			{
				return resourceGroupCode8Level1Description;
			}
			set
			{
				this.resourceGroupCode8Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode8Level2Description
		{
			get
			{
				return resourceGroupCode8Level2Description;
			}
			set
			{
				this.resourceGroupCode8Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode8Level3Description
		{
			get
			{
				return resourceGroupCode8Level3Description;
			}
			set
			{
				this.resourceGroupCode8Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode8Level4Description
		{
			get
			{
				return resourceGroupCode8Level4Description;
			}
			set
			{
				this.resourceGroupCode8Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode8Level5Description
		{
			get
			{
				return resourceGroupCode8Level5Description;
			}
			set
			{
				this.resourceGroupCode8Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode8Level1Unit
		{
			get
			{
				return resourceGroupCode8Level1Unit;
			}
			set
			{
				this.resourceGroupCode8Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode8Level2Unit
		{
			get
			{
				return resourceGroupCode8Level2Unit;
			}
			set
			{
				this.resourceGroupCode8Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode8Level3Unit
		{
			get
			{
				return resourceGroupCode8Level3Unit;
			}
			set
			{
				this.resourceGroupCode8Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode8Level4Unit
		{
			get
			{
				return resourceGroupCode8Level4Unit;
			}
			set
			{
				this.resourceGroupCode8Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode8Level5Unit
		{
			get
			{
				return resourceGroupCode8Level5Unit;
			}
			set
			{
				this.resourceGroupCode8Level5Unit = value;
			}
		}
		public virtual string ResourceGroupCode9
		{
			get
			{
				return resourceGroupCode9;
			}
			set
			{
				this.resourceGroupCode9 = value;
			}
		}
		public virtual string ResourceGroupCode9Level1Code
		{
			get
			{
				return resourceGroupCode9Level1Code;
			}
			set
			{
				this.resourceGroupCode9Level1Code = value;
			}
		}
		public virtual string ResourceGroupCode9Level2Code
		{
			get
			{
				return resourceGroupCode9Level2Code;
			}
			set
			{
				this.resourceGroupCode9Level2Code = value;
			}
		}
		public virtual string ResourceGroupCode9Level3Code
		{
			get
			{
				return resourceGroupCode9Level3Code;
			}
			set
			{
				this.resourceGroupCode9Level3Code = value;
			}
		}
		public virtual string ResourceGroupCode9Level4Code
		{
			get
			{
				return resourceGroupCode9Level4Code;
			}
			set
			{
				this.resourceGroupCode9Level4Code = value;
			}
		}
		public virtual string ResourceGroupCode9Level5Code
		{
			get
			{
				return resourceGroupCode9Level5Code;
			}
			set
			{
				this.resourceGroupCode9Level5Code = value;
			}
		}
		public virtual string ResourceGroupCode9Level1Title
		{
			get
			{
				return resourceGroupCode9Level1Title;
			}
			set
			{
				this.resourceGroupCode9Level1Title = value;
			}
		}
		public virtual string ResourceGroupCode9Level2Title
		{
			get
			{
				return resourceGroupCode9Level2Title;
			}
			set
			{
				this.resourceGroupCode9Level2Title = value;
			}
		}
		public virtual string ResourceGroupCode9Level3Title
		{
			get
			{
				return resourceGroupCode9Level3Title;
			}
			set
			{
				this.resourceGroupCode9Level3Title = value;
			}
		}
		public virtual string ResourceGroupCode9Level4Title
		{
			get
			{
				return resourceGroupCode9Level4Title;
			}
			set
			{
				this.resourceGroupCode9Level4Title = value;
			}
		}
		public virtual string ResourceGroupCode9Level5Title
		{
			get
			{
				return resourceGroupCode9Level5Title;
			}
			set
			{
				this.resourceGroupCode9Level5Title = value;
			}
		}
		public virtual string ResourceGroupCode9Level1Description
		{
			get
			{
				return resourceGroupCode9Level1Description;
			}
			set
			{
				this.resourceGroupCode9Level1Description = value;
			}
		}
		public virtual string ResourceGroupCode9Level2Description
		{
			get
			{
				return resourceGroupCode9Level2Description;
			}
			set
			{
				this.resourceGroupCode9Level2Description = value;
			}
		}
		public virtual string ResourceGroupCode9Level3Description
		{
			get
			{
				return resourceGroupCode9Level3Description;
			}
			set
			{
				this.resourceGroupCode9Level3Description = value;
			}
		}
		public virtual string ResourceGroupCode9Level4Description
		{
			get
			{
				return resourceGroupCode9Level4Description;
			}
			set
			{
				this.resourceGroupCode9Level4Description = value;
			}
		}
		public virtual string ResourceGroupCode9Level5Description
		{
			get
			{
				return resourceGroupCode9Level5Description;
			}
			set
			{
				this.resourceGroupCode9Level5Description = value;
			}
		}
		public virtual string ResourceGroupCode9Level1Unit
		{
			get
			{
				return resourceGroupCode9Level1Unit;
			}
			set
			{
				this.resourceGroupCode9Level1Unit = value;
			}
		}
		public virtual string ResourceGroupCode9Level2Unit
		{
			get
			{
				return resourceGroupCode9Level2Unit;
			}
			set
			{
				this.resourceGroupCode9Level2Unit = value;
			}
		}
		public virtual string ResourceGroupCode9Level3Unit
		{
			get
			{
				return resourceGroupCode9Level3Unit;
			}
			set
			{
				this.resourceGroupCode9Level3Unit = value;
			}
		}
		public virtual string ResourceGroupCode9Level4Unit
		{
			get
			{
				return resourceGroupCode9Level4Unit;
			}
			set
			{
				this.resourceGroupCode9Level4Unit = value;
			}
		}
		public virtual string ResourceGroupCode9Level5Unit
		{
			get
			{
				return resourceGroupCode9Level5Unit;
			}
			set
			{
				this.resourceGroupCode9Level5Unit = value;
			}
		}
		public virtual long? LineItemId
		{
			get
			{
				return lineItemId;
			}
			set
			{
				this.lineItemId = value;
			}
		}
		public virtual string LineItemTitle
		{
			get
			{
				return lineItemTitle;
			}
			set
			{
				this.lineItemTitle = value;
			}
		}
		public virtual string LineItemDescription
		{
			get
			{
				return lineItemDescription;
			}
			set
			{
				this.lineItemDescription = value;
			}
		}
		public virtual decimal LineItemProductivity
		{
			get
			{
				return lineItemProductivity;
			}
			set
			{
				this.lineItemProductivity = value;
			}
		}
		public virtual decimal LineItemActBased
		{
			get
			{
				return lineItemActBased;
			}
			set
			{
				this.lineItemActBased = value;
			}
		}
		public virtual string LineItemUnit
		{
			get
			{
				return lineItemUnit;
			}
			set
			{
				this.lineItemUnit = value;
			}
		}
		public virtual string LineItemProject
		{
			get
			{
				return lineItemProject;
			}
			set
			{
				this.lineItemProject = value;
			}
		}
		public virtual string LineItemCurrency
		{
			get
			{
				return lineItemCurrency;
			}
			set
			{
				this.lineItemCurrency = value;
			}
		}
		public virtual decimal LineItemTotalRate
		{
			get
			{
				return lineItemTotalRate;
			}
			set
			{
				this.lineItemTotalRate = value;
			}
		}
		public virtual decimal LineItemMaterialRate
		{
			get
			{
				return lineItemMaterialRate;
			}
			set
			{
				this.lineItemMaterialRate = value;
			}
		}
		public virtual decimal LineItemLaborRate
		{
			get
			{
				return lineItemLaborRate;
			}
			set
			{
				this.lineItemLaborRate = value;
			}
		}
		public virtual decimal LineItemSubcontractorRate
		{
			get
			{
				return lineItemSubcontractorRate;
			}
			set
			{
				this.lineItemSubcontractorRate = value;
			}
		}
		public virtual decimal LineItemEquipmentRate
		{
			get
			{
				return lineItemEquipmentRate;
			}
			set
			{
				this.lineItemEquipmentRate = value;
			}
		}
		public virtual decimal LineItemConsumablesRate
		{
			get
			{
				return lineItemConsumablesRate;
			}
			set
			{
				this.lineItemConsumablesRate = value;
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