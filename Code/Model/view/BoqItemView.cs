using System;

namespace Model.view
{

	[Serializable]
	public class BoqItemView
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
		private long? boqItemAssemblyId;
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
		private decimal boqItemAwardedMaterialRate;
		private decimal boqItemAwardedInsuranceRate;
		private decimal boqItemAwardedSubcontractorRate;
		private decimal boqItemAwardedManhours;
		private decimal boqItemAwardedIndirectRate;
		private decimal boqItemAwardedShipmentRate;
		private decimal boqItemAwardedTotalRate;

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

		private DateTime boqItemCustomDate1;
		private DateTime boqItemCustomDate2;
		private DateTime boqItemCustomDate3;
		private DateTime boqItemCustomDate4;
		private DateTime boqItemCustomDate5;

		private string boqItemPublishedItemCode;
		private string boqItemPublishedRevisionCode;
		private bool? boqItemScheduled;
		private string boqItemWbsCode1;
		private string boqItemWbsCode1Level1Code;
		private string boqItemWbsCode1Level2Code;
		private string boqItemWbsCode1Level3Code;
		private string boqItemWbsCode1Level4Code;
		private string boqItemWbsCode1Level5Code;
		private string boqItemWbsCode1Level6Code;
		private string boqItemWbsCode1Level7Code;
		private string boqItemWbsCode1Level8Code;
		private string boqItemWbsCode1Level9Code;

		private string boqItemWbsCode1Level1Title;
		private string boqItemWbsCode1Level2Title;
		private string boqItemWbsCode1Level3Title;
		private string boqItemWbsCode1Level4Title;
		private string boqItemWbsCode1Level5Title;
		private string boqItemWbsCode1Level6Title;
		private string boqItemWbsCode1Level7Title;
		private string boqItemWbsCode1Level8Title;
		private string boqItemWbsCode1Level9Title;

		private string boqItemWbsCode1Level1Unit;
		private string boqItemWbsCode1Level2Unit;
		private string boqItemWbsCode1Level3Unit;
		private string boqItemWbsCode1Level4Unit;
		private string boqItemWbsCode1Level5Unit;
		private string boqItemWbsCode1Level6Unit;
		private string boqItemWbsCode1Level7Unit;
		private string boqItemWbsCode1Level8Unit;
		private string boqItemWbsCode1Level9Unit;

		private string boqItemWbsCode1Level1Quantity;
		private string boqItemWbsCode1Level2Quantity;
		private string boqItemWbsCode1Level3Quantity;
		private string boqItemWbsCode1Level4Quantity;
		private string boqItemWbsCode1Level5Quantity;
		private string boqItemWbsCode1Level6Quantity;
		private string boqItemWbsCode1Level7Quantity;
		private string boqItemWbsCode1Level8Quantity;
		private string boqItemWbsCode1Level9Quantity;

		private string boqItemWbsCode2;
		private string boqItemWbsCode2Level1Code;
		private string boqItemWbsCode2Level2Code;
		private string boqItemWbsCode2Level3Code;
		private string boqItemWbsCode2Level4Code;
		private string boqItemWbsCode2Level5Code;
		private string boqItemWbsCode2Level6Code;
		private string boqItemWbsCode2Level7Code;
		private string boqItemWbsCode2Level8Code;
		private string boqItemWbsCode2Level9Code;

		private string boqItemWbsCode2Level1Unit;
		private string boqItemWbsCode2Level2Unit;
		private string boqItemWbsCode2Level3Unit;
		private string boqItemWbsCode2Level4Unit;
		private string boqItemWbsCode2Level5Unit;
		private string boqItemWbsCode2Level6Unit;
		private string boqItemWbsCode2Level7Unit;
		private string boqItemWbsCode2Level8Unit;
		private string boqItemWbsCode2Level9Unit;

		private string boqItemWbsCode2Level1Quantity;
		private string boqItemWbsCode2Level2Quantity;
		private string boqItemWbsCode2Level3Quantity;
		private string boqItemWbsCode2Level4Quantity;
		private string boqItemWbsCode2Level5Quantity;
		private string boqItemWbsCode2Level6Quantity;
		private string boqItemWbsCode2Level7Quantity;
		private string boqItemWbsCode2Level8Quantity;
		private string boqItemWbsCode2Level9Quantity;

		private string boqItemWbsCode2Level1Title;
		private string boqItemWbsCode2Level2Title;
		private string boqItemWbsCode2Level3Title;
		private string boqItemWbsCode2Level4Title;
		private string boqItemWbsCode2Level5Title;
		private string boqItemWbsCode2Level6Title;
		private string boqItemWbsCode2Level7Title;
		private string boqItemWbsCode2Level8Title;
		private string boqItemWbsCode2Level9Title;

		private string boqItemLocation;
		private string boqItemLocationLevel1Code;
		private string boqItemLocationLevel2Code;
		private string boqItemLocationLevel3Code;
		private string boqItemLocationLevel4Code;
		private string boqItemLocationLevel5Code;
		private string boqItemLocationLevel6Code;
		private string boqItemLocationLevel7Code;
		private string boqItemLocationLevel8Code;
		private string boqItemLocationLevel9Code;

		private string boqItemLocationLevel1Title;
		private string boqItemLocationLevel2Title;
		private string boqItemLocationLevel3Title;
		private string boqItemLocationLevel4Title;
		private string boqItemLocationLevel5Title;
		private string boqItemLocationLevel6Title;
		private string boqItemLocationLevel7Title;
		private string boqItemLocationLevel8Title;
		private string boqItemLocationLevel9Title;

		private string boqItemWbsCode1Level1ItemCode;
		private string boqItemWbsCode1Level2ItemCode;
		private string boqItemWbsCode1Level3ItemCode;
		private string boqItemWbsCode1Level4ItemCode;
		private string boqItemWbsCode1Level5ItemCode;
		private string boqItemWbsCode1Level6ItemCode;
		private string boqItemWbsCode1Level7ItemCode;
		private string boqItemWbsCode1Level8ItemCode;
		private string boqItemWbsCode1Level9ItemCode;

		private string boqItemWbsCode2Level1ItemCode;
		private string boqItemWbsCode2Level2ItemCode;
		private string boqItemWbsCode2Level3ItemCode;
		private string boqItemWbsCode2Level4ItemCode;
		private string boqItemWbsCode2Level5ItemCode;
		private string boqItemWbsCode2Level6ItemCode;
		private string boqItemWbsCode2Level7ItemCode;
		private string boqItemWbsCode2Level8ItemCode;
		private string boqItemWbsCode2Level9ItemCode;

		private string boqItemGroupCode1;
		private string boqItemGroupCode1Level1Code;
		private string boqItemGroupCode1Level2Code;
		private string boqItemGroupCode1Level3Code;
		private string boqItemGroupCode1Level4Code;
		private string boqItemGroupCode1Level5Code;
		private string boqItemGroupCode1Level6Code;
		private string boqItemGroupCode1Level7Code;
		private string boqItemGroupCode1Level8Code;
		private string boqItemGroupCode1Level9Code;

		private string boqItemGroupCode1Level1Title;
		private string boqItemGroupCode1Level2Title;
		private string boqItemGroupCode1Level3Title;
		private string boqItemGroupCode1Level4Title;
		private string boqItemGroupCode1Level5Title;
		private string boqItemGroupCode1Level6Title;
		private string boqItemGroupCode1Level7Title;
		private string boqItemGroupCode1Level8Title;
		private string boqItemGroupCode1Level9Title;

		private string boqItemGroupCode1Level1Description;
		private string boqItemGroupCode1Level2Description;
		private string boqItemGroupCode1Level3Description;
		private string boqItemGroupCode1Level4Description;
		private string boqItemGroupCode1Level5Description;
		private string boqItemGroupCode1Level6Description;
		private string boqItemGroupCode1Level7Description;
		private string boqItemGroupCode1Level8Description;
		private string boqItemGroupCode1Level9Description;

