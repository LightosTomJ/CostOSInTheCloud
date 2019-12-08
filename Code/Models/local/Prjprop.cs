
namespace Models.local
{
	public class Prjprop : BaseClass.Prjprop//, Interfaces.IPrjprop
	{
		public Prjprop Clone()
		{
			Prjprop c = new Prjprop();
			c.Id = Id;
			c.Pkey = Pkey;
			c.Pval = Pval;
			c.Projecturlid = Projecturlid;
			c.Projecturl = Projecturl;

			return c;
		}
	}
}
