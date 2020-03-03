using System;
using System.Collections.Generic;

namespace Models.projects
{
    [Serializable]
    public class WorksheetDataMappingTable
    {
        //Import Algorithms:
        public static int ALG_NONE = 0;
        public static int ALG_UNIT_ONLY = 1;
        public static int ALG_EMPTY_ROWS_TOP_BOTTOM_AND_UNIT = 2;
        public static int ALG_TIMBERLINE = 3;

        public long? id;
        public string title;
        //	public Integer importAlgorithm;

        public bool? commentAutoDetect;
        public bool? treeAutoDetect;
        public bool? keepItemsOnly;
        public string treeMapping;
        public string tablePreference;
        public int? groupColumnIndex;

        // Like Ignore Row or Ignore Cell 
        public string cellDataToIgnore;
        public ISet<WorksheetIdentifyColumnTable> identifyColumns;
        public WorksheetRevisionTable revision;
        public sbyte[] excelFile;

        public WorksheetDataMappingTable()
        { }
    }
}