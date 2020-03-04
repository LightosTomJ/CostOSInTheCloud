using System;
using System.Collections.Generic;

namespace Model.DB.Cache
{
    public partial class Country
    {
        public Country()
        {
            Currency = new HashSet<Currency>();
        }

        public short CountryId { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public string SentenceCaseName { get; set; }
        public string Iso3 { get; set; }
        public short? Numcode { get; set; }
        public int Phonecode { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Currency> Currency { get; set; }
    }
}
