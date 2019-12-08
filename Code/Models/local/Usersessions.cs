
namespace Models.local
{
	public class Usersessions : BaseClass.Usersessions//, Interfaces.IUsersessions
	{
		public Usersessions Clone()
		{
			Usersessions c = new Usersessions();
			c.Id = Id;
			c.Username = Username;
			c.Serialkey = Serialkey;
			c.LoggedinDate = LoggedinDate;
			c.LastupdateDate = LastupdateDate;

			return c;
		}
	}
}
