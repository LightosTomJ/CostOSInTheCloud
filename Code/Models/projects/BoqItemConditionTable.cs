using Models.local.BaseClass;
using System;

namespace Models.projects
{
    [Serializable]
    public class BoqItemCondition
    {

        public const string SELECTED_UNIT1 = "selectedQty.1";
        public const string SELECTED_UNIT2 = "selectedQty.2";
        public const string SELECTED_UNIT3 = "selectedQty.3";
        public const string SELECTED_UNITF = "selectedQty.F";
        public const string OVERRIDEN_UNIT = "selectedQty.O";
        /// 
        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "selectedUnit", "factor1", "factor2", "sumup", "finalQuantity" };

        public long? boqItemConditionId;
        public string selectedUnit;
        public decimal factor1;
        public decimal factor2;
        public decimal sumup;
        public decimal finalQuantity;
        public string finalUnit;
        public string selectedQuantityName;
        public decimal selectedQuantity;
        public decimal overridenQty;
        public string overridenUnit;

        public DateTime lastUpdate;
        //	public String formula;

        public BoqItemTable boqItemTable;

        public Condition conditionTable;
        public long? paramItemId;
        public local.BaseClass.Paramitem paramItemTable;

        public BoqItemCondition()
        { }

    }
}