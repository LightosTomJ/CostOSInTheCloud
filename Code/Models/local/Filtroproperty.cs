
namespace Models.local
{
	public class Filtroproperty : BaseClass.Filtroproperty//, Interfaces.IFiltroproperty
	{
		public Filtroproperty Clone()
		{
			Filtroproperty c = new Filtroproperty();
			c.Filtropropertyid = Filtropropertyid;
			c.Used = Used;
			c.Usetype = Usetype;
			c.Field = Field;
			c.Restriction = Restriction;
			c.Filtroid = Filtroid;
			c.Filtropropertiescount = Filtropropertiescount;
			c.Filtro = Filtro;

			return c;
		}
	}
}
