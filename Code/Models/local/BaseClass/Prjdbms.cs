using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Prjdbms
    {
        public Prjdbms()
        {
            Projecturl = new HashSet<Projecturl>();
        }

        public long Id { get; set; }
        public string Hname { get; set; }
        public string Hport { get; set; }
        public int? Hdbms { get; set; }
        public string Hinst { get; set; }
        public string Huser { get; set; }
        public string Hpass { get; set; }
        public string Dbname { get; set; }

        public virtual ICollection<Projecturl> Projecturl { get; set; }
    }
}
