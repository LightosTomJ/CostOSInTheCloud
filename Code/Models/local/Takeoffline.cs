
namespace Models.local
{
	public class Takeoffline : BaseClass.Takeoffline//, Interfaces.ITakeoffline
	{
		public Takeoffline Clone()
		{
			Takeoffline c = new Takeoffline();
			c.Id = Id;
			c.Sx = Sx;
			c.Sy = Sy;
			c.Ex = Ex;
			c.Ey = Ey;
			c.Lid = Lid;
			c.Linescount = Linescount;
			c.L = L;
			c.Takeoffpoint = Takeoffpoint;

			return c;
		}
	}
}
