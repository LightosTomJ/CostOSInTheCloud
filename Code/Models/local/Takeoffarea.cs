
namespace Models.local
{
	public class Takeoffarea : BaseClass.Takeoffarea//, Interfaces.ITakeoffarea
	{
		public Takeoffarea Clone()
		{
			Takeoffarea c = new Takeoffarea();
			c.Id = Id;
			c.Blankfill = Blankfill;
			c.Conline = Conline;
			c.Tension = Tension;
			c.Aid = Aid;
			c.Areacount = Areacount;
			c.A = A;
			c.Takeoffpoint = Takeoffpoint;
			c.Takeofftriangle = Takeofftriangle;

			return c;
		}
	}
}
