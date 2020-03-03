using System;

namespace Models.projects
{
    [Serializable]
    public class RateBuildUpTable
    {

        public long? id;
        public string resourceType;
        public long? resourceId; // IN CENTRAL DATABASE
        public long? projectResourceId; // IN PROJECT DATABASE OR NULL
        public bool? online;
        public long? databaseCreationDate;

        public decimal rateOverwrite;
        public decimal finalRate;
        public string calculationFormula;

        public decimal rate0;
        public decimal rate1;
        public decimal rate2;
        public decimal rate3;
        public decimal rate4;
        public decimal rate5;
        public decimal rate6;
        public decimal rate7;
        public decimal rate8;
        public decimal rate9;
        public decimal rate10;
        public decimal rate11;
        public decimal rate12;
        public decimal rate13;
        public decimal rate14;


        public ProjectTemplateTable projectTemplateTable;

        public RateBuildUpTable()
        { }
    }
}