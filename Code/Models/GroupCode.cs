using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Groupcode
    {
        public long Groupcodeid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Description { get; set; }
        public string Groupcode1 { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public decimal? Ufact { get; set; }
        public string Unit { get; set; }
    }
}
