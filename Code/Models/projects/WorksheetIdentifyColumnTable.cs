using System;

namespace Models.projects
{

    [Serializable]
    public class WorksheetIdentifyColumnTable
    {
        public const int COLUMN_TYPE_INCOMING = 0;
        public const int COLUMN_TYPE_OUTGOING = 1;

        public const int FIELD_TYPE_TEXT = 0; // No Validation
        public const int FIELD_TYPE_NUMBER = 1; // Validation to Number
        public const int FIELD_TYPE_GROUPCODE = 2; // Validation to Group Code
        public const int FIELD_TYPE_UNIT = 3; // Validation to Unit

        public const int ACTION_ACCEPT = 0;
        public const int ACTION_REJECT = 1;
        public const int ACTION_CONCATENATE = 2;
        public const int ACTION_SPLIT_NON_ENGLISH = 3;

        public long? id;
        public string fieldName;
        public int? columnIndex;
        public int? fieldType;
        public string fieldMap;

        public int? columnType;
        public int? mapAction;
        public string splitField;
        public bool? mappedForUniqueness;
        public bool? prefixSheetNameForUniqueness;
        public bool? prefixFileNameForUniqueness;
        public bool? excludeAutoMatch;

        public WorksheetDataMappingTable dataMapping;
        
        public WorksheetIdentifyColumnTable()
        { }

    }
}