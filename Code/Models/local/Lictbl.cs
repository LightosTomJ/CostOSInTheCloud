
namespace Models.local
{
	public class Lictbl : BaseClass.Lictbl//, Interfaces.ILictbl
	{
		public Lictbl Clone()
		{
			Lictbl c = new Lictbl();
			c.Id = Id;
			c.Hashkey = Hashkey;

			return c;
		}
	}
}
