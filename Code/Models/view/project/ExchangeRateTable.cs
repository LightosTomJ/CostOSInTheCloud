using System;

namespace Models.project
{
    [Serializable]
    public class ExchangeRateTable
    {
        public long? id;
        public string fromCurrency;
        public string toCurrency;
        public decimal rate;
        public DateTime date;

        public ExchangeRateTable()
        { }
    }
}