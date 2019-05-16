using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ProjectAccess
    {
        public long Paid { get; set; }
        public string Title { get; set; }
        public string Acccon { get; set; }
        public bool? Aladd { get; set; }
        public bool? Alupd { get; set; }
        public bool? Alrem { get; set; }
        public long? Puid { get; set; }

        public virtual ProjectUser Pu { get; set; }
    }
}
