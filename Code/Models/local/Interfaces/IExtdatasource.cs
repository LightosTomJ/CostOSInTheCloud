using System;
//using System.Collections.Generic;

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
		DateTime? Createdate { get; set; }
		string Editorid { get; set; }
		DateTime? Lastupdate { get; set; }
		//ICollection<Extquery> Extquery { get; set; }
		
		Extdatasource Clone();
	}
}
