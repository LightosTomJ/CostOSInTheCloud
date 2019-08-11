

CREATE PROCEDURE dbo.usp_dyn_find_boq_item_sql
@PrjId BIGINT,
@wbs1 bit = 0,
@wbs2 bit =0 ,
@groupCode1 bit =0 ,
@groupCode2 bit =0 ,
@groupCode3 bit =0,
@groupCode4 bit =0 ,
@groupCode5 bit =0,
@groupCode6 bit =0 ,
@groupCode7 bit =0,
@groupCode8 bit =0,
@groupCode9 bit =0,
@SqlQuery nvarchar(max) ='' OUTPUT 
AS	

DECLARE @Dbname nvarchar(max)
DECLARE @MainPart NVARCHAR(MAX)
DECLARE @Wbs1Part NVARCHAR(MAX)
DECLARE @Wbs2Part NVARCHAR(MAX)
DECLARE @GRoupCode1Part NVARCHAR(MAX)
DECLARE @GRoupCode2Part NVARCHAR(MAX)
DECLARE @GRoupCode3Part NVARCHAR(MAX)
DECLARE @GRoupCode4Part NVARCHAR(MAX)
DECLARE @GRoupCode5Part NVARCHAR(MAX)
DECLARE @GRoupCode6Part NVARCHAR(MAX)
DECLARE @GRoupCode7Part NVARCHAR(MAX)
DECLARE @GRoupCode8Part NVARCHAR(MAX)
DECLARE @GRoupCode9Part NVARCHAR(MAX)

DECLARE @Wbs1PartOuterApply NVARCHAR(MAX)
DECLARE @Wbs2PartOuterApply NVARCHAR(MAX)
DECLARE @GRoupCode1PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode2PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode3PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode4PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode5PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode6PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode7PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode8PartCrossApply NVARCHAR(MAX)
DECLARE @GRoupCode9PartCrossApply NVARCHAR(MAX)
BEGIN

SELECT @Dbname = DBNAME
  FROM PROJECTURL
 WHERE PROJECTURLID = @PrjId;

SET @MainPart='
SELECT 
k.projectCode as projectCode, 
k.projectName as projectName, 
k.projectEPS as projectEPS, 
k.projectCurrency as projectCurrency, 
k.projectCountry as projectCountry, 
k.projectClientName as projectClientName, 
k.projectClientBudget as projectClientBudget,
k.projectJobSize as projectJobSize,
k.projectUnit as projectUnit,
k.projectBasementSize as projectBasementSize,
k.projectDuration as projectDuration,
o.BOQITEMID AS boqitemId,
o.CODE AS boqItemCode,
o.TITLE AS boqItemTitle,
o.PARAMITEMID as boqItemAssemblyId,
o.PARAMCODE as boqItemAssemblyTitle,
o.EDITORID AS boqItemEditorId,
o.CREATEUSERID AS boqItemCreateUserId,
o.ESTIMATOR AS boqItemEstimator,
o.PAYMENT_DATE AS boqItemPaymentDate,
o.LAST_UPDATE AS boqItemLastUpdate,
o.CREATE_DATE AS boqItemCreateDate,
o.STATUS AS boqItemStatus,
o.ACCURACY AS boqItemAccuracy,
o.FLAG AS boqItemFlag,
o.LOCCOUNTRY AS boqItemLocalizationCountry,
o.LOCSTATE AS boqItemLocalizationState,
o.LOCFAC AS boqItemLocalizationFactor,
o.QUANTITY AS boqItemQuantity1,
o.SECQUANTITY AS boqItemQuantity2,
o.ESTQUANT AS  boqItemEstimatedQuantity,
o.MEASQUANT AS boqItemTakeoffQuantity,
o.QUANTLOSS AS boqItemQuantityLoss,
o.CNQT AS boqItemConditionQT,
o.HAS_PRODUCTIVITY AS boqItemHasProductivity,
o.ACTBASED as boqItemActivityBased,
o.DURATION AS boqItemDuration,
o.PRODUCTIVITY AS boqItemProductivity,
o.PRODFACTOR AS boqItemProductivityFactor,
o.ADJPROD AS boqItemAdjustedProductivity,
o.MANHOURS AS boqItemTotalManHours,
o.UNITMHOURS AS boqItemUnitManHours,
o.MHOURSFACTOR AS boqItemUnitManHoursFactor,
o.AUNITMHOURS AS boqItemAdjustedUnitManHours,
o.EQUHOURS as boqItemEquipmentHours,
(CASE WHEN ua1.TOUNIT IS NULL THEN o.UNIT ELSE ua1.TOUNIT END) as boqItemUnit1,
(CASE WHEN ua2.TOUNIT IS NULL THEN o.SECOND_UNIT ELSE ua2.TOUNIT END) as boqItemUnit2,
o.UNITS_DIV AS boqItemUnitDivider,
o.ASSRATE AS boqItemLineItemRate,
o.ASRT AS boqItemLineItemRT,
o.EQURATE AS boqItemEquipmentRate,
o.EQRT AS boqItemEquipmentRT,
o.SUBRATE AS boqItemSubcontractorRate,
o.SUBQUOTERATE AS boqItemSubcontractorQuotedRate,
o.SBRT AS boqItemSubcontractorRateRT,
o.LABRATE AS boqItemLaborRate,
o.LBRT AS boqItemLaborRT,
o.MATRATE AS boqItemMaterialRate,
o.MATQUOTERATE AS boqItemMaterialQuotedRate,
o.MART AS boqItemMaterialRateRT,
o.CONRATE AS boqItemConsumableRate,
o.CMRT AS boqItemConsumableRateRT,
o.FABRATE AS boqItemFabricationRate,
o.SHIPRATE AS boqItemShipmentRate,
o.RATE AS boqItemTotalRate1,
o.SECRATE AS boqItemTotalRate2,
o.PUBLISHEDRATE AS boqItemPublishedRate,
o.OFFRATE AS boqItemOfferedRate1,
o.OFFSECRATE AS boqItemOfferedRate2,
o.ASSCOST AS boqItemLineItemCost,
o.EQUCOST AS boqItemEquipmentCost,
o.SUBCOST AS boqItemSubcontractorCost,
o.LABCOST AS boqItemLaborCost,
o.MATCOST AS boqItemMaterialCost,
o.CONCOST AS boqItemConsumableCost,
o.FABCOST AS boqItemFabricationCost,
o.SHIPCOST AS boqItemShipmentCost,
o.MATRESCOST AS boqItemMaterialResourcesCost,
o.TOTALCOST AS boqItemTotalCost,
o.OFFPRICE AS boqItemOfferedPrice,
o.MARKUP AS boqItemMarkup,
o.ESCALATION AS boqItemEscalation,
o.AWDMAT AS boqItemAwardedMaterialRate,
o.AWDINS AS boqItemAwardedInsuranceRate,
o.AWDSUB AS boqItemAwardedSubcontractorRate,
o.AWDMHOURS AS boqItemAwardedManhours,
o.AWDIND AS boqItemAwardedIndirectRate,
o.AWDSHIP AS boqItemAwardedShipmentRate,
o.AWDTOTAL AS boqItemAwardedTotalRate,
o.CUSTXT1 AS boqItemCustomText1,
o.CUSTXT2 AS boqItemCustomText2,
o.CUSTXT3 AS boqItemCustomText3,
o.CUSTXT4 AS boqItemCustomText4,
o.CUSTXT5 AS boqItemCustomText5,
o.CUSTXT6 AS boqItemCustomText6,
o.CUSTXT7 AS boqItemCustomText7,
o.CUSTXT8 AS boqItemCustomText8,
o.CUSTXT9 AS boqItemCustomText9,
o.CUSTXT10 AS boqItemCustomText10,
o.CUSTXT11 AS boqItemCustomText11,
o.CUSTXT12 AS boqItemCustomText12,
o.CUSTXT13 AS boqItemCustomText13,
o.CUSTXT14 AS boqItemCustomText14,
o.CUSTXT15 AS boqItemCustomText15,
o.CUSTXT16 AS boqItemCustomText16,
o.CUSTXT17 AS boqItemCustomText17,
o.CUSTXT18 AS boqItemCustomText18,
o.CUSTXT19 AS boqItemCustomText19,
o.CUSTXT20 AS boqItemCustomText20,
o.CUSRATE1 AS boqItemCustomDecimal1,
o.CUSRATE2 AS boqItemCustomDecimal2,
o.CUSRATE3 AS boqItemCustomDecimal3,
o.CUSRATE4 AS boqItemCustomDecimal4,
o.CUSRATE5 AS boqItemCustomDecimal5,
o.CUSRATE6 AS boqItemCustomDecimal6,
o.CUSRATE7 AS boqItemCustomDecimal7,
o.CUSRATE8 AS boqItemCustomDecimal8,
o.CUSRATE9 AS boqItemCustomDecimal9,
o.CUSRATE10 AS boqItemCustomDecimal10,
o.CUSRATE11 AS boqItemCustomDecimal11,
o.CUSRATE12 AS boqItemCustomDecimal12,
o.CUSRATE13 AS boqItemCustomDecimal13,
o.CUSRATE14 AS boqItemCustomDecimal14,
o.CUSRATE15 AS boqItemCustomDecimal15,
o.CUSCUMRATE1 AS boqItemCustomCumDecimal1,
o.CUSCUMRATE2 AS boqItemCustomCumDecimal2,
o.CUSCUMRATE3 AS boqItemCustomCumDecimal3,
o.CUSCUMRATE4 AS boqItemCustomCumDecimal4,
o.CUSCUMRATE5 AS boqItemCustomCumDecimal5,
o.CUSCUMRATE6 AS boqItemCustomCumDecimal6,
o.CUSCUMRATE7 AS boqItemCustomCumDecimal7,
o.CUSCUMRATE8 AS boqItemCustomCumDecimal8,
o.CUSCUMRATE9 AS boqItemCustomCumDecimal9,
o.CUSCUMRATE10 AS boqItemCustomCumDecimal10,
o.PUGRCFACTOR AS boqItemPuGroupCode1Factor,
o.PUGEKFACTOR AS boqItemPuGroupCode2Factor,
o.PUEX1FACTOR AS boqItemPuGroupCode3Factor,
o.PUEX2FACTOR AS boqItemPuGroupCode4Factor,
o.PUEX3FACTOR AS boqItemPuGroupCode5Factor,
o.PUEX4FACTOR AS boqItemPuGroupCode6Factor,
o.PUEX5FACTOR AS boqItemPuGroupCode7Factor,
o.PUEX6FACTOR AS boqItemPuGroupCode8Factor,
o.PUEX7FACTOR AS boqItemPuGroupCode9Factor,
o.CUSPER1 AS boqItemCustomPercentange1,
o.CUSPER2 AS boqItemCustomPercentange2,
o.CUSPER3 AS boqItemCustomPercentange3,
o.CUSPER4 AS boqItemCustomPercentange4,
o.CUSPER5 AS boqItemCustomPercentange5,
o.CUSPER6 AS boqItemCustomPercentange6,
o.CUSPER7 AS boqItemCustomPercentange7,
o.CUSPER8 AS boqItemCustomPercentange8,
o.CUSPER9 AS boqItemCustomPercentange9,
o.CUSPER10 AS boqItemCustomPercentange10,
o.PUBLISHEDITEMCODE AS boqItemPublishedItemCode,
o.PUBLISHEDREVISIONCODE AS boqItemPublishedRevisionCode,
'

