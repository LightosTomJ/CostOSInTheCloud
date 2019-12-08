
namespace Models.local
{
	public class Unitalias : BaseClass.Unitalias//, Interfaces.IUnitalias
	{
		public Unitalias Clone()
		{
			Unitalias c = new Unitalias();
			c.Id = Id;
			c.Frunit = Frunit;
			c.Tounit = Tounit;

			return c;
		}
	}
}
