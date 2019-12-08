
namespace Models.local
{
	public class Filtro : BaseClass.Filtro//, Interfaces.IFiltro
	{
		public Filtro Clone()
		{
			Filtro c = new Filtro();
			c.Filtroid = Filtroid;
			c.Lastupdate = Lastupdate;
			c.Filtroname = Filtroname;
			c.Filtrotype = Filtrotype;
			c.Filtrodescription = Filtrodescription;
			c.Filtroproperty = Filtroproperty;

			return c;
		}
	}
}