IF @wbs1=1
		SET @Wbs1Part ='
	WBSCODE1DATA.CODE1 AS boqItemWbsCode1Level1Code,
	WBSCODE1DATA.CODE2 AS boqItemWbsCode1Level2Code,
	WBSCODE1DATA.CODE3 AS boqItemWbsCode1Level3Code,
	WBSCODE1DATA.CODE4 AS boqItemWbsCode1Level4Code,
	WBSCODE1DATA.CODE5 AS boqItemWbsCode1Level5Code,
	WBSCODE1DATA.CODE6 AS boqItemWbsCode1Level6Code,
	WBSCODE1DATA.CODE7 AS boqItemWbsCode1Level7Code,
	WBSCODE1DATA.CODE8 AS boqItemWbsCode1Level8Code,
	WBSCODE1DATA.CODE9 AS boqItemWbsCode1Level9Code,
	WBSCODE1DATA.ITEMCODE1 AS boqItemWbsCode1Level1ItemCode,
	WBSCODE1DATA.ITEMCODE2 AS boqItemWbsCode1Level2ItemCode,
	WBSCODE1DATA.ITEMCODE3 AS boqItemWbsCode1Level3ItemCode,
	WBSCODE1DATA.ITEMCODE4 AS boqItemWbsCode1Level4ItemCode,
	WBSCODE1DATA.ITEMCODE5 AS boqItemWbsCode1Level5ItemCode,
	WBSCODE1DATA.ITEMCODE6 AS boqItemWbsCode1Level6ItemCode,
	WBSCODE1DATA.ITEMCODE7 AS boqItemWbsCode1Level7ItemCode,
	WBSCODE1DATA.ITEMCODE8 AS boqItemWbsCode1Level8ItemCode,
	WBSCODE1DATA.ITEMCODE9 AS boqItemWbsCode1Level9ItemCode,
	WBSCODE1DATA.TITLE1 AS boqItemWbsCode1Level1Title,
	WBSCODE1DATA.TITLE2 AS boqItemWbsCode1Level2Title,
	WBSCODE1DATA.TITLE3 AS boqItemWbsCode1Level3Title,
	WBSCODE1DATA.TITLE4 AS boqItemWbsCode1Level4Title,
	WBSCODE1DATA.TITLE5 AS boqItemWbsCode1Level5Title,
	WBSCODE1DATA.TITLE6 AS boqItemWbsCode1Level6Title,
	WBSCODE1DATA.TITLE7 AS boqItemWbsCode1Level7Title,
	WBSCODE1DATA.TITLE8 AS boqItemWbsCode1Level8Title,
	WBSCODE1DATA.TITLE9 AS boqItemWbsCode1Level9Title,
	WBSCODE1DATA.UNIT1 AS boqItemWbsCode1Level1Unit,
	WBSCODE1DATA.UNIT2 AS boqItemWbsCode1Level2Unit,
	WBSCODE1DATA.UNIT3 AS boqItemWbsCode1Level3Unit,
	WBSCODE1DATA.UNIT4 AS boqItemWbsCode1Level4Unit,
	WBSCODE1DATA.UNIT5 AS boqItemWbsCode1Level5Unit,
	WBSCODE1DATA.UNIT6 AS boqItemWbsCode1Level6Unit,
	WBSCODE1DATA.UNIT7 AS boqItemWbsCode1Level7Unit,
	WBSCODE1DATA.UNIT8 AS boqItemWbsCode1Level8Unit,
	WBSCODE1DATA.UNIT9 AS boqItemWbsCode1Level9Unit,
	WBSCODE1DATA.QUANTITY1 AS boqItemWbsCode1Level1Quantity,
	WBSCODE1DATA.QUANTITY2 AS boqItemWbsCode1Level2Quantity,
	WBSCODE1DATA.QUANTITY3 AS boqItemWbsCode1Level3Quantity,
	WBSCODE1DATA.QUANTITY4 AS boqItemWbsCode1Level4Quantity,
	WBSCODE1DATA.QUANTITY5 AS boqItemWbsCode1Level5Quantity,
	WBSCODE1DATA.QUANTITY6 AS boqItemWbsCode1Level6Quantity,
	WBSCODE1DATA.QUANTITY7 AS boqItemWbsCode1Level7Quantity,
	WBSCODE1DATA.QUANTITY8 AS boqItemWbsCode1Level8Quantity,
	WBSCODE1DATA.QUANTITY9 AS boqItemWbsCode1Level9Quantity,
	WBSCODE1DATA.DESCRIPTION1 AS boqItemWbsCode1Level1Description,
	WBSCODE1DATA.DESCRIPTION2 AS boqItemWbsCode1Level2Description,
	WBSCODE1DATA.DESCRIPTION3 AS boqItemWbsCode1Level3Description,
	WBSCODE1DATA.DESCRIPTION4 AS boqItemWbsCode1Level4Description,
	WBSCODE1DATA.DESCRIPTION5 AS boqItemWbsCode1Level5Description,
	WBSCODE1DATA.DESCRIPTION6 AS boqItemWbsCode1Level6Description,
	WBSCODE1DATA.DESCRIPTION7 AS boqItemWbsCode1Level7Description,
	WBSCODE1DATA.DESCRIPTION8 AS boqItemWbsCode1Level8Description,
	WBSCODE1DATA.DESCRIPTION9 AS boqItemWbsCode1Level9Description,'
	ELSE
		SET @Wbs1Part =''
IF @wbs2 =1
		SET @Wbs2Part ='
	WBSCODE2DATA.CODE1 AS boqItemWbsCode2Level1Code,
	WBSCODE2DATA.CODE2 AS boqItemWbsCode2Level2Code,
	WBSCODE2DATA.CODE3 AS boqItemWbsCode2Level3Code,
	WBSCODE2DATA.CODE4 AS boqItemWbsCode2Level4Code,
	WBSCODE2DATA.CODE5 AS boqItemWbsCode2Level5Code,
	WBSCODE2DATA.CODE6 AS boqItemWbsCode2Level6Code,
	WBSCODE2DATA.CODE7 AS boqItemWbsCode2Level7Code,
	WBSCODE2DATA.CODE8 AS boqItemWbsCode2Level8Code,
	WBSCODE2DATA.CODE9 AS boqItemWbsCode2Level9Code,
	WBSCODE2DATA.ITEMCODE1 AS boqItemWbsCode2Level1ItemCode,
	WBSCODE2DATA.ITEMCODE2 AS boqItemWbsCode2Level2ItemCode,
	WBSCODE2DATA.ITEMCODE3 AS boqItemWbsCode2Level3ItemCode,
	WBSCODE2DATA.ITEMCODE4 AS boqItemWbsCode2Level4ItemCode,
	WBSCODE2DATA.ITEMCODE5 AS boqItemWbsCode2Level5ItemCode,
	WBSCODE2DATA.ITEMCODE6 AS boqItemWbsCode2Level6ItemCode,
	WBSCODE2DATA.ITEMCODE7 AS boqItemWbsCode2Level7ItemCode,
	WBSCODE2DATA.ITEMCODE8 AS boqItemWbsCode2Level8ItemCode,
	WBSCODE2DATA.ITEMCODE9 AS boqItemWbsCode2Level9ItemCode,
	WBSCODE2DATA.TITLE1 AS boqItemWbsCode2Level1Title,
	WBSCODE2DATA.TITLE2 AS boqItemWbsCode2Level2Title,
	WBSCODE2DATA.TITLE3 AS boqItemWbsCode2Level3Title,
	WBSCODE2DATA.TITLE4 AS boqItemWbsCode2Level4Title,
	WBSCODE2DATA.TITLE5 AS boqItemWbsCode2Level5Title,
	WBSCODE2DATA.TITLE6 AS boqItemWbsCode2Level6Title,
	WBSCODE2DATA.TITLE7 AS boqItemWbsCode2Level7Title,
	WBSCODE2DATA.TITLE8 AS boqItemWbsCode2Level8Title,
	WBSCODE2DATA.TITLE9 AS boqItemWbsCode2Level9Title,
	WBSCODE2DATA.UNIT1 AS boqItemWbsCode2Level1Unit,
	WBSCODE2DATA.UNIT2 AS boqItemWbsCode2Level2Unit,
	WBSCODE2DATA.UNIT3 AS boqItemWbsCode2Level3Unit,
	WBSCODE2DATA.UNIT4 AS boqItemWbsCode2Level4Unit,
	WBSCODE2DATA.UNIT5 AS boqItemWbsCode2Level5Unit,
	WBSCODE2DATA.UNIT6 AS boqItemWbsCode2Level6Unit,
	WBSCODE2DATA.UNIT7 AS boqItemWbsCode2Level7Unit,
	WBSCODE2DATA.UNIT8 AS boqItemWbsCode2Level8Unit,
	WBSCODE2DATA.UNIT9 AS boqItemWbsCode2Level9Unit,
	WBSCODE2DATA.QUANTITY1 AS boqItemWbsCode2Level1Quantity,
	WBSCODE2DATA.QUANTITY2 AS boqItemWbsCode2Level2Quantity,
	WBSCODE2DATA.QUANTITY3 AS boqItemWbsCode2Level3Quantity,
	WBSCODE2DATA.QUANTITY4 AS boqItemWbsCode2Level4Quantity,
	WBSCODE2DATA.QUANTITY5 AS boqItemWbsCode2Level5Quantity,
	WBSCODE2DATA.QUANTITY6 AS boqItemWbsCode2Level6Quantity,
	WBSCODE2DATA.QUANTITY7 AS boqItemWbsCode2Level7Quantity,
	WBSCODE2DATA.QUANTITY8 AS boqItemWbsCode2Level8Quantity,
	WBSCODE2DATA.QUANTITY9 AS boqItemWbsCode2Level9Quantity,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level1Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level2Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level3Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level4Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level5Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level6Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level7Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level8Description,
	WBSCODE2DATA.DESCRIPTION3 AS boqItemWbsCode2Level9Description,'
ELSE
SET @Wbs2Part =''
IF @groupCode1 =1	
SET @GRoupCode1Part ='
GROUPCODE1DATA.CODE1 AS boqItemGroupCode1Level1Code,
GROUPCODE1DATA.CODE2 AS boqItemGroupCode1Level2Code,
GROUPCODE1DATA.CODE3 AS boqItemGroupCode1Level3Code,
GROUPCODE1DATA.CODE4 AS boqItemGroupCode1Level4Code,
GROUPCODE1DATA.CODE5 AS boqItemGroupCode1Level5Code,
GROUPCODE1DATA.CODE6 AS boqItemGroupCode1Level6Code,
GROUPCODE1DATA.CODE7 AS boqItemGroupCode1Level7Code,
GROUPCODE1DATA.CODE8 AS boqItemGroupCode1Level8Code,
GROUPCODE1DATA.CODE9 AS boqItemGroupCode1Level9Code,
GROUPCODE1DATA.TITLE1 AS boqItemGroupCode1Level1Title,
GROUPCODE1DATA.TITLE2 AS boqItemGroupCode1Level2Title,
GROUPCODE1DATA.TITLE3 AS boqItemGroupCode1Level3Title,
GROUPCODE1DATA.TITLE4 AS boqItemGroupCode1Level4Title,
GROUPCODE1DATA.TITLE5 AS boqItemGroupCode1Level5Title,
GROUPCODE1DATA.TITLE6 AS boqItemGroupCode1Level6Title,
GROUPCODE1DATA.TITLE7 AS boqItemGroupCode1Level7Title,
GROUPCODE1DATA.TITLE8 AS boqItemGroupCode1Level8Title,
GROUPCODE1DATA.TITLE9 AS boqItemGroupCode1Level9Title,
GROUPCODE1DATA.UNIT1 AS boqItemGroupCode1Level1Unit,
GROUPCODE1DATA.UNIT2 AS boqItemGroupCode1Level2Unit,
GROUPCODE1DATA.UNIT3 AS boqItemGroupCode1Level3Unit,
GROUPCODE1DATA.UNIT4 AS boqItemGroupCode1Level4Unit,
GROUPCODE1DATA.UNIT5 AS boqItemGroupCode1Level5Unit,
GROUPCODE1DATA.UNIT6 AS boqItemGroupCode1Level6Unit,
GROUPCODE1DATA.UNIT7 AS boqItemGroupCode1Level7Unit,
GROUPCODE1DATA.UNIT8 AS boqItemGroupCode1Level8Unit,
GROUPCODE1DATA.UNIT9 AS boqItemGroupCode1Level9Unit,
GROUPCODE1DATA.UFACT1 AS boqItemGroupCode1Level1UnitFactor,
GROUPCODE1DATA.UFACT2 AS boqItemGroupCode1Level2UnitFactor,
GROUPCODE1DATA.UFACT3 AS boqItemGroupCode1Level3UnitFactor,
GROUPCODE1DATA.UFACT4 AS boqItemGroupCode1Level4UnitFactor,
GROUPCODE1DATA.UFACT5 AS boqItemGroupCode1Level5UnitFactor,
GROUPCODE1DATA.UFACT6 AS boqItemGroupCode1Level6UnitFactor,
GROUPCODE1DATA.UFACT7 AS boqItemGroupCode1Level7UnitFactor,
GROUPCODE1DATA.UFACT8 AS boqItemGroupCode1Level8UnitFactor,
GROUPCODE1DATA.UFACT9 AS boqItemGroupCode1Level9UnitFactor,
GROUPCODE1DATA.NOTES1 AS boqItemGroupCode1Level1Notes,
GROUPCODE1DATA.NOTES2 AS boqItemGroupCode1Level2Notes,
GROUPCODE1DATA.NOTES3 AS boqItemGroupCode1Level3Notes,
GROUPCODE1DATA.NOTES4 AS boqItemGroupCode1Level4Notes,
GROUPCODE1DATA.NOTES5 AS boqItemGroupCode1Level5Notes,
GROUPCODE1DATA.NOTES6 AS boqItemGroupCode1Level6Notes,
GROUPCODE1DATA.NOTES7 AS boqItemGroupCode1Level7Notes,
GROUPCODE1DATA.NOTES8 AS boqItemGroupCode1Level8Notes,
GROUPCODE1DATA.NOTES9 AS boqItemGroupCode1Level9Notes,
GROUPCODE1DATA.DESCRIPTION1 AS boqItemGroupCode1Level1Description,
GROUPCODE1DATA.DESCRIPTION2 AS boqItemGroupCode1Level2Description,
GROUPCODE1DATA.DESCRIPTION3 AS boqItemGroupCode1Level3Description,
GROUPCODE1DATA.DESCRIPTION4 AS boqItemGroupCode1Level4Description,
GROUPCODE1DATA.DESCRIPTION5 AS boqItemGroupCode1Level5Description,
GROUPCODE1DATA.DESCRIPTION6 AS boqItemGroupCode1Level6Description,
GROUPCODE1DATA.DESCRIPTION7 AS boqItemGroupCode1Level7Description,
GROUPCODE1DATA.DESCRIPTION8 AS boqItemGroupCode1Level8Description,
GROUPCODE1DATA.DESCRIPTION9 AS boqItemGroupCode1Level9Description,'
ELSE
SET @GRoupCode1Part =''
IF @groupCode2 =1
SET @GRoupCode2Part ='
GROUPCODE2DATA.CODE1 AS boqItemGroupCode2Level1Code,
GROUPCODE2DATA.CODE2 AS boqItemGroupCode2Level2Code,
GROUPCODE2DATA.CODE3 AS boqItemGroupCode2Level3Code,
GROUPCODE2DATA.CODE4 AS boqItemGroupCode2Level4Code,
GROUPCODE2DATA.CODE5 AS boqItemGroupCode2Level5Code,
GROUPCODE2DATA.CODE6 AS boqItemGroupCode2Level6Code,
GROUPCODE2DATA.CODE7 AS boqItemGroupCode2Level7Code,
GROUPCODE2DATA.CODE8 AS boqItemGroupCode2Level8Code,
GROUPCODE2DATA.CODE9 AS boqItemGroupCode2Level9Code,
GROUPCODE2DATA.TITLE1 AS boqItemGroupCode2Level1Title,
GROUPCODE2DATA.TITLE2 AS boqItemGroupCode2Level2Title,
GROUPCODE2DATA.TITLE3 AS boqItemGroupCode2Level3Title,
GROUPCODE2DATA.TITLE4 AS boqItemGroupCode2Level4Title,
GROUPCODE2DATA.TITLE5 AS boqItemGroupCode2Level5Title,
GROUPCODE2DATA.TITLE6 AS boqItemGroupCode2Level6Title,
GROUPCODE2DATA.TITLE7 AS boqItemGroupCode2Level7Title,
GROUPCODE2DATA.TITLE8 AS boqItemGroupCode2Level8Title,
GROUPCODE2DATA.TITLE9 AS boqItemGroupCode2Level9Title,
GROUPCODE2DATA.UNIT1 AS boqItemGroupCode2Level1Unit,
GROUPCODE2DATA.UNIT2 AS boqItemGroupCode2Level2Unit,
GROUPCODE2DATA.UNIT3 AS boqItemGroupCode2Level3Unit,
GROUPCODE2DATA.UNIT4 AS boqItemGroupCode2Level4Unit,
GROUPCODE2DATA.UNIT5 AS boqItemGroupCode2Level5Unit,
GROUPCODE2DATA.UNIT6 AS boqItemGroupCode2Level6Unit,
GROUPCODE2DATA.UNIT7 AS boqItemGroupCode2Level7Unit,
GROUPCODE2DATA.UNIT8 AS boqItemGroupCode2Level8Unit,
GROUPCODE2DATA.UNIT9 AS boqItemGroupCode2Level9Unit,
GROUPCODE2DATA.UFACT1 AS boqItemGroupCode2Level1UnitFactor,
GROUPCODE2DATA.UFACT2 AS boqItemGroupCode2Level2UnitFactor,
GROUPCODE2DATA.UFACT3 AS boqItemGroupCode2Level3UnitFactor,
GROUPCODE2DATA.UFACT4 AS boqItemGroupCode2Level4UnitFactor,
GROUPCODE2DATA.UFACT5 AS boqItemGroupCode2Level5UnitFactor,
GROUPCODE2DATA.UFACT6 AS boqItemGroupCode2Level6UnitFactor,
GROUPCODE2DATA.UFACT7 AS boqItemGroupCode2Level7UnitFactor,
GROUPCODE2DATA.UFACT8 AS boqItemGroupCode2Level8UnitFactor,
GROUPCODE2DATA.UFACT9 AS boqItemGroupCode2Level9UnitFactor,
GROUPCODE2DATA.NOTES1 AS boqItemGroupCode2Level1Notes,
GROUPCODE2DATA.NOTES2 AS boqItemGroupCode2Level2Notes,
GROUPCODE2DATA.NOTES3 AS boqItemGroupCode2Level3Notes,
GROUPCODE2DATA.NOTES4 AS boqItemGroupCode2Level4Notes,
GROUPCODE2DATA.NOTES5 AS boqItemGroupCode2Level5Notes,
GROUPCODE2DATA.NOTES6 AS boqItemGroupCode2Level6Notes,
GROUPCODE2DATA.NOTES7 AS boqItemGroupCode2Level7Notes,
GROUPCODE2DATA.NOTES8 AS boqItemGroupCode2Level8Notes,
GROUPCODE2DATA.NOTES9 AS boqItemGroupCode2Level9Notes,
GROUPCODE2DATA.DESCRIPTION1 AS boqItemGroupCode2Level1Description,
GROUPCODE2DATA.DESCRIPTION2 AS boqItemGroupCode2Level2Description,
GROUPCODE2DATA.DESCRIPTION3 AS boqItemGroupCode2Level3Description,
GROUPCODE2DATA.DESCRIPTION4 AS boqItemGroupCode2Level4Description,
GROUPCODE2DATA.DESCRIPTION5 AS boqItemGroupCode2Level5Description,
GROUPCODE2DATA.DESCRIPTION6 AS boqItemGroupCode2Level6Description,
GROUPCODE2DATA.DESCRIPTION7 AS boqItemGroupCode2Level7Description,
GROUPCODE2DATA.DESCRIPTION8 AS boqItemGroupCode2Level8Description,
GROUPCODE2DATA.DESCRIPTION9 AS boqItemGroupCode2Level9Description,' 

