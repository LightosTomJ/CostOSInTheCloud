
namespace Models.local
{
	public class Takeofftriangle : BaseClass.Takeofftriangle//, Interfaces.ITakeofftriangle
	{
		public Takeofftriangle Clone()
		{
			Takeofftriangle c = new Takeofftriangle();
			c.Id = Id;
			c.Xpos1 = Xpos1;
			c.Ypos1 = Ypos1;
			c.Zpos1 = Zpos1;
			c.Xpos2 = Xpos2;
			c.Ypos2 = Ypos2;
			c.Zpos2 = Zpos2;
			c.Xpos3 = Xpos3;
			c.Ypos3 = Ypos3;
			c.Zpos3 = Zpos3;
			c.Tid = Tid;
			c.Triacount = Triacount;
			c.T = T;

			return c;
		}
	}
}
