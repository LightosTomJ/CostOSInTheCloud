
namespace Models.local
{
	public class Xcellfile : BaseClass.Xcellfile//, Interfaces.IXcellfile
	{
		public Xcellfile Clone()
		{
			Xcellfile c = new Xcellfile();
			c.Xcellid = Xcellid;
			c.Xcellfile1 = Xcellfile1;
			c.Sheet = Sheet;
			c.Cellx = Cellx;
			c.Celly = Celly;
			c.Projecttemplate = Projecttemplate;

			return c;
		}
	}
}
