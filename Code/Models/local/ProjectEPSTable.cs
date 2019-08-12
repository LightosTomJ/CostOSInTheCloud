using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectEPSTable
    {

        public static readonly string[] FIELDS = new string[] { "projectEPSId", "groupCode", "title", "unit", "unitFactor", "editorId", "notes", "description", "lastUpdate" };

        public long? projectEPSId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string description { get; set; }
        public DateTime lastUpdate { get; set; }

        public ISet<ProjectInfoTable> projects { get; set; }
        public long? parentId { get; set; }

        public ProjectEPSTable()
        {
            //if ( DatabaseDBUtil.getProperties() != null )
            //setEditorId(DatabaseDBUtil.getProperties().getUserId());
        }
    }
}