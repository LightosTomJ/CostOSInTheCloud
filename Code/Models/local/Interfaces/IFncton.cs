using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IFncton
	{
		long Functionid { get; set; }
		DateTime? Lastupdate { get; set; }
		bool? Takeoff { get; set; }
		string Createuserid { get; set; }
		string Editorid { get; set; }
		DateTime? Createdate { get; set; }
		string Name { get; set; }
		string Unit { get; set; }
		string Grouping { get; set; }
		string Description { get; set; }
		string Lang { get; set; }
		string Pswd { get; set; }
		string Snum { get; set; }
		string Prttype { get; set; }
		string Impl { get; set; }
		string Restype { get; set; }
		//ICollection<FnctonArgument> FnctonArgument { get; set; }
		
		Fncton Clone();
	}
}