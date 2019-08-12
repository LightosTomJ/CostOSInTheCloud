using System;

namespace Model.local
{
    [Serializable]
    public class CountryTable
    {
        public static readonly string[] FIELDS = new string[] { "id", "label", "value" };

        public long? id { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }

        public CountryTable()
        { }
    }
}