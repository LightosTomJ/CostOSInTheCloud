﻿using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Currency
    {
        public long Id { get; set; }
        public string Cname { get; set; }
        public string Symbol { get; set; }
        public string Isocode { get; set; }
        public string Isoflag { get; set; }
    }
}