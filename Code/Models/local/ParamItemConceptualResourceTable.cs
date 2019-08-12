using System;

namespace Model.local
{
    [Serializable]
    public class ParamItemConceptualResourceTable
    {
        public long? conceptualId { get; set; }
        public string title { get; set; }
        public string currency { get; set; }
        public string unit { get; set; }
        public string materialUnitRate { get; set; }
        public string materialFabricationRate { get; set; }
        public string materialShipmentRate { get; set; }
        public string subcontractorRate { get; set; }
        public string subcontractorIKA { get; set; }
        public string crewIds { get; set; }
        public string crewFactors { get; set; }
        public string titleConcatenation { get; set; }
        public string notesConcatenation { get; set; }
        public string descriptionConcatenation { get; set; }

        public string weightUnit { get; set; }
        public string weight { get; set; }
        /*OIL & GAS*/
        public string volFlow { get; set; }
        public string volFlowUnit { get; set; }
        public string massFlow { get; set; }
        public string massFlowUnit { get; set; }
        public string duty { get; set; }
        public string dutyUnit { get; set; }
        public string operPress { get; set; }
        public string operPressUnit { get; set; }
        public string operTemp { get; set; }
        public string operTempUnit { get; set; }
        /* oil & gas end */
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string extraCode1 { get; set; }
        public string extraCode2 { get; set; }
        public string extraCode3 { get; set; }
        public string extraCode4 { get; set; }
        public string extraCode5 { get; set; }
        public string extraCode6 { get; set; }
        public string extraCode7 { get; set; }

        public string rawMaterial1 { get; set; }
        public string rawMaterial2 { get; set; }
        public string rawMaterial3 { get; set; }
        public string rawMaterial4 { get; set; }
        public string rawMaterial5 { get; set; }
        public decimal reliance1 { get; set; }
        public decimal reliance2 { get; set; }
        public decimal reliance3 { get; set; }
        public decimal reliance4 { get; set; }
        public decimal reliance5 { get; set; }
        public DateTime refDate { get; set; }

        public ParamItemOutputTable paramItemOutputTable { get; set; }

        public string laborRate { get; set; }
        public string laborIKA { get; set; }
        public string consumableRate { get; set; }
        public string equipmentReservationRate { get; set; }
        public string equipmentLubricatesRate { get; set; }
        public string equipmentTiresRate { get; set; }
        public string equipmentSparePartsRate { get; set; }
        public string equipmentDepreciationRate { get; set; }
        public string equipmentFuelRate { get; set; }
        public string equipmentFuelConsumption { get; set; }
        public string equipmentFuelType { get; set; }

        // Custom Text
        public string customText1Equation { get; set; }
        public string customText2Equation { get; set; }
        public string customText3Equation { get; set; }
        public string customText4Equation { get; set; }
        public string customText5Equation { get; set; }
        public string customText6Equation { get; set; }
        public string customText7Equation { get; set; }
        public string customText8Equation { get; set; }
        public string customText9Equation { get; set; }
        public string customText10Equation { get; set; }
        public string customText11Equation { get; set; }
        public string customText12Equation { get; set; }
        public string customText13Equation { get; set; }
        public string customText14Equation { get; set; }
        public string customText15Equation { get; set; }
        public string customText16Equation { get; set; }
        public string customText17Equation { get; set; }
        public string customText18Equation { get; set; }
        public string customText19Equation { get; set; }
        public string customText20Equation { get; set; }
        public string customText21Equation { get; set; }
        public string customText22Equation { get; set; }
        public string customText23Equation { get; set; }
        public string customText24Equation { get; set; }
        public string customText25Equation { get; set; }


        // Custom Decimal
        public string customRate1Equation { get; set; }
        public string customRate2Equation { get; set; }
        public string customRate3Equation { get; set; }
        public string customRate4Equation { get; set; }
        public string customRate5Equation { get; set; }
        public string customRate6Equation { get; set; }
        public string customRate7Equation { get; set; }
        public string customRate8Equation { get; set; }
        public string customRate9Equation { get; set; }
        public string customRate10Equation { get; set; }
        public string customRate11Equation { get; set; }
        public string customRate12Equation { get; set; }
        public string customRate13Equation { get; set; }
        public string customRate14Equation { get; set; }
        public string customRate15Equation { get; set; }
        public string customRate16Equation { get; set; }
        public string customRate17Equation { get; set; }
        public string customRate18Equation { get; set; }
        public string customRate19Equation { get; set; }
        public string customRate20Equation { get; set; }

        // Custom Cumulative Rate
        public string customCumRate1Equation { get; set; }
        public string customCumRate2Equation { get; set; }
        public string customCumRate3Equation { get; set; }
        public string customCumRate4Equation { get; set; }
        public string customCumRate5Equation { get; set; }
        public string customCumRate6Equation { get; set; }
        public string customCumRate7Equation { get; set; }
        public string customCumRate8Equation { get; set; }
        public string customCumRate9Equation { get; set; }
        public string customCumRate10Equation { get; set; }
        public string customCumRate11Equation { get; set; }
        public string customCumRate12Equation { get; set; }
        public string customCumRate13Equation { get; set; }
        public string customCumRate14Equation { get; set; }
        public string customCumRate15Equation { get; set; }
        public string customCumRate16Equation { get; set; }
        public string customCumRate17Equation { get; set; }
        public string customCumRate18Equation { get; set; }
        public string customCumRate19Equation { get; set; }
        public string customCumRate20Equation { get; set; }

        public int? executionType { get; set; }

        public ParamItemConceptualResourceTable()
        { }
    }
}