using System;

namespace Model.local
{
    [Serializable]
    public class FieldCustomizationTable
    {
        public const int FORMULAIN_RET = 0;
        public const int SELECION_LIST = 1;
        public const int CALCULATED_SELECION_LIST = 2;

        public long? id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string formula { get; set; }
        public string resourceType { get; set; } // LayoutType Here
        public bool? editable { get; set; }
        public int? selectionList { get; set; }
        public string selectionValues { get; set; }
        public string defSelection { get; set; }

        public FieldCustomizationTable()
        { }
    }
}