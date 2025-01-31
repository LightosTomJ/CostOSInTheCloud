﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcQuantity
    {
        public long Id { get; set; }
        public string Grpname { get; set; }
        public string Name { get; set; }
        public int? Nameid { get; set; }
        public int? Qtype { get; set; }
        public decimal? Val { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
