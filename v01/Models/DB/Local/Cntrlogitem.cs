using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class CntrLogItem
    {
        public long Id { get; set; }
        public long? Logid { get; set; }
        public string Fltr { get; set; }
        public byte? Oprtn { get; set; }
        public long? Itemid { get; set; }
        public string Item { get; set; }
        public long? Prjid { get; set; }
    }
}
