using Model.local;
using System;

namespace Models.project
{

    [Serializable]
    public class BoqItemAssemblyTable
    {

        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment" };

        public long? boqItemAssemblyId;
        public decimal factor1;
        public decimal factor2;
        public decimal factor3;
        public decimal exchangeRate;
        public decimal totalUnits;
        public decimal finalRate;
        public decimal finalLaborRate;
        public decimal finalLaborManhours;
        public decimal finalEquipmentHours;
        public decimal finalMaterialRate;
        public decimal finalShipmentRate;
        public decimal finalFabricationRate;

        public decimal finalSubcontractorRate;

        public decimal finalEquipmentRate;
        public decimal finalConsumableRate;

        public decimal totalCost;
        public decimal laborCost;
        public decimal equipmentCost;
        public decimal subcontractorCost;
        public decimal materialTotalCost;
        public decimal consumableCost;

        public decimal quantityPerUnit;
        public string quantityPerUnitFormula;
        public sbyte? quantityPerUnitFormulaState;

        // FIXED COST:
        public decimal fixedCost;
        public decimal finalFixedCost = decimal.Zero;
        public decimal variableCost = decimal.Zero;


        public decimal localFactor;
        public string localCountry;
        public string localStateProvince;

        public bool? hasUserTotalUnits;
        public DateTime lastUpdate;
        public BoqItemTable boqItemTable;

        public long? paramItemId;

        public AssemblyTable assemblyTable;
        public ParamItemTable paramItemTable;
        public string comment;
        public string pvVars;

        public BoqItemAssemblyTable()
        {
        }
    }
}