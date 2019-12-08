
namespace Models.local
{
	public class AlcAmusers : BaseClass.AlcAmusers//, Interfaces.IAlcAmusers
	{
		public AlcAmusers Clone()
		{
			AlcAmusers c = new AlcAmusers();
			c.UserGid = UserGid;
			c.UserId = UserId;
			c.Name = Name;
			c.Password = Password;

			return c;
		}
	}
}
