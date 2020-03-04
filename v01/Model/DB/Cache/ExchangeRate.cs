using System;
using System.Collections.Generic;

namespace Model.DB.Cache
{
    public partial class ExchangeRate
    {
        public Guid ExchangeRateId { get; set; }
        public short CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
