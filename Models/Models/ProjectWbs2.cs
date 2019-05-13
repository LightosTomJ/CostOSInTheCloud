using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ProjectWbs2
    {
        public long Projectwbsid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public string Projectname { get; set; }
        public long? Projectinfoid { get; set; }
        public string Unit { get; set; }
        public decimal? Ufact { get; set; }
        public string Itemcode { get; set; }

        public virtual ProjectInfo Projectinfo { get; set; }
    }
}
