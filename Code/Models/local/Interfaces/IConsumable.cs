
namespace Models.local.Interfaces
{
	public interface IConsumable
	{
		long Consumableid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Rescode { get; set; }
		int? Overtype { get; set; }
		string Description { get; set; }
		string Unit { get; set; }
		decimal? Rate { get; set; }
		decimal? Qty { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Project { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Title { get; set; }
		string Notes { get; set; }
		string Currency { get; set; }
		string Editorid { get; set; }
		string Stateprovince { get; set; }
		string Country { get; set; }
		bool? Virtual { get; set; }
		bool? Predicted { get; set; }
		bool? Conceptual { get; set; }
		int? Tchtype { get; set; }
		decimal? Tval { get; set; }
		string Tunit { get; set; }
		int? Tcolor { get; set; }
		int? Tregtype { get; set; }
		string Trids { get; set; }
		System.DateTime? Trdate { get; set; }
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
		System.Collections.Generic.ICollection<AssemblyConsumable> AssemblyConsumable { get; set; }
		
		Consumable Clone();
	}
}
