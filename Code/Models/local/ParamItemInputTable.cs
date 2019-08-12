using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemInputTable
    {
        public static readonly string[] VIEWABLE_FIELDS = new string[] { "paramInputId", "name", "label", "description", "comment", "dataType", "sortOrder", "grouping", "dependencyStatement", "validationStatement", "selectionList", "hidden", "pblk" };

        /// <summary>
        /// Data Types:
        /// </summary>
        public const string DECIMAL = "datatype.decimal";
        public const string INTEGER = "datatype.integer";
        public const string TEXT = "datatype.text";
        public const string SELECTIONLIST = "datatype.list";
        public const string BIMMODEL = "datatype.bimmodel";
        public const string BOOLEAN = "datatype.boolean";
        public const string FORMULA = "datatype.formula";

        public const string COUNTRY = "datatype.country";
        public const string LOCFACTOR = "datatype.locfactor";
        public const string TAKEOFF = "datatype.takeoff";
        public const string ARRAY = "datatype.array";
        public const string CALCARRAY = "datatype.calcarray";
        public const string CALCLIST = "datatype.calclist";
        public const string SVGFILE = "datatype.svg";
        public const string PRJVAR = "datatype.prjvar";

        public const string IMAGE = "datatype.image";
        public const string CALCVALUE = "datatype.calcvalue";
        public const string DATE = "datatype.date";
        public const string NOTES = "datatype.notes";


        /// <summary>
        /// Array Types:
        /// </summary>
        public const string ROW_HEADER_ARRAY = "arraytype.rowheader";

        public const string FIXED_NUMBER_USER_DEFINED_ARRAY = "arraytype.fixed";
        public const string DYNAMIC_NUMBER_USER_DEFINED_ARRAY = "arraytype.dynamic";

        public const string FIXED_TEXT_USER_DEFINED_ARRAY = "arraytype.fixedtext";
        public const string DYNAMIC_TEXT_USER_DEFINED_ARRAY = "arraytype.dynamictext";

        public const string DYNAMIC_TEXT_AND_ASSIGN_RESOURCES_USER_DEFINED_ARRAY = "arraytype.dynamictext.assignres";

        public const string FIXED_FORMULA_USER_DEFINED_ARRAY = "arraytype.fixedformula";
        public const string DYNAMIC_FORMULA_USER_DEFINED_ARRAY = "arraytype.dynamicformula";

        public const string FIXED_FORMULA_TEXT_USER_DEFINED_ARRAY = "arraytype.fixedformula.text";
        public const string DYNAMIC_FORMULA_TEXT_USER_DEFINED_ARRAY = "arraytype.dynamicformula.text";

        public const string GIS_TAKEOFF_XY_ARRAY = "arraytype.gisxy";
        public const string GIS_TAKEOFF_XYZ_ARRAY = "arraytype.gisxyz";

        /// <summary>
        /// Array Views:
        /// </summary>
        public const string ARRAY_TABLE_VIEW = "arrayview.table";
        public const string ARRAY_PIECHART_VIEW = "arrayview.piechart";
        public const string ARRAY_XYCHART_VIEW = "arrayview.xychart"; // Scatter
        public const string ARRAY_XY_LINEAR_CHART_VIEW = "arrayview.xychart.linear";
        public const string ARRAY_XY_QUAD_CHART_VIEW = "arrayview.xychart.quadratic";
        public const string ARRAY_XY_CUBIC_CHART_VIEW = "arrayview.xychart.cubic";

        // Decimal Digits to show in display:
        public static readonly sbyte?[] CALC_VALUE_DECIMAL_DIGITS = new sbyte?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public const sbyte DEFAULT_CALC_VALUE_DECIMAL_DIGITS = 3;

        public long? paramInputId { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string description { get; set; }
        public string dataType { get; set; }
        public string dependencyStatement { get; set; }
        public string validationStatement { get; set; }
        public string selectionList { get; set; } // comma separated
        public string defaultValue { get; set; }
        public string storedValue { get; set; }
        public int? sortOrder { get; set; }
        public bool? hidden { get; set; }
        public bool? pblk { get; set; }
        public string grouping { get; set; }
        public string arrayType { get; set; }
        public string arraySizeVar { get; set; }
        public bool? editable { get; set; }
        public bool? wasShowing { get; set; }
        public bool? calcValue { get; set; }
        public sbyte? calcValueDecimalDigits { get; set; } // [0 - 10] decimal digits only in display
        public string comment { get; set; }
        public bool? frmRowVisible { get; set; }

        public ParamItemTable paramItemTable { get; set; }
        public ISet<ParamItemConditionTable> conditionSet { get; set; }


        public ParamItemInputTable()
        { }
    }
}