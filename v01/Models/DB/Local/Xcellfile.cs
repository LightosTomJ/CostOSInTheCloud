using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class XcellFile
    {
        public XcellFile()
        {
            Projecttemplate = new HashSet<ProjectTemplate>();
        }

        public long Xcellid { get; set; }
        public byte[] Xcellfile1 { get; set; }
        public int? Sheet { get; set; }
        public int? Cellx { get; set; }
        public int? Celly { get; set; }

        public virtual ICollection<ProjectTemplate> Projecttemplate { get; set; }
    }
}
