﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class RateDistrib
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sortorder { get; set; }
        public int? Disttype { get; set; }
        public bool? Balanced { get; set; }
        public bool? Dstrbtd { get; set; }
        public string Targetfield { get; set; }
        public string Targetcostfield { get; set; }
        public string Distranges { get; set; }
        public string Distrates { get; set; }
        public bool? Mapped { get; set; }
        public int? Sheetno { get; set; }
        public int? Cellx { get; set; }
        public int? Celly { get; set; }
        public decimal? Stovalnum { get; set; }

        public virtual ProjectTemplate Template { get; set; }
    }
}