ELSE
SET @GRoupCode2Part =''
IF @groupCode3 =1	
SET @GRoupCode3Part ='
GROUPCODE3DATA.CODE1 AS boqItemGroupCode3Level1Code,
GROUPCODE3DATA.CODE2 AS boqItemGroupCode3Level2Code,
GROUPCODE3DATA.CODE3 AS boqItemGroupCode3Level3Code,
GROUPCODE3DATA.CODE4 AS boqItemGroupCode3Level4Code,
GROUPCODE3DATA.CODE5 AS boqItemGroupCode3Level5Code,
GROUPCODE3DATA.CODE6 AS boqItemGroupCode3Level6Code,
GROUPCODE3DATA.CODE7 AS boqItemGroupCode3Level7Code,
GROUPCODE3DATA.CODE8 AS boqItemGroupCode3Level8Code,
GROUPCODE3DATA.CODE9 AS boqItemGroupCode3Level9Code,
GROUPCODE3DATA.TITLE1 AS boqItemGroupCode3Level1Title,
GROUPCODE3DATA.TITLE2 AS boqItemGroupCode3Level2Title,
GROUPCODE3DATA.TITLE3 AS boqItemGroupCode3Level3Title,
GROUPCODE3DATA.TITLE4 AS boqItemGroupCode3Level4Title,
GROUPCODE3DATA.TITLE5 AS boqItemGroupCode3Level5Title,
GROUPCODE3DATA.TITLE6 AS boqItemGroupCode3Level6Title,
GROUPCODE3DATA.TITLE7 AS boqItemGroupCode3Level7Title,
GROUPCODE3DATA.TITLE8 AS boqItemGroupCode3Level8Title,
GROUPCODE3DATA.TITLE9 AS boqItemGroupCode3Level9Title,
GROUPCODE3DATA.UNIT1 AS boqItemGroupCode3Level1Unit,
GROUPCODE3DATA.UNIT2 AS boqItemGroupCode3Level2Unit,
GROUPCODE3DATA.UNIT3 AS boqItemGroupCode3Level3Unit,
GROUPCODE3DATA.UNIT4 AS boqItemGroupCode3Level4Unit,
GROUPCODE3DATA.UNIT5 AS boqItemGroupCode3Level5Unit,
GROUPCODE3DATA.UNIT6 AS boqItemGroupCode3Level6Unit,
GROUPCODE3DATA.UNIT7 AS boqItemGroupCode3Level7Unit,
GROUPCODE3DATA.UNIT8 AS boqItemGroupCode3Level8Unit,
GROUPCODE3DATA.UNIT9 AS boqItemGroupCode3Level9Unit,
GROUPCODE3DATA.UFACT1 AS boqItemGroupCode3Level1UnitFactor,
GROUPCODE3DATA.UFACT2 AS boqItemGroupCode3Level2UnitFactor,
GROUPCODE3DATA.UFACT3 AS boqItemGroupCode3Level3UnitFactor,
GROUPCODE3DATA.UFACT4 AS boqItemGroupCode3Level4UnitFactor,
GROUPCODE3DATA.UFACT5 AS boqItemGroupCode3Level5UnitFactor,
GROUPCODE3DATA.UFACT6 AS boqItemGroupCode3Level6UnitFactor,
GROUPCODE3DATA.UFACT7 AS boqItemGroupCode3Level7UnitFactor,
GROUPCODE3DATA.UFACT8 AS boqItemGroupCode3Level8UnitFactor,
GROUPCODE3DATA.UFACT9 AS boqItemGroupCode3Level9UnitFactor,
GROUPCODE3DATA.NOTES1 AS boqItemGroupCode3Level1Notes,
GROUPCODE3DATA.NOTES2 AS boqItemGroupCode3Level2Notes,
GROUPCODE3DATA.NOTES3 AS boqItemGroupCode3Level3Notes,
GROUPCODE3DATA.NOTES4 AS boqItemGroupCode3Level4Notes,
GROUPCODE3DATA.NOTES5 AS boqItemGroupCode3Level5Notes,
GROUPCODE3DATA.NOTES6 AS boqItemGroupCode3Level6Notes,
GROUPCODE3DATA.NOTES7 AS boqItemGroupCode3Level7Notes,
GROUPCODE3DATA.NOTES8 AS boqItemGroupCode3Level8Notes,
GROUPCODE3DATA.NOTES9 AS boqItemGroupCode3Level9Notes,
GROUPCODE3DATA.DESCRIPTION1 AS boqItemGroupCode3Level1Description,
GROUPCODE3DATA.DESCRIPTION2 AS boqItemGroupCode3Level2Description,
GROUPCODE3DATA.DESCRIPTION3 AS boqItemGroupCode3Level3Description,
GROUPCODE3DATA.DESCRIPTION4 AS boqItemGroupCode3Level4Description,
GROUPCODE3DATA.DESCRIPTION5 AS boqItemGroupCode3Level5Description,
GROUPCODE3DATA.DESCRIPTION6 AS boqItemGroupCode3Level6Description,
GROUPCODE3DATA.DESCRIPTION7 AS boqItemGroupCode3Level7Description,
GROUPCODE3DATA.DESCRIPTION8 AS boqItemGroupCode3Level8Description,
GROUPCODE3DATA.DESCRIPTION9 AS boqItemGroupCode3Level9Description,' 

ELSE
SET @GRoupCode3Part =''
IF @groupCode4 =1
SET @GRoupCode4Part ='
GROUPCODE4DATA.CODE1 AS boqItemGroupCode4Level1Code,
GROUPCODE4DATA.CODE2 AS boqItemGroupCode4Level2Code,
GROUPCODE4DATA.CODE3 AS boqItemGroupCode4Level3Code,
GROUPCODE4DATA.CODE4 AS boqItemGroupCode4Level4Code,
GROUPCODE4DATA.CODE5 AS boqItemGroupCode4Level5Code,
GROUPCODE4DATA.CODE6 AS boqItemGroupCode4Level6Code,
GROUPCODE4DATA.CODE7 AS boqItemGroupCode4Level7Code,
GROUPCODE4DATA.CODE8 AS boqItemGroupCode4Level8Code,
GROUPCODE4DATA.CODE9 AS boqItemGroupCode4Level9Code,
GROUPCODE4DATA.TITLE1 AS boqItemGroupCode4Level1Title,
GROUPCODE4DATA.TITLE2 AS boqItemGroupCode4Level2Title,
GROUPCODE4DATA.TITLE3 AS boqItemGroupCode4Level3Title,
GROUPCODE4DATA.TITLE4 AS boqItemGroupCode4Level4Title,
GROUPCODE4DATA.TITLE5 AS boqItemGroupCode4Level5Title,
GROUPCODE4DATA.TITLE6 AS boqItemGroupCode4Level6Title,
GROUPCODE4DATA.TITLE7 AS boqItemGroupCode4Level7Title,
GROUPCODE4DATA.TITLE8 AS boqItemGroupCode4Level8Title,
GROUPCODE4DATA.TITLE9 AS boqItemGroupCode4Level9Title,
GROUPCODE4DATA.UNIT1 AS boqItemGroupCode4Level1Unit,
GROUPCODE4DATA.UNIT2 AS boqItemGroupCode4Level2Unit,
GROUPCODE4DATA.UNIT3 AS boqItemGroupCode4Level3Unit,
GROUPCODE4DATA.UNIT4 AS boqItemGroupCode4Level4Unit,
GROUPCODE4DATA.UNIT5 AS boqItemGroupCode4Level5Unit,
GROUPCODE4DATA.UNIT6 AS boqItemGroupCode4Level6Unit,
GROUPCODE4DATA.UNIT7 AS boqItemGroupCode4Level7Unit,
GROUPCODE4DATA.UNIT8 AS boqItemGroupCode4Level8Unit,
GROUPCODE4DATA.UNIT9 AS boqItemGroupCode4Level9Unit,
GROUPCODE4DATA.UFACT1 AS boqItemGroupCode4Level1UnitFactor,
GROUPCODE4DATA.UFACT2 AS boqItemGroupCode4Level2UnitFactor,
GROUPCODE4DATA.UFACT3 AS boqItemGroupCode4Level3UnitFactor,
GROUPCODE4DATA.UFACT4 AS boqItemGroupCode4Level4UnitFactor,
GROUPCODE4DATA.UFACT5 AS boqItemGroupCode4Level5UnitFactor,
GROUPCODE4DATA.UFACT6 AS boqItemGroupCode4Level6UnitFactor,
GROUPCODE4DATA.UFACT7 AS boqItemGroupCode4Level7UnitFactor,
GROUPCODE4DATA.UFACT8 AS boqItemGroupCode4Level8UnitFactor,
GROUPCODE4DATA.UFACT9 AS boqItemGroupCode4Level9UnitFactor,
GROUPCODE4DATA.NOTES1 AS boqItemGroupCode4Level1Notes,
GROUPCODE4DATA.NOTES2 AS boqItemGroupCode4Level2Notes,
GROUPCODE4DATA.NOTES3 AS boqItemGroupCode4Level3Notes,
GROUPCODE4DATA.NOTES4 AS boqItemGroupCode4Level4Notes,
GROUPCODE4DATA.NOTES5 AS boqItemGroupCode4Level5Notes,
GROUPCODE4DATA.NOTES6 AS boqItemGroupCode4Level6Notes,
GROUPCODE4DATA.NOTES7 AS boqItemGroupCode4Level7Notes,
GROUPCODE4DATA.NOTES8 AS boqItemGroupCode4Level8Notes,
GROUPCODE4DATA.NOTES9 AS boqItemGroupCode4Level9Notes,
GROUPCODE4DATA.DESCRIPTION1 AS boqItemGroupCode4Level1Description,
GROUPCODE4DATA.DESCRIPTION2 AS boqItemGroupCode4Level2Description,
GROUPCODE4DATA.DESCRIPTION3 AS boqItemGroupCode4Level3Description,
GROUPCODE4DATA.DESCRIPTION4 AS boqItemGroupCode4Level4Description,
GROUPCODE4DATA.DESCRIPTION5 AS boqItemGroupCode4Level5Description,
GROUPCODE4DATA.DESCRIPTION6 AS boqItemGroupCode4Level6Description,
GROUPCODE4DATA.DESCRIPTION7 AS boqItemGroupCode4Level7Description,
GROUPCODE4DATA.DESCRIPTION8 AS boqItemGroupCode4Level8Description,
GROUPCODE4DATA.DESCRIPTION9 AS boqItemGroupCode4Level9Description,'


