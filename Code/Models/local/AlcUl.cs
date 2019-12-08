
namespace Models.local
{
	public class AlcUl : BaseClass.AlcUl//, Interfaces.IAlcUl
	{
		public AlcUl Clone()
		{
			AlcUl c = new AlcUl();
			c.Ulgid = Ulgid;
			c.Ulla = Ulla;
			c.Ulflag = Ulflag;

			return c;
		}
	}
}