		private string boqItemGroupCode1Level1Unit;
		private string boqItemGroupCode1Level2Unit;
		private string boqItemGroupCode1Level3Unit;
		private string boqItemGroupCode1Level4Unit;
		private string boqItemGroupCode1Level5Unit;
		private string boqItemGroupCode1Level6Unit;
		private string boqItemGroupCode1Level7Unit;
		private string boqItemGroupCode1Level8Unit;
		private string boqItemGroupCode1Level9Unit;

		private decimal boqItemGroupCode1UnitFactor;
		private decimal boqItemGroupCode2UnitFactor;
		private decimal boqItemGroupCode3UnitFactor;
		private decimal boqItemGroupCode4UnitFactor;
		private decimal boqItemGroupCode5UnitFactor;
		private decimal boqItemGroupCode6UnitFactor;
		private decimal boqItemGroupCode7UnitFactor;
		private decimal boqItemGroupCode8UnitFactor;
		private decimal boqItemGroupCode9UnitFactor;

		private decimal boqItemGroupCode1Level1UnitFactor;
		private decimal boqItemGroupCode1Level2UnitFactor;
		private decimal boqItemGroupCode1Level3UnitFactor;
		private decimal boqItemGroupCode1Level4UnitFactor;
		private decimal boqItemGroupCode1Level5UnitFactor;
		private decimal boqItemGroupCode1Level6UnitFactor;
		private decimal boqItemGroupCode1Level7UnitFactor;
		private decimal boqItemGroupCode1Level8UnitFactor;
		private decimal boqItemGroupCode1Level9UnitFactor;

		private string boqItemGroupCode2;
		private string boqItemGroupCode2Level1Code;
		private string boqItemGroupCode2Level2Code;
		private string boqItemGroupCode2Level3Code;
		private string boqItemGroupCode2Level4Code;
		private string boqItemGroupCode2Level5Code;
		private string boqItemGroupCode2Level6Code;
		private string boqItemGroupCode2Level7Code;
		private string boqItemGroupCode2Level8Code;
		private string boqItemGroupCode2Level9Code;

		private string boqItemGroupCode2Level1Title;
		private string boqItemGroupCode2Level2Title;
		private string boqItemGroupCode2Level3Title;
		private string boqItemGroupCode2Level4Title;
		private string boqItemGroupCode2Level5Title;
		private string boqItemGroupCode2Level6Title;
		private string boqItemGroupCode2Level7Title;
		private string boqItemGroupCode2Level8Title;
		private string boqItemGroupCode2Level9Title;

		private string boqItemGroupCode2Level1Description;
		private string boqItemGroupCode2Level2Description;
		private string boqItemGroupCode2Level3Description;
		private string boqItemGroupCode2Level4Description;
		private string boqItemGroupCode2Level5Description;
		private string boqItemGroupCode2Level6Description;
		private string boqItemGroupCode2Level7Description;
		private string boqItemGroupCode2Level8Description;
		private string boqItemGroupCode2Level9Description;

		private string boqItemGroupCode2Level1Unit;
		private string boqItemGroupCode2Level2Unit;
		private string boqItemGroupCode2Level3Unit;
		private string boqItemGroupCode2Level4Unit;
		private string boqItemGroupCode2Level5Unit;
		private string boqItemGroupCode2Level6Unit;
		private string boqItemGroupCode2Level7Unit;
		private string boqItemGroupCode2Level8Unit;
		private string boqItemGroupCode2Level9Unit;

		private decimal boqItemGroupCode2Level1UnitFactor;
		private decimal boqItemGroupCode2Level2UnitFactor;
		private decimal boqItemGroupCode2Level3UnitFactor;
		private decimal boqItemGroupCode2Level4UnitFactor;
		private decimal boqItemGroupCode2Level5UnitFactor;
		private decimal boqItemGroupCode2Level6UnitFactor;
		private decimal boqItemGroupCode2Level7UnitFactor;
		private decimal boqItemGroupCode2Level8UnitFactor;
		private decimal boqItemGroupCode2Level9UnitFactor;

		private string boqItemGroupCode3;
		private string boqItemGroupCode3Level1Code;
		private string boqItemGroupCode3Level2Code;
		private string boqItemGroupCode3Level3Code;
		private string boqItemGroupCode3Level4Code;
		private string boqItemGroupCode3Level5Code;
		private string boqItemGroupCode3Level6Code;
		private string boqItemGroupCode3Level7Code;
		private string boqItemGroupCode3Level8Code;
		private string boqItemGroupCode3Level9Code;

		private string boqItemGroupCode3Level1Title;
		private string boqItemGroupCode3Level2Title;
		private string boqItemGroupCode3Level3Title;
		private string boqItemGroupCode3Level4Title;
		private string boqItemGroupCode3Level5Title;
		private string boqItemGroupCode3Level6Title;
		private string boqItemGroupCode3Level7Title;
		private string boqItemGroupCode3Level8Title;
		private string boqItemGroupCode3Level9Title;

		private string boqItemGroupCode3Level1Description;
		private string boqItemGroupCode3Level2Description;
		private string boqItemGroupCode3Level3Description;
		private string boqItemGroupCode3Level4Description;
		private string boqItemGroupCode3Level5Description;
		private string boqItemGroupCode3Level6Description;
		private string boqItemGroupCode3Level7Description;
		private string boqItemGroupCode3Level8Description;
		private string boqItemGroupCode3Level9Description;

		private string boqItemGroupCode3Level1Unit;
		private string boqItemGroupCode3Level2Unit;
		private string boqItemGroupCode3Level3Unit;
		private string boqItemGroupCode3Level4Unit;
		private string boqItemGroupCode3Level5Unit;
		private string boqItemGroupCode3Level6Unit;
		private string boqItemGroupCode3Level7Unit;
		private string boqItemGroupCode3Level8Unit;
		private string boqItemGroupCode3Level9Unit;

		private decimal boqItemGroupCode3Level1UnitFactor;
		private decimal boqItemGroupCode3Level2UnitFactor;
		private decimal boqItemGroupCode3Level3UnitFactor;
		private decimal boqItemGroupCode3Level4UnitFactor;
		private decimal boqItemGroupCode3Level5UnitFactor;
		private decimal boqItemGroupCode3Level6UnitFactor;
		private decimal boqItemGroupCode3Level7UnitFactor;
		private decimal boqItemGroupCode3Level8UnitFactor;
		private decimal boqItemGroupCode3Level9UnitFactor;

		private string boqItemGroupCode4;
		private string boqItemGroupCode4Level1Code;
		private string boqItemGroupCode4Level2Code;
		private string boqItemGroupCode4Level3Code;
		private string boqItemGroupCode4Level4Code;
		private string boqItemGroupCode4Level5Code;
		private string boqItemGroupCode4Level6Code;
		private string boqItemGroupCode4Level7Code;
		private string boqItemGroupCode4Level8Code;
		private string boqItemGroupCode4Level9Code;

		private string boqItemGroupCode4Level1Title;
		private string boqItemGroupCode4Level2Title;
		private string boqItemGroupCode4Level3Title;
		private string boqItemGroupCode4Level4Title;
		private string boqItemGroupCode4Level5Title;
		private string boqItemGroupCode4Level6Title;
		private string boqItemGroupCode4Level7Title;
		private string boqItemGroupCode4Level8Title;
		private string boqItemGroupCode4Level9Title;

		private string boqItemGroupCode4Level1Description;
		private string boqItemGroupCode4Level2Description;
		private string boqItemGroupCode4Level3Description;
		private string boqItemGroupCode4Level4Description;
		private string boqItemGroupCode4Level5Description;
		private string boqItemGroupCode4Level6Description;
		private string boqItemGroupCode4Level7Description;
		private string boqItemGroupCode4Level8Description;
		private string boqItemGroupCode4Level9Description;

