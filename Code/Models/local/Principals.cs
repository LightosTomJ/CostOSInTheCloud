
namespace Models.local
{
	public class Principals : BaseClass.Principals//, Interfaces.IPrincipals
	{
		public Principals Clone()
		{
			Principals c = new Principals();
			c.Principalid = Principalid;
			c.Authtype = Authtype;
			c.Color = Color;
			c.Email = Email;
			c.Enbl = Enbl;
			c.Hashkey = Hashkey;
			c.Name = Name;
			c.Password = Password;

			return c;
		}
	}
}
