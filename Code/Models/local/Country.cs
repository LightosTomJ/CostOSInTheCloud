
namespace Models.local
{
	public class Country : BaseClass.Country//, Interfaces.ICountry
	{
		public Country Clone()
		{
			Country c = new Country();
			c.Id = Id;
			c.Ccode = Ccode;
			c.Cname = Cname;

			return c;
		}
	}
}
