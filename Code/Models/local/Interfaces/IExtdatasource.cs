
namespace Models.local.Interfaces
{
	public interface IExtdatasource
	{
		long Datasourceid { get; set; }
		string Dstitle { get; set; }
		byte? Dstype { get; set; }
		byte? Jdbctype { get; set; }
		string Jdbcdriver { get; set; }
		string Jdbcurl { get; set; }
		string Jdbcuser { get; set; }
		string Jdbcpsw { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Editorid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		System.Collections.Generic.ICollection<Extquery> Extquery { get; set; }
		
		Extdatasource Clone();
	}
}
