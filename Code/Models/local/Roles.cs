
namespace Models.local
{
	public class Roles : BaseClass.Roles//, Interfaces.IRoles
	{
		public Roles Clone()
		{
			Roles c = new Roles();
			c.Roleid = Roleid;
			c.Principalid = Principalid;
			c.Role = Role;
			c.Rolegroup = Rolegroup;

			return c;
		}
	}
}
