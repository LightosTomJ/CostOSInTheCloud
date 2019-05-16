using System;
using System.Collections.Generic;

namespace Models
{
    public partial class RawMaterial
    {
        public long Rawmatid { get; set; }
        public string Code { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? RateDate { get; set; }
    }
}
