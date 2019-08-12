using System;

namespace Models.project
{
    [Serializable]
    public class RateDistributorTable : ProjectIdEntity
    {

        public const int BOQ_DISTRIBUTION = 0;
        public const int WBS1_DISTRIBUTION = 1;
        public const int WBS2_DISTRIBUTION = 2;
        public const int GC1_DISTRIBUTION = 3;
        public const int GC2_DISTRIBUTION = 4;
        public const int GC3_DISTRIBUTION = 5;
        public const int GC4_DISTRIBUTION = 6;
        public const int GC5_DISTRIBUTION = 7;
        public const int GC6_DISTRIBUTION = 8;
        public const int GC7_DISTRIBUTION = 9;
        public const int GC8_DISTRIBUTION = 10;
        public const int GC9_DISTRIBUTION = 11;

        public long? id;
        public ProjectTemplateTable projectTemplateTable;

        public string name;
        public string description;
        public int? sortOrder;
        public int? distributionType;
        public bool? balanced;
        public bool? distributed;
        public string targetField;
        public string targetCostField;
        public string distributionRanges;
        public string distributionRates;

        public bool? mapped;
        public int? sheetNo;
        public int? cellX;
        public int? cellY;
        public decimal storedValueNum;

    }
}