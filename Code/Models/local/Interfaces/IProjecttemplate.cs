
namespace Models.local.Interfaces
{
	public interface IProjecttemplate
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Title { get; set; }
		string Editorid { get; set; }
		string Userid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		System.DateTime? Createdate { get; set; }
		string Createuser { get; set; }
		long? Databaseid { get; set; }
		long? Dbcreatedate { get; set; }
		bool? Pblk { get; set; }
		bool? Hasbuildups { get; set; }
		bool? Hasdistributors { get; set; }
		bool? Allowviewers { get; set; }
		string Description { get; set; }
		Models.local.BaseClass.Xcellfile Template { get; set; }
		System.Collections.Generic.ICollection<Projectspecvar> Projectspecvar { get; set; }
		System.Collections.Generic.ICollection<Ratebuildup> Ratebuildup { get; set; }
		System.Collections.Generic.ICollection<Ratebuildupcols> Ratebuildupcols { get; set; }
		System.Collections.Generic.ICollection<Ratedistrib> Ratedistrib { get; set; }
		
		Projecttemplate Clone();
	}
}
