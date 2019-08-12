using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectResourceTable
    {
        public static readonly string[] ASSIGNMENT_RESOURCE_FIELDS = new string[] { "itemCode", "title", "notes", "unit", "resourceAssignmentRate", "currency" };

        public static readonly string[] VIEWABLE_FIELDS = new string[] { "projectResourceId", "resourceType", "itemCode", "title", "description", "notes", "unit", "rate", "rateFormula", "currency", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20", "customPercentRate1", "customPercentRate2", "customPercentRate3", "customPercentRate4", "customPercentRate5", "customPercentRate6", "customPercentRate7", "customPercentRate8", "customPercentRate9", "customPercentRate10", "customPercentRate11", "customPercentRate12", "customPercentRate13", "customPercentRate14", "customPercentRate15", "customPercentRate16", "customPercentRate17", "customPercentRate18", "customPercentRate19", "customPercentRate20" };

        public static readonly Type[] CLASSES = new Type[] { typeof(long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal) };

        public static readonly string[] FORMULA_FIELDS = new string[] { "rateFormula" };

        public BoqItemTable boqItemTableSingleInstance { get; set; }

        public long? projectResourceId { get; set; }
        public long? projectId { get; set; }
        public long? parentId { get; set; }

        public string resourceType { get; set; }
        public string itemCode { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public string unit { get; set; }
        public decimal rate { get; set; }
        public string rateFormula { get; set; }
        public string currency { get; set; }

        public string editorId { get; set; }
        public DateTime lastUpdate { get; set; }
        public string createUserId { get; set; }
        public DateTime createDate { get; set; }

        // Group Codes:
        public string groupCode { get; set; }
        public string gekCode { get; set; }
        public string extraCode1 { get; set; }
        public string extraCode2 { get; set; }
        public string extraCode3 { get; set; }
        public string extraCode4 { get; set; }
        public string extraCode5 { get; set; }
        public string extraCode6 { get; set; }
        public string extraCode7 { get; set; }

        // Custom Texts:
        public string customText1 { get; set; }
        public string customText2 { get; set; }
        public string customText3 { get; set; }
        public string customText4 { get; set; }
        public string customText5 { get; set; }
        public string customText6 { get; set; }
        public string customText7 { get; set; }
        public string customText8 { get; set; }
        public string customText9 { get; set; }
        public string customText10 { get; set; }
        public string customText11 { get; set; }
        public string customText12 { get; set; }
        public string customText13 { get; set; }
        public string customText14 { get; set; }
        public string customText15 { get; set; }
        public string customText16 { get; set; }
        public string customText17 { get; set; }
        public string customText18 { get; set; }
        public string customText19 { get; set; }
        public string customText20 { get; set; }
        public string customText21 { get; set; }
        public string customText22 { get; set; }
        public string customText23 { get; set; }
        public string customText24 { get; set; }
        public string customText25 { get; set; }

        // Custom Rates:
        public decimal customRate1 { get; set; }
        public decimal customRate2 { get; set; }
        public decimal customRate3 { get; set; }
        public decimal customRate4 { get; set; }
        public decimal customRate5 { get; set; }
        public decimal customRate6 { get; set; }
        public decimal customRate7 { get; set; }
        public decimal customRate8 { get; set; }
        public decimal customRate9 { get; set; }
        public decimal customRate10 { get; set; }
        public decimal customRate11 { get; set; }
        public decimal customRate12 { get; set; }
        public decimal customRate13 { get; set; }
        public decimal customRate14 { get; set; }
        public decimal customRate15 { get; set; }
        public decimal customRate16 { get; set; }
        public decimal customRate17 { get; set; }
        public decimal customRate18 { get; set; }
        public decimal customRate19 { get; set; }
        public decimal customRate20 { get; set; }

        // Custom Percentage Rates:
        public decimal customPercentRate1 { get; set; }
        public decimal customPercentRate2 { get; set; }
        public decimal customPercentRate3 { get; set; }
        public decimal customPercentRate4 { get; set; }
        public decimal customPercentRate5 { get; set; }
        public decimal customPercentRate6 { get; set; }
        public decimal customPercentRate7 { get; set; }
        public decimal customPercentRate8 { get; set; }
        public decimal customPercentRate9 { get; set; }
        public decimal customPercentRate10 { get; set; }
        public decimal customPercentRate11 { get; set; }
        public decimal customPercentRate12 { get; set; }
        public decimal customPercentRate13 { get; set; }
        public decimal customPercentRate14 { get; set; }
        public decimal customPercentRate15 { get; set; }
        public decimal customPercentRate16 { get; set; }
        public decimal customPercentRate17 { get; set; }
        public decimal customPercentRate18 { get; set; }
        public decimal customPercentRate19 { get; set; }
        public decimal customPercentRate20 { get; set; }

        public ProjectResourceTable()
        { }
    }
}