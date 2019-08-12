using System;

namespace Model.local
{
    public class CentralLogTable
    {
        public const string RESOURSE_SOURCE = "RESOURCE";
        public const string LINE_ITEM_SOURCE = "LINEITEM";
        public const string PARAM_ITEM_SOURCE = "PARAMITEM";
        public const string MATERIAL_SOURCE = "MATERIAL";
        public const string LABOR_SOURCE = "LABOR";
        public const string SUBCONTRACTOR_SOURCE = "SUBCONTRACTOR";
        public const string OTHER_COST_SOURCE = "OTHERSOURCE";
        public const string RESOURSE_ASSIGNMENT_SOURCE = "RESOURSEASSSRC";
        public const string RESOURSE_ASSIGNMENT_PROJECT = "RESOURSEASSPRJ";
        public const string BOQ_ITEM_FORMULA_SOURCE = "FORMULA";
        public const string BOQ_ITEM_SOURCE = "BOQ";
        public const string BOQ_ITEM_ESTIMATOR = "ESTIMATOR";
        public const string BOQ_ITEM_EXCHANGE_RATE = "EXCHANGE_RATE";
        public const string BOQ_ITEM_SYNC = "SYNC_RATES";
        public const string EPS_SOURCE = "EPS";
        public const string PROJECT_SOURCE = "PROJECT";
        public const string PROJECT_RESOURCE_SOURCE = "PROJECT_RESOURCE";
        public const string GROUPCODE_SOURCE = "GROUPCODE";
        public const string QUOTATION_SOURCE = "QUOTATION";
        public const string QUOTEMPLATE_SOURCE = "QUOTETEMPLATE";
        public const string GLOBAL_PROPERTIES_SOURCE = "GLOBALPROPS";
        public const string TAKEOFF_SOURCE = "TAKEOFF";
        public const string SYNC_DATABASE_SOURCE = "SYNCDB";
        public const string GLOBAL_CHANGE_SOURCE = "GLOBCH";
        public const string PROJECT_VARS_SOURCE = "PROJECTVAR";
        public const string PROJECT_PROPS_SOURCE = "PROJECTPROP";
        public const string EXTERNAL_DATASOURCE_SOURCE = "EXTDATASOURCE";
        public const string EXTERNAL_QUERY_SOURCE = "EXTQUERY";

        public const string BIMCT_SOURCE = "BIMCT";

        public static readonly sbyte? OPERATION_CRE = (sbyte)0;
        public static readonly sbyte? OPERATION_UPD = (sbyte)1;
        public static readonly sbyte? OPERATION_DEL = (sbyte)2;

        //filter (if the action related to a specific table then the filter is the name of the table )	
        public long? id { get; set; }
        public DateTime logDate { get; set; }
        public string logEditorId { get; set; }
        public sbyte? logOperation { get; set; } // C U D
        public string logDescription { get; set; }
        public string logFilter { get; set; }
        public string logSource { get; set; }   // is in central database EPS, RESOURCES, GLOBAL PROPERTIES GROUP CODES ETC OR
                                                // OR
        public long? projectId { get; set; }    // is in project

        public CentralLogTable()
        { }
    }
}