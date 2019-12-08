
namespace Models.local
{
	public class Paramreturn : BaseClass.Paramreturn//, Interfaces.IParamreturn
	{
		public Paramreturn Clone()
		{
			Paramreturn c = new Paramreturn();
			c.Paramreturnid = Paramreturnid;
			c.Reteq = Reteq;
			c.Paramitemid = Paramitemid;
			c.Paramitem = Paramitem;

			return c;
		}
	}
}
