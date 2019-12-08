
namespace Models.local
{
	public class Paramoutput : BaseClass.Paramoutput//, Interfaces.IParamoutput
	{
		public Paramoutput Clone()
		{
			Paramoutput c = new Paramoutput();
			c.Paramoutputid = Paramoutputid;
			c.Qtyeq = Qtyeq;
			c.Factoreq = Factoreq;
			c.Labloceq = Labloceq;
			c.Matloceq = Matloceq;
			c.Equloceq = Equloceq;
			c.Subloceq = Subloceq;
			c.Conloceq = Conloceq;
			c.Prdeq = Prdeq;
			c.Title = Title;
			c.Resids = Resids;
			c.Generation = Generation;
			c.Sortorder = Sortorder;
			c.Loopvar = Loopvar;
			c.Paramitemid = Paramitemid;
			c.Paramitem = Paramitem;
			c.Conceptuals = Conceptuals;
			c.Queryresource = Queryresource;

			return c;
		}
	}
}
