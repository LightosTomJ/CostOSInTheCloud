using System;

namespace Models.project
{
    [Serializable]
    public class BoqItemMaterial
    {

        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalMaterialRate", "finalFabricationRate", "finalShipmentRate", "finalRate", "totalMaterialCost", "totalFabricationCost", "totalShipmentCost", "totalCost", "escalation", "finalEscalationRate", "totalEscalationCost", "fixedCost", "finalFixedCost", "variableCost", "comment" };

        public long? boqItemMaterialId;
        public decimal factor1;
        public decimal factor2;
        public decimal escalation;
        public decimal factor3;
        public decimal quantityPerUnit;
        public string quantityPerUnitFormula;
        public sbyte? quantityPerUnitFormulaState;
        public decimal exchangeRate;
        public decimal totalUnits;
        public decimal finalMaterialRate;
        public decimal finalFabricationRate;
        public decimal finalShipmentRate;
        public decimal finalEscalationRate;
        public decimal finalRate;
        public decimal totalMaterialCost;
        public decimal totalFabricationCost;
        public decimal totalShipmentCost;
        public decimal totalEscalationCost;
        public decimal totalCost;
        public decimal localFactor;
        public string localCountry;
        public string localStateProvince;
        public bool? hasUserTotalUnits;
        public DateTime lastUpdate;
        public long? paramItemId;
        public BoqItemTable boqItemTable;
        //public ParamItem paramItemTable;
        //public Material materialTable;
        public QuoteItemTable quoteItemTable;

        // FIXED COST:
        public decimal fixedCost;
        public decimal finalFixedCost = decimal.Zero;
        public decimal variableCost = decimal.Zero;

        public string comment;
        public string pvVars;

        public BoqItemMaterial()
        { }
    }
}