ELSE
SET @GRoupCode4Part =''
IF @groupCode5 =1
SET @GRoupCode5Part ='
GROUPCODE5DATA.CODE1 AS boqItemGroupCode5Level1Code,
GROUPCODE5DATA.CODE2 AS boqItemGroupCode5Level2Code,
GROUPCODE5DATA.CODE3 AS boqItemGroupCode5Level3Code,
GROUPCODE5DATA.CODE4 AS boqItemGroupCode5Level4Code,
GROUPCODE5DATA.CODE5 AS boqItemGroupCode5Level5Code,
GROUPCODE5DATA.CODE6 AS boqItemGroupCode5Level6Code,
GROUPCODE5DATA.CODE7 AS boqItemGroupCode5Level7Code,
GROUPCODE5DATA.CODE8 AS boqItemGroupCode5Level8Code,
GROUPCODE5DATA.CODE9 AS boqItemGroupCode5Level9Code,
GROUPCODE5DATA.TITLE1 AS boqItemGroupCode5Level1Title,
GROUPCODE5DATA.TITLE2 AS boqItemGroupCode5Level2Title,
GROUPCODE5DATA.TITLE3 AS boqItemGroupCode5Level3Title,
GROUPCODE5DATA.TITLE4 AS boqItemGroupCode5Level4Title,
GROUPCODE5DATA.TITLE5 AS boqItemGroupCode5Level5Title,
GROUPCODE5DATA.TITLE6 AS boqItemGroupCode5Level6Title,
GROUPCODE5DATA.TITLE7 AS boqItemGroupCode5Level7Title,
GROUPCODE5DATA.TITLE8 AS boqItemGroupCode5Level8Title,
GROUPCODE5DATA.TITLE9 AS boqItemGroupCode5Level9Title,
GROUPCODE5DATA.UNIT1 AS boqItemGroupCode5Level1Unit,
GROUPCODE5DATA.UNIT2 AS boqItemGroupCode5Level2Unit,
GROUPCODE5DATA.UNIT3 AS boqItemGroupCode5Level3Unit,
GROUPCODE5DATA.UNIT4 AS boqItemGroupCode5Level4Unit,
GROUPCODE5DATA.UNIT5 AS boqItemGroupCode5Level5Unit,
GROUPCODE5DATA.UNIT6 AS boqItemGroupCode5Level6Unit,
GROUPCODE5DATA.UNIT7 AS boqItemGroupCode5Level7Unit,
GROUPCODE5DATA.UNIT8 AS boqItemGroupCode5Level8Unit,
GROUPCODE5DATA.UNIT9 AS boqItemGroupCode5Level9Unit,
GROUPCODE5DATA.UFACT1 AS boqItemGroupCode5Level1UnitFactor,
GROUPCODE5DATA.UFACT2 AS boqItemGroupCode5Level2UnitFactor,
GROUPCODE5DATA.UFACT3 AS boqItemGroupCode5Level3UnitFactor,
GROUPCODE5DATA.UFACT4 AS boqItemGroupCode5Level4UnitFactor,
GROUPCODE5DATA.UFACT5 AS boqItemGroupCode5Level5UnitFactor,
GROUPCODE5DATA.UFACT6 AS boqItemGroupCode5Level6UnitFactor,
GROUPCODE5DATA.UFACT7 AS boqItemGroupCode5Level7UnitFactor,
GROUPCODE5DATA.UFACT8 AS boqItemGroupCode5Level8UnitFactor,
GROUPCODE5DATA.UFACT9 AS boqItemGroupCode5Level9UnitFactor,
GROUPCODE5DATA.NOTES1 AS boqItemGroupCode5Level1Notes,
GROUPCODE5DATA.NOTES2 AS boqItemGroupCode5Level2Notes,
GROUPCODE5DATA.NOTES3 AS boqItemGroupCode5Level3Notes,
GROUPCODE5DATA.NOTES4 AS boqItemGroupCode5Level4Notes,
GROUPCODE5DATA.NOTES5 AS boqItemGroupCode5Level5Notes,
GROUPCODE5DATA.NOTES6 AS boqItemGroupCode5Level6Notes,
GROUPCODE5DATA.NOTES7 AS boqItemGroupCode5Level7Notes,
GROUPCODE5DATA.NOTES8 AS boqItemGroupCode5Level8Notes,
GROUPCODE5DATA.NOTES9 AS boqItemGroupCode5Level9Notes,
GROUPCODE5DATA.DESCRIPTION1 AS boqItemGroupCode5Level1Description,
GROUPCODE5DATA.DESCRIPTION2 AS boqItemGroupCode5Level2Description,
GROUPCODE5DATA.DESCRIPTION3 AS boqItemGroupCode5Level3Description,
GROUPCODE5DATA.DESCRIPTION4 AS boqItemGroupCode5Level4Description,
GROUPCODE5DATA.DESCRIPTION5 AS boqItemGroupCode5Level5Description,
GROUPCODE5DATA.DESCRIPTION6 AS boqItemGroupCode5Level6Description,
GROUPCODE5DATA.DESCRIPTION7 AS boqItemGroupCode5Level7Description,
GROUPCODE5DATA.DESCRIPTION8 AS boqItemGroupCode5Level8Description,
GROUPCODE5DATA.DESCRIPTION9 AS boqItemGroupCode5Level9Description,'


ELSE
SET @GRoupCode5Part =''
IF @groupCode6 =1
SET @GRoupCode6Part ='
GROUPCODE6DATA.CODE1 AS boqItemGroupCode6Level1Code,
GROUPCODE6DATA.CODE2 AS boqItemGroupCode6Level2Code,
GROUPCODE6DATA.CODE3 AS boqItemGroupCode6Level3Code,
GROUPCODE6DATA.CODE4 AS boqItemGroupCode6Level4Code,
GROUPCODE6DATA.CODE5 AS boqItemGroupCode6Level5Code,
GROUPCODE6DATA.CODE6 AS boqItemGroupCode6Level6Code,
GROUPCODE6DATA.CODE7 AS boqItemGroupCode6Level7Code,
GROUPCODE6DATA.CODE8 AS boqItemGroupCode6Level8Code,
GROUPCODE6DATA.CODE9 AS boqItemGroupCode6Level9Code,
GROUPCODE6DATA.TITLE1 AS boqItemGroupCode6Level1Title,
GROUPCODE6DATA.TITLE2 AS boqItemGroupCode6Level2Title,
GROUPCODE6DATA.TITLE3 AS boqItemGroupCode6Level3Title,
GROUPCODE6DATA.TITLE4 AS boqItemGroupCode6Level4Title,
GROUPCODE6DATA.TITLE5 AS boqItemGroupCode6Level5Title,
GROUPCODE6DATA.TITLE6 AS boqItemGroupCode6Level6Title,
GROUPCODE6DATA.TITLE7 AS boqItemGroupCode6Level7Title,
GROUPCODE6DATA.TITLE8 AS boqItemGroupCode6Level8Title,
GROUPCODE6DATA.TITLE9 AS boqItemGroupCode6Level9Title,
GROUPCODE6DATA.UNIT1 AS boqItemGroupCode6Level1Unit,
GROUPCODE6DATA.UNIT2 AS boqItemGroupCode6Level2Unit,
GROUPCODE6DATA.UNIT3 AS boqItemGroupCode6Level3Unit,
GROUPCODE6DATA.UNIT4 AS boqItemGroupCode6Level4Unit,
GROUPCODE6DATA.UNIT5 AS boqItemGroupCode6Level5Unit,
GROUPCODE6DATA.UNIT6 AS boqItemGroupCode6Level6Unit,
GROUPCODE6DATA.UNIT7 AS boqItemGroupCode6Level7Unit,
GROUPCODE6DATA.UNIT8 AS boqItemGroupCode6Level8Unit,
GROUPCODE6DATA.UNIT9 AS boqItemGroupCode6Level9Unit,
GROUPCODE6DATA.UFACT1 AS boqItemGroupCode6Level1UnitFactor,
GROUPCODE6DATA.UFACT2 AS boqItemGroupCode6Level2UnitFactor,
GROUPCODE6DATA.UFACT3 AS boqItemGroupCode6Level3UnitFactor,
GROUPCODE6DATA.UFACT4 AS boqItemGroupCode6Level4UnitFactor,
GROUPCODE6DATA.UFACT5 AS boqItemGroupCode6Level5UnitFactor,
GROUPCODE6DATA.UFACT6 AS boqItemGroupCode6Level6UnitFactor,
GROUPCODE6DATA.UFACT7 AS boqItemGroupCode6Level7UnitFactor,
GROUPCODE6DATA.UFACT8 AS boqItemGroupCode6Level8UnitFactor,
GROUPCODE6DATA.UFACT9 AS boqItemGroupCode6Level9UnitFactor,
GROUPCODE6DATA.NOTES1 AS boqItemGroupCode6Level1Notes,
GROUPCODE6DATA.NOTES2 AS boqItemGroupCode6Level2Notes,
GROUPCODE6DATA.NOTES3 AS boqItemGroupCode6Level3Notes,
GROUPCODE6DATA.NOTES4 AS boqItemGroupCode6Level4Notes,
GROUPCODE6DATA.NOTES5 AS boqItemGroupCode6Level5Notes,
GROUPCODE6DATA.NOTES6 AS boqItemGroupCode6Level6Notes,
GROUPCODE6DATA.NOTES7 AS boqItemGroupCode6Level7Notes,
GROUPCODE6DATA.NOTES8 AS boqItemGroupCode6Level8Notes,
GROUPCODE6DATA.NOTES9 AS boqItemGroupCode6Level9Notes,
GROUPCODE6DATA.DESCRIPTION1 AS boqItemGroupCode6Level1Description,
GROUPCODE6DATA.DESCRIPTION2 AS boqItemGroupCode6Level2Description,
GROUPCODE6DATA.DESCRIPTION3 AS boqItemGroupCode6Level3Description,
GROUPCODE6DATA.DESCRIPTION4 AS boqItemGroupCode6Level4Description,
GROUPCODE6DATA.DESCRIPTION5 AS boqItemGroupCode6Level5Description,
GROUPCODE6DATA.DESCRIPTION6 AS boqItemGroupCode6Level6Description,
GROUPCODE6DATA.DESCRIPTION7 AS boqItemGroupCode6Level7Description,
GROUPCODE6DATA.DESCRIPTION8 AS boqItemGroupCode6Level8Description,
GROUPCODE6DATA.DESCRIPTION9 AS boqItemGroupCode6Level9Description,'


ELSE
SET @GRoupCode6Part =''
IF @groupCode7 =1
	
SET @GRoupCode7Part ='
GROUPCODE7DATA.CODE1 AS boqItemGroupCode7Level1Code,
GROUPCODE7DATA.CODE2 AS boqItemGroupCode7Level2Code,
GROUPCODE7DATA.CODE3 AS boqItemGroupCode7Level3Code,
GROUPCODE7DATA.CODE4 AS boqItemGroupCode7Level4Code,
GROUPCODE7DATA.CODE5 AS boqItemGroupCode7Level5Code,
GROUPCODE7DATA.CODE6 AS boqItemGroupCode7Level6Code,
GROUPCODE7DATA.CODE7 AS boqItemGroupCode7Level7Code,
GROUPCODE7DATA.CODE8 AS boqItemGroupCode7Level8Code,
GROUPCODE7DATA.CODE9 AS boqItemGroupCode7Level9Code,
GROUPCODE7DATA.TITLE1 AS boqItemGroupCode7Level1Title,
GROUPCODE7DATA.TITLE2 AS boqItemGroupCode7Level2Title,
GROUPCODE7DATA.TITLE3 AS boqItemGroupCode7Level3Title,
GROUPCODE7DATA.TITLE4 AS boqItemGroupCode7Level4Title,
GROUPCODE7DATA.TITLE5 AS boqItemGroupCode7Level5Title,
GROUPCODE7DATA.TITLE6 AS boqItemGroupCode7Level6Title,
GROUPCODE7DATA.TITLE7 AS boqItemGroupCode7Level7Title,
GROUPCODE7DATA.TITLE8 AS boqItemGroupCode7Level8Title,
GROUPCODE7DATA.TITLE9 AS boqItemGroupCode7Level9Title,
GROUPCODE7DATA.UNIT1 AS boqItemGroupCode7Level1Unit,
GROUPCODE7DATA.UNIT2 AS boqItemGroupCode7Level2Unit,
GROUPCODE7DATA.UNIT3 AS boqItemGroupCode7Level3Unit,
GROUPCODE7DATA.UNIT4 AS boqItemGroupCode7Level4Unit,
GROUPCODE7DATA.UNIT5 AS boqItemGroupCode7Level5Unit,
GROUPCODE7DATA.UNIT6 AS boqItemGroupCode7Level6Unit,
GROUPCODE7DATA.UNIT7 AS boqItemGroupCode7Level7Unit,
GROUPCODE7DATA.UNIT8 AS boqItemGroupCode7Level8Unit,
GROUPCODE7DATA.UNIT9 AS boqItemGroupCode7Level9Unit,
GROUPCODE7DATA.UFACT1 AS boqItemGroupCode7Level1UnitFactor,
GROUPCODE7DATA.UFACT2 AS boqItemGroupCode7Level2UnitFactor,
GROUPCODE7DATA.UFACT3 AS boqItemGroupCode7Level3UnitFactor,
GROUPCODE7DATA.UFACT4 AS boqItemGroupCode7Level4UnitFactor,
GROUPCODE7DATA.UFACT5 AS boqItemGroupCode7Level5UnitFactor,
GROUPCODE7DATA.UFACT6 AS boqItemGroupCode7Level6UnitFactor,
GROUPCODE7DATA.UFACT7 AS boqItemGroupCode7Level7UnitFactor,
GROUPCODE7DATA.UFACT8 AS boqItemGroupCode7Level8UnitFactor,
GROUPCODE7DATA.UFACT9 AS boqItemGroupCode7Level9UnitFactor,
GROUPCODE7DATA.NOTES1 AS boqItemGroupCode7Level1Notes,
GROUPCODE7DATA.NOTES2 AS boqItemGroupCode7Level2Notes,
GROUPCODE7DATA.NOTES3 AS boqItemGroupCode7Level3Notes,
GROUPCODE7DATA.NOTES4 AS boqItemGroupCode7Level4Notes,
GROUPCODE7DATA.NOTES5 AS boqItemGroupCode7Level5Notes,
GROUPCODE7DATA.NOTES6 AS boqItemGroupCode7Level6Notes,
GROUPCODE7DATA.NOTES7 AS boqItemGroupCode7Level7Notes,
GROUPCODE7DATA.NOTES8 AS boqItemGroupCode7Level8Notes,
GROUPCODE7DATA.NOTES9 AS boqItemGroupCode7Level9Notes,
GROUPCODE7DATA.DESCRIPTION1 AS boqItemGroupCode7Level1Description,
GROUPCODE7DATA.DESCRIPTION2 AS boqItemGroupCode7Level2Description,
GROUPCODE7DATA.DESCRIPTION3 AS boqItemGroupCode7Level3Description,
GROUPCODE7DATA.DESCRIPTION4 AS boqItemGroupCode7Level4Description,
GROUPCODE7DATA.DESCRIPTION5 AS boqItemGroupCode7Level5Description,
GROUPCODE7DATA.DESCRIPTION6 AS boqItemGroupCode7Level6Description,
GROUPCODE7DATA.DESCRIPTION7 AS boqItemGroupCode7Level7Description,
GROUPCODE7DATA.DESCRIPTION8 AS boqItemGroupCode7Level8Description,
GROUPCODE7DATA.DESCRIPTION9 AS boqItemGroupCode7Level9Description,'
 
