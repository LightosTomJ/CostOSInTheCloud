
namespace Models.local
{
	public class Userprop : BaseClass.Userprop//, Interfaces.IUserprop
	{
		public Userprop Clone()
		{
			Userprop c = new Userprop();
			c.Id = Id;
			c.Userid = Userid;
			c.Pkey = Pkey;
			c.Pval = Pval;

			return c;
		}
	}
}
