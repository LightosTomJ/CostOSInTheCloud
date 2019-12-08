
namespace Models.local
{
	public class Cntrlogitem : BaseClass.Cntrlogitem//, Interfaces.ICntrlogitem
	{
		public Cntrlogitem Clone()
		{
			Cntrlogitem c = new Cntrlogitem();
			c.Id = Id;
			c.Logid = Logid;
			c.Fltr = Fltr;
			c.Oprtn = Oprtn;
			c.Itemid = Itemid;
			c.Item = Item;
			c.Prjid = Prjid;

			return c;
		}
	}
}
