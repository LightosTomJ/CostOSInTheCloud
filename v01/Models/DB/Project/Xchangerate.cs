using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Xchangerate
    {
        public long Xchangerateid { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? RateDate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
    }
}
