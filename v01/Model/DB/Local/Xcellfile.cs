using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class Xcellfile
    {
        public Xcellfile()
        {
            Projecttemplate = new HashSet<Projecttemplate>();
        }

        public long Xcellid { get; set; }
        public byte[] Xcellfile1 { get; set; }
        public int? Sheet { get; set; }
        public int? Cellx { get; set; }
        public int? Celly { get; set; }

        public virtual ICollection<Projecttemplate> Projecttemplate { get; set; }
    }
}
