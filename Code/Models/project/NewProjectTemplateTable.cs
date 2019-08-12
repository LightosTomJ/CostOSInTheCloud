using System;

namespace Models.project
{
    [Serializable]
    public class NewProjectTemplateTable
    {
        public const int BOTTOM_UP = 0;
        public const int TOP_DOWN = 1;
        public long? id;
        public string title;
        public int type;
        public string description;
        public string paramItemIds;
        public string templateImageId;
        public bool has2D;
        public bool hasBIM;
        public bool hasGIS;
        public string wbsFill;
        public string wbs2Fill;
        public bool hasAddFromExcel;
        public string layoutIds;
        public string projectVariableTemplateIds;

        public NewProjectTemplateTable()
        { }
    }
}