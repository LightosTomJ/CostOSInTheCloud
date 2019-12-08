
namespace Models.local.Interfaces
{
	public interface IRatebuildup
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Restype { get; set; }
		long? Resid { get; set; }
		long? Resprjid { get; set; }
		bool? Onln { get; set; }
		long? Dbcreatedate { get; set; }
		string Calcformula { get; set; }
		string Overrate1 { get; set; }
		decimal? Frate { get; set; }
		decimal? Rate0 { get; set; }
		decimal? Rate1 { get; set; }
		decimal? Rate2 { get; set; }
		decimal? Rate3 { get; set; }
		decimal? Rate4 { get; set; }
		decimal? Rate5 { get; set; }
		decimal? Rate6 { get; set; }
		decimal? Rate7 { get; set; }
		decimal? Rate8 { get; set; }
		decimal? Rate9 { get; set; }
		decimal? Rate10 { get; set; }
		decimal? Rate11 { get; set; }
		decimal? Rate12 { get; set; }
		decimal? Rate13 { get; set; }
		decimal? Rate14 { get; set; }
		Models.local.BaseClass.Projecttemplate Template { get; set; }
		
		Ratebuildup Clone();
	}
}
