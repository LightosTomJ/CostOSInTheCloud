
namespace Models.local
{
	public class BcScene : BaseClass.BcScene//, Interfaces.IBcScene
	{
		public BcScene Clone()
		{
			BcScene c = new BcScene();
			c.Id = Id;
			c.Sguid = Sguid;
			c.Sname = Sname;
			c.Sdata = Sdata;
			c.Stype = Stype;

			return c;
		}
	}
}
