using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Layoutcpanel
    {
        public long Layoutcpanelid { get; set; }
        public long? Layoutcid { get; set; }
        public string Prefcols { get; set; }
        public string Lockedcols { get; set; }
        public string Sortedcols { get; set; }
        public string Filtercols { get; set; }
        public bool? Assment { get; set; }
        public bool? Vizer { get; set; }
        public string Selvizer { get; set; }
        public bool? Side { get; set; }
        public bool? Grpn { get; set; }
        public bool? Dsgrp { get; set; }
        public string Grpcols { get; set; }
        public string Grpords { get; set; }
        public bool? Vsble { get; set; }
        public string Columns { get; set; }
        public string Columnwidths { get; set; }
        public bool? Sorttypeup { get; set; }
        public int? Sortindex { get; set; }
        public bool? Autoresize { get; set; }
        public int? Rowheight { get; set; }
        public bool? Filters { get; set; }
        public bool? Xtralvl { get; set; }
        public int? Layoutcpanelcount { get; set; }

        public virtual Layoutc Layoutc { get; set; }
    }
}
