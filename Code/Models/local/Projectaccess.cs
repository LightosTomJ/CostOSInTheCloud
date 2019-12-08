
namespace Models.local
{
	public class Projectaccess : BaseClass.Projectaccess//, Interfaces.IProjectaccess
	{
		public Projectaccess Clone()
		{
			Projectaccess c = new Projectaccess();
			c.Paid = Paid;
			c.Title = Title;
			c.Acccon = Acccon;
			c.Aladd = Aladd;
			c.Alupd = Alupd;
			c.Alrem = Alrem;
			c.Puid = Puid;
			c.Pu = Pu;

			return c;
		}
	}
}
