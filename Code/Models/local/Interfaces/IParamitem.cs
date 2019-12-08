
namespace Models.local.Interfaces
{
	public interface IParamitem
	{
		long Paramitemid { get; set; }
		decimal? Samplerate { get; set; }
		string Icon { get; set; }
		bool? Cmodel { get; set; }
		string Groupname { get; set; }
		decimal? Totalcost { get; set; }
		decimal? Qty { get; set; }
		bool? Multunitqty { get; set; }
		string Variable { get; set; }
		string Description { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Rescode { get; set; }
		string Titleequ { get; set; }
		string Groupidentity { get; set; }
		string Title { get; set; }
		string Unit { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Editorid { get; set; }
		string Notes { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Extracode1 { get; set; }
		string Extracode2 { get; set; }
		string Extracode3 { get; set; }
		string Extracode4 { get; set; }
		string Extracode5 { get; set; }
		string Extracode6 { get; set; }
		string Extracode7 { get; set; }
		string Extracode8 { get; set; }
		string Extracode9 { get; set; }
		string Extracode10 { get; set; }
		string Wbs { get; set; }
		string Wbs2 { get; set; }
		string Loc { get; set; }
		string Pswd { get; set; }
		string Snum { get; set; }
		string Prttype { get; set; }
		string Createuserid { get; set; }
		System.DateTime? Createdate { get; set; }
		System.Collections.Generic.ICollection<Paraminput> Paraminput { get; set; }
		System.Collections.Generic.ICollection<Paramoutput> Paramoutput { get; set; }
		System.Collections.Generic.ICollection<Paramreturn> Paramreturn { get; set; }
		
		Paramitem Clone();
	}
}
