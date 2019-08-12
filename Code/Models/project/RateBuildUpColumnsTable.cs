using System;

namespace Models.project
{
    [Serializable]
    public class RateBuildUpColumnsTable
    {

        public const int ADDITION_NUMBER = 0;
        public const int MULTIPLIER_PERCENTAGE = 1;
        public const int SUBTRACT_NUMBER = 2;
        public const int MULTIPLIER_NUMBER = 3;
        public const int DIVIDER_NUMBER = 4;
        public const int ADDITION_SOFAR_NUMBER = 5;
        public const int SUBTRACT_SOFAR_NUMBER = 6;
        public const int MULTIPLIER_SOFAR_NUMBER = 7;
        public const int DIVIDER_SOFAR_NUMBER = 8;


        public long? id;
        public string resourceType;
        public string rowFormula;
        public string columnName0;
        public int? columnType0;
        public bool? columnActive0;
        public string columnFormula0;
        public string columnName1;
        public int? columnType1;
        public bool? columnActive1;
        public string columnFormula1;
        public string columnName2;
        public int? columnType2;
        public bool? columnActive2;
        public string columnFormula2;
        public string columnName3;
        public int? columnType3;
        public bool? columnActive3;
        public string columnFormula3;
        public string columnName4;
        public int? columnType4;
        public bool? columnActive4;
        public string columnFormula4;
        public string columnName5;
        public int? columnType5;
        public bool? columnActive5;
        public string columnFormula5;
        public string columnName6;
        public int? columnType6;
        public bool? columnActive6;
        public string columnFormula6;
        public string columnName7;
        public int? columnType7;
        public bool? columnActive7;
        public string columnFormula7;
        public string columnName8;
        public int? columnType8;
        public bool? columnActive8;
        public string columnFormula8;
        public string columnName9;
        public int? columnType9;
        public bool? columnActive9;
        public string columnFormula9;
        public string columnName10;
        public int? columnType10;
        public bool? columnActive10;
        public string columnFormula10;
        public string columnName11;
        public int? columnType11;
        public bool? columnActive11;
        public string columnFormula11;
        public string columnName12;
        public int? columnType12;
        public bool? columnActive12;
        public string columnFormula12;
        public string columnName13;
        public int? columnType13;
        public bool? columnActive13;
        public string columnFormula13;
        public string columnName14;
        public int? columnType14;
        public bool? columnActive14;
        public string columnFormula14;

        public decimal columnValue0;
        public decimal columnValue1;
        public decimal columnValue2;
        public decimal columnValue3;
        public decimal columnValue4;
        public decimal columnValue5;
        public decimal columnValue6;
        public decimal columnValue7;
        public decimal columnValue8;
        public decimal columnValue9;
        public decimal columnValue10;
        public decimal columnValue11;
        public decimal columnValue12;
        public decimal columnValue13;
        public decimal columnValue14;

        public bool? applyToEveryResource;
        public string tablePreference;
        public string sortablePreference;
        public ProjectTemplateTable projectTemplateTable;

        public RateBuildUpColumnsTable()
        { }
    }
}