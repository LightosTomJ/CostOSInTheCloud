
namespace Models.local
{
	public class Takeofflegend : BaseClass.Takeofflegend//, Interfaces.ITakeofflegend
	{
		public Takeofflegend Clone()
		{
			Takeofflegend c = new Takeofflegend();
			c.Id = Id;
			c.Xpos = Xpos;
			c.Ypos = Ypos;
			c.Zoom = Zoom;
			c.Rotangle = Rotangle;
			c.Legtxt = Legtxt;
			c.Fnt = Fnt;
			c.Fntcolor = Fntcolor;
			c.Cid = Cid;
			c.Lgdcount = Lgdcount;
			c.C = C;

			return c;
		}
	}
}
