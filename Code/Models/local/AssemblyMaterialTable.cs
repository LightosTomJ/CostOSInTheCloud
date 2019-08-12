using System;

namespace Model.local
{
    [Serializable]
    public class AssemblyMaterialTable
    {
        public static readonly decimal ONE = 1;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment" };

        public long? assemblyMaterialId { get; set; }
        public DateTime lastUpdate { get; set; }
        public decimal factor1 { get; set; }
        public decimal factor2 { get; set; }
        public decimal divider { get; set; }
        public decimal quantityPerUnit { get; set; }
        public string quantityPerUnitFormula { get; set; }
        public sbyte? quantityPerUnitFormulaState { get; set; }
        public decimal localFactor { get; set; }
        public string localCountry { get; set; }
        public string localStateProvince { get; set; }
        public decimal exchangeRate { get; set; }
        public long? materialTableId { get; set; }
        public MaterialTable materialTable { get; set; }
        public AssemblyTable assemblyTable { get; set; }
        public decimal finalRate { get; set; }
        public decimal fixedCost = decimal.Zero;
        public decimal finalFixedCost = decimal.Zero;
        public string comment { get; set; }
        public string pvVars { get; set; }

        public AssemblyMaterialTable()
        { }
    }
}