ELSE
SET @GRoupCode7Part =''
IF @groupCode8 =1
SET @GRoupCode8Part ='
GROUPCODE8DATA.CODE1 AS boqItemGroupCode8Level1Code,
GROUPCODE8DATA.CODE2 AS boqItemGroupCode8Level2Code,
GROUPCODE8DATA.CODE3 AS boqItemGroupCode8Level3Code,
GROUPCODE8DATA.CODE4 AS boqItemGroupCode8Level4Code,
GROUPCODE8DATA.CODE5 AS boqItemGroupCode8Level5Code,
GROUPCODE8DATA.CODE6 AS boqItemGroupCode8Level6Code,
GROUPCODE8DATA.CODE7 AS boqItemGroupCode8Level7Code,
GROUPCODE8DATA.CODE8 AS boqItemGroupCode8Level8Code,
GROUPCODE8DATA.CODE9 AS boqItemGroupCode8Level9Code,
GROUPCODE8DATA.TITLE1 AS boqItemGroupCode8Level1Title,
GROUPCODE8DATA.TITLE2 AS boqItemGroupCode8Level2Title,
GROUPCODE8DATA.TITLE3 AS boqItemGroupCode8Level3Title,
GROUPCODE8DATA.TITLE4 AS boqItemGroupCode8Level4Title,
GROUPCODE8DATA.TITLE5 AS boqItemGroupCode8Level5Title,
GROUPCODE8DATA.TITLE6 AS boqItemGroupCode8Level6Title,
GROUPCODE8DATA.TITLE7 AS boqItemGroupCode8Level7Title,
GROUPCODE8DATA.TITLE8 AS boqItemGroupCode8Level8Title,
GROUPCODE8DATA.TITLE9 AS boqItemGroupCode8Level9Title,
GROUPCODE8DATA.UNIT1 AS boqItemGroupCode8Level1Unit,
GROUPCODE8DATA.UNIT2 AS boqItemGroupCode8Level2Unit,
GROUPCODE8DATA.UNIT3 AS boqItemGroupCode8Level3Unit,
GROUPCODE8DATA.UNIT4 AS boqItemGroupCode8Level4Unit,
GROUPCODE8DATA.UNIT5 AS boqItemGroupCode8Level5Unit,
GROUPCODE8DATA.UNIT6 AS boqItemGroupCode8Level6Unit,
GROUPCODE8DATA.UNIT7 AS boqItemGroupCode8Level7Unit,
GROUPCODE8DATA.UNIT8 AS boqItemGroupCode8Level8Unit,
GROUPCODE8DATA.UNIT9 AS boqItemGroupCode8Level9Unit,
GROUPCODE8DATA.UFACT1 AS boqItemGroupCode8Level1UnitFactor,
GROUPCODE8DATA.UFACT2 AS boqItemGroupCode8Level2UnitFactor,
GROUPCODE8DATA.UFACT3 AS boqItemGroupCode8Level3UnitFactor,
GROUPCODE8DATA.UFACT4 AS boqItemGroupCode8Level4UnitFactor,
GROUPCODE8DATA.UFACT5 AS boqItemGroupCode8Level5UnitFactor,
GROUPCODE8DATA.UFACT6 AS boqItemGroupCode8Level6UnitFactor,
GROUPCODE8DATA.UFACT7 AS boqItemGroupCode8Level7UnitFactor,
GROUPCODE8DATA.UFACT8 AS boqItemGroupCode8Level8UnitFactor,
GROUPCODE8DATA.UFACT9 AS boqItemGroupCode8Level9UnitFactor,
GROUPCODE8DATA.NOTES1 AS boqItemGroupCode8Level1Notes,
GROUPCODE8DATA.NOTES2 AS boqItemGroupCode8Level2Notes,
GROUPCODE8DATA.NOTES3 AS boqItemGroupCode8Level3Notes,
GROUPCODE8DATA.NOTES4 AS boqItemGroupCode8Level4Notes,
GROUPCODE8DATA.NOTES5 AS boqItemGroupCode8Level5Notes,
GROUPCODE8DATA.NOTES6 AS boqItemGroupCode8Level6Notes,
GROUPCODE8DATA.NOTES7 AS boqItemGroupCode8Level7Notes,
GROUPCODE8DATA.NOTES8 AS boqItemGroupCode8Level8Notes,
GROUPCODE8DATA.NOTES9 AS boqItemGroupCode8Level9Notes,
GROUPCODE8DATA.DESCRIPTION1 AS boqItemGroupCode8Level1Description,
GROUPCODE8DATA.DESCRIPTION2 AS boqItemGroupCode8Level2Description,
GROUPCODE8DATA.DESCRIPTION3 AS boqItemGroupCode8Level3Description,
GROUPCODE8DATA.DESCRIPTION4 AS boqItemGroupCode8Level4Description,
GROUPCODE8DATA.DESCRIPTION5 AS boqItemGroupCode8Level5Description,
GROUPCODE8DATA.DESCRIPTION6 AS boqItemGroupCode8Level6Description,
GROUPCODE8DATA.DESCRIPTION7 AS boqItemGroupCode8Level7Description,
GROUPCODE8DATA.DESCRIPTION8 AS boqItemGroupCode8Level8Description,
GROUPCODE8DATA.DESCRIPTION9 AS boqItemGroupCode8Level9Description,'
	
ELSE
SET @GRoupCode8Part =''
IF @groupCode9 =1
SET @GRoupCode9Part ='
GROUPCODE9DATA.CODE1 AS boqItemGroupCode9Level1Code,
GROUPCODE9DATA.CODE2 AS boqItemGroupCode9Level2Code,
GROUPCODE9DATA.CODE3 AS boqItemGroupCode9Level3Code,
GROUPCODE9DATA.CODE4 AS boqItemGroupCode9Level4Code,
GROUPCODE9DATA.CODE5 AS boqItemGroupCode9Level5Code,
GROUPCODE9DATA.CODE6 AS boqItemGroupCode9Level6Code,
GROUPCODE9DATA.CODE7 AS boqItemGroupCode9Level7Code,
GROUPCODE9DATA.CODE8 AS boqItemGroupCode9Level8Code,
GROUPCODE9DATA.CODE9 AS boqItemGroupCode9Level9Code,
GROUPCODE9DATA.TITLE1 AS boqItemGroupCode9Level1Title,
GROUPCODE9DATA.TITLE2 AS boqItemGroupCode9Level2Title,
GROUPCODE9DATA.TITLE3 AS boqItemGroupCode9Level3Title,
GROUPCODE9DATA.TITLE4 AS boqItemGroupCode9Level4Title,
GROUPCODE9DATA.TITLE5 AS boqItemGroupCode9Level5Title,
GROUPCODE9DATA.TITLE6 AS boqItemGroupCode9Level6Title,
GROUPCODE9DATA.TITLE7 AS boqItemGroupCode9Level7Title,
GROUPCODE9DATA.TITLE8 AS boqItemGroupCode9Level8Title,
GROUPCODE9DATA.TITLE9 AS boqItemGroupCode9Level9Title,
GROUPCODE9DATA.UNIT1 AS boqItemGroupCode9Level1Unit,
GROUPCODE9DATA.UNIT2 AS boqItemGroupCode9Level2Unit,
GROUPCODE9DATA.UNIT3 AS boqItemGroupCode9Level3Unit,
GROUPCODE9DATA.UNIT4 AS boqItemGroupCode9Level4Unit,
GROUPCODE9DATA.UNIT5 AS boqItemGroupCode9Level5Unit,
GROUPCODE9DATA.UNIT6 AS boqItemGroupCode9Level6Unit,
GROUPCODE9DATA.UNIT7 AS boqItemGroupCode9Level7Unit,
GROUPCODE9DATA.UNIT8 AS boqItemGroupCode9Level8Unit,
GROUPCODE9DATA.UNIT9 AS boqItemGroupCode9Level9Unit,
GROUPCODE9DATA.UFACT1 AS boqItemGroupCode9Level1UnitFactor,
GROUPCODE9DATA.UFACT2 AS boqItemGroupCode9Level2UnitFactor,
GROUPCODE9DATA.UFACT3 AS boqItemGroupCode9Level3UnitFactor,
GROUPCODE9DATA.UFACT4 AS boqItemGroupCode9Level4UnitFactor,
GROUPCODE9DATA.UFACT5 AS boqItemGroupCode9Level5UnitFactor,
GROUPCODE9DATA.UFACT6 AS boqItemGroupCode9Level6UnitFactor,
GROUPCODE9DATA.UFACT7 AS boqItemGroupCode9Level7UnitFactor,
GROUPCODE9DATA.UFACT8 AS boqItemGroupCode9Level8UnitFactor,
GROUPCODE9DATA.UFACT9 AS boqItemGroupCode9Level9UnitFactor,
GROUPCODE9DATA.NOTES1 AS boqItemGroupCode9Level1Notes,
GROUPCODE9DATA.NOTES2 AS boqItemGroupCode9Level2Notes,
GROUPCODE9DATA.NOTES3 AS boqItemGroupCode9Level3Notes,
GROUPCODE9DATA.NOTES4 AS boqItemGroupCode9Level4Notes,
GROUPCODE9DATA.NOTES5 AS boqItemGroupCode9Level5Notes,
GROUPCODE9DATA.NOTES6 AS boqItemGroupCode9Level6Notes,
GROUPCODE9DATA.NOTES7 AS boqItemGroupCode9Level7Notes,
GROUPCODE9DATA.NOTES8 AS boqItemGroupCode9Level8Notes,
GROUPCODE9DATA.NOTES9 AS boqItemGroupCode9Level9Notes,
GROUPCODE9DATA.DESCRIPTION1 AS boqItemGroupCode9Level1Description,
GROUPCODE9DATA.DESCRIPTION2 AS boqItemGroupCode9Level2Description,
GROUPCODE9DATA.DESCRIPTION3 AS boqItemGroupCode9Level3Description,
GROUPCODE9DATA.DESCRIPTION4 AS boqItemGroupCode9Level4Description,
GROUPCODE9DATA.DESCRIPTION5 AS boqItemGroupCode9Level5Description,
GROUPCODE9DATA.DESCRIPTION6 AS boqItemGroupCode9Level6Description,
GROUPCODE9DATA.DESCRIPTION7 AS boqItemGroupCode9Level7Description,
GROUPCODE9DATA.DESCRIPTION8 AS boqItemGroupCode9Level8Description,
GROUPCODE9DATA.DESCRIPTION9 AS boqItemGroupCode9Level9Description,'


	
ELSE
SET @GRoupCode9Part =''
IF @wbs1 =1
SET @Wbs1PartOuterApply ='
cross apply (select SUBSTRING(o.WBSCODE,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.WBSCODE))+' + CHAR(39) + '.' + CHAR(39) + ') as WBS1(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY))) as WBS1_1(Pos)
  cross apply (SELECT CASE WHEN WBS1_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_1.Pos+1))) ELSE -1 END) as WBS1_2(Pos)
  cross apply (SELECT CASE WHEN WBS1_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_2.Pos+1))) ELSE -1 END) as WBS1_3(Pos)
  cross apply (SELECT CASE WHEN WBS1_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_3.Pos+1))) ELSE -1 END) as WBS1_4(Pos)
  cross apply (SELECT CASE WHEN WBS1_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_4.Pos+1))) ELSE -1 END) as WBS1_5(Pos)
  cross apply (SELECT CASE WHEN WBS1_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_5.Pos+1))) ELSE -1 END) as WBS1_6(Pos)
  cross apply (SELECT CASE WHEN WBS1_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_6.Pos+1))) ELSE -1 END) as WBS1_7(Pos)
  cross apply (SELECT CASE WHEN WBS1_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_7.Pos+1))) ELSE -1 END) as WBS1_8(Pos)
  cross apply (SELECT CASE WHEN WBS1_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS1.CODEONLY, WBS1_8.Pos+1))) ELSE -1 END) as WBS1_9(Pos)
  cross apply (
        select (CASE WHEN WBS1_1.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN WBS1_2.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_2.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_3.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_3.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_4.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_4.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_5.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_5.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_6.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_6.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_7.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_7.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_8.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_8.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS1_9.Pos>1 THEN LEFT(WBS1.CODEONLY,WBS1_9.Pos-1) ELSE NULL END)
	) AS WBSCODE1(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.CODE) as CODE1, max(l1.ITEMCODE) as ITEMCODE1, max(l1.TITLE) as TITLE1, max(l1.QUANTITY) as QUANTITY1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.DESCRIPTION) as DESCRIPTION1,
		max(l2.CODE) as CODE2, max(l2.ITEMCODE) as ITEMCODE2, max(l2.TITLE) as TITLE1, max(l2.QUANTITY) as QUANTITY2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.DESCRIPTION) as DESCRIPTION2,
		max(l3.CODE) as CODE3, max(l3.ITEMCODE) as ITEMCODE3, max(l3.TITLE) as TITLE1, max(l3.QUANTITY) as QUANTITY3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.DESCRIPTION) as DESCRIPTION3,
		max(l4.CODE) as CODE4, max(l4.ITEMCODE) as ITEMCODE4, max(l4.TITLE) as TITLE1, max(l4.QUANTITY) as QUANTITY4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.DESCRIPTION) as DESCRIPTION4,
		max(l5.CODE) as CODE5, max(l5.ITEMCODE) as ITEMCODE5, max(l5.TITLE) as TITLE1, max(l5.QUANTITY) as QUANTITY5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.DESCRIPTION) as DESCRIPTION5,
		max(l6.CODE) as CODE6, max(l6.ITEMCODE) as ITEMCODE6, max(l6.TITLE) as TITLE1, max(l6.QUANTITY) as QUANTITY6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.DESCRIPTION) as DESCRIPTION6,
		max(l7.CODE) as CODE7, max(l7.ITEMCODE) as ITEMCODE7, max(l7.TITLE) as TITLE1, max(l7.QUANTITY) as QUANTITY7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.DESCRIPTION) as DESCRIPTION7,
		max(l8.CODE) as CODE8, max(l8.ITEMCODE) as ITEMCODE8, max(l8.TITLE) as TITLE1, max(l8.QUANTITY) as QUANTITY8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.DESCRIPTION) as DESCRIPTION8,
		max(l9.CODE) as CODE9, max(l9.ITEMCODE) as ITEMCODE9, max(l9.TITLE) as TITLE1, max(l9.QUANTITY) as QUANTITY9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.DESCRIPTION) as DESCRIPTION9
		from '+@Dbname+'.dbo.PROJECTWBS as l1 with(nolock)
			 left join '+@Dbname+'.dbo.PROJECTWBS l2 WITH (NOLOCK) ON l2.CODE = WBSCODE1.LEVEL2 AND l2.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l3 WITH (NOLOCK) ON l3.CODE = WBSCODE1.LEVEL3 AND l3.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l4 WITH (NOLOCK) ON l4.CODE = WBSCODE1.LEVEL4 AND l4.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l5 WITH (NOLOCK) ON l5.CODE = WBSCODE1.LEVEL5 AND l5.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l6 WITH (NOLOCK) ON l6.CODE = WBSCODE1.LEVEL6 AND l6.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l7 WITH (NOLOCK) ON l7.CODE = WBSCODE1.LEVEL7 AND l7.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l8 WITH (NOLOCK) ON l8.CODE = WBSCODE1.LEVEL8 AND l8.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS l9 WITH (NOLOCK) ON l9.CODE = WBSCODE1.LEVEL9 AND l9.PRJID = ' + cast(@PrjId as varchar(max)) + '
		where l1.CODE = WBSCODE1.LEVEL1 AND l1.PRJID = ' + cast(@PrjId as varchar(max)) + '
  ) AS WBSCODE1DATA(CODE1,ITEMCODE1,TITLE1,QUANTITY1,UNIT1,UFACT1,DESCRIPTION1, CODE2,ITEMCODE2,TITLE2,QUANTITY2,UNIT2,UFACT2,DESCRIPTION2,CODE3,ITEMCODE3,TITLE3,QUANTITY3,UNIT3,UFACT3,DESCRIPTION3,CODE4,ITEMCODE4,TITLE4,QUANTITY4,UNIT4,UFACT4,DESCRIPTION4,CODE5,ITEMCODE5,TITLE5,QUANTITY5,UNIT5,UFACT5,DESCRIPTION5,CODE6,ITEMCODE6,TITLE6,QUANTITY6,UNIT6,UFACT6,DESCRIPTION6,CODE7,ITEMCODE7,TITLE7,QUANTITY7,UNIT7,UFACT7,DESCRIPTION7,CODE8,ITEMCODE8,TITLE8,QUANTITY8,UNIT8,UFACT8,DESCRIPTION8,CODE9,ITEMCODE9,TITLE9,QUANTITY9,UNIT9,UFACT9,DESCRIPTION9) 
