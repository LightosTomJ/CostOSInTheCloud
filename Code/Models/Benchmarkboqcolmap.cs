using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Benchmarkboqcolmap
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Frombench { get; set; }
        public string Toboq { get; set; }
        public string Aggregate { get; set; }
        public string Viewname { get; set; }
    }
}
