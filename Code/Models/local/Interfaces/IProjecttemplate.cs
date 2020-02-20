using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IProjecttemplate
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Title { get; set; }
		string Editorid { get; set; }
		string Userid { get; set; }
		DateTime? Lastupdate { get; set; }
		DateTime? Createdate { get; set; }
		string Createuser { get; set; }
		long? Databaseid { get; set; }
		long? Dbcreatedate { get; set; }
		bool? Pblk { get; set; }
		bool? Hasbuildups { get; set; }
		bool? Hasdistributors { get; set; }
		bool? Allowviewers { get; set; }
		string Description { get; set; }
		BaseClass.Xcellfile Template { get; set; }
		//ICollection<Projectspecvar> Projectspecvar { get; set; }
		//ICollection<Ratebuildup> Ratebuildup { get; set; }
		//ICollection<Ratebuildupcols> Ratebuildupcols { get; set; }
		//ICollection<Ratedistrib> Ratedistrib { get; set; }
		
		Projecttemplate Clone();
	}
}
