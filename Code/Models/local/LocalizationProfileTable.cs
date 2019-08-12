using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class LocalizationProfileTable
    {
        public long? id{ get; set; }
        public string profileName{ get; set; }
        public bool? supportsState{ get; set; }
        public string fromCountry{ get; set; }
        public string fromState{ get; set; }
        public IList<LocalizationFactorTable> factors{ get; set; }
        public string editorId{ get; set; }
        public string createUserId{ get; set; }
        public DateTime lastUpdate{ get; set; }
        public DateTime createDate{ get; set; }

        public LocalizationProfileTable()
        {
            factors = new List<LocalizationFactorTable>();
        }
    }
}