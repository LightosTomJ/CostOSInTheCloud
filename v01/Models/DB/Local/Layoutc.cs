using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class Layoutc
    {
        public Layoutc()
        {
            Layoutcpanel = new HashSet<Layoutcpanel>();
        }

        public long Layoutcid { get; set; }
        public string Name { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Creatorid { get; set; }
        public string Editorid { get; set; }
        public string Selectedgk { get; set; }
        public bool? Pblk { get; set; }
        public bool? Dflt { get; set; }
        public string Type { get; set; }
        public string Visibtabs { get; set; }
        public bool? Showtree { get; set; }
        public bool? Spangrp { get; set; }
        public bool? Rowstrp { get; set; }
        public string Grpname { get; set; }
        public string F1name { get; set; }
        public int? F1size { get; set; }
        public int? F1style { get; set; }
        public string F2name { get; set; }
        public int? F2size { get; set; }
        public int? F2style { get; set; }
        public string F3name { get; set; }
        public int? F3size { get; set; }
        public int? F3style { get; set; }
        public string F4name { get; set; }
        public int? F4size { get; set; }
        public string Fnname { get; set; }
        public int? Fnsize { get; set; }
        public int? Fnstyle { get; set; }
        public string Fnclr { get; set; }
        public string Funame { get; set; }
        public int? Fusize { get; set; }
        public int? Fustyle { get; set; }
        public string Fuclr { get; set; }
        public int? F4style { get; set; }
        public string F5name { get; set; }
        public int? F5size { get; set; }
        public int? F5style { get; set; }
        public string Lfname { get; set; }
        public int? Lfsize { get; set; }
        public int? Lfstyle { get; set; }
        public string F1clr { get; set; }
        public string F2clr { get; set; }
        public string F3clr { get; set; }
        public string F4clr { get; set; }
        public string F5clr { get; set; }
        public string Lfclr { get; set; }
        public string Rs1clr { get; set; }
        public string Rs2clr { get; set; }
        public bool? Mltln { get; set; }
        public int? Zoom { get; set; }
        public bool? Gridon { get; set; }
        public bool? Hgridon { get; set; }
        public bool? F1undl { get; set; }
        public bool? F2undl { get; set; }
        public bool? F3undl { get; set; }
        public bool? F4undl { get; set; }
        public bool? F5undl { get; set; }
        public bool? Fnundl { get; set; }
        public bool? Fuundl { get; set; }
        public bool? Flundl { get; set; }
        public string L1bclr { get; set; }
        public string L2bclr { get; set; }
        public string L3bclr { get; set; }
        public string L4bclr { get; set; }
        public string L5bclr { get; set; }
        public string Lnbclr { get; set; }
        public string Unbclr { get; set; }
        public string Lfbclr { get; set; }
        public bool? Rowhead { get; set; }
        public bool? Csep { get; set; }
        public string Csepclr { get; set; }
        public string Gridclr { get; set; }
        public string Layoutroles { get; set; }

        public virtual ICollection<Layoutcpanel> Layoutcpanel { get; set; }
    }
}