		private string boqItemGroupCode4Level1Unit;
		private string boqItemGroupCode4Level2Unit;
		private string boqItemGroupCode4Level3Unit;
		private string boqItemGroupCode4Level4Unit;
		private string boqItemGroupCode4Level5Unit;
		private string boqItemGroupCode4Level6Unit;
		private string boqItemGroupCode4Level7Unit;
		private string boqItemGroupCode4Level8Unit;
		private string boqItemGroupCode4Level9Unit;

		private decimal boqItemGroupCode4Level1UnitFactor;
		private decimal boqItemGroupCode4Level2UnitFactor;
		private decimal boqItemGroupCode4Level3UnitFactor;
		private decimal boqItemGroupCode4Level4UnitFactor;
		private decimal boqItemGroupCode4Level5UnitFactor;
		private decimal boqItemGroupCode4Level6UnitFactor;
		private decimal boqItemGroupCode4Level7UnitFactor;
		private decimal boqItemGroupCode4Level8UnitFactor;
		private decimal boqItemGroupCode4Level9UnitFactor;

		private string boqItemGroupCode5;
		private string boqItemGroupCode5Level1Code;
		private string boqItemGroupCode5Level2Code;
		private string boqItemGroupCode5Level3Code;
		private string boqItemGroupCode5Level4Code;
		private string boqItemGroupCode5Level5Code;
		private string boqItemGroupCode5Level6Code;
		private string boqItemGroupCode5Level7Code;
		private string boqItemGroupCode5Level8Code;
		private string boqItemGroupCode5Level9Code;

		private string boqItemGroupCode5Level1Title;
		private string boqItemGroupCode5Level2Title;
		private string boqItemGroupCode5Level3Title;
		private string boqItemGroupCode5Level4Title;
		private string boqItemGroupCode5Level5Title;
		private string boqItemGroupCode5Level6Title;
		private string boqItemGroupCode5Level7Title;
		private string boqItemGroupCode5Level8Title;
		private string boqItemGroupCode5Level9Title;

		private string boqItemGroupCode5Level1Description;
		private string boqItemGroupCode5Level2Description;
		private string boqItemGroupCode5Level3Description;
		private string boqItemGroupCode5Level4Description;
		private string boqItemGroupCode5Level5Description;
		private string boqItemGroupCode5Level6Description;
		private string boqItemGroupCode5Level7Description;
		private string boqItemGroupCode5Level8Description;
		private string boqItemGroupCode5Level9Description;

		private string boqItemGroupCode5Level1Unit;
		private string boqItemGroupCode5Level2Unit;
		private string boqItemGroupCode5Level3Unit;
		private string boqItemGroupCode5Level4Unit;
		private string boqItemGroupCode5Level5Unit;
		private string boqItemGroupCode5Level6Unit;
		private string boqItemGroupCode5Level7Unit;
		private string boqItemGroupCode5Level8Unit;
		private string boqItemGroupCode5Level9Unit;

		private decimal boqItemGroupCode5Level1UnitFactor;
		private decimal boqItemGroupCode5Level2UnitFactor;
		private decimal boqItemGroupCode5Level3UnitFactor;
		private decimal boqItemGroupCode5Level4UnitFactor;
		private decimal boqItemGroupCode5Level5UnitFactor;
		private decimal boqItemGroupCode5Level6UnitFactor;
		private decimal boqItemGroupCode5Level7UnitFactor;
		private decimal boqItemGroupCode5Level8UnitFactor;
		private decimal boqItemGroupCode5Level9UnitFactor;

		private string boqItemGroupCode6;
		private string boqItemGroupCode6Level1Code;
		private string boqItemGroupCode6Level2Code;
		private string boqItemGroupCode6Level3Code;
		private string boqItemGroupCode6Level4Code;
		private string boqItemGroupCode6Level5Code;
		private string boqItemGroupCode6Level6Code;
		private string boqItemGroupCode6Level7Code;
		private string boqItemGroupCode6Level8Code;
		private string boqItemGroupCode6Level9Code;

		private string boqItemGroupCode6Level1Title;
		private string boqItemGroupCode6Level2Title;
		private string boqItemGroupCode6Level3Title;
		private string boqItemGroupCode6Level4Title;
		private string boqItemGroupCode6Level5Title;
		private string boqItemGroupCode6Level6Title;
		private string boqItemGroupCode6Level7Title;
		private string boqItemGroupCode6Level8Title;
		private string boqItemGroupCode6Level9Title;

		private string boqItemGroupCode6Level1Description;
		private string boqItemGroupCode6Level2Description;
		private string boqItemGroupCode6Level3Description;
		private string boqItemGroupCode6Level4Description;
		private string boqItemGroupCode6Level5Description;
		private string boqItemGroupCode6Level6Description;
		private string boqItemGroupCode6Level7Description;
		private string boqItemGroupCode6Level8Description;
		private string boqItemGroupCode6Level9Description;

		private string boqItemGroupCode6Level1Unit;
		private string boqItemGroupCode6Level2Unit;
		private string boqItemGroupCode6Level3Unit;
		private string boqItemGroupCode6Level4Unit;
		private string boqItemGroupCode6Level5Unit;
		private string boqItemGroupCode6Level6Unit;
		private string boqItemGroupCode6Level7Unit;
		private string boqItemGroupCode6Level8Unit;
		private string boqItemGroupCode6Level9Unit;

		private decimal boqItemGroupCode6Level1UnitFactor;
		private decimal boqItemGroupCode6Level2UnitFactor;
		private decimal boqItemGroupCode6Level3UnitFactor;
		private decimal boqItemGroupCode6Level4UnitFactor;
		private decimal boqItemGroupCode6Level5UnitFactor;
		private decimal boqItemGroupCode6Level6UnitFactor;
		private decimal boqItemGroupCode6Level7UnitFactor;
		private decimal boqItemGroupCode6Level8UnitFactor;
		private decimal boqItemGroupCode6Level9UnitFactor;

		private string boqItemGroupCode7;
		private string boqItemGroupCode7Level1Code;
		private string boqItemGroupCode7Level2Code;
		private string boqItemGroupCode7Level3Code;
		private string boqItemGroupCode7Level4Code;
		private string boqItemGroupCode7Level5Code;
		private string boqItemGroupCode7Level6Code;
		private string boqItemGroupCode7Level7Code;
		private string boqItemGroupCode7Level8Code;
		private string boqItemGroupCode7Level9Code;

		private string boqItemGroupCode7Level1Title;
		private string boqItemGroupCode7Level2Title;
		private string boqItemGroupCode7Level3Title;
		private string boqItemGroupCode7Level4Title;
		private string boqItemGroupCode7Level5Title;
		private string boqItemGroupCode7Level6Title;
		private string boqItemGroupCode7Level7Title;
		private string boqItemGroupCode7Level8Title;
		private string boqItemGroupCode7Level9Title;

		private string boqItemGroupCode7Level1Description;
		private string boqItemGroupCode7Level2Description;
		private string boqItemGroupCode7Level3Description;
		private string boqItemGroupCode7Level4Description;
		private string boqItemGroupCode7Level5Description;
		private string boqItemGroupCode7Level6Description;
		private string boqItemGroupCode7Level7Description;
		private string boqItemGroupCode7Level8Description;
		private string boqItemGroupCode7Level9Description;

		private string boqItemGroupCode7Level1Unit;
		private string boqItemGroupCode7Level2Unit;
		private string boqItemGroupCode7Level3Unit;
		private string boqItemGroupCode7Level4Unit;
		private string boqItemGroupCode7Level5Unit;
		private string boqItemGroupCode7Level6Unit;
		private string boqItemGroupCode7Level7Unit;
		private string boqItemGroupCode7Level8Unit;
		private string boqItemGroupCode7Level9Unit;

