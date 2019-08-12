using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemQueryResourceTable
    {

        public const int CUSTOM_FIELDS_INDEX_START = 19;

        public static readonly string[] ITEM_VARIABLES = new string[] { "ITEM_TITLE", "ITEM_ESTIMATED_QUANTITY", "ITEM_DESCRIPTION", "ITEM_NOTES", "ITEM_PRODUCTIVITY", "ITEM_PRODUCTIVITY_FACTOR", "ITEM_PAYMENT_DATE", "ITEM_WBS_CODE1", "ITEM_WBS_CODE2", "ITEM_PUBLISHED_ITEM_CODE", "ITEM_LOCATION", "ITEM_GROUP_CODE1", "ITEM_GROUP_CODE2", "ITEM_GROUP_CODE3", "ITEM_GROUP_CODE4", "ITEM_GROUP_CODE5", "ITEM_GROUP_CODE6", "ITEM_GROUP_CODE7", "ITEM_GROUP_CODE8", "ITEM_GROUP_CODE9", "ITEM_CUSTOM_TEXT1", "ITEM_CUSTOM_TEXT2", "ITEM_CUSTOM_TEXT3", "ITEM_CUSTOM_TEXT4", "ITEM_CUSTOM_TEXT5", "ITEM_CUSTOM_TEXT6", "ITEM_CUSTOM_TEXT7", "ITEM_CUSTOM_TEXT8", "ITEM_CUSTOM_TEXT9", "ITEM_CUSTOM_TEXT10", "ITEM_CUSTOM_TEXT11", "ITEM_CUSTOM_TEXT12", "ITEM_CUSTOM_TEXT13", "ITEM_CUSTOM_TEXT14", "ITEM_CUSTOM_TEXT15", "ITEM_CUSTOM_TEXT16", "ITEM_CUSTOM_TEXT17", "ITEM_CUSTOM_TEXT18", "ITEM_CUSTOM_TEXT19", "ITEM_CUSTOM_TEXT20", "ITEM_CUSTOM_TEXT21", "ITEM_CUSTOM_TEXT22", "ITEM_CUSTOM_TEXT23", "ITEM_CUSTOM_TEXT24", "ITEM_CUSTOM_TEXT25", "ITEM_CUSTOM_DECIMAL1", "ITEM_CUSTOM_DECIMAL2", "ITEM_CUSTOM_DECIMAL3", "ITEM_CUSTOM_DECIMAL4", "ITEM_CUSTOM_DECIMAL5", "ITEM_CUSTOM_DECIMAL6", "ITEM_CUSTOM_DECIMAL7", "ITEM_CUSTOM_DECIMAL8", "ITEM_CUSTOM_DECIMAL9", "ITEM_CUSTOM_DECIMAL10", "ITEM_CUSTOM_DECIMAL11", "ITEM_CUSTOM_DECIMAL12", "ITEM_CUSTOM_DECIMAL13", "ITEM_CUSTOM_DECIMAL14", "ITEM_CUSTOM_DECIMAL15", "ITEM_CUSTOM_DECIMAL16", "ITEM_CUSTOM_DECIMAL17", "ITEM_CUSTOM_DECIMAL18", "ITEM_CUSTOM_DECIMAL19", "ITEM_CUSTOM_DECIMAL20", "ITEM_CUSTOM_CUM_DECIMAL1", "ITEM_CUSTOM_CUM_DECIMAL2", "ITEM_CUSTOM_CUM_DECIMAL3", "ITEM_CUSTOM_CUM_DECIMAL4", "ITEM_CUSTOM_CUM_DECIMAL5", "ITEM_CUSTOM_CUM_DECIMAL6", "ITEM_CUSTOM_CUM_DECIMAL7", "ITEM_CUSTOM_CUM_DECIMAL8", "ITEM_CUSTOM_CUM_DECIMAL9", "ITEM_CUSTOM_CUM_DECIMAL10", "ITEM_CUSTOM_CUM_DECIMAL11", "ITEM_CUSTOM_CUM_DECIMAL12", "ITEM_CUSTOM_CUM_DECIMAL13", "ITEM_CUSTOM_CUM_DECIMAL14", "ITEM_CUSTOM_CUM_DECIMAL15", "ITEM_CUSTOM_CUM_DECIMAL16", "ITEM_CUSTOM_CUM_DECIMAL17", "ITEM_CUSTOM_CUM_DECIMAL18", "ITEM_CUSTOM_CUM_DECIMAL19", "ITEM_CUSTOM_CUM_DECIMAL20" };

        public static readonly string[] ITEM_FIELDS = new string[] { "title", "estimatedQuantity", "description", "notes", "productivity", "prodFactor", "paymentDate", "wbsCode", "wbs2Code", "publishedItemCode", "location", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7", "customText1", "customText2", "customText3", "customText4", "customText5", "customText6", "customText7", "customText8", "customText9", "customText10", "customText11", "customText12", "customText13", "customText14", "customText15", "customText16", "customText17", "customText18", "customText19", "customText20", "customText21", "customText22", "customText23", "customText24", "customText25", "customRate1", "customRate2", "customRate3", "customRate4", "customRate5", "customRate6", "customRate7", "customRate8", "customRate9", "customRate10", "customRate11", "customRate12", "customRate13", "customRate14", "customRate15", "customRate16", "customRate17", "customRate18", "customRate19", "customRate20", "customCumRate1", "customCumRate2", "customCumRate3", "customCumRate4", "customCumRate5", "customCumRate6", "customCumRate7", "customCumRate8", "customCumRate9", "customCumRate10", "customCumRate11", "customCumRate12", "customCumRate13", "customCumRate14", "customCumRate15", "customCumRate16", "customCumRate17", "customCumRate18", "customCumRate19", "customCumRate20" };

        public static readonly Type[] ITEM_CLASSES = new Type[] { typeof(string), typeof(decimal), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal) };

        public const int EXEC_TYPE_ALWAYS = 0; // or null
        public const int EXEC_TYPE_AFTER_FAIL = 1;
        public const int EXEC_TYPE_AFTER_SUCCESS = 2;

        public const int SQL_TYPE = 0; // or null
        public const int JSON_TYPE = 1;

        public long? id { get; set; }
        public string title { get; set; }
        public string jsonUrl { get; set; }
        public string resourceType { get; set; }
        public string orderField { get; set; }
        public bool? asceding { get; set; }
        public bool? singleSelection { get; set; }
        public string titleEquation { get; set; }
        public string estimatedQuantityEquation { get; set; }
        public string descriptionEquation { get; set; }
        public string notesEquation { get; set; }
        public string paymentDateEquation { get; set; }
        public string productivityEquation { get; set; }
        public string prodFactorEquation { get; set; }

        // Group Codes
        public string wbsCodeEquation { get; set; }
        public string wbs2CodeEquation { get; set; }
        public string locationEquation { get; set; }
        public string publishedItemCodeEquation { get; set; }

        public string groupCodeEquation { get; set; }
        public string gekCodeEquation { get; set; }
        public string extraCode1Equation { get; set; }
        public string extraCode2Equation { get; set; }
        public string extraCode3Equation { get; set; }
        public string extraCode4Equation { get; set; }
        public string extraCode5Equation { get; set; }
        public string extraCode6Equation { get; set; }
        public string extraCode7Equation { get; set; }

        // Custom Text
        public string customText1Equation { get; set; }
        public string customText2Equation { get; set; }
        public string customText3Equation { get; set; }
        public string customText4Equation { get; set; }
        public string customText5Equation { get; set; }
        public string customText6Equation { get; set; }
        public string customText7Equation { get; set; }
        public string customText8Equation { get; set; }
        public string customText9Equation { get; set; }
        public string customText10Equation { get; set; }
        public string customText11Equation { get; set; }
        public string customText12Equation { get; set; }
        public string customText13Equation { get; set; }
        public string customText14Equation { get; set; }
        public string customText15Equation { get; set; }
        public string customText16Equation { get; set; }
        public string customText17Equation { get; set; }
        public string customText18Equation { get; set; }
        public string customText19Equation { get; set; }
        public string customText20Equation { get; set; }
        public string customText21Equation { get; set; }
        public string customText22Equation { get; set; }
        public string customText23Equation { get; set; }
        public string customText24Equation { get; set; }
        public string customText25Equation { get; set; }

        // Custom Decimal
        public string customRate1Equation { get; set; }
        public string customRate2Equation { get; set; }
        public string customRate3Equation { get; set; }
        public string customRate4Equation { get; set; }
        public string customRate5Equation { get; set; }
        public string customRate6Equation { get; set; }
        public string customRate7Equation { get; set; }
        public string customRate8Equation { get; set; }
        public string customRate9Equation { get; set; }
        public string customRate10Equation { get; set; }
        public string customRate11Equation { get; set; }
        public string customRate12Equation { get; set; }
        public string customRate13Equation { get; set; }
        public string customRate14Equation { get; set; }
        public string customRate15Equation { get; set; }
        public string customRate16Equation { get; set; }
        public string customRate17Equation { get; set; }
        public string customRate18Equation { get; set; }
        public string customRate19Equation { get; set; }
        public string customRate20Equation { get; set; }

        // Custom Cumulative Rate
        public string customCumRate1Equation { get; set; }
        public string customCumRate2Equation { get; set; }
        public string customCumRate3Equation { get; set; }
        public string customCumRate4Equation { get; set; }
        public string customCumRate5Equation { get; set; }
        public string customCumRate6Equation { get; set; }
        public string customCumRate7Equation { get; set; }
        public string customCumRate8Equation { get; set; }
        public string customCumRate9Equation { get; set; }
        public string customCumRate10Equation { get; set; }
        public string customCumRate11Equation { get; set; }
        public string customCumRate12Equation { get; set; }
        public string customCumRate13Equation { get; set; }
        public string customCumRate14Equation { get; set; }
        public string customCumRate15Equation { get; set; }
        public string customCumRate16Equation { get; set; }
        public string customCumRate17Equation { get; set; }
        public string customCumRate18Equation { get; set; }
        public string customCumRate19Equation { get; set; }
        public string customCumRate20Equation { get; set; }

        // Types
        public int? executionType { get; set; }
        public int? type { get; set; }

        public ParamItemOutputTable paramItemOutputTable { get; set; }
        public IList<ParamItemQueryRowTable> queryRowList = new List<ParamItemQueryRowTable>(0);

    }
}