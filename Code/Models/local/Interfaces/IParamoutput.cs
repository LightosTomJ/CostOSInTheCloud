//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IParamoutput
	{
		long Paramoutputid { get; set; }
		string Qtyeq { get; set; }
		string Factoreq { get; set; }
		string Labloceq { get; set; }
		string Matloceq { get; set; }
		string Equloceq { get; set; }
		string Subloceq { get; set; }
		string Conloceq { get; set; }
		string Prdeq { get; set; }
		string Title { get; set; }
		string Resids { get; set; }
		string Generation { get; set; }
		int? Sortorder { get; set; }
		string Loopvar { get; set; }
		long? Paramitemid { get; set; }
		BaseClass.Paramitem Paramitem { get; set; }
		//ICollection<Conceptuals> Conceptuals { get; set; }
		//ICollection<Queryresource> Queryresource { get; set; }
		
		Paramoutput Clone();
	}
}
