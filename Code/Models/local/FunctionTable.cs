using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class FunctionTable
    {
        public const string EXPR_LANGUAGE = "EXPR";
        public const string JS_LANGUAGE = "JS";

        public static readonly string[] FIELDS = new string[] { "functionId", "name", "description", "implementation", "lastUpdate", "createDate", "createUserId", "editorId", "grouping", "takeoff", "unit", "resultType" };

        public long? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string implementation { get; set; }
        public DateTime lastUpdate { get; set; }
        public DateTime createDate { get; set; }
        public string createUserId { get; set; }
        public string editorId { get; set; }
        public string grouping { get; set; }
        public bool? takeoff { get; set; }
        public string unit { get; set; }
        public string language { get; set; }
        public string resultType { get; set; }

        public string password { get; set; }
        public string serialNumber { get; set; }
        public string protectionType { get; set; }

        public IList<FunctionArgumentTable> functionArgumentList { get; set; }

        public FunctionTable()
        {
            functionArgumentList = new List<FunctionArgumentTable>();
        }
    }
}