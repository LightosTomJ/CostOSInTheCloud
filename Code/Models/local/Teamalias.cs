
namespace Models.local
{
	public class Teamalias : BaseClass.Teamalias//, Interfaces.ITeamalias
	{
		public Teamalias Clone()
		{
			Teamalias c = new Teamalias();
			c.Id = Id;
			c.Team = Team;
			c.Alias = Alias;

			return c;
		}
	}
}
