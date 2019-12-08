
namespace Models.local
{
	public class Wsfile : BaseClass.Wsfile//, Interfaces.IWsfile
	{
		public Wsfile Clone()
		{
			Wsfile c = new Wsfile();
			c.Id = Id;
			c.Xmlfile = Xmlfile;
			c.Title = Title;
			c.Fpath = Fpath;
			c.Xcellfile = Xcellfile;
			c.Numsheets = Numsheets;
			c.Filerevid = Filerevid;
			c.Actsheets = Actsheets;
			c.Tcmfile = Tcmfile;
			c.Filerev = Filerev;

			return c;
		}
	}
}
