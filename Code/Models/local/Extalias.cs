
namespace Models.local
{
	public class Extalias : BaseClass.Extalias//, Interfaces.IExtalias
	{
		public Extalias Clone()
		{
			Extalias c = new Extalias();
			c.Aliasid = Aliasid;
			c.Linenumber = Linenumber;
			c.Fromaliasclassname = Fromaliasclassname;
			c.Fromalias = Fromalias;
			c.Tofield = Tofield;
			c.Datamapping = Datamapping;
			c.Isquerycolumnid = Isquerycolumnid;
			c.Queryid = Queryid;
			c.Query = Query;

			return c;
		}
	}
}
