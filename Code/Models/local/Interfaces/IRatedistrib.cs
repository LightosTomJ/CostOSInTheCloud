
namespace Models.local.Interfaces
{
	public interface IRatedistrib
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		int? Sortorder { get; set; }
		int? Disttype { get; set; }
		bool? Balanced { get; set; }
		bool? Dstrbtd { get; set; }
		string Targetfield { get; set; }
		string Targetcostfield { get; set; }
		string Distranges { get; set; }
		string Distrates { get; set; }
		bool? Mapped { get; set; }
		int? Sheetno { get; set; }
		int? Cellx { get; set; }
		int? Celly { get; set; }
		decimal? Stovalnum { get; set; }
		Models.local.BaseClass.Projecttemplate Template { get; set; }
		
		Ratedistrib Clone();
	}
}
