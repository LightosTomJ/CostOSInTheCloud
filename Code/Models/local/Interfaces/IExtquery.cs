using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IExtquery
	{
		long Queryid { get; set; }
		string Title { get; set; }
		string Dsquery { get; set; }
		string Resourcetype { get; set; }
		string Createuser { get; set; }
		DateTime? Createdate { get; set; }
		string Editorid { get; set; }
		DateTime? Lastupdate { get; set; }
		long? Datasourceid { get; set; }
		BaseClass.Extdatasource Datasource { get; set; }
		//ICollection<Extalias> Extalias { get; set; }
		
		Extquery Clone();
	}
}
