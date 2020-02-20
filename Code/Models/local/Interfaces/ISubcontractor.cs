//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface ISubcontractor
	{
		long Subcontractorid { get; set; }
		string Description { get; set; }
		string Accuracy { get; set; }
		string Inclusion { get; set; }
		bool? Virtual { get; set; }
		bool? Predicted { get; set; }
		int? Tchtype { get; set; }
		decimal? Tval { get; set; }
		string Tunit { get; set; }
		int? Tcolor { get; set; }
		int? Tregtype { get; set; }
		string Trids { get; set; }
		System.DateTime? Trdate { get; set; }
		bool? Conceptual { get; set; }
		string Unit { get; set; }
		decimal? Matrate { get; set; }
		decimal? Rate { get; set; }
		decimal? Ika { get; set; }
		decimal? Qty { get; set; }
		decimal? Totalrate { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Editorid { get; set; }
		string Performance { get; set; }
		string Project { get; set; }
		string Contactperson { get; set; }
		string Company { get; set; }
		string Phonenumber { get; set; }
		string Mobilenumber { get; set; }
		string Faxnumber { get; set; }
		string Email { get; set; }
		string Url { get; set; }
		string Country { get; set; }
		string City { get; set; }
		string Stateprovince { get; set; }
		string Address { get; set; }
		string Notes { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Rescode { get; set; }
		string Title { get; set; }
		string Currency { get; set; }
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
		//ICollection<AssemblySubcontractor> AssemblySubcontractor { get; set; }
		
		Subcontractor Clone();
	}
}
