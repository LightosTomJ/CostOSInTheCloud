
namespace Models.local.Interfaces
{
	public interface IProjectspecvar
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string Datatype { get; set; }
		string Defval { get; set; }
		string Stoval { get; set; }
		int? Sortorder { get; set; }
		int? Cellx { get; set; }
		int? Celly { get; set; }
		int? Sheetno { get; set; }
		bool? Mapped { get; set; }
		decimal? Stovalnum { get; set; }
		bool? Isnumber { get; set; }
		bool? Mandatory { get; set; }
		string Pushfield { get; set; }
		BaseClass.Projecttemplate Template { get; set; }
		
		Projectspecvar Clone();
	}
}
