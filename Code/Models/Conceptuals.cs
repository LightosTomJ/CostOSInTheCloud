using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Conceptuals
    {
        public long Conceptualid { get; set; }
        public string Title { get; set; }
        public string Currency { get; set; }
        public string Crewfacs { get; set; }
        public string Unit { get; set; }
        public string Titleconcat { get; set; }
        public string Matrate { get; set; }
        public string Matfab { get; set; }
        public string Matship { get; set; }
        public string Crews { get; set; }
        public string Subrate { get; set; }
        public string Weightunit { get; set; }
        public string Rawmat1 { get; set; }
        public string Rawmat2 { get; set; }
        public string Rawmat3 { get; set; }
        public string Rawmat4 { get; set; }
        public string Rawmat5 { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Rel1 { get; set; }
        public decimal? Rel2 { get; set; }
        public decimal? Rel3 { get; set; }
        public decimal? Rel4 { get; set; }
        public decimal? Rel5 { get; set; }
        public DateTime? Refdate { get; set; }
        public long? Paramoutputid { get; set; }
        public string Weightrate { get; set; }
        public string Subika { get; set; }
        public string Volflow { get; set; }
        public string Vfunit { get; set; }
        public string Massflow { get; set; }
        public string Mfunit { get; set; }
        public string Duty { get; set; }
        public string Dtunit { get; set; }
        public string Operpress { get; set; }
        public string Opunit { get; set; }
        public string Opertemp { get; set; }
        public string Otunit { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Extracode1 { get; set; }
        public string Extracode2 { get; set; }
        public string Extracode3 { get; set; }
        public string Extracode4 { get; set; }
        public string Extracode5 { get; set; }
        public string Extracode6 { get; set; }
        public string Extracode7 { get; set; }
        public string Notesconcat { get; set; }
        public string Descconcat { get; set; }
        public string Labrate { get; set; }
        public string Labika { get; set; }
        public string Conrate { get; set; }
        public string Equresrate { get; set; }
        public string Equlubrate { get; set; }
        public string Equtrsrate { get; set; }
        public string Equsprrate { get; set; }
        public string Equdeprate { get; set; }
        public string Equfulrate { get; set; }
        public string Equfucrate { get; set; }
        public string Equfutrate { get; set; }
        public string Ct01eq { get; set; }
        public string Ct02eq { get; set; }
        public string Ct03eq { get; set; }
        public string Ct04eq { get; set; }
        public string Ct05eq { get; set; }
        public string Ct06eq { get; set; }
        public string Ct07eq { get; set; }
        public string Ct08eq { get; set; }
        public string Ct09eq { get; set; }
        public string Ct10eq { get; set; }
        public string Cr01eq { get; set; }
        public string Cr02eq { get; set; }
        public string Cr03eq { get; set; }
        public string Cr04eq { get; set; }
        public string Cr05eq { get; set; }
        public string Cr06eq { get; set; }
        public string Cr07eq { get; set; }
        public string Cr08eq { get; set; }
        public string Cr09eq { get; set; }
        public string Cr10eq { get; set; }
        public string Cc01eq { get; set; }
        public string Cc02eq { get; set; }
        public string Cc03eq { get; set; }
        public string Cc04eq { get; set; }
        public string Cc05eq { get; set; }

        public virtual ParamOutput Paramoutput { get; set; }
    }
}
