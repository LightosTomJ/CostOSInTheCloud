
namespace Models.local
{
	public class Prjdbms : BaseClass.Prjdbms//, Interfaces.IPrjdbms
	{
		public Prjdbms Clone()
		{
			Prjdbms c = new Prjdbms();
			c.Id = Id;
			c.Hname = Hname;
			c.Hport = Hport;
			c.Hdbms = Hdbms;
			c.Hinst = Hinst;
			c.Huser = Huser;
			c.Hpass = Hpass;
			c.Dbname = Dbname;
			c.Projecturl = Projecturl;

			return c;
		}
	}
}
