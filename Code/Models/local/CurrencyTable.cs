using System;

namespace Model.local
{
    [Serializable]
    public class CurrencyTable
    {
        public static readonly string[] FIELDS = new string[] { "id", "name", "symbol", "code", "flag" };

        public long? id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string code { get; set; }
        public string flag { get; set; }

        public CurrencyTable()
        { }
    }
}