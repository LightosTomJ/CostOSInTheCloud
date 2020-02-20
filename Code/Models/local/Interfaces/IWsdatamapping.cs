using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IWsdatamapping
	{
		long Id { get; set; }
		string Title { get; set; }
		string Celldtingn { get; set; }
		int? Groupcol { get; set; }
		string Treemapping { get; set; }
		bool? Commentdetect { get; set; }
		bool? Treedetect { get; set; }
		string Tableprefer { get; set; }
		//ICollection<Wscolident> Wscolident { get; set; }
		//ICollection<Wsrevision> Wsrevision { get; set; }
		
		Wsdatamapping Clone();
	}
}
