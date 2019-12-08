
namespace Models.local
{
	public class Glbprop : BaseClass.Glbprop//, Interfaces.IGlbprop
	{
		public Glbprop Clone()
		{
			Glbprop c = new Glbprop();
			c.Id = Id;
			c.Pkey = Pkey;
			c.Pval = Pval;

			return c;
		}
	}
}
