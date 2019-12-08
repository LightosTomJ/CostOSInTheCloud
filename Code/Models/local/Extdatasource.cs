
namespace Models.local
{
	public class Extdatasource : BaseClass.Extdatasource//, Interfaces.IExtdatasource
	{
		public Extdatasource Clone()
		{
			Extdatasource c = new Extdatasource();
			c.Datasourceid = Datasourceid;
			c.Dstitle = Dstitle;
			c.Dstype = Dstype;
			c.Jdbctype = Jdbctype;
			c.Jdbcdriver = Jdbcdriver;
			c.Jdbcurl = Jdbcurl;
			c.Jdbcuser = Jdbcuser;
			c.Jdbcpsw = Jdbcpsw;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Editorid = Editorid;
			c.Lastupdate = Lastupdate;
			c.Extquery = Extquery;

			return c;
		}
	}
}
