
namespace Models.local.Interfaces
{
	public interface ILayoutc
	{
		long Layoutcid { get; set; }
		string Name { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Creatorid { get; set; }
		string Editorid { get; set; }
		string Selectedgk { get; set; }
		bool? Pblk { get; set; }
		bool? Dflt { get; set; }
		string Type { get; set; }
		string Visibtabs { get; set; }
		bool? Showtree { get; set; }
		bool? Spangrp { get; set; }
		bool? Rowstrp { get; set; }
		string Grpname { get; set; }
		string F1name { get; set; }
		int? F1size { get; set; }
		int? F1style { get; set; }
		string F2name { get; set; }
		int? F2size { get; set; }
		int? F2style { get; set; }
		string F3name { get; set; }
		int? F3size { get; set; }
		int? F3style { get; set; }
		string F4name { get; set; }
		int? F4size { get; set; }
		string Fnname { get; set; }
		int? Fnsize { get; set; }
		int? Fnstyle { get; set; }
		string Fnclr { get; set; }
		string Funame { get; set; }
		int? Fusize { get; set; }
		int? Fustyle { get; set; }
		string Fuclr { get; set; }
		int? F4style { get; set; }
		string F5name { get; set; }
		int? F5size { get; set; }
		int? F5style { get; set; }
		string Lfname { get; set; }
		int? Lfsize { get; set; }
		int? Lfstyle { get; set; }
		string F1clr { get; set; }
		string F2clr { get; set; }
		string F3clr { get; set; }
		string F4clr { get; set; }
		string F5clr { get; set; }
		string Lfclr { get; set; }
		string Rs1clr { get; set; }
		string Rs2clr { get; set; }
		bool? Mltln { get; set; }
		int? Zoom { get; set; }
		bool? Gridon { get; set; }
		bool? Hgridon { get; set; }
		bool? F1undl { get; set; }
		bool? F2undl { get; set; }
		bool? F3undl { get; set; }
		bool? F4undl { get; set; }
		bool? F5undl { get; set; }
		bool? Fnundl { get; set; }
		bool? Fuundl { get; set; }
		bool? Flundl { get; set; }
		string L1bclr { get; set; }
		string L2bclr { get; set; }
		string L3bclr { get; set; }
		string L4bclr { get; set; }
		string L5bclr { get; set; }
		string Lnbclr { get; set; }
		string Unbclr { get; set; }
		string Lfbclr { get; set; }
		bool? Rowhead { get; set; }
		bool? Csep { get; set; }
		string Csepclr { get; set; }
		string Gridclr { get; set; }
		string Layoutroles { get; set; }
		System.Collections.Generic.ICollection<Layoutcpanel> Layoutcpanel { get; set; }
		
		Layoutc Clone();
	}
}
