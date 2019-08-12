using System;

namespace Model.local
{
    [Serializable]
    public class AssemblyLaborTable
    {
        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment" };

        public long? assemblyLaborId { get; set; }
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
        public decimal exchangeRate { get; set; }
        public long? laborTableId { get; set; }
        public decimal finalRate { get; set; }
        public decimal finalIKARate { get; set; }
        public decimal fixedCost = decimal.Zero;
        public decimal finalFixedCost = decimal.Zero;
        public string comment { get; set; }
        public string pvVars { get; set; }

        public decimal unitHours { get; set; }

        public LaborTable laborTable { get; set; }
        public AssemblyTable assemblyTable { get; set; }

        public AssemblyLaborTable()
        { }
    }
}