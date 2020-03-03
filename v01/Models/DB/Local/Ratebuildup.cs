using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Ratebuildup
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Restype { get; set; }
        public long? Resid { get; set; }
        public long? Resprjid { get; set; }
        public bool? Onln { get; set; }
        public long? Dbcreatedate { get; set; }
        public string Calcformula { get; set; }
        public string Overrate1 { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Rate0 { get; set; }
        public decimal? Rate1 { get; set; }
        public decimal? Rate2 { get; set; }
        public decimal? Rate3 { get; set; }
        public decimal? Rate4 { get; set; }
        public decimal? Rate5 { get; set; }
        public decimal? Rate6 { get; set; }
        public decimal? Rate7 { get; set; }
        public decimal? Rate8 { get; set; }
        public decimal? Rate9 { get; set; }
        public decimal? Rate10 { get; set; }
        public decimal? Rate11 { get; set; }
        public decimal? Rate12 { get; set; }
        public decimal? Rate13 { get; set; }
        public decimal? Rate14 { get; set; }

        public virtual Projecttemplate Template { get; set; }
    }
}
