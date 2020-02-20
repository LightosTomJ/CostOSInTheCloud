
namespace Models.local.Interfaces
{
	public interface IFiltroproperty
	{
		long Filtropropertyid { get; set; }
		bool? Used { get; set; }
		string Usetype { get; set; }
		string Field { get; set; }
		string Restriction { get; set; }
		long? Filtroid { get; set; }
		int? Filtropropertiescount { get; set; }
		BaseClass.Filtro Filtro { get; set; }
		
		Filtroproperty Clone();
	}
}
