using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectInfoTableList
    {
        // public Vector _o_items;
        public List<ProjectInfoTable> ProjectInfos;
        public const long serialVersionUID = 1L;

        public ProjectInfoTableList()
        {
            ProjectInfos = new List<ProjectInfoTable>();
        }
    }
}