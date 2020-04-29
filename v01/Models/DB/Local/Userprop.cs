using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class UserProp
    {
        public long Id { get; set; }
        public string Userid { get; set; }
        public string Pkey { get; set; }
        public string Pval { get; set; }
    }
}
