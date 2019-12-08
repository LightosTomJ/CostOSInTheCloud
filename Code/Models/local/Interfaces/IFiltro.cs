
namespace Models.local.Interfaces
{
	public interface IFiltro
	{
		long Filtroid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Filtroname { get; set; }
		string Filtrotype { get; set; }
		string Filtrodescription { get; set; }
		System.Collections.Generic.ICollection<Filtroproperty> Filtroproperty { get; set; }
		
		Filtro Clone();
	}
}
