using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface ILocprof
	{
		long Functionid { get; set; }
		string Fromcountry { get; set; }
		string Fromstate { get; set; }
		string Name { get; set; }
		bool? Supstate { get; set; }
		string Editorid { get; set; }
		string Createuserid { get; set; }
		DateTime? Createdate { get; set; }
		DateTime? Lastupdate { get; set; }
		//ICollection<Locfactor> Locfactor { get; set; }
		
		Locprof Clone();
	}
}
