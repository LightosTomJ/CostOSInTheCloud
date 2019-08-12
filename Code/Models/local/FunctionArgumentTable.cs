using Models.project;
using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class FunctionArgumentTable
    {

        public const string DECIMAL = ParamItemInputTable.DECIMAL;
        public const string INTEGER = ParamItemInputTable.INTEGER;
        public const string SELECTIONLIST = ParamItemInputTable.SELECTIONLIST;
        public const string BOOLEAN = ParamItemInputTable.BOOLEAN;

        public const string COUNTRY = ParamItemInputTable.COUNTRY;
        public const string TAKEOFF = ParamItemInputTable.TAKEOFF;
        public const string ARRAY = ParamItemInputTable.ARRAY;
        public const string CALCARRAY = ParamItemInputTable.CALCARRAY;
        public const string CALLIST = ParamItemInputTable.CALCLIST;

        public const string IMAGE = ParamItemInputTable.IMAGE;
        public const string NOTES = ParamItemInputTable.NOTES;
        public const string TEXT = ParamItemInputTable.TEXT;
        public const string LOCFACTOR = ParamItemInputTable.LOCFACTOR;

        public const string CALCVALUE = ParamItemInputTable.CALCVALUE;
        public const string DATE = ParamItemInputTable.DATE;

        public long? id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string unit { get; set; }
        public string description { get; set; }
        public string selectionList { get; set; }
        public string grouping { get; set; }
        public string validationStatement { get; set; }
        public string dependencyStatement { get; set; }
        public string defaultValue { get; set; }
        public int? sortOrder { get; set; }
        public bool? editable { get; set; }
        public string arrayType { get; set; }
        public FunctionTable functionTable { get; set; }

        // Used only to transfer conditions:
        public ISet<ConditionTable> conditionSet { get; set; }

        public FunctionArgumentTable()
        { }
    }
}