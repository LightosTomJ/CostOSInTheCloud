
namespace Models.local
{
	public class Wsdatamapping : BaseClass.Wsdatamapping//, Interfaces.IWsdatamapping
	{
		public Wsdatamapping Clone()
		{
			Wsdatamapping c = new Wsdatamapping();
			c.Id = Id;
			c.Title = Title;
			c.Celldtingn = Celldtingn;
			c.Groupcol = Groupcol;
			c.Treemapping = Treemapping;
			c.Commentdetect = Commentdetect;
			c.Treedetect = Treedetect;
			c.Tableprefer = Tableprefer;
			c.Wscolident = Wscolident;
			c.Wsrevision = Wsrevision;

			return c;
		}
	}
}
