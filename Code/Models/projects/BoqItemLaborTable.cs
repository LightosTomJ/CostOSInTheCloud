using System;

namespace Models.projects
{
    [Serializable]
    public class BoqItemLabor
    { 
        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment" };

        public long? boqItemLaborId;
        public decimal factor1;
        public decimal factor2;
        public decimal factor3;
        public decimal quantityPerUnit;
        public string quantityPerUnitFormula;
        public sbyte? quantityPerUnitFormulaState;
        public decimal exchangeRate;
        public decimal totalUnits;
        public decimal finalRate;
        public decimal totalCost;
        public decimal localFactor;
        public string localCountry;
        public string localStateProvince;
        public bool? hasUserTotalUnits;
        public DateTime lastUpdate;
        public long? paramItemId;

        // FIXED COST:
        public decimal fixedCost;
        public decimal finalFixedCost = decimal.Zero;
        public decimal variableCost = decimal.Zero;

        public string comment;
        public string pvVars;
        public decimal unitHours;
        //public ParamItem paramItemTable;
        public BoqItemTable boqItemTable;
        //public Labor laborTable;

        public BoqItemLabor()
        { }
    }
}