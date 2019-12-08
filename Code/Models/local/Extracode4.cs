
namespace Models.local
{
	public class Extracode4 : BaseClass.Extracode4//, Interfaces.IExtracode4
	{
		public Extracode4 Clone()
		{
			Extracode4 c = new Extracode4();
			c.Groupcodeid = Groupcodeid;
			c.Lastupdate = Lastupdate;
			c.Description = Description;
			c.Groupcode = Groupcode;
			c.Title = Title;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Ufact = Ufact;
			c.Unit = Unit;

			return c;
		}
	}
}
