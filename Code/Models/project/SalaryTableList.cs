using System;
using System.Collections.Generic;

namespace Models.project
{

    [Serializable]
    public class SalaryTableList
    {
        // public Vector _o_items;
        public List<SalaryTable> Salaries { get; set; }

        public const long serialVersionUID = 1L;

        public SalaryTableList()
        {
            Salaries = new List<SalaryTable>();
        }
    }
}