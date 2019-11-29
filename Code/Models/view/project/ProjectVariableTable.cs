using Models.local.BaseClass;
using System;

namespace Models.project
{
    [Serializable]
    public class ProjectVariableTable //: ProjectIdEntity
    {

        public const string SHEET_CELL = "datatype.sheetcell";
        public const string CALCULATED_VALUE = ParamItemInput.CALCVALUE;

        public long? id;
        public string name;

        public string description;
        public string dataType;

        public string defaultValue;
        public string storedValue;
        public decimal storedValueNum;
        public int? sortOrder;

        public int? sheetNo;
        public bool? mapped;
        public int? cellX;
        public int? cellY;
        public bool? number;
        public bool? mandatory;
        public string pushField;
        public bool? hidden;
        public long? databaseTemplateId;
        public string databaseTemplateName;

        public ProjectTemplateTable projectTemplateTable;

        public ProjectVariableTable()
        { }
    }
}