﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class AssemblyConsumable
    {
        public long Assemblyconsumableid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Divider { get; set; }
        public decimal? Qtypunit { get; set; }
        public string Qtypunitform { get; set; }
        public byte? Qtypuformstate { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Exchangerate { get; set; }
        public decimal? Fixedcost { get; set; }
        public decimal? Finalfixedcost { get; set; }
        public string PvVars { get; set; }
        public long? Consumableid { get; set; }
        public long? Assemblyid { get; set; }

        public virtual Assembly Assembly { get; set; }
        public virtual Consumable Consumable { get; set; }
    }
}