' 
ELSE
SET @Wbs1PartOuterApply =''
IF @wbs2 =1
SET @Wbs2PartOuterApply ='
cross apply (select SUBSTRING(o.WBS2CODE,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.WBS2CODE))+' + CHAR(39) + '.' + CHAR(39) + ') as WBS2(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY))) as WBS2_1(Pos)
  cross apply (SELECT CASE WHEN WBS2_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_1.Pos+1))) ELSE -1 END) as WBS2_2(Pos)
  cross apply (SELECT CASE WHEN WBS2_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_2.Pos+1))) ELSE -1 END) as WBS2_3(Pos)
  cross apply (SELECT CASE WHEN WBS2_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_3.Pos+1))) ELSE -1 END) as WBS2_4(Pos)
  cross apply (SELECT CASE WHEN WBS2_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_4.Pos+1))) ELSE -1 END) as WBS2_5(Pos)
  cross apply (SELECT CASE WHEN WBS2_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_5.Pos+1))) ELSE -1 END) as WBS2_6(Pos)
  cross apply (SELECT CASE WHEN WBS2_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_6.Pos+1))) ELSE -1 END) as WBS2_7(Pos)
  cross apply (SELECT CASE WHEN WBS2_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_7.Pos+1))) ELSE -1 END) as WBS2_8(Pos)
  cross apply (SELECT CASE WHEN WBS2_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', WBS2.CODEONLY, WBS2_8.Pos+1))) ELSE -1 END) as WBS2_9(Pos)
  cross apply (
        select (CASE WHEN WBS2_1.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN WBS2_2.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_2.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_3.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_3.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_4.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_4.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_5.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_5.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_6.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_6.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_7.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_7.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_8.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_8.Pos-1) ELSE NULL END),
		       (CASE WHEN WBS2_9.Pos>1 THEN LEFT(WBS2.CODEONLY,WBS2_9.Pos-1) ELSE NULL END)
	) AS WBSCODE2(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.CODE) as CODE1, max(l1.ITEMCODE) as ITEMCODE1, max(l1.TITLE) as TITLE1, max(l1.QUANTITY) as QUANTITY1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.DESCRIPTION) as DESCRIPTION1,
		max(l2.CODE) as CODE2, max(l2.ITEMCODE) as ITEMCODE2, max(l2.TITLE) as TITLE1, max(l2.QUANTITY) as QUANTITY2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.DESCRIPTION) as DESCRIPTION2,
		max(l3.CODE) as CODE3, max(l3.ITEMCODE) as ITEMCODE3, max(l3.TITLE) as TITLE1, max(l3.QUANTITY) as QUANTITY3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.DESCRIPTION) as DESCRIPTION3,
		max(l4.CODE) as CODE4, max(l4.ITEMCODE) as ITEMCODE4, max(l4.TITLE) as TITLE1, max(l4.QUANTITY) as QUANTITY4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.DESCRIPTION) as DESCRIPTION4,
		max(l5.CODE) as CODE5, max(l5.ITEMCODE) as ITEMCODE5, max(l5.TITLE) as TITLE1, max(l5.QUANTITY) as QUANTITY5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.DESCRIPTION) as DESCRIPTION5,
		max(l6.CODE) as CODE6, max(l6.ITEMCODE) as ITEMCODE6, max(l6.TITLE) as TITLE1, max(l6.QUANTITY) as QUANTITY6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.DESCRIPTION) as DESCRIPTION6,
		max(l7.CODE) as CODE7, max(l7.ITEMCODE) as ITEMCODE7, max(l7.TITLE) as TITLE1, max(l7.QUANTITY) as QUANTITY7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.DESCRIPTION) as DESCRIPTION7,
		max(l8.CODE) as CODE8, max(l8.ITEMCODE) as ITEMCODE8, max(l8.TITLE) as TITLE1, max(l8.QUANTITY) as QUANTITY8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.DESCRIPTION) as DESCRIPTION8,
		max(l9.CODE) as CODE9, max(l9.ITEMCODE) as ITEMCODE9, max(l9.TITLE) as TITLE1, max(l9.QUANTITY) as QUANTITY9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.DESCRIPTION) as DESCRIPTION9
		from '+@Dbname+'.dbo.PROJECTWBS2 as l1 with(nolock)
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l2 WITH (NOLOCK) ON l2.CODE = WBSCODE2.LEVEL2 AND l2.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l3 WITH (NOLOCK) ON l3.CODE = WBSCODE2.LEVEL3 AND l3.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l4 WITH (NOLOCK) ON l4.CODE = WBSCODE2.LEVEL4 AND l4.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l5 WITH (NOLOCK) ON l5.CODE = WBSCODE2.LEVEL5 AND l5.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l6 WITH (NOLOCK) ON l6.CODE = WBSCODE2.LEVEL6 AND l6.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l7 WITH (NOLOCK) ON l7.CODE = WBSCODE2.LEVEL7 AND l7.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l8 WITH (NOLOCK) ON l8.CODE = WBSCODE2.LEVEL8 AND l8.PRJID = ' + cast(@PrjId as varchar(max)) + '
			 left join '+@Dbname+'.dbo.PROJECTWBS2 l9 WITH (NOLOCK) ON l9.CODE = WBSCODE2.LEVEL9 AND l9.PRJID = ' + cast(@PrjId as varchar(max)) + '
		where l1.CODE = WBSCODE2.LEVEL1 AND l1.PRJID = ' + cast(@PrjId as varchar(max)) + '
  ) AS WBSCODE2DATA(CODE1,ITEMCODE1,TITLE1,QUANTITY1,UNIT1,UFACT1,DESCRIPTION1,CODE2,ITEMCODE2,TITLE2,QUANTITY2,UNIT2,UFACT2,DESCRIPTION2,CODE3,ITEMCODE3,TITLE3,QUANTITY3,UNIT3,UFACT3,DESCRIPTION3,CODE4,ITEMCODE4,TITLE4,QUANTITY4,UNIT4,UFACT4,DESCRIPTION4,CODE5,ITEMCODE5,TITLE5,QUANTITY5,UNIT5,UFACT5,DESCRIPTION5,CODE6,ITEMCODE6,TITLE6,QUANTITY6,UNIT6,UFACT6,DESCRIPTION6,CODE7,ITEMCODE7,TITLE7,QUANTITY7,UNIT7,UFACT7,DESCRIPTION7,CODE8,ITEMCODE8,TITLE8,QUANTITY8,UNIT8,UFACT8,DESCRIPTION8,CODE9,ITEMCODE9,TITLE9,QUANTITY9,UNIT9,UFACT9,DESCRIPTION9) '
