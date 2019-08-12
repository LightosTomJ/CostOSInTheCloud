using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectResourceTableList
    {

        public List<ProjectResourceTable> ProjectResourceItems { get; set; }
        public const long serialVersionUID = 1L;

        public ProjectResourceTableList()
        {
            ProjectResourceItems = new List<ProjectResourceTable>();

        }
    }
}