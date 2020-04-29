using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BenchmarkBOQColMap
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Frombench { get; set; }
        public string Toboq { get; set; }
        public string Aggregate { get; set; }
        public string Viewname { get; set; }
    }
}
