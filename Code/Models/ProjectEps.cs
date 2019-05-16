using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ProjectEps
    {
        public ProjectEps()
        {
            ProjectInfo = new HashSet<ProjectInfo>();
        }

        public long Projectepsid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public string Description { get; set; }
        public DateTime? Lastupdate { get; set; }
        public long? Parentid { get; set; }

        public virtual ICollection<ProjectInfo> ProjectInfo { get; set; }
    }
}
