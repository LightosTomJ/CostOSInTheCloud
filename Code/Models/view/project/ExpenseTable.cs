using System;

namespace Models.project
{
    [Serializable]
    public class ExpenseTable
    {

        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "code", "description", "unit", "materialRate", "subconstractorsRate", "laborRate", "miscRate", "quantity", "rate", "months", "percent", "totalCost" };

        public long? expenseId;
        public string code;
        public string description;
        public string unit;
        public decimal quantity;
        public decimal customRate;
        public decimal months;
        public decimal percent;

        public decimal materialRate;
        public decimal subcontractorsRate;
        public decimal laborRate;
        public decimal miscRate;


        public ExpenseTable()
        { }
    }
}