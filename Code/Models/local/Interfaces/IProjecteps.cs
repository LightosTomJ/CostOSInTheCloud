using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IProjecteps
	{
		long Projectepsid { get; set; }
		string Code { get; set; }
		string Title { get; set; }
		string Editorid { get; set; }
		string Description { get; set; }
		DateTime? Lastupdate { get; set; }
		long? Parentid { get; set; }
		//ICollection<Projectinfo> Projectinfo { get; set; }
		
		Projecteps Clone();
	}
}