		private decimal boqItemGroupCode7Level1UnitFactor;
		private decimal boqItemGroupCode7Level2UnitFactor;
		private decimal boqItemGroupCode7Level3UnitFactor;
		private decimal boqItemGroupCode7Level4UnitFactor;
		private decimal boqItemGroupCode7Level5UnitFactor;
		private decimal boqItemGroupCode7Level6UnitFactor;
		private decimal boqItemGroupCode7Level7UnitFactor;
		private decimal boqItemGroupCode7Level8UnitFactor;
		private decimal boqItemGroupCode7Level9UnitFactor;

		private string boqItemGroupCode8;
		private string boqItemGroupCode8Level1Code;
		private string boqItemGroupCode8Level2Code;
		private string boqItemGroupCode8Level3Code;
		private string boqItemGroupCode8Level4Code;
		private string boqItemGroupCode8Level5Code;
		private string boqItemGroupCode8Level6Code;
		private string boqItemGroupCode8Level7Code;
		private string boqItemGroupCode8Level8Code;
		private string boqItemGroupCode8Level9Code;

		private string boqItemGroupCode8Level1Title;
		private string boqItemGroupCode8Level2Title;
		private string boqItemGroupCode8Level3Title;
		private string boqItemGroupCode8Level4Title;
		private string boqItemGroupCode8Level5Title;
		private string boqItemGroupCode8Level6Title;
		private string boqItemGroupCode8Level7Title;
		private string boqItemGroupCode8Level8Title;
		private string boqItemGroupCode8Level9Title;


		private string boqItemGroupCode8Level1Description;
		private string boqItemGroupCode8Level2Description;
		private string boqItemGroupCode8Level3Description;
		private string boqItemGroupCode8Level4Description;
		private string boqItemGroupCode8Level5Description;
		private string boqItemGroupCode8Level6Description;
		private string boqItemGroupCode8Level7Description;
		private string boqItemGroupCode8Level8Description;
		private string boqItemGroupCode8Level9Description;

		private string boqItemGroupCode8Level1Unit;
		private string boqItemGroupCode8Level2Unit;
		private string boqItemGroupCode8Level3Unit;
		private string boqItemGroupCode8Level4Unit;
		private string boqItemGroupCode8Level5Unit;
		private string boqItemGroupCode8Level6Unit;
		private string boqItemGroupCode8Level7Unit;
		private string boqItemGroupCode8Level8Unit;
		private string boqItemGroupCode8Level9Unit;

		private decimal boqItemGroupCode8Level1UnitFactor;
		private decimal boqItemGroupCode8Level2UnitFactor;
		private decimal boqItemGroupCode8Level3UnitFactor;
		private decimal boqItemGroupCode8Level4UnitFactor;
		private decimal boqItemGroupCode8Level5UnitFactor;
		private decimal boqItemGroupCode8Level6UnitFactor;
		private decimal boqItemGroupCode8Level7UnitFactor;
		private decimal boqItemGroupCode8Level8UnitFactor;
		private decimal boqItemGroupCode8Level9UnitFactor;

		private string boqItemGroupCode9;
		private string boqItemGroupCode9Level1Code;
		private string boqItemGroupCode9Level2Code;
		private string boqItemGroupCode9Level3Code;
		private string boqItemGroupCode9Level4Code;
		private string boqItemGroupCode9Level5Code;
		private string boqItemGroupCode9Level6Code;
		private string boqItemGroupCode9Level7Code;
		private string boqItemGroupCode9Level8Code;
		private string boqItemGroupCode9Level9Code;

		private string boqItemGroupCode9Level1Title;
		private string boqItemGroupCode9Level2Title;
		private string boqItemGroupCode9Level3Title;
		private string boqItemGroupCode9Level4Title;
		private string boqItemGroupCode9Level5Title;
		private string boqItemGroupCode9Level6Title;
		private string boqItemGroupCode9Level7Title;
		private string boqItemGroupCode9Level8Title;
		private string boqItemGroupCode9Level9Title;

		private string boqItemGroupCode9Level1Description;
		private string boqItemGroupCode9Level2Description;
		private string boqItemGroupCode9Level3Description;
		private string boqItemGroupCode9Level4Description;
		private string boqItemGroupCode9Level5Description;
		private string boqItemGroupCode9Level6Description;
		private string boqItemGroupCode9Level7Description;
		private string boqItemGroupCode9Level8Description;
		private string boqItemGroupCode9Level9Description;

		private string boqItemGroupCode9Level1Unit;
		private string boqItemGroupCode9Level2Unit;
		private string boqItemGroupCode9Level3Unit;
		private string boqItemGroupCode9Level4Unit;
		private string boqItemGroupCode9Level5Unit;
		private string boqItemGroupCode9Level6Unit;
		private string boqItemGroupCode9Level7Unit;
		private string boqItemGroupCode9Level8Unit;
		private string boqItemGroupCode9Level9Unit;

		private decimal boqItemGroupCode9Level1UnitFactor;
		private decimal boqItemGroupCode9Level2UnitFactor;
		private decimal boqItemGroupCode9Level3UnitFactor;
		private decimal boqItemGroupCode9Level4UnitFactor;
		private decimal boqItemGroupCode9Level5UnitFactor;
		private decimal boqItemGroupCode9Level6UnitFactor;
		private decimal boqItemGroupCode9Level7UnitFactor;
		private decimal boqItemGroupCode9Level8UnitFactor;
		private decimal boqItemGroupCode9Level9UnitFactor;

