using System;

namespace Model.local
{
    [Serializable]
    public class ParamItemQueryRowTable
    {
        // AVAILABLE CONDITIONS:
        public const string AND_CONDITION = "AND";
        public const string NOT_CONDITION = "NOT";
        public const string OR_CONDITION = "OR";

        // AVAILABLE RULES:
        public const string EQUAL = "EQ";
        public const string NOT_EQUAL = "NE";
        public const string CONTAINS = "CN";
        public const string NOT_CONTAIN = "NC";
        public const string STARTS_WITH = "SW";
        public const string ENDS_WITH = "EW";
        public const string GREATER_THAN = "GT";
        public const string LESS_THAN = "LT";
        public const string GREATER_EQUAL = "GE";
        public const string LESS_EQUAL = "LE";

        public long? id { get; set; }
        public string fieldName { get; set; }
        public string ruleName { get; set; }
        public string type { get; set; }
        public string condition { get; set; }
        //	public String groupCodeEquation { get; set; }
        //	public String groupCodeEquation { get; set; }

        public ParamItemQueryResourceTable queryResourceTable;

        public ParamItemQueryRowTable()
        { }
    }
}