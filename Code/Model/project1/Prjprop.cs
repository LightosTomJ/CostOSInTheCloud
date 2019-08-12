using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Prjprop
    {
        public long Id { get; set; }
        public string Pkey { get; set; }
        public string Pval { get; set; }
        public long? Projecturlid { get; set; }

        public virtual Projecturl Projecturl { get; set; }
    }
}
