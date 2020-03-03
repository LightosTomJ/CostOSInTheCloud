using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Projectwbs
    {
        public long Projectwbsid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Itemcode { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public decimal? Ufact { get; set; }
        public string Unit { get; set; }
        public decimal? Quantity { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
    }
}
