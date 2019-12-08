
namespace Models.local
{
	public class Takeoffpoint : BaseClass.Takeoffpoint//, Interfaces.ITakeoffpoint
	{
		public Takeoffpoint Clone()
		{
			Takeoffpoint c = new Takeoffpoint();
			c.Id = Id;
			c.Zpos = Zpos;
			c.Xpos = Xpos;
			c.Ypos = Ypos;
			c.Pid = Pid;
			c.Sid = Sid;
			c.Cid = Cid;
			c.Polycount = Polycount;
			c.Pointcount = Pointcount;
			c.Elevcount = Elevcount;
			c.C = C;
			c.P = P;
			c.S = S;

			return c;
		}
	}
}
