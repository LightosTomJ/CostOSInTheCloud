using System;
using System.Collections.Generic;

namespace Model.DB.Project
{
    public partial class Rawmaterial
    {
        public long Rawmatid { get; set; }
        public string Code { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? RateDate { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }
    }
}
