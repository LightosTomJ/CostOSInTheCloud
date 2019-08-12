using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class ExpenseTableList
    {
        public List<ExpenseTable> items { get; set; }
        public const long serialVersionUID = 1L;

        public ExpenseTableList()
        {
            items = new List<ExpenseTable>();
        }
    }
}