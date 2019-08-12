using System;

namespace Model.local
{
    [Serializable]
    public class LocalizationFactorTable
    {
        public long? id { get; set; }
        public string parentCode { get; set; }
        public string groupCodeName { get; set; }

        public string toCountry { get; set; }
        public string toState { get; set; }
        public string toCity { get; set; }
        public string toZipCode { get; set; }

        public decimal laborFactor { get; set; }
        public decimal materialFactor { get; set; }
        public decimal subcontractorFactor { get; set; }
        public decimal consumableFactor { get; set; }
        public decimal equipmentFactor { get; set; }
        public decimal assemblyFactor { get; set; }
        public string geoPolygon { get; set; }
        public string editorId { get; set; }
        public bool? online { get; set; }
        public LocalizationProfileTable localizationProfileTable { get; set; }

        public LocalizationFactorTable()
        { }
    }
}