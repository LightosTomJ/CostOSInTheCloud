using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class UnitAlias
    {
        public long Id { get; set; }
        public string Frunit { get; set; }
        public string Tounit { get; set; }
    }
}
