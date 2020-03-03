using System;

namespace Models.projects
{

    [Serializable]
    public class WorksheetFileTable
    {

        public long? id;
        public string fileName;
        public string filePath;
        public sbyte[] excelFile;
        public string activeSheets;
        public int? numberOfSheets;
        public bool? xmlFile;
        public WorksheetRevisionTable worksheetRevision;
        public bool? tcmFile;

        public WorksheetFileTable()
        { }
    }
}