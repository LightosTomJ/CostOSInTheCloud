
namespace Models.local
{
	public class Fldfn : BaseClass.Fldfn//, Interfaces.IFldfn
	{
		public Fldfn Clone()
		{
			Fldfn c = new Fldfn();
			c.Fldfnid = Fldfnid;
			c.Name = Name;
			c.Ftype = Ftype;
			c.Fpath = Fpath;
			c.Rpdfnid = Rpdfnid;
			c.Rpdfnfildefcount = Rpdfnfildefcount;
			c.Rpdfn = Rpdfn;

			return c;
		}
	}
}
