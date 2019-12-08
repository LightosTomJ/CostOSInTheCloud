
namespace Models.local
{
	public class Extquery : BaseClass.Extquery//, Interfaces.IExtquery
	{
		public Extquery Clone()
		{
			Extquery c = new Extquery();
			c.Queryid = Queryid;
			c.Title = Title;
			c.Dsquery = Dsquery;
			c.Resourcetype = Resourcetype;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Editorid = Editorid;
			c.Lastupdate = Lastupdate;
			c.Datasourceid = Datasourceid;
			c.Datasource = Datasource;
			c.Extalias = Extalias;

			return c;
		}
	}
}
