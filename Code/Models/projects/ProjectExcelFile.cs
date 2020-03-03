namespace Models.projects
{
    public class ProjectExcelFile
    {

        public long? id;
        public sbyte[] excelFile;
        public ProjectTemplateTable projectTemplate;

        public int? sheetIndex;
        public int? cellX;
        public int? cellY;

        public ProjectExcelFile()
        { }

    }
}