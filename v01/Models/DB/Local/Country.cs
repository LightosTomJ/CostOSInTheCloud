﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Country
    {
        public long Id { get; set; }
        public string Ccode { get; set; }
        public string Cname { get; set; }
    }
}
