
namespace Models.local
{
	public class Queryrow : BaseClass.Queryrow//, Interfaces.IQueryrow
	{
		public Queryrow Clone()
		{
			Queryrow c = new Queryrow();
			c.Qrowid = Qrowid;
			c.Fname = Fname;
			c.Rname = Rname;
			c.Cndn = Cndn;
			c.Ctype = Ctype;
			c.Qresid = Qresid;
			c.Qrowscount = Qrowscount;
			c.Qres = Qres;

			return c;
		}
	}
}
