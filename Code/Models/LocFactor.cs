using System;
using System.Collections.Generic;

namespace Models
{
    public partial class LocFactor
    {
        public long Lfid { get; set; }
        public string Parentecode { get; set; }
        public string Editorid { get; set; }
        public bool? Online { get; set; }
        public string Codetype { get; set; }
        public string Tocountry { get; set; }
        public string Tostate { get; set; }
        public string Tocity { get; set; }
        public string Tozipcode { get; set; }
        public decimal? Labfac { get; set; }
        public decimal? Matfac { get; set; }
        public decimal? Subfac { get; set; }
        public decimal? Confac { get; set; }
        public decimal? Equfac { get; set; }
        public decimal? Assfac { get; set; }
        public string Geopoly { get; set; }
        public long? Fid { get; set; }
        public int? Faccount { get; set; }
        public bool? Onln { get; set; }

        public virtual LocProf F { get; set; }
    }
}
