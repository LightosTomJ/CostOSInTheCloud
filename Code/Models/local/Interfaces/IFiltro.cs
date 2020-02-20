using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IFiltro
	{
		long Filtroid { get; set; }
		DateTime? Lastupdate { get; set; }
		string Filtroname { get; set; }
		string Filtrotype { get; set; }
		string Filtrodescription { get; set; }
		//ICollection<Filtroproperty> Filtroproperty { get; set; }
		
		Filtro Clone();
	}
}
