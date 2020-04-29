using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class ProjectEPS
    {
        public ProjectEPS()
        {
            Projectinfo = new HashSet<ProjectInfo>();
        }

        public long Projectepsid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public string Description { get; set; }
        public DateTime? Lastupdate { get; set; }
        public long? Parentid { get; set; }

        public virtual ICollection<ProjectInfo> Projectinfo { get; set; }
    }
}
