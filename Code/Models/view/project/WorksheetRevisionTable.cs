using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class WorksheetRevisionTable
    {

        public long? id;
        public string title;
        public string code;
        public string description;

        public DateTime createDate;
        public DateTime lastUpdate;
        public string createUserId;
        public string editorId;
        public bool? selected;
        public IList<WorksheetFileTable> files;
        public WorksheetDataMappingTable dataMapping;
        public bool? pblk;

    }
}