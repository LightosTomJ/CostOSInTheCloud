
namespace Models.local
{
	public class Quotetemplate : BaseClass.Quotetemplate//, Interfaces.IQuotetemplate
	{
		public Quotetemplate Clone()
		{
			Quotetemplate c = new Quotetemplate();
			c.Id = Id;
			c.Xcellfile = Xcellfile;
			c.Editorid = Editorid;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Title = Title;
			c.Ismaterial = Ismaterial;
			c.Layoutid = Layoutid;
			c.Dflt = Dflt;

			return c;
		}
	}
}