		private string boqItemDescription;
		private string boqItemNotes;
		private sbyte? boqItemEquipmentRateType;
		private sbyte? boqItemAssemblyRateType;
		private sbyte? boqItemSubcontractorRateType;
		private sbyte? boqItemLaborRateType;
		private sbyte? boqItemMaterialRateType;
		private sbyte? boqItemConsumableRateType;
		private sbyte? boqItemTakeoffQuantityType;

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
		public virtual long? BoqItemAssemblyId
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
		public virtual decimal BoqItemAwardedMaterialRate
		{
			get
			{
				return boqItemAwardedMaterialRate;
			}
			set
			{
				this.boqItemAwardedMaterialRate = value;
			}
		}
		public virtual decimal BoqItemAwardedInsuranceRate
		{
			get
			{
				return boqItemAwardedInsuranceRate;
			}
			set
			{
				this.boqItemAwardedInsuranceRate = value;
			}
		}
		public virtual decimal BoqItemAwardedSubcontractorRate
		{
			get
			{
				return boqItemAwardedSubcontractorRate;
			}
			set
			{
				this.boqItemAwardedSubcontractorRate = value;
			}
		}
		public virtual decimal BoqItemAwardedManhours
		{
			get
			{
				return boqItemAwardedManhours;
			}
			set
			{
				this.boqItemAwardedManhours = value;
			}
		}
		public virtual decimal BoqItemAwardedIndirectRate
		{
			get
			{
				return boqItemAwardedIndirectRate;
			}
			set
			{
				this.boqItemAwardedIndirectRate = value;
			}
		}
		public virtual decimal BoqItemAwardedShipmentRate
		{
			get
			{
				return boqItemAwardedShipmentRate;
			}
			set
			{
				this.boqItemAwardedShipmentRate = value;
			}
		}
		public virtual decimal BoqItemAwardedTotalRate
		{
			get
			{
				return boqItemAwardedTotalRate;
			}
			set
			{
				this.boqItemAwardedTotalRate = value;
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
		public virtual string BoqItemWbsCode1Level6Code
		{
			get
			{
				return boqItemWbsCode1Level6Code;
			}
			set
			{
				this.boqItemWbsCode1Level6Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level7Code
		{
			get
			{
				return boqItemWbsCode1Level7Code;
			}
			set
			{
				this.boqItemWbsCode1Level7Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level8Code
		{
			get
			{
				return boqItemWbsCode1Level8Code;
			}
			set
			{
				this.boqItemWbsCode1Level8Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level9Code
		{
			get
			{
				return boqItemWbsCode1Level9Code;
			}
			set
			{
				this.boqItemWbsCode1Level9Code = value;
			}
		}
		public virtual string BoqItemWbsCode1Level6Title
		{
			get
			{
				return boqItemWbsCode1Level6Title;
			}
			set
			{
				this.boqItemWbsCode1Level6Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level7Title
		{
			get
			{
				return boqItemWbsCode1Level7Title;
			}
			set
			{
				this.boqItemWbsCode1Level7Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level8Title
		{
			get
			{
				return boqItemWbsCode1Level8Title;
			}
			set
			{
				this.boqItemWbsCode1Level8Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level9Title
		{
			get
			{
				return boqItemWbsCode1Level9Title;
			}
			set
			{
				this.boqItemWbsCode1Level9Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level6Code
		{
			get
			{
				return boqItemWbsCode2Level6Code;
			}
			set
			{
				this.boqItemWbsCode2Level6Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level7Code
		{
			get
			{
				return boqItemWbsCode2Level7Code;
			}
			set
			{
				this.boqItemWbsCode2Level7Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level8Code
		{
			get
			{
				return boqItemWbsCode2Level8Code;
			}
			set
			{
				this.boqItemWbsCode2Level8Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level9Code
		{
			get
			{
				return boqItemWbsCode2Level9Code;
			}
			set
			{
				this.boqItemWbsCode2Level9Code = value;
			}
		}
		public virtual string BoqItemWbsCode2Level6Title
		{
			get
			{
				return boqItemWbsCode2Level6Title;
			}
			set
			{
				this.boqItemWbsCode2Level6Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level7Title
		{
			get
			{
				return boqItemWbsCode2Level7Title;
			}
			set
			{
				this.boqItemWbsCode2Level7Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level8Title
		{
			get
			{
				return boqItemWbsCode2Level8Title;
			}
			set
			{
				this.boqItemWbsCode2Level8Title = value;
			}
		}
		public virtual string BoqItemWbsCode2Level9Title
		{
			get
			{
				return boqItemWbsCode2Level9Title;
			}
			set
			{
				this.boqItemWbsCode2Level9Title = value;
			}
		}
		public virtual string BoqItemLocationLevel6Code
		{
			get
			{
				return boqItemLocationLevel6Code;
			}
			set
			{
				this.boqItemLocationLevel6Code = value;
			}
		}
		public virtual string BoqItemLocationLevel7Code
		{
			get
			{
				return boqItemLocationLevel7Code;
			}
			set
			{
				this.boqItemLocationLevel7Code = value;
			}
		}
		public virtual string BoqItemLocationLevel8Code
		{
			get
			{
				return boqItemLocationLevel8Code;
			}
			set
			{
				this.boqItemLocationLevel8Code = value;
			}
		}
		public virtual string BoqItemLocationLevel9Code
		{
			get
			{
				return boqItemLocationLevel9Code;
			}
			set
			{
				this.boqItemLocationLevel9Code = value;
			}
		}
		public virtual string BoqItemLocationLevel6Title
		{
			get
			{
				return boqItemLocationLevel6Title;
			}
			set
			{
				this.boqItemLocationLevel6Title = value;
			}
		}
		public virtual string BoqItemLocationLevel7Title
		{
			get
			{
				return boqItemLocationLevel7Title;
			}
			set
			{
				this.boqItemLocationLevel7Title = value;
			}
		}
		public virtual string BoqItemLocationLevel8Title
		{
			get
			{
				return boqItemLocationLevel8Title;
			}
			set
			{
				this.boqItemLocationLevel8Title = value;
			}
		}
		public virtual string BoqItemLocationLevel9Title
		{
			get
			{
				return boqItemLocationLevel9Title;
			}
			set
			{
				this.boqItemLocationLevel9Title = value;
			}
		}
		public virtual string BoqItemWbsCode1Level6ItemCode
		{
			get
			{
				return boqItemWbsCode1Level6ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level6ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level7ItemCode
		{
			get
			{
				return boqItemWbsCode1Level7ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level7ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level8ItemCode
		{
			get
			{
				return boqItemWbsCode1Level8ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level8ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode1Level9ItemCode
		{
			get
			{
				return boqItemWbsCode1Level9ItemCode;
			}
			set
			{
				this.boqItemWbsCode1Level9ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level6ItemCode
		{
			get
			{
				return boqItemWbsCode2Level6ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level6ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level7ItemCode
		{
			get
			{
				return boqItemWbsCode2Level7ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level7ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level8ItemCode
		{
			get
			{
				return boqItemWbsCode2Level8ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level8ItemCode = value;
			}
		}
		public virtual string BoqItemWbsCode2Level9ItemCode
		{
			get
			{
				return boqItemWbsCode2Level9ItemCode;
			}
			set
			{
				this.boqItemWbsCode2Level9ItemCode = value;
			}
		}
		public virtual string BoqItemGroupCode1Level6Code
		{
			get
			{
				return boqItemGroupCode1Level6Code;
			}
			set
			{
				this.boqItemGroupCode1Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level7Code
		{
			get
			{
				return boqItemGroupCode1Level7Code;
			}
			set
			{
				this.boqItemGroupCode1Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level8Code
		{
			get
			{
				return boqItemGroupCode1Level8Code;
			}
			set
			{
				this.boqItemGroupCode1Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level9Code
		{
			get
			{
				return boqItemGroupCode1Level9Code;
			}
			set
			{
				this.boqItemGroupCode1Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode1Level6Title
		{
			get
			{
				return boqItemGroupCode1Level6Title;
			}
			set
			{
				this.boqItemGroupCode1Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level7Title
		{
			get
			{
				return boqItemGroupCode1Level7Title;
			}
			set
			{
				this.boqItemGroupCode1Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level8Title
		{
			get
			{
				return boqItemGroupCode1Level8Title;
			}
			set
			{
				this.boqItemGroupCode1Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level9Title
		{
			get
			{
				return boqItemGroupCode1Level9Title;
			}
			set
			{
				this.boqItemGroupCode1Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode1Level6Description
		{
			get
			{
				return boqItemGroupCode1Level6Description;
			}
			set
			{
				this.boqItemGroupCode1Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level7Description
		{
			get
			{
				return boqItemGroupCode1Level7Description;
			}
			set
			{
				this.boqItemGroupCode1Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level8Description
		{
			get
			{
				return boqItemGroupCode1Level8Description;
			}
			set
			{
				this.boqItemGroupCode1Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level9Description
		{
			get
			{
				return boqItemGroupCode1Level9Description;
			}
			set
			{
				this.boqItemGroupCode1Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode1Level6Unit
		{
			get
			{
				return boqItemGroupCode1Level6Unit;
			}
			set
			{
				this.boqItemGroupCode1Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level7Unit
		{
			get
			{
				return boqItemGroupCode1Level7Unit;
			}
			set
			{
				this.boqItemGroupCode1Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level8Unit
		{
			get
			{
				return boqItemGroupCode1Level8Unit;
			}
			set
			{
				this.boqItemGroupCode1Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode1Level9Unit
		{
			get
			{
				return boqItemGroupCode1Level9Unit;
			}
			set
			{
				this.boqItemGroupCode1Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level6Code
		{
			get
			{
				return boqItemGroupCode2Level6Code;
			}
			set
			{
				this.boqItemGroupCode2Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level7Code
		{
			get
			{
				return boqItemGroupCode2Level7Code;
			}
			set
			{
				this.boqItemGroupCode2Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level8Code
		{
			get
			{
				return boqItemGroupCode2Level8Code;
			}
			set
			{
				this.boqItemGroupCode2Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level9Code
		{
			get
			{
				return boqItemGroupCode2Level9Code;
			}
			set
			{
				this.boqItemGroupCode2Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode2Level6Title
		{
			get
			{
				return boqItemGroupCode2Level6Title;
			}
			set
			{
				this.boqItemGroupCode2Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level7Title
		{
			get
			{
				return boqItemGroupCode2Level7Title;
			}
			set
			{
				this.boqItemGroupCode2Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level8Title
		{
			get
			{
				return boqItemGroupCode2Level8Title;
			}
			set
			{
				this.boqItemGroupCode2Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level9Title
		{
			get
			{
				return boqItemGroupCode2Level9Title;
			}
			set
			{
				this.boqItemGroupCode2Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode2Level6Description
		{
			get
			{
				return boqItemGroupCode2Level6Description;
			}
			set
			{
				this.boqItemGroupCode2Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level7Description
		{
			get
			{
				return boqItemGroupCode2Level7Description;
			}
			set
			{
				this.boqItemGroupCode2Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level8Description
		{
			get
			{
				return boqItemGroupCode2Level8Description;
			}
			set
			{
				this.boqItemGroupCode2Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level9Description
		{
			get
			{
				return boqItemGroupCode2Level9Description;
			}
			set
			{
				this.boqItemGroupCode2Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode2Level6Unit
		{
			get
			{
				return boqItemGroupCode2Level6Unit;
			}
			set
			{
				this.boqItemGroupCode2Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level7Unit
		{
			get
			{
				return boqItemGroupCode2Level7Unit;
			}
			set
			{
				this.boqItemGroupCode2Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level8Unit
		{
			get
			{
				return boqItemGroupCode2Level8Unit;
			}
			set
			{
				this.boqItemGroupCode2Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode2Level9Unit
		{
			get
			{
				return boqItemGroupCode2Level9Unit;
			}
			set
			{
				this.boqItemGroupCode2Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level6Code
		{
			get
			{
				return boqItemGroupCode3Level6Code;
			}
			set
			{
				this.boqItemGroupCode3Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level7Code
		{
			get
			{
				return boqItemGroupCode3Level7Code;
			}
			set
			{
				this.boqItemGroupCode3Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level8Code
		{
			get
			{
				return boqItemGroupCode3Level8Code;
			}
			set
			{
				this.boqItemGroupCode3Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level9Code
		{
			get
			{
				return boqItemGroupCode3Level9Code;
			}
			set
			{
				this.boqItemGroupCode3Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode3Level6Title
		{
			get
			{
				return boqItemGroupCode3Level6Title;
			}
			set
			{
				this.boqItemGroupCode3Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level7Title
		{
			get
			{
				return boqItemGroupCode3Level7Title;
			}
			set
			{
				this.boqItemGroupCode3Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level8Title
		{
			get
			{
				return boqItemGroupCode3Level8Title;
			}
			set
			{
				this.boqItemGroupCode3Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level9Title
		{
			get
			{
				return boqItemGroupCode3Level9Title;
			}
			set
			{
				this.boqItemGroupCode3Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode3Level6Description
		{
			get
			{
				return boqItemGroupCode3Level6Description;
			}
			set
			{
				this.boqItemGroupCode3Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level7Description
		{
			get
			{
				return boqItemGroupCode3Level7Description;
			}
			set
			{
				this.boqItemGroupCode3Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level8Description
		{
			get
			{
				return boqItemGroupCode3Level8Description;
			}
			set
			{
				this.boqItemGroupCode3Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level9Description
		{
			get
			{
				return boqItemGroupCode3Level9Description;
			}
			set
			{
				this.boqItemGroupCode3Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode3Level6Unit
		{
			get
			{
				return boqItemGroupCode3Level6Unit;
			}
			set
			{
				this.boqItemGroupCode3Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level7Unit
		{
			get
			{
				return boqItemGroupCode3Level7Unit;
			}
			set
			{
				this.boqItemGroupCode3Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level8Unit
		{
			get
			{
				return boqItemGroupCode3Level8Unit;
			}
			set
			{
				this.boqItemGroupCode3Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode3Level9Unit
		{
			get
			{
				return boqItemGroupCode3Level9Unit;
			}
			set
			{
				this.boqItemGroupCode3Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level6Code
		{
			get
			{
				return boqItemGroupCode4Level6Code;
			}
			set
			{
				this.boqItemGroupCode4Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level7Code
		{
			get
			{
				return boqItemGroupCode4Level7Code;
			}
			set
			{
				this.boqItemGroupCode4Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level8Code
		{
			get
			{
				return boqItemGroupCode4Level8Code;
			}
			set
			{
				this.boqItemGroupCode4Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level9Code
		{
			get
			{
				return boqItemGroupCode4Level9Code;
			}
			set
			{
				this.boqItemGroupCode4Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode4Level6Title
		{
			get
			{
				return boqItemGroupCode4Level6Title;
			}
			set
			{
				this.boqItemGroupCode4Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level7Title
		{
			get
			{
				return boqItemGroupCode4Level7Title;
			}
			set
			{
				this.boqItemGroupCode4Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level8Title
		{
			get
			{
				return boqItemGroupCode4Level8Title;
			}
			set
			{
				this.boqItemGroupCode4Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level9Title
		{
			get
			{
				return boqItemGroupCode4Level9Title;
			}
			set
			{
				this.boqItemGroupCode4Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode4Level6Description
		{
			get
			{
				return boqItemGroupCode4Level6Description;
			}
			set
			{
				this.boqItemGroupCode4Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level7Description
		{
			get
			{
				return boqItemGroupCode4Level7Description;
			}
			set
			{
				this.boqItemGroupCode4Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level8Description
		{
			get
			{
				return boqItemGroupCode4Level8Description;
			}
			set
			{
				this.boqItemGroupCode4Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level9Description
		{
			get
			{
				return boqItemGroupCode4Level9Description;
			}
			set
			{
				this.boqItemGroupCode4Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode4Level6Unit
		{
			get
			{
				return boqItemGroupCode4Level6Unit;
			}
			set
			{
				this.boqItemGroupCode4Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level7Unit
		{
			get
			{
				return boqItemGroupCode4Level7Unit;
			}
			set
			{
				this.boqItemGroupCode4Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level8Unit
		{
			get
			{
				return boqItemGroupCode4Level8Unit;
			}
			set
			{
				this.boqItemGroupCode4Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode4Level9Unit
		{
			get
			{
				return boqItemGroupCode4Level9Unit;
			}
			set
			{
				this.boqItemGroupCode4Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level6Code
		{
			get
			{
				return boqItemGroupCode5Level6Code;
			}
			set
			{
				this.boqItemGroupCode5Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level7Code
		{
			get
			{
				return boqItemGroupCode5Level7Code;
			}
			set
			{
				this.boqItemGroupCode5Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level8Code
		{
			get
			{
				return boqItemGroupCode5Level8Code;
			}
			set
			{
				this.boqItemGroupCode5Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level9Code
		{
			get
			{
				return boqItemGroupCode5Level9Code;
			}
			set
			{
				this.boqItemGroupCode5Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode5Level6Title
		{
			get
			{
				return boqItemGroupCode5Level6Title;
			}
			set
			{
				this.boqItemGroupCode5Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level7Title
		{
			get
			{
				return boqItemGroupCode5Level7Title;
			}
			set
			{
				this.boqItemGroupCode5Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level8Title
		{
			get
			{
				return boqItemGroupCode5Level8Title;
			}
			set
			{
				this.boqItemGroupCode5Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level9Title
		{
			get
			{
				return boqItemGroupCode5Level9Title;
			}
			set
			{
				this.boqItemGroupCode5Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode5Level6Description
		{
			get
			{
				return boqItemGroupCode5Level6Description;
			}
			set
			{
				this.boqItemGroupCode5Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level7Description
		{
			get
			{
				return boqItemGroupCode5Level7Description;
			}
			set
			{
				this.boqItemGroupCode5Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level8Description
		{
			get
			{
				return boqItemGroupCode5Level8Description;
			}
			set
			{
				this.boqItemGroupCode5Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level9Description
		{
			get
			{
				return boqItemGroupCode5Level9Description;
			}
			set
			{
				this.boqItemGroupCode5Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode5Level6Unit
		{
			get
			{
				return boqItemGroupCode5Level6Unit;
			}
			set
			{
				this.boqItemGroupCode5Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level7Unit
		{
			get
			{
				return boqItemGroupCode5Level7Unit;
			}
			set
			{
				this.boqItemGroupCode5Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level8Unit
		{
			get
			{
				return boqItemGroupCode5Level8Unit;
			}
			set
			{
				this.boqItemGroupCode5Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode5Level9Unit
		{
			get
			{
				return boqItemGroupCode5Level9Unit;
			}
			set
			{
				this.boqItemGroupCode5Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level6Code
		{
			get
			{
				return boqItemGroupCode6Level6Code;
			}
			set
			{
				this.boqItemGroupCode6Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level7Code
		{
			get
			{
				return boqItemGroupCode6Level7Code;
			}
			set
			{
				this.boqItemGroupCode6Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level8Code
		{
			get
			{
				return boqItemGroupCode6Level8Code;
			}
			set
			{
				this.boqItemGroupCode6Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level9Code
		{
			get
			{
				return boqItemGroupCode6Level9Code;
			}
			set
			{
				this.boqItemGroupCode6Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode6Level6Title
		{
			get
			{
				return boqItemGroupCode6Level6Title;
			}
			set
			{
				this.boqItemGroupCode6Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level7Title
		{
			get
			{
				return boqItemGroupCode6Level7Title;
			}
			set
			{
				this.boqItemGroupCode6Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level8Title
		{
			get
			{
				return boqItemGroupCode6Level8Title;
			}
			set
			{
				this.boqItemGroupCode6Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level9Title
		{
			get
			{
				return boqItemGroupCode6Level9Title;
			}
			set
			{
				this.boqItemGroupCode6Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode6Level6Description
		{
			get
			{
				return boqItemGroupCode6Level6Description;
			}
			set
			{
				this.boqItemGroupCode6Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level7Description
		{
			get
			{
				return boqItemGroupCode6Level7Description;
			}
			set
			{
				this.boqItemGroupCode6Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level8Description
		{
			get
			{
				return boqItemGroupCode6Level8Description;
			}
			set
			{
				this.boqItemGroupCode6Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level9Description
		{
			get
			{
				return boqItemGroupCode6Level9Description;
			}
			set
			{
				this.boqItemGroupCode6Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode6Level6Unit
		{
			get
			{
				return boqItemGroupCode6Level6Unit;
			}
			set
			{
				this.boqItemGroupCode6Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level7Unit
		{
			get
			{
				return boqItemGroupCode6Level7Unit;
			}
			set
			{
				this.boqItemGroupCode6Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level8Unit
		{
			get
			{
				return boqItemGroupCode6Level8Unit;
			}
			set
			{
				this.boqItemGroupCode6Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode6Level9Unit
		{
			get
			{
				return boqItemGroupCode6Level9Unit;
			}
			set
			{
				this.boqItemGroupCode6Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level6Code
		{
			get
			{
				return boqItemGroupCode7Level6Code;
			}
			set
			{
				this.boqItemGroupCode7Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level7Code
		{
			get
			{
				return boqItemGroupCode7Level7Code;
			}
			set
			{
				this.boqItemGroupCode7Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level8Code
		{
			get
			{
				return boqItemGroupCode7Level8Code;
			}
			set
			{
				this.boqItemGroupCode7Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level9Code
		{
			get
			{
				return boqItemGroupCode7Level9Code;
			}
			set
			{
				this.boqItemGroupCode7Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode7Level6Title
		{
			get
			{
				return boqItemGroupCode7Level6Title;
			}
			set
			{
				this.boqItemGroupCode7Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level7Title
		{
			get
			{
				return boqItemGroupCode7Level7Title;
			}
			set
			{
				this.boqItemGroupCode7Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level8Title
		{
			get
			{
				return boqItemGroupCode7Level8Title;
			}
			set
			{
				this.boqItemGroupCode7Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level9Title
		{
			get
			{
				return boqItemGroupCode7Level9Title;
			}
			set
			{
				this.boqItemGroupCode7Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode7Level6Description
		{
			get
			{
				return boqItemGroupCode7Level6Description;
			}
			set
			{
				this.boqItemGroupCode7Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level7Description
		{
			get
			{
				return boqItemGroupCode7Level7Description;
			}
			set
			{
				this.boqItemGroupCode7Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level8Description
		{
			get
			{
				return boqItemGroupCode7Level8Description;
			}
			set
			{
				this.boqItemGroupCode7Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level9Description
		{
			get
			{
				return boqItemGroupCode7Level9Description;
			}
			set
			{
				this.boqItemGroupCode7Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode7Level6Unit
		{
			get
			{
				return boqItemGroupCode7Level6Unit;
			}
			set
			{
				this.boqItemGroupCode7Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level7Unit
		{
			get
			{
				return boqItemGroupCode7Level7Unit;
			}
			set
			{
				this.boqItemGroupCode7Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level8Unit
		{
			get
			{
				return boqItemGroupCode7Level8Unit;
			}
			set
			{
				this.boqItemGroupCode7Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode7Level9Unit
		{
			get
			{
				return boqItemGroupCode7Level9Unit;
			}
			set
			{
				this.boqItemGroupCode7Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level6Code
		{
			get
			{
				return boqItemGroupCode8Level6Code;
			}
			set
			{
				this.boqItemGroupCode8Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level7Code
		{
			get
			{
				return boqItemGroupCode8Level7Code;
			}
			set
			{
				this.boqItemGroupCode8Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level8Code
		{
			get
			{
				return boqItemGroupCode8Level8Code;
			}
			set
			{
				this.boqItemGroupCode8Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level9Code
		{
			get
			{
				return boqItemGroupCode8Level9Code;
			}
			set
			{
				this.boqItemGroupCode8Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode8Level6Title
		{
			get
			{
				return boqItemGroupCode8Level6Title;
			}
			set
			{
				this.boqItemGroupCode8Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level7Title
		{
			get
			{
				return boqItemGroupCode8Level7Title;
			}
			set
			{
				this.boqItemGroupCode8Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level8Title
		{
			get
			{
				return boqItemGroupCode8Level8Title;
			}
			set
			{
				this.boqItemGroupCode8Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level9Title
		{
			get
			{
				return boqItemGroupCode8Level9Title;
			}
			set
			{
				this.boqItemGroupCode8Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode8Level6Description
		{
			get
			{
				return boqItemGroupCode8Level6Description;
			}
			set
			{
				this.boqItemGroupCode8Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level7Description
		{
			get
			{
				return boqItemGroupCode8Level7Description;
			}
			set
			{
				this.boqItemGroupCode8Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level8Description
		{
			get
			{
				return boqItemGroupCode8Level8Description;
			}
			set
			{
				this.boqItemGroupCode8Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level9Description
		{
			get
			{
				return boqItemGroupCode8Level9Description;
			}
			set
			{
				this.boqItemGroupCode8Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode8Level6Unit
		{
			get
			{
				return boqItemGroupCode8Level6Unit;
			}
			set
			{
				this.boqItemGroupCode8Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level7Unit
		{
			get
			{
				return boqItemGroupCode8Level7Unit;
			}
			set
			{
				this.boqItemGroupCode8Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level8Unit
		{
			get
			{
				return boqItemGroupCode8Level8Unit;
			}
			set
			{
				this.boqItemGroupCode8Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode8Level9Unit
		{
			get
			{
				return boqItemGroupCode8Level9Unit;
			}
			set
			{
				this.boqItemGroupCode8Level9Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level6Code
		{
			get
			{
				return boqItemGroupCode9Level6Code;
			}
			set
			{
				this.boqItemGroupCode9Level6Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level7Code
		{
			get
			{
				return boqItemGroupCode9Level7Code;
			}
			set
			{
				this.boqItemGroupCode9Level7Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level8Code
		{
			get
			{
				return boqItemGroupCode9Level8Code;
			}
			set
			{
				this.boqItemGroupCode9Level8Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level9Code
		{
			get
			{
				return boqItemGroupCode9Level9Code;
			}
			set
			{
				this.boqItemGroupCode9Level9Code = value;
			}
		}
		public virtual string BoqItemGroupCode9Level6Title
		{
			get
			{
				return boqItemGroupCode9Level6Title;
			}
			set
			{
				this.boqItemGroupCode9Level6Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level7Title
		{
			get
			{
				return boqItemGroupCode9Level7Title;
			}
			set
			{
				this.boqItemGroupCode9Level7Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level8Title
		{
			get
			{
				return boqItemGroupCode9Level8Title;
			}
			set
			{
				this.boqItemGroupCode9Level8Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level9Title
		{
			get
			{
				return boqItemGroupCode9Level9Title;
			}
			set
			{
				this.boqItemGroupCode9Level9Title = value;
			}
		}
		public virtual string BoqItemGroupCode9Level6Description
		{
			get
			{
				return boqItemGroupCode9Level6Description;
			}
			set
			{
				this.boqItemGroupCode9Level6Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level7Description
		{
			get
			{
				return boqItemGroupCode9Level7Description;
			}
			set
			{
				this.boqItemGroupCode9Level7Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level8Description
		{
			get
			{
				return boqItemGroupCode9Level8Description;
			}
			set
			{
				this.boqItemGroupCode9Level8Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level9Description
		{
			get
			{
				return boqItemGroupCode9Level9Description;
			}
			set
			{
				this.boqItemGroupCode9Level9Description = value;
			}
		}
		public virtual string BoqItemGroupCode9Level6Unit
		{
			get
			{
				return boqItemGroupCode9Level6Unit;
			}
			set
			{
				this.boqItemGroupCode9Level6Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level7Unit
		{
			get
			{
				return boqItemGroupCode9Level7Unit;
			}
			set
			{
				this.boqItemGroupCode9Level7Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level8Unit
		{
			get
			{
				return boqItemGroupCode9Level8Unit;
			}
			set
			{
				this.boqItemGroupCode9Level8Unit = value;
			}
		}
		public virtual string BoqItemGroupCode9Level9Unit
		{
			get
			{
				return boqItemGroupCode9Level9Unit;
			}
			set
			{
				this.boqItemGroupCode9Level9Unit = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode1Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode1Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode1Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode2Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode2Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode2Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode3Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode3Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode3Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode4Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode4Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode4Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode5Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode5Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode5Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode6Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode6Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode6Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode7Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode7Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode7Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode8Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode8Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode8Level9UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level1UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level1UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level1UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level2UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level2UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level2UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level3UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level3UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level3UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level4UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level4UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level4UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level5UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level5UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level5UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level6UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level6UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level6UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level7UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level7UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level7UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level8UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level8UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level8UnitFactor = value;
			}
		}
		public virtual decimal BoqItemGroupCode9Level9UnitFactor
		{
			get
			{
				return boqItemGroupCode9Level9UnitFactor;
			}
			set
			{
				this.boqItemGroupCode9Level9UnitFactor = value;
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
		public virtual string BoqItemWbsCode1Level1Unit
		{
			get
			{
				return boqItemWbsCode1Level1Unit;
			}
			set
			{
				this.boqItemWbsCode1Level1Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level2Unit
		{
			get
			{
				return boqItemWbsCode1Level2Unit;
			}
			set
			{
				this.boqItemWbsCode1Level2Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level3Unit
		{
			get
			{
				return boqItemWbsCode1Level3Unit;
			}
			set
			{
				this.boqItemWbsCode1Level3Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level4Unit
		{
			get
			{
				return boqItemWbsCode1Level4Unit;
			}
			set
			{
				this.boqItemWbsCode1Level4Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5Unit
		{
			get
			{
				return boqItemWbsCode1Level5Unit;
			}
			set
			{
				this.boqItemWbsCode1Level5Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level6Unit
		{
			get
			{
				return boqItemWbsCode1Level6Unit;
			}
			set
			{
				this.boqItemWbsCode1Level6Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level7Unit
		{
			get
			{
				return boqItemWbsCode1Level7Unit;
			}
			set
			{
				this.boqItemWbsCode1Level7Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level8Unit
		{
			get
			{
				return boqItemWbsCode1Level8Unit;
			}
			set
			{
				this.boqItemWbsCode1Level8Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level9Unit
		{
			get
			{
				return boqItemWbsCode1Level9Unit;
			}
			set
			{
				this.boqItemWbsCode1Level9Unit = value;
			}
		}
		public virtual string BoqItemWbsCode1Level1Quantity
		{
			get
			{
				return boqItemWbsCode1Level1Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level1Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level2Quantity
		{
			get
			{
				return boqItemWbsCode1Level2Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level2Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level3Quantity
		{
			get
			{
				return boqItemWbsCode1Level3Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level3Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level4Quantity
		{
			get
			{
				return boqItemWbsCode1Level4Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level4Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level5Quantity
		{
			get
			{
				return boqItemWbsCode1Level5Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level5Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level6Quantity
		{
			get
			{
				return boqItemWbsCode1Level6Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level6Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level7Quantity
		{
			get
			{
				return boqItemWbsCode1Level7Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level7Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level8Quantity
		{
			get
			{
				return boqItemWbsCode1Level8Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level8Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode1Level9Quantity
		{
			get
			{
				return boqItemWbsCode1Level9Quantity;
			}
			set
			{
				this.boqItemWbsCode1Level9Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level1Unit
		{
			get
			{
				return boqItemWbsCode2Level1Unit;
			}
			set
			{
				this.boqItemWbsCode2Level1Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level2Unit
		{
			get
			{
				return boqItemWbsCode2Level2Unit;
			}
			set
			{
				this.boqItemWbsCode2Level2Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level3Unit
		{
			get
			{
				return boqItemWbsCode2Level3Unit;
			}
			set
			{
				this.boqItemWbsCode2Level3Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level4Unit
		{
			get
			{
				return boqItemWbsCode2Level4Unit;
			}
			set
			{
				this.boqItemWbsCode2Level4Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5Unit
		{
			get
			{
				return boqItemWbsCode2Level5Unit;
			}
			set
			{
				this.boqItemWbsCode2Level5Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level6Unit
		{
			get
			{
				return boqItemWbsCode2Level6Unit;
			}
			set
			{
				this.boqItemWbsCode2Level6Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level7Unit
		{
			get
			{
				return boqItemWbsCode2Level7Unit;
			}
			set
			{
				this.boqItemWbsCode2Level7Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level8Unit
		{
			get
			{
				return boqItemWbsCode2Level8Unit;
			}
			set
			{
				this.boqItemWbsCode2Level8Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level9Unit
		{
			get
			{
				return boqItemWbsCode2Level9Unit;
			}
			set
			{
				this.boqItemWbsCode2Level9Unit = value;
			}
		}
		public virtual string BoqItemWbsCode2Level1Quantity
		{
			get
			{
				return boqItemWbsCode2Level1Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level1Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level2Quantity
		{
			get
			{
				return boqItemWbsCode2Level2Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level2Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level3Quantity
		{
			get
			{
				return boqItemWbsCode2Level3Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level3Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level4Quantity
		{
			get
			{
				return boqItemWbsCode2Level4Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level4Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level5Quantity
		{
			get
			{
				return boqItemWbsCode2Level5Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level5Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level6Quantity
		{
			get
			{
				return boqItemWbsCode2Level6Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level6Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level7Quantity
		{
			get
			{
				return boqItemWbsCode2Level7Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level7Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level8Quantity
		{
			get
			{
				return boqItemWbsCode2Level8Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level8Quantity = value;
			}
		}
		public virtual string BoqItemWbsCode2Level9Quantity
		{
			get
			{
				return boqItemWbsCode2Level9Quantity;
			}
			set
			{
				this.boqItemWbsCode2Level9Quantity = value;
			}
		}
	}

}