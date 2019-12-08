
namespace Models.local.Interfaces
{
	public interface IExtquery
	{
		long Queryid { get; set; }
		string Title { get; set; }
		string Dsquery { get; set; }
		string Resourcetype { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Editorid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		long? Datasourceid { get; set; }
		Models.local.BaseClass.Extdatasource Datasource { get; set; }
		System.Collections.Generic.ICollection<Extalias> Extalias { get; set; }
		
		Extquery Clone();
	}
}
