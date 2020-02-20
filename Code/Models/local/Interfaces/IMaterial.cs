using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IMaterial
	{
		long Materialid { get; set; }
		string Accuracy { get; set; }
		string Description { get; set; }
		bool? Virtual { get; set; }
		bool? Predicted { get; set; }
		int? Tchtype { get; set; }
		decimal? Tval { get; set; }
		string Tunit { get; set; }
		int? Tcolor { get; set; }
		int? Tregtype { get; set; }
		string Trids { get; set; }
		DateTime? Trdate { get; set; }
		bool? Conceptual { get; set; }
		string Bimmaterial { get; set; }
		string Bimtype { get; set; }
		string Country { get; set; }
		string Rawmat { get; set; }
		decimal? Reliance { get; set; }
		string Rawmat2 { get; set; }
		decimal? Reliance2 { get; set; }
		string Rawmat3 { get; set; }
		decimal? Reliance3 { get; set; }
		string Rawmat4 { get; set; }
		decimal? Reliance4 { get; set; }
		string Rawmat5 { get; set; }
		decimal? Reliance5 { get; set; }
		string Unit { get; set; }
		decimal? Rate { get; set; }
		decimal? Shiprate { get; set; }
		decimal? Fabrate { get; set; }
		decimal? Totalrate { get; set; }
		string Inclusion { get; set; }
		decimal? Distance { get; set; }
		string Distunit { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Project { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		string Stateprovince { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Rescode { get; set; }
		string Title { get; set; }
		string Suppliername { get; set; }
		string Currency { get; set; }
		decimal? Weight { get; set; }
		string Weightunit { get; set; }
		decimal? Volflow { get; set; }
		decimal? Msflow { get; set; }
		decimal? Duty { get; set; }
		decimal? Opres { get; set; }
		decimal? Optmp { get; set; }
		string Vlflowut { get; set; }
		string Msflowut { get; set; }
		string Dutyut { get; set; }
		string Optemput { get; set; }
		string Opresut { get; set; }
		decimal? Qty { get; set; }
		long? Supplierid { get; set; }
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
		int? Overtype { get; set; }
		BaseClass.Supplier Supplier { get; set; }
		//ICollection<AssemblyMaterial> AssemblyMaterial { get; set; }
		
		Material Clone();
	}
}
