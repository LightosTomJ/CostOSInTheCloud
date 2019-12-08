
namespace Models.local.Interfaces
{
	public interface IExtalias
	{
		long Aliasid { get; set; }
		short ? Linenumber { get; set; }
		string Fromaliasclassname { get; set; }
		string Fromalias { get; set; }
		string Tofield { get; set; }
		string Datamapping { get; set; }
		bool? Isquerycolumnid { get; set; }
		long? Queryid { get; set; }
		Models.local.BaseClass.Extquery Query { get; set; }
		
		Extalias Clone();
	}
}
