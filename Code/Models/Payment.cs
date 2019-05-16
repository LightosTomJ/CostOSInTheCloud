using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Payment
    {
        public long Paymentid { get; set; }
        public long? Paymentincid { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? Factor { get; set; }
        public decimal? Months { get; set; }
        public decimal? CustomCompensation { get; set; }
    }
}