ELSE
SET @Wbs2PartOuterApply =''
IF @groupCode1 =1	
SET @GRoupCode1PartCrossApply ='
cross apply (select SUBSTRING(o.GROUPCODE,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.GROUPCODE))+' + CHAR(39) + '.' + CHAR(39) + ') as GC1(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY))) as GC1_1(Pos)
  cross apply (SELECT CASE WHEN GC1_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_1.Pos+1))) ELSE -1 END) as GC1_2(Pos)
  cross apply (SELECT CASE WHEN GC1_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_2.Pos+1))) ELSE -1 END) as GC1_3(Pos)
  cross apply (SELECT CASE WHEN GC1_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_3.Pos+1))) ELSE -1 END) as GC1_4(Pos)
  cross apply (SELECT CASE WHEN GC1_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_4.Pos+1))) ELSE -1 END) as GC1_5(Pos)
  cross apply (SELECT CASE WHEN GC1_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_5.Pos+1))) ELSE -1 END) as GC1_6(Pos)
  cross apply (SELECT CASE WHEN GC1_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_6.Pos+1))) ELSE -1 END) as GC1_7(Pos)
  cross apply (SELECT CASE WHEN GC1_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_7.Pos+1))) ELSE -1 END) as GC1_8(Pos)
  cross apply (SELECT CASE WHEN GC1_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC1.CODEONLY, GC1_8.Pos+1))) ELSE -1 END) as GC1_9(Pos)
  cross apply (
        select (CASE WHEN GC1_1.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC1_2.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_3.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_4.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_5.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_6.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_7.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_8.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC1_9.Pos>1 THEN LEFT(GC1.CODEONLY,GC1_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE1(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from GROUPCODE as l1 with(nolock)
			 left join GROUPCODE l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE1.LEVEL2    
			 left join GROUPCODE l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE1.LEVEL3
			 left join GROUPCODE l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE1.LEVEL4
			 left join GROUPCODE l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE1.LEVEL5
			 left join GROUPCODE l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE1.LEVEL6
			 left join GROUPCODE l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE1.LEVEL7
			 left join GROUPCODE l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE1.LEVEL8 
			 left join GROUPCODE l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE1.LEVEL9
		where l1.GROUPCODE = GROUPCODE1.LEVEL1
  ) AS GROUPCODE1DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
' 
ELSE
SET @GRoupCode1PartCrossApply =''
IF @groupCode2 =1	
SET @GRoupCode2PartCrossApply =' 
 cross apply (select SUBSTRING(o.GEKCODE,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.GEKCODE))+' + CHAR(39) + '.' + CHAR(39) + ') as GC2(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY))) as GC2_1(Pos)
  cross apply (SELECT CASE WHEN GC2_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_1.Pos+1))) ELSE -1 END) as GC2_2(Pos)
  cross apply (SELECT CASE WHEN GC2_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_2.Pos+1))) ELSE -1 END) as GC2_3(Pos)
  cross apply (SELECT CASE WHEN GC2_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_3.Pos+1))) ELSE -1 END) as GC2_4(Pos)
  cross apply (SELECT CASE WHEN GC2_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_4.Pos+1))) ELSE -1 END) as GC2_5(Pos)
  cross apply (SELECT CASE WHEN GC2_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_5.Pos+1))) ELSE -1 END) as GC2_6(Pos)
  cross apply (SELECT CASE WHEN GC2_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_6.Pos+1))) ELSE -1 END) as GC2_7(Pos)
  cross apply (SELECT CASE WHEN GC2_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_7.Pos+1))) ELSE -1 END) as GC2_8(Pos)
  cross apply (SELECT CASE WHEN GC2_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC2.CODEONLY, GC2_8.Pos+1))) ELSE -1 END) as GC2_9(Pos)
  cross apply (
        select (CASE WHEN GC2_1.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC2_2.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_3.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_4.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_5.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_6.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_7.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_8.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC2_9.Pos>1 THEN LEFT(GC2.CODEONLY,GC2_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE2(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from GEKCODE as l1 with(nolock)
			 left join GEKCODE l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE2.LEVEL2    
			 left join GEKCODE l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE2.LEVEL3
			 left join GEKCODE l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE2.LEVEL4
			 left join GEKCODE l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE2.LEVEL5
			 left join GEKCODE l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE2.LEVEL6
			 left join GEKCODE l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE2.LEVEL7
			 left join GEKCODE l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE2.LEVEL8 
			 left join GEKCODE l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE2.LEVEL9
		where l1.GROUPCODE = GROUPCODE2.LEVEL1
  ) AS GROUPCODE2DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode2PartCrossApply =''
IF @groupCode3 =1
SET @GRoupCode3PartCrossApply =' 
 cross apply (select SUBSTRING(o.EXTRACODE1,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE1))+' + CHAR(39) + '.' + CHAR(39) + ') as GC3(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY))) as GC3_1(Pos)
  cross apply (SELECT CASE WHEN GC3_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_1.Pos+1))) ELSE -1 END) as GC3_2(Pos)
  cross apply (SELECT CASE WHEN GC3_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_2.Pos+1))) ELSE -1 END) as GC3_3(Pos)
  cross apply (SELECT CASE WHEN GC3_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_3.Pos+1))) ELSE -1 END) as GC3_4(Pos)
  cross apply (SELECT CASE WHEN GC3_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_4.Pos+1))) ELSE -1 END) as GC3_5(Pos)
  cross apply (SELECT CASE WHEN GC3_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_5.Pos+1))) ELSE -1 END) as GC3_6(Pos)
  cross apply (SELECT CASE WHEN GC3_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_6.Pos+1))) ELSE -1 END) as GC3_7(Pos)
  cross apply (SELECT CASE WHEN GC3_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_7.Pos+1))) ELSE -1 END) as GC3_8(Pos)
  cross apply (SELECT CASE WHEN GC3_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC3.CODEONLY, GC3_8.Pos+1))) ELSE -1 END) as GC3_9(Pos)
  cross apply (
        select (CASE WHEN GC3_1.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC3_2.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_3.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_4.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_5.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_6.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_7.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_8.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC3_9.Pos>1 THEN LEFT(GC3.CODEONLY,GC3_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE3(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE1 as l1 with(nolock)
			 left join EXTRACODE1 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE3.LEVEL2    
			 left join EXTRACODE1 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE3.LEVEL3
			 left join EXTRACODE1 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE3.LEVEL4
			 left join EXTRACODE1 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE3.LEVEL5
			 left join EXTRACODE1 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE3.LEVEL6
			 left join EXTRACODE1 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE3.LEVEL7
			 left join EXTRACODE1 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE3.LEVEL8 
			 left join EXTRACODE1 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE3.LEVEL9
		where l1.GROUPCODE = GROUPCODE3.LEVEL1
  ) AS GROUPCODE3DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode3PartCrossApply =''
IF @groupCode4 =1
SET @GRoupCode4PartCrossApply =' 
 cross apply (select SUBSTRING(o.EXTRACODE2,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE2))+' + CHAR(39) + '.' + CHAR(39) + ') as GC4(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY))) as GC4_1(Pos)
  cross apply (SELECT CASE WHEN GC4_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_1.Pos+1))) ELSE -1 END) as GC4_2(Pos)
  cross apply (SELECT CASE WHEN GC4_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_2.Pos+1))) ELSE -1 END) as GC4_3(Pos)
  cross apply (SELECT CASE WHEN GC4_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_3.Pos+1))) ELSE -1 END) as GC4_4(Pos)
  cross apply (SELECT CASE WHEN GC4_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_4.Pos+1))) ELSE -1 END) as GC4_5(Pos)
  cross apply (SELECT CASE WHEN GC4_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_5.Pos+1))) ELSE -1 END) as GC4_6(Pos)
  cross apply (SELECT CASE WHEN GC4_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_6.Pos+1))) ELSE -1 END) as GC4_7(Pos)
  cross apply (SELECT CASE WHEN GC4_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_7.Pos+1))) ELSE -1 END) as GC4_8(Pos)
  cross apply (SELECT CASE WHEN GC4_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC4.CODEONLY, GC4_8.Pos+1))) ELSE -1 END) as GC4_9(Pos)
  cross apply (
        select (CASE WHEN GC4_1.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC4_2.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_3.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_4.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_5.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_6.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_7.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_8.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC4_9.Pos>1 THEN LEFT(GC4.CODEONLY,GC4_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE4(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE2 as l1 with(nolock)
			 left join EXTRACODE2 l2 ON l2.GROUPCODE = GROUPCODE4.LEVEL2    
			 left join EXTRACODE2 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE4.LEVEL3
			 left join EXTRACODE2 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE4.LEVEL4
			 left join EXTRACODE2 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE4.LEVEL5
			 left join EXTRACODE2 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE4.LEVEL6
			 left join EXTRACODE2 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE4.LEVEL7
			 left join EXTRACODE2 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE4.LEVEL8 
			 left join EXTRACODE2 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE4.LEVEL9
		where l1.GROUPCODE = GROUPCODE4.LEVEL1
  ) AS GROUPCODE4DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) '
ELSE
SET @GRoupCode4PartCrossApply =''
IF @groupCode5 =1
SET @GRoupCode5PartCrossApply ='
  cross apply (select SUBSTRING(o.EXTRACODE3,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE3))+' + CHAR(39) + '.' + CHAR(39) + ') as GC5(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY))) as GC5_1(Pos)
  cross apply (SELECT CASE WHEN GC5_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_1.Pos+1))) ELSE -1 END) as GC5_2(Pos)
  cross apply (SELECT CASE WHEN GC5_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_2.Pos+1))) ELSE -1 END) as GC5_3(Pos)
  cross apply (SELECT CASE WHEN GC5_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_3.Pos+1))) ELSE -1 END) as GC5_4(Pos)
  cross apply (SELECT CASE WHEN GC5_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_4.Pos+1))) ELSE -1 END) as GC5_5(Pos)
  cross apply (SELECT CASE WHEN GC5_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_5.Pos+1))) ELSE -1 END) as GC5_6(Pos)
  cross apply (SELECT CASE WHEN GC5_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_6.Pos+1))) ELSE -1 END) as GC5_7(Pos)
  cross apply (SELECT CASE WHEN GC5_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_7.Pos+1))) ELSE -1 END) as GC5_8(Pos)
  cross apply (SELECT CASE WHEN GC5_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC5.CODEONLY, GC5_8.Pos+1))) ELSE -1 END) as GC5_9(Pos)
  cross apply (
        select (CASE WHEN GC5_1.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC5_2.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_3.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_4.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_5.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_6.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_7.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_8.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC5_9.Pos>1 THEN LEFT(GC5.CODEONLY,GC5_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE5(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE3 as l1 with(nolock)
			 left join EXTRACODE3 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE5.LEVEL2    
			 left join EXTRACODE3 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE5.LEVEL3
			 left join EXTRACODE3 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE5.LEVEL4
			 left join EXTRACODE3 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE5.LEVEL5
			 left join EXTRACODE3 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE5.LEVEL6
			 left join EXTRACODE3 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE5.LEVEL7
			 left join EXTRACODE3 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE5.LEVEL8 
			 left join EXTRACODE3 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE5.LEVEL9
		where l1.GROUPCODE = GROUPCODE5.LEVEL1
  ) AS GROUPCODE5DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode5PartCrossApply =''
IF @groupCode6 =1
SET @GRoupCode6PartCrossApply ='  
cross apply (select SUBSTRING(o.EXTRACODE4,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE4))+' + CHAR(39) + '.' + CHAR(39) + ') as GC6(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY))) as GC6_1(Pos)
  cross apply (SELECT CASE WHEN GC6_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_1.Pos+1))) ELSE -1 END) as GC6_2(Pos)
  cross apply (SELECT CASE WHEN GC6_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_2.Pos+1))) ELSE -1 END) as GC6_3(Pos)
  cross apply (SELECT CASE WHEN GC6_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_3.Pos+1))) ELSE -1 END) as GC6_4(Pos)
  cross apply (SELECT CASE WHEN GC6_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_4.Pos+1))) ELSE -1 END) as GC6_5(Pos)
  cross apply (SELECT CASE WHEN GC6_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_5.Pos+1))) ELSE -1 END) as GC6_6(Pos)
  cross apply (SELECT CASE WHEN GC6_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_6.Pos+1))) ELSE -1 END) as GC6_7(Pos)
  cross apply (SELECT CASE WHEN GC6_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_7.Pos+1))) ELSE -1 END) as GC6_8(Pos)
  cross apply (SELECT CASE WHEN GC6_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC6.CODEONLY, GC6_8.Pos+1))) ELSE -1 END) as GC6_9(Pos)
  cross apply (
        select (CASE WHEN GC6_1.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC6_2.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_3.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_4.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_5.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_6.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_7.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_8.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC6_9.Pos>1 THEN LEFT(GC6.CODEONLY,GC6_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE6(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE4 as l1 with(nolock)
			 left join EXTRACODE4 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE6.LEVEL2    
			 left join EXTRACODE4 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE6.LEVEL3
			 left join EXTRACODE4 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE6.LEVEL4
			 left join EXTRACODE4 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE6.LEVEL5
			 left join EXTRACODE4 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE6.LEVEL6
			 left join EXTRACODE4 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE6.LEVEL7
			 left join EXTRACODE4 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE6.LEVEL8 
			 left join EXTRACODE4 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE6.LEVEL9
		where l1.GROUPCODE = GROUPCODE6.LEVEL1
  ) AS GROUPCODE6DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode6PartCrossApply =''
IF @groupCode7 =1
SET @GRoupCode7PartCrossApply ='

  cross apply (select SUBSTRING(o.EXTRACODE5,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE5))+' + CHAR(39) + '.' + CHAR(39) + ') as GC7(CODEONLY) 
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY))) as GC7_1(Pos)
  cross apply (SELECT CASE WHEN GC7_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_1.Pos+1))) ELSE -1 END) as GC7_2(Pos)
  cross apply (SELECT CASE WHEN GC7_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_2.Pos+1))) ELSE -1 END) as GC7_3(Pos)
  cross apply (SELECT CASE WHEN GC7_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_3.Pos+1))) ELSE -1 END) as GC7_4(Pos)
  cross apply (SELECT CASE WHEN GC7_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_4.Pos+1))) ELSE -1 END) as GC7_5(Pos)
  cross apply (SELECT CASE WHEN GC7_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_5.Pos+1))) ELSE -1 END) as GC7_6(Pos)
  cross apply (SELECT CASE WHEN GC7_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_6.Pos+1))) ELSE -1 END) as GC7_7(Pos)
  cross apply (SELECT CASE WHEN GC7_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_7.Pos+1))) ELSE -1 END) as GC7_8(Pos)
  cross apply (SELECT CASE WHEN GC7_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC7.CODEONLY, GC7_8.Pos+1))) ELSE -1 END) as GC7_9(Pos)
  cross apply (
        select (CASE WHEN GC7_1.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC7_2.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_3.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_4.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_5.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_6.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_7.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_8.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC7_9.Pos>1 THEN LEFT(GC7.CODEONLY,GC7_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE7(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE5 as l1 with(nolock) 
			 left join EXTRACODE5 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE7.LEVEL2    
			 left join EXTRACODE5 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE7.LEVEL3
			 left join EXTRACODE5 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE7.LEVEL4
			 left join EXTRACODE5 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE7.LEVEL5
			 left join EXTRACODE5 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE7.LEVEL6
			 left join EXTRACODE5 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE7.LEVEL7
			 left join EXTRACODE5 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE7.LEVEL8 
			 left join EXTRACODE5 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE7.LEVEL9
		where l1.GROUPCODE = GROUPCODE7.LEVEL1
  ) AS GROUPCODE7DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'	
ELSE
SET @GRoupCode7PartCrossApply =''
IF @groupCode8 =1
SET @GRoupCode8PartCrossApply ='
 cross apply (select SUBSTRING(o.EXTRACODE6,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE6))+' + CHAR(39) + '.' + CHAR(39) + ') as GC8(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY))) as GC8_1(Pos)
  cross apply (SELECT CASE WHEN GC8_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_1.Pos+1))) ELSE -1 END) as GC8_2(Pos)
  cross apply (SELECT CASE WHEN GC8_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_2.Pos+1))) ELSE -1 END) as GC8_3(Pos)
  cross apply (SELECT CASE WHEN GC8_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_3.Pos+1))) ELSE -1 END) as GC8_4(Pos)
  cross apply (SELECT CASE WHEN GC8_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_4.Pos+1))) ELSE -1 END) as GC8_5(Pos)
  cross apply (SELECT CASE WHEN GC8_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_5.Pos+1))) ELSE -1 END) as GC8_6(Pos)
  cross apply (SELECT CASE WHEN GC8_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_6.Pos+1))) ELSE -1 END) as GC8_7(Pos)
  cross apply (SELECT CASE WHEN GC8_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_7.Pos+1))) ELSE -1 END) as GC8_8(Pos)
  cross apply (SELECT CASE WHEN GC8_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC8.CODEONLY, GC8_8.Pos+1))) ELSE -1 END) as GC8_9(Pos)
  cross apply (
        select (CASE WHEN GC8_1.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC8_2.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_3.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_4.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_5.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_6.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_7.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_8.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC8_9.Pos>1 THEN LEFT(GC8.CODEONLY,GC8_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE8(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE6 as l1 with(nolock) 
			 left join EXTRACODE6 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE8.LEVEL2    
			 left join EXTRACODE6 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE8.LEVEL3
			 left join EXTRACODE6 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE8.LEVEL4
			 left join EXTRACODE6 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE8.LEVEL5
			 left join EXTRACODE6 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE8.LEVEL6
			 left join EXTRACODE6 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE8.LEVEL7
			 left join EXTRACODE6 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE8.LEVEL8 
			 left join EXTRACODE6 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE8.LEVEL9
		where l1.GROUPCODE = GROUPCODE8.LEVEL1
  ) AS GROUPCODE8DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode8PartCrossApply =''
IF @groupCode9 =1
SET @GRoupCode9PartCrossApply =' 
 cross apply (select SUBSTRING(o.EXTRACODE7,0,CHARINDEX(' + CHAR(39) + '-' + CHAR(39) + ',o.EXTRACODE7))+' + CHAR(39) + '.' + CHAR(39) + ') as GC9(CODEONLY)
  cross apply (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY))) as GC9_1(Pos)
  cross apply (SELECT CASE WHEN GC9_1.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_1.Pos+1))) ELSE -1 END) as GC9_2(Pos)
  cross apply (SELECT CASE WHEN GC9_2.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_2.Pos+1))) ELSE -1 END) as GC9_3(Pos)
  cross apply (SELECT CASE WHEN GC9_3.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_3.Pos+1))) ELSE -1 END) as GC9_4(Pos)
  cross apply (SELECT CASE WHEN GC9_4.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_4.Pos+1))) ELSE -1 END) as GC9_5(Pos)
  cross apply (SELECT CASE WHEN GC9_5.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_5.Pos+1))) ELSE -1 END) as GC9_6(Pos)
  cross apply (SELECT CASE WHEN GC9_6.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_6.Pos+1))) ELSE -1 END) as GC9_7(Pos)
  cross apply (SELECT CASE WHEN GC9_7.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_7.Pos+1))) ELSE -1 END) as GC9_8(Pos)
  cross apply (SELECT CASE WHEN GC9_8.Pos>1 THEN (select (charindex(' + CHAR(39) + '.' + CHAR(39) + ', GC9.CODEONLY, GC9_8.Pos+1))) ELSE -1 END) as GC9_9(Pos)
  cross apply (
        select (CASE WHEN GC9_1.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_1.Pos-1) ELSE NULL END), 
		       (CASE WHEN GC9_2.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_2.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_3.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_3.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_4.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_4.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_5.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_5.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_6.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_6.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_7.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_7.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_8.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_8.Pos-1) ELSE NULL END),
		       (CASE WHEN GC9_9.Pos>1 THEN LEFT(GC9.CODEONLY,GC9_9.Pos-1) ELSE NULL END)
	) AS GROUPCODE9(LEVEL1,LEVEL2,LEVEL3,LEVEL4,LEVEL5,LEVEL6,LEVEL7,LEVEL8,LEVEL9) 
  outer apply (
	select
		max(l1.GROUPCODE) as CODE1, max(l1.TITLE) as TITLE1, max(l1.DESCRIPTION) as DESCRIPTION1, max(l1.UNIT) as UNIT1, max(l1.UFACT) as UFACT1, max(l1.NOTES) as NOTES1,
		max(l2.GROUPCODE) as CODE2, max(l2.TITLE) as TITLE2, max(l2.DESCRIPTION) as DESCRIPTION2, max(l2.UNIT) as UNIT2, max(l2.UFACT) as UFACT2, max(l2.NOTES) as NOTES2,
		max(l3.GROUPCODE) as CODE3, max(l3.TITLE) as TITLE3, max(l3.DESCRIPTION) as DESCRIPTION3, max(l3.UNIT) as UNIT3, max(l3.UFACT) as UFACT3, max(l3.NOTES) as NOTES3,
		max(l4.GROUPCODE) as CODE4, max(l4.TITLE) as TITLE4, max(l4.DESCRIPTION) as DESCRIPTION4, max(l4.UNIT) as UNIT4, max(l4.UFACT) as UFACT4, max(l4.NOTES) as NOTES4,
		max(l5.GROUPCODE) as CODE5, max(l5.TITLE) as TITLE5, max(l5.DESCRIPTION) as DESCRIPTION5, max(l5.UNIT) as UNIT5, max(l5.UFACT) as UFACT5, max(l5.NOTES) as NOTES5,
		max(l6.GROUPCODE) as CODE6, max(l6.TITLE) as TITLE6, max(l6.DESCRIPTION) as DESCRIPTION6, max(l6.UNIT) as UNIT6, max(l6.UFACT) as UFACT6, max(l6.NOTES) as NOTES6,
		max(l7.GROUPCODE) as CODE7, max(l7.TITLE) as TITLE7, max(l7.DESCRIPTION) as DESCRIPTION7, max(l7.UNIT) as UNIT7, max(l7.UFACT) as UFACT7, max(l7.NOTES) as NOTES7,
		max(l8.GROUPCODE) as CODE8, max(l8.TITLE) as TITLE8, max(l8.DESCRIPTION) as DESCRIPTION8, max(l8.UNIT) as UNIT8, max(l8.UFACT) as UFACT8, max(l8.NOTES) as NOTES8,
		max(l9.GROUPCODE) as CODE9, max(l9.TITLE) as TITLE9, max(l9.DESCRIPTION) as DESCRIPTION9, max(l9.UNIT) as UNIT9, max(l9.UFACT) as UFACT9, max(l9.NOTES) as NOTES9
		from EXTRACODE7  as l1 with(nolock) 
			 left join EXTRACODE7 l2 WITH (NOLOCK) ON l2.GROUPCODE = GROUPCODE9.LEVEL2    
			 left join EXTRACODE7 l3 WITH (NOLOCK) ON l3.GROUPCODE = GROUPCODE9.LEVEL3
			 left join EXTRACODE7 l4 WITH (NOLOCK) ON l4.GROUPCODE = GROUPCODE9.LEVEL4
			 left join EXTRACODE7 l5 WITH (NOLOCK) ON l5.GROUPCODE = GROUPCODE9.LEVEL5
			 left join EXTRACODE7 l6 WITH (NOLOCK) ON l6.GROUPCODE = GROUPCODE9.LEVEL6
			 left join EXTRACODE7 l7 WITH (NOLOCK) ON l7.GROUPCODE = GROUPCODE9.LEVEL7
			 left join EXTRACODE7 l8 WITH (NOLOCK) ON l8.GROUPCODE = GROUPCODE9.LEVEL8 
			 left join EXTRACODE7 l9 WITH (NOLOCK) ON l9.GROUPCODE = GROUPCODE9.LEVEL9
		where l1.GROUPCODE = GROUPCODE9.LEVEL1
  ) AS GROUPCODE9DATA(CODE1,TITLE1,DESCRIPTION1,UNIT1,UFACT1,NOTES1,CODE2,TITLE2,DESCRIPTION2,UNIT2,UFACT2,NOTES2,CODE3,TITLE3,DESCRIPTION3,UNIT3,UFACT3,NOTES3,CODE4,TITLE4,DESCRIPTION4,UNIT4,UFACT4,NOTES4,CODE5,TITLE5,DESCRIPTION5,UNIT5,UFACT5,NOTES5,CODE6,TITLE6,DESCRIPTION6,UNIT6,UFACT6,NOTES6,CODE7,TITLE7,DESCRIPTION7,UNIT7,UFACT7,NOTES7,CODE8,TITLE8,DESCRIPTION8,UNIT8,UFACT8,NOTES8,CODE9,TITLE9,DESCRIPTION9,UNIT9,UFACT9,NOTES9) 
