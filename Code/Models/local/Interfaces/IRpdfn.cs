
namespace Models.local.Interfaces
{
	public interface IRpdfn
	{
		long Rpdfnid { get; set; }
		string Rname { get; set; }
		string Ricn { get; set; }
		string Rdsgn { get; set; }
		string Rdesc { get; set; }
		string Redtid { get; set; }
		string Rcreuser { get; set; }
		System.DateTime? Rlastupd { get; set; }
		System.DateTime? Rcredate { get; set; }
		string Rgrp { get; set; }
		bool? Rpblk { get; set; }
		bool? Rusrrep { get; set; }
		bool? Mltusrrpt { get; set; }
		string Reporttype { get; set; }
		string Rjsurl { get; set; }
		string Reportroles { get; set; }
		System.Collections.Generic.ICollection<Fldfn> Fldfn { get; set; }
		
		Rpdfn Clone();
	}
}
