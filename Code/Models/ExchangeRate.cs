using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ExchangeRate
    {
        public long Xchangerateid { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? RateDate { get; set; }
    }
}
