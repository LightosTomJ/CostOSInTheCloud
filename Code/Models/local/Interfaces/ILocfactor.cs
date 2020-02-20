
namespace Models.local.Interfaces
{
	public interface ILocfactor
	{
		long Lfid { get; set; }
		string Parentecode { get; set; }
		string Editorid { get; set; }
		bool? Onln { get; set; }
		string Codetype { get; set; }
		string Tocountry { get; set; }
		string Tostate { get; set; }
		string Tocity { get; set; }
		string Tozipcode { get; set; }
		decimal? Labfac { get; set; }
		decimal? Matfac { get; set; }
		decimal? Subfac { get; set; }
		decimal? Confac { get; set; }
		decimal? Equfac { get; set; }
		decimal? Assfac { get; set; }
		string Geopoly { get; set; }
		long? Fid { get; set; }
		int? Faccount { get; set; }
		BaseClass.Locprof F { get; set; }
		
		Locfactor Clone();
	}
}
