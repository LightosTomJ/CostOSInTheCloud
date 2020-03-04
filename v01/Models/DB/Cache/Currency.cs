using System;
using System.Collections.Generic;

namespace Models.DB.Cache
{
    public partial class Currency
    {
        public Currency()
        {
            ExchangeRate = new HashSet<ExchangeRate>();
        }

        public short CurrencyId { get; set; }
        public string Entity { get; set; }
        public string Name { get; set; }
        public string AlphabeticCode { get; set; }
        public short NumericCode { get; set; }
        public byte MinorUnit { get; set; }
        public bool IsFundYesNo { get; set; }
        public short CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<ExchangeRate> ExchangeRate { get; set; }
    }
}