'
ELSE
SET @GRoupCode9PartCrossApply =''

SET @SqlQuery =
'
'+@MainPart+'
o.WBSCODE    AS boqItemWbsCode1,

/* WBSCODE1 */
'+@Wbs1Part+'
/* WBSCODE1 */

o.WBS2CODE   AS boqItemWbsCode2,

/* WBSCODE2 */
'+
@Wbs2Part
+'
/* WBSCODE2 */

 o.GROUPCODE  AS boqItemGroupCode1, 

/* START GRPOUPCODE1 */
'+
@GRoupCode1Part
+'
/* END GRPOUPCODE1 */

o.GEKCODE    AS boqItemGroupCode2,

/* START GRPOUPCODE2 */
'+
@GRoupCode2Part
+'
/* END GROUPCODE2 */

o.EXTRACODE1 AS boqItemGroupCode3,

/* START GROUPCODE3 */
'+
@GRoupCode3Part
+'
/* END GROUPCODE3 */

o.EXTRACODE2 AS boqItemGroupCode4,
/* START GROUPCODE4 */
'+
@GRoupCode4Part
+'
/* END GROUPCODE4 */

o.EXTRACODE3 AS boqItemGroupCode5,
/* START GROUPCODE5 */
'+
@GRoupCode5Part
+'
/* END GROUPCODE5 */

o.EXTRACODE4 AS boqItemGroupCode6,

/* START GROUPCODE6 */
'+
@GRoupCode6Part
+'
/* END GROUPCODE6 */

o.EXTRACODE5 AS boqItemGroupCode7,

/* START GROUPCODE7 */
'+
@GRoupCode7Part
+'
/* END GROUPCODE7 */

o.EXTRACODE6 AS boqItemGroupCode8,
/* START GROUPCODE8 */
'+
@GRoupCode8Part
+'
/* END GROUPCODE8 */

o.EXTRACODE7 AS boqItemGroupCode9,

/* START GROUPCODE9 */
'+
@GRoupCode9Part
+'
/* END GROUPCODE9 */

o.LOCATION   AS boqItemLocation,
o.DESCRIPTION AS boqItemDescription,
o.NOTES AS boqItemNotes,
o.ASRT AS boqItemAssemblyRateType,
o.EQRT AS boqItemEquipmentRateType,
o.LBRT AS boqItemLaborRateType,
o.SBRT AS boqItemSubcontractorRateType,
o.MART AS boqItemMaterialRateType,
o.CMRT AS boqItemConsumableRateType,
o.CNQT AS boqItemTakeoffQuantityType
FROM '+@Dbname+'.dbo.BOQITEM  AS o with(nolock) 
left outer join UNITALIAS as ua1 WITH (NOLOCK) ON ua1.FRUNIT = o.UNIT
left outer join UNITALIAS as ua2 WITH (NOLOCK) ON ua2.FRUNIT = o.SECOND_UNIT

/* START WBS CODE1 */
'+
@Wbs1PartOuterApply
+'
/* END WBS CODE1 */

/* START WBS CODE2 */
'+
@Wbs2PartOuterApply
+'  
/* END WBS CODE2 */
/* START GROUP CODE1 */
'+
@GRoupCode1PartCrossApply
+'
/* END GROUP CODE1 */
/* START GROUPCODE2 */
'+
@GRoupCode2PartCrossApply
+'
/* END GROUPCODE2 */
/* START GROUPCODE3 */
'+
@GRoupCode3PartCrossApply
+'
/* END GROUPCODE3 */
/* START GROUPCODE4 */
'+
@GRoupCode4PartCrossApply
+'
/* END GROUPCODE4 */
/* START GROUPCODE5 */
'+
@GRoupCode5PartCrossApply
+'
/* END GROUPCODE5 */
/* START GROUPCODE6 */
'+
@GRoupCode6PartCrossApply
+'
/* END GROUPCODE6 */
/* START GROUPCODE7 */
'+
@GRoupCode7PartCrossApply
+'
/* END GROUPCODE7 */
/* START GROUPCODE8 */
'+
@GRoupCode8PartCrossApply
+'
/* END GROUPCODE8 */
/* START GROUPCODE9 */
'+
@GRoupCode9PartCrossApply
+'
/* END GROUPCODE9 */
,
/* JOIN PROJECT PROPERTIES WITH (NOLOCK) IN k */
  (SELECT 
     MAX([project.code]) AS [projectCode],
	 MAX([project.name]) AS [projectName],
	 MAX([project.eps])  AS [projectEPS],
	 MAX([project.currency.symbol])  AS [projectCurrency],
	 MAX([project.country])  AS [projectCountry],
	 MAX([project.client.name]) AS [projectClientName],
	 MAX([project.client.budget]) AS [projectClientBudget],
	 MAX([project.mainsqm]) AS [projectJobSize],
	 MAX([project.unit]) AS [projectUnit],
	 MAX([project.basementsqm]) AS [projectBasementSize],
	 MAX([project.floors]) AS [projectDuration]
	 
	FROM (select PKEY,PVAL from '+@Dbname+'.dbo.PRJPROP with(nolock) WHERE PRJID = ' + cast(@PrjId as varchar(max)) +' AND PKEY LIKE ' + CHAR(39) + 'pro%' + CHAR(39) + ') PropTable PIVOT
	(
		MAX([PVAL]) FOR [PKEY] IN (
			   [project.code],
			   [project.name],
			   [project.eps],
			   [project.currency.symbol],
			   [project.country],
			   [project.client.name],
			   [project.client.budget],
			   [project.mainsqm],
			   [project.unit],
			   [project.basementsqm],
			   [project.floors])
	) T) as k
	
	WHERE o.PRJID = ' + cast(@PrjId as varchar(max))

--PRINT CAST(@SqlQuery AS NTEXT)

RETURN

END

