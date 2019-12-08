
namespace Models.local
{
	public class Takeoffcon : BaseClass.Takeoffcon//, Interfaces.ITakeoffcon
	{
		public Takeoffcon Clone()
		{
			Takeoffcon c = new Takeoffcon();
			c.Id = Id;
			c.Title = Title;
			c.Description = Description;
			c.Colour = Colour;
			c.Grouping = Grouping;
			c.Cndtype = Cndtype;
			c.Patterntype = Patterntype;
			c.Shapetype = Shapetype;
			c.Elevation = Elevation;
			c.Samples = Samples;
			c.Height = Height;
			c.Width = Width;
			c.Depth = Depth;
			c.Thickness = Thickness;
			c.Takeoff = Takeoff;
			c.Editorid = Editorid;
			c.Createuserid = Createuserid;
			c.Lastupdate = Lastupdate;
			c.Createdate = Createdate;
			c.Qty1type = Qty1type;
			c.Qty2type = Qty2type;
			c.Qty3type = Qty3type;
			c.Uom1 = Uom1;
			c.Uom2 = Uom2;
			c.Uom3 = Uom3;
			c.Qty1 = Qty1;
			c.Qty2 = Qty2;
			c.Qty3 = Qty3;
			c.Projectinfoid = Projectinfoid;
			c.Projectinfo = Projectinfo;
			c.Takeoffarea = Takeoffarea;
			c.Takeofflegend = Takeofflegend;
			c.Takeoffline = Takeoffline;
			c.Takeoffpoint = Takeoffpoint;

			return c;
		}
	}
}
