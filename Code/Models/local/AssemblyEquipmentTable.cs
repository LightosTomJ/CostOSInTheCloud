using System;

namespace Model.local
{
    [Serializable]
    public class AssemblyEquipmentTable
    {
        public static readonly decimal ONE = 1;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment" };

        public long? assemblyEquipmentId { get; set; }
        public DateTime lastUpdate { get; set; }
        public decimal factor1 { get; set; }
        public decimal factor2 { get; set; }
        public decimal factor3 { get; set; }
        public decimal quantityPerUnit { get; set; }
        public string quantityPerUnitFormula { get; set; }
        public sbyte? quantityPerUnitFormulaState { get; set; }
        public decimal localFactor { get; set; }
        public string localCountry { get; set; }
        public string localStateProvince { get; set; }
        public decimal energyPrice { get; set; }
        public decimal fuelRate { get; set; }
        public decimal exchangeRate { get; set; }
        public long? equipmentTableId { get; set; }
        public decimal finalRate { get; set; }
        public decimal finalDepreciationRate { get; set; }
        public decimal finalFuelRate { get; set; }
        public decimal fixedCost = decimal.Zero;
        public decimal finalFixedCost = decimal.Zero;
        public string comment { get; set; }
        public string pvVars { get; set; }

        public decimal unitHours { get; set; }

        public EquipmentTable equipmentTable { get; set; }
        public AssemblyTable assemblyTable { get; set; }

        public AssemblyEquipmentTable()
        { }
    }
}