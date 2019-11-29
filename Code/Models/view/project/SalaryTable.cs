using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class SalaryTable
    {

        public const long serialVersionUID = 1L;

        public static readonly string[] FIELDS = new string[] { "salaryIncId", "description", "category", "salary", "factor", "months", "compensation", "total" };

        public long? salaryId;
        public string description;
        public string category;
        public decimal factor;
        public decimal salary;
        public decimal months;
        public decimal customCompensation;
        public long? salaryIncId = new long?(0);

        public static List<object> compensationCategoryNames = new List<object>();

        public SalaryTable()
        {

        }
    }
}