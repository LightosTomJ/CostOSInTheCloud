
namespace Models.local
{
	public class AlcUserGroups : BaseClass.AlcUserGroups//, Interfaces.IAlcUserGroups
	{
		public AlcUserGroups Clone()
		{
			AlcUserGroups c = new AlcUserGroups();
			c.UserId = UserId;
			c.GroupId = GroupId;

			return c;
		}
	}
}
