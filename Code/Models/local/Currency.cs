
namespace Models.local
{
	public class Currency : BaseClass.Currency//, Interfaces.ICurrency
	{
		public Currency Clone()
		{
			Currency c = new Currency();
			c.Id = Id;
			c.Cname = Cname;
			c.Symbol = Symbol;
			c.Isocode = Isocode;
			c.Isoflag = Isoflag;

			return c;
		}
	}
}
