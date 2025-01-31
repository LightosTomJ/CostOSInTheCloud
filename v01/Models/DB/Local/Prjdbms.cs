﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class PrjDBMS
    {
        public PrjDBMS()
        {
            Projecturl = new HashSet<ProjectURL>();
        }

        public long Id { get; set; }
        public string Hname { get; set; }
        public string Hport { get; set; }
        public int? Hdbms { get; set; }
        public string Hinst { get; set; }
        public string Huser { get; set; }
        public string Hpass { get; set; }
        public string Dbname { get; set; }

        public virtual ICollection<ProjectURL> Projecturl { get; set; }
    }
}
