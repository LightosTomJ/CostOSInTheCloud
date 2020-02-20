
namespace Models.local.Interfaces
{
	public interface ILayoutcpanel
	{
		long Layoutcpanelid { get; set; }
		long? Layoutcid { get; set; }
		string Prefcols { get; set; }
		string Lockedcols { get; set; }
		string Sortedcols { get; set; }
		string Filtercols { get; set; }
		bool? Assment { get; set; }
		bool? Vizer { get; set; }
		string Selvizer { get; set; }
		bool? Side { get; set; }
		bool? Grpn { get; set; }
		bool? Dsgrp { get; set; }
		string Grpcols { get; set; }
		string Grpords { get; set; }
		bool? Vsble { get; set; }
		string Columns { get; set; }
		string Columnwidths { get; set; }
		bool? Sorttypeup { get; set; }
		int? Sortindex { get; set; }
		bool? Autoresize { get; set; }
		int? Rowheight { get; set; }
		bool? Filters { get; set; }
		bool? Xtralvl { get; set; }
		int? Layoutcpanelcount { get; set; }
		BaseClass.Layoutc Layoutc { get; set; }
		
		Layoutcpanel Clone();
	}
}
