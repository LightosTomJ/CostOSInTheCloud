using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class RateBuildUpCols
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Restype { get; set; }
        public string Tablepref { get; set; }
        public string Sortpref { get; set; }
        public bool? Applyall { get; set; }
        public string Rowformula { get; set; }
        public string Colname0 { get; set; }
        public int? Coltype0 { get; set; }
        public bool? Colact0 { get; set; }
        public string Colform0 { get; set; }
        public string Colname1 { get; set; }
        public int? Coltype1 { get; set; }
        public bool? Colact1 { get; set; }
        public string Colform1 { get; set; }
        public string Colname2 { get; set; }
        public int? Coltype2 { get; set; }
        public bool? Colact2 { get; set; }
        public string Colform2 { get; set; }
        public string Colname3 { get; set; }
        public int? Coltype3 { get; set; }
        public bool? Colact3 { get; set; }
        public string Colform3 { get; set; }
        public string Colname4 { get; set; }
        public int? Coltype4 { get; set; }
        public bool? Colact4 { get; set; }
        public string Colform4 { get; set; }
        public string Colname5 { get; set; }
        public int? Coltype5 { get; set; }
        public bool? Colact5 { get; set; }
        public string Colform5 { get; set; }
        public string Colname6 { get; set; }
        public int? Coltype6 { get; set; }
        public bool? Colact6 { get; set; }
        public string Colform6 { get; set; }
        public string Colname7 { get; set; }
        public int? Coltype7 { get; set; }
        public bool? Colact7 { get; set; }
        public string Colform7 { get; set; }
        public string Colname8 { get; set; }
        public int? Coltype8 { get; set; }
        public bool? Colact8 { get; set; }
        public string Colform8 { get; set; }
        public string Colname9 { get; set; }
        public int? Coltype9 { get; set; }
        public bool? Colact9 { get; set; }
        public string Colform9 { get; set; }
        public string Colname10 { get; set; }
        public int? Coltype10 { get; set; }
        public bool? Colact10 { get; set; }
        public string Colform10 { get; set; }
        public string Colname11 { get; set; }
        public int? Coltype11 { get; set; }
        public bool? Colact11 { get; set; }
        public string Colform11 { get; set; }
        public string Colname12 { get; set; }
        public int? Coltype12 { get; set; }
        public bool? Colact12 { get; set; }
        public string Colform12 { get; set; }
        public string Colname13 { get; set; }
        public int? Coltype13 { get; set; }
        public bool? Colact13 { get; set; }
        public string Colform13 { get; set; }
        public string Colname14 { get; set; }
        public int? Coltype14 { get; set; }
        public bool? Colact14 { get; set; }
        public string Colform14 { get; set; }
        public decimal? Coldefval0 { get; set; }
        public decimal? Coldefval1 { get; set; }
        public decimal? Coldefval2 { get; set; }
        public decimal? Coldefval3 { get; set; }
        public decimal? Coldefval4 { get; set; }
        public decimal? Coldefval5 { get; set; }
        public decimal? Coldefval6 { get; set; }
        public decimal? Coldefval7 { get; set; }
        public decimal? Coldefval8 { get; set; }
        public decimal? Coldefval9 { get; set; }
        public decimal? Coldefval10 { get; set; }
        public decimal? Coldefval11 { get; set; }
        public decimal? Coldefval12 { get; set; }
        public decimal? Coldefval13 { get; set; }
        public decimal? Coldefval14 { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual ProjectTemplate Template { get; set; }
    }
}
