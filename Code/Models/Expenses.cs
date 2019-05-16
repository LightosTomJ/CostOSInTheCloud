using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Expenses
    {
        public long Expenseid { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CustomRate { get; set; }
        public decimal? Months { get; set; }
        public decimal? Percent { get; set; }
        public decimal? LaborRate { get; set; }
        public decimal? SubcontractorsRate { get; set; }
        public decimal? MaterialRate { get; set; }
        public decimal? MiscRate { get; set; }
        public decimal? Prcnt { get; set; }
    }
}
