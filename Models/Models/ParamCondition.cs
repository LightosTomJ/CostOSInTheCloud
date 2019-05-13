using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ParamCondition
    {
        public long Conditionid { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? Selqty { get; set; }
        public decimal? Qty1 { get; set; }
        public decimal? Qty2 { get; set; }
        public decimal? Qty3 { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        public string Dbname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int? Bidno { get; set; }
        public int? Cndno { get; set; }
        public string Cndtype { get; set; }
        public int? Cndid { get; set; }
        public string Globalid { get; set; }
        public string Takeofftype { get; set; }
        public string Building { get; set; }
        public string Storey { get; set; }
        public string Location { get; set; }
        public string Layer { get; set; }
        public string Qty1name { get; set; }
        public string Qty2name { get; set; }
        public string Qty3name { get; set; }
        public string Formula1 { get; set; }
        public string Formula2 { get; set; }
        public string Formula3 { get; set; }
        public string Bimtype { get; set; }
        public string Bimmaterial { get; set; }
        public long? Paramitemid { get; set; }
        public long? Paraminputid { get; set; }
        public bool? Virt { get; set; }
        public string Fctstate { get; set; }
        public decimal? Qtyf { get; set; }
        public string Unitf { get; set; }
        public string Qtyfname { get; set; }
        public string Formulaf { get; set; }

        public virtual ParamInput Paraminput { get; set; }
    }
